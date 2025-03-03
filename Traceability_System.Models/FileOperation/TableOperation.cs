using Appraisal_System.Utility;
using NPOI.HPSF;
using Traceability_System.DTO;
using Traceability_System.Models.CharAnalysis;
using Traceability_System.Utility;

namespace Traceability_System.Models.FileOperation;

public class TableOperation
{
    readonly SqlHelper _sqlHelper = new();
    readonly LogHelper _logHelper = new();
    readonly FileRead _fileRead = new();

    public List<string> PathList = new();
    int ColIndex = 1; // 第二列的索引（索引从0开始）
    int RowIndex = 3; // 第四行的索引（索引从0开始）
    string DirPath = "D:\\FTP\\";

    public string Complete = "D:\\FTP";
    string today = DateTime.Today.ToString("yyyy-MM-dd");

    //public static SemaphoreSlim _fileAccessSemaphore = new SemaphoreSlim(1, 1);

    //检查文件夹中是否有文件
    public async Task DirectoryExist(string folder)
    {
        string newPath = Path.Combine(DirPath, folder);
        var dirPathlist = Directory.GetDirectories(newPath).ToList();

        if (dirPathlist.Count == 0) return;

        List<string> directoriesToDelete = new List<string>();

        foreach (var item in dirPathlist)
        {
            try
            {
                if (!Directory.Exists(item))
                    continue;


                string[] files = Directory.GetFiles(item, "*.csv");
                if (files.Length == 0)
                {
                    directoriesToDelete.Add(item);
                    continue;
                }

                await Parallel.ForEachAsync(files, async (fileName, cancellationToken) =>
                {
                    await _fileRead.ProcessFileAsync(fileName, folder);
                });
            }
            catch (Exception ex)
            {
                _logHelper.Error($"文件读取异常:{ex.Message}");
                throw;
            }

        }
        DeleteEmptyDirectories(directoriesToDelete);
    }
    private void DeleteEmptyDirectories(List<string> directoriesToDelete)
    {
        foreach (var dirToDelete in directoriesToDelete)
        {
            try
            {
                if (Directory.Exists(dirToDelete))
                {
                    Directory.Delete(dirToDelete, true); // 删除目录及其内容
                    _logHelper.Info($"目录 {dirToDelete} 已删除");
                }
            }
            catch (Exception ex)
            {
                _logHelper.Error($"删除目录 {dirToDelete} 失败, 错误信息: {ex.Message}");
            }
        }
    }

    //读取文件并移动文件
    public async Task GetCsvCellValueTask(string fileName, string folder)
    {
        if (!File.Exists(fileName))
            return;

        int retryCount = 0;
        const int maxRetryCount = 5;
        while (retryCount < maxRetryCount)
        {
            try
            {
                using (var reader = new StreamReader(fileName))
                {
                    ProofData proofData = new ProofData();

                    string[] lines = File.ReadLines(fileName).ToArray();
                    if (lines.Length == 0)
                        return;

                    var strFile = lines[RowIndex].Split(',')[ColIndex];
                    var strtime = lines[RowIndex].Split(',')[0];
                    string tableName = folder + "Table";

                    // 获取数据分析结果

                    var list = await GetAnalysis(strFile, fileName, folder);

                    // 获取表的列名
                    var colName = SqlHelper.GetSqlColumnName(tableName);


                    var keyValue = proofData.KeyValues(tableName, list);

                    //从数据库中读取更新次数
                    string sql = $"select Number from {tableName}  where {keyValue[0]} = '{keyValue[1]}' ";
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


                    if (sqlTest != null)
                    {
                        int renew = await _sqlHelper.BuildUpdateQuery(renewParameter);
                        if (renew >= 1)
                        {
                            Console.WriteLine($"表:{tableName},序列号:{keyValue[1]},更新成功,已更新{renewParameter.renewNum + 1}次");

                            await UploadFileAsync(fileName, folder, "Complete");
                        }

                    }
                    else
                    {
                        var AddTable = SqlHelper.BatchAddTable(renewParameter);
                        if (AddTable)
                        {

                            Console.WriteLine($"表:{tableName},序列号:{keyValue[1]},添加成功");

                            await UploadFileAsync(fileName, folder, "Complete");
                        }
                    }
                }
                break;

            }
            catch (IOException ex)
            {
                //L
                retryCount += 1;
                if (retryCount >= maxRetryCount)
                {
                    _logHelper.Warn($"文件 {fileName} 正在被另一个程序调用，跳过,跳过次数 {retryCount}");
                    break;
                }

                await Task.Delay(1000); // 等待1秒钟后重试
            }
            catch (Exception ex)
            {
                Logger.WriteLogAsync($"读取文件{fileName}失败,因为:{ex.Message}");
                //await UploadFileAsync(fileName, folder, "Error");
                throw;
            }
        }
    }






