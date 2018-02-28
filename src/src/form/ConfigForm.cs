using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.soeasystem.spider.src.service;
using com.soeasystem.spider.src.utils;

namespace com.soeasystem.spider
{
    public partial class ConfigForm : Form
    {
        private MailService mailService = new MailService();

        private MailSendService mailSendService = new MailSendService();

        public ConfigForm()
        {
            InitializeComponent();

            //init dgv_config
            {
                dgv_config.DataSource = ConfigService.show();
                dgv_config.Columns["name"].Visible = false;
                dgv_config.Columns["comments"].ReadOnly = true;
            }

            //init dgv_mail_sender
            btn_refresh_mail_sender_Click(null, null);
        }

        public void refresh()
        {
            dgv_config.DataSource = ConfigService.show();
        }

        private void btn_refresh_mail_sender_Click(object sender, EventArgs e)
        {
            dgv_mail_sender.DataSource = mailSendService.getAll();
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_config.Rows)
            {
                ConfigService.update((String)row.Cells["name"].Value, (String)row.Cells["value"].Value);
            }

            ThreadPoolEx.maxThread(Convert.ToInt32(ConfigService.get("thread.maxCnt")));

            MessageBox.Show("配置修改完成~");
        }

        private void btn_add_mail_sender_Click(object sender, EventArgs e)
        {
            if ("".Equals(tb_host.Text.Trim()))
            {
                MessageBox.Show("SMTP服务器地址不允许为空");
                return;
            }
            if ("".Equals(tb_port.Text.Trim()))
            {
                MessageBox.Show("SMTP服务器端口不允许为空");
                return;
            }
            if (!CommonUtils.isNumber(tb_port.Text.Trim()))
            {
                MessageBox.Show("SMTP服务器端口只能为数字");
                return;
            }
            if ("".Equals(tb_username.Text.Trim()))
            {
                MessageBox.Show("用户名不允许为空");
                return;
            }
            if ("".Equals(tb_password.Text.Trim()))
            {
                MessageBox.Show("密码不允许为空");
                return;
            }
            mailSendService.add(tb_host.Text.Trim(), Convert.ToInt32(tb_port.Text.Trim()), tb_username.Text.Trim(), tb_password.Text.Trim(), cb_enable_ssl.Checked, tb_mail_address.Text);
        }

        private void btn_del_mail_sender_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgv_mail_sender.SelectedRows)
            {
                mailSendService.remove(Convert.ToInt32(dr.Cells["id"].Value));
            }

            btn_refresh_mail_sender_Click(sender, e);
        }

        private void btn_test_mail_send_Click(object sender, EventArgs e)
        {
            MessageBox.Show(mailSendService.testMail(tb_host.Text.Trim(), Convert.ToInt32(tb_port.Text.Trim()), tb_username.Text.Trim(), tb_password.Text.Trim(), cb_enable_ssl.Checked, tb_mail_address.Text));
        }
    }
}
