using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using Traceability_System.Models;
using Traceability_System.Utility;

namespace Traceability_System.Api.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {

        [HttpGet]
        public List<string> GetStr(string txt)
        {
            //Gaer_Rotor_Parse gaer_Rotor_Parse = new Gaer_Rotor_Parse(txt);
            //return gaer_Rotor_Parse.RR_and_GearSplitList();
            //RR_Parse motor_Parse = new RR_Parse(txt);
            //return motor_Parse.RR_SplitList();
            //TA_Parse t_Parse = new TA_Parse(txt);
            //return t_Parse.TA_SplitList();
            Motor_Parse motor = new Motor_Parse(txt);
            return motor.MotorSplitList();
            //Rotor_Parse rotor_Parse = new Rotor_Parse(txt);
            //return rotor_Parse.RR_and_GearSplitList();

        }


        //[HttpGet("getLen")]
        //public IActionResult GetLen(string txt)
        //{
        //    //return txt.Length.ToString();
        //    //List<Dictionary<string, object>> TableDataList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(tableData);

        //    var json = RedisHelper.ReString(txt.ToString());
        //    if (json == null)
        //    {
        //        return null;
        //    }
        //    var obj = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
        //    var pageData = obj.Skip((1 - 1) * 100).Take(100);

        //    pageData = obj.Where(x =>
        //        DateTime.Parse(x["CollectionDate"]) >= DateTime.Parse("2024/1/1 13:18:32") &&
        //        DateTime.Parse(x["CollectionDate"]) <= DateTime.Parse("2024/1/1 12:18:32"));
        //    return Ok(new { data = pageData, count = obj.Count(), code = 200 });
        //}
        [HttpGet("WriteCsvToRedis")]
        public void WriteCsvToRedis(string txt)
        {
           //SelectAllData.GetDirList();
        }

        [HttpPost("requestData")]
        public void ReceiveJson([FromBody] dynamic requestData)
        {
            string jsonData = requestData.ToString();
            //string jsonData = JsonConvert.SerializeObject(requestData);

            RedisHelper.RedisSet("出荷数据", jsonData, 4);
        }

    }


}
