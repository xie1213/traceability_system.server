
using Appraisal_System.Utility;
using Traceability_System.Models.FileOperation;
using Traceability_System.Models.SelectDB;

namespace Traceability_System.API
{
    public class FileReaderService : IHostedService, IDisposable
    {
        //定义定时器
        private Timer _timer;

        private readonly IConfiguration Configuration;

        private readonly MergeCsv _mergeCsv;
        public FileReaderService(IConfiguration config, MergeCsv mergeCsv)
        {
            Configuration = config;
            SqlHelper.ConStr = Configuration["Data:ConnectionString"];
            _mergeCsv = mergeCsv;
        }

        public void Dispose()
        {
            //释放资源
            _timer.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //创建一个定时器,指定立即执行第一次任务和每隔1分钟执行一次任务
            _timer = new Timer(ReadFiles, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            // 停止定时器
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }


        private async void ReadFiles(object state)
        {
            await ReadFilesAsync(); // 异步并行读取文件夹
            _mergeCsv.GetDirList();
        }

        // 定时任务调用的方法 
        public async Task ReadFilesAsync()
        {
            TableOperation TableOperation = new TableOperation();
            var folders = new[] { "Gear", "Motor", "Rotor", "TA", "Rr" };
            int i = 0;
            //并行
            var tasks = folders.Select(async folder =>
            {
                await TableOperation.DirectoryExist(folder);
                i++;
            });

            await Task.WhenAll(tasks);
        }

    }
}
