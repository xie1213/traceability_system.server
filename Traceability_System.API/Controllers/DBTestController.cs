
using Microsoft.AspNetCore.Mvc;
using Traceability_System.DTO;
using Traceability_System.Models.SelectDB;
using Newtonsoft.Json;
using Appraisal_System.Utility;
using System.Diagnostics;
using Traceability_System.Utility;
using System.Data;
using Traceability_System.Models.FileOperation;
using System.Collections.Generic;

namespace Traceability_System.Api.Controllers
{
    [Route("api/[controller]")]
    public class DBTestController : Controller
    {

        //private readonly _966KDataBaseContext _dbContext;
        private readonly SelectAllData _selectAllData;

        public DBTestController( SelectAllData selectAllData)
        {
            _selectAllData = selectAllData;
        }

        //#region 禁止
        //[HttpPost("SelTablePost")]
        //public IActionResult SelTablePost([FromBody] SelTableRequest Request)
        // {

        //    if (Request == null)
        //    {
        //        return BadRequest("请求参数为空");
        //    }
        //    //Stopwatch stopwatch = new Stopwatch();
        //    // 启动计时器
        //    //stopwatch.Start();
        //    object list;


        //    if (Request.TableName == "出荷履历")
        //    {
        //        //list = _selectAllData.GetOutTable(Request);
        //    }
        //    else if(Request.TableName == "全部履历")
        //    {

        //         list = _selectAllData.GetTableByName(Request);
        //       // SelectAllData.GetTableByName(Request);
        //    }
        //    else
        //    {
        //        list = _selectAllData.GetTableByName(Request);
        //    }

        //    //stopwatch.Stop();

        //    //Console.WriteLine("查询数据的时间" + stopwatch.ElapsedMilliseconds);
        //    return Ok(list);
        //    // 停止计时器
            
        //    //

        //    //try
        //    //{
        //    //    if (Request.TableName == "全部数据")
        //    //    {
        //    //        Request.limit = 10;
        //    //    }
        //    //    //var first50Items = Test.Take(Request.limit);
        //    //    stopwatch = new Stopwatch();
        //    //    stopwatch.Start();

        //    //    //var first50Items = RedisHelper.GetHashToPage<MotorTable>(1);
        //    //    var first50Items = RedisHelper.GetHashToPage(1,50);

        //    //    stopwatch.Stop();
        //    //    Console.WriteLine("获取数据的时间" + stopwatch.ElapsedMilliseconds);

        //    //    return Ok(new { data = first50Items, code = 200 });
        //    //}
        //    //catch (Exception)
        //    //{

        //    //    throw;
        //    //}


        //}
        //#endregion
     
        [HttpPost("getTableData")]
        public IActionResult getTableData([FromBody] ParameterData parameter)
        {
            object list;
            if (parameter.tableName == "全部履历")
            {
                list = _selectAllData.GetAllTableData(parameter);
            }
            else if (parameter.tableName == "出荷履历")
            {
                list = _selectAllData.GetOutTable(parameter);
            }
            else
            {
                list = _selectAllData.GetRestTableData(parameter);
            }
            return Ok(list);
            //return Ok(parameter);
        }


        [HttpGet("GetRedis")]
        public  IActionResult GetRedis(int page,int limit, string tableName)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                // 启动计时器
                //var json = await RedisHelper.ReStringAs
                stopwatch.Start();
                RedisHelper redisHelper = new RedisHelper();
                var first50Items = redisHelper.GetHashToPage(tableName,page, limit);
                //await Console.Out.WriteLineAsync();
                stopwatch.Stop();

