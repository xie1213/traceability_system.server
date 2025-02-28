using Microsoft.Data.SqlClient;
using System.Data;
using Traceability_System.DTO;
using Traceability_System.Utility;
using DataTable = System.Data.DataTable;

namespace Appraisal_System.Utility
{
    public class SqlHelper
    {
        public static string ConStr { get; set; } = "";

        private static readonly LogHelper logHelper = new LogHelper();
        //public SqlHelper()
        //{
        //    ConStr = "Data Source=.;uid=sa;pwd=123456;Datebase:966KData;";
        //}
        //執行查詢，返回DataTable的方法
        public static DataTable ExecuteTable(string cmdText, params SqlParameter[] sqlParameters)
        {
            using (SqlConnection conn = new(ConStr))
            {

                conn.Open();
                try
                {
                    using (SqlCommand cmd = new(cmdText, conn))
                    {
                        if (sqlParameters != null)
                        {
                            cmd.Parameters.AddRange(sqlParameters);
                        }

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            sda.Fill(ds);
                            return ds.Tables[0];

                        }
                    }
                }
                catch (Exception e)
                {
                    //Console.WriteLine("查询出错" + e.Message);
                    logHelper.Warn("查询时出现错误" + e.Message);
                    throw;
                }

            }
        }

        public static async Task<DataTable> ExecuteTableAsync(string cmdText, int commandTimeout = 60, params SqlParameter[] sqlParameters)
        {
            int retries = 0;
            {
                try
                {
                    await using (SqlConnection conn = new SqlConnection(ConStr))
                    {
                        await conn.OpenAsync();
                        using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                        {
                            cmd.CommandTimeout = commandTimeout; // 设置命令超时时间
                            if (sqlParameters != null)
                            {
                                cmd.Parameters.AddRange(sqlParameters);
                            }

                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataSet ds = new DataSet();
                                sda.Fill(ds);
                                return ds.Tables[0];

                            }
                        }
                    }
                }

                catch (SqlException ex) when (ex.Number == -2) // -2是SQL Server的超时错误代码
                {
                    logHelper.Error($"ExecuteTableAsync错误: 超时错误{ex.Message}");
                }
                catch (Exception ex)
                {
                    logHelper.Error("ExecuteTableAsync错误" + ex.Message);
                    throw;
                }
            }
            return null;
        }


        //執行增刪改的方法
        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] sqlParameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConStr))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        if (sqlParameters != null)
                        {
                            cmd.Parameters.AddRange(sqlParameters);
                        }
                        conn.Open();

                        int rows = cmd.ExecuteNonQuery();
                        if (rows <= 0)
                        {
                            //throw new Exception("数据库操作失败");
                        }
                        return rows;
                    }
                }
            }
            catch (Exception ex)
            {
                logHelper.Warn("增删改时出现错误" + ex.Message);
                throw;
            }

        }

        public async Task<int> ExecuteNonQueryAsync(string cmdText, params SqlParameter[] sqlParameters)
        {
            try
            {
                await using (SqlConnection conn = new SqlConnection(ConStr))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        if (sqlParameters != null)
                        {
                            cmd.Parameters.AddRange(sqlParameters);
                        }
                        conn.Open();

                        int rows = cmd.ExecuteNonQuery();
                        if (rows <= 0)
                        {
                            //throw new Exception("数据库操作失败");
                        }
                        return rows;
                    }
                }
            }
            catch (Exception ex)
            {
                logHelper.Warn("ExecuteNonQueryAsync错误" + ex.Message);
                throw;
            }

        }
        //執行查詢返回單個值方法
        public static object ExecuteScalar(string cmdText, params SqlParameter[] sqlParameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConStr))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        if (sqlParameters != null)
                        {
                            cmd.Parameters.AddRange(sqlParameters);
                        }
                        conn.Open();

                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                logHelper.Warn("单个值出现错误" + ex.Message);
                throw;
            }

        }

        public static async Task<object> ExecuteScalarAsync(string cmdText, int commandTimeout = 60, params SqlParameter[] sqlParameters)
        {
            int retries = 0;
            try
            {
                await using (SqlConnection conn = new SqlConnection(ConStr))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.CommandTimeout = commandTimeout; // 设置命令超时时间
                        if (sqlParameters != null)
                        {
                            cmd.Parameters.AddRange(sqlParameters);
                        }

                        object result = await cmd.ExecuteScalarAsync();
                        return result;
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == -2) // -2是SQL Server的超时错误代码
            {
                logHelper.Warn("ExecuteScalarAsync错误: 超时错误，超过最大重试次数" + ex.Message);
            }
            catch (Exception ex)
            {
                logHelper.Warn("ExecuteScalarAsync错误" + ex.Message);
                throw;
            }

            return null;
        }

        //執行查詢返回多行多列的方法
        public static SqlDataReader ExecuteReader(string cmdText, params SqlParameter[] sqlParameters)
        {
            SqlConnection conn = new SqlConnection(ConStr);


            using (SqlCommand cmd = new SqlCommand(cmdText, conn))
            {
                if (sqlParameters != null)
                {
                    cmd.Parameters.AddRange(sqlParameters);
                }
                try
                {
                    conn.Open();

                    //System.Data.CommandBehavior.CloseConnection 這個枚舉表示在外部使用完SqlDataReader後，關閉Reader時，會自動將
                    // Connection關閉
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }

            }
        }

        public static List<string> GetSqlColumnName(string TableName)
        {

            List<string> columnName = new List<string>();
            string sql = "select syscolumns.name from syscolumns where id=object_id('" + TableName + "')" + " order by colid";
            // string sql = "select syscolumns.name from syscolumns where id=object_id('StandardData')";
            using (SqlConnection conn = new SqlConnection(ConStr))
            {
                try
                {
                    conn.Open();
                    SqlCommand com = new(sql, conn);
                    SqlDataReader dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        columnName.Add(dr[0].ToString());
                    }
                    dr.Close();
                    conn.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return columnName;
            }



        }
        //public static bool BatchAddTable(RenewParameter renew)
        //{
        //    try
        //    {
        //        if (renew.valueList.Count > renew.colNameList.Count)
        //        {
        //            return false;
        //        }

        //        using var conn = GetConnection();

        //        // 创建临时数据表
        //        var dt = new DataTable();
        //        foreach (string name in renew.colNameList)
        //        {
        //            dt.Columns.Add(name);
        //        }

        //        // 创建数据行并赋值
        //        DataRow newRow = dt.NewRow();
        //        for (int i = 0; i < renew.colNameList.Count; i++)
        //        {
        //            string colName = renew.colNameList[i];
        //            if (i < renew.valueList.Count)
        //            {
        //                // 处理空字符串或无效日期值
        //                if (dt.Columns[colName].DataType == typeof(DateTime) && string.IsNullOrWhiteSpace(renew.valueList[i]?.ToString()))
        //                {
        //                    newRow[colName] = DBNull.Value; // 将空字符串替换为 DBNull
        //                }
        //                else
        //                {
        //                    newRow[colName] = renew.valueList[i];
        //                }
        //            }
        //            else
        //            {
        //                // 如果 valueList 不足，填充默认值
        //                newRow[colName] = DBNull.Value;
        //            }
        //        }
        //        dt.Rows.Add(newRow);

        //        // 执行批量插入
        //        using var bulkCopy = new SqlBulkCopy(conn);
        //        bulkCopy.DestinationTableName = renew.tableName;

        //        // 映射列
        //        foreach (var colName in renew.colNameList)
        //        {
        //            bulkCopy.ColumnMappings.Add(colName, colName);
        //        }

        //        if (dt != null)
        //        {
        //            bulkCopy.WriteToServer(dt);
        //        }

        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        logHelper.Error("批量插入时失败: " + e.Message);
        //        return false; // 返回 false 表示操作失败
        //    }
        //}
        //批量添加
        //public static bool BatchAddTable(List<string> valueList, List<string> colNameList, string tableName, string strtime)
        public static bool BatchAddTable(RenewParameter renew)
        {

            try
            {

                if (renew.valueList.Count > renew.colNameList.Count)
                {

                    return false;
                }
                using var conn = GetConnection();


                // 2. 创建临时数据表 
                var dt = new DataTable();
                foreach (string name in renew.colNameList)
                {
                    //if (!name.Equals("Id"))
                    dt.Columns.Add(name);
                }
                Console.WriteLine();
                //string Alljson = JsonConvert.SerializeObject(dt);

                //RedisHelper.SetJsonData(renew.tableName, Alljson, 5);

                DataRow newRow = dt.NewRow();
                for (int i = 0; i < renew.colNameList.Count; i++)
                {
                    if (i == 0)
                    {
                        newRow[renew.colNameList[i]] = "";
                        i++;
                    }
                    if (i <= renew.valueList.Count)
                    {
                        newRow[renew.colNameList[i]] = renew.valueList[i - 1];
                    }
                    else
                    {
                        newRow[renew.colNameList[i]] = renew.renewTime;
                        i++;
                        newRow[renew.colNameList[i]] = renew.renewNum;
                    }

                }
                dt.Rows.Add(newRow);

                // 5. 执行批量插入 
                using var bulkCopy = new SqlBulkCopy(conn);
                bulkCopy.DestinationTableName = renew.tableName;
                //bulkCopy.WriteToServer(dt);
                //映射列
                foreach (var colName in renew.colNameList)
                {
                    bulkCopy.ColumnMappings.Add(colName, colName);
                }
                if (dt != null)
                {
                    bulkCopy.WriteToServer(dt);
                }
                // 写入数据

                conn.Close();
                return true;
            }
            catch (Exception e)
            {

                //Console.WriteLine(e);
                //Console.WriteLine("插入失败" + e.Message);
                logHelper.Error("批量插入时失败" + e.Message);
                throw;
                // false;   
            }

        }

        //public static bool BuildUpdateQuery(string tableName, List<string> colNameList, List<string> valueList, List<string> strings, string strTime)
        public async Task<int> BuildUpdateQuery(RenewParameter renewParameter)
        {
            ProofData proofData = new ProofData();
            //var chack = proofData.GetRedis(tableName, strings[1]);
            // 构建 SET 子句
            List<string> setClauses = new List<string>();
            try
            {
                for (int i = 0; i < renewParameter.colNameList.Count; i++)
                {
                    if (i == 0)
                    {
                        //newRow[colNameList[i]] = "";
                        i++;
                    }
                    if (i <= renewParameter.valueList.Count)
                    {
                        setClauses.Add($"{renewParameter.colNameList[i]} = '{renewParameter.valueList[i - 1]}'");
                    }
                    else
                    {
                        setClauses.Add($"{renewParameter.colNameList[i]} = '{renewParameter.renewTime}'");
                        i++;
                        setClauses.Add($"{renewParameter.colNameList[i]}  = ' {renewParameter.renewNum + 1}'");
                    }
                }
                // 构建完整的更新语句
                string updateQuery = $"UPDATE {renewParameter.tableName} SET {string.Join(", ", setClauses)} WHERE {renewParameter.specify[0]} = '{renewParameter.specify[1]}'  ;";


                return await ExecuteNonQueryWithRetryAsync(updateQuery);


            }
            catch (Exception e)
            {
                logHelper.Error("BuildUpdateQuery方法错误" + e.Message);
                throw;
            }

        }

        public async Task<int> ExecuteNonQueryWithRetryAsync(string cmdText, int maxRetries = 3, params SqlParameter[] sqlParameters)
        {
            int retries = 0;
            while (retries < maxRetries)
            {
                try
                {
                    await using (SqlConnection conn = new SqlConnection(ConStr))
                    {
                        using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                        {
                            if (sqlParameters != null)
                            {
                                cmd.Parameters.AddRange(sqlParameters);
                            }
                            cmd.CommandTimeout = 30; // 设置超时时间为30秒
                            await conn.OpenAsync();

                            int rows = await cmd.ExecuteNonQueryAsync();
                            if (rows <= 0)
                            {
                                logHelper.Error("更新失败");
                                //throw new Exception("数据库操作失败");
                            }
                            return rows;
                        }
                    }
                }
                catch (SqlException ex) when (ex.Number == 1205) // 1205是SQL Server的死锁错误代码
                {
                    retries++;
                    if (retries >= maxRetries)
                    {
                        logHelper.Warn("ExecuteNonQueryAsync错误: 超过最大重试次数" + ex.Message);
                        throw;
                    }
                    // 等待一段时间后重试
                    await Task.Delay(1000);
                }
                catch (Exception ex)
                {
                    logHelper.Warn("ExecuteNonQueryAsync错误" + ex.Message);
                    throw;
                }
            }
            return 0;
        }



        private static SqlConnection GetConnection()
        {
            // 从配置文件读取连接字符串
            //string connStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

            // 创建连接对象
            SqlConnection conn = new(ConStr);

            // 开启连接
            conn.Open();

            return conn;
        }


    }



}

