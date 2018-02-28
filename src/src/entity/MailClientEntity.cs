using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace com.soeasystem.spider.src.entity
{
    public class MailClientEntity
    {

        public MailClientEntity(SmtpClient smtpClient, String host, String mailAddress, String userName, Int32 id)
        {
            this.smtpClient = smtpClient;
            this.host = host;
            this.mailAddress = mailAddress;
            this.userName = userName;
            this.id = id;
        }

        private Int32 id;

        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private SmtpClient smtpClient;

        public SmtpClient SmtpClient
        {
            get { return smtpClient; }
            set { smtpClient = value; }
        }

        private String host;

        public String Host
        {
            get { return host; }
            set { host = value; }
        }

        private String mailAddress;

        public String MailAddress
        {
            get { return mailAddress; }
            set { mailAddress = value; }
        }

        private String userName;

        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private int errorCnt;

        public int ErrorCnt
        {
            get { return errorCnt; }
            set { errorCnt = value; }
        }

        private DateTime waitEndTime;

        public DateTime WaitEndTime
        {
            get { return waitEndTime; }
            set { waitEndTime = value; }
        }

    }
}
