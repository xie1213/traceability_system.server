using Microsoft.AspNetCore.Mvc;
using Traceability_System.Models.FileOperation;

namespace Traceability_System.API.Controllers
{
    [Route("api/[controller]")]
    public class PingController : Controller
    {

        private string lastPingStatus = "";
        private string ipAddress = "192.168.0.10";

        // GET: /ping/status
        [HttpGet("status")]
        public ActionResult<string> GetPingStatus()
        {
            //string ipAddress = "192.168.0.10";

            //string ipAddress = "192.168.81.1";
            IPInspect iPInspect = new IPInspect(ipAddress);
            lastPingStatus = iPInspect.IPInspectMethod();
            // 返回最后一次的Ping状态
            return Ok(lastPingStatus);
        }
    }

}
