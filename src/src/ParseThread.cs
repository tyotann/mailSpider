using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using com.soeasystem.spider.src.utils;
using System.Collections;
using com.soeasystem.spider.src;
using System.Threading;
using log4net;
using Amib.Threading;
using com.soeasystem.spider.src.service;
using System.Diagnostics;
using System.Net.Sockets;

namespace com.soeasystem.spider
{
    public class ParseThread
    {
        private static ILog logger = LogManager.GetLogger("ParseThread");

        private static String[] excludeArray = ConfigService.get("parse.unparseSuffix").ToLower().Replace("\"", "").Split(',');

        private static ParseService parseService = new ParseService();

        private static RuntimeService runtimeSerivce = new RuntimeService();

        public static Object run(Object o)
        {
            try
            {
                Hashtable param = o as Hashtable;

                String url = Convert.ToString(param["url"]);

                try
                {
                    String keyword = (String)param["type"];

                    parseService.changeStatus(url, Constant.ParseStatus.START);

                    //如果RUNTIME的状态为STOP，则不再解析
                    if (!Constant.RunStatus.STOP.Equals(runtimeSerivce.get(url).RunStatus))
                    {
                        String html = WebClientUtils.getHTML(url, Convert.ToInt32(ConfigService.get("parse.request.timeout")) * 1000);

                        if (!"".Equals(html))
                        {
                            spiderURL(html, url, keyword);
                            spiderMail(html, keyword, url);
                        }
                    }

                    parseService.changeStatus(url, Constant.ParseStatus.SUCCESS);
                }
                catch
                {
                    parseService.changeStatus(url, Constant.ParseStatus.EXCEPTION);
                }
            }
            catch (Exception ex) { logger.Error(ex.Message, ex); }

            return null;
        }



        private static void spiderMail(String html, String keyword, String url)
        {
            MailService mailService = new MailService();

            String[] mailArray = CommonUtils.getHTMLMailArray(html);
            foreach (String mail in mailArray)
            {
                mailService.add(url, mail.Trim(), keyword);
            }
        }

        private static void spiderURL(String html, String url, String type)
        {
            String baseURI = CommonUtils.getBaseURL(url);
            String[] linkArray = CommonUtils.getHTMLinkArray(url, html);

            foreach (String link in linkArray)
            {
                if (link.Length < 256 && link.StartsWith(baseURI) && !isExcludeURL(link.ToLower()))
                {
                    parseService.add(link, type);
                }
            }
        }

        /**
         * 操他大爷的,用正则表达式测试下来反而慢,日
         * */
        private static Boolean isExcludeURL(String link)
        {
            Boolean isExclude = false;

            foreach (String exclude in excludeArray)
            {
                if (link.EndsWith(exclude.Trim()) || link.IndexOf(exclude.Trim() + "?") > 0)
                {
                    isExclude = true;
                    break;
                }
            }

            return isExclude;
        }

    }
}

