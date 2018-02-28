using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using com.soeasystem.spider;
using log4net;
using System.Threading;
using System.IO;
using com.soeasystem.spider.Properties;
using com.soeasystem.spider.src.utils;
using com.soeasystem.spider.src.service;
using System.Diagnostics;
using DevExpress.Data;
using com.soeasystem.spider.src.form;
using com.soeasystem.spider.src;

namespace mailSpider
{
    static class Program
    {
        private static ILog logger = LogManager.GetLogger("ParseThread");

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                if (!SystemUtils.isSingleProcesses())
                {
                    MessageBox.Show("已启动了另一个程序~");
                    return;
                }

                //控件语言设置
               //DevExpressChineseLanguage.init();

                //检查数据库文件
                checkDbFile();

                //检查是否管理员
                if (!SystemUtils.IsAdministrator())
                {
                    MessageBox.Show("此程序需要以管理员权限启动~");
                    return;
                }

                Application.ThreadException += new ThreadExceptionEventHandler(delegate(object sender, ThreadExceptionEventArgs t)
                {
                    logger.Error(t.Exception.Message, t.Exception);
                });

                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(delegate(object sender, UnhandledExceptionEventArgs t)
                {
                    Exception ex = (Exception)t.ExceptionObject;
                    logger.Error(ex.Message, ex);
                });

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                RegisterInfo registerInfo = RegisterService.getRegisterInfo();

                //跨线程更新数据
                CurrencyDataController.DisableThreadingProblemsDetection = true;

                //跨线程调用控件
                Control.CheckForIllegalCrossThreadCalls = false;

                // 设置标题栏皮肤
                DevExpress.Skins.SkinManager.EnableFormSkins();
                DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged();


                //检查注册信息
                if ("UN_SUPPORT".Equals(registerInfo.VersionType))
                {
                    Application.Run(new RegisterForm());
                }
                else if ("CLOSE".Equals(registerInfo.VersionType))
                {

                }
                else if ("FULL".Equals(registerInfo.VersionType) || "TRIAL".Equals(registerInfo.VersionType))
                {
                    Application.Run(new MainForm());
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
            }

        }

        //查看数据文件是否存在
        private static void checkDbFile()
        {

            String mailSpiderDbPath = SystemUtils.getCurrentPath() + "\\mailSpider.db";
            if (!File.Exists(mailSpiderDbPath))
            {
                FileStream fs = null;
                try
                {
                    fs = new FileStream(mailSpiderDbPath, FileMode.Create);
                    fs.Write(Resources.mailSpider, 0, Resources.mailSpider.Length);
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
            }
        }

    }
}
