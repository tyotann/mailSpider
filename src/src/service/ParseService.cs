using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amib.Threading;
using System.Collections;
using com.soeasystem.spider.src.utils;
using com.soeasystem.spider.src.entity;
using System.Threading;

namespace com.soeasystem.spider.src.service
{
    public class ParseService
    {
        private static RuntimeService runtimeService = new RuntimeService();

        public ParseEntity get(String url)
        {
            RuntimeEntity runtime = runtimeService.get(url);

            ParseEntity result = null;

            if (runtime != null)
            {
                if (runtime.WaitQueue[url] != null)
                {
                    result = (ParseEntity)runtime.WaitQueue[url];
                }
                else if (runtime.StartQueue[url] != null)
                {
                    result = (ParseEntity)runtime.StartQueue[url];
                }
                else if (runtime.SuccessQueue[url] != null)
                {
                    result = (ParseEntity)runtime.SuccessQueue[url];
                }
                else if (runtime.ErrorQueue[url] != null)
                {
                    result = (ParseEntity)runtime.ErrorQueue[url];
                }
            }

            return result;
        }

        public void add(String url, String type)
        {
            url = url.Replace("\r\n", "").Replace(Environment.NewLine, "").Trim();

            RuntimeEntity runtime = runtimeService.get(url);

            if (runtime == null)
            {
                runtime = runtimeService.add(url);
            }

            if (Constant.RunStatus.RUNING.Equals(runtime.RunStatus))
            {
                try
                {
                    if (get(url) == null)
                    {
                        runtime.WaitQueue.Add(url, new ParseEntity(url, type));

                        Hashtable param = new Hashtable();
                        param.Add("url", url);
                        param.Add("type", type);

                        lock (runtime.WorkItemsGroup)
                        {
                            ThreadPoolEx.add(runtime.WorkItemsGroup, new WorkItemCallback(ParseThread.run), param, runtime.Priority);
                        }
                    }
                }
                catch { }

                //等待解析数超过系统设定,则优先级降低
                if (!WorkItemPriority.Lowest.Equals(runtime.Priority) && (runtime.WaitQueue.Count + runtime.StartQueue.Count + runtime.SuccessQueue.Count) > Convert.ToInt32(ConfigService.get("parse.lowParseCnt")))
                {
                    runtime.Priority = WorkItemPriority.Lowest;
                }

                //已解析数超过系统设定,则停止
                if (runtime.WaitQueue.Count + runtime.StartQueue.Count + runtime.SuccessQueue.Count + runtime.ErrorQueue.Count >= Convert.ToInt32(ConfigService.get("parse.rule.maxParseCnt")))
                {
                    runtime.RunStatus = Constant.RunStatus.STOPING;
                }
            }
        }

        public void changeStatus(String url, Constant.ParseStatus status)
        {
            RuntimeEntity runtime = runtimeService.get(url);

            if (!Constant.RunStatus.STOP.Equals(runtime.RunStatus))
            {
                if (status.Equals(Constant.ParseStatus.START))
                {
                    Object parse = runtime.WaitQueue[url];
                    runtime.StartQueue.Add(url, parse);
                    runtime.WaitQueue.Remove(url);
                }
                else if (status.Equals(Constant.ParseStatus.SUCCESS))
                {
                    Object parse = runtime.StartQueue[url];
                    runtime.SuccessQueue.Add(url, parse);
                    runtime.StartQueue.Remove(url);
                }
                else if (status.Equals(Constant.ParseStatus.EXCEPTION))
                {
                    Object parse = runtime.StartQueue[url];
                    runtime.ErrorQueue.Add(url, parse);
                    runtime.StartQueue.Remove(url);
                }

                //等待队列与执行队列为空的话,整个站点停止解析
                if (runtime.WaitQueue.Count == 0 && runtime.StartQueue.Count == 0)
                {
                    runtime.stop(true);
                }
            }

        }



    }
}
