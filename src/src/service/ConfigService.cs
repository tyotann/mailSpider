using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SQLite;
using com.soeasystem.spider.src.utils;

namespace com.soeasystem.spider.src.service
{

    public class ConfigService
    {
        public static Hashtable configMap = null;

        public static DataTable show()
        {
            return SQLiteUtils.query("select comments, name, value from t_config where show_flag = 1");
        }

        public static DataTable export()
        {
            return SQLiteUtils.query("select comments, name, value from t_config where show_flag = 1");
        }

        public static void import(DataTable dt)
        {
            SQLiteConnection connection = null;
            SQLiteTransaction transaction = null;

            try
            {
                connection = SQLiteUtils.getConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                List<SQLiteParameter> paramList = new List<SQLiteParameter>();

                foreach (DataRow dr in dt.Rows)
                {
                    paramList.Add(new SQLiteParameter("@name", dr["name"]));
                    paramList.Add(new SQLiteParameter("@value", dr["value"]));
                    SQLiteUtils.execute("update t_config set value = @value where name = @name", paramList, connection);
                    configMap[dr["name"]] = dr["value"];
                }
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public static String get(String name)
        {
            if (configMap == null)
            {
                configMap = new Hashtable();

                DataTable dt = SQLiteUtils.query("select name, value from t_config");

                foreach (DataRow dw in dt.Rows)
                {
                    configMap.Add(Convert.ToString(dw["name"]), Convert.ToString(dw["value"]));
                }
            }

            return (String)configMap[name];
        }

        public static void update(String name, String value)
        {
            lock (configMap)
            {
                List<SQLiteParameter> paramList = new List<SQLiteParameter>();
                paramList.Add(new SQLiteParameter("@name", name));
                paramList.Add(new SQLiteParameter("@value", value));
                SQLiteUtils.execute("update t_config set value = @value where name = @name", paramList);
                configMap[name] = value;
            }
        }
    }
}
