using Appraisal_System.Utility;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using Traceability_System.DTO;
using Traceability_System.Entity.Models;
using Traceability_System.Models.ExportedMethod;
using Traceability_System.Models.FileOperation;
using Traceability_System.Utility;

namespace Traceability_System.Models.SelectDB
{
    public class SelectAllData
    {

        private readonly RedisHelper _redisHelper;
        private readonly LogHelper _logHelper;
        public SelectAllData(RedisHelper redisHelper, LogHelper logHelper)
        {
            _redisHelper = redisHelper;
            _logHelper = logHelper;
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
                        { "Motor履历_OrderBy", "ShipmentSerial" },
                        { "Gear履历_OrderBy", "DorpinSerial" },
                        { "Rotor履历_OrderBy", "MG1RSerial" },
                        { "Rr履历_OrderBy", "RRCoverSerial" },
                        { "Ta履历_OrderBy", "ShipmentSerial" },
                        { "NewMotorTable_OrderBy", "ShipmentSerial" },
                    };

        // 创建一个字典，存储表名和对应的 orderby 字段
        Dictionary<string, (string tableName, string orderby)> tableMappings = new Dictionary<string, (string, string)>
        {
            ["Motor履历"] = ("MotorTable", "ShipmentSerial"),
            ["Gear履历"] = ("GearTable", "DorpinSerial"),
            ["Rotor履历"] = ("RotorTable", "MG1RSerial"),
            ["Rr履历"] = ("Rrtable", "RRCoverSerial"),
            ["Ta履历"] = ("Tatable", "ShipmentSerial"),
            ["出荷履历"] = ("Shipping", "SerialNo")
        };

        //导出表名
        public string exportedName = "";


        //获取表格信息
        public async Task<object> GetRestTableData(ParameterData parameter)
        {
            try
            {
                //RedisHelper redisHelper = new RedisHelper();
                //redisHelper.DeleteHash(parameter.TableName);
                string tableName = string.Empty;
                string orderby = string.Empty;

                // 根据 parameter.tableName 直接从字典中获取对应的值，并进行赋值
                (tableName, orderby) = tableMappings.GetValueOrDefault(parameter.tableName, (string.Empty, string.Empty));

                string baseSql = $"select * from {tableName} where ";

                exportedName = parameter.tableName;

                //条件sql
                List<string> sqlList = CreateFactorSql(parameter, orderby);

                string itemSql = string.Join(" and ", sqlList);

                baseSql += $"{itemSql} ORDER BY RIGHT({orderby},8) DESC ";


                DataTable dt = await SqlHelper.ExecuteTableAsync(baseSql);
                if (dt.Rows.Count == 0)
                {
                    return "空值";
                }
                _redisHelper.DeleteHash(parameter.tableName);
                var list = new List<object>();
                Assembly asm = Assembly.Load("Traceability_System.Entity");
                Type modelType = asm.GetType("Traceability_System.Entity.Models." + tableName);


                await Task.Run(() => ExportDataAsync(exportedName, dt));


                Console.WriteLine("数据转化");
                foreach (DataRow dr in dt.Rows)
                {
                    var model = dr.DataRowToType(modelType);
                    var jsonData = JsonConvert.SerializeObject(model);


                    var filed = dr["Id"].ToString();

                    await  _redisHelper.SetHashToJsonAsync(parameter.tableName, filed, jsonData,7);

                    list.Add(model);
                    // RedisHelper.SetHash()
                }
                var listData = list.Take(30);
                return new { data = listData, count = list.Count() };
            }
            catch (Exception ex)
            {
                _logHelper.Error("获取表格信息时出错" + ex.Message);
                throw;
            }
            
        }


