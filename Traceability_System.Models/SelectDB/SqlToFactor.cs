using Newtonsoft.Json;
using Traceability_System.DTO;
using Traceability_System.Utility;

namespace Traceability_System.Models.SelectDB
{
    public class SqlToFactor
    {
        private readonly RedisHelper _redisHelper;

        public SqlToFactor(RedisHelper redisHelper)
        {
            _redisHelper = redisHelper;
        }

        public void SetParameterRedis(ParameterData parameter)
        {
            string setRedis = parameter.tableName;
            if (parameter.startDateTime != "")
            {

                string startTime = ConvertToTime(parameter.startDateTime);
                string endTime = ConvertToTime(parameter.endDateTime);
                setRedis += $"_{startTime}-{endTime}";
            }

            if (parameter.serialDateNumber != "")
            {
                setRedis += $"_{parameter.serialDateNumber}";
            }


            string factor = JsonConvert.SerializeObject(parameter);



            var expiry = TimeSpan.FromMinutes(30); // 过期时间为 30 分钟
            _redisHelper.SetJsonData(parameter.tableName, factor, expiry);
        }

        string ConvertToTime(string timeStr)
        {
            DateTime dateTime = DateTime.ParseExact(timeStr, "yyyy-MM-dd HH:mm:ss", null);
            string timestamp = dateTime.ToString("yyyyMMddHHmmss");
            return timestamp;
        }

    }
}
