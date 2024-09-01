using Appraisal_System.Utility;
using Microsoft.VisualBasic.FileIO;
using System.Globalization;
using System.Text;
using Traceability_System.Utility;

namespace Traceability_System.Models.FileOperation
{
    public class MergeCsv
    {
        string dirPath = @"\\192.168.0.10\\meiwa\\CSV";

        //string dirPath = @"C:\\Users\\x1769\\Desktop\\CSV";
        private readonly RedisHelper _redisHelper;
        private static object lockObject = new object();
        string path = "D:\\Traceability\\Ship";

        public MergeCsv(RedisHelper redisHelper)
        {
            _redisHelper = redisHelper;
        }

        public async Task GetDirList()
        {
            if (IPInspect() != "链接成功" || !Directory.Exists(dirPath))
                return;
            try
            {

                //获取路径下的所有子目录
                List<string> csvDir = Directory.GetDirectories(dirPath).ToList();
                if (csvDir == null)
                    return;

                foreach (string csvFliesDir in csvDir)
                {

                    //获取二级文件下是否存在文件
                    List<string> csvFiles = Directory.GetDirectories(csvFliesDir).ToList();

                    //List<string> csvFiles = Directory.GetFiles(csvFliesDir).ToList();

                    if (csvFiles == null)
                        return;

                    //循环输出文件路径

                    for (int i = 0; i < csvFiles.Count; i++)
                    {
                        string[] files = Directory.GetFiles(csvFiles[i]);
                        if (files.Length == 0)
                            return;

                        lock (lockObject)
                        {
                            GetCsv(files);

                        }
                    }
                }
            }
            catch (Exception e)
            {

                Logger.WriteLogAsync($"出荷链接错误:{e.Message}");
            }
            //一级文件

        }

        //获取csv文件
        void GetCsv(string[] files)
        {
            for (int i = 0; i < files.Length; i++)
            {
                //string dirPath = GetPath(files[i]);

                string[] parts = files[i].Split('\\');
                string filePath = parts[parts.Length - 3];
                string itemName = filePath + "\\" + parts[parts.Length - 2];

                string item = parts[parts.Length - 1].Replace(".csv", "");
                var redisPath = _redisHelper.GetAllHashValues(itemName, 0);
                //int index = redisPath == null ? -1 : Array.FindIndex(files, file => file.Contains(redisPath));

                if (redisPath.Contains(item) || GetTime(filePath))
                {
                    continue;
                }

                ReadCsv(files[i], itemName, dirPath);

            }
        }

        //读取Csv文件并保存到数据库
        public void ReadCsv(string itemName, string pathName, string dirPath)
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            try
            {
                using (TextFieldParser parser = new TextFieldParser(itemName, Encoding.GetEncoding("gb18030")))
                {
                    // 指定分隔符（CSV文件一般使用逗号作为分隔符）
                    parser.Delimiters = new string[] { "," };

                    // 设置是否处理引号
                    parser.HasFieldsEnclosedInQuotes = true;


                    string[] parts = itemName.Split('\\');
                    // 提取倒数第一个和倒数第二个部分，即最后的文件夹路径部分
                    string lastFolder = parts[parts.Length - 3] + "\\" + parts[parts.Length - 2];
                    string item = parts[parts.Length - 1].Replace(".csv", "");

                    // 循环读取每一行
                    while (!parser.EndOfData)
                    {
                        // 获取当前行的字段数组
                        string[] fields = parser.ReadFields();
                        bool isNull = GetBySerialNo(fields[0].TrimEnd());
                        string numPath = Path.Combine(path, "序列号");

                        string sql = BuildQuery(pathName, isNull, fields, item);

                        SqlHelper.ExecuteNonQuery(sql);

                    }
                    _redisHelper.SetHash(lastFolder, item, 0);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //根据序列号获取数据
        public bool GetBySerialNo(string SerialNo)
        {
            string sql = $"select * from Shipping where SerialNo = '{SerialNo}'";
            var str = SqlHelper.ExecuteScalar(sql);
            return str == null ? false : true;
        }

        //获取sql
        private string BuildQuery(string pathName, bool isNull, string[] fields, string itemName)
        {
            string sql = "";
            if (isNull)
            {
                sql = "UPDATE Shipping SET ";
                if (pathName.Contains("Senko"))
                {
                    sql += $"ProductNo = '{fields[1]}',Printing = '{fields[5]}',LeadTimeDate = '{fields[2]}' ";
                }
                else
                {
                    sql += $"ShippingTimeDate = '{fields[16]}',Destination = '{fields[12]}'," +
                                $"DestinationArea = '{fields[18]}',ReceivingPoint = '{fields[19]}',BackNo = '{fields[20]}'," +
                                $"OrderNo = '{fields[22]}',PlineNo = '{fields[23]}',ReceivingNo = '{fields[21]}',Operator = '{fields[17]}' ";
                }

                Logger.WriteLogAsync($"{pathName}文件下的{itemName}中的{fields[0]}字段更新", path);
                sql += $"WHERE SerialNo = '{fields[0]}'";
            }
            else
            {
                sql = "INSERT INTO Shipping ";
                if (pathName.Contains("Senko"))
                {
                    sql += $"(SerialNo,ProductNo,Printing,LeadTimeDate) ";
                    sql += $" values('{fields[0]}','{fields[1]}','{fields[5]}','{fields[2]}') ";
                }
                else
                {
                    sql += $"(SerialNo,ShippingTimeDate,Destination,DestinationArea,ReceivingPoint," +
                                    $"BackNo,OrderNo,PlineNo,ReceivingNo,Operator)" +
                                    $"values('{fields[0]}','{fields[16]}','{fields[12]}','{fields[18]}','{fields[19]}','{fields[20]}'," +
                                    $"'{fields[22]}','{fields[23]}','{fields[21]}','{fields[17]}')";
                }

            }
            return sql;
        }

        //检查ip通不通
        public string IPInspect()
        {
            string ipAddress = "192.168.0.10";
            IPInspect iPInspect = new IPInspect(ipAddress);
            var lastPingStatus = iPInspect.IPInspectMethod();

            return lastPingStatus.ToString();
        }

        bool GetTime(string fileTime)
        {
            bool timeDate = false;
            DateTime fileDate = DateTime.ParseExact(fileTime, "yyyyMMdd", CultureInfo.InvariantCulture);
            DateTime currentDate = DateTime.Now;
            DateTime twoDaysAgo = currentDate.AddDays(-3);
            if (fileDate < twoDaysAgo)
            {
                timeDate = true;
            }
            return timeDate;
        }
    }
}