        // 生成 SQL 语句的方法
        private List<string> CreateFactorSql(ParameterData parameter, string orderby)
        {
            List<string> sqlList = new List<string>();

            //条件查询
            var selectFactor = parameter.selectFactor;

            //表名
            var tableName = parameter.tableName;

            //开始时间
            var startDateTime = parameter.startDateTime;

            //结束时间
            var endDateTime = parameter.endDateTime;

            //序列号
            var serialDateNumber = parameter.serialDateNumber;

            var selName = parameter.tableName;

            // 时间字段
            if (startDateTime != null && endDateTime != null)
            {

                string timeStr = tableName == "出荷履历" ? "ShippingTimeDate" : "CollectionDate";


                string timeSql = $" {timeStr} BETWEEN '{startDateTime}' AND '{endDateTime}' ";

                string a = CoverToTime.TimeToInt(startDateTime);

                string b = CoverToTime.TimeToInt(endDateTime);
                exportedName += $"_{a}-{b}";
                sqlList.Add(timeSql);
            }

            // 序列号不为空
            if (serialDateNumber != null)
            {
                int numLen = serialDateNumber.Length;
                serialDateNumber = serialDateNumber.Replace(" ", "%");
                string serialSql = $" {orderby} like '%{serialDateNumber}%' ";

                exportedName += $"_{serialDateNumber}";
                sqlList.Add(serialSql);
            }

            if (selectFactor != null)
            {

                sqlList.Add(CheckedToString(selectFactor));
                // 拼接 SQL 条件
            }
            return sqlList;
        }

        //验证字符串
        public string CheckedToString(selectFactor selectFactor)
        {
            string selSql = $"{selectFactor.selectName} ";

            //判断是否等于空
            bool isTopLimit = selectFactor.topLimit == null;
            bool isLowerLimit = selectFactor.lowerLimit == null;

            bool equalStr = selectFactor.topLimit == selectFactor.lowerLimit;


            exportedName += $"_{selectFactor.selectNameZh}";
            //是否是时间
            if (selectFactor.selectName.Contains("Date"))
            {
                selSql += $" between '{selectFactor.startDateTime}' and '{selectFactor.endDateTime}' ";
                string a = CoverToTime.TimeToInt(selectFactor.startDateTime);

                string b = CoverToTime.TimeToInt(selectFactor.endDateTime);
                exportedName += $"-{a}-{b}";
                return selSql;
            }

            //上下限都不等于空
            if (!isTopLimit && !isLowerLimit)
            {
                if (equalStr)
                {
                    selSql += $" like '%{selectFactor.topLimit}%' ";
                    exportedName += $"-{selectFactor.topLimit}";
                }
                else
                {
                    exportedName += $"-{selectFactor.topLimit}-{selectFactor.lowerLimit}";
                    selSql = CreateFactorSql(selectFactor.selectName, selectFactor.topLimit, selectFactor.lowerLimit);
                }
            }
            else if (isTopLimit)
            {
                //上限为空,下限不为空
                selSql = $"CAST({selSql} AS FLOAT)>={selectFactor.lowerLimit}";
                exportedName += $"-{selectFactor.lowerLimit}";
            }
            else
            {
                //下限为空,上限不为空
                selSql = $"CAST({selSql} AS FLOAT)<={selectFactor.topLimit}";
                exportedName += $"-{selectFactor.topLimit}";
            }

            return selSql;
        }

        string CreateFactorSql(string selName, string topLimit, string lowerLimit)
        {
            int topLen = topLimit.Length;
            int lowerLen = lowerLimit.Length;

            return $" RIGHT({selName},{topLen}) between '{lowerLimit}' and '{topLimit}'";
        }


        string CheckedToCase(string topLimit, string lowerLimit)
        {
            int topIndex = topLimit.IndexOf("#");
            int lowerindex = lowerLimit.IndexOf("#");
            string selSql;
            if (topIndex != 1 && lowerindex != 1)
            {
                selSql = $"CONVERT(BIGINT, SUBSTRING(CaseSerial, 6, LEN(CaseSerial) - 5)) BETWEEN '{lowerLimit}' AND '{topLimit}'";
            }
            else
            {
                selSql = $" between '{lowerLimit}' and '{topLimit}' ";
            }
            return selSql;


        }

