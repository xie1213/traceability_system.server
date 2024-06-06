namespace Traceability_System.Utility
{
    public class ProofData
    {
       // private readonly RedisHelper _redisHelper;

        //public ProofData(RedisHelper redisHelper)
        //{
        //    _redisHelper = redisHelper;
        //}

         Dictionary<string, (string field, int index)> fieldMaps = new Dictionary<string, (string field, int index)>{
             {"NewMotorTable", ("ShipmentSerial", 27)},
              {"MotorTable", ("ShipmentSerial", 27)},
              {"TATable", ("ShipmentSerial", 27)},

              {"GearTable", ("DFringSerial", 24)},

              {"RotorTable", ("MG1RSerial", 18)},

              {"RrTable", ("RRCoverSerial", 26)},

            };
       
        public  List<string> KeyValues(string key,List<string> value)
        {
            List<string> list = new();
            string keyCode = "", field = "";

            if (fieldMaps.TryGetValue(key, out var map))
            {

                field = map.field;
                int index = map.index;

                // 读取值
                keyCode = value[index];
            }
            list.AddRange(new[] { field, keyCode});
            return list;
        } 
    }



}
