
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


        public async Task ExportedTable()
        {
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
            Console.WriteLine("导出ta数据");
            await ProcessDataAsync(
                data,
                dr => dr.DataRowToModel<ExportedTa>());

        }

        public async Task GetInitialGear(DataTable data)
        {
            Console.WriteLine("导出Gear数据");
            await ProcessDataAsync(
                data,
                dr => dr.DataRowToModel<ExportedGear>());
        }

        public async Task GetInitialMotor(DataTable data)
        {
            Console.WriteLine("导出Motor数据");
            await ProcessDataAsync(
                data,
                dr => dr.DataRowToModel<ExportedMotor>());
        }

        public async Task GetInitialRotor(DataTable data)
        {
            Console.WriteLine("导出Rotor数据");
            await ProcessDataAsync(
                data,
                dr => dr.DataRowToModel<ExportedRotor>());
        }

        public async Task GetInitialRr(DataTable data)
        {
            Console.WriteLine("导出Motor数据");
            await ProcessDataAsync(
                data,
                dr => dr.DataRowToModel<ExportedRr>());
        }

        #endregion



        //分析表数据并导出
        public async Task ProcessDataAsync<T>(DataTable data, Func<DataRow, T> converter) where T : class, new()
        {
           
            var result = new List<T>();

            foreach (DataRow dr in data.Rows)
            {
                var item = converter(dr);
                result.Add(item);
            }

            var watch = Stopwatch.StartNew();
            string filename = _tableName;
            if (IsFileInUse(_tableName + ".xlsx"))
                return;

            Console.WriteLine("开始导出");
            try
            {
                using (var context = ContextFactory.GetWriteContext(filename))
                {
                    var sheet = context.CrateSheet<T>(_tableName);
                    for (int i = 0; i < result.Count; i++)
                    {
                        sheet.AppendData(_tableName, result[i]);
                    }
                    string path = context.Save();
                    Console.WriteLine("路径" + path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        //复制文件路径
        //public string CopyFile(string fileName)
        //{
        //    _tableName = subStr(fileName);

        //    string filePath = Path.Combine(baseDirectory, $"{_tableName}.xlsx");
        //    string copyName = $"{fileName}_.xlsx";
        //    string copyPath = Path.Combine(baseDirectory, "export");

        //    if (!Directory.Exists(copyPath))
        //        Directory.CreateDirectory(copyPath);

        //    string copyFlie = Path.Combine(copyPath, copyName);

        //    File.Copy(filePath, copyFlie);
        //    return copyFlie;
        //}

        public static bool IsFileInUse(string fileName)
        {
            bool inUse = true;
            string path = @"D:\exportTable\export";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path = Path.Combine(path, fileName);

            if (!File.Exists(path))
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
