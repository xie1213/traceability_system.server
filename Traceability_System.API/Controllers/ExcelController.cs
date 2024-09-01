using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
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
        public async Task<IActionResult> ExportTable(string tableName, string count)
        {
            var watch = Stopwatch.StartNew();
            int tabCount = Convert.ToInt32(count);
            if (tabCount == 0) return NotFound();

            var filePath = await _exportToExcel.ExportToExcel(tableName, tabCount);
            watch.Stop();
            if (filePath != null && filePath.Length > 0)
            {
                await Console.Out.WriteLineAsync(count + "条用了:" + watch.ElapsedMilliseconds);
                return File(filePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{tableName}.xlsx");

            }
            else
            {
                return NotFound();
            }


        }


        private readonly ConcurrentDictionary<string, byte[]> ExportTasks = new ConcurrentDictionary<string, byte[]>();

        [HttpPost("StartExport")]
        public async Task<IActionResult> StartExport([FromBody] ExportRequest request)
        {
            //生成唯一ID
            var taskId = Guid.NewGuid().ToString();
            if (request.Count <= 0) return BadRequest("无效的请求数量。");
            ExportTasks[taskId] = null;

            _ = Task.Run(async () =>
            {
                try
                {
                    byte[] fileBytes = await _exportToExcel.ExportToExcel(request.TableName, request.Count);
                    if (fileBytes != null && fileBytes.Length > 0)
                    {
                        // 如果成功，更新任务状态为文件路径
                        ExportTasks[taskId] = fileBytes;
                    }
                    else
                    {
                        // 如果失败，更新状态为失败
                        ExportTasks[taskId] = null;
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            });
            return Ok(new { TaskId = taskId });
        }

        // 检查导出任务状态
        [HttpGet("CheckExportStatus")]
        public IActionResult CheckExportStatus(string taskId)
        {
            // 尝试获取任务状态
            if (ExportTasks.TryGetValue(taskId, out var fileBytes))
            {
                if (fileBytes != null && fileBytes.Length > 0)
                {
                    // 如果任务完成，返回状态
                    return Ok(new { Status = "Completed" });
                }
                else
                {
                    // 如果任务失败
                    return Ok(new { Status = "Failed" });
                }
            }
            // 如果找不到任务，返回 NotFound
            return NotFound();
        }


        // 下载导出的数据
        [HttpGet("DownloadExportedData")]
        public IActionResult DownloadExportedData(string taskId)
        {
            // 根据任务 ID 获取字节数组
            if (ExportTasks.TryGetValue(taskId, out var fileBytes) && fileBytes != null && fileBytes.Length > 0)
            {
                // 返回文件字节数组
                return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "export.xlsx");
            }
            // 如果找不到文件字节数组或任务未完成，返回 NotFound
            return NotFound();
        }

    }
    public class ExportRequest
    {
        public string TableName { get; set; }
        public int Count { get; set; }

        public string TaskId { get; set; }
    }

}
