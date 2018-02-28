using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.soeasystem.spider.src.searchEngine;
using com.soeasystem.spider.src.utils;
using System.ComponentModel;

namespace com.soeasystem.spider.src.entity
{
    public class EngineEntity : INotifyPropertyChanged
    {
        private static Dictionary<String, String> allUrlMap = new Dictionary<String, String>();

        public Dictionary<String, String> AllUrlMap
        {
            get { return allUrlMap; }
        }

        private Boolean selected = false;

        public Boolean Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        private Int32 errorCnt = 0;

        public Int32 ErrorCnt
        {
            get { return errorCnt; }
            set { errorCnt = value; }
        }

        //当前页数
        private Int32 pageCnt = 0;

        public Int32 PageCnt
        {
            get { return pageCnt; }
            set { pageCnt = value; }
        }

        private String engineName;

        public String EngineName
        {
            get { return engineName; }
            set { engineName = value; }
        }

        private String url;

        public String Url
        {
            get { return url; }
            set { url = value; }
        }

        //每页显示记录条数
        private Int32 pageSize = 10;

        public Int32 PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        //最大页数
        private Int32 maxPageCnt = 1000;

        public Int32 MaxPageCnt
        {
            get { return maxPageCnt; }
            set { maxPageCnt = value; }
        }

        //搜索实现
        private IEngine search;

        public IEngine Search
        {
            get { return search; }
            set { search = value; }
        }

        private List<String> urlList = new List<string>();

        public Boolean addUrl(String url)
        {
            Boolean added = false;

            String baseUrl = CommonUtils.getBaseURL(url);

            lock (allUrlMap)
            {
                if (!allUrlMap.ContainsKey(baseUrl))
                {
                    urlList.Add(url);
                    added = true;
                    allUrlMap.Add(baseUrl, url);
                }
            }

            allUrlCnt++;

            NotifyPropertyChanged("AllUrlCnt");

            return added;
        }

        public List<String> getUrlList()
        {
            return urlList;
        }

        //所有网站数
        private Int32 allUrlCnt = 0;

        public Int32 AllUrlCnt
        {
            get { return allUrlCnt; }
        }

        //去重后网站数
        public Int32 UrlCnt
        {
            get { return urlList.Count; }
        }

        public Int32 Progress
        {
            get { return "处理结束".Equals(status) ? 100 : (pageCnt * 100 / maxPageCnt); }
        }

        private String status = "未处理";

        public String Status
        {
            get { return status; }
            set
            {
                status = value;
                NotifyPropertyChanged("Status");
            }
        }

        private String nextString;

        public String NextString
        {
            get { return nextString; }
            set { nextString = value; }
        }

        private String preString = null;

        public String PreString
        {
            get { return preString; }
            set { preString = value; }
        }

        #region INotifyPropertyChanged 成员

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion
    }
}
