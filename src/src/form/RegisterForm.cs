using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.soeasystem.spider.src.utils;
using com.soeasystem.spider.src.service;
using System.Net.Mail;
using System.IO;
using mailSpider;

namespace com.soeasystem.spider
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            if (File.Exists(SystemUtils.getCurrentPath() + "\\license.info"))
            {
                //0:company_name,1:end_date,2:version_type,3:mail,4:tel
                String[] info = FileUtils.read("license.info").Split('#');

                tb_companyName.Text = info[0];
                chk_isFull.Checked = info[2].Equals("FULL");
                tb_mailName.Text = info[3];
                tb_telName.Text = info[4];
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ("".Equals(tb_companyName.Text.Trim()))
            {
                MessageBox.Show("公司名不能为空");
                return;
            }

            if (tb_companyName.Text.Trim().IndexOf("@") > -1 || tb_companyName.Text.Trim().IndexOf("#") > -1 || tb_companyName.Text.Trim().IndexOf("|") > -1)
            {
                MessageBox.Show("公司名不能为特殊字符");
                return;
            }

            if ("".Equals(tb_mailName.Text.Trim()))
            {
                MessageBox.Show("邮箱名与电话不能都为空,后续软件升级信息将通过邮箱发送至您~");
                return;
            }

            if (tb_mailName.Text.Trim().Length > 40)
            {
                MessageBox.Show("邮箱名太长,不符合规范");
                return;
            }

            if (tb_companyName.Text.Trim().IndexOf("#") > -1)
            {
                MessageBox.Show("邮箱名不能含特殊字符#");
                return;
            }

            if ("".Equals(tb_telName.Text.Trim()))
            {
                MessageBox.Show("电话不能都为空");
                return;
            }
            if (tb_telName.Text.Trim().IndexOf("#") > -1)
            {
                MessageBox.Show("电话不能含特殊字符#");
                return;
            }

            if (tb_telName.Text.Trim().Length > 30)
            {
                MessageBox.Show("电话太长,不符合规范");
                return;
            }

            String key = "";

            try
            {
                String versionType = chk_isFull.Checked ? "FULL" : "TRIAL";

                String companyName = tb_companyName.Text.Trim();

                String mail = tb_mailName.Text.Trim();

                String tel = tb_telName.Text.Trim();

                String startDate = "1900-01-01";

                String endDate = null;

                //试用期1天
                if (chk_isFull.Checked)
                {
                    endDate = "2020-01-01";
                }
                else
                {
                    endDate = Convert.ToDateTime(DateUtils.getRealSysDate().Substring(0, 10)).AddDays(1).ToString("yyyy-MM-dd");
                }

                //写入注册信息
                FileUtils.write("license.info", companyName + "#" + endDate + "#" + versionType + "#" + mail + "#" + tel);

                HardDiskInfo hardDiskInfo = HardInfoUtils.getDiskInfo(0);

                key = RegisterService.encode(RegisterService.getRegisterString(companyName, startDate, endDate, HardInfoUtils.getCpuSerialNumber(), hardDiskInfo.SerialNumber, Convert.ToString(hardDiskInfo.Capacity), versionType));

                //发送邮件
                {
                    SmtpClient client = new SmtpClient("smtp.263.net", 25);
                    client.EnableSsl = false;
                    client.Credentials = new System.Net.NetworkCredential("sta_sales10", "911911ds");

                    String mailContent = "邮箱:" + mail + Environment.NewLine;
                    mailContent += "电话:" + tel + Environment.NewLine;
                    mailContent += "注册信息:" + key;

                    MailMessage mailMessage = new MailMessage("sta_sales10@263.net", "mailspider@soeasystem.com", tb_companyName.Text, mailContent);

                    //设置邮件的格式           
                    mailMessage.IsBodyHtml = false;

                    //设置邮件的发送级别
                    mailMessage.Priority = MailPriority.Normal;
                    //FileUtils.write("license.sign", key);
                    client.Send(mailMessage);
                }

                MessageBox.Show("申请提交成功");
            }
            catch (Exception ex)
            {
                FileUtils.write("license.sign", key);
                MessageBox.Show("申请提交失败:" + ex.Message);
            }

            this.Close();
        }
    }
}
