namespace Traceability_System.Utility
{
    using StackExchange.Redis;
    using System;

    class Program
    {
        static void Main()
        {
            // 连接到 Redis 服务器
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");

            // 获取 Redis 数据库
            IDatabase db = redis.GetDatabase();

            // 存储 List 数据
            string key = "myList";
            db.ListRightPush(key, "item1");
            db.ListRightPush(key, "item2");
            db.ListRightPush(key, "item3");

            // 读取 List 数据
            var list = db.ListRange(key);

            // 输出 List 中的元素
            Console.WriteLine("List elements:");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            // 删除 List 数据
            db.KeyDelete(key);

            // 关闭 Redis 连接
            redis.Close();
        }
    }
}
