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

            if (status == "InProgress")
                return Ok("InProgress");

            try
            {
                // Ensure file exists before trying to open
                if (!System.IO.File.Exists(exportTask.fliePath))
                {
                    return NotFound("文件未找到");
                }

                var fileName = $"{tableName}.xlsx";
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileStream = new FileStream(exportTask.fliePath, FileMode.Open, FileAccess.Read, FileShare.Read);

                // Create a file result
                var fileResult = File(fileStream, contentType, fileName);

                // Asynchronously delete the file after returning it
                Task.Run(async () =>
                {
                    await Task.Delay(2000); // Delay to ensure file stream has been handled
                    try
                    {
                        fileStream.Close(); // Ensure the stream is closed
                        System.IO.File.Delete(exportTask.fliePath);
                    }
                    catch (Exception deleteEx)
                    {
                        // Log exception
                        Console.WriteLine($"文件删除失败: {deleteEx.Message}");
                    }
                });

                return fileResult;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"处理文件时发生错误: {ex.Message}");
                return StatusCode(500, "处理文件时发生错误");
            }
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


