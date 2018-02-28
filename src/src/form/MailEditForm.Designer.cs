namespace com.soeasystem.spider.src.form
{
    partial class MailEditForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailEditForm));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tv_mail = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dgv_mail_list = new DevExpress.XtraGrid.GridControl();
            this.grid_mail_list = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cb_mail_status = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btn_select = new DevExpress.XtraEditors.SimpleButton();
            this.btn_query = new DevExpress.XtraEditors.SimpleButton();
            this.tb_search = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tv_mail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mail_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_mail_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_mail_status.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_search.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tv_mail);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl2);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(872, 353);
            this.splitContainerControl1.SplitterPosition = 177;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // tv_mail
            // 
            this.tv_mail.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.tv_mail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_mail.Location = new System.Drawing.Point(0, 0);
            this.tv_mail.Name = "tv_mail";
            this.tv_mail.OptionsBehavior.Editable = false;
            this.tv_mail.OptionsView.ShowHorzLines = false;
            this.tv_mail.OptionsView.ShowIndicator = false;
            this.tv_mail.OptionsView.ShowVertLines = false;
            this.tv_mail.SelectImageList = this.imageCollection;
            this.tv_mail.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowOnlyInEditor;
            this.tv_mail.Size = new System.Drawing.Size(177, 353);
            this.tv_mail.TabIndex = 0;
            this.tv_mail.AfterFocusNode += new DevExpress.XtraTreeList.NodeEventHandler(this.tv_mail_AfterFocusNode);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "邮箱一览";
            this.treeListColumn1.FieldName = "text";
            this.treeListColumn1.MinWidth = 52;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.dgv_mail_list);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 65);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(690, 288);
            this.panelControl2.TabIndex = 1;
            // 
            // dgv_mail_list
            // 
            this.dgv_mail_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_mail_list.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.dgv_mail_list.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.dgv_mail_list.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.dgv_mail_list.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.dgv_mail_list.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dgv_mail_list_EmbeddedNavigator_ButtonClick);
            this.dgv_mail_list.Location = new System.Drawing.Point(2, 2);
            this.dgv_mail_list.MainView = this.grid_mail_list;
            this.dgv_mail_list.Name = "dgv_mail_list";
            this.dgv_mail_list.Size = new System.Drawing.Size(686, 284);
            this.dgv_mail_list.TabIndex = 0;
            this.dgv_mail_list.UseEmbeddedNavigator = true;
            this.dgv_mail_list.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grid_mail_list});
            // 
            // grid_mail_list
            // 
            this.grid_mail_list.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.grid_mail_list.GridControl = this.dgv_mail_list;
            this.grid_mail_list.Name = "grid_mail_list";
            this.grid_mail_list.OptionsSelection.MultiSelect = true;
            this.grid_mail_list.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "邮箱地址";
            this.gridColumn1.FieldName = "mail_address";
            this.gridColumn1.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "类别";
            this.gridColumn2.FieldName = "type";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "发送次数";
            this.gridColumn3.FieldName = "send_cnt";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "创建时间";
            this.gridColumn4.FieldName = "create_date";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "发送时间";
            this.gridColumn5.FieldName = "send_date";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "编号";
            this.gridColumn6.FieldName = "id";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cb_mail_status);
            this.panelControl1.Controls.Add(this.btn_select);
            this.panelControl1.Controls.Add(this.btn_query);
            this.panelControl1.Controls.Add(this.tb_search);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(690, 65);
            this.panelControl1.TabIndex = 0;
            // 
            // cb_mail_status
            // 
            this.cb_mail_status.Location = new System.Drawing.Point(192, 9);
            this.cb_mail_status.Name = "cb_mail_status";
            this.cb_mail_status.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cb_mail_status.Properties.Items.AddRange(new object[] {
            "全部",
            "已发送",
            "未发送"});
            this.cb_mail_status.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cb_mail_status.Size = new System.Drawing.Size(182, 20);
            this.cb_mail_status.TabIndex = 6;
            this.cb_mail_status.SelectedIndexChanged += new System.EventHandler(this.cb_mail_status_SelectedIndexChanged);
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(495, 5);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(75, 53);
            this.btn_select.TabIndex = 5;
            this.btn_select.Text = "选择";
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(395, 5);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(75, 53);
            this.btn_query.TabIndex = 4;
            this.btn_query.Text = "查询";
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // tb_search
            // 
            this.tb_search.Location = new System.Drawing.Point(192, 38);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(182, 20);
            this.tb_search.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(134, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "查询条件:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(134, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "发件状态:";
            // 
            // cardView1
            // 
            this.cardView1.FocusedCardTopFieldIndex = 0;
            this.cardView1.Name = "cardView1";
            // 
            // MailEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 353);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "MailEditForm";
            this.Text = "MailEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tv_mail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mail_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_mail_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_mail_status.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_search.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTreeList.TreeList tv_mail;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
        private DevExpress.XtraGrid.GridControl dgv_mail_list;
        private DevExpress.XtraGrid.Views.Grid.GridView grid_mail_list;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit tb_search;
        private DevExpress.XtraEditors.SimpleButton btn_query;
        private DevExpress.XtraEditors.SimpleButton btn_select;
        private DevExpress.XtraEditors.ComboBoxEdit cb_mail_status;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}