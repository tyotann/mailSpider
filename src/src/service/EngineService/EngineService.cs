using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.soeasystem.spider.src.searchEngine;
using com.soeasystem.spider.src.entity;
using com.soeasystem.spider.src.utils;
using System.Net;
using System.Threading;
using System.Web;
using System.Collections;

namespace com.soeasystem.spider.src.service
{
    public class EngineService
    {
        public static Object search(Object o)
        {
            try
            {
                Hashtable param = (Hashtable)o;

                EngineEntity engine = (EngineEntity)param["engine"];

                engine.Status = "处理中";

                String searchKey = HttpUtility.UrlEncode((String)param["searchKey"], Encoding.UTF8);

                IEngine search = engine.Search;

                Dictionary<String, String> urlMap = new Dictionary<String, String>();

                Int32 timeout = Convert.ToInt32(ConfigService.get("parse.request.timeout")) * 1000;

                String html = String.Empty;

                Int32 unParseURL = 0;

                //出错50次算结束,连续5次没抓到邮箱算结束,大于设置最大邮箱数算结束
                while (!search.isEndPage(html, engine) && engine.PageCnt <= engine.MaxPageCnt && engine.ErrorCnt < 50 && unParseURL < 5)
                {
                    String url = search.getPageUrl(html, engine, searchKey);

                    try
                    {
                        html = WebClientUtils.getHTML(url, timeout);

                        if (!String.Empty.Equals(html))
                        {
                            if (search.addUrl(CommonUtils.getHTMLinkArray(url, html), engine) == 0)
                            {
                                unParseURL++;
                            }
                            else
                            {
                                unParseURL = 0;
                            }
                        }

                        engine.PageCnt = engine.PageCnt + 1;
                    }
                    catch (Exception ex)
                    {
                        engine.ErrorCnt = engine.ErrorCnt + 1;
                        search.error(engine, ex);
                        html = String.Empty;
                    }
                }

                engine.Status = "处理结束";

            }
            catch { }

            return null;
        }

    }
}
