using Newtonsoft.Json;
using StackExchange.Redis;
using System.Collections.Generic;

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
        public bool RedisSet(string key, string value, int dbNum = 0)
        {
            db = redis.GetDatabase(dbNum);

            db.StringSet(key, value);
            return true;
        }


        /// <summary>
        /// 异步存储
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="dbNum"></param>
        public async Task RedisSetAsync(string key,string value,int dbNum = 0)
        {
            db = redis.GetDatabase(dbNum);

            await db.StringSetAsync(key, value);
        }


        /// <summary>
        /// 根据键获取值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public async Task<string> RedisGetAsync(string key, int dbNum = 0)
        {
            //Task.Delay(1000); // 模拟延迟
            var db = redis.GetDatabase(dbNum);
            var value =  await db.StringGetAsync(key);
            return value;
        }


        /// <summary>
        /// 存入json数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        public void SetJsonData(string key, string data, TimeSpan expiry, int dbNum = 6)
        {
            db = redis.GetDatabase(dbNum);
            db.StringSet(key, data, expiry);
        }



        /// <summary>
        /// 存入Hash
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="hashField"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetHash(string redisKey, string hashField, int dbnum)
        {
            db = redis.GetDatabase(dbnum);

            //int value = 0;
            if (db.HashExists(redisKey, hashField))
            {
                var newvalue = db.HashGet(redisKey, hashField);
            }

            db.HashSet(redisKey, hashField, hashField);
            TimeSpan expiry = TimeSpan.FromDays(3);
            db.KeyExpire(redisKey, expiry);
            //return ;
        }

        //存入json类型得hash
        public void SetHashToJson(string hashKey, string field, string value, int dbnum = 7)
        {
            db = redis.GetDatabase(dbnum);
            TimeSpan expiry = TimeSpan.FromDays(1);
            db.HashSet(hashKey, field, value);
            db.KeyExpire(hashKey, expiry);
        }

        /// <summary>
        /// 从Hash中获取分页数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<object>> GetHashToPageAsync(string tableName, int page = 0, int pageSize = 0)
        {
            try
            {
                db = redis.GetDatabase(7);

                var allFields = await db.HashKeysAsync(tableName);
                List<object> list = new List<object>();

                RedisValue[] pageFields;
                if (page == 0 || pageSize == 0)
                {
                    pageFields = allFields;
                }
                else
                {
                    int startIndex = (page - 1) * pageSize;
                    int count = Math.Min(pageSize, allFields.Length - startIndex);
                    pageFields = allFields.Skip(startIndex).Take(count).ToArray();
                }

                var values = await db.HashGetAsync(tableName, pageFields);
                foreach (var item in values)
                {
                    var rowData = JsonConvert.DeserializeObject<Dictionary<string, string>>(item);
                    list.Add(rowData);
                }

                return list;
            }
            catch (RedisConnectionException ex)
            {
                // 处理 Redis 连接异常
                Console.WriteLine("Redis 连接失败：" + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                // 处理其他异常
                Console.WriteLine("发生异常：" + ex.Message);
                throw;
            }
        }

        //public async Task<List<PairField>> GetHashToPage(string tableName, int page = 0, int pageSize = 0)
        //{
        //    try
        //    {
        //        db = redis.GetDatabase(7);

        //        var allFields = await db.HashKeysAsync(tableName);
        //        List<object> list = new List<object>();

        //        RedisValue[] pageFields;
        //        if (page == 0 || pageSize == 0)
        //        {
        //            pageFields = allFields;
        //        }
        //        else
        //        {
        //            int startIndex = (page - 1) * pageSize;
        //            int count = Math.Min(pageSize, allFields.Length - startIndex);
        //            pageFields = allFields.Skip(startIndex).Take(count).ToArray();
        //        }

        //        var values = await db.HashGetAsync(tableName, pageFields);
        //        foreach (var item in values)
        //        {
        //            var rowData = JsonConvert.DeserializeObject<PairField>(item);
        //            list.Add(rowData);
        //        }

        //        return list;
        //    }
        //    catch (RedisConnectionException ex)
        //    {
        //        // 处理 Redis 连接异常
        //        Console.WriteLine("Redis 连接失败：" + ex.Message);
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        // 处理其他异常
        //        Console.WriteLine("发生异常：" + ex.Message);
        //        return null;
        //    }
        //}

        //获取hash中的值

        public List<string> GetAllHashValues(string tableName, int dbnum = 7)
        {
            db = redis.GetDatabase(dbnum);
            var values = db.HashValues(tableName);


            return values.Select(v => v.ToString()).ToList();
            //return values;
        }

        public void DeleteHash(string key, int dbnum = 7)
        {
            db = redis.GetDatabase(dbnum);
            bool keyExists = db.KeyExists(key);
            if (keyExists)
            {
                db.KeyDelete(key);
                //Console.WriteLine($"存在{hashKey} 已删除");
            }
        }


        //检查键是否存在
        public bool keyExists(string Key, int dbnum = 0)
        {
            db = redis.GetDatabase(dbnum);
            bool keyExists = db.KeyExists(Key);
            return keyExists;
        }
    }
}
