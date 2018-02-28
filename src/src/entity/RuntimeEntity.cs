using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Amib.Threading;
using com.soeasystem.spider.src.utils;
using com.soeasystem.spider.src.service;
using Amib.Threading.Internal;
using System.Threading;

namespace com.soeasystem.spider.src.entity
{
    public class RuntimeEntity
    {
        public RuntimeEntity(String baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        private String baseUrl = null;

        public String BaseUrl
        {
            get { return baseUrl; }
            set { baseUrl = value; }
        }

        private Hashtable waitQueue = new Hashtable();

        public Hashtable WaitQueue
        {
            get { return waitQueue; }
            set { waitQueue = value; }
        }

        private Hashtable startQueue = new Hashtable();

        public Hashtable StartQueue
        {
            get { return startQueue; }
            set { startQueue = value; }
        }

        private Hashtable successQueue = new Hashtable();

        public Hashtable SuccessQueue
        {
            get { return successQueue; }
            set { successQueue = value; }
        }

        private Hashtable errorQueue = new Hashtable();

        public Hashtable ErrorQueue
        {
            get { return errorQueue; }
            set { errorQueue = value; }
        }

        private WorkItemPriority priority = WorkItemPriority.BelowNormal;

        public WorkItemPriority Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        private Constant.RunStatus runStatus = Constant.RunStatus.RUNING;

        public Constant.RunStatus RunStatus
        {
            get { return runStatus; }
            set { runStatus = value; }
        }

        //所有mail数
        private Int32 allMailCnt = 0;

        public Int32 AllMailCnt
        {
            get { return allMailCnt; }
            set { allMailCnt = value; }
        }

        //记录mail数
        private Int32 addMailCnt = 0;

        public Int32 AddMailCnt
        {
            get { return addMailCnt; }
            set { addMailCnt = value; }
        }

        private IWorkItemsGroup workItemsGroup = ThreadPoolEx.getWorkItemsGroup();

        public IWorkItemsGroup WorkItemsGroup
        {
            get { return workItemsGroup; }
        }

        public Int32 getWaitQueueCnt()
        {
            return waitQueue == null ? 0 : waitQueue.Count;
        }


        public Int32 getStartQueueCnt()
        {
            return startQueue == null ? 0 : startQueue.Count;
        }

        private Int32 successQueueCnt = 0;

        public Int32 getSuccessQueueCnt()
        {
            return successQueue == null ? successQueueCnt : successQueue.Count;
        }

        private Int32 errorQueueCnt = 0;

        public Int32 getErrorQueueCnt()
        {
            return errorQueue == null ? errorQueueCnt : errorQueue.Count;
        }

        private static Int32 maxMailCnt = Convert.ToInt32(ConfigService.get("parse.rule.sameSiteMaxMailCnt"));

        public Boolean addMainCnt()
        {
            Boolean result = true;

            if (!Constant.RunStatus.STOP.Equals(this.runStatus))
            {
                if (maxMailCnt > 0 && ++addMailCnt >= maxMailCnt)
                {
                    result = false;
                    this.stop(true);
                }
            }

            allMailCnt++;

            return result;
        }

        private object _lock = new object();

        public void stop(Boolean abort)
        {
            if (this.RunStatus != Constant.RunStatus.STOP)
            {
                lock (_lock)
                {
                    if (this.RunStatus != Constant.RunStatus.STOP)
                    {
                        this.RunStatus = Constant.RunStatus.STOP;

                        this.waitQueue = null;
                        this.startQueue = null;
                        this.successQueueCnt = successQueue.Count;
                        this.successQueue = null;
                        this.errorQueueCnt = errorQueue.Count;
                        this.errorQueue = null;

                        IWorkItemsGroup oldWorkItemsGroup = this.workItemsGroup;
                        this.workItemsGroup = null;

                        Thread mailThread = new Thread(new ThreadStart(delegate
                        {
                            try
                            {
                                oldWorkItemsGroup.Cancel(false);
                                oldWorkItemsGroup = null;
                            }
                            catch { }
                        }));
                        mailThread.Name = "stop workItemsGroup thread";
                        mailThread.IsBackground = false;
                        mailThread.Priority = ThreadPriority.Normal;
                        mailThread.Start();
                    }
                }
            }
        }

        public Boolean reparse()
        {
            lock (_lock)
            {
                Boolean result = true;

                if (!Constant.RunStatus.STOP.Equals(this.RunStatus))
                {
                    result = false;
                }
                else
                {
                    this.workItemsGroup = ThreadPoolEx.getWorkItemsGroup();

                    this.WaitQueue = new Hashtable();
                    this.StartQueue = new Hashtable();
                    this.successQueue = new Hashtable();
                    this.errorQueue = new Hashtable();

                    this.RunStatus = Constant.RunStatus.RUNING;
                }

                return result;
            }
        }

    }
}
