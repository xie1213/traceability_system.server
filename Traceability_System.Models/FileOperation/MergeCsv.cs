using Appraisal_System.Utility;
using Microsoft.VisualBasic.FileIO;
using System.Text;
using Traceability_System.Utility;

namespace Traceability_System.Models.FileOperation
{
    public class MergeCsv
    {
        string dirPath = @"\\192.168.0.10\\meiwa\\CSV";

        public void GetDirList()
        {

            var ipchack = IPInspect();
            if (ipchack != "链接成功")
                return;
            try
            {
                List<string> csvDir = Directory.GetDirectories(dirPath).ToList();
                if(csvDir == null)
                {
                    return;
                }
                foreach (string csvFliesDir in csvDir)
                {
                    //二级文件
                    List<string> csvFiles = Directory.GetDirectories(csvFliesDir).ToList();
                    if (csvFiles == null)
                    {
                        return;
                    }
                    foreach (string csvFile in csvFiles)
                    {
                        if (File.Exists(csvFile))
                        {
                            GetAllCsvs(csvFile);

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

        //获取该文件下的所有csv文件
        public void GetAllCsvs(string csvFile)
        {
            try
            {
                string[] csvItemGather = Directory.GetFiles(csvFile, "*.csv");

                string pathName = Path.GetFileName(csvFile);
                foreach (var item in csvItemGather)
                {
                    string itemName = Path.GetFileNameWithoutExtension(item);
                    var itemValue = ReadCsv(item, pathName);
                    RedisHelper.RedisSet(itemName, itemValue);
                }
            }
            catch (Exception e)
            {

                Logger.WriteLogAsync($"获取出荷文件时出现错误:{e.Message}");
            }


        }

        //读取Csv文件并保存到数据库
        public string ReadCsv(string itemName, string pathName)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            try
            {
                string sql = "";
                using (TextFieldParser parser = new TextFieldParser(itemName, Encoding.GetEncoding("gb18030")))
                {
                    // 指定分隔符（CSV文件一般使用逗号作为分隔符）
                    parser.Delimiters = new string[] { "," };

                    // 设置是否处理引号
                    parser.HasFieldsEnclosedInQuotes = true;

                    // 循环读取每一行
                    while (!parser.EndOfData)
                    {
                        // 获取当前行的字段数组
                        string[] fields = parser.ReadFields();
                        var isNull = GetBySerialNo(fields[0]);
                        if (pathName == "Senko")
                        {

                            if (isNull)
                            {
                                //break;
                                sql = $"update Shipping set ProductNo = '{fields[1]}',Printing = '{fields[5]}',LeadTime = '{fields[2]}' where SerialNo = '{fields[0]}' ";
                                //Console.WriteLine("有值");
                            }
                            else
                            {
                                sql = $"insert into Shipping (SerialNo,ProductNo,Printing,LeadTime) ";
                                sql += $" values('{fields[0]}','{fields[1]}','{fields[5]}','{fields[2]}') ";
                            }
                        }
                        else
                        {
                            if (isNull)
                            {
                                sql = $"update Shipping set ShippingTime = '{fields[16]}',Destination = '{fields[12]}'," +
                                $"DestinationArea = '{fields[18]}',ReceivingPoint = '{fields[19]}',BackNo = '{fields[20]}'," +
                                $"OrderNo = '{fields[22]}',PlineNo = '{fields[23]}',ReceivingNo = '{fields[21]}',Operator = '{fields[17]}' " +
                                $"where SerialNo = '{fields[0]}'";
                            }
                            else
                            {
                                sql = $"insert into Shipping (SerialNo,ShippingTime,Destination,DestinationArea,ReceivingPoint,BackNo,OrderNo,PlineNo,ReceivingNo,Operator)" +
                                    $"values('{fields[0]}','{fields[16]}','{fields[12]}','{fields[18]}','{fields[19]}','{fields[20]}'," +
                                    $"'{fields[22]}','{fields[23]}','{fields[21]}','{fields[17]}')";
                            }


                        }
                        SqlHelper.ExecuteNonQuery(sql);

                        return sql;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return itemName;
        }

        //根据序列号获取数据
        public bool GetBySerialNo(string SerialNo)
        {
            string sql = $"select * from Shipping where SerialNo = '{SerialNo}'";
            var str = SqlHelper.ExecuteScalar(sql);
            return str == null ? false : true;
        }

        //检查ip通不通
        public string IPInspect()
        {
            string ipAddress = "192.168.0.10";
            IPInspect iPInspect = new IPInspect(ipAddress);
            var lastPingStatus = iPInspect.IPInspectMethod();

            return lastPingStatus.ToString();
        }
    }
}
