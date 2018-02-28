using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.soeasystem.spider.src.service;
using com.soeasystem.spider.src;
using System.Collections;

namespace com.soeasystem.spider
{
    public partial class MailForm : Form
    {
        private static MailService mailService = new MailService();

        public void isModifyMode()
        {
            dgv_mail_list.AllowUserToAddRows = true;
            dgv_mail_list.ReadOnly = false;
            btn_select.Visible = false;
        }

        public void isSelectMode()
        {
            dgv_mail_list.AllowUserToAddRows = false;
            dgv_mail_list.ReadOnly = true;
            btn_select.Visible = true;
        }

        public MailForm()
        {
            InitializeComponent();

            tv_mail.Nodes.Add("root", "全部");

            cb_mail_status.SelectedIndex = 1;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            String type = null;

            String createDate = null;

            if (tv_mail.SelectedNode != null && tv_mail.SelectedNode.Tag != null)
            {
                Hashtable treeEntity = (Hashtable)tv_mail.SelectedNode.Tag;
                type = Convert.ToString(treeEntity["type"]);
                createDate = Convert.ToString(treeEntity["create_date"]);
            }

            if (type != null)
            {
                DataTable dt = mailService.get(type, createDate, getSendType(), tb_search.Text.Trim());

                dt.Columns["id"].AllowDBNull = true;
                dgv_mail_list.DataSource = dt;

                dgv_mail_list.Columns["id"].Visible = false;
                dgv_mail_list.Columns["create_type"].Visible = false;
                dgv_mail_list.Columns["type"].ReadOnly = true;
                dgv_mail_list.Columns["send_cnt"].ReadOnly = true;
                dgv_mail_list.Columns["create_date"].ReadOnly = true;
                dgv_mail_list.Columns["send_date"].ReadOnly = true;

                dgv_mail_list.Columns["mail_address"].HeaderText = "邮箱地址";
                dgv_mail_list.Columns["type"].HeaderText = "类别";
                dgv_mail_list.Columns["send_cnt"].HeaderText = "发送次数";
                dgv_mail_list.Columns["create_date"].HeaderText = "创建时间";
                dgv_mail_list.Columns["send_date"].HeaderText = "发送时间";

                lb_mail_list_cnt.Text = Convert.ToString(dt.Rows.Count);
            }

        }

        private Constant.MailSendType getSendType()
        {

            Constant.MailSendType sendType = Constant.MailSendType.ALL;

            if ("未发件".Equals(cb_mail_status.Text))
            {
                sendType = Constant.MailSendType.UN_SEND;
            }
            else if ("已发件".Equals(cb_mail_status.Text))
            {
                sendType = Constant.MailSendType.SENDED;
            }

            return sendType;
        }

        private void cb_mail_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = mailService.getStatistical(getSendType());

            tv_mail.Nodes["root"].Nodes.Clear();

            Dictionary<String, TreeNode> typeNodeDic = new Dictionary<String, TreeNode>();

            foreach (DataRow dr in dt.Rows)
            {
                String type = Convert.ToString(dr["type"]);

                String createDate = Convert.ToString(dr["create_date"]);

                Hashtable param = new Hashtable();
                param.Add("type", type);

                TreeNode typeNode = typeNodeDic.ContainsKey(type) ? typeNodeDic[type] : null;

                if (typeNode == null)
                {
                    typeNode = new TreeNode(type);
                    typeNode.Tag = param.Clone();
                    tv_mail.Nodes["root"].Nodes.Add(typeNode);
                    typeNodeDic.Add(type, typeNode);
                }

                param.Add("create_date", createDate);

                TreeNode dateNode = new TreeNode(createDate + "(" + Convert.ToString(dr["num"]) + ")"); ;
                dateNode.Tag = param;
                typeNode.Nodes.Add(dateNode);
            }


            tv_mail.Nodes["root"].ExpandAll();

            btn_refresh_Click(sender, e);
        }

        private void tv_mail_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btn_refresh_Click(sender, e);
        }

        private void dgv_mail_list_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dgv_mail_list.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否删除这些邮箱?", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    foreach (DataGridViewRow dgvr in dgv_mail_list.SelectedRows)
                    {
                        mailService.remove(Convert.ToString(dgvr.Cells["id"].Value));
                    }
                }
            }

            e.Cancel = true;

            btn_refresh_Click(sender, e);
        }

        private void dgv_mail_list_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvr = dgv_mail_list.SelectedRows[0];

            String mailAddress = Convert.ToString(dgvr.Cells["mail_address"].Value);

            String id = Convert.ToString(dgvr.Cells["id"].Value);

            if ("".Equals(id))
            {

                String type = "";

                if (tv_mail.SelectedNode != null && tv_mail.SelectedNode.Tag != null)
                {
                    type = Convert.ToString(((Hashtable)tv_mail.SelectedNode.Tag)["type"]);
                }

                if ("".Equals(type))
                {
                    MessageBox.Show("请选择左侧树的类别后再新增邮箱!");
                    return;
                }

                mailService.add(mailAddress, type);
            }
            else
            {
                mailService.update(Convert.ToString(dgvr.Cells["id"].Value), mailAddress);
            }

            btn_refresh_Click(sender, e);
        }

        private DataGridViewSelectedRowCollection selectRow = null;

        public DataGridViewSelectedRowCollection getSelectRow()
        {
            return selectRow;
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            selectRow = dgv_mail_list.SelectedRows;
            this.Close();
        }

        private void dgv_mail_list_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                e.Handled = true;
            }

        }




    }
}
