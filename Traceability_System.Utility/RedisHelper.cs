using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System;

namespace Traceability_System.Utility
{
    public class RedisHelper
    {
        private static ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");
        private static IDatabase db;



        /// <summary>
        /// 存入键值对
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static bool RedisSet(string key, string value, int dbNum = 0)
        {
            db = redis.GetDatabase(dbNum);
            // 判断key是否存在
            //if (db.KeyExists(key))
            //{
            //    //// key存在，判断value是否存在
            //    //if (!string.IsNullOrEmpty(db.StringGet(key)))
            //    //{
            //    //    //存在return;
            //    //    return false;
            //    //}
            //    //// value不存在，将新的value添加到原有的value后面
            //    //db.StringAppend(key, value);

            //}
            //else
            //{
            //    // key不存在，创建key并设置value
            //    db.StringSet(key, value);
            //}
            db.StringSet(key, value);
            return true;
        }

        /// <summary>
        /// 根据键获取值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public string RedisGetAsync(string key, int dbNum = 0)
        {
            //Task.Delay(1000); // 模拟延迟
            var db = redis.GetDatabase(dbNum);
            return db.StringGet(key);
        }


        /// <summary>
        /// 存入json数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        public static void SetJsonData(string key, string data, int dbNum = 0)
        {
            Task.Run(() =>
            {
                db = redis.GetDatabase(dbNum);
                if (dbNum != 5)
                {
                    db.StringSet(key, data);
                }
            });
        }

        /// <summary>
        /// 读取json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetJsonData<T>(string key, int dbNum = 0)
        {
            db = redis.GetDatabase(dbNum);
            // 使用 GET 命令从 Redis 中检索 JSON 数据
            string json = db.StringGet(key);

            if (!string.IsNullOrEmpty(json))
            {
                // 将 JSON 字符串反序列化为对象
                return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
            }
            else
            {
                return null;
            }
        }

        public  List<Dictionary<string, string>> ReString(string txt, int dbNum = 0)
        {
            db = redis.GetDatabase(dbNum);
            string dataFromRedis = db.StringGet(txt);
            if (dataFromRedis == null)
            {
                return null;
            }
            var obj = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(dataFromRedis);
            return obj;
        }
        public  List<Dictionary<string, string>> ReStringAsync(string txt, int dbNum = 0)
        {
            var db = redis.GetDatabase(dbNum);
            string dataFromRedis = db.StringGet(txt);
            if (dataFromRedis == null)
            {
                return new List<Dictionary<string, string>>();
            }
            return JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(dataFromRedis);

        }

        /// <summary>
        /// 存入Hash
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="hashField"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public  int SetHash(string redisKey, string hashField, int dbnum)
        {
            db = redis.GetDatabase(dbnum);

            int value = 0;
            if (db.HashExists(redisKey, hashField))
            {
                var newvalue = db.HashGet(redisKey, hashField);
                if (!newvalue.IsNull)
                {
                    value = (int)newvalue + 1;
                }
            }
            db.HashSet(redisKey, hashField, value);
            return value;
        }

        //存入json类型得hash
        public  void SetHashToJson(string hashKey, string field, string value, int dbnum = 7)
        {
            db = redis.GetDatabase(dbnum);
            db.HashSet(hashKey, field, value);
        }
        //获取Hash键值
        public  string GetHashValue(string key, string field, int dbnum)
        {
            db = redis.GetDatabase(dbnum);
            return db.HashGet(key, field);
        }
        /// <summary>
        /// 从Hash中获取分页数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public  List<object> GetHashToPage(string tableName,int page = 0,int pageSize = 0)
        {
            db = redis.GetDatabase(7);

            var allFields = db.HashKeys(tableName);
            //const int pageSize = 50;
            List<object> list = new List<object>();
            RedisValue[]? pageFields = null;
            if (page == 0 || pageSize == 0 )
            {
                pageFields = allFields.ToArray();

            }
            else
            {
                pageFields = allFields.Skip((page - 1) * pageSize).Take(pageSize).ToArray(); ;
            }

            var values = db.HashGet(tableName, pageFields);
            foreach (var item in values)
            {
                var Rowdata = JsonConvert.DeserializeObject<Dictionary<string, string>>(item.ToString());

                list.Add(Rowdata);
            }

            return list;
        }
        
        //获取hash中的值

        public  RedisValue[] GetAllHashValues(string tableName,int dbnum=7)
        {
            db = redis.GetDatabase(dbnum);
            var values = db.HashValues(tableName);
            return values;
        }

        public  void DeleteHash(string tableName,int dbnum = 7)
        {
            db = redis.GetDatabase(dbnum);
            db.KeyDelete(tableName);
        }
    }
}
