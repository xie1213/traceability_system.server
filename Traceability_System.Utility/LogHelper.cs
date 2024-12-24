using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traceability_System.Utility
{
    public class LogHelper
    {
        private static SemaphoreSlim _fileAccessSemaphore = new SemaphoreSlim(1, 1);
        public string Today { get { return DateTime.Now.ToString("yyyy-MM-dd"); } }

        public string logDir = @"D:\LogFile";


        public void Warn(string log)
        {
            WriteLogAsync(log, "Warn");
        }

        public void Info(string log)
        {
            WriteLogAsync(log, "Info");
        }

        public void Error(string log)
        {
            WriteLogAsync(log, "Error");
        }

        //public void Warn(string log)
        //{
        //    WriteLogAsync(log, "Warn");
        //}




        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        async void WriteLogAsync(string logMessage, string logLevel)
        {

            string logPath = await LogPathIsNull(); // 日志文件夹路径

            //string logTxtPath = await CreateLogFileAsync();//日志文件路径

            await _fileAccessSemaphore.WaitAsync(); // 获取文件信号保证只有一个

            try
            {
                using (FileStream fs = new FileStream(logPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    await writer.WriteLineAsync($"[{DateTime.Now}] [{logLevel}] : {logMessage}\t");
                }
            }
            finally
            {
                _fileAccessSemaphore.Release(); // 释放信号
            }

        }

        /// <summary>
        /// 读取日志
        /// </summary>
        /// <returns></returns>
        //public static async Task<List<string>> ReadLogAsync()
        //{

        //    string logPath = await LogPathIsNull(); // 日志文件路径

        //    List<string> logLines = new List<string>();

        //    await _fileAccessSemaphore.WaitAsync(); // 获取文件信号保证只有一个

        //    try
        //    {
        //        DateTime startTime = DateTime.Now.AddSeconds(-120);
        //        //int lastReadPosition = (int)Properties.Settings.Default.oldReadPosition;//最后读取行数

        //        using (FileStream fs = new FileStream(logPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        //        using (StreamReader reader = new StreamReader(fs))
        //        {
        //            string line;
        //            if (lastReadPosition > 0)
        //            {
        //                for (int i = 0; i < lastReadPosition; i++)
        //                {
        //                    if (await reader.ReadLineAsync() == null)
        //                    {
        //                        lastReadPosition = i;
        //                        break;
        //                    }
        //                }
        //            }
        //            //fs.Seek(lastReadPosition, SeekOrigin.Begin);
        //            while ((line = await reader.ReadLineAsync()) != null)//如果读到数据不为空
        //            {
        //                if (line.Contains("[Information]"))
        //                {
        //                    string logText = line.Replace("[Information]", "");
        //                    if (line.Contains("#"))
        //                    {
        //                        logText = logText.Replace("#", "\n");

        //                        logLines.Add(logText);
        //                    }
        //                }

        //                lastReadPosition++;
        //            }

        //            //Properties.Settings.Default.oldReadPosition = lastReadPosition;//更新读取数
        //            Properties.Settings.Default.Save();
        //        }
        //    }
        //    finally
        //    {
        //        _fileAccessSemaphore.Release(); // 释放信号
        //    }

        //    return logLines;
        //}

        /// <summary>
        /// 清除日志
        /// </summary>
        public void CleanupLogs()
        {
           
                                                                            // 获取当前日期
            DateTime currentDate = DateTime.Now;

            // 获取目录中的日志文件列表
            //string[] logFiles = Directory.GetFiles(logFiles);

            string[] logFiles = Directory.GetDirectories(logDir);

            foreach (var logFile in logFiles)
            {
                // 获取日志文件的创建日期
                DateTime creationDate = File.GetCreationTime(logFile);
                string logName = Path.GetFileName(logFile);
                string format = "yyyy-MM-dd";
                DateTime parsedDate;
                if (DateTime.TryParseExact(logName, format, CultureInfo.InvariantCulture, DateTimeStyles.None,
                        out parsedDate))
                {
                    // 如果日志文件超过14天，删除它
                    if (currentDate - creationDate >= TimeSpan.FromDays(9))
                    {
                        //DeleteDirectory(logFile);
                        Info($"日志文件夹{logFile},超过一周已删除");
                    }
                }
            }
        }


        /// <summary>
        /// 递归删除文件
        /// </summary>
        /// <param name="targetDirectory"></param>
        //static void DeleteDirectory(string targetDirectory)
        //{
        //    try
        //    {
        //        // 删除目标目录中的所有文件
        //        foreach (string file in Directory.GetFiles(targetDirectory))
        //        {
        //            File.Delete(file);
        //        }

        //        // 递归删除所有子目录及其内容
        //        foreach (string subdirectory in Directory.GetDirectories(targetDirectory))
        //        {
        //            DeleteDirectory(subdirectory);
        //        }

        //        // 删除目标目录本身
        //        Directory.Delete(targetDirectory);

        //        Console.WriteLine("目录及其内容已成功删除。");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"发生错误: {ex.Message}");
        //    }
        //}

        //判断日志路径是否为空
        private async Task<string> LogPathIsNull()
        {
            //string logFileDire = ConfigurationManager.AppSettings["LogConfig"];

            string logFileNow = Path.Combine(logDir, $"{Today}");
            //根据LogConfig配置判断LogPath是否为空
            if (!Directory.Exists(logFileNow))
            {
                Directory.CreateDirectory(logFileNow);
            }
            string logTxtPath = Path.Combine(logFileNow, $"{Today}.log");
            //检查文件是否存在，如果不存在，则创建文件（异步方式）
            if (!File.Exists(logTxtPath))
            {
                await _fileAccessSemaphore.WaitAsync(); // 获取文件信号保证只有一个
                                                        // 创建日志文件夹（如果不存在）
                try
                {
                    using (FileStream fs = File.Create(logTxtPath))
                    {
                        await fs.FlushAsync(); // 异步刷新文件流
                    }
                }
                finally
                {
                    _fileAccessSemaphore.Release();
                }

            }
            return logTxtPath;
        }
    }



}
