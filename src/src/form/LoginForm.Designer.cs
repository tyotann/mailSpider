namespace com.soeasystem.spider.src.form
{
    partial class LoginForm
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
            this.pb_process = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // pb_process
            // 
            this.pb_process.Location = new System.Drawing.Point(12, 204);
            this.pb_process.Name = "pb_process";
            this.pb_process.Size = new System.Drawing.Size(784, 19);
            this.pb_process.TabIndex = 0;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 273);
            this.ControlBox = false;
            this.Controls.Add(this.pb_process);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pb_process;
    }
}