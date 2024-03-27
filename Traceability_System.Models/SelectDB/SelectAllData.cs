using System.Data;
using System.Reflection;
using System.Text;
using Appraisal_System.Utility;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using Traceability_System.DTO;
using Traceability_System.Entity.Model;
using Traceability_System.Models.FileOperation;
using Traceability_System.Utility;

namespace Traceability_System.Models.SelectDB
{
    public class SelectAllData
    {

        private readonly RedisHelper _redisHelper;

        public SelectAllData(RedisHelper redisHelper)
        {
            _redisHelper = redisHelper;
        }

        Dictionary<string, string> tablePatterns = new Dictionary<string, string>
                    {
                        { "MotorTable", "\n ShipmentSerial like '%{0}%'" },
                        { "GearTable", "\n DorpinSerial like '%{0}%'" },
                        { "RotorTable", "\n MG1RSerial like '%{0}%'" },
                        { "Rrtable", "\n RRCoverSerial like '%{0}%'" },
                        { "Tatable", "\n ShipmentSerial like '%{0}%'" },
                        { "全部数据", "\n ShipmentSerial like '%{0}%'" },
                        // 添加更多表名和对应的模式
                        //获取表的列名
                        { "MotorTable_OrderBy", "ShipmentSerial" },
                        { "GearTable_OrderBy", "DorpinSerial" },
                        { "RotorTable_OrderBy", "MG1RSerial" },
                        { "Rrtable_OrderBy", "RRCoverSerial" },
                        { "Tatable_OrderBy", "ShipmentSerial" },
                        { "NewMotorTable_OrderBy", "ShipmentSerial" },
                    };

        //获取表格信息
        public object GetTableByName(SelTableRequest requestData)
        {
            try
            {
                RedisHelper redisHelper = new RedisHelper();
                redisHelper.DeleteHash(requestData.TableName);

                string timeItem = "", selItem = "", serialNo = "";
                string orderByColumn = tablePatterns.TryGetValue($"{requestData.TableName}_OrderBy", out var col) ? col : "";

                if (!requestData.selColName.IsNullOrEmpty())
                {
                    //string column = requestData.selColName[0];
                    //string val1 = requestData.selColName[1];
                    //string val2 = requestData.selColName[2];

                    //string compareExpr = BuildCompareExpr(column, val1, val2);
                    if (requestData.selColName.Count == 3)
                    {
                        selItem = $"{requestData.selColName[0]} between '{requestData.selColName[1]}' and '{requestData.selColName[2]}'";
                    }
                    else
                    {
                        selItem = $"{requestData.selColName[0]} like '5{requestData.selColName[1]}%'";
                    }

                }
                else if (requestData.SerialNo != "")
                {
                    serialNo = $"\n {orderByColumn} like '%{requestData.SerialNo}%'";
                }
                else
                {
                    timeItem = $"CollectionDate BETWEEN '{requestData.TimeDate[0]}' AND '{requestData.TimeDate[1]}' ";
                }


                string selLike = "";

                //if (!string.IsNullOrEmpty(requestData.SerialNo))
                //{
                //    if (tablePatterns.TryGetValue(requestData.TableName, out var pattern))
                //    {
                //        selLike += string.Format("\n" + pattern, requestData.SerialNo);
                //    }
                //}
                if (requestData.TableName == "全部数据")
                {
                    return GetAllTable(timeItem, selItem, selLike);
                }



                string sqlQuery = $"SELECT  * FROM {requestData.TableName} where ";
                if (selItem != "" && serialNo != "")
                {
                    sqlQuery += $"{selItem} and  {serialNo} ";
                }
                else
                {
                    sqlQuery += $"{timeItem} {selItem} {serialNo}";
                }


                sqlQuery+= $"ORDER BY RIGHT({orderByColumn},8) DESC ";

                
                DataTable dt = SqlHelper.ExecuteTable(sqlQuery);

                var list = new List<object>();
                Assembly asm = Assembly.Load("Traceability_System.Entity");
                Type modelType = asm.GetType("Traceability_System.Entity.Model." + requestData.TableName);

                foreach (DataRow dr in dt.Rows)
                {
                    var model = dr.DataRowToType(modelType);
                    var jsonData = JsonConvert.SerializeObject(model);
                    var filed = dr["Id"].ToString();

                    redisHelper.SetHashToJson(requestData.TableName, filed, jsonData);

                    list.Add(model);
                    // RedisHelper.SetHash()
                }
                //string Alljson = JsonConvert.SerializeObject(list);
                var listData = list.Take(25);

                //RedisHelper.SetJsonData("全部数据", Alljson);

                return new { data = listData, count = list.Count() };

            }
            catch (Exception ex)
            {
                // 记录或打印异常详细信息进行调试
                Logger.WriteLogAsync($"发生错误：{ex.Message}");

                // 返回带有错误代码和消息的JSON
                return ex.Message;
            }
        }
        //getpageLimit
        //public static object GetPageData(int page,int limit)
        //{
        //    try
        //    {
        //        return list.Skip((page - 1) * limit).Take(limit); ;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        public object GetOutTable(SelTableRequest requestData)
        {
            string selItem = "", timeItem = "", serialNo = "", sql = "select * from Shipping where";

            try
            {

                if (!requestData.selColName.IsNullOrEmpty())
                {
                    //string column = requestData.selColName[0];
                    //string val1 = requestData.selColName[1];
                    //string val2 = requestData.selColName[2];

                    //string compareExpr = BuildCompareExpr(column, val1, val2);
                    selItem = $"\r  {requestData.selColName[0]} like '%{requestData.selColName[1]}%'";
                }
                else if (requestData.SerialNo != "")
                {
                    serialNo = $"\n SerialNo like '%{requestData.SerialNo}%'";
                }
                else
                {
                    timeItem = $" LeadTime BETWEEN '{requestData.TimeDate[0]}' AND '{requestData.TimeDate[1]}' ";
                }
                if (selItem != "" && serialNo != "")
                {
                    sql += $"{selItem} and  {serialNo} ";
                }
                else
                {

                    sql += $"{timeItem} {selItem} {serialNo}";
                }

                var shipList = new List<object>();

                DataTable dt = SqlHelper.ExecuteTable(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    _redisHelper.DeleteHash(requestData.TableName);
                    foreach (DataRow dr in dt.Rows)
                    {
                        var model = dr.DataRowToModel<Shipping>();
                        var jsonData = JsonConvert.SerializeObject(model);

                        var filed = model.Id.ToString();
                        _redisHelper.SetHashToJson(requestData.TableName, filed, jsonData);

                        shipList.Add(model);
                    }
                    return new { data = shipList.Take(25), count = shipList.Count() };

                }
                else
                {
                    return new { count = 0 };
                }
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
        //判断值类型
        object TryParse(string s)
        {
            if (int.TryParse(s, out int i))
                return i;

            if (DateTime.TryParse(s, out DateTime dt))
                return dt;

            // 其他类型判断

            return s; // 返回字符串
        }
        //返回查询语句
        string BuildCompareExpr(string column, string val1, string val2)
        {
            object obj1 = TryParse(val1);
            object obj2 = TryParse(val2);
            string sql = "";
            // 三元运算符逻辑
            if (val1 == val2)
            {
                return $"{column} like '%{val1}%' ";
            }
            switch (obj1, obj2)
            {
                case (int i1, int i2):
                    sql = $"{column} between {i1} and {i2}";
                    break;
                case (DateTime dt1, DateTime dt2):
                    sql = $"{column} between '{dt1}' and '{dt2}'";
                    break;
                case (string dt1, string dt2):
                    sql = $"{column} like '%{dt1}%' and {column} like '%{dt2}%' ";
                    break;

                    // 其他模式匹配
            }
            return sql;
        }


        object GetAllTable(string timeItem, string selItem, string selLike)
        {
            string sqlQuery = "select * from TATable as ta" +
                       $"\rleft join vw_MotorTable mo on RIGHT(ta.ShipmentSerial,8) = RIGHT(mo.MoShipmentSerial, 8)" +
                       $"\rleft join vw_GearTable as df on ta.DorpinSerial = df.GeDorpinSerial" +
                       $"\rleft join vw1_RotorTable as ro1 on ta.MG1RSerial = ro1.Ro1MG1RSerial and LEFT(ta.MG1RSerial,2) = '11'" +
                       $"\rleft join vw2_RotorTable as ro2 on ta.MG1RSerial = ro2.Ro2MG1RSerial and LEFT(ta.MG1RSerial,2) = '12'" +
                       $"\rleft join vw_RRTable as rr on ta.RRCoverSerial = rr.RRRRCoverSerial" +
                       $"\rwhere {timeItem} {selItem} {selLike} order by RIGHT(ShipmentSerial,8) desc ";
            DataTable resultTable = SqlHelper.ExecuteTable(sqlQuery);
            var resultList = new List<Dictionary<string, object>>();
            foreach (DataRow row in resultTable.Rows)
            {
                var rowData = new Dictionary<string, object>();
                foreach (DataColumn col in resultTable.Columns)
                {

                    rowData[col.ColumnName] = row[col].ToString() == "" ? "" : row[col];
                }

                resultList.Add(rowData);
                var json = JsonConvert.SerializeObject(rowData);
                _redisHelper.SetHashToJson("全部数据", row["Id"].ToString(), json);
            }

            return new { data = resultList.Take(20), count = resultList.Count() };
            //return null;
        }


        //public static byte[] OutputCsv()
        //{
        //    try
        //    {
        //        // 创建 CSV 数据
        //        StringBuilder csvData = new StringBuilder();
        //        // 使用UTF-8编码
        //        Encoding utf8 = new UTF8Encoding(false);
        //        var jsonList = JsonConvert.SerializeObject(list);

        //        // 将 JSON 字符串反序列化为数组
        //        string[] arrayFromJson = JsonConvert.DeserializeObject<string[]>(jsonList);
        //        // 添加标题行
        //        foreach (var item in arrayFromJson)
        //        {
        //            Console.WriteLine(item);
        //        }

        //        //foreach (var item in TablCol)
        //        //{
        //        //    csvData.Append(item);
        //        //}
        //        //csvData.AppendLine(); // 换行


        //        //foreach (var col in list)
        //        //{
        //        //    csvData.Append(col);
        //        //}

        //        //csvData.AppendLine(); // 换行

        //        // TODO: 添加其他数据行


        //        // 将 CSV 数据转换为字节数组
        //        byte[] buffer = utf8.GetBytes(csvData.ToString());

        //        return buffer;
        //    }
        //    catch
        //    {
        //        // 处理异常逻辑
        //        return null;
        //    }
        //}

        string dirPath = @"\\192.168.0.10\\meiwa\\CSV";

        public void GetDirList()
        {

            var ipchack = IPInspect();
            if (ipchack != "链接成功")
                return;

            //一级文件
            List<string> csvDir = Directory.GetDirectories(dirPath).ToList();

            foreach (string csvFliesDir in csvDir)
            {
                //二级文件
                List<string> csvFiles = Directory.GetDirectories(csvFliesDir).ToList();
                foreach (string csvFile in csvFiles)
                {
                    GetAllCsvs(csvFile);
                }
                //Console.WriteLine("-----------------------");

            }
        }

        //获取该文件下的所有csv文件
        public void GetAllCsvs(string csvFile)
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
