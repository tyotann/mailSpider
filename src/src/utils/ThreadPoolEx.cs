using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amib.Threading;
using System.Collections;
using System.Threading;
using Amib.Threading.Internal;
using com.soeasystem.spider.src.service;

namespace com.soeasystem.spider.src.utils
{
    public class ThreadPoolEx
    {
        private static SmartThreadPool threadPool = null;

        private static Int32 threadCntPerSite = Convert.ToInt32(ConfigService.get("parse.rule.threadCntPerSite"));

        public static void maxThread(int maxThead)
        {
            threadPool.MaxThreads = maxThead;
        }

        public static void init()
        {
            STPStartInfo stpStartInfo = new STPStartInfo();
            stpStartInfo.MaxWorkerThreads = Convert.ToInt32(ConfigService.get("thread.maxCnt"));
            stpStartInfo.MinWorkerThreads = 0;
            stpStartInfo.ThreadPriority = ThreadPriority.BelowNormal;
            stpStartInfo.CallToPostExecute = CallToPostExecute.Never;

            threadPool = new SmartThreadPool(stpStartInfo);
        }

        public static IWorkItemsGroup getWorkItemsGroup()
        {
            return threadPool.CreateWorkItemsGroup(threadCntPerSite);
        }

        public static IWorkItemsGroup getWorkItemsGroup(int concurrency)
        {
            return threadPool.CreateWorkItemsGroup(concurrency);
        }

        public static void destory()
        {
            threadPool.Dispose();
        }

        public static IWorkItemResult add(IWorkItemsGroup workItemsGroup, WorkItemCallback callback, Hashtable param, WorkItemPriority priority)
        {
            return workItemsGroup.QueueWorkItem(callback, param, priority);
        }

        public static Boolean IsIdle()
        {
            return threadPool.IsIdle;
        }


    }
}
