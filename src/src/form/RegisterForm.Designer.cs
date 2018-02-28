namespace com.soeasystem.spider
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tb_companyName = new System.Windows.Forms.TextBox();
            this.chk_isFull = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_mailName = new System.Windows.Forms.TextBox();
            this.tb_telName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "公司名:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(153, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "提交申请";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_companyName
            // 
            this.tb_companyName.Location = new System.Drawing.Point(128, 28);
            this.tb_companyName.Name = "tb_companyName";
            this.tb_companyName.Size = new System.Drawing.Size(193, 21);
            this.tb_companyName.TabIndex = 3;
            // 
            // chk_isFull
            // 
            this.chk_isFull.AutoSize = true;
            this.chk_isFull.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_isFull.Checked = true;
            this.chk_isFull.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_isFull.Location = new System.Drawing.Point(77, 76);
            this.chk_isFull.Name = "chk_isFull";
            this.chk_isFull.Size = new System.Drawing.Size(60, 16);
            this.chk_isFull.TabIndex = 6;
            this.chk_isFull.Text = "正式版";
            this.chk_isFull.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "联系人邮箱:";
            // 
            // tb_mailName
            // 
            this.tb_mailName.Location = new System.Drawing.Point(128, 114);
            this.tb_mailName.Name = "tb_mailName";
            this.tb_mailName.Size = new System.Drawing.Size(193, 21);
            this.tb_mailName.TabIndex = 8;
            // 
            // tb_telName
            // 
            this.tb_telName.Location = new System.Drawing.Point(128, 155);
            this.tb_telName.Name = "tb_telName";
            this.tb_telName.Size = new System.Drawing.Size(193, 21);
            this.tb_telName.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "联系人电话:";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 272);
            this.Controls.Add(this.tb_telName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_mailName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chk_isFull);
            this.Controls.Add(this.tb_companyName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册页面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_companyName;
        private System.Windows.Forms.CheckBox chk_isFull;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_mailName;
        private System.Windows.Forms.TextBox tb_telName;
        private System.Windows.Forms.Label label4;
    }
}