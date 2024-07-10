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
        public async Task<IActionResult> ExportTable(string tableName,string count)
        {

            int tabCount = Convert.ToInt32(count);
            if (tabCount == 0) return NotFound();

            var filePath = await _exportToExcel.ExportToExcel(tableName, tabCount);

            if (filePath != null && filePath.Length > 0)
            {
                return File(filePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{tableName}.xlsx");
            }
            else
            {
                return NotFound();
            }


        }
        [HttpGet("SeveToTable")]
        public async Task SeveTable(string tableName)
        {
            var watch = Stopwatch.StartNew();

            await _exportToExcel.SevaToExcel(tableName);
            watch.Stop();
            var elapsedMilliseconds = watch.ElapsedMilliseconds;

            await Console.Out.WriteLineAsync("2000条用了:" + elapsedMilliseconds);
        }

    }
}
