using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traceability_System.Models.FileOperation
{
    public class FileSpace
    {

        //获取文件夹内存大小
        public static long CalculateFolderSize(string folderPath)
        {
            long size = 0;

            // 获取文件夹中的所有文件
            string[] files = Directory.GetFiles(folderPath);

            // 计算文件大小总和
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                size += fileInfo.Length;
            }

            // 获取文件夹中的所有子文件夹
            string[] subFolders = Directory.GetDirectories(folderPath);

            // 递归计算子文件夹的大小
            foreach (string subFolder in subFolders)
            {
                size += CalculateFolderSize(subFolder);
            }

            return size;
        }

        //根据大小返回不同值
        public static string GetFriendlySize(long sizeInBytes)
        {
            // 将字节转换为MB和GB
            double sizeInMB = sizeInBytes / (1024.0 * 1024.0);
            double sizeInGB = sizeInBytes / (1024.0 * 1024.0 * 1024.0);

            // 如果文件大小大于或等于1 GB，则返回GB，否则返回MB
            if (sizeInGB >= 1)
            {
                return $"{sizeInGB:F2} GB";
            }
            else
            {
                return $"{sizeInMB:F2} MB";
            }
        }
    }
}
