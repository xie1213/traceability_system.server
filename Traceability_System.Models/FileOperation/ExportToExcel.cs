﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traceability_System.Models.DictionaryMapper;
using Traceability_System.Utility;

namespace Traceability_System.Models.FileOperation
{
    public class ExportToExcel
    {
        private readonly RedisHelper _redisHelper;
        private readonly ExportTableMapper _exportTable;

        public ExportToExcel(RedisHelper redisHelper, ExportTableMapper exportTable)
        {
            _redisHelper = redisHelper;
            _exportTable = exportTable;
        }





        //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        public byte[] ExportTable(string tableName)
        {
            //许可证
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;


            int underscoreIndex = tableName.IndexOf('_');

            string exportTableName = underscoreIndex != -1 ? tableName.Substring(0, underscoreIndex) : "";

            string colName = _redisHelper.RedisGetAsync(exportTableName, 4);

            using (var package = new ExcelPackage())
            {
                // 添加一个工作表
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(tableName);

                int row = 0;
                if (exportTableName == "全部履历")
                {
                    //导出全部数据时表头
                    worksheet.Cells[2, 1, 2, 2].Merge = true;
                    worksheet.Cells[2, 1].Value = "固定列";
                    worksheet.Cells[2, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // 设置居中对齐

                    //worksheet.Cells[3, 1, 2, twoCol + twoLen - 1].Merge = true;
                    worksheet.Cells[3, 1].Value = "采集时间";
                    worksheet.Cells[3, 2].Value = "出荷序列";

                    ForAllTable(worksheet, colName);
                    row = 4;
                }
                else if (exportTableName == "出荷履历")
                {

                    //导出出荷数据时表头
                    ForShip(worksheet, colName);
                    row = 2;
                }
                else
                {
                    CreateExcelTitle(worksheet, colName);
                    row = 3;
                }
                AddDataToAll(worksheet, exportTableName, row);

                //自动调整列宽
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                using (var memoryStream = new MemoryStream())
                {
                    package.SaveAs(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }

        //导出表的表头
        private void CreateExcelTitle(ExcelWorksheet worksheet, string colName)
        {
            int twoCol = 1, firstCol = 1;
            List<Dictionary<string, object>> TableDataList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(colName);
            foreach (var item in TableDataList)
            {
                int i = 0;
                var firstRowName = item["title"].ToString();
                var twoRowList = JArray.Parse(item["val"].ToString());

                //导出第二行
                foreach (var twoName in twoRowList)
                {
                    worksheet.Cells[2, twoCol].Value = twoName["col"].ToString();
                    worksheet.Cells[2, twoCol].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // 设置居中对齐
                    twoCol++;
                    i++;
                }

                //导出第一行
                worksheet.Cells[1, firstCol, 1, firstCol + i - 1].Merge = true;
                worksheet.Cells[1, firstCol].Value = firstRowName;
                worksheet.Cells[1, firstCol].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // 设置居中对齐
                firstCol += i;
            }
        }


        //出荷表表头
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

        //全部表数据表头
        void ForAllTable(ExcelWorksheet worksheet, string colName)
        {
            //RedisHelper redisHelper = new RedisHelper();

            List<Dictionary<string, object>> tableDataList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(colName);

            int firstCol = 1, twoCol = 3, threeCol = 3;
            foreach (var item in tableDataList)
            {
                var twoRowList = JArray.Parse(item["data"].ToString());
                int i = 0;
                foreach (var twoRow in twoRowList)
                {
                    //Console.WriteLine(twoRow["val"]);
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

            //// 设置整列的样式
            //ExcelRange columnRange = worksheet.Cells[row, 3, row + exportData.Count(), worksheet.Dimension.Columns];
            //columnRange.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
            worksheet.Cells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;


            foreach (var dataRow in exportData)
            {
                int col = 3;

                var rowdata = JsonConvert.DeserializeObject<Dictionary<string, string>>(dataRow);

                //根据表名选择第二列
                string Itemvalue = _exportTable.keyValuePairs.TryGetValue(tableName, out string itemKey) ?
                    rowdata[itemKey].ToString() : "";

                DateTime collectionDate = DateTime.Parse(rowdata["CollectionDate"].ToString());

                worksheet.Cells[row, 1].Value = collectionDate;

                worksheet.Cells[row, 1].Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";

                worksheet.Cells[row, 2].Value = Itemvalue;

                var writtenKeys = new List<string> { "CollectionDate", itemKey };

                foreach (var key in rowdata.Keys)
                {
                    // 写入 Excel 单元格
                    ExcelRange cell = worksheet.Cells[row, col];



                    //如果disItem 中包含就跳过
                    if (disItem.Contains(key) || writtenKeys.Contains(key))
                    {
                        continue;
                    }

                    //bool containsKey = _exportTable.columns.TryGetValue(key, out var column);
                    var comparer = StringComparer.OrdinalIgnoreCase; 

                    object convertedValue ="";
                    
                    if (_exportTable.columns.Contains(key, comparer))
                    {
                        convertedValue = rowdata[key];
                    }
                    else if (!string.IsNullOrEmpty(rowdata[key]))
                    {
                        if (key.Contains("Date") && DateTime.TryParse(rowdata[key].ToString(), out DateTime dateValue))
                        {
                            convertedValue = dateValue;
                            cell.Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";
                        }
                        else
                        {
                            convertedValue = double.TryParse(rowdata[key], out double numericValue) ? numericValue : rowdata[key];
                        }
                    }
                    cell.Value = convertedValue;
                    //cell.Value = rowdata[key];

                    //cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left; // 设置居中对齐

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
                displayedColumns.AddRange(new string[] { "CollectionDate", "MoShipmentSerial", "GeDFRingSerial", "Ro1MG1RSerial", "Ro2MG1RSerial", "RRRRCoverSerial" });
            }

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