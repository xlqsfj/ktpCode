namespace KtpAcsMiddleware.WinForm.KtpLibrary
{
    partial class AuthenticationSyncList
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
            this.WorkerDetailMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerCms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.WorkerPushMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerUpAllAuthMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.FaceDevicesLb = new System.Windows.Forms.ListBox();
            this.FaceDevicesCms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.FaceDeviceReloadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AuthWorkersGridPager = new KtpAcsMiddleware.WinForm.UserControls.KtpGridPager();
            this.KtpSyncStatesCb = new System.Windows.Forms.ComboBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.AuthWorkersGrid = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentityCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SexText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuthenticationStateText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeedbackCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressNow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerCms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.FaceDevicesCms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AuthWorkersGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // WorkerDetailMenuItem
            // 
            this.WorkerDetailMenuItem.Name = "WorkerDetailMenuItem";
            this.WorkerDetailMenuItem.Size = new System.Drawing.Size(180, 22);
            this.WorkerDetailMenuItem.Text = "详细信息";
            this.WorkerDetailMenuItem.Click += new System.EventHandler(this.WorkerDetailMenuItem_Click);
            // 
            // WorkerCms
            // 
            this.WorkerCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WorkerDetailMenuItem,
            this.WorkerPushMenuItem,
            this.WorkerUpAllAuthMenuItem});
            this.WorkerCms.Name = "TeamsCms";
            this.WorkerCms.Size = new System.Drawing.Size(181, 92);
            // 
            // WorkerPushMenuItem
            // 
            this.WorkerPushMenuItem.Name = "WorkerPushMenuItem";
            this.WorkerPushMenuItem.Size = new System.Drawing.Size(180, 22);
            this.WorkerPushMenuItem.Text = "推送当前";
            this.WorkerPushMenuItem.Click += new System.EventHandler(this.WorkerPushMenuItem_Click);
            // 
            // WorkerUpAllAuthMenuItem
            // 
            this.WorkerUpAllAuthMenuItem.Name = "WorkerUpAllAuthMenuItem";
            this.WorkerUpAllAuthMenuItem.Size = new System.Drawing.Size(180, 22);
            this.WorkerUpAllAuthMenuItem.Text = "上传全部";
            this.WorkerUpAllAuthMenuItem.Click += new System.EventHandler(this.WorkerUpAllAuthMenuItem_Click);
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(0, 2);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(807, 26);
            this.SearchText.TabIndex = 16;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.FaceDevicesLb);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.AuthWorkersGridPager);
            this.splitContainer1.Panel2.Controls.Add(this.KtpSyncStatesCb);
            this.splitContainer1.Panel2.Controls.Add(this.SearchButton);
            this.splitContainer1.Panel2.Controls.Add(this.SearchText);
            this.splitContainer1.Panel2.Controls.Add(this.AuthWorkersGrid);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("宋体", 12F);
            this.splitContainer1.Size = new System.Drawing.Size(1333, 696);
            this.splitContainer1.SplitterDistance = 223;
            this.splitContainer1.TabIndex = 3;
            // 
            // FaceDevicesLb
            // 
            this.FaceDevicesLb.ContextMenuStrip = this.FaceDevicesCms;
            this.FaceDevicesLb.Font = new System.Drawing.Font("宋体", 12F);
            this.FaceDevicesLb.FormattingEnabled = true;
            this.FaceDevicesLb.ItemHeight = 16;
            this.FaceDevicesLb.Location = new System.Drawing.Point(0, 0);
            this.FaceDevicesLb.Name = "FaceDevicesLb";
            this.FaceDevicesLb.Size = new System.Drawing.Size(222, 692);
            this.FaceDevicesLb.TabIndex = 0;
            this.FaceDevicesLb.SelectedIndexChanged += new System.EventHandler(this.FaceDevicesLb_SelectedIndexChanged);
            // 
            // FaceDevicesCms
            // 
            this.FaceDevicesCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FaceDeviceReloadMenuItem});
            this.FaceDevicesCms.Name = "TeamsCms";
            this.FaceDevicesCms.Size = new System.Drawing.Size(101, 26);
            // 
            // FaceDeviceReloadMenuItem
            // 
            this.FaceDeviceReloadMenuItem.Name = "FaceDeviceReloadMenuItem";
            this.FaceDeviceReloadMenuItem.Size = new System.Drawing.Size(100, 22);
            this.FaceDeviceReloadMenuItem.Text = "刷新";
            this.FaceDeviceReloadMenuItem.Click += new System.EventHandler(this.FaceDeviceReloadMenuItem_Click);
            // 
            // AuthWorkersGridPager
            // 
            this.AuthWorkersGridPager.Location = new System.Drawing.Point(0, 665);
            this.AuthWorkersGridPager.Margin = new System.Windows.Forms.Padding(4);
            this.AuthWorkersGridPager.Name = "AuthWorkersGridPager";
            this.AuthWorkersGridPager.PageCount = 0;
            this.AuthWorkersGridPager.PageIndex = 1;
            this.AuthWorkersGridPager.PageSize = 10;
            this.AuthWorkersGridPager.PagingHandler = null;
            this.AuthWorkersGridPager.Size = new System.Drawing.Size(295, 25);
            this.AuthWorkersGridPager.TabIndex = 19;
            // 
            // KtpSyncStatesCb
            // 
            this.KtpSyncStatesCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KtpSyncStatesCb.FormattingEnabled = true;
            this.KtpSyncStatesCb.Location = new System.Drawing.Point(813, 3);
            this.KtpSyncStatesCb.Name = "KtpSyncStatesCb";
            this.KtpSyncStatesCb.Size = new System.Drawing.Size(151, 24);
            this.KtpSyncStatesCb.TabIndex = 18;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(967, 2);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(136, 26);
            this.SearchButton.TabIndex = 17;
            this.SearchButton.Text = "搜索";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // AuthWorkersGrid
            // 
            this.AuthWorkersGrid.AllowUserToAddRows = false;
            this.AuthWorkersGrid.AllowUserToDeleteRows = false;
            this.AuthWorkersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AuthWorkersGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AuthWorkersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AuthWorkersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.WorkerName,
            this.IdentityCode,
            this.Mobile,
            this.SexText,
            this.Nation,
            this.AuthenticationStateText,
            this.FeedbackCode,
            this.AddressNow,
            this.DeviceCode});
            this.AuthWorkersGrid.ContextMenuStrip = this.WorkerCms;
            this.AuthWorkersGrid.Location = new System.Drawing.Point(0, 32);
            this.AuthWorkersGrid.MultiSelect = false;
            this.AuthWorkersGrid.Name = "AuthWorkersGrid";
            this.AuthWorkersGrid.ReadOnly = true;
            this.AuthWorkersGrid.RowHeadersVisible = false;
            this.AuthWorkersGrid.RowHeadersWidth = 20;
            this.AuthWorkersGrid.RowTemplate.Height = 23;
            this.AuthWorkersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AuthWorkersGrid.Size = new System.Drawing.Size(1103, 630);
            this.AuthWorkersGrid.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // WorkerName
            // 
            this.WorkerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WorkerName.DataPropertyName = "WorkerName";
            this.WorkerName.FillWeight = 5F;
            this.WorkerName.HeaderText = "姓名";
            this.WorkerName.Name = "WorkerName";
            this.WorkerName.ReadOnly = true;
            // 
            // IdentityCode
            // 
            this.IdentityCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IdentityCode.DataPropertyName = "IdentityCode";
            this.IdentityCode.FillWeight = 8F;
            this.IdentityCode.HeaderText = "证件号";
            this.IdentityCode.Name = "IdentityCode";
            this.IdentityCode.ReadOnly = true;
            // 
            // Mobile
            // 
            this.Mobile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Mobile.DataPropertyName = "ClockTypeText";
            this.Mobile.FillWeight = 5F;
            this.Mobile.HeaderText = "打卡类型";
            this.Mobile.Name = "Mobile";
            this.Mobile.ReadOnly = true;
            // 
            // SexText
            // 
            this.SexText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SexText.DataPropertyName = "ClockTimeText";
            this.SexText.FillWeight = 6F;
            this.SexText.HeaderText = "打卡时间";
            this.SexText.Name = "SexText";
            this.SexText.ReadOnly = true;
            // 
            // Nation
            // 
            this.Nation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nation.DataPropertyName = "ClockStateText";
            this.Nation.FillWeight = 5F;
            this.Nation.HeaderText = "打卡状态";
            this.Nation.Name = "Nation";
            this.Nation.ReadOnly = true;
            // 
            // AuthenticationStateText
            // 
            this.AuthenticationStateText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AuthenticationStateText.DataPropertyName = "StateText";
            this.AuthenticationStateText.FillWeight = 5F;
            this.AuthenticationStateText.HeaderText = "同步状态";
            this.AuthenticationStateText.Name = "AuthenticationStateText";
            this.AuthenticationStateText.ReadOnly = true;
            // 
            // FeedbackCode
            // 
            this.FeedbackCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FeedbackCode.DataPropertyName = "FeedbackCode";
            this.FeedbackCode.FillWeight = 5F;
            this.FeedbackCode.HeaderText = "最近返回";
            this.FeedbackCode.Name = "FeedbackCode";
            this.FeedbackCode.ReadOnly = true;
            // 
            // AddressNow
            // 
            this.AddressNow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AddressNow.DataPropertyName = "Feedback";
            this.AddressNow.FillWeight = 8F;
            this.AddressNow.HeaderText = "最近返回信息";
            this.AddressNow.Name = "AddressNow";
            this.AddressNow.ReadOnly = true;
            // 
            // DeviceCode
            // 
            this.DeviceCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DeviceCode.DataPropertyName = "DeviceCode";
            this.DeviceCode.FillWeight = 5F;
            this.DeviceCode.HeaderText = "设备";
            this.DeviceCode.Name = "DeviceCode";
            this.DeviceCode.ReadOnly = true;
            // 
            // AuthenticationSyncList
            // 
            this.AcceptButton = this.SearchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 696);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AuthenticationSyncList";
            this.Text = "考勤同步";
            this.WorkerCms.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.FaceDevicesCms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AuthWorkersGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem WorkerDetailMenuItem;
        private System.Windows.Forms.ContextMenuStrip WorkerCms;
        private UserControls.KtpGridPager AuthWorkersGridPager;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox FaceDevicesLb;
        private System.Windows.Forms.ComboBox KtpSyncStatesCb;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DataGridView AuthWorkersGrid;
        private System.Windows.Forms.ToolStripMenuItem WorkerUpAllAuthMenuItem;
        private System.Windows.Forms.ContextMenuStrip FaceDevicesCms;
        private System.Windows.Forms.ToolStripMenuItem FaceDeviceReloadMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentityCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn SexText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nation;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuthenticationStateText;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeedbackCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressNow;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceCode;
        private System.Windows.Forms.ToolStripMenuItem WorkerPushMenuItem;
    }
}