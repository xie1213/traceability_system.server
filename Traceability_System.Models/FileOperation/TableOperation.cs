using Appraisal_System.Utility;
using Traceability_System.DTO;
using Traceability_System.Models.CharAnalysis;
using Traceability_System.Utility;

namespace Traceability_System.Models.FileOperation;

public class TableOperation
{

    public List<string> PathList = new();
    int ColIndex = 1; // 第二列的索引（索引从0开始）
    int RowIndex = 3; // 第四行的索引（索引从0开始）
    string DirPath = "D:\\FTP\\";

    public string Complete = "D:\\FTP\\Complete";
    string today = DateTime.Today.ToString("yyyy-MM-dd");

    readonly SqlHelper _sqlHelper = new();

    //public static SemaphoreSlim _fileAccessSemaphore = new SemaphoreSlim(1, 1);

    //检查文件夹中是否有文件
    public async Task DirectoryExist(string folder)
    {
        string newPath = Path.Combine(DirPath, folder);
        List<string> directoriesToDelete = new List<string>();
        var dirPathlist = Directory.GetDirectories(newPath).ToList();
        if (dirPathlist.Count > 0)
        {
            foreach (var item in dirPathlist)
            {
                string[] files = Directory.GetFiles(item, "*.csv");
                if (files.Length == 0)
                {
                    directoriesToDelete.Add(item);
                    continue;
                }

                foreach (var fileName in files)
                {
                   await GetCsvCellValueTask(fileName, folder);
                }
            }

            // 在循环外部执行删除操作
            foreach (var dirToDelete in directoriesToDelete)
            {
                Directory.Delete(dirToDelete);
                dirPathlist.Remove(dirToDelete);
            }
        }

    }

    //读取文件并移动文件
    public async Task GetCsvCellValueTask(string fileName, string folder)
    {
        if (!File.Exists(fileName))
        {
            return;
        }
        try
        {
            using (var reader = new StreamReader(fileName))
            {
                //await _fileAccessSemaphore.WaitAsync(); // 获取文件信号保证只有一个
                ProofData proofData = new ProofData();
                string[] lines = File.ReadLines(fileName).ToArray();
                if (lines.Length == 0)
                {
                    return;
                }

                var strFile = lines[RowIndex].Split(',')[ColIndex];
                var strtime = lines[RowIndex].Split(',')[0];
                string tableName = folder + "Table";

                // 获取数据分析结果

                var list = GetAnalysis(strFile, fileName, folder);

                // 获取表的列名
                var colName = SqlHelper.GetSqlColumnName(tableName);


                var keyValue = proofData.KeyValues(tableName, list);

                //从数据库中读取更新次数
                string sql = $"select Number from {tableName}  where {keyValue[0]} = '{keyValue[1]}' ";
                var sqlTest = SqlHelper.ExecuteScalar(sql);

                RenewParameter renewParameter = new RenewParameter();
                renewParameter.tableName = tableName;
                renewParameter.colNameList = colName; ;
                renewParameter.valueList = list;
                renewParameter.specify = keyValue;
                renewParameter.renewTime = strtime;
                renewParameter.renewNum = Convert.ToInt32(sqlTest);

                if (sqlTest != null)
                {
                    int renew = await _sqlHelper.BuildUpdateQuery(renewParameter);
                    if (renew >= 1)
                    {
                        Console.WriteLine($"表:{tableName},序列号:{keyValue[1]},更新成功,已更新{renewParameter.renewNum + 1}次");
                        //Logger.WriteLogAsync($"表:{tableName},序列号:{keyValue[1]},更新成功,已更新{renewParameter.renewNum + 1}次");

                    }

                }
                else
                {
                    var AddTable = SqlHelper.BatchAddTable(renewParameter);
                    if (AddTable)
                    {

                        Console.WriteLine($"表:{tableName},序列号:{keyValue[1]},添加成功");
                        //Logger.WriteLogAsync($"表:{tableName},序列号:{keyValue[1]},添加成功");
                    }


                    //Logger.WriteLogAsync(fileName + "添加成功");

                }
                //Logger.WriteLogAsync($"旧文件路径:{fileName}");
            }
            UploadFile(fileName, folder);

        }
        catch (IOException ex)
        {
            // 可以选择等待一段时间或者尝试其他方式来解决这个问题
            Logger.WriteLogAsync($"'{fileName} 错误 {ex.Message}'");
            return;
        }
        catch (Exception ex)
        {
            Logger.WriteLogAsync(fileName + "解析失败" + ex.Message);
            throw;
        }

    }




    // 提取字符串长度验证逻辑到单独的方法
    bool ValidateStringLength(string str)
    {
        return str.Length == 2000 ? true : false;
    }

    //根据表名获取解析文件得方法
    List<string> GetAnalysis(string str, string filePath, string dirName)
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
            Logger.WriteLogAsync($"解析表失败{ex.Message}");
            //Console.WriteLine(str + "error");
            throw;
        }

    }


    //移动文件
    public void UploadFile(string oldPath, string folder)
    {
        if (!File.Exists(oldPath))
        {
            //Console.WriteLine(oldPath + "文件不存在");
            return;
        }
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

            // 删除源文件
            //if (File.Exists(newFilePath))
            //{
            //    File.Delete(oldPath);
            //}
            Logger.WriteLogAsync($"新文件路径 {newFilePath}\r\n");

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


}

