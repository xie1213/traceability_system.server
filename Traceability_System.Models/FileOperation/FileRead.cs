using Appraisal_System.Utility;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public string Complete = "D:\\FTP";
        string today = DateTime.Today.ToString("yyyy-MM-dd");



        public async Task ProcessFileAsync(string fileName, string folder)
        {
            if (IsFileLocked(fileName))
            {
                _loger.Warn($"文件 {fileName} 被占用，无法处理");
                return;
            }

            string[] lines;
            using (var reader = new StreamReader(fileName))
            {
                lines = File.ReadLines(fileName).ToArray();
                if (lines.Length == 0)
                {
                    await UploadFileAsync(fileName, folder, "Error");
                    _loger.Error($"{fileName} 读取错误,数据为空");
                    return;
                }
            }

            // 2. 移动文件到处理目录
            string processingFolder = Path.Combine(Complete,folder, "_processing");
            Directory.CreateDirectory(processingFolder); // 确保目录存在
            string processingFilePath = Path.Combine(processingFolder, Path.GetFileName(fileName));
            try
            {
                File.Move(fileName, processingFilePath); // 文件移动操作
            }
            catch (Exception ex)
            {
                _loger.Error($"文件 {fileName} 移动失败, 跳过当前文件, 错误信息: {ex.Message}");
                return;
            }


            var strFile = lines[RowIndex].Split(',')[ColIndex];
            var strtime = lines[RowIndex].Split(',')[0];
            string tableName = folder + "Table";
            List<string> list;
            try
            {
                // 分析表
                list = await ParseDataAsync(strFile, folder);
            }
            catch (Exception ex)
            {
                await UploadFileAsync(processingFilePath, folder, "Error");
                _loger.Error($"文件 {fileName} 读取失败,错误信息: {ex.Message}");
                return;
            }
            //获取表列名
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
            try
            {
                if (sqlTest != null)
                {
                    int renew = await _sqlHelper.BuildUpdateQuery(renewParameter);
                    if (renew >= 1)
                    {
                        Console.WriteLine($"表:{tableName},序列号:{keyValue[1]},更新成功,已更新{renewParameter.renewNum + 1}次");

                        // 移动文件到完成目录
                        await UploadFileAsync(processingFilePath, folder, "Complete");
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
            }
            catch (Exception ex)
            {
                _loger.Error($"数据库操作失败{fileName}");
                return;
            }

        }

        
        



        private async Task<List<string>> ParseDataAsync(string str, string dirName)
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
    }
}

