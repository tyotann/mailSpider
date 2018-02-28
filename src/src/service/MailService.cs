using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using com.soeasystem.spider.src.utils;
using System.Net.Mail;
using System.Collections;
using System.Windows.Forms;
using System.Threading;
using com.soeasystem.spider.src.entity;
using mailSpider;

namespace com.soeasystem.spider.src.service
{
    public class MailService
    {
        private static RuntimeService runtimeSerivce = new RuntimeService();

        public List<String> import(DataTable dataTable)
        {
            SQLiteConnection connection = null;
            SQLiteTransaction transaction = null;

            List<String> unImportList = new List<String>();

            try
            {
                connection = SQLiteUtils.getConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                foreach (DataRow dr in dataTable.Rows)
                {
                    List<SQLiteParameter> paramList = new List<SQLiteParameter>();
                    paramList.Add(new SQLiteParameter("@mail_address", Convert.ToString(dr["mail_address"])));
                    paramList.Add(new SQLiteParameter("@type", Convert.ToString(dr["type"])));

                    DataTable result = SQLiteUtils.query("select count(*) as cnt from t_mail_address where mail_address = @mail_address and type = @type", paramList, connection);
                    long rowCnt = (long)result.Rows[0]["cnt"];
                    if (rowCnt == 0)
                    {
                        String create_date = dr.Table.Columns["create_date"] == null ? "" : Convert.ToString(dr["create_date"]);
                        paramList.Add(new SQLiteParameter("@create_date", create_date));

                        String create_type = dr.Table.Columns["create_type"] == null ? "1" : Convert.ToString(dr["create_type"]);
                        paramList.Add(new SQLiteParameter("@create_type", create_type));

                        String send_cnt = dr.Table.Columns["send_cnt"] == null ? "0" : Convert.ToString(dr["send_cnt"]);
                        paramList.Add(new SQLiteParameter("@send_cnt", send_cnt));

                        String send_date = dr.Table.Columns["send_date"] == null ? "" : Convert.ToString(dr["send_date"]);
                        paramList.Add(new SQLiteParameter("@send_date", send_date));

                        SQLiteUtils.execute("insert into t_mail_address(mail_address, type, send_cnt, create_date, send_date, create_type) values(@mail_address, @type, @send_cnt, @create_date, @send_date, @create_type)", paramList, connection);
                    }
                    else
                    {
                        unImportList.Add(Convert.ToString(dr["mail_address"]));
                    }
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

            return unImportList;
        }

        public void add(String mailAddress, String type)
        {
            add(null, mailAddress, type);
        }

        public void add(String url, String mailAddress, String type)
        {
            mailAddress = mailAddress.ToLower().Trim();

            List<SQLiteParameter> paramList = new List<SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@mail_address", mailAddress));
            paramList.Add(new SQLiteParameter("@type", type));

            DataTable dt = SQLiteUtils.query("select count(mail_address) as cnt from t_mail_address where mail_address = @mail_address and type = @type", paramList);
            long rowCnt = (long)dt.Rows[0]["cnt"];

            if (rowCnt == 0)
            {
                //同站点mail解析超过系统设定数,则不再添加mail
                if (url == null || runtimeSerivce.get(url).addMainCnt())
                {
                    paramList.Add(new SQLiteParameter("@create_date", DateUtils.getSysDate()));
                    paramList.Add(new SQLiteParameter("@send_cnt", "0"));

                    //如果手动录入,则为1;自动抓取的为0
                    paramList.Add(new SQLiteParameter("@create_type", url != null ? "0" : "1"));
                    SQLiteUtils.execute("insert into t_mail_address(mail_address,send_cnt,type,create_date,create_type) values(@mail_address,@send_cnt,@type,@create_date,@create_type)", paramList);
                }
            }
        }

        public void update(String id, String mailAddress)
        {
            List<SQLiteParameter> paramList = new List<SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@id", id));
            paramList.Add(new SQLiteParameter("@mail_address", mailAddress.ToLower().Trim()));
            paramList.Add(new SQLiteParameter("@create_type", "1"));
            SQLiteUtils.execute("update t_mail_address set mail_address = @mail_address, create_type = @create_type where id = @id", paramList);
        }

        public void remove(String id)
        {
            List<SQLiteParameter> paramList = new List<SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@id", id));
            SQLiteUtils.execute("delete from t_mail_address where id = @id", paramList);
        }

        public DataTable get(String type, String createDate, Constant.MailSendType sendType, String mailAddressLike)
        {
            String sql = "select * from t_mail_address where 1=1 ";

            List<SQLiteParameter> paramList = new List<SQLiteParameter>();

            if (type != null && !"".Equals(type))
            {
                paramList.Add(new SQLiteParameter("@type", type));
                sql += "and type = @type ";
            }
            if (createDate != null && !"".Equals(createDate))
            {
                paramList.Add(new SQLiteParameter("@create_date", createDate + "%"));
                sql += "and create_date like @create_date ";
            }

            if (Constant.MailSendType.SENDED.Equals(sendType))
            {
                sql += "and send_cnt > 0 ";
            }
            else if (Constant.MailSendType.UN_SEND.Equals(sendType))
            {
                sql += "and send_cnt = 0 ";
            }

            if (mailAddressLike != null && !"".Equals(mailAddressLike))
            {
                paramList.Add(new SQLiteParameter("@mail_address", "%" + mailAddressLike + "%"));
                sql += "and mail_address like @mail_address ";
            }

            sql += " order by create_date";

            return SQLiteUtils.query(sql, paramList);
        }

        public DataTable getStatistical(Constant.MailSendType sendType)
        {
            String sql = "select type,substr(create_date,1,10) as create_date,count(1) as num from t_mail_address where 1=1 ";
            if (Constant.MailSendType.SENDED.Equals(sendType))
            {
                sql += "and send_cnt > 0 ";
            }
            else if (Constant.MailSendType.UN_SEND.Equals(sendType))
            {
                sql += "and send_cnt = 0 ";
            }
            sql += "group by type,2 order by 1,2 desc";

            return SQLiteUtils.query(sql);
        }

    }
}
