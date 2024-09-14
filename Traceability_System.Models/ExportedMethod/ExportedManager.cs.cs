using DocumentFormat.OpenXml.Vml.Office;
using ExcelKit.Core.Infrastructure.Factorys;
using Newtonsoft.Json;
using NPOI.SS.Util.CellWalk;
using OfficeOpenXml;
using System.Data;
using System.Diagnostics;
using Traceability_System.Entity.ExporteModels;
using Traceability_System.Utility;

namespace Traceability_System.Models.ExportedMethod
{
    public class ExportedManager
    {
        public string _tableName = "";
        public DataTable? data = null;
        public int _count;
        string _path = @"D:\exportTable\export";
        //string _taskId = Guid.NewGuid().ToString();
        private readonly RedisHelper _redisHelper = new RedisHelper();

        //启始程序
        public async Task ExportedTable()
        {
            ExportTask exportTask = new ExportTask();

            var initialJson = JsonConvert.SerializeObject(exportTask);

            await _redisHelper.RedisSetAsync(_tableName, initialJson);

            var _handlers = new Dictionary<string, Func<Task>>()
            {
                { "Ta", () => GetInitialTa(data) },
                { "Gear", () => GetInitialGear(data) },
                { "Motor", () => GetInitialMotor(data) },
                { "Rotor", () => GetInitialRotor(data) },
                { "Rr", () => GetInitialRr(data) },
                { "全部", () => GetInitialAll(data) },
                { "出荷", () => GetInitialShip(data) },



            };

            foreach (var item in _handlers)
            {
                if (_tableName.Contains(item.Key))
                {
                    await item.Value();
                }
            }
        }



        #region 根据不同得数据生成不同表
        public async Task GetInitialTa(DataTable data)
        {
            Console.WriteLine("导出ta数据");
            await ProcessDataAsync(
                data,
                dr => dr.DataRowToModel<ExportedTa>());

        }

        public async Task GetInitialGear(DataTable data)
        {
            var watch = new Stopwatch();
            Console.WriteLine("导出Gear数据");
            await ProcessDataAsync(
                data,
                dr => dr.DataRowToModel<ExportedGear>());
        }

        public async Task GetInitialMotor(DataTable data)
        {
            var watch = new Stopwatch();
            Console.WriteLine("导出Motor数据");
            await ProcessDataAsync(
                data,
                dr => dr.DataRowToModel<ExportedMotor>());
        }

        public async Task GetInitialRotor(DataTable data)
        {
            var watch = new Stopwatch();
            Console.WriteLine("导出Rotor数据");
            await ProcessDataAsync(
                data,
                dr => dr.DataRowToModel<ExportedRotor>());
        }

        public async Task GetInitialRr(DataTable data)
        {
            var watch = new Stopwatch();
            await ProcessDataAsync(
                data,
                dr => dr.DataRowToModel<ExportedRr>());
        }


        private async Task GetInitialShip(DataTable? data)
        {
            var watch = new Stopwatch();
            Console.WriteLine("导出出荷数据");
            await ProcessDataAsync(
                data,
                dr => dr.DataRowToModel<ExportedShip>());
        }

        private async Task GetInitialAll(DataTable? data)
        {
            var watch = new Stopwatch();
            Console.WriteLine("导出全部数据");
            await ProcessDataAsync(
                data,
                dr => dr.DataRowToModel<ExportedAllData>());
        }
        #endregion

