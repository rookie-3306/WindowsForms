using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WindowsFormsApp8
{
    class DatabaseHelper
    {
        //设置初始的连接字符串
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SuperMarket_Database"].ConnectionString);
        /// <summary>
        /// 获取SQL连接对象
        /// </summary>
        /// <returns>SQL连接对象</returns>
        public static SqlConnection GetSqlConnection()
        {
            return conn;
        }

        #region 各种基本操作
        public static void OpenGetSqlConnection()
        {
            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public static SqlCommand GetSqlCommand(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd;
        }

        public static SqlDataAdapter GetSqlDataAdapter(string sql)
        {
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            return sda;
        }

        public static DataSet GetDataSet(string sql)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter temp_sda = new SqlDataAdapter(sql, conn);
            temp_sda.Fill(ds, "temp");
            return ds;
        }

        public static SqlDataReader GetSqlDataReader(string sql)
        {
            SqlCommand cmd = GetSqlCommand(sql);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public static SqlDataReader GetSqlDataReader(string sql, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(parameters);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public static int GetExecuteSelectSQLLine(string sql)
        {
            SqlCommand cmd = GetSqlCommand(sql);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count;
        }

        public static int GetExecuteSelectSQLLine(string sql, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(parameters);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count;
        }

        public static int ExecuteNonQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteNonQuery();
        }

        public static int ExecuteNonQuery(string sql, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery();
        }

        public static object ExecuteScalar(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteScalar();
        }

        public static object ExecuteScalar(string sql, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteScalar();
        }
        #endregion

        #region CUDR操作
        public static SqlDataReader ExecuteSelect(string sql)
        {
            SqlDataReader dr = GetSqlDataReader(sql);
            return dr;
        }
        public static SqlDataReader ExecuteSelect(string sql, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(parameters);
            SqlDataReader dr = GetSqlDataReader(sql, parameters);
            return dr;
        }

        public static int ExecuteUpdate(string sql)
        {
            SqlCommand cmd = GetSqlCommand(sql);
            return cmd.ExecuteNonQuery();
        }
        public static int ExecuteUpdate(string sql, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery();
        }

        public static int ExecuteDelete(string sql)
        {
            return ExecuteUpdate(sql);
        }
        public static int ExecuteDelete(string sql, SqlParameter[] parameters)
        {
            return ExecuteUpdate(sql, parameters);
        }

        public static int ExecuteInsert(string sql)
        {
            return ExecuteUpdate(sql);
        }
        public static int ExecuteInsert(string sql, SqlParameter[] parameters)
        {
            return ExecuteUpdate(sql, parameters);
        }
        #endregion
    }
}
