using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Traceability_System.Models.FileOperation
{
    public class IPInspect
    {
        private readonly string _ipAddress;

        public IPInspect(string ipAddress)
        {
            _ipAddress = ipAddress;
        }

        //检查IP
        public  string IPInspectMethod()
        {
            using (Ping ping = new Ping())
            {
                try
                {
                    // 发送Ping请求
                    PingReply reply = ping.Send(_ipAddress);
                    var ipstart =  UpPingStatus(reply);
                    //Console.WriteLine("成功");
                    return ipstart;
                }
                catch (Exception ex)
                {
                    // 更新最后一次的Ping状态为失败
                    var err =  UpPingStatus(null, ex.Message);
                    Console.WriteLine(ex.Message);
                    return err;
                }
            }

        }
        

           
        public string UpPingStatus(PingReply? reply,string? errorMessage = null)
        {
            string lastPingStatus;
            if (reply != null && reply.Status == IPStatus.Success)
            {
                //SelectAllData.GetDirList();
                lastPingStatus = $"链接成功";
            }
            else if (errorMessage != null)
            {
                lastPingStatus = $"链接时出错: {errorMessage}";
            }
            else
            {
                lastPingStatus = "链接失败";
            }

            return lastPingStatus;
        }
    }
}
