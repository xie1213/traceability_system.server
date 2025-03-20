using Appraisal_System.Utility;
using System.Transactions;
using Traceability_System.DTO;
using Traceability_System.Models.CharAnalysis;
using Traceability_System.Utility;

namespace Traceability_System.Models.FileOperation
{
    public class FileRead
    {
        readonly LogHelper _loger = new();
        readonly SqlHelper _sqlHelper = new();
        readonly ProofData _proofData = new();

        int ColIndex = 1; // 第二列的索引（索引从0开始）
        int RowIndex = 3; // 第四行的索引（索引从0开始）
        //int retryCount = 0;
        int maxRetries = 5;
        string error = "Error";
        string complete = "Complete";

        public string dirFile = "D:\\FTP";
        string today = DateTime.Today.ToString("yyyy-MM-dd");



        public async Task ProcessFileAsync(string fileName, string folder)
        {

            string tableName = folder + "Table";
            List<string> list;
            string strFile, strtime = "";

            string[] lines = await ReadFileWithRetryAsync(fileName);
            if (lines == null) return;

            // 检查行数是否足够
            if (lines.Length <= RowIndex)
            {

                _loger.logDir = CeratePath(fileName, error, folder);
                _loger.Error($"文件 {fileName} 行数不足，至少需要 {RowIndex + 1} 行");
                await UploadFileAsync(fileName, folder, error);
                return;
            }

            strFile = lines[RowIndex].Split(',')[ColIndex];
            strtime = lines[RowIndex].Split(',')[0];
            


            try
            {
                // 分析表
                list = ParseDataAsync(strFile, folder);
                //await UploadFileAsync(fileName, folder, "Complete");
            }
            catch (Exception ex)
            {
                await UploadFileAsync(fileName, folder, error);
                _loger.Error($"文件 {fileName} 读取失败,错误信息: {ex.Message}");
                return;
            }

            try
            {
                bool success = await CreateSQLAsync(fileName, folder, tableName, list, strtime);
                if (success)
                {
                    await UploadFileAsync(fileName, folder, complete);
                }
            }
            catch (Exception ex)
            {
                var logs = Path.GetFileNameWithoutExtension(fileName);


                _loger.logDir = CeratePath(fileName, error, folder);

                _loger.Error($"数据添加到数据库错误\t{ex.Message}");
                await UploadFileAsync(fileName, folder, error);
                throw;
            }




            //获取表列名



        }

        public async Task<string[]> ReadFileWithRetryAsync(string filePath)
        {
            int retryCount = 0;
            while (retryCount < maxRetries)
            {
                try
                {
                    if (IsFileLocked(filePath))
                    {
                        retryCount++;
                        if (retryCount >= maxRetries)
                        {
                            _loger.Warn($"文件 {filePath} 被占用，重试次数已用完");
                            throw new IOException($"文件 {filePath} 被占用");
                        }
                        await Task.Delay(1000); // 等待1秒后重试
                    }
                    else
                    {
                        using (var reader = new StreamReader(filePath))
                        {
                            return (await reader.ReadToEndAsync()).Split(Environment.NewLine);
                        }
                    }
                }
                catch (IOException ex)
                {
                    retryCount++;
                    if (retryCount >= maxRetries)
                    {
                        _loger.Error($"文件 {filePath} 读取失败，重试次数已用完，错误信息: {ex.Message}");
                        break;
                    }
                    await Task.Delay(1000); // 等待1秒后重试
                }
            }
            return null;
        }

        async Task<bool> CreateSQLAsync(string fileName, string folder, string tableName, List<string> list, string strtime)
        {
            var colName = SqlHelper.GetSqlColumnName(tableName);

            var keyValue = _proofData.KeyValues(tableName, list);

            // 从数据库中读取更新次数
            string sql = $"select Number from {tableName} where {keyValue[0]} = '{keyValue[1]}'";

            var sqlTest = await SqlHelper.ExecuteScalarAsync(sql);

            RenewParameter renewParameter = new RenewParameter()
            {
                tableName = tableName,
                colNameList = colName,
                valueList = list,
                specify = keyValue,
                renewTime = strtime,
                renewNum = Convert.ToInt32(sqlTest)
            };

            if (sqlTest == null)
            {
                try
                {

                    SqlHelper.BatchAddTable(renewParameter);
                    Console.WriteLine($"表:{tableName},序列号:{keyValue[1]},添加成功");
                    return true;
                }
                catch (Exception ex)
                {
                    {
                        _loger.Warn($"添加失败:{tableName},序列号:{keyValue[1]} \n错误:{ex.Message} ");
                        return false;
                    }
                }
            }
            else
            {
                try
                {
                    await _sqlHelper.BuildUpdateQuery(renewParameter);
                    Console.WriteLine($"表:{tableName},序列号:{keyValue[1]},更新成功,已更新{renewParameter.renewNum + 1}次");
                    return true;
                }
                catch (Exception ex)
                {
                    _loger.Warn($"更新失败:{tableName},序列号:{keyValue[1]} \n错误:{ex.Message} ");
                    return false;

                }
            }
        }


