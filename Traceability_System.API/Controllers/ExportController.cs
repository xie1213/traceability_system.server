using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Org.BouncyCastle.Bcpg.Sig;
using Traceability_System.Models.ExportedMethod;
using Traceability_System.Models.FileOperation;
using Traceability_System.Utility;

namespace Traceability_System.API.Controllers
{
    [Route("api/[controller]")]
    public class ExportController : Controller
    {
        private readonly newExportToExcel _exportToExcel;
        private readonly RedisHelper _redisHelper;
        //private readonly ExportTask _exportTask;

        public ExportController(newExportToExcel exportToExcel)
        {
            _exportToExcel = exportToExcel;
            _redisHelper = new RedisHelper();
            //_exportTask = exportTask;
        }


        [HttpGet("DownloadTable")]
        public async Task<IActionResult> DownloadTable(string tableName)
        {
            var value = await _redisHelper.RedisGetAsync(tableName);
            if (value == null)
            {
                return BadRequest("没有数据");
            }
            ExportTask exportTask = JsonConvert.DeserializeObject<ExportTask>(value);

            var status = exportTask.Status.ToString();


            Console.WriteLine(exportTask.Status);
            if (status == "InProgress")
                return Ok("InProgress");

   
            //// 返回文件内容作为下载
            return File(exportTask.FileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{tableName}.xlsx");

        }

        [HttpGet("test")]
        public void test(string path1,string path2)
        {
            MergeExcel.MergeExcelFiles(path1, path2);
        }
    }


}
public class ExportRequest
{
    public string TableName { get; set; }
    public int Count { get; set; }
}


