
using DocumentFormat.OpenXml.InkML;
using ExcelKit.Core.ExcelWrite;
using ExcelKit.Core.Infrastructure.Factorys;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using Traceability_System.Entity.ExporteModels;
using Traceability_System.Models.ExportedMethod.interfaces;
using Traceability_System.Utility;

namespace Traceability_System.Models.ExportedMethod
{
    public class ExportedManager
    {
        public string _tableName = "";
        public DataTable? data = null;
        public int _count;
        string _path = @"D:\exportTable\export";
        string _taskId = "";
        private readonly RedisHelper _redisHelper = new RedisHelper();

        //启始程序
        public async Task ExportedTable()
        {
            _taskId = Guid.NewGuid().ToString();

           await _redisHelper.RedisSetAsync(_taskId,"");

            var _handlers = new Dictionary<string, Func<Task>>()
            {
                { "Ta", () => GetInitialTa(data) },
                { "Gear", () => GetInitialGear(data) },
                { "Motor", () => GetInitialMotor(data) },
                { "Rotor", () => GetInitialMotor(data) },
                { "Rr", () => GetInitialMotor(data) },

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
            var watch = new Stopwatch();

            Console.WriteLine("导出ta数据");
            await ProcessDataAsync(
                data,
                watch,
                dr => dr.DataRowToModel<ExportedTa>());

        }

        public async Task GetInitialGear(DataTable data)
        {
            var watch = new Stopwatch();
            Console.WriteLine("导出Gear数据");
            await ProcessDataAsync(
                data,
                watch,
                dr => dr.DataRowToModel<ExportedGear>());
        }

        public async Task GetInitialMotor(DataTable data)
        {
            var watch = new Stopwatch();
            Console.WriteLine("导出Motor数据");
            await ProcessDataAsync(
                data,
                watch,
                dr => dr.DataRowToModel<ExportedMotor>());
        }

        public async Task GetInitialRotor(DataTable data)
        {
            var watch = new Stopwatch();
            Console.WriteLine("导出Rotor数据");
            await ProcessDataAsync(
                data,
                watch,
                dr => dr.DataRowToModel<ExportedRotor>());
        }

        public async Task GetInitialRr(DataTable data)
        {
            var watch = new Stopwatch();
            Console.WriteLine("导出Motor数据");
            await ProcessDataAsync(
                data,
                watch,
                dr => dr.DataRowToModel<ExportedRr>());
        }

        #endregion



        //分析表数据并导出
        public async Task ProcessDataAsync<T>(DataTable data, Stopwatch watch, Func<DataRow, T> converter) where T : class, new()
        {
            if (data.Rows.Count == 0)
            {
                _redisHelper.DeleteHash(_taskId,0);
                return;
            }

            var result = new List<T>();

            foreach (DataRow dr in data.Rows)
            {
                var item = converter(dr);
                result.Add(item);
            }

            string filename = _tableName;
            if (IsFileInUse(_tableName + ".xlsx"))
                return;

            Console.WriteLine("开始导出" + watch.ElapsedMilliseconds);
            try
            {
                string prefix = filename.Split('_')[0];
                using (var context = ContextFactory.GetWriteContext(prefix))
                {
                    var sheet = context.CrateSheet<T>(prefix);
                    for (int i = 0; i < result.Count; i++)
                    {
                        sheet.AppendData(prefix, result[i]);
                    }
                    string path = context.Save();

                    File.Move(path, _path);

                    Console.WriteLine("导出成功" + watch.ElapsedMilliseconds);
                    Console.WriteLine("路径" + path);
                }
            }
            catch (Exception ex)
            {
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




    }
}