    // 提取字符串长度验证逻辑到单独的方法
    bool ValidateStringLength(string str)
    {
        return str.Length == 2000 ? true : false;
    }

    //根据表名获取解析文件得方法
    async Task<List<string>> GetAnalysis(string str, string filePath, string dirName)
    {
        //Console.WriteLine(dirName);
        object rotor;
        List<string> strList = new List<string>();
        try
        {
            switch (dirName)
            {
                case "Motor":
                    rotor = new Motor_Parse(str);
                    strList = ((Motor_Parse)rotor).MotorSplitList();
                    break;
                case "Gear":
                    rotor = new Gaer_Rotor_Parse(str);
                    strList = ((Gaer_Rotor_Parse)rotor).RR_and_GearSplitList();
                    break;
                case "Rotor":
                    rotor = new Rotor_Parse(str);
                    strList = ((Rotor_Parse)rotor).RR_and_GearSplitList();
                    break;
                case "Rr":
                    rotor = new RR_Parse(str);
                    strList = ((RR_Parse)rotor).RR_SplitList();
                    break;
                case "TA":
                    rotor = new TA_Parse(str);
                    strList = ((TA_Parse)rotor).TA_SplitList();
                    break;
            }

            return strList;
        }
        catch (Exception ex)
        {
            Logger.WriteLogAsync($"解析{dirName}表失败:{ex.Message}");
            //Console.WriteLine(str + "error");
            await UploadFileAsync(filePath, dirName, "Error");
            throw;
        }

    }


    //移动文件
    public void UploadFile(string oldPath, string folder)
    {
        if (!File.Exists(oldPath))
            return;
        try
        {
            //await TableOperation._fileAccessSemaphore.WaitAsync(); // 获取文件信号保证只有一个


            string fileName = Path.GetFileName(oldPath);


            string fileDirectory = Path.GetFileName(Path.GetDirectoryName(oldPath));


            string newPath = Path.Combine(Complete, today, folder, fileDirectory);

            Directory.CreateDirectory(newPath);

            string newFilePath = Path.Combine(newPath, fileName);

            if (File.Exists(newFilePath))
            {
                File.Delete(newFilePath);
            }
            File.Move(oldPath, newFilePath);


        }
        catch (IOException ex)
        {


            Logger.WriteLogAsync($"无法移动文件'{oldPath}',{ex.Message}。");
            // 可以选择等待一段时间或者尝试其他方式来解决这个问题
            return;
        }
        catch (Exception e)
        {
            Logger.WriteLogAsync($"错误文件{oldPath},{e.Message}");
            throw; // 保留原始异常信息
        }
    }

    public async Task UploadFileAsync(string oldPath, string folder, string state, int maxRetries = 3)
    {
        if (!File.Exists(oldPath))
        {
            Logger.WriteLogAsync($"{oldPath} 文件不存在");
            return;
        }

        int retries = 0;
        while (retries < maxRetries)
        {
            try
            {
                string fileName = Path.GetFileName(oldPath);
                string fileDirectory = Path.GetFileName(Path.GetDirectoryName(oldPath));
                string newPath = Path.Combine(Complete, state, today, folder, fileDirectory);

                Directory.CreateDirectory(newPath);
                string newFilePath = Path.Combine(newPath, fileName);

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

