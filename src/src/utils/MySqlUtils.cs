using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;

namespace com.soeasystem.spider.src.utils
{
    public class MySqlUtils
    {
        private static String connectionString = "server=r8516tyotann.mysql.aliyun.com;user id=r9228tyotann; password=r9228tyotann; database=r9228tyotann; pooling=false;charset=utf8";

        private static String currentDbPath = Environment.CurrentDirectory + "\\mailSpider.db";


        /**

        public static MySqlConnection getConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }


        public static DataTable query(string sql)
        {
            return MySqlUtils.query(sql, null, null);
        }

        public static DataTable query(string sql, MySqlConnection connection)
        {
            return MySqlUtils.query(sql, null, connection);
        }

        public static DataTable query(string sql, List<MySqlParameter> paramList)
        {
            return MySqlUtils.query(sql, paramList, null);

        }

        public static DataTable query(string sql, List<MySqlParameter> paramList, MySqlConnection connection)
        {
            DataTable dt = new DataTable();

            MySqlDataReader reader = null;

            bool createConn = false;

            try
            {
                if (connection == null)
                {
                    connection = getConnection();
                    connection.Open();
                    createConn = true;
                }

                MySqlCommand command = new MySqlCommand(sql, connection);

                if (paramList != null && paramList.Count > 0)
                {
                    foreach (MySqlParameter param in paramList)
                    {
                        command.Parameters.Add(param);
                    }
                }

                reader = command.ExecuteReader();
                dt.Load(reader);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (createConn && connection != null)
                {
                    connection.Close();
                }
            }

            return dt;
        }


        /**
        public static int execute(string sql)
        {
            return SQLiteUtils.execute(sql, null, null);
        }

        public static int execute(string sql, SQLiteConnection connection)
        {
            return SQLiteUtils.execute(sql, null, connection);
        }

        public static int execute(string sql, List<SQLiteParameter> paramList)
        {
            return SQLiteUtils.execute(sql, paramList, null);
        }

        public static int execute(string sql, List<SQLiteParameter> paramList, SQLiteConnection connection)
        {
            if (connection == null)
            {
                connection = getDefaultConnection();
            }

            SQLiteCommand command = new SQLiteCommand(sql, connection);

            if (paramList != null && paramList.Count > 0)
            {
                foreach (SQLiteParameter param in paramList)
                {
                    command.Parameters.Add(param);
                }
            }

            lock (locking)
            {
                return command.ExecuteNonQuery();
            }

        }
         * */
    }
}
