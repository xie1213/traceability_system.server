using Microsoft.AspNetCore.Mvc;
using Traceability_System.Models.FileOperation;

namespace Traceability_System.API.Controllers
{
    [Route("api/[controller]")]
    public class ExcelController : Controller
    {
        private readonly ExportToExcel _exportToExcel;

        public ExcelController(ExportToExcel exportToExcel)
        {
            _exportToExcel = exportToExcel;
        }

        [HttpGet("ExportData")]
        public IActionResult ExportTable(string tableName)
        {
            // 调用 ExcelService 中的方法创建 Excel 表
            var filePath = _exportToExcel.ExportTable(tableName);

            //返回生成的 Excel 文件给前端进行下载
            //string filePath = $"{tableName}.xlsx";
            //byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(filePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{tableName}.xlsx");
        }
    }
}
