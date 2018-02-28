using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amib.Threading;
using System.Collections;

namespace com.soeasystem.spider.src.entity
{
    public class ParseEntity
    {
        private String url;

        public String Url
        {
            get { return url; }
            set { url = value; }
        }

        private String type;

        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        public ParseEntity(String url, String type)
        {
            this.url = url;
            this.type = type;
        }
    }
}
