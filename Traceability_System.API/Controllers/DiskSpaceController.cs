using Microsoft.AspNetCore.Mvc;
using Traceability_System.Models.FileOperation;

namespace Traceability_System.API.Controllers
{
    [Route("api/[controller]")]
    public class DiskSpaceController : Controller
    {

        [HttpGet("GetDDriveSpace")]
        public IActionResult GetDDriveSpace()
        {
            string driveName = "D";
            DriveInfo driveInfo = new DriveInfo(driveName);

            if (driveInfo.IsReady)
            {
                long availableSpace = driveInfo.AvailableFreeSpace;
                double availableSpaceGB = availableSpace / (1024.0 * 1024.0 * 1024.0);
                return Ok(new { AvailableSpaceGB = $"{availableSpaceGB:F2} GB" });
            }
            else
            {
                return NotFound(new { Message = $"驱动器 {driveName} 不存在或不可用。" });
            }
        }

        //获取文件夹内存
        [HttpGet("FolderSize")]
        public IActionResult GetFolderSize()
        {
            try
            {
                string folderPath = @"D:\FTP";
                // 检查文件夹路径是否为空
                if (string.IsNullOrWhiteSpace(folderPath))
                {
                    return BadRequest("文件夹路径不能为空。");
                }

                // 检查文件夹是否存在
                if (!Directory.Exists(folderPath))
                {
                    return NotFound($"文件夹 '{folderPath}' 不存在。");
                }

                // 调用方法获取文件夹大小
                long folderSize = FileSpace.CalculateFolderSize(folderPath);

                // 将字节转换为更友好的单位
                string friendlySize = FileSpace.GetFriendlySize(folderSize);

                //// 显示文件夹所占用的内存大小
                //Console.WriteLine($"文件夹 {folderPath} 的内存大小为：{friendlySize}");

                // 返回文件夹所占用的内存大小
                return Ok(new { FolderSizeGB = friendlySize });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"发生错误：{ex.Message}");
            }
        }
    }
}
