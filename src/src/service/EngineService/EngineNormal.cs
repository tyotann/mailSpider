using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.soeasystem.spider.src.searchEngine;
using com.soeasystem.spider.src.entity;
using com.soeasystem.spider.src.utils;

namespace com.soeasystem.spider.src.service
{
    public class EngineNormal : IEngine
    {

        public virtual String getPageUrl(String perHTML, EngineEntity entity, String searchKey)
        {
            String result = entity.Url;
            result = result.Replace("${searchKey}", searchKey);
            result = result.Replace("${pageStart}", Convert.ToString(entity.PageCnt * entity.PageSize));
            result = result.Replace("${pageCnt}", Convert.ToString(entity.PageCnt));

            return result;
        }

        public virtual Boolean isEndPage(String html, EngineEntity entity)
        {
            Boolean result = false;

            if (!"".Equals(html))
            {
                if (entity.PreString == null || "".Equals(entity.PreString))
                {
                    result = (html.IndexOf(entity.NextString) == -1);
                }
                else
                {
                    result = (html.IndexOf(entity.PreString) > 0 && html.IndexOf(entity.NextString) == -1);
                }
            }

            return result;
        }

        public virtual Int32 addUrl(String[] linkArray, EngineEntity entity)
        {
            Int32 addCnt = 0;
            foreach (String link in linkArray)
            {
                if (link.Length < 2000 && link.IndexOf(entity.EngineName) == -1)
                {
                    addCnt += entity.addUrl(link) ? 1 : 0;
                }
            }
            return addCnt;
        }

        public virtual void error(EngineEntity entity, Exception ex)
        {
        }
    }
}
