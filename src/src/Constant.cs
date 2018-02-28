using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.soeasystem.spider.src
{
    public class Constant
    {

        public enum ParseStatus
        {
            WAIT, START, EXCEPTION, SUCCESS
        }

        public enum MailSendType
        {
            ALL, UN_SEND, SENDED, EXCEPTION, SUCCESS
        }

        public enum RunStatus
        {
            RUNING, STOPING, STOP
        }

    }


}
