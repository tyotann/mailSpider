namespace com.soeasystem.spider
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tb_type = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.daemon_timer = new System.Windows.Forms.Timer(this.components);
            this.mainTab = new System.Windows.Forms.TabControl();
            this.monitor = new System.Windows.Forms.TabPage();
            this.ckb_reparse = new System.Windows.Forms.CheckBox();
            this.cb_parse_run_status = new System.Windows.Forms.ComboBox();
            this.ss_parse_url = new System.Windows.Forms.StatusStrip();
            this.lb_url_cnt = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_complete_url_cnt = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_all_mail_cnt = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_add_mail_cnt = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_parse_cnt_pre_sec = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_refresh_url = new System.Windows.Forms.Button();
            this.dgv_url = new System.Windows.Forms.DataGridView();
            this.cms_url = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_reparse = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_parse_stop = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_start = new System.Windows.Forms.Button();
            this.mail = new System.Windows.Forms.TabPage();
            this.btn_select_sender = new System.Windows.Forms.Button();
            this.ss_send_mail = new System.Windows.Forms.StatusStrip();
            this.tssl_mail_send_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.cb_mail_send_attach = new System.Windows.Forms.ComboBox();
            this.btn_mail_sender_add_attach = new System.Windows.Forms.Button();
            this.rtb_mail_send_content = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_mail_send_title = new System.Windows.Forms.TextBox();
            this.btn_send_mail = new System.Windows.Forms.Button();
            this.mailSendLog = new System.Windows.Forms.TabPage();
            this.btn_refresh_mail_send_log = new System.Windows.Forms.Button();
            this.dgv_mail_send_log = new System.Windows.Forms.DataGridView();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmi_tools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_setting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_mail_address = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_bind_ie_plugin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_unbind_ie_plugin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_export_import = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_export_unsend_mail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_export_all_mail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_import_mail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_export_config = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_import_config = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_export_mail_sender = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_import_mail_sender = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_other = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_help = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_about = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.register_time = new System.Windows.Forms.Timer(this.components);
            this.tsmi_searchEngine = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTab.SuspendLayout();
            this.monitor.SuspendLayout();
            this.ss_parse_url.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_url)).BeginInit();
            this.cms_url.SuspendLayout();
            this.mail.SuspendLayout();
            this.ss_send_mail.SuspendLayout();
            this.mailSendLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mail_send_log)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_type
            // 
            this.tb_type.Location = new System.Drawing.Point(81, 12);
            this.tb_type.Name = "tb_type";
            this.tb_type.Size = new System.Drawing.Size(166, 21);
            this.tb_type.TabIndex = 4;
            this.tt.SetToolTip(this.tb_type, "多个关键字用,隔开,如果为空,则页面中所有邮箱都将收录");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "分类:";
            // 
            // daemon_timer
            // 
            this.daemon_timer.Enabled = true;
            this.daemon_timer.Interval = 5000;
            this.daemon_timer.Tick += new System.EventHandler(this.daemon_timer_Tick);
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.monitor);
            this.mainTab.Controls.Add(this.mail);
            this.mainTab.Controls.Add(this.mailSendLog);
            this.mainTab.Location = new System.Drawing.Point(13, 27);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(781, 482);
            this.mainTab.TabIndex = 7;
            // 
            // monitor
            // 
            this.monitor.Controls.Add(this.ckb_reparse);
            this.monitor.Controls.Add(this.cb_parse_run_status);
            this.monitor.Controls.Add(this.ss_parse_url);
            this.monitor.Controls.Add(this.btn_refresh_url);
            this.monitor.Controls.Add(this.dgv_url);
            this.monitor.Controls.Add(this.tb_type);
            this.monitor.Controls.Add(this.label1);
            this.monitor.Controls.Add(this.btn_start);
            this.monitor.Location = new System.Drawing.Point(4, 21);
            this.monitor.Name = "monitor";
            this.monitor.Padding = new System.Windows.Forms.Padding(3);
            this.monitor.Size = new System.Drawing.Size(773, 457);
            this.monitor.TabIndex = 0;
            this.monitor.Text = "监控";
            this.monitor.UseVisualStyleBackColor = true;
            // 
            // ckb_reparse
            // 
            this.ckb_reparse.AutoSize = true;
            this.ckb_reparse.Checked = true;
            this.ckb_reparse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb_reparse.Location = new System.Drawing.Point(360, 14);
            this.ckb_reparse.Name = "ckb_reparse";
            this.ckb_reparse.Size = new System.Drawing.Size(126, 16);
            this.ckb_reparse.TabIndex = 15;
            this.ckb_reparse.Text = "重解析邮箱为0站点";
            this.ckb_reparse.UseVisualStyleBackColor = true;
            // 
            // cb_parse_run_status
            // 
            this.cb_parse_run_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_parse_run_status.FormattingEnabled = true;
            this.cb_parse_run_status.Items.AddRange(new object[] {
            "全部",
            "执行中",
            "执行完成"});
            this.cb_parse_run_status.Location = new System.Drawing.Point(496, 13);
            this.cb_parse_run_status.Name = "cb_parse_run_status";
            this.cb_parse_run_status.Size = new System.Drawing.Size(121, 20);
            this.cb_parse_run_status.TabIndex = 14;
            this.cb_parse_run_status.SelectedIndexChanged += new System.EventHandler(this.cb_parse_run_status_SelectedIndexChanged);
            // 
            // ss_parse_url
            // 
            this.ss_parse_url.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lb_url_cnt,
            this.lb_complete_url_cnt,
            this.lb_all_mail_cnt,
            this.lb_add_mail_cnt,
            this.lb_parse_cnt_pre_sec});
            this.ss_parse_url.Location = new System.Drawing.Point(3, 432);
            this.ss_parse_url.Name = "ss_parse_url";
            this.ss_parse_url.Size = new System.Drawing.Size(767, 22);
            this.ss_parse_url.TabIndex = 13;
            this.ss_parse_url.Text = "statusStrip1";
            // 
            // lb_url_cnt
            // 
            this.lb_url_cnt.Name = "lb_url_cnt";
            this.lb_url_cnt.Size = new System.Drawing.Size(77, 17);
            this.lb_url_cnt.Text = "请求链接数:0";
            // 
            // lb_complete_url_cnt
            // 
            this.lb_complete_url_cnt.Name = "lb_complete_url_cnt";
            this.lb_complete_url_cnt.Size = new System.Drawing.Size(89, 17);
            this.lb_complete_url_cnt.Text = "已分析链接数:0";
            // 
            // lb_all_mail_cnt
            // 
            this.lb_all_mail_cnt.Name = "lb_all_mail_cnt";
            this.lb_all_mail_cnt.Size = new System.Drawing.Size(77, 17);
            this.lb_all_mail_cnt.Text = "抓取邮箱数:0";
            // 
            // lb_add_mail_cnt
            // 
            this.lb_add_mail_cnt.Name = "lb_add_mail_cnt";
            this.lb_add_mail_cnt.Size = new System.Drawing.Size(89, 17);
            this.lb_add_mail_cnt.Text = "非重复邮箱数:0";
            // 
            // lb_parse_cnt_pre_sec
            // 
            this.lb_parse_cnt_pre_sec.Name = "lb_parse_cnt_pre_sec";
            this.lb_parse_cnt_pre_sec.Size = new System.Drawing.Size(101, 17);
            this.lb_parse_cnt_pre_sec.Text = "每秒分析连接数:0";
            // 
            // btn_refresh_url
            // 
            this.btn_refresh_url.Location = new System.Drawing.Point(646, 11);
            this.btn_refresh_url.Name = "btn_refresh_url";
            this.btn_refresh_url.Size = new System.Drawing.Size(75, 23);
            this.btn_refresh_url.TabIndex = 8;
            this.btn_refresh_url.Text = "刷新";
            this.btn_refresh_url.UseVisualStyleBackColor = true;
            this.btn_refresh_url.Click += new System.EventHandler(this.btn_refresh_url_Click);
            // 
            // dgv_url
            // 
            this.dgv_url.AllowUserToAddRows = false;
            this.dgv_url.AllowUserToDeleteRows = false;
            this.dgv_url.AllowUserToResizeColumns = false;
            this.dgv_url.AllowUserToResizeRows = false;
            this.dgv_url.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_url.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_url.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_url.ContextMenuStrip = this.cms_url;
            this.dgv_url.Location = new System.Drawing.Point(24, 47);
            this.dgv_url.Name = "dgv_url";
            this.dgv_url.ReadOnly = true;
            this.dgv_url.RowTemplate.Height = 23;
            this.dgv_url.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_url.Size = new System.Drawing.Size(722, 382);
            this.dgv_url.TabIndex = 7;
            this.tt.SetToolTip(this.dgv_url, "分析情况一览,右键后可以设定优先级");
            // 
            // cms_url
            // 
            this.cms_url.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_reparse,
            this.tsmi_parse_stop});
            this.cms_url.Name = "cms_url";
            this.cms_url.Size = new System.Drawing.Size(123, 48);
            // 
            // tsmi_reparse
            // 
            this.tsmi_reparse.Name = "tsmi_reparse";
            this.tsmi_reparse.Size = new System.Drawing.Size(122, 22);
            this.tsmi_reparse.Text = "重新解析";
            this.tsmi_reparse.Click += new System.EventHandler(this.tsmi_reparse_Click);
            // 
            // tsmi_parse_stop
            // 
            this.tsmi_parse_stop.Name = "tsmi_parse_stop";
            this.tsmi_parse_stop.Size = new System.Drawing.Size(122, 22);
            this.tsmi_parse_stop.Text = "停止解析";
            this.tsmi_parse_stop.Click += new System.EventHandler(this.tsmi_parse_stop_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(265, 10);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(73, 23);
            this.btn_start.TabIndex = 3;
            this.btn_start.Text = "开始";
            this.tt.SetToolTip(this.btn_start, "开始分析IE点击的URL");
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // mail
            // 
            this.mail.Controls.Add(this.btn_select_sender);
            this.mail.Controls.Add(this.ss_send_mail);
            this.mail.Controls.Add(this.cb_mail_send_attach);
            this.mail.Controls.Add(this.btn_mail_sender_add_attach);
            this.mail.Controls.Add(this.rtb_mail_send_content);
            this.mail.Controls.Add(this.label7);
            this.mail.Controls.Add(this.tb_mail_send_title);
            this.mail.Controls.Add(this.btn_send_mail);
            this.mail.Location = new System.Drawing.Point(4, 21);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(773, 457);
            this.mail.TabIndex = 2;
            this.mail.Text = "邮箱";
            this.mail.UseVisualStyleBackColor = true;
            // 
            // btn_select_sender
            // 
            this.btn_select_sender.Location = new System.Drawing.Point(31, 17);
            this.btn_select_sender.Name = "btn_select_sender";
            this.btn_select_sender.Size = new System.Drawing.Size(75, 23);
            this.btn_select_sender.TabIndex = 26;
            this.btn_select_sender.Text = "选择发件人";
            this.btn_select_sender.UseVisualStyleBackColor = true;
            this.btn_select_sender.Click += new System.EventHandler(this.btn_select_sender_Click);
            // 
            // ss_send_mail
            // 
            this.ss_send_mail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_mail_send_status});
            this.ss_send_mail.Location = new System.Drawing.Point(0, 435);
            this.ss_send_mail.Name = "ss_send_mail";
            this.ss_send_mail.Size = new System.Drawing.Size(773, 22);
            this.ss_send_mail.TabIndex = 25;
            this.ss_send_mail.Text = "statusStrip1";
            // 
            // tssl_mail_send_status
            // 
            this.tssl_mail_send_status.Name = "tssl_mail_send_status";
            this.tssl_mail_send_status.Size = new System.Drawing.Size(189, 17);
            this.tssl_mail_send_status.Text = "待发邮件:0;已发邮件:0;发送异常:0";
            // 
            // cb_mail_send_attach
            // 
            this.cb_mail_send_attach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_mail_send_attach.FormattingEnabled = true;
            this.cb_mail_send_attach.Location = new System.Drawing.Point(518, 20);
            this.cb_mail_send_attach.Name = "cb_mail_send_attach";
            this.cb_mail_send_attach.Size = new System.Drawing.Size(236, 20);
            this.cb_mail_send_attach.TabIndex = 23;
            // 
            // btn_mail_sender_add_attach
            // 
            this.btn_mail_sender_add_attach.Location = new System.Drawing.Point(428, 18);
            this.btn_mail_sender_add_attach.Name = "btn_mail_sender_add_attach";
            this.btn_mail_sender_add_attach.Size = new System.Drawing.Size(75, 23);
            this.btn_mail_sender_add_attach.TabIndex = 21;
            this.btn_mail_sender_add_attach.Text = "添加附件";
            this.btn_mail_sender_add_attach.UseVisualStyleBackColor = true;
            this.btn_mail_sender_add_attach.Click += new System.EventHandler(this.btn_mail_sender_add_attach_Click);
            // 
            // rtb_mail_send_content
            // 
            this.rtb_mail_send_content.Location = new System.Drawing.Point(15, 61);
            this.rtb_mail_send_content.Name = "rtb_mail_send_content";
            this.rtb_mail_send_content.Size = new System.Drawing.Size(739, 336);
            this.rtb_mail_send_content.TabIndex = 20;
            this.rtb_mail_send_content.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(139, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "主题:";
            // 
            // tb_mail_send_title
            // 
            this.tb_mail_send_title.Location = new System.Drawing.Point(180, 19);
            this.tb_mail_send_title.Name = "tb_mail_send_title";
            this.tb_mail_send_title.Size = new System.Drawing.Size(209, 21);
            this.tb_mail_send_title.TabIndex = 16;
            // 
            // btn_send_mail
            // 
            this.btn_send_mail.Location = new System.Drawing.Point(336, 403);
            this.btn_send_mail.Name = "btn_send_mail";
            this.btn_send_mail.Size = new System.Drawing.Size(75, 23);
            this.btn_send_mail.TabIndex = 15;
            this.btn_send_mail.Text = "发送邮件";
            this.btn_send_mail.UseVisualStyleBackColor = true;
            this.btn_send_mail.Click += new System.EventHandler(this.btn_send_mail_Click);
            // 
            // mailSendLog
            // 
            this.mailSendLog.Controls.Add(this.btn_refresh_mail_send_log);
            this.mailSendLog.Controls.Add(this.dgv_mail_send_log);
            this.mailSendLog.Location = new System.Drawing.Point(4, 21);
            this.mailSendLog.Name = "mailSendLog";
            this.mailSendLog.Size = new System.Drawing.Size(773, 457);
            this.mailSendLog.TabIndex = 4;
            this.mailSendLog.Text = "邮件发送日志";
            this.mailSendLog.UseVisualStyleBackColor = true;
            // 
            // btn_refresh_mail_send_log
            // 
            this.btn_refresh_mail_send_log.Location = new System.Drawing.Point(44, 17);
            this.btn_refresh_mail_send_log.Name = "btn_refresh_mail_send_log";
            this.btn_refresh_mail_send_log.Size = new System.Drawing.Size(75, 23);
            this.btn_refresh_mail_send_log.TabIndex = 9;
            this.btn_refresh_mail_send_log.Text = "刷新";
            this.btn_refresh_mail_send_log.UseVisualStyleBackColor = true;
            this.btn_refresh_mail_send_log.Click += new System.EventHandler(this.btn_refresh_mail_send_log_Click);
            // 
            // dgv_mail_send_log
            // 
            this.dgv_mail_send_log.AllowUserToAddRows = false;
            this.dgv_mail_send_log.AllowUserToDeleteRows = false;
            this.dgv_mail_send_log.AllowUserToResizeColumns = false;
            this.dgv_mail_send_log.AllowUserToResizeRows = false;
            this.dgv_mail_send_log.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_mail_send_log.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_mail_send_log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_mail_send_log.ContextMenuStrip = this.cms_url;
            this.dgv_mail_send_log.Location = new System.Drawing.Point(20, 57);
            this.dgv_mail_send_log.MultiSelect = false;
            this.dgv_mail_send_log.Name = "dgv_mail_send_log";
            this.dgv_mail_send_log.ReadOnly = true;
            this.dgv_mail_send_log.RowTemplate.Height = 23;
            this.dgv_mail_send_log.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_mail_send_log.Size = new System.Drawing.Size(731, 374);
            this.dgv_mail_send_log.TabIndex = 8;
            this.tt.SetToolTip(this.dgv_mail_send_log, "分析情况一览,右键后可以设定优先级");
            // 
            // tt
            // 
            this.tt.AutoPopDelay = 2000;
            this.tt.InitialDelay = 500;
            this.tt.ReshowDelay = 100;
            // 
            // openFileDialog
            // 
            this.openFileDialog.AutoUpgradeEnabled = false;
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "选择附件";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_tools,
            this.tsmi_export_import,
            this.tsmi_other,
            this.tsmi_searchEngine});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(805, 24);
            this.menuStrip.TabIndex = 8;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tsmi_tools
            // 
            this.tsmi_tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_setting,
            this.tsmi_mail_address,
            this.tsmi_bind_ie_plugin,
            this.tsmi_unbind_ie_plugin});
            this.tsmi_tools.Name = "tsmi_tools";
            this.tsmi_tools.Size = new System.Drawing.Size(43, 20);
            this.tsmi_tools.Text = "工具";
            // 
            // tsmi_setting
            // 
            this.tsmi_setting.Name = "tsmi_setting";
            this.tsmi_setting.Size = new System.Drawing.Size(152, 22);
            this.tsmi_setting.Text = "设置";
            this.tsmi_setting.Click += new System.EventHandler(this.tsmi_setting_Click);
            // 
            // tsmi_mail_address
            // 
            this.tsmi_mail_address.Name = "tsmi_mail_address";
            this.tsmi_mail_address.Size = new System.Drawing.Size(152, 22);
            this.tsmi_mail_address.Text = "邮箱维护";
            this.tsmi_mail_address.Click += new System.EventHandler(this.tsmi_mail_address_Click);
            // 
            // tsmi_bind_ie_plugin
            // 
            this.tsmi_bind_ie_plugin.Name = "tsmi_bind_ie_plugin";
            this.tsmi_bind_ie_plugin.Size = new System.Drawing.Size(152, 22);
            this.tsmi_bind_ie_plugin.Text = "绑定IE插件";
            this.tsmi_bind_ie_plugin.Click += new System.EventHandler(this.tsmi_bind_ie_plugin_Click);
            // 
            // tsmi_unbind_ie_plugin
            // 
            this.tsmi_unbind_ie_plugin.Name = "tsmi_unbind_ie_plugin";
            this.tsmi_unbind_ie_plugin.Size = new System.Drawing.Size(152, 22);
            this.tsmi_unbind_ie_plugin.Text = "卸载IE插件";
            this.tsmi_unbind_ie_plugin.Click += new System.EventHandler(this.tsmi_unbind_ie_plugin_Click);
            // 
            // tsmi_export_import
            // 
            this.tsmi_export_import.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_export_unsend_mail,
            this.tsmi_export_all_mail,
            this.tsmi_import_mail,
            this.toolStripSeparator1,
            this.tsmi_export_config,
            this.tsmi_import_config,
            this.toolStripSeparator2,
            this.tsmi_export_mail_sender,
            this.tsmi_import_mail_sender});
            this.tsmi_export_import.Name = "tsmi_export_import";
            this.tsmi_export_import.Size = new System.Drawing.Size(43, 20);
            this.tsmi_export_import.Text = "高级";
            // 
            // tsmi_export_unsend_mail
            // 
            this.tsmi_export_unsend_mail.Name = "tsmi_export_unsend_mail";
            this.tsmi_export_unsend_mail.Size = new System.Drawing.Size(170, 22);
            this.tsmi_export_unsend_mail.Text = "导出未发邮箱";
            this.tsmi_export_unsend_mail.Click += new System.EventHandler(this.tsmi_export_unsend_mail_Click);
            // 
            // tsmi_export_all_mail
            // 
            this.tsmi_export_all_mail.Name = "tsmi_export_all_mail";
            this.tsmi_export_all_mail.Size = new System.Drawing.Size(170, 22);
            this.tsmi_export_all_mail.Text = "导出所有邮箱";
            this.tsmi_export_all_mail.Click += new System.EventHandler(this.tsmi_export_all_mail_Click);
            // 
            // tsmi_import_mail
            // 
            this.tsmi_import_mail.Name = "tsmi_import_mail";
            this.tsmi_import_mail.Size = new System.Drawing.Size(170, 22);
            this.tsmi_import_mail.Text = "导入邮箱";
            this.tsmi_import_mail.Click += new System.EventHandler(this.tsmi_import_mail_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // tsmi_export_config
            // 
            this.tsmi_export_config.Name = "tsmi_export_config";
            this.tsmi_export_config.Size = new System.Drawing.Size(170, 22);
            this.tsmi_export_config.Text = "导出配置信息";
            this.tsmi_export_config.Click += new System.EventHandler(this.tsmi_export_config_Click);
            // 
            // tsmi_import_config
            // 
            this.tsmi_import_config.Name = "tsmi_import_config";
            this.tsmi_import_config.Size = new System.Drawing.Size(170, 22);
            this.tsmi_import_config.Text = "导入配置信息";
            this.tsmi_import_config.Click += new System.EventHandler(this.tsmi_import_config_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(167, 6);
            // 
            // tsmi_export_mail_sender
            // 
            this.tsmi_export_mail_sender.Name = "tsmi_export_mail_sender";
            this.tsmi_export_mail_sender.Size = new System.Drawing.Size(170, 22);
            this.tsmi_export_mail_sender.Text = "导出邮件发送账户";
            this.tsmi_export_mail_sender.Click += new System.EventHandler(this.tsmi_export_mail_sender_Click);
            // 
            // tsmi_import_mail_sender
            // 
            this.tsmi_import_mail_sender.Name = "tsmi_import_mail_sender";
            this.tsmi_import_mail_sender.Size = new System.Drawing.Size(170, 22);
            this.tsmi_import_mail_sender.Text = "导入邮件发送账户";
            this.tsmi_import_mail_sender.Click += new System.EventHandler(this.tsmi_import_mail_sender_Click);
            // 
            // tsmi_other
            // 
            this.tsmi_other.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_help,
            this.tsmi_about});
            this.tsmi_other.Name = "tsmi_other";
            this.tsmi_other.Size = new System.Drawing.Size(43, 20);
            this.tsmi_other.Text = "其他";
            // 
            // tsmi_help
            // 
            this.tsmi_help.Name = "tsmi_help";
            this.tsmi_help.Size = new System.Drawing.Size(98, 22);
            this.tsmi_help.Text = "帮助";
            this.tsmi_help.Click += new System.EventHandler(this.tsmi_help_Click);
            // 
            // tsmi_about
            // 
            this.tsmi_about.Name = "tsmi_about";
            this.tsmi_about.Size = new System.Drawing.Size(98, 22);
            this.tsmi_about.Text = "关于";
            this.tsmi_about.Click += new System.EventHandler(this.tsmi_about_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.AddExtension = false;
            this.saveFileDialog.RestoreDirectory = true;
            // 
            // register_time
            // 
            this.register_time.Enabled = true;
            this.register_time.Interval = 3600000;
            this.register_time.Tick += new System.EventHandler(this.register_time_Tick);
            // 
            // tsmi_searchEngine
            // 
            this.tsmi_searchEngine.Name = "tsmi_searchEngine";
            this.tsmi_searchEngine.Size = new System.Drawing.Size(67, 20);
            this.tsmi_searchEngine.Text = "搜索引擎";
            this.tsmi_searchEngine.Click += new System.EventHandler(this.tsmi_searchEngine_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(805, 521);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.mainTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mail spider";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.mainTab.ResumeLayout(false);
            this.monitor.ResumeLayout(false);
            this.monitor.PerformLayout();
            this.ss_parse_url.ResumeLayout(false);
            this.ss_parse_url.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_url)).EndInit();
            this.cms_url.ResumeLayout(false);
            this.mail.ResumeLayout(false);
            this.mail.PerformLayout();
            this.ss_send_mail.ResumeLayout(false);
            this.ss_send_mail.PerformLayout();
            this.mailSendLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mail_send_log)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer daemon_timer;
        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TabPage monitor;
        private System.Windows.Forms.DataGridView dgv_url;
        private System.Windows.Forms.TabPage mail;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.ContextMenuStrip cms_url;
        private System.Windows.Forms.Button btn_send_mail;
        private System.Windows.Forms.TextBox tb_mail_send_title;
        private System.Windows.Forms.Button btn_refresh_url;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtb_mail_send_content;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btn_mail_sender_add_attach;
        private System.Windows.Forms.ComboBox cb_mail_send_attach;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmi_tools;
        private System.Windows.Forms.ToolStripMenuItem tsmi_setting;
        private System.Windows.Forms.ToolStripMenuItem tsmi_bind_ie_plugin;
        private System.Windows.Forms.ToolStripMenuItem tsmi_unbind_ie_plugin;
        private System.Windows.Forms.StatusStrip ss_send_mail;
        private System.Windows.Forms.ToolStripStatusLabel tssl_mail_send_status;
        private System.Windows.Forms.ToolStripMenuItem tsmi_parse_stop;
        private System.Windows.Forms.TabPage mailSendLog;
        private System.Windows.Forms.DataGridView dgv_mail_send_log;
        private System.Windows.Forms.Button btn_refresh_mail_send_log;
        private System.Windows.Forms.ToolStripMenuItem tsmi_export_import;
        private System.Windows.Forms.ToolStripMenuItem tsmi_export_unsend_mail;
        private System.Windows.Forms.ToolStripMenuItem tsmi_export_all_mail;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem tsmi_import_mail;
        private System.Windows.Forms.ToolStripMenuItem tsmi_mail_address;
        private System.Windows.Forms.Button btn_select_sender;
        private System.Windows.Forms.StatusStrip ss_parse_url;
        private System.Windows.Forms.ToolStripStatusLabel lb_url_cnt;
        private System.Windows.Forms.ToolStripStatusLabel lb_complete_url_cnt;
        private System.Windows.Forms.ToolStripStatusLabel lb_all_mail_cnt;
        private System.Windows.Forms.ToolStripMenuItem tsmi_reparse;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.ToolStripStatusLabel lb_parse_cnt_pre_sec;
        private System.Windows.Forms.ToolStripMenuItem tsmi_other;
        private System.Windows.Forms.ToolStripMenuItem tsmi_help;
        private System.Windows.Forms.ToolStripMenuItem tsmi_about;
        private System.Windows.Forms.ToolStripMenuItem tsmi_export_config;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_import_config;
        private System.Windows.Forms.ComboBox cb_parse_run_status;
        private System.Windows.Forms.ToolStripStatusLabel lb_add_mail_cnt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_export_mail_sender;
        private System.Windows.Forms.ToolStripMenuItem tsmi_import_mail_sender;
        private System.Windows.Forms.Timer register_time;
        private System.Windows.Forms.CheckBox ckb_reparse;
        private System.Windows.Forms.ToolStripMenuItem tsmi_searchEngine;
    }
}

