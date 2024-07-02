using Newtonsoft.Json;
using OfficeOpenXml;
using System.Data;
using Traceability_System.Models.DictionaryMapper;
using Traceability_System.Utility;


namespace Traceability_System.Models.FileOperation
{
    public class newExportToExcel
    {
        private readonly RedisHelper _redisHelper;
        private readonly ExportTableMapper _exportTable;
        public string filePath = "";

        string baseDirectory = @"D:\work\Traceability_System\assets";
        public string tableName = "";
        int count = 0;


        public newExportToExcel(RedisHelper redisHelper, ExportTableMapper exportTable)
        {
            _redisHelper = redisHelper;
            _exportTable = exportTable;

        }


        public async Task<byte[]> ExportTable(string tableName)
        {
            //文件保存路径
            filePath = CopyFile(tableName);

            tableName = subStr(tableName);
            //许可证
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //List<string> allList = new List<string>();

            var exportData = _redisHelper.GetAllHashValues(tableName);
            // 将当前页数据添加到总数据集合中

            count = exportData.Count;


            // 调用方法将数据导出为 Excel 文件
            byte[] excelBytes = await ExportToExcel(exportData);


            //await ExportToExcel(exportData, tableName);

            return excelBytes;

        }

        //导出数据发送流给前端
        public async Task<byte[]> ExportToExcel<T>(List<T> list)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {

                await CreateExcel(package, list);
                //worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns(); // 最后一次调整列宽

                using (var memoryStream = new MemoryStream())
                {
                    await package.SaveAsAsync(memoryStream);

                    return memoryStream.ToArray();
                    //package.Save();
                }
            }
        }

        //直接保存到后端
        public async Task SevaToExcel<T>(List<T> list)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {

                await CreateExcel(package, list);
                //worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns(); // 最后一次调整列宽

                using (var memoryStream = new MemoryStream())
                {
                    await package.SaveAsAsync(memoryStream);

                    package.Save();
                }
            }
        }

        //创建表格
        public async Task<ExcelPackage> CreateExcel<T>(ExcelPackage package,List<T> list)
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // 第一个工作表
            int processedRows = 0;
            //int batchSize = count;
            int batchSize = 500;


            var skipKeys = SkipField(tableName); // 跳过字段
            while (processedRows < batchSize)
            {
                var batchList = list.Skip(processedRows).Take(batchSize).ToList();
                processedRows += batchList.Count;


                var tasks = batchList.Select(async (item, index) =>
                {
                    var rowData = JsonConvert.DeserializeObject<Dictionary<string, string>>(item.ToString());

                    //根据表格名字选择第二列
                    string itemKey = _exportTable.keyValuePairs.TryGetValue(tableName, out string key) ? rowData[key].ToString() : string.Empty;

                    int row = processedRows - batchList.Count + index + 3; // 起始行
                    DateTime collectionDate = DateTime.Parse(rowData["CollectionDate"]);

                    worksheet.Cells[row, 1].Value = collectionDate; //固定字段
                    worksheet.Cells[row, 2].Value = itemKey;
                    //skipKeys.Add("");
                    skipKeys.Add(key);
                    int col = 3;
                    foreach (var pair in rowData)
                    {

                        var cells = worksheet.Cells[row, col];

                        if (skipKeys.Contains(pair.Key))
                            continue;

                        cells.Value = pair.Value;
                        col++;
                    }
                });

                await Task.WhenAll(tasks);
            }

            return package;
        }

        //获取单元格格式
        void GetKeyType(string key, string value, ExcelRange cells)
        {
            //比较字符串
            var comparer = StringComparer.OrdinalIgnoreCase;

            if (_exportTable.columns.Contains(key, comparer) || value == "")
            {
                cells.Value = value;

            }
            else
            {
                if (key.Contains("Date") && DateTime.TryParse(value, out DateTime dateValue))
                {
                    cells.Value = dateValue;
                    cells.Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";
                }
                else if (double.TryParse(value.TrimEnd(), out double numericValue))
                {
                    cells.Value = numericValue;

                    if (key == "" || key == "Operator")
                    {
                        cells.Style.Numberformat.Format = "000000000"; // 邮政编码格式
                    }
                    //cell.Style.Numberformat.Format = "@"; // 文本格式
                }

            }
        }


        //复制文件路径
        public string CopyFile(string tableName)
        {
            string filePath = Path.Combine(baseDirectory, $"{tableName}.xlsx");
            string copyName = $"{tableName}_.xlsx";
            string copyPath = Path.Combine(baseDirectory, copyName);

            if (!Directory.Exists(baseDirectory))
            {
                Directory.CreateDirectory(baseDirectory);
            }

            if (File.Exists(copyPath))
            {
                File.Delete(copyPath);
            }

            File.Copy(filePath, copyPath);
            return copyPath;
        }

        //截取字符
        public string subStr(string tableName)
        {
            int underscoreIndex = tableName.IndexOf('_');

            string exportTableName = underscoreIndex != -1 ? tableName.Substring(0, underscoreIndex) : "";

            return exportTableName;
        }

        //跳过字段
        List<string> SkipField(string tableName)
        {
            List<string> displayedColumns = new List<string>
            {
                "Id","Number","CollectionDate"
            };

            if (tableName == "全部履历")
            {
                displayedColumns.AddRange(new string[] { "CollectionDate", "MoShipmentSerial", "GeDFRingSerial", "Ro1MG1RSerial", "Ro2MG1RSerial", "RRRRCoverSerial" });
            }

            return displayedColumns;
        }


        //获取倒序数据
        List<string> GetDescData(string tableName)
        {
            //List<string> exportData = new List<string>();
            var exportData = _redisHelper.GetAllHashValues(tableName);


            return exportData.OrderByDescending(dataRow =>
            {
                var rowData = JsonConvert.DeserializeObject<Dictionary<string, string>>(dataRow);

                var clonum = _exportTable.keyValuePairs[tableName];
                if (rowData.ContainsKey(clonum))
                {
                    string columnValue = rowData[clonum].ToString();
                    if (columnValue.Length >= 8)
                    {
                        return columnValue.Substring(columnValue.Length - 8);
                    }
                }
                return "";
            }).ToList();

        }
    }

}
