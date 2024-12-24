using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        private ExportTask _exportTask;
        private readonly LogHelper _logHelper;

        public ExportController(newExportToExcel exportToExcel, LogHelper logHelper)
        {
            _exportToExcel = exportToExcel;
            _redisHelper = new RedisHelper();
            _exportTask = new ExportTask();
            _logHelper = logHelper;
        }


        [HttpGet("GetPath")]
        public async Task<IActionResult> GetPath(string tableName)
        {
            try
            {
                var value = await _redisHelper.RedisGetAsync(tableName);
                if (value == null)
                {
                    return BadRequest("没有数据");
                }
                _exportTask = JsonConvert.DeserializeObject<ExportTask>(value);

                var status = _exportTask.Status.ToString();

                return Ok(status);
            }
            catch (Exception)
            {
                _logHelper.Error("导出失败");
                return BadRequest();
            }
           
        }

        [HttpPost("DownloadTable")]
        public async Task<IActionResult> DownloadTable(string tableName)
        {
            var value = await _redisHelper.RedisGetAsync(tableName);
            if (value == null)
            {
                return BadRequest("没有数据");
            }
            _exportTask = JsonConvert.DeserializeObject<ExportTask>(value);

            try
            {
                if (!System.IO.File.Exists(_exportTask.fliePath))
                {
                    return NotFound("文件未找到");
                }

                var fileName = $"{tableName}.xlsx";
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                var fileStream = new FileStream(_exportTask.fliePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var fileResult = File(fileStream, contentType, fileName);

                // Asynchronously delete the file after returning it
                _ = Task.Run(async () =>
                {
                    await Task.Delay(6000); // Delay to ensure the file stream has been handled
                    try
                    {
                        fileStream.Dispose(); // Dispose the stream before deleting
                        System.IO.File.Delete(_exportTask.fliePath);
                    }
                    catch (Exception deleteEx)
                    {
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



        [HttpPost("testexpot")]
        public IActionResult testexpot()
        {
            string path = @"D:\exportTable\export\Test.xlsx";
            var fileName = $"Test.xlsx";
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            var fileResult = File(fileStream, contentType, fileName);
            _ = Task.Run(async () =>
            {
                await Task.Delay(6000); // Delay to ensure the file stream has been handled
                try
                {
                    fileStream.Dispose(); // Dispose the stream before deleting
                }
                catch (Exception deleteEx)
                {
                    Console.WriteLine($"文件删除失败: {deleteEx.Message}");
                }
            });

            return fileResult;

            //string path = @"D:\exportTable\export\Test.xlsx";
            //var fileName = "Test.xlsx";
            //var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //try
            //{
            //    using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            //    {
            //        var fileResult = File(fileStream, contentType, fileName);
            //        return fileResult;
            //    }
            //}
            //catch (Exception ex )
            //{
            //    Console.WriteLine(ex.Message);
            //    throw;
            //}


        }

    }


}
public class ExportRequest
{
    public string TableName { get; set; }
    public int Count { get; set; }
}


