using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Traceability_System.DTO;
using Traceability_System.Utility;
using DataTable = System.Data.DataTable;

namespace Appraisal_System.Utility
{
    public class SqlHelper
    {
        public static string ConStr { get; set; } = "";

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

                    throw e;
                }
               
            }
        }

        //執行增刪改的方法
        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] sqlParameters)
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
        //執行查詢返回單個值方法
        public static object ExecuteScalar(string cmdText, params SqlParameter[] sqlParameters)
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

        public static Boolean AddTable(DataTable dt, string tableName)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConStr))
            {
                try
                {
                    sqlCon.Open();
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlCon))
                    {
                        bulkCopy.DestinationTableName = tableName;

                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            bulkCopy.ColumnMappings.Add(dt.Columns[i].Caption.ToString(), dt.Columns[i].Caption.ToString());
                        }
                        bulkCopy.WriteToServer(dt);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    sqlCon.Close();
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

                }
                return columnName;
            }



        }


        //封装一个返回DataTable的方法
        public static DataTable ExecuteDataTable(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, ConStr))
            {
                adapter.SelectCommand.CommandType = cmdType;
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);
            }

            return dt;
        }

        //批量添加
        //public static bool BatchAddTable(List<string> valueList, List<string> colNameList, string tableName, string strtime)
        public static bool BatchAddTable(RenewParameter renew)
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

            try
            {
                // 5. 执行批量插入 
                using var bulkCopy = new SqlBulkCopy(conn);
                bulkCopy.DestinationTableName =renew.tableName;
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
                return true;
            }
            catch (Exception e)
            {
                
                //Console.WriteLine(e);
                
                throw;
                // false;   
            }
            conn.Close();

        }

        //public static bool BuildUpdateQuery(string tableName, List<string> colNameList, List<string> valueList, List<string> strings, string strTime)
        public static int BuildUpdateQuery(RenewParameter renewParameter)
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
                        setClauses.Add($"{renewParameter.colNameList[i]}  = ' {renewParameter.renewNum+1}'");
                    }
                }
                // 构建完整的更新语句
                string updateQuery = $"UPDATE {renewParameter.tableName} SET {string.Join(", ", setClauses)} WHERE {renewParameter.specify[0]} = '{renewParameter.specify[1]}'  ;";
                return ExecuteNonQuery(updateQuery);
                
            }
            catch (Exception e)
            {

                throw e;
            }
          
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