        private async Task<bool> ExecuteTransactionAsync(string fileName, string folder, string tableName, List<string> list, string strtime)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                // 存储数据
                bool dbSuccess = await CreateSQLAsync(fileName, folder, tableName, list, strtime);
                if (!dbSuccess)
                {
                    return false;
                }

                // 移动文件
                await UploadFileAsync(fileName, folder, complete);

                // 提交事务
                transaction.Complete();
                return true;
            }
        }


        private List<string> ParseDataAsync(string str, string dirName)
        {
            var parserMap = new Dictionary<string, Func<object>>
            {
                { "Motor", () => new Motor_Parse(str) },
                { "Gear", () => new Gaer_Rotor_Parse(str) },
                { "Rotor", () => new Rotor_Parse(str) },
                { "Rr", () => new RR_Parse(str) },
                { "TA", () => new TA_Parse(str) }
            };

            var methodMap = new Dictionary<string, Func<object, List<string>>>
            {
                { "Motor", rotor => ((Motor_Parse)rotor).MotorSplitList() },
                { "Gear", rotor => ((Gaer_Rotor_Parse)rotor).RR_and_GearSplitList() },
                { "Rotor", rotor => ((Rotor_Parse)rotor).RR_and_GearSplitList() },
                { "Rr", rotor => ((RR_Parse)rotor).RR_SplitList() },
                { "TA", rotor => ((TA_Parse)rotor).TA_SplitList() }
            };

            if (!parserMap.ContainsKey(dirName) || !methodMap.ContainsKey(dirName))
            {
                throw new ArgumentException($"未知的目录名称: {dirName}");
            }

            var parser = parserMap[dirName]();
            return methodMap[dirName](parser);
        }



        public bool IsFileLocked(string filePath)
        {
            try
            {
                using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    stream.Close();
                }
                return false; // 文件未被占用
            }
            catch (IOException)
            {
                return true; // 文件被占用
            }
        }



        public async Task UploadFileAsync(string oldPath, string folder, string state)
        {
            if (!File.Exists(oldPath))
            {
                Logger.WriteLogAsync($"{oldPath} 文件不存在");
                return;
            }
            int retries = 0;
            while (retries < maxRetries)
            {
                {
                    try
                    {
                        string fileDirectory = Path.GetFileName(oldPath);
                        string newPath = CeratePath(oldPath, state, folder);

                        string newFilePath = Path.Combine(newPath, fileDirectory);

                        if (File.Exists(newFilePath))
                        {
                            File.Delete(newFilePath);
                        }

                        File.Move(oldPath, newFilePath);
                        return;
                    }
                    catch (IOException ex)
                    {
                        retries++;
                        if (retries >= maxRetries)
                        {
                            Logger.WriteLogAsync($"文件{oldPath} 正在被占用 , 跳过次数:{retries}");
                            //throw;
                            break;
                        }
                        // 等待一段时间后重试
                        await Task.Delay(1000);
                    }
                    catch (Exception e)
                    {
                        Logger.WriteLogAsync($"移动文件失败, {e.Message}");
                        throw; // 保留原始异常信息
                    }
                }
            }
        }

        string CeratePath(string oldPath, string state, string folder)
        {
            string fileName = Path.GetFileName(oldPath);
            string fileDirectory = Path.GetFileName(Path.GetDirectoryName(oldPath));
            string newPath = Path.Combine(dirFile, state, today, folder, fileDirectory);

            Directory.CreateDirectory(newPath);
            return newPath;

        }
    }
}