                //Console.WriteLine("分页查询时间"+stopwatch.ElapsedMilliseconds);
                return Ok(new { data = first50Items });
            }
            catch (Exception e)
            {
                Logger.WriteLogAsync("redis 读取 错误"+e.Message);
                throw;
            }
            
        }

        [HttpGet("SelTableGet")]
        public IActionResult SelTableGet(string TableName)
        {
            string sql = $"select top(50)* from  {TableName}";
            DataTable list = SqlHelper.ExecuteTable(sql);

            string json = JsonConvert.SerializeObject(list);
            //try
            //{
            //    byte[] jsonData = Encoding.UTF8.GetBytes(json);

            //    // 使用 GZip 压缩 JSON 数据
            //    byte[] compressedData;
            //    using (MemoryStream outputStream = new MemoryStream())
            //    {
            //        using (GZipStream gzipStream = new GZipStream(outputStream, CompressionMode.Compress))
            //        {
            //            gzipStream.Write(jsonData, 0, jsonData.Length);
            //        }
            //        compressedData = outputStream.ToArray();
            //    }

            //    // 设置响应头，指定 Content-Encoding 为 gzip
            //    Response.Headers.Add("Content-Encoding", "gzip");

            //    // 返回压缩后的 JSON 数据
            //    return Ok(compressedData);
            //}
            //catch (Exception e)
            //{

            //    throw;
            //}
            //// 创建一个内存流来存储 JSON 数据
                   
            var dataList = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
            return Ok(new {data= dataList });
        }

       

        //[HttpGet("GetExport")]
        //public IActionResult Export(string tableName)
        //{
        //    //ExportCsv exportCsv = new ExportCsv();
        //    byte[] excelBytes = exportCsv.newExportExcle(tableName);

        //    MemoryStream stream = new MemoryStream(excelBytes);
        //    return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{tableName}.xlsx");
        //}

        //获取表的列名
        [HttpGet("DBGetTable")]
        //public List<string> DBGetTable(string tableName)
        //{
        //    //SqlHelper.ConStr = "Data Source=.;uid=sa;pwd=123456;Datebase:966KData;";
        //    //var a = SqlHelper.GetSqlColumnName(tableName);
        //    List<string> list = new List<string>();
        //    ////return null;
        //    ////输出属性名
        //    //return a;
        //    //foreach (string property in a)
        //    //{
        //    //    string propertyName = property;

        //    //    string lowerCaseName = char.ToLower(propertyName[0]) + propertyName.Substring(1);
        //    //    list.Add(lowerCaseName);

        //    //}

        //    //return a;
        //    //MotorTable motorTable = new MotorTable();
        //    //RotorTable motorTable = new RotorTable();
        //    //GearTable motorTable = new GearTable();
        //    //Rrtable motorTable = new Rrtable();
        //    //Tatable motorTable = new Tatable();
        //    //List<string> list = new List<string>();

        //    //获取MotorTable实例的所有属性名称
        //   // var properties = motorTable.GetType().GetProperties();

        //    //foreach (var property in properties)
        //    //{
        //    //    // 获取属性名称
        //    //    string propertyName = property.Name;

        //    //    // 将属性名称转换为小写
        //    //    //string lowerCaseName = char.ToLower(propertyName[0]) + propertyName.Substring(1);

        //    //    // 将小写属性名称添加到列表
        //    //    list.Add(propertyName);
        //    //}
        //    //return list;
        //}

        [HttpGet("GetAllTable")]
        public IActionResult GetAllData()
        {
            try
            {
                string sqlQuery = "select * from TATable as ta" +
                $"\rleft join vw_MotorTable mo on RIGHT(ta.ShipmentSerial,8) = RIGHT(mo.MoShipmentSerial, 8)" +
                $"\rleft join vw_GearTable as df on ta.DFCaseSerial = df.GeDFCaseSerial" +
                $"\rleft join vw1_RotorTable as ro1 on ta.MG1RSerial = ro1.Ro1MG1RSerial and LEFT(ta.MG1RSerial,2) = '11'" +
                $"\rleft join vw2_RotorTable as ro2 on ta.MG1RSerial = ro2.Ro2MG1RSerial and LEFT(ta.MG1RSerial,2) = '12'" +
                $"\rleft join vw_RRTable as rr on ta.RRCoverSerial = rr.RRRRCoverSerial" +
                $"\rwhere ta.Id = 1";

                DataTable resultTable = SqlHelper.ExecuteTable(sqlQuery);
                List<Dictionary<string, object>> resultList = new List<Dictionary<string, object>>();
                foreach (DataRow row in resultTable.Rows)
                {
                    var rowData = new Dictionary<string, object>();
                    foreach (DataColumn col in resultTable.Columns)
                    {
                        rowData[col.ColumnName] = row[col].ToString() == "" ? "" : row[col];
                    } 
                    resultList.Add(rowData);
                }
                //RedisHelper.SetJsonHash("test", resultList, 3);
                //var list = query.ToList();
                return new JsonResult(new { data = resultList, code = 200 });
            }
            catch (Exception)
            {

                throw;
            }
            
        }

    }
}
