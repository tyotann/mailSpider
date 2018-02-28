namespace com.soeasystem.spider
{
    partial class MailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailForm));
            this.btn_del_mail = new System.Windows.Forms.Button();
            this.cb_mail_send_attach = new System.Windows.Forms.ComboBox();
            this.btn_mail_sender_add_attach = new System.Windows.Forms.Button();
            this.rtb_mail_send_content = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_mail_send_title = new System.Windows.Forms.TextBox();
            this.btn_send_mail = new System.Windows.Forms.Button();
            this.btn_search_mail = new System.Windows.Forms.Button();
            this.lb_mail_cnt = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_mail = new System.Windows.Forms.ComboBox();
            this.dgv_mail = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_mail_status = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_mail_list_cnt = new System.Windows.Forms.Label();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_select = new System.Windows.Forms.Button();
            this.tv_mail = new System.Windows.Forms.TreeView();
            this.dgv_mail_list = new System.Windows.Forms.DataGridView();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mail_list)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_del_mail
            // 
            this.btn_del_mail.Location = new System.Drawing.Point(334, 22);
            this.btn_del_mail.Name = "btn_del_mail";
            this.btn_del_mail.Size = new System.Drawing.Size(44, 23);
            this.btn_del_mail.TabIndex = 24;
            this.btn_del_mail.Text = "删除";
            this.btn_del_mail.UseVisualStyleBackColor = true;
            // 
            // cb_mail_send_attach
            // 
            this.cb_mail_send_attach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_mail_send_attach.FormattingEnabled = true;
            this.cb_mail_send_attach.Location = new System.Drawing.Point(518, 58);
            this.cb_mail_send_attach.Name = "cb_mail_send_attach";
            this.cb_mail_send_attach.Size = new System.Drawing.Size(236, 20);
            this.cb_mail_send_attach.TabIndex = 23;
            // 
            // btn_mail_sender_add_attach
            // 
            this.btn_mail_sender_add_attach.Location = new System.Drawing.Point(415, 55);
            this.btn_mail_sender_add_attach.Name = "btn_mail_sender_add_attach";
            this.btn_mail_sender_add_attach.Size = new System.Drawing.Size(75, 23);
            this.btn_mail_sender_add_attach.TabIndex = 21;
            this.btn_mail_sender_add_attach.Text = "添加附件";
            this.btn_mail_sender_add_attach.UseVisualStyleBackColor = true;
            // 
            // rtb_mail_send_content
            // 
            this.rtb_mail_send_content.Location = new System.Drawing.Point(415, 90);
            this.rtb_mail_send_content.Name = "rtb_mail_send_content";
            this.rtb_mail_send_content.Size = new System.Drawing.Size(339, 297);
            this.rtb_mail_send_content.TabIndex = 20;
            this.rtb_mail_send_content.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(413, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "主题:";
            // 
            // tb_mail_send_title
            // 
            this.tb_mail_send_title.Location = new System.Drawing.Point(454, 23);
            this.tb_mail_send_title.Name = "tb_mail_send_title";
            this.tb_mail_send_title.Size = new System.Drawing.Size(300, 21);
            this.tb_mail_send_title.TabIndex = 16;
            // 
            // btn_send_mail
            // 
            this.btn_send_mail.Location = new System.Drawing.Point(542, 395);
            this.btn_send_mail.Name = "btn_send_mail";
            this.btn_send_mail.Size = new System.Drawing.Size(75, 23);
            this.btn_send_mail.TabIndex = 15;
            this.btn_send_mail.Text = "发送邮件";
            this.btn_send_mail.UseVisualStyleBackColor = true;
            // 
            // btn_search_mail
            // 
            this.btn_search_mail.Location = new System.Drawing.Point(280, 22);
            this.btn_search_mail.Name = "btn_search_mail";
            this.btn_search_mail.Size = new System.Drawing.Size(44, 23);
            this.btn_search_mail.TabIndex = 14;
            this.btn_search_mail.Text = "查询";
            this.btn_search_mail.UseVisualStyleBackColor = true;
            // 
            // lb_mail_cnt
            // 
            this.lb_mail_cnt.AutoSize = true;
            this.lb_mail_cnt.Location = new System.Drawing.Point(241, 26);
            this.lb_mail_cnt.Name = "lb_mail_cnt";
            this.lb_mail_cnt.Size = new System.Drawing.Size(11, 12);
            this.lb_mail_cnt.TabIndex = 13;
            this.lb_mail_cnt.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(176, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "邮箱个数:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "发件状态:";
            // 
            // cb_mail
            // 
            this.cb_mail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_mail.FormattingEnabled = true;
            this.cb_mail.Items.AddRange(new object[] {
            "",
            "未发件",
            "已发件"});
            this.cb_mail.Location = new System.Drawing.Point(80, 23);
            this.cb_mail.MaxDropDownItems = 99;
            this.cb_mail.Name = "cb_mail";
            this.cb_mail.Size = new System.Drawing.Size(84, 20);
            this.cb_mail.TabIndex = 10;
            // 
            // dgv_mail
            // 
            this.dgv_mail.AllowUserToAddRows = false;
            this.dgv_mail.AllowUserToDeleteRows = false;
            this.dgv_mail.AllowUserToResizeColumns = false;
            this.dgv_mail.AllowUserToResizeRows = false;
            this.dgv_mail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_mail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_mail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_mail.Location = new System.Drawing.Point(17, 58);
            this.dgv_mail.Name = "dgv_mail";
            this.dgv_mail.ReadOnly = true;
            this.dgv_mail.RowTemplate.Height = 23;
            this.dgv_mail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_mail.Size = new System.Drawing.Size(361, 360);
            this.dgv_mail.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "发件状态:";
            // 
            // cb_mail_status
            // 
            this.cb_mail_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_mail_status.Items.AddRange(new object[] {
            "全部",
            "未发件",
            "已发件"});
            this.cb_mail_status.Location = new System.Drawing.Point(84, 9);
            this.cb_mail_status.MaxDropDownItems = 99;
            this.cb_mail_status.Name = "cb_mail_status";
            this.cb_mail_status.Size = new System.Drawing.Size(103, 20);
            this.cb_mail_status.TabIndex = 13;
            this.cb_mail_status.SelectedIndexChanged += new System.EventHandler(this.cb_mail_status_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(533, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "邮箱个数:";
            // 
            // lb_mail_list_cnt
            // 
            this.lb_mail_list_cnt.AutoSize = true;
            this.lb_mail_list_cnt.Location = new System.Drawing.Point(598, 15);
            this.lb_mail_list_cnt.Name = "lb_mail_list_cnt";
            this.lb_mail_list_cnt.Size = new System.Drawing.Size(11, 12);
            this.lb_mail_list_cnt.TabIndex = 15;
            this.lb_mail_list_cnt.Text = "0";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(442, 7);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(62, 23);
            this.btn_refresh.TabIndex = 17;
            this.btn_refresh.Text = "查询";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(673, 7);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(75, 23);
            this.btn_select.TabIndex = 19;
            this.btn_select.Text = "选择";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // tv_mail
            // 
            this.tv_mail.Location = new System.Drawing.Point(20, 38);
            this.tv_mail.Name = "tv_mail";
            this.tv_mail.Size = new System.Drawing.Size(168, 460);
            this.tv_mail.TabIndex = 20;
            this.tv_mail.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_mail_AfterSelect);
            // 
            // dgv_mail_list
            // 
            this.dgv_mail_list.AllowUserToResizeColumns = false;
            this.dgv_mail_list.AllowUserToResizeRows = false;
            this.dgv_mail_list.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_mail_list.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_mail_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_mail_list.Location = new System.Drawing.Point(204, 38);
            this.dgv_mail_list.Name = "dgv_mail_list";
            this.dgv_mail_list.RowTemplate.Height = 23;
            this.dgv_mail_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_mail_list.Size = new System.Drawing.Size(582, 460);
            this.dgv_mail_list.TabIndex = 21;
            this.dgv_mail_list.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_mail_list_CellValueChanged);
            this.dgv_mail_list.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgv_mail_list_UserDeletingRow);
            this.dgv_mail_list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_mail_list_KeyDown);
            // 
            // tb_search
            // 
            this.tb_search.Location = new System.Drawing.Point(281, 9);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(131, 21);
            this.tb_search.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "查询条件:";
            // 
            // MailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(805, 514);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_search);
            this.Controls.Add(this.dgv_mail_list);
            this.Controls.Add(this.tv_mail);
            this.Controls.Add(this.btn_select);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.lb_mail_list_cnt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_mail_status);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MailForm";
            this.Text = "MailForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mail_list)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_del_mail;
        private System.Windows.Forms.ComboBox cb_mail_send_attach;
        private System.Windows.Forms.Button btn_mail_sender_add_attach;
        private System.Windows.Forms.RichTextBox rtb_mail_send_content;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_mail_send_title;
        private System.Windows.Forms.Button btn_send_mail;
        private System.Windows.Forms.Button btn_search_mail;
        private System.Windows.Forms.Label lb_mail_cnt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_mail;
        private System.Windows.Forms.DataGridView dgv_mail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_mail_status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_mail_list_cnt;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.TreeView tv_mail;
        private System.Windows.Forms.DataGridView dgv_mail_list;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.Label label4;
    }
}