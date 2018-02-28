using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using com.soeasystem.spider.src.utils;
using Amib.Threading;
using com.soeasystem.spider.src.entity;
using System.Windows.Forms;

namespace com.soeasystem.spider.src.service
{
    public class RuntimeService
    {
        private static Hashtable runtimeMap = new Hashtable();

        public RuntimeEntity get(String url)
        {
            return (RuntimeEntity)runtimeMap[CommonUtils.getBaseURL(url)];
        }

        public Hashtable getAll()
        {
            return runtimeMap;
        }

        public RuntimeEntity add(String url)
        {
            url = CommonUtils.getBaseURL(url);

            RuntimeEntity runtime = new RuntimeEntity(url);

            runtimeMap.Add(url, runtime);

            return runtime;
        }
    }
}
