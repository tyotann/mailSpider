using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace com.soeasystem.spider.src.form
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private URLEngineForm engineSearchForm = new URLEngineForm();

        private MailEditForm mailEditForm = new MailEditForm();

        public MainForm()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            showFormAsChild(engineSearchForm, iframeControl);
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            showFormAsChild(mailEditForm, iframeControl);
        }


        private void showFormAsChild(Form childFrom, PanelControl control)
        {
            control.Controls.Clear();

            childFrom.FormBorderStyle = FormBorderStyle.None;
            childFrom.TopLevel = false;
            childFrom.Parent = control;
            childFrom.Dock = DockStyle.Fill;
            childFrom.Show();
            //childFrom.BringToFront();
            childFrom.Focus();
        }

    }
}