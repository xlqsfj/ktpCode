namespace KtpAcsMiddleware.WinForm.FaceRecognition
{
    partial class FaceWorkerList
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
            this.FaceWorkerCms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.WorkerInitNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerInitNewDelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FaceWorkerStatesCb = new System.Windows.Forms.ComboBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.FaceDeviceDelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FaceDeviceAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FaceDeviceEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FaceDevicesCms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.FaceDeviceReloadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FaceDeviceBellMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FaceDeviceBellAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FaceWorkersAllInitNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FaceDevicesLb = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.FaceWorkersGrid = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentityCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SexText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressNow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuthenticationStateText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorCodeText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaceWorkersGridPager = new KtpAcsMiddleware.WinForm.UserControls.KtpGridPager();
            this.FaceWorkerCms.SuspendLayout();
            this.FaceDevicesCms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FaceWorkersGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // WorkerDetailMenuItem
            // 
            this.WorkerDetailMenuItem.Name = "WorkerDetailMenuItem";
            this.WorkerDetailMenuItem.Size = new System.Drawing.Size(136, 22);
            this.WorkerDetailMenuItem.Text = "工人信息";
            this.WorkerDetailMenuItem.Click += new System.EventHandler(this.WorkerDetailMenuItem_Click);
            // 
            // FaceWorkerCms
            // 
            this.FaceWorkerCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WorkerDetailMenuItem,
            this.WorkerInitNewMenuItem,
            this.WorkerInitNewDelMenuItem});
            this.FaceWorkerCms.Name = "TeamsCms";
            this.FaceWorkerCms.Size = new System.Drawing.Size(137, 70);
            // 
            // WorkerInitNewMenuItem
            // 
            this.WorkerInitNewMenuItem.Name = "WorkerInitNewMenuItem";
            this.WorkerInitNewMenuItem.Size = new System.Drawing.Size(136, 22);
            this.WorkerInitNewMenuItem.Text = "设为新添加";
            this.WorkerInitNewMenuItem.Click += new System.EventHandler(this.WorkerInitNewMenuItem_Click);
            // 
            // WorkerInitNewDelMenuItem
            // 
            this.WorkerInitNewDelMenuItem.Name = "WorkerInitNewDelMenuItem";
            this.WorkerInitNewDelMenuItem.Size = new System.Drawing.Size(136, 22);
            this.WorkerInitNewDelMenuItem.Text = "设为新删除";
            this.WorkerInitNewDelMenuItem.Click += new System.EventHandler(this.WorkerInitNewDelMenuItem_Click);
            // 
            // FaceWorkerStatesCb
            // 
            this.FaceWorkerStatesCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FaceWorkerStatesCb.FormattingEnabled = true;
            this.FaceWorkerStatesCb.Location = new System.Drawing.Point(810, 6);
            this.FaceWorkerStatesCb.Name = "FaceWorkerStatesCb";
            this.FaceWorkerStatesCb.Size = new System.Drawing.Size(151, 24);
            this.FaceWorkerStatesCb.TabIndex = 18;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(967, 5);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(136, 26);
            this.SearchButton.TabIndex = 17;
            this.SearchButton.Text = "搜索";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(0, 5);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(807, 26);
            this.SearchText.TabIndex = 16;
            // 
            // FaceDeviceDelMenuItem
            // 
            this.FaceDeviceDelMenuItem.Name = "FaceDeviceDelMenuItem";
            this.FaceDeviceDelMenuItem.Size = new System.Drawing.Size(184, 22);
            this.FaceDeviceDelMenuItem.Text = "删除";
            this.FaceDeviceDelMenuItem.Click += new System.EventHandler(this.FaceDeviceDelMenuItem_Click);
            // 
            // FaceDeviceAddMenuItem
            // 
            this.FaceDeviceAddMenuItem.Name = "FaceDeviceAddMenuItem";
            this.FaceDeviceAddMenuItem.Size = new System.Drawing.Size(184, 22);
            this.FaceDeviceAddMenuItem.Text = "添加";
            this.FaceDeviceAddMenuItem.Click += new System.EventHandler(this.FaceDeviceAddMenuItem_Click);
            // 
            // FaceDeviceEditMenuItem
            // 
            this.FaceDeviceEditMenuItem.Name = "FaceDeviceEditMenuItem";
            this.FaceDeviceEditMenuItem.Size = new System.Drawing.Size(184, 22);
            this.FaceDeviceEditMenuItem.Text = "编辑";
            this.FaceDeviceEditMenuItem.Click += new System.EventHandler(this.FaceDeviceEditMenuItem_Click);
            // 
            // FaceDevicesCms
            // 
            this.FaceDevicesCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FaceDeviceReloadMenuItem,
            this.FaceDeviceBellMenuItem,
            this.FaceDeviceEditMenuItem,
            this.FaceDeviceDelMenuItem,
            this.FaceDeviceAddMenuItem,
            this.FaceDeviceBellAllMenuItem,
            this.FaceWorkersAllInitNewMenuItem});
            this.FaceDevicesCms.Name = "TeamsCms";
            this.FaceDevicesCms.Size = new System.Drawing.Size(185, 158);
            // 
            // FaceDeviceReloadMenuItem
            // 
            this.FaceDeviceReloadMenuItem.Name = "FaceDeviceReloadMenuItem";
            this.FaceDeviceReloadMenuItem.Size = new System.Drawing.Size(184, 22);
            this.FaceDeviceReloadMenuItem.Text = "刷新";
            this.FaceDeviceReloadMenuItem.Click += new System.EventHandler(this.FaceDeviceReloadMenuItem_Click);
            // 
            // FaceDeviceBellMenuItem
            // 
            this.FaceDeviceBellMenuItem.Name = "FaceDeviceBellMenuItem";
            this.FaceDeviceBellMenuItem.Size = new System.Drawing.Size(184, 22);
            this.FaceDeviceBellMenuItem.Text = "通知";
            this.FaceDeviceBellMenuItem.Click += new System.EventHandler(this.FaceDeviceBellMenuItem_Click);
            // 
            // FaceDeviceBellAllMenuItem
            // 
            this.FaceDeviceBellAllMenuItem.Name = "FaceDeviceBellAllMenuItem";
            this.FaceDeviceBellAllMenuItem.Size = new System.Drawing.Size(184, 22);
            this.FaceDeviceBellAllMenuItem.Text = "通知全部";
            this.FaceDeviceBellAllMenuItem.Click += new System.EventHandler(this.FaceDeviceBellAllMenuItem_Click);
            // 
            // FaceWorkersAllInitNewMenuItem
            // 
            this.FaceWorkersAllInitNewMenuItem.Name = "FaceWorkersAllInitNewMenuItem";
            this.FaceWorkersAllInitNewMenuItem.Size = new System.Drawing.Size(184, 22);
            this.FaceWorkersAllInitNewMenuItem.Text = "旗下工人复位新添加";
            this.FaceWorkersAllInitNewMenuItem.Click += new System.EventHandler(this.FaceWorkersAllInitNewMenuItem_Click);
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
            this.splitContainer1.Panel2.Controls.Add(this.FaceWorkersGridPager);
            this.splitContainer1.Panel2.Controls.Add(this.FaceWorkerStatesCb);
            this.splitContainer1.Panel2.Controls.Add(this.SearchButton);
            this.splitContainer1.Panel2.Controls.Add(this.SearchText);
            this.splitContainer1.Panel2.Controls.Add(this.FaceWorkersGrid);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("宋体", 12F);
            this.splitContainer1.Size = new System.Drawing.Size(1333, 696);
            this.splitContainer1.SplitterDistance = 223;
            this.splitContainer1.TabIndex = 2;
            // 
            // FaceWorkersGrid
            // 
            this.FaceWorkersGrid.AllowUserToAddRows = false;
            this.FaceWorkersGrid.AllowUserToDeleteRows = false;
            this.FaceWorkersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FaceWorkersGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FaceWorkersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FaceWorkersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.WorkerId,
            this.WorkerName,
            this.IdentityCode,
            this.Mobile,
            this.SexText,
            this.Nation,
            this.AddressNow,
            this.AuthenticationStateText,
            this.ErrorCodeText,
            this.DeviceCode});
            this.FaceWorkersGrid.ContextMenuStrip = this.FaceWorkerCms;
            this.FaceWorkersGrid.Location = new System.Drawing.Point(0, 37);
            this.FaceWorkersGrid.MultiSelect = false;
            this.FaceWorkersGrid.Name = "FaceWorkersGrid";
            this.FaceWorkersGrid.ReadOnly = true;
            this.FaceWorkersGrid.RowHeadersVisible = false;
            this.FaceWorkersGrid.RowHeadersWidth = 20;
            this.FaceWorkersGrid.RowTemplate.Height = 23;
            this.FaceWorkersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FaceWorkersGrid.Size = new System.Drawing.Size(1103, 625);
            this.FaceWorkersGrid.TabIndex = 0;
            this.FaceWorkersGrid.SelectionChanged += new System.EventHandler(this.FaceWorkersGrid_SelectionChanged);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // WorkerId
            // 
            this.WorkerId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WorkerId.DataPropertyName = "WorkerId";
            this.WorkerId.HeaderText = "WorkerId";
            this.WorkerId.Name = "WorkerId";
            this.WorkerId.ReadOnly = true;
            this.WorkerId.Visible = false;
            // 
            // WorkerName
            // 
            this.WorkerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WorkerName.DataPropertyName = "WorkerName";
            this.WorkerName.FillWeight = 4F;
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
            this.IdentityCode.MinimumWidth = 7;
            this.IdentityCode.Name = "IdentityCode";
            this.IdentityCode.ReadOnly = true;
            // 
            // Mobile
            // 
            this.Mobile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Mobile.DataPropertyName = "Mobile";
            this.Mobile.FillWeight = 5F;
            this.Mobile.HeaderText = "手机号";
            this.Mobile.Name = "Mobile";
            this.Mobile.ReadOnly = true;
            // 
            // SexText
            // 
            this.SexText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SexText.DataPropertyName = "SexText";
            this.SexText.FillWeight = 4F;
            this.SexText.HeaderText = "性别";
            this.SexText.Name = "SexText";
            this.SexText.ReadOnly = true;
            // 
            // Nation
            // 
            this.Nation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nation.DataPropertyName = "NationText";
            this.Nation.FillWeight = 5F;
            this.Nation.HeaderText = "民族";
            this.Nation.Name = "Nation";
            this.Nation.ReadOnly = true;
            // 
            // AddressNow
            // 
            this.AddressNow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AddressNow.DataPropertyName = "AddressNow";
            this.AddressNow.FillWeight = 15F;
            this.AddressNow.HeaderText = "地址";
            this.AddressNow.Name = "AddressNow";
            this.AddressNow.ReadOnly = true;
            // 
            // AuthenticationStateText
            // 
            this.AuthenticationStateText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AuthenticationStateText.DataPropertyName = "StatusText";
            this.AuthenticationStateText.FillWeight = 5F;
            this.AuthenticationStateText.HeaderText = "状态";
            this.AuthenticationStateText.Name = "AuthenticationStateText";
            this.AuthenticationStateText.ReadOnly = true;
            // 
            // ErrorCodeText
            // 
            this.ErrorCodeText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ErrorCodeText.DataPropertyName = "ErrorCodeText";
            this.ErrorCodeText.FillWeight = 5F;
            this.ErrorCodeText.HeaderText = "返回值";
            this.ErrorCodeText.Name = "ErrorCodeText";
            this.ErrorCodeText.ReadOnly = true;
            // 
            // DeviceCode
            // 
            this.DeviceCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DeviceCode.DataPropertyName = "DeviceCode";
            this.DeviceCode.FillWeight = 6F;
            this.DeviceCode.HeaderText = "设备";
            this.DeviceCode.Name = "DeviceCode";
            this.DeviceCode.ReadOnly = true;
            // 
            // FaceWorkersGridPager
            // 
            this.FaceWorkersGridPager.Location = new System.Drawing.Point(0, 665);
            this.FaceWorkersGridPager.Margin = new System.Windows.Forms.Padding(4);
            this.FaceWorkersGridPager.Name = "FaceWorkersGridPager";
            this.FaceWorkersGridPager.PageCount = 0;
            this.FaceWorkersGridPager.PageIndex = 1;
            this.FaceWorkersGridPager.PageSize = 15;
            this.FaceWorkersGridPager.PagingHandler = null;
            this.FaceWorkersGridPager.Size = new System.Drawing.Size(295, 25);
            this.FaceWorkersGridPager.TabIndex = 19;
            // 
            // FaceWorkerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 696);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FaceWorkerList";
            this.Text = "人脸库";
            this.FaceWorkerCms.ResumeLayout(false);
            this.FaceDevicesCms.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FaceWorkersGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem WorkerDetailMenuItem;
        private System.Windows.Forms.ContextMenuStrip FaceWorkerCms;
        private UserControls.KtpGridPager FaceWorkersGridPager;
        private System.Windows.Forms.ComboBox FaceWorkerStatesCb;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.ToolStripMenuItem FaceDeviceDelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FaceDeviceAddMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FaceDeviceEditMenuItem;
        private System.Windows.Forms.ContextMenuStrip FaceDevicesCms;
        private System.Windows.Forms.ListBox FaceDevicesLb;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView FaceWorkersGrid;
        private System.Windows.Forms.ToolStripMenuItem FaceDeviceBellMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FaceDeviceBellAllMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentityCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn SexText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nation;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressNow;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuthenticationStateText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorCodeText;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceCode;
        private System.Windows.Forms.ToolStripMenuItem FaceDeviceReloadMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WorkerInitNewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WorkerInitNewDelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FaceWorkersAllInitNewMenuItem;
    }
}