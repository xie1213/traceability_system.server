using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System;
using Traceability_System.DTO;

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

            db.HashSet(hashKey, field, value);
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
                return null;
            }
            catch (Exception ex)
            {
                // 处理其他异常
                Console.WriteLine("发生异常：" + ex.Message);
                return null;
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

        public void DeleteHash(string hashKey, int dbnum = 7)
        {
            db = redis.GetDatabase(dbnum);
            bool hashExists = db.KeyExists(hashKey) && db.KeyType(hashKey) == RedisType.Hash;
            if (hashExists)
            {
                db.KeyDelete(hashKey);
                //Console.WriteLine($"存在{hashKey} 已删除");
            }
        }

    }
}
