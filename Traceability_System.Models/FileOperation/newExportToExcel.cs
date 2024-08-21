using Newtonsoft.Json;
using OfficeOpenXml;
using System.Data;
using System.Drawing.Drawing2D;
using Traceability_System.Models.DictionaryMapper;
using Traceability_System.Utility;


namespace Traceability_System.Models.FileOperation
{
    public class newExportToExcel
    {
        private readonly RedisHelper _redisHelper;
        private readonly ExportTableMapper _exportTable;
        public string filePath = "";

        string baseDirectory = @"D:\exportTable";
        public string _tableName = "";
        int _count = 0;


        public newExportToExcel(RedisHelper redisHelper, ExportTableMapper exportTable)
        {
            _redisHelper = redisHelper;
            _exportTable = exportTable;

        }

        //导出数据发送流给前端
        public async Task<byte[]> ExportToExcel(string tableName, int count)
        {
            //文件保存路径
            filePath = CopyFile(tableName);

            //许可证
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //List<string> allList = new List<string>();

            var list = _redisHelper.GetAllHashValues(_tableName);
            // 将当前页数据添加到总数据集合中

            _count = count;

            // 如果数据为空，则返回空数组
            if (count == 0)
            {
                return new byte[0];
            }
            FileInfo fileInfo = new FileInfo(filePath);

            try
            {
                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {

                    await CreateExcel(package, list, tableName);
                    //worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns(); // 最后一次调整列宽

                    using (var memoryStream = new MemoryStream())
                    {
                        await package.SaveAsAsync(memoryStream);
                        File.Delete(filePath);
                        return memoryStream.ToArray();
                        //package.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
            }

        }

        //直接保存到后端
        public async Task SevaToExcel(string tableName)
        {
            //文件保存路径
            filePath = CopyFile(tableName);

            //许可证
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //List<string> allList = new List<string>();

            var list = _redisHelper.GetAllHashValues(_tableName);
            // 将当前页数据添加到总数据集合中

            _count = list.Count;
            FileInfo fileInfo = new FileInfo(filePath);

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {

                await CreateExcel(package, list, tableName);
                //worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns(); // 最后一次调整列宽

                using (var memoryStream = new MemoryStream())
                {
                    await package.SaveAsAsync(memoryStream);

                    package.Save();
                }
            }
        }

        //创建表格
        public async Task<ExcelPackage> CreateExcel<T>(ExcelPackage package, List<T> list, string tableName)
        {
            try
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // 第一个工作表
                int processedRows = 0;
                //int batchSize = count;
                int batchSize = 5000;

                worksheet.Name = tableName;

                var skipKeys = SkipField(_tableName); // 跳过字段

                #region 原版

                while (processedRows < _count)
                {
                    var batchList = list.Skip(processedRows).Take(batchSize).ToList();

                    if (batchList.Count == 0) break;

                    processedRows += batchList.Count;



                    var tasks = batchList.Select(async (item, index) =>
                    {
                        var rowData = JsonConvert.DeserializeObject<Dictionary<string, string>>(item.ToString());

                        //根据表格名字选择第二列
                        string itemKey = _exportTable.keyValuePairs.TryGetValue(_tableName, out string key) ? rowData[key].ToString() : string.Empty;

                        int row = processedRows - batchList.Count + index; // 起始行
                        int col = 3;
                        if (_tableName.Contains("出荷"))
                        {
                            row += 2;
                            col = 1;
                        }
                        else
                        {

                            row += _tableName.Contains("全部") ? 4 : 3;
                            DateTime collectionDate = DateTime.Parse(rowData["CollectionDate"]);
                            worksheet.Cells[row, 1].Value = collectionDate; //固定字段
                            worksheet.Cells[row, 1].Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";
                            worksheet.Cells[row, 2].Value = itemKey;
                            //skipKeys.Add("");
                            skipKeys.Add(key);
                        }


                        foreach (var pair in rowData)
                        {

                            ExcelRange cells = worksheet.Cells[row, col];

                            if (skipKeys.Contains(pair.Key))
                                continue;

                            GetKeyType(pair.Key, pair.Value, cells);

                            cells.Value = pair.Value;
                            col++;
                        }
                    });

                    await Task.WhenAll(tasks);
                }
                #endregion

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns(); // 最后一次调整列宽
                return package; // 返回处理后的包
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        //获取单元格格式
        void GetKeyType(string key, string value, ExcelRange cells)
        {
            //比较字符串
            var comparer = StringComparer.OrdinalIgnoreCase;

            try
            {
                if (_exportTable.columns.Contains(key, comparer) || value == "")
                {
                    cells.Value = value;

                }
                else
                {
                    if (key.Contains("Date") && DateTime.TryParse(value, out DateTime dateValue))
                    {
                        DateTime collectionDate = DateTime.Parse(value);

                        cells.Value = collectionDate;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }




        }


        //复制文件路径
        public string CopyFile(string fileName)
        {
            _tableName = subStr(fileName);

            string filePath = Path.Combine(baseDirectory, $"{_tableName}.xlsx");
            string copyName = $"{fileName}_.xlsx";
            string copyPath = Path.Combine(baseDirectory, "export");

            if (!Directory.Exists(copyPath))
                Directory.CreateDirectory(copyPath);

            string copyFlie  = Path.Combine(copyPath, copyName);

            File.Copy(filePath, copyFlie);
            return copyFlie;
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
