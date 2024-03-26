using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using System.Data;
using Traceability_System.Utility;

namespace Traceability_System.Models.FileOperation
{

    public class ExportCsv
    {

        string Taday = DateTime.Now.ToString();

        Dictionary<string, string> itemKeyMap = new Dictionary<string, string>(){
                          {"MotorTable", "ShipmentSerial"},
                          {"Tatable", "ShipmentSerial"},
                          {"RotorTable", "Mg1rserial"},
                          {"GearTable", "DfringSerial"},
                          {"Rrtable", "RrcoverSerial"}
                        };
        public byte[] newExportExcle(string tableName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                //var redisJson = await RedisHelper.ReStringAsync(tableName, 4);
                int row = 0;
                var worksheet = package.Workbook.Worksheets.Add(tableName);
                if (tableName == "全部数据")
                {
                    row = 4;
                    ForAllTable(worksheet, tableName);

                }
                else if (tableName == "出荷数据")
                {
                    row = 2;
                    ForShip(worksheet, tableName);

                }
                else
                {
                    row = 3;
                    CreateExcelTitle(worksheet, tableName);
                }
                AddDataToAll(worksheet, tableName, row);

                //添加数据
                //CreateDataList(worksheet, tableName, row);
                // 保存文件到内存流
                using (var memoryStream = new MemoryStream())
                {
                    package.SaveAs(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }

        //添加数据
        void CreateDataList(ExcelWorksheet worksheet, string tableName, int row)
        {
            RedisHelper redisHelper = new RedisHelper();
            var exportData = redisHelper.GetAllHashValues(tableName);

            foreach (var dataRow in exportData)
            {

                var rowdata = JsonConvert.DeserializeObject<Dictionary<string, string>>(dataRow);
                //删除不要的键
                if (rowdata.ContainsKey("Id"))
                {
                    rowdata.Remove("Id");
                }
                if (rowdata.ContainsKey("Number"))
                {
                    rowdata.Remove("Number");
                }
                else if (tableName == "出荷数据")
                {

                    int col = 1;
                    foreach (var key in rowdata.Keys)
                    {
                        //避免重复导出
                        //if (writtenKeys.Contains(key)) continue;

                        var value = rowdata[key];
                        worksheet.Cells[row, col].Value = value;
                        col++;
                    }
                    row++;
                }
                else
                {

                    var Itemvalue = "";
                    worksheet.Cells[row, 1].Value = rowdata["CollectionDate"];

                    //根据不同表固定不同列
                    string itemKey;
                    if (itemKeyMap.TryGetValue(tableName, out itemKey))
                    {
                        Itemvalue = rowdata[itemKey].ToString();
                    }
                    var writtenKeys = new List<string> { "CollectionDate", itemKey };

                    worksheet.Cells[row, 2].Value = Itemvalue;

                    int col = 3;
                    foreach (var key in rowdata.Keys)
                    {
                        //避免重复导出
                        if (writtenKeys.Contains(key)) continue;

                        var value = rowdata[key];
                        worksheet.Cells[row, col].Value = value;
                        col++;
                    }
                    row++;
                }
            }
        }

        //普通表头
        void CreateExcelTitle(ExcelWorksheet worksheet, string tableName)
        {
            RedisHelper redisHelper = new RedisHelper();

            //var newColName = RedisHelper.ReStringAsync(tableName,4);
            var colName = redisHelper.RedisGetAsync(tableName, 4);
            List<Dictionary<string, object>> TableDataList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(colName);

            int twoCol = 1, firstCol = 1;
            foreach (var item in TableDataList)
            {
                int i = 0;
                var firstRowName = item["title"].ToString();
                var twoRowList = JArray.Parse(item["val"].ToString());
                foreach (var twoName in twoRowList)
                {
                    //worksheet.Cells[2, twoCol, 2, twoCol + twoLen - 1].Merge = true;
                    worksheet.Cells[2, twoCol].Value = twoName["col"].ToString();
                    worksheet.Cells[2, twoCol].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // 设置居中对齐
                    twoCol++;
                    i++;
                }
                worksheet.Cells[1, firstCol, 1, firstCol + i - 1].Merge = true;
                worksheet.Cells[1, firstCol].Value = firstRowName;
                worksheet.Cells[1, firstCol].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // 设置居中对齐
                firstCol += i;

            }
        }

        //出荷数据表头
        void ForShip(ExcelWorksheet worksheet, string tableName)
        {
            RedisHelper redisHelper = new RedisHelper();

            var josn = redisHelper.ReStringAsync(tableName, 4);
            int i = 1;
            foreach (var item in josn)
            {
                var a = item["tableName"].ToString();
                worksheet.Cells[1, i].Value = a;
                i++;
            }
        }
        //ExcelWorksheet worksheet, string tableName
        void AddDataToAll(ExcelWorksheet worksheet, string tableName, int row)
        {
            int rows = row;
            RedisHelper redisHelper = new RedisHelper();
            var exportData = redisHelper.GetAllHashValues(tableName);
            List<string> disItem = new List<string> {
                "Id", "Number",
            };

            
            if (tableName =="全部数据")
            {
                disItem.AddRange(new string[] { "CollectionDate", "MoShipmentSerial", "GeDfringSerial", "Ro1MG1RSerial", "Ro2MG1RSerial", "RRRRCoverSerial" });
            }

            foreach (var dataRow in exportData)
            {
                int col = 1;
                var rowdata = JsonConvert.DeserializeObject<Dictionary<string, string>>(dataRow);
                foreach (var key in rowdata.Keys)
                {
                   
                    bool exists = disItem.Any(item => item == key);
                    if (exists)
                    {
                        continue;
                    }
                   
                    string Itemvalue = itemKeyMap.TryGetValue(tableName, out string itemKey) ?
                        rowdata[itemKey].ToString() : "";

                    if (tableName != "全部数据" && tableName != "出荷数据" && col == 1)
                    {
                       
                        worksheet.Cells[row, 1].Value = rowdata["CollectionDate"].ToString();
                       
                        worksheet.Cells[row, 2].Value = Itemvalue;

                        col = 3;
                        //避免重复导出
                    }

                    var writtenKeys = new List<string> { "CollectionDate", itemKey };
                    if (writtenKeys.Contains(key)) continue;

                    string value = !string.IsNullOrEmpty(rowdata[key]) ? rowdata[key].ToString() : "";
                    worksheet.Cells[row, col].Value = value;
                    col++;
                }
                row++;

            }
        }
        //全部数据表头
        void ForAllTable(ExcelWorksheet worksheet, string tablName)
        {
            RedisHelper redisHelper = new RedisHelper();

            //var josn = await RedisHelper.ReStringAsync(tableName, 4);
            var colName = redisHelper.RedisGetAsync(tablName, 4);
            List<Dictionary<string, object>> tableDataList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(colName);

            int firstCol = 1, twoCol = 1, threeCol = 1;
            foreach (var item in tableDataList)
            {
                var twoRowList = JArray.Parse(item["data"].ToString());
                int i = 0;
                foreach (var twoRow in twoRowList)
                {
                    //Console.WriteLine(twoRow["title"].ToString());
                    var twoLen = twoRow["colName"].Count();
                    worksheet.Cells[2, twoCol, 2, twoCol + twoLen - 1].Merge = true;
                    worksheet.Cells[2, twoCol].Value = twoRow["tableName"].ToString();
                    worksheet.Cells[2, twoCol].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // 设置居中对齐
                    twoCol += twoLen;

                    foreach (var threeRow in twoRow["colName"])
                    {

                        worksheet.Cells[3, threeCol].Value = threeRow.ToString();
                        worksheet.Cells[3, threeCol].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // 设置居中对齐
                        threeCol += 1;
                        i++;
                    }
                }

                var firstRowName = item["title"].ToString();
                worksheet.Cells[1, firstCol, 1, firstCol + i - 1].Merge = true;
                worksheet.Cells[1, firstCol].Value = firstRowName;
                worksheet.Cells[1, firstCol].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // 设置居中对齐
                firstCol += i;
            }
        }
    }

}

