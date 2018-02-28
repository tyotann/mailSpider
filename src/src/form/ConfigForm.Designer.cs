namespace com.soeasystem.spider
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.mainTab = new System.Windows.Forms.TabControl();
            this.setting = new System.Windows.Forms.TabPage();
            this.dgv_config = new System.Windows.Forms.DataGridView();
            this.btn_apply = new System.Windows.Forms.Button();
            this.mailSendConfig = new System.Windows.Forms.TabPage();
            this.tb_mail_address = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_test_mail_send = new System.Windows.Forms.Button();
            this.btn_del_mail_sender = new System.Windows.Forms.Button();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.tb_host = new System.Windows.Forms.TextBox();
            this.cb_enable_ssl = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_add_mail_sender = new System.Windows.Forms.Button();
            this.btn_refresh_mail_sender = new System.Windows.Forms.Button();
            this.dgv_mail_sender = new System.Windows.Forms.DataGridView();
            this.mainTab.SuspendLayout();
            this.setting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_config)).BeginInit();
            this.mailSendConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mail_sender)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.setting);
            this.mainTab.Controls.Add(this.mailSendConfig);
            this.mainTab.Location = new System.Drawing.Point(12, 18);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(781, 491);
            this.mainTab.TabIndex = 8;
            // 
            // setting
            // 
            this.setting.Controls.Add(this.dgv_config);
            this.setting.Controls.Add(this.btn_apply);
            this.setting.Location = new System.Drawing.Point(4, 21);
            this.setting.Name = "setting";
            this.setting.Padding = new System.Windows.Forms.Padding(3);
            this.setting.Size = new System.Drawing.Size(773, 466);
            this.setting.TabIndex = 1;
            this.setting.Text = "设置";
            this.setting.UseVisualStyleBackColor = true;
            // 
            // dgv_config
            // 
            this.dgv_config.AllowUserToAddRows = false;
            this.dgv_config.AllowUserToDeleteRows = false;
            this.dgv_config.AllowUserToResizeRows = false;
            this.dgv_config.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_config.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_config.Location = new System.Drawing.Point(25, 19);
            this.dgv_config.Name = "dgv_config";
            this.dgv_config.RowTemplate.Height = 23;
            this.dgv_config.Size = new System.Drawing.Size(729, 364);
            this.dgv_config.TabIndex = 9;
            // 
            // btn_apply
            // 
            this.btn_apply.Location = new System.Drawing.Point(332, 412);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(75, 23);
            this.btn_apply.TabIndex = 2;
            this.btn_apply.Text = "应用";
            this.btn_apply.UseVisualStyleBackColor = true;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // mailSendConfig
            // 
            this.mailSendConfig.Controls.Add(this.tb_mail_address);
            this.mailSendConfig.Controls.Add(this.label5);
            this.mailSendConfig.Controls.Add(this.btn_test_mail_send);
            this.mailSendConfig.Controls.Add(this.btn_del_mail_sender);
            this.mailSendConfig.Controls.Add(this.tb_port);
            this.mailSendConfig.Controls.Add(this.tb_username);
            this.mailSendConfig.Controls.Add(this.tb_password);
            this.mailSendConfig.Controls.Add(this.tb_host);
            this.mailSendConfig.Controls.Add(this.cb_enable_ssl);
            this.mailSendConfig.Controls.Add(this.label4);
            this.mailSendConfig.Controls.Add(this.label3);
            this.mailSendConfig.Controls.Add(this.label2);
            this.mailSendConfig.Controls.Add(this.label1);
            this.mailSendConfig.Controls.Add(this.btn_add_mail_sender);
            this.mailSendConfig.Controls.Add(this.btn_refresh_mail_sender);
            this.mailSendConfig.Controls.Add(this.dgv_mail_sender);
            this.mailSendConfig.Location = new System.Drawing.Point(4, 21);
            this.mailSendConfig.Name = "mailSendConfig";
            this.mailSendConfig.Size = new System.Drawing.Size(773, 466);
            this.mailSendConfig.TabIndex = 4;
            this.mailSendConfig.Text = "邮件发送账户设置";
            this.mailSendConfig.UseVisualStyleBackColor = true;
            // 
            // tb_mail_address
            // 
            this.tb_mail_address.Location = new System.Drawing.Point(506, 28);
            this.tb_mail_address.Name = "tb_mail_address";
            this.tb_mail_address.Size = new System.Drawing.Size(100, 21);
            this.tb_mail_address.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(441, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "邮箱地址:";
            // 
            // btn_test_mail_send
            // 
            this.btn_test_mail_send.Location = new System.Drawing.Point(480, 66);
            this.btn_test_mail_send.Name = "btn_test_mail_send";
            this.btn_test_mail_send.Size = new System.Drawing.Size(75, 23);
            this.btn_test_mail_send.TabIndex = 26;
            this.btn_test_mail_send.Text = "测试";
            this.btn_test_mail_send.UseVisualStyleBackColor = true;
            this.btn_test_mail_send.Click += new System.EventHandler(this.btn_test_mail_send_Click);
            // 
            // btn_del_mail_sender
            // 
            this.btn_del_mail_sender.Location = new System.Drawing.Point(642, 66);
            this.btn_del_mail_sender.Name = "btn_del_mail_sender";
            this.btn_del_mail_sender.Size = new System.Drawing.Size(75, 23);
            this.btn_del_mail_sender.TabIndex = 25;
            this.btn_del_mail_sender.Text = "删除";
            this.btn_del_mail_sender.UseVisualStyleBackColor = true;
            this.btn_del_mail_sender.Click += new System.EventHandler(this.btn_del_mail_sender_Click);
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(317, 28);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(100, 21);
            this.tb_port.TabIndex = 24;
            this.tb_port.Text = "25";
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(124, 68);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(132, 21);
            this.tb_username.TabIndex = 23;
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(317, 68);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(100, 21);
            this.tb_password.TabIndex = 22;
            // 
            // tb_host
            // 
            this.tb_host.Location = new System.Drawing.Point(124, 28);
            this.tb_host.Name = "tb_host";
            this.tb_host.Size = new System.Drawing.Size(132, 21);
            this.tb_host.TabIndex = 21;
            // 
            // cb_enable_ssl
            // 
            this.cb_enable_ssl.AutoSize = true;
            this.cb_enable_ssl.Checked = true;
            this.cb_enable_ssl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_enable_ssl.Location = new System.Drawing.Point(642, 27);
            this.cb_enable_ssl.Name = "cb_enable_ssl";
            this.cb_enable_ssl.Size = new System.Drawing.Size(66, 16);
            this.cb_enable_ssl.TabIndex = 20;
            this.cb_enable_ssl.Text = "启用SSL";
            this.cb_enable_ssl.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "用户名:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "端口:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "密码:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "SMTP服务器地址:";
            // 
            // btn_add_mail_sender
            // 
            this.btn_add_mail_sender.Location = new System.Drawing.Point(561, 66);
            this.btn_add_mail_sender.Name = "btn_add_mail_sender";
            this.btn_add_mail_sender.Size = new System.Drawing.Size(75, 23);
            this.btn_add_mail_sender.TabIndex = 15;
            this.btn_add_mail_sender.Text = "新增";
            this.btn_add_mail_sender.UseVisualStyleBackColor = true;
            this.btn_add_mail_sender.Click += new System.EventHandler(this.btn_add_mail_sender_Click);
            // 
            // btn_refresh_mail_sender
            // 
            this.btn_refresh_mail_sender.Location = new System.Drawing.Point(342, 409);
            this.btn_refresh_mail_sender.Name = "btn_refresh_mail_sender";
            this.btn_refresh_mail_sender.Size = new System.Drawing.Size(75, 23);
            this.btn_refresh_mail_sender.TabIndex = 10;
            this.btn_refresh_mail_sender.Text = "刷新";
            this.btn_refresh_mail_sender.UseVisualStyleBackColor = true;
            this.btn_refresh_mail_sender.Click += new System.EventHandler(this.btn_refresh_mail_sender_Click);
            // 
            // dgv_mail_sender
            // 
            this.dgv_mail_sender.AllowUserToAddRows = false;
            this.dgv_mail_sender.AllowUserToResizeColumns = false;
            this.dgv_mail_sender.AllowUserToResizeRows = false;
            this.dgv_mail_sender.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_mail_sender.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_mail_sender.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_mail_sender.Location = new System.Drawing.Point(23, 104);
            this.dgv_mail_sender.Name = "dgv_mail_sender";
            this.dgv_mail_sender.ReadOnly = true;
            this.dgv_mail_sender.RowTemplate.Height = 23;
            this.dgv_mail_sender.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_mail_sender.Size = new System.Drawing.Size(722, 284);
            this.dgv_mail_sender.TabIndex = 8;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 521);
            this.Controls.Add(this.mainTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Config";
            this.mainTab.ResumeLayout(false);
            this.setting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_config)).EndInit();
            this.mailSendConfig.ResumeLayout(false);
            this.mailSendConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mail_sender)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TabPage setting;
        private System.Windows.Forms.Button btn_apply;
        private System.Windows.Forms.TabPage mailSendConfig;
        private System.Windows.Forms.Button btn_refresh_mail_sender;
        private System.Windows.Forms.DataGridView dgv_mail_sender;
        private System.Windows.Forms.DataGridView dgv_config;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_add_mail_sender;
        private System.Windows.Forms.CheckBox cb_enable_ssl;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.TextBox tb_host;
        private System.Windows.Forms.Button btn_del_mail_sender;
        private System.Windows.Forms.Button btn_test_mail_send;
        private System.Windows.Forms.TextBox tb_mail_address;
        private System.Windows.Forms.Label label5;
    }
}