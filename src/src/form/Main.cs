using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Data.SQLite;
using System.Threading;
using com.soeasystem.spider.src;
using com.soeasystem.spider.src.utils;
using log4net.Util;
using com.soeasystem.spider.src.entity;
using Amib.Threading;
using log4net;
using com.soeasystem.spider.src.service;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net;
using mailSpider;
using com.soeasystem.spider.src.form;

namespace com.soeasystem.spider
{
    public partial class Main : Form
    {
        private static ILog logger = LogManager.GetLogger("Main");

        private ParseService parseService = new ParseService();

        private RuntimeService runtimeService = new RuntimeService();

        private MailService mailService = new MailService();

        private MailSendService mailSendService = new MailSendService();

        private DataTable urlDataTable = null;

        private DataTable sendLog = null;

        private ConfigForm configForm = new ConfigForm();

        private URLEngineForm engineSearchForm = new URLEngineForm();

        private MailForm mailForm = new MailForm();

        private Stopwatch stopwatch = new Stopwatch();

        public static String type = String.Empty;

        public Main()
        {
            ServicePointManager.DefaultConnectionLimit = 256;

            InitializeComponent();


            //非正式版区别
            if (!"FULL".Equals(RegisterService.getRegisterInfo().VersionType))
            {
                //不显示邮箱维护
                tsmi_mail_address.Enabled = false;

                //不显示导入导出
                tsmi_export_import.Enabled = false;

                //不能发送邮件
                btn_send_mail.Enabled = false;
            }

            //初始化线程池
            ThreadPoolEx.init();

            //init urlMap
            {
                urlDataTable = new DataTable();
                urlDataTable.Columns.Add("URL", typeof(string));
                urlDataTable.Columns.Add("等待处理个数", typeof(Int32));
                urlDataTable.Columns.Add("正在处理个数", typeof(Int32));
                urlDataTable.Columns.Add("处理成功个数", typeof(Int32));
                urlDataTable.Columns.Add("请求网页超时数", typeof(Int32));
                urlDataTable.Columns.Add("抓取非重复邮箱数", typeof(Int32));
                urlDataTable.Columns.Add("状态", typeof(string));
      
                dgv_url.DataSource = urlDataTable;
            }

            //init dgv_mail_send_log
            {
                sendLog = new DataTable();
                sendLog.Columns.Add("信息", typeof(string));
                dgv_mail_send_log.DataSource = sendLog;
            }

            cb_parse_run_status.SelectedIndex = 1;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (tb_type.ReadOnly)
            {
                btn_start.Text = "开始";

                stopwatch.Stop();
            }
            else
            {
                btn_start.Text = "停止";

                Main.type = tb_type.Text.Trim();

                if (tb_type.Text.Trim().Equals(""))
                {
                    MessageBox.Show("请输入此次IE搜索的邮箱类别!");
                    return;
                }

                if (MessageBox.Show("是否启动搜索引擎组件", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    engineSearchForm.ShowDialog();
                }

                stopwatch.Start();
            }


            tb_type.ReadOnly = !tb_type.ReadOnly;
        }


        /**
         * 守护进程
         */
        private void daemon_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                tssl_mail_send_status.Text = "待发邮件:" + MailSendService.sendWaitCnt + "; 已发邮件:" + MailSendService.sendSuccessCnt + "; 无法发送数:" + MailSendService.sendErrorCnt;

                //如果队列已经结束,则重跑邮箱解析为0的站点
                if (ckb_reparse.Checked && ThreadPoolEx.IsIdle() && runtimeService.getAll().Count > 0)
                {
                    foreach (DictionaryEntry de in (Hashtable)runtimeService.getAll().Clone())
                    {
                        RuntimeEntity runtime = (RuntimeEntity)de.Value;

                        if (runtime.AllMailCnt == 0 && runtime.reparse())
                        {
                            parseService.add((String)de.Key, tb_type.Text.Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
            }

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (DictionaryEntry de in (Hashtable)runtimeService.getAll().Clone())
            {
                RuntimeEntity runtimeEntity = runtimeService.get((String)de.Key);

                if (runtimeEntity.getWaitQueueCnt() > 0 || runtimeEntity.getStartQueueCnt() > 0)
                {
                    if (MessageBox.Show("还有任务没有完成,是否强制关闭程序?", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                    break;
                }
            }

            if (MailSendService.sendWaitCnt > 0 && MessageBox.Show("还有邮件正在发送,是否强制关闭程序?", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }

            if (!e.Cancel)
            {
                ThreadPoolEx.destory();
            }
        }

        private void cb_parse_run_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_refresh_url_Click(sender, e);
        }

        private void btn_refresh_url_Click(object sender, EventArgs e)
        {
            btn_refresh_url.Enabled = false;

            try
            {
                urlDataTable.Clear();

                Int32 allMailCnt = 0, addMailCnt = 0, completeUrlCnt = 0;

                dgv_url.Columns["状态"].Visible = "全部".Equals(cb_parse_run_status.Text);

                foreach (DictionaryEntry de in (Hashtable)runtimeService.getAll().Clone())
                {
                    DataRow row = urlDataTable.NewRow();

                    row["URL"] = de.Key;

                    RuntimeEntity runtime = (RuntimeEntity)de.Value;
                    row["等待处理个数"] = runtime.getWaitQueueCnt();
                    row["正在处理个数"] = runtime.getStartQueueCnt();
                    row["处理成功个数"] = runtime.getSuccessQueueCnt();
                    row["请求网页超时数"] = runtime.getErrorQueueCnt();
                    row["抓取非重复邮箱数"] = runtime.AddMailCnt;
                    row["状态"] = runtime.RunStatus;

                    if ("执行中".Equals(cb_parse_run_status.Text))
                    {
                        if (Constant.RunStatus.RUNING.Equals(runtime.RunStatus) || Constant.RunStatus.STOPING.Equals(runtime.RunStatus))
                        {
                            urlDataTable.Rows.Add(row);
                        }
                    }
                    else if ("执行完成".Equals(cb_parse_run_status.Text))
                    {
                        if (Constant.RunStatus.STOP.Equals(runtime.RunStatus))
                        {
                            urlDataTable.Rows.Add(row);
                        }
                    }
                    else
                    {
                        urlDataTable.Rows.Add(row);
                    }

                    allMailCnt += runtime.AllMailCnt;
                    addMailCnt += runtime.AddMailCnt;
                    completeUrlCnt += runtime.getSuccessQueueCnt() + runtime.getErrorQueueCnt();
                }

                lb_all_mail_cnt.Text = "抓取邮箱数:" + Convert.ToString(allMailCnt);
                lb_add_mail_cnt.Text = "非重复邮箱数:" + Convert.ToString(addMailCnt);
                lb_url_cnt.Text = "请求链接数:" + Convert.ToString(urlDataTable.Rows.Count);
                lb_complete_url_cnt.Text = "已分析链接数:" + Convert.ToString(completeUrlCnt);
                lb_parse_cnt_pre_sec.Text = "每秒分析链接数:" + Math.Ceiling(completeUrlCnt / stopwatch.Elapsed.TotalSeconds);
            }
            catch { }

            btn_refresh_url.Enabled = true;
        }

        List<String> attachmentList = new List<String>();

        private void btn_mail_sender_add_attach_Click(object sender, EventArgs e)
        {
            openFileDialog.Multiselect = true;
            openFileDialog.FileName = "";
            openFileDialog.Filter = "所有文件类型(*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                cb_mail_send_attach.Items.Clear();
                attachmentList.Clear();

                foreach (String attach in openFileDialog.FileNames)
                {
                    attachmentList.Add(attach);
                    cb_mail_send_attach.Items.Add(new FileInfo(attach).Name);
                }
            }
        }

        private void btn_send_mail_Click(object sender, EventArgs e)
        {
            if (MailSendService.sendWaitCnt > 0)
            {
                MessageBox.Show("还有邮件正在发送中!");
                return;
            }
            else
            {
                if (mailForm.getSelectRow() != null && mailForm.getSelectRow().Count != 0)
                {
                    btn_send_mail.Enabled = false;
                    List<String[]> addressList = new List<String[]>();

                    foreach (DataGridViewRow row in mailForm.getSelectRow())
                    {
                        addressList.Add(new String[] { Convert.ToString(row.Cells["mail_address"].Value), Convert.ToString(row.Cells["create_type"].Value) });
                    }

                    String title = tb_mail_send_title.Text;

                    String content = rtb_mail_send_content.Text;

                    Thread mailThread = new Thread(new ThreadStart(delegate
                    {
                        try
                        {
                            mailSendService.send(addressList, title, content, attachmentList);
                        }
                        catch { }
                    }));
                    mailThread.Name = "mail send Thread";
                    mailThread.IsBackground = true;
                    mailThread.Priority = ThreadPriority.Normal;
                    mailThread.Start();

                    Thread.Sleep(5000);
                    btn_send_mail.Enabled = true;
                }
            }
        }

        private void tsmi_setting_Click(object sender, EventArgs e)
        {
            configForm.refresh();
            configForm.ShowDialog();
        }

        private void tsmi_bind_ie_plugin_Click(object sender, EventArgs e)
        {
            String regAsmPath = SystemUtils.getRegAsmPath();

            if (regAsmPath == null)
            {
                MessageBox.Show("没有找到RegAsm.exe,请确定已经安装了Microsoft.NET Framework 3.5 sp1版本!");
                return;
            }
            else
            {
                MessageBox.Show(SystemUtils.executeCmd(regAsmPath + " /codebase \"URListener.dll\""));
            }
        }

        private void tsmi_unbind_ie_plugin_Click(object sender, EventArgs e)
        {
            String regAsmPath = SystemUtils.getRegAsmPath();

            if (regAsmPath == null)
            {
                MessageBox.Show("没有找到RegAsm.exe,请确定已经安装了Microsoft.NET Framework 3.5 sp1版本!");
                return;
            }
            else
            {
                MessageBox.Show(SystemUtils.executeCmd(regAsmPath + " /u \"URListener.dll\""));
            }
        }

        private void tsmi_parse_stop_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgv_url.SelectedRows)
            {
                runtimeService.get((String)dr.Cells[0].Value).stop(true);
            }
        }

        private void btn_refresh_mail_send_log_Click(object sender, EventArgs e)
        {
            sendLog.Clear();

            foreach (String log in MailSendService.sendLog)
            {
                DataRow dr = sendLog.NewRow();
                dr["信息"] = log;
                sendLog.Rows.Add(dr);
            }

        }

        private void tsmi_export_unsend_mail_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "mail";
            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = "mail spider文件类型(*.spider)|*.spider";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                FileStream fs = null;
                try
                {
                    fs = (FileStream)saveFileDialog.OpenFile();
                    DataTable dt = mailService.get(null, null, Constant.MailSendType.UN_SEND, null);
                    new BinaryFormatter().Serialize(fs, dt);
                    MessageBox.Show("成功导出" + dt.Rows.Count + "个邮箱");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出异常:" + ex.Message);
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

        private void tsmi_export_all_mail_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "mail";
            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = "mail spider文件类型(*.spider)|*.spider";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                FileStream fs = null;
                try
                {
                    fs = (FileStream)saveFileDialog.OpenFile();
                    DataTable dt = mailService.get(null, null, Constant.MailSendType.ALL, null);
                    new BinaryFormatter().Serialize(fs, dt);
                    MessageBox.Show("成功导出" + dt.Rows.Count + "个邮箱");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出异常:" + ex.Message);
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

        private void tsmi_import_mail_Click(object sender, EventArgs e)
        {
            openFileDialog.Multiselect = false;
            openFileDialog.FileName = "mail";
            openFileDialog.AddExtension = true;
            openFileDialog.Filter = "mail spider文件类型(*.spider)|*.spider";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                Stream stream = null;
                try
                {
                    stream = openFileDialog.OpenFile();
                    DataTable dt = (DataTable)new BinaryFormatter().Deserialize(stream);
                    List<String> unImportList = mailService.import(dt);

                    MessageBox.Show("成功导入" + Convert.ToString(dt.Rows.Count - unImportList.Count) + "个邮箱");
                    if (unImportList.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();

                        foreach (String address in unImportList)
                        {
                            sb.Append(Environment.NewLine + address);
                        }
                        MessageBox.Show("以下邮箱已存在,因此没有导入" + sb.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导入异常:" + ex.Message);
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                }
            }
        }

        private void tsmi_mail_address_Click(object sender, EventArgs e)
        {
            mailForm.isModifyMode();
            mailForm.ShowDialog();
        }

        private void btn_select_sender_Click(object sender, EventArgs e)
        {
            mailForm.isSelectMode();
            mailForm.ShowDialog();
        }

        private void tsmi_reparse_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgv_url.SelectedRows)
            {
                String url = (String)dr.Cells[0].Value;

                RuntimeEntity runtime = runtimeService.get(url);

                if (runtime.reparse())
                {
                    parseService.add(url, tb_type.Text.Trim());
                }
            }
        }

        protected override void DefWndProc(ref Message m)
        {
            try
            {
                switch (m.Msg)
                {
                    case 0x004A:

                        if (tb_type.ReadOnly)
                        {
                            byte[] lpdata;

                            int dwData;

                            SystemUtils.receiveMsg(ref m, out dwData, out lpdata);

                            parseService.add(Encoding.UTF8.GetString(lpdata), tb_type.Text.Trim());
                        }
                        break;
                    default:
                        base.DefWndProc(ref m);
                        break;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
            }
        }

        private void tsmi_about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("程序版本" + Application.ProductVersion + Environment.NewLine + "如有建议,请发邮件至:mailspider@soeasystem.com" + Environment.NewLine + "客服QQ:977073927" + Environment.NewLine + "注册于公司:" + RegisterService.getRegisterInfo().CompanyName);
        }

        private void tsmi_help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请查看相应操作手册");
        }

        private void tsmi_export_config_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "config";
            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = "mail spider文件类型(*.spider)|*.spider";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                FileStream fs = null;
                try
                {
                    fs = (FileStream)saveFileDialog.OpenFile();
                    new BinaryFormatter().Serialize(fs, ConfigService.show());
                    MessageBox.Show("成功导出配置文件");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出异常:" + ex.Message);
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

        private void tsmi_import_config_Click(object sender, EventArgs e)
        {
            openFileDialog.Multiselect = false;
            openFileDialog.FileName = "config";
            openFileDialog.AddExtension = true;
            openFileDialog.Filter = "mail spider文件类型(*.spider)|*.spider";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                Stream stream = null;
                try
                {
                    stream = openFileDialog.OpenFile();
                    DataTable dt = (DataTable)new BinaryFormatter().Deserialize(stream);
                    ConfigService.import(dt);

                    MessageBox.Show("成功导入配置文件");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导入异常:" + ex.Message);
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                }
            }
        }

        private void tsmi_export_mail_sender_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "mailSender";
            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = "mail spider文件类型(*.spider)|*.spider";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                FileStream fs = null;
                try
                {
                    fs = (FileStream)saveFileDialog.OpenFile();
                    new BinaryFormatter().Serialize(fs, mailSendService.getAll());
                    MessageBox.Show("成功导出配置文件");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出异常:" + ex.Message);
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

        private void tsmi_import_mail_sender_Click(object sender, EventArgs e)
        {
            openFileDialog.Multiselect = false;
            openFileDialog.FileName = "mailSender";
            openFileDialog.AddExtension = true;
            openFileDialog.Filter = "mail spider文件类型(*.spider)|*.spider";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                Stream stream = null;
                try
                {
                    stream = openFileDialog.OpenFile();
                    DataTable dt = (DataTable)new BinaryFormatter().Deserialize(stream);
                    mailSendService.import(dt);

                    MessageBox.Show("成功导入配置文件");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导入异常:" + ex.Message);
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                }
            }
        }

        private void register_time_Tick(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(DateUtils.getRealSysDate().Substring(0, 10)).Subtract(Convert.ToDateTime(RegisterService.getRegisterInfo().EndDate)).TotalDays > 0)
            {
                MessageBox.Show("您的授权日期:" + RegisterService.getRegisterInfo().EndDate + "已过期,~请与销售联系购买新的许可");
                this.Close();
            }
        }

        private void tsmi_searchEngine_Click(object sender, EventArgs e)
        {
            engineSearchForm.ShowDialog();
        }

    }
}
