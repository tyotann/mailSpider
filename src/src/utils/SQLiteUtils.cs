using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace com.soeasystem.spider.src.utils
{
    public class SQLiteUtils
    {
        private static Object locking = new Object();

        private static String currentDbPath = Environment.CurrentDirectory + "\\mailSpider.db";

        private static SQLiteConnection _defaultConnection = null;

        public static SQLiteConnection getConnection()
        {
            SQLiteConnectionStringBuilder connstr = new SQLiteConnectionStringBuilder();
            connstr.DataSource = currentDbPath;
            connstr.FailIfMissing = false;
            connstr.Pooling = true;
            connstr.Password = "#soeasystem@mailspider#nb";

            SQLiteConnection connection = new SQLiteConnection(connstr.ToString());
            return connection;
        }

        private static object _lock = new object();

        private static SQLiteConnection getDefaultConnection()
        {
            if (_defaultConnection == null)
            {
                lock (_lock)
                {
                    if (_defaultConnection == null)
                    {
                        _defaultConnection = SQLiteUtils.getConnection();
                        _defaultConnection.Open();
                    }
                }
            }

            return _defaultConnection;
        }


        public static DataTable query(string sql)
        {
            return SQLiteUtils.query(sql, null, null);
        }

        public static DataTable query(string sql, SQLiteConnection connection)
        {
            return SQLiteUtils.query(sql, null, connection);
        }

        public static DataTable query(string sql, List<SQLiteParameter> paramList)
        {
            return SQLiteUtils.query(sql, paramList, null);
        }

        public static DataTable query(string sql, List<SQLiteParameter> paramList, SQLiteConnection connection)
        {
            DataTable dt = new DataTable();

            SQLiteDataReader reader = null;

            try
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
                    reader = command.ExecuteReader();
                    dt.Load(reader);
                }

            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return dt;
        }


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
    }
}
