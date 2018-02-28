using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.soeasystem.spider.src.entity;
using com.soeasystem.spider.src.searchEngine;
using com.soeasystem.spider.src.utils;
using Amib.Threading;
using System.Collections;
using com.soeasystem.spider.src.service;
using DevExpress.Data;

namespace com.soeasystem.spider.src.form
{
    public partial class URLEngineForm : DevExpress.XtraEditors.XtraForm
    {
        private static IWorkItemsGroup workItemsGroup = null;

        private static BindingList<EngineEntity> engineList = new BindingList<EngineEntity>();

        private static ParseService parseService = new ParseService();

        public URLEngineForm()
        {
            InitializeComponent();

            //google
            EngineEntity google = new EngineEntity();
            google.EngineName = "google";
            google.Search = new GoogleSearch();
            google.Url = "http://www.google.com.hk/search?q=${searchKey}&start=${pageStart}&hl=zh-CN";
            google.PageSize = 10;
            google.MaxPageCnt = 100;
            engineList.Add(google);

            //yahoo
            EngineEntity yahoo = new EngineEntity();
            yahoo.EngineName = "yahoo";
            yahoo.Search = new YahooSearch();
            yahoo.Url = "http://search.yahoo.com/search?p=${searchKey}&b=${pageStart}";
            yahoo.PageSize = 10;
            yahoo.MaxPageCnt = 100;
            engineList.Add(yahoo);

            //ask.com
            EngineEntity ask = new EngineEntity();
            ask.EngineName = "ask.com";
            ask.Search = new EngineNormal();
            ask.Url = "http://www.ask.com/web?q=${searchKey}&page=${pageCnt}";
            ask.PreString = ">&#171;&#160;Prev";
            ask.NextString = ">Next&#160;&#187";
            engineList.Add(ask);

            //bing
            EngineEntity bing = new EngineEntity();
            bing.EngineName = "bing";
            bing.Search = new EngineNormal();
            bing.Url = "http://cn.bing.com/search?q=${searchKey}&first=${pageStart}";
            bing.PageSize = 10;
            bing.PreString = "上一页</a>";
            bing.NextString = "下一页</a>";
            engineList.Add(bing);

            //dmoz
            EngineEntity dmoz = new EngineEntity();
            dmoz.EngineName = "dmoz";
            dmoz.Search = new EngineNormal();
            dmoz.Url = "http://www.dmoz.org/search?q=${searchKey}&start=${pageStart}&type=next";
            dmoz.PageSize = 20;
            dmoz.NextString = ">next</a>";
            engineList.Add(dmoz);

            //lycos
            EngineEntity lycos = new EngineEntity();
            lycos.EngineName = "lycos";
            lycos.Search = new LycosSearch();
            lycos.Url = "http://search.lycos.com/web?q=${searchKey}&pn=${pageCnt}";
            engineList.Add(lycos);

            //search
            EngineEntity search = new EngineEntity();
            search.EngineName = "search.com";
            search.Search = new EngineNormal();
            search.Url = "http://www.search.com/search?q=${searchKey}&nav=${pageCnt}.10.5.10";
            search.NextString = "Next page of results";
            engineList.Add(search);

            //teoma
            EngineEntity teoma = new EngineEntity();
            teoma.EngineName = "teoma";
            teoma.Search = new EngineNormal();
            teoma.Url = "http://www.teoma.com/web?q=${searchKey}&page=${pageCnt}";
            teoma.PreString = "<u>Prev</u>";
            teoma.NextString = "<u>Next</u>";
            engineList.Add(teoma);

            //aol
            EngineEntity aol = new EngineEntity();
            aol.EngineName = "aol";
            aol.Search = new AolSearch();
            aol.Url = "http://search.aol.com/aol/search?q=${searchKey}";
            aol.PreString = "Previous</span>";
            aol.NextString = "Next</span>";
            engineList.Add(aol);

            grid_engine.DataSource = engineList;
        }

        private void btn_hidden_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                if ("".Equals(tb_searchKey.Text.Trim()))
                {
                    XtraMessageBox.Show("请输入搜索引擎检索关键字!");
                    return;
                }

                btn_start.Enabled = false;

                if (workItemsGroup == null)
                {
                    workItemsGroup = ThreadPoolEx.getWorkItemsGroup(5);

                    workItemsGroup.OnIdle += new WorkItemsGroupIdleHandler(delegate(IWorkItemsGroup target)
                    {
                        foreach (String url in engineList[0].AllUrlMap.Values)
                        {
                            parseService.add(url, Main.type);
                        }

                        XtraMessageBox.Show("搜索引擎共抓取出" + engineList[0].AllUrlMap.Count + "个站点提交分析");

                        engineList[0].AllUrlMap.Clear();

                        this.Close();
                    });
                }

                foreach (EngineEntity engine in engineList)
                {
                    if (engine.Selected && "未处理".Equals(engine.Status))
                    {
                        Hashtable param = new Hashtable();
                        param.Add("engine", engine);
                        param.Add("searchKey", tb_searchKey.Text.Trim());

                        engine.Status = "等待处理";

                        ThreadPoolEx.add(workItemsGroup, new WorkItemCallback(EngineService.search), param, WorkItemPriority.Normal);
                    }
                }



            }
            catch { }
            finally { btn_start.Enabled = true; }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            grid_engine.RefreshDataSource();
        }
    }
}