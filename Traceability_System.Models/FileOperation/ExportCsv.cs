﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using System.Data;
using Traceability_System.Models.DictionaryMapper;
using Traceability_System.Utility;

namespace Traceability_System.Models.FileOperation
{

    public class ExportCsv
    {

        string Taday = DateTime.Now.ToString();

        public ExportCsv(RedisHelper redisHelper, ExportTableMapper exportTable)
        {
            _redisHelper = redisHelper;
            _exportTable = exportTable;
        }

        private readonly RedisHelper _redisHelper;
        private readonly ExportTableMapper _exportTable;

        public  byte[] newExportExcle(string tableName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            int underscoreIndex = tableName.IndexOf('_');

            string exportTableName = underscoreIndex != -1 ? tableName.Substring(0, underscoreIndex) : "";

            using (var package = new ExcelPackage())
            {

                int row = 0;
                var worksheet = package.Workbook.Worksheets.Add(tableName);
                if (exportTableName == "全部履历")
                {
                    row = 4;
                    ForAllTable(worksheet, exportTableName);

                }
                else if (exportTableName == "出荷履历")
                {
                    row = 2;
                    ForShip(worksheet, exportTableName);

                }
                else
                {
                    row = 3;
                    CreateExcelTitle(worksheet, exportTableName);
                }
                AddDataToAll(worksheet, exportTableName, row);

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
                    var twoLen = twoRow["val"].Count();
                    worksheet.Cells[2, twoCol, 2, twoCol + twoLen - 1].Merge = true;
                    worksheet.Cells[2, twoCol].Value = twoRow["title"].ToString();
                    worksheet.Cells[2, twoCol].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // 设置居中对齐
                    twoCol += twoLen;

                    foreach (var threeRow in twoRow["val"])
                    {

                        worksheet.Cells[3, threeCol].Value = threeRow["col"].ToString();
                        worksheet.Cells[3, threeCol].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // 设置居中对齐
                        threeCol += 1;
                        i++;
                    }
                }
                //Console.WriteLine();
                var firstRowName = item["title"].ToString();
                worksheet.Cells[1, firstCol, 1, firstCol + i - 1].Merge = true;
                worksheet.Cells[1, firstCol].Value = firstRowName;
                worksheet.Cells[1, firstCol].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // 设置居中对齐
                firstCol += i;
            }
        }

        //导出数据
        void AddDataToAll(ExcelWorksheet worksheet, string tableName, int row)
        {
            int rows = row;
            //根据表名获取数据
            var exportData = _redisHelper.GetAllHashValues(tableName);

            //跳过字段
            List<string> disItem = SkipField(tableName);

            foreach (var dataRow in exportData)
            {
                int col = 3;
                var rowdata = JsonConvert.DeserializeObject<Dictionary<string, string>>(dataRow);
                foreach (var key in rowdata.Keys)
                {
                    //如果disItem 中包含就跳过
                    if (disItem.Contains(key)) continue;


                    //根据表名选择第二列
                    string Itemvalue = _exportTable.keyValuePairs.TryGetValue(tableName, out string itemKey) ?
                        rowdata[itemKey].ToString() : "";

                    DateTime collectionDate = DateTime.Parse(rowdata["CollectionDate"].ToString());

                    worksheet.Cells[row, 1].Value = collectionDate;

                    worksheet.Cells[row, 1].Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";

                    worksheet.Cells[row, 2].Value = Itemvalue;

                    //避免重复导出

                    var writtenKeys = new List<string> { "CollectionDate", itemKey };
                    if (writtenKeys.Contains(key)) continue;

                    // 将值转换为适当的类型
                    object convertedValue = ConvertToAppropriateType(rowdata[key]);

                    // 写入 Excel 单元格
                    ExcelRange cell = worksheet.Cells[row, col];


                    // 如果值是 DateTime 类型，则设置单元格格式为日期时间格式
                    if (convertedValue is DateTime)
                    {
                        cell.Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";
                    }
                    else if (convertedValue is double)
                    {
                        cell.Style.Numberformat.Format = "0.00"; // 可以根据需要修改数字格式
                    }

                    cell.Value = convertedValue;
                    col++;
                }
                row++;
            }
        }

        //跳过字段
        List<string> SkipField(string tableName)
        {
            List<string> displayedColumns = new List<string>
            {
                "Id","Number"
            };

            if (tableName == "全部履历")
            {
                displayedColumns.AddRange(new string[] { "CollectionDate", "MoShipmentSerial", "GeDfringSerial", "Ro1MG1RSerial", "Ro2MG1RSerial", "RRRRCoverSerial" });
            }

            //string skipItem = _exportTable.keyValuePairs.TryGetValue(tableName, out string itemKey) ?itemKey : "";
            return displayedColumns;
        }

        // 将值转换为适当的类型
        object ConvertToAppropriateType(string value)
        {
            object keyValue;
            // 如果值包含 "Date"，则尝试将其转换为日期类型
            if (value.Contains("Date"))
            {

                keyValue = DateTime.TryParse(value, out DateTime dateValue) ? dateValue : value;
                return keyValue;
            }
            // 尝试将数字字符串转换为双精度浮点数
            else
            {
                keyValue = double.TryParse(value, out double numericValue) ? numericValue : value;
                return keyValue;
            }
        }
    }

}

