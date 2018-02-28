using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.soeasystem.spider.src.entity;
using System.Net;

namespace com.soeasystem.spider.src.searchEngine
{
    public interface IEngine
    {
        String getPageUrl(String perHTML, EngineEntity entity, String searchKey);

        Boolean isEndPage(String html, EngineEntity entity);

        Int32 addUrl(String[] linkArray, EngineEntity entity);

        void error(EngineEntity entity, Exception ex);
    }
}