        public async Task<object> GetTableByName(SelTableRequest requestData)
        {
            try
            {
                //RedisHelper redisHelper = new RedisHelper();
                _redisHelper.DeleteHash(requestData.TableName);

                string timeItem = "", selItem = "", serialNo = "";
                string orderByColumn = tablePatterns.TryGetValue($"{requestData.TableName}_OrderBy", out var col) ? col : "";

                if (!requestData.selColName.IsNullOrEmpty())
                {

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
                if (requestData.TableName == "全部数据")
                {
                    //return GetAllTable(timeItem, selItem, selLike);
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


                sqlQuery += $"ORDER BY RIGHT({orderByColumn},8) DESC ";


                DataTable dt = await SqlHelper.ExecuteTableAsync(sqlQuery);

                var list = new List<object>();
                Assembly asm = Assembly.Load("Traceability_System.Entity");
                Type modelType = asm.GetType("Traceability_System.Entity.Models." + requestData.TableName);

                foreach (DataRow dr in dt.Rows)
                {
                    var model = dr.DataRowToType(modelType);
                    var jsonData = JsonConvert.SerializeObject(model);
                    var filed = dr["Id"].ToString();

                  await  _redisHelper.SetHashToJsonAsync(requestData.TableName, filed, jsonData);

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


        ////获取出荷数据
        public async Task <object> GetOutTable(ParameterData parameter)
        {
            string baseSql = "select * from Shipping where";
            Console.WriteLine("查找出荷数据");
            try
            {
                exportedName = parameter.tableName;
                //条件sql
                List<string> sqlList = CreateFactorSql(parameter, "SerialNo");

                string itemSql = string.Join(" and ", sqlList);

                baseSql += $"\n{itemSql} ORDER BY SerialNo DESC ";

                var shipList = new List<object>();

                DataTable dt = await SqlHelper.ExecuteTableAsync(baseSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                   await Task.Run(() => ExportDataAsync(exportedName, dt));
                    
                    _redisHelper.DeleteHash(parameter.tableName);
                    foreach (DataRow dr in dt.Rows)
                    {
                        var model = dr.DataRowToModel<Shipping>();
                        var jsonData = JsonConvert.SerializeObject(model);

                        var filed = model.Id.ToString();
                        await _redisHelper.SetHashToJsonAsync(parameter.tableName, filed, jsonData);

                        shipList.Add(model);
                    }
                    return new { data = shipList.Take(30), count = shipList.Count() };
                }
                else
                {
                    return new { count = 0 };
                }
            }
            catch (Exception e)
            {
                _logHelper.Error("获取出荷表数据时出现错误" + e.Message);
                throw;
                //return e.Message;
            }
        }


        //获取全部数据
        public async Task<object> GetAllTableData(ParameterData parameter)
        {
            try
            {
                exportedName = parameter.tableName;

                var sqlList = CreateFactorSql(parameter, "ShipmentSerial");

                string itemSql = string.Join(" and ", sqlList);


                string sqlQuery = "select * from TATable as ta" +
                           $" left join vw_MotorTable mo on RIGHT(ta.ShipmentSerial,8) = RIGHT(mo.MoShipmentSerial, 8)" +
                           $" left join vw_GearTable as df on ta.DfringSerial = df.GeDfringSerial" +
                           $" left join vw1_RotorTable as ro1 on ta.MG1RSerial = ro1.Ro1MG1RSerial and LEFT(ta.MG1RSerial,2) = '11'" +
                           $" left join vw2_RotorTable as ro2 on ta.MG1RSerial = ro2.Ro2MG1RSerial and LEFT(ta.MG1RSerial,2) = '12'" +
                           $" left join vw_RRTable as rr on ta.RRCoverSerial = rr.RRRRCoverSerial" +
                           $" where {itemSql} order by RIGHT(ShipmentSerial,8) desc ";


                DataTable resultTable =await SqlHelper.ExecuteTableAsync(sqlQuery);
                if (resultTable.Rows.Count == 0)
                {
                    return "空值";
                }
                await Task.Run(() => ExportDataAsync(exportedName, resultTable));

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
                   await _redisHelper.SetHashToJsonAsync("全部履历", row["Id"].ToString(), json);
                }

                return new { data = resultList.Take(30), count = resultList.Count() };
                //return null;
            }
            catch (Exception ex)
            {
                _logHelper.Error("全部表读取错误" + ex.Message);
                throw;
            }
          
        }


        //检查ip通不通
        public string IPInspect()
        {
            string ipAddress = "192.168.0.10";
            IPInspect iPInspect = new IPInspect(ipAddress);
            var lastPingStatus = iPInspect.IPInspectMethod();

            return lastPingStatus.ToString();
        }


        private async Task ExportDataAsync(string exportedName, DataTable dt)
        {
            ExportedManager exported = new ExportedManager();
            exported._tableName = exportedName;
            exported.data = dt;

            Console.WriteLine("开始导出");
            await exported.ExportedTable();
        }

    }
}
