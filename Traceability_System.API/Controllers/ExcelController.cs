using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Traceability_System.Models.FileOperation;

namespace Traceability_System.API.Controllers
{
    [Route("api/[controller]")]
    public class ExcelController : Controller
    {
        //private readonly ExportToExcel _exportToExcel;
        private readonly newExportToExcel _exportToExcel;

        public ExcelController(newExportToExcel exportToExcel)
        {
            _exportToExcel = exportToExcel;

        }

        [HttpGet("ExportData")]
        public async Task<IActionResult> ExportTable(string tableName)
        {
            // 调用 ExcelService 中的方法创建 Excel 表
            //_exportToExcel
            var watch = Stopwatch.StartNew();

            var filePath = await _exportToExcel.ExportTable(tableName);
            watch.Stop();
            var elapsedMilliseconds = watch.ElapsedMilliseconds;

            await Console.Out.WriteLineAsync("2000条用了:" + elapsedMilliseconds);
            //return File(filePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{tableName}.csv");
            return File(filePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{tableName}.xlsx");

            //return null;

        }
        [HttpGet("SeveToTable")]
        public async Task SeveTable(string tableName)
        {
            var watch = Stopwatch.StartNew();

            await _exportToExcel.ExportTable(tableName);
            watch.Stop();
            var elapsedMilliseconds = watch.ElapsedMilliseconds;

            await Console.Out.WriteLineAsync("2000条用了:" + elapsedMilliseconds);
        }

    }
}