        //分析表数据并导出
        public async Task ProcessDataAsync<T>(DataTable data, Func<DataRow, T> converter) where T : class, new()
        {
            var watch = new Stopwatch();
            string w1, w2, w3;
            watch.Start();

            if (data.Rows.Count == 0)
            {
                _redisHelper.DeleteHash(_tableName, 0);
                return;
            }

            var result = new List<T>();

            foreach (DataRow dr in data.Rows)
            {
                var item = converter(dr);
                result.Add(item);
            }

            if (IsFileInUse(_tableName + ".xlsx"))
                return;

            ExportTask exportTask = new ExportTask();
            watch.Stop();
            w1 = watch.Elapsed.ToString();
            Console.WriteLine("data 转list" + w1);
            try
            {
                watch.Start();
                string prefix = _tableName.Split('_')[0];
                string suffix = _tableName.Split("_")[1];
                string tableName = prefix + "test";


                using (var context = ContextFactory.GetWriteContext(prefix))
                {
                    var sheet = context.CrateSheet<T>(prefix);
                    // sheet.Name = tableName;
                    for (int i = 0; i < result.Count; i++)
                    {
                        sheet.AppendData(prefix, result[i]);
                    }
                    string path = context.Save();
                    watch.Stop();
                    w2 = watch.Elapsed.ToString();
                    Console.WriteLine("保存成功" + w2);

                    if (prefix.Contains("出荷"))
                    {
                        File.Move(path, _path);
                        File.Delete(path);
                        ToFileByts(_path);
                    }
                    else
                    {
                        InsertRow(path, _path, prefix);
                    }


                }

            }
            catch (Exception ex)
            {
                exportTask.ErrorMessage = ex.Message;
                exportTask.Status = ExportStatus.Failed;
                var initialJson = JsonConvert.SerializeObject(exportTask);
                _redisHelper.RedisSet(_tableName, initialJson);
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        //检查文件是否存在
        public bool IsFileInUse(string fileName)
        {
            bool inUse = true;

            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }

            _path = Path.Combine(_path, fileName);

            if (!File.Exists(_path))
                return false;

            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);

                inUse = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("文件正在占用，请先关闭文件");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
            return inUse;//true表示正在使用,false没有使用
        }

        //添加行
        public void InsertRow(string oldPath, string newPatn, string prefix)
        {
            var wacth = Stopwatch.StartNew();

            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oldPath);
            // 访问 Excel 文件中的第一个工作表
            Aspose.Cells.Worksheet worksheet = workbook.Worksheets[0];

            int row = prefix.Contains("全部") ? 2 : 1;

            // 从第 3 行开始在工作表中插入 10 行
            worksheet.Cells.InsertRows(0, row);

            // 保存修改后的 Excel 文件
            workbook.Save(newPatn);

            string tblHdrPath = Path.Combine(@"D:\exportTable", prefix + ".xlsx");

            //File.Delete(oldPath);

            wacth.Stop();

            Console.WriteLine("添加行" + wacth.Elapsed);

            MergeFile(newPatn, tblHdrPath);


        }

        //合并文件
        public void MergeFile(string path1, string path2)
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            try
            {
                var wacth = Stopwatch.StartNew();

                using (var package1 = new ExcelPackage(new FileInfo(path1)))
                using (var package2 = new ExcelPackage(new FileInfo(path2)))
                {
                    ExcelWorksheet w1 = package1.Workbook.Worksheets[0]; // 获取第一个工作表
                    ExcelWorksheet w2 = package2.Workbook.Worksheets[0]; // 获取第一个工作表
                    ExcelWorksheet w1_2 = package1.Workbook.Worksheets[1]; // 水印
                    package1.Workbook.Worksheets.Delete(w1_2);

                    foreach (var merge in w2.MergedCells)
                    {
                        w1.Cells[merge].Merge = true;
                    }
                    var rowCount2 = w2.Dimension.End.Row;
                    var colCount2 = w2.Dimension.End.Column;

                    for (int row = 1; row <= rowCount2; row++)
                    {
                        for (int col = 1; col <= colCount2; col++)
                        {
                            var sourceCell = w2.Cells[row, col];
                            var targetCell = w1.Cells[row, col];

                            targetCell.Value = sourceCell.Value;
                            targetCell.Style.HorizontalAlignment = sourceCell.Style.HorizontalAlignment;
                            targetCell.Style.VerticalAlignment = sourceCell.Style.VerticalAlignment;
                        }
                    }
                    //w1.Cells[w1.Dimension.Address].AutoFitColumns();
                    package1.Save();
                }
                wacth.Stop();

                Console.WriteLine("添加表头" + wacth.Elapsed);
                ToFileByts(path1);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        public void ToFileByts(string path1)
        {
            var wacth = Stopwatch.StartNew();

            //var fileBytes = File.ReadAllBytes(path1);

            ExportTask exportTask = new ExportTask();
            exportTask.fliePath = path1;

            exportTask.Status = ExportStatus.Completed;

            var initialJson = JsonConvert.SerializeObject(exportTask);

            _redisHelper.RedisSet(_tableName, initialJson);

            wacth.Stop();
            Console.WriteLine("转化流" + wacth.Elapsed);
        }

    }
    public class ExportTask
    {
        public ExportStatus Status { get; set; } = ExportStatus.InProgress;

        public   string fliePath { get; set; }  

        public string ErrorMessage { get; set; }

    }

    public enum ExportStatus
    {
        InProgress,
        Completed,
        Failed
    }

}
