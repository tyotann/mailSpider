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
    public class AolSearch : EngineNormal
    {
        public override String getPageUrl(String perHTML, EngineEntity entity, String searchKey)
        {
            String result = entity.Url;
            result = result.Replace("${searchKey}", searchKey);

            if (entity.PageCnt > 0)
            {
                result += "&page=" + Convert.ToString(entity.PageCnt);
            }

            return result;
        }

    }
}
