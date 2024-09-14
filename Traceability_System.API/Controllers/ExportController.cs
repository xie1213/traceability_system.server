using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        //private readonly ConcurrentDictionary<string, ExportTask> ExportTasks = new ConcurrentDictionary<string, ExportTask>();




        [HttpPost("StartExport")]
        public async Task<IActionResult> StartExport([FromBody] ExportRequest request)
        {
            // 生成唯一的任务ID
            var taskId = string.IsNullOrEmpty(request.TaskId) ? Guid.NewGuid().ToString() : request.TaskId;

            if (request.Count <= 0) return BadRequest("无效的请求数量。");

            ExportTask exportTask = new ExportTask();

            var key = taskId.ToString();

            // 将任务初始化状态存储到 Redis
            var initialJson = JsonConvert.SerializeObject(exportTask);

            await _redisHelper.RedisSetAsync(key, initialJson);


            _ = Task.Run(async () =>
            {
                try
                {
                   

                     byte[] fileBytes = await _exportToExcel.ExportToExcel(request.TableName, request.Count);
                    if (fileBytes != null && fileBytes.Length > 0)
                    {
                        exportTask.Status = ExportStatus.Completed;
                        exportTask.FileBytes = fileBytes;
                    }
                    else
                    {
                        exportTask.Status = ExportStatus.InProgress;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"导出失败: {ex.Message}");
                    exportTask.Status = ExportStatus.Failed;
                    exportTask.ErrorMessage = ex.Message;

                    //ExportTasks[taskId].Status = ExportStatus.Failed;
                }
                finally
                {
                    // 更新任务状态到 Redis
                    var json = JsonConvert.SerializeObject(exportTask);
                    await _redisHelper.RedisSetAsync(key, json);
                }
            });
            return Ok(taskId);
        }

        [HttpGet("CheckExportStatus")]
        public async Task<IActionResult> CheckExportStatus(string taskId)
        {
            try
            {

                var KeyExists = _redisHelper.keyExists(taskId);
                string Status = ExportStatus.InProgress.ToString();

                // 如果状态为 "Failed"，抛出异常

                if (KeyExists)
                {
                    string list = await _redisHelper.RedisGetAsync(taskId);
                    ExportTask exportTask = JsonConvert.DeserializeObject<ExportTask>(list);
                    if (exportTask.ErrorMessage != null)
                    {
                        throw new InvalidOperationException(exportTask.ErrorMessage);
                    }
                    Status = exportTask.Status.ToString();
                }
                return Ok(new { Status });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return Ok(new { Status = "Failed", error = ex.Message });
                throw;
            }
        }

        [HttpGet("DownloadExportedData")]
        public async Task<IActionResult> DownloadExportedData(string taskId, string tableName)
        {
            try
            {
                string list = await _redisHelper.RedisGetAsync(taskId);
                if (list == null)
                {
                    return BadRequest("没有数据");
                }

                ExportTask exportTask = JsonConvert.DeserializeObject<ExportTask>(list);
                _redisHelper.DeleteHash(taskId, 0);
                return File(exportTask.FileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", tableName + ".xlsx");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [HttpGet("DownloadTable")]
        public IActionResult DownloadTable(string tableName)
        {
            var path = Path.Combine(@"D:\exportTable\export",tableName + ".xlsx");


            // 检查文件是否存在
            if (!System.IO.File.Exists(path))
            {
                return NotFound(); // 文件未找到，返回404
            }

            // 读取文件内容
            var fileBytes = System.IO.File.ReadAllBytes(path);

            // 返回文件内容作为下载
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{tableName}.xlsx");
        }


    }


}
public class ExportRequest
{
    public string TableName { get; set; }
    public int Count { get; set; }
}

public class ExportTask
{
    public ExportStatus Status { get; set; } = ExportStatus.NotStarted;
    public byte[] FileBytes { get; set; }

    public string ErrorMessage { get; set; }

}

public enum ExportStatus
{
    NotStarted,
    InProgress,
    Completed,
    Failed
}
