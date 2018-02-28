using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.soeasystem.spider.src.entity;
using System.Net;
using com.soeasystem.spider.src.utils;
using com.soeasystem.spider.src.form;
using System.Drawing;
using System.Web;
using com.soeasystem.spider.src.service;

namespace com.soeasystem.spider.src.searchEngine
{
    public class YahooSearch : EngineNormal
    {
        public override Boolean isEndPage(String html, EngineEntity entity)
        {
            return (html.IndexOf("Try the suggestions below or type a new query above") > 0);
        }

        public override Int32 addUrl(String[] linkArray, EngineEntity entity)
        {
            Int32 addCnt = 0;

            foreach (String link in linkArray)
            {
                if (link.Length < 4000 && link.IndexOf("/r/_ylt=") > 0)
                {
                    String rlink = HttpUtility.UrlDecode(link.Substring(link.IndexOf("**") + 2));

                    if (rlink.IndexOf(entity.EngineName) == -1)
                    {
                        addCnt += entity.addUrl(rlink) ? 1 : 0;
                    }
                }
            }
            return addCnt;
        }
    }
}
