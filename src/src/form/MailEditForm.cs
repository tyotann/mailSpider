using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.soeasystem.spider.src.service;
using System.Collections;
using DevExpress.XtraTreeList.Nodes;

namespace com.soeasystem.spider.src.form
{
    public partial class MailEditForm : DevExpress.XtraEditors.XtraForm
    {
        private static MailService mailService = new MailService();

        public void isModifyMode()
        {
            grid_mail_list.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            grid_mail_list.OptionsBehavior.ReadOnly = false;
            btn_select.Visible = false;
        }

        public void isSelectMode()
        {
            grid_mail_list.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            grid_mail_list.OptionsBehavior.ReadOnly = true;
            btn_select.Visible = true;
        }

        public MailEditForm()
        {
            InitializeComponent();

            cb_mail_status.SelectedIndex = 2;
        }

        private Constant.MailSendType getSendType()
        {
            Constant.MailSendType sendType = Constant.MailSendType.ALL;

            if ("未发送".Equals(cb_mail_status.Text))
            {
                sendType = Constant.MailSendType.UN_SEND;
            }
            else if ("已发送".Equals(cb_mail_status.Text))
            {
                sendType = Constant.MailSendType.SENDED;
            }

            return sendType;
        }

        private void cb_mail_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            tv_mail.BeginUnboundLoad();

            DataTable dt = mailService.getStatistical(getSendType());

            //tv_mail.Nodes[0].Nodes["root"].Nodes.Clear();

            Dictionary<String, TreeListNode> typeNodeDic = new Dictionary<String, TreeListNode>();

            tv_mail.ClearNodes();

            foreach (DataRow dr in dt.Rows)
            {
                String type = Convert.ToString(dr["type"]);

                String createDate = Convert.ToString(dr["create_date"]);

                Hashtable param = new Hashtable();
                param.Add("type", type);

                TreeListNode typeNode = typeNodeDic.ContainsKey(type) ? typeNodeDic[type] : null;

                if (typeNode == null)
                {
                    typeNode = tv_mail.AppendNode(param, null);
                    typeNode.SetValue("text", type);
                    typeNode.Tag = param.Clone();
                    typeNode.SelectImageIndex = 1;
                    typeNodeDic.Add(type, typeNode);
                }

                param.Add("create_date", createDate);

                TreeListNode dateNode = tv_mail.AppendNode(param, typeNode.Id);
                dateNode.SelectImageIndex = 1;
                dateNode.SetValue("text", createDate + "(" + Convert.ToString(dr["num"]) + ")");
                dateNode.Tag = param;
            }

            tv_mail.Nodes.FirstNode.ExpandAll();

            tv_mail.EndUnboundLoad();
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            String type = null;

            String createDate = null;

            if (tv_mail.FocusedNode != null && tv_mail.FocusedNode.Tag != null)
            {
                Hashtable treeEntity = (Hashtable)tv_mail.FocusedNode.Tag;
                type = Convert.ToString(treeEntity["type"]);
                createDate = Convert.ToString(treeEntity["create_date"]);
            }

            if (type != null)
            {
                DataTable dt = mailService.get(type, createDate, getSendType(), tb_search.Text.Trim());

                dt.Columns["id"].AllowDBNull = true;
                dgv_mail_list.DataSource = dt;



                //lb_mail_list_cnt.Text = Convert.ToString(dt.Rows.Count);
            }

        }

        private void tv_mail_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            btn_query_Click(sender, e);
        }

        private void dgv_mail_list_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Append)
            {
                /**
                try
                {
                    if (!string.IsNullOrEmpty(glucInvCName.EditValue.ToString()))
                    {
                        e.Handled = true;//取消默认新增事件
                        grvPPintervalDetail.AddNewRow();
                        int lineNum = grvPPintervalDetail.RowCount;
                        grvPPintervalDetail.RefreshData();
                        grvPPintervalDetail.MoveLast();
                        string code = "";
                        if ((1 < lineNum || lineNum == 1) && (lineNum < 9 || lineNum == 9))
                        {
                            code = "00" + lineNum;
                        }
                        if (10 <= lineNum)
                        {
                            code = "0" + lineNum;
                        }
                        grvPPintervalDetail.SetFocusedRowCellValue(grvPPintervalDetail.Columns["PPIntervalCode"], (glucInvCName.EditValue.ToString() + code).ToString());
                 * */
                 
            }
            else if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
            }
            else if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.EndEdit)
            {
               
            }
            else if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.CancelEdit)
            {
                
            }
            //btn_query_Click(sender, e);
        }

    }
}