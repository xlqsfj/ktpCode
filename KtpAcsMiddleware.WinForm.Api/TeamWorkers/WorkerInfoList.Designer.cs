namespace KtpAcsMiddleware.WinForm.Api.TeamWorkers
{
    partial class WorkerInfoList
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
            this.FaceWorkerStatesCb = new System.Windows.Forms.ComboBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.WorkerAllInitNewDelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerDetailMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FaceWorkerCms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.WorkerInitNewDelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeviceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuthenticationStateText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressNow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SexText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentityCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPagingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.WorkersGrid = new System.Windows.Forms.DataGridView();
            this.FaceDeviceBellMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FaceDeviceReloadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FaceDevicesCms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.FaceDevicesLb = new System.Windows.Forms.ListBox();
            this.FaceWorkerCms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridPagingNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkersGrid)).BeginInit();
            this.FaceDevicesCms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FaceWorkerStatesCb
            // 
            this.FaceWorkerStatesCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FaceWorkerStatesCb.FormattingEnabled = true;
            this.FaceWorkerStatesCb.Location = new System.Drawing.Point(814, 45);
            this.FaceWorkerStatesCb.Name = "FaceWorkerStatesCb";
            this.FaceWorkerStatesCb.Size = new System.Drawing.Size(151, 20);
            this.FaceWorkerStatesCb.TabIndex = 24;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(967, -32);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(136, 26);
            this.SearchButton.TabIndex = 23;
            this.SearchButton.Text = "搜索";
            this.SearchButton.UseVisualStyleBackColor = true;
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(0, -32);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(807, 21);
            this.SearchText.TabIndex = 22;
            // 
            // WorkerAllInitNewDelMenuItem
            // 
            this.WorkerAllInitNewDelMenuItem.Name = "WorkerAllInitNewDelMenuItem";
            this.WorkerAllInitNewDelMenuItem.Size = new System.Drawing.Size(160, 22);
            this.WorkerAllInitNewDelMenuItem.Text = "全部设为新删除";
            // 
            // WorkerDetailMenuItem
            // 
            this.WorkerDetailMenuItem.Name = "WorkerDetailMenuItem";
            this.WorkerDetailMenuItem.Size = new System.Drawing.Size(160, 22);
            this.WorkerDetailMenuItem.Text = "工人信息";
            // 
            // FaceWorkerCms
            // 
            this.FaceWorkerCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WorkerDetailMenuItem,
            this.WorkerInitNewDelMenuItem,
            this.WorkerAllInitNewDelMenuItem});
            this.FaceWorkerCms.Name = "TeamsCms";
            this.FaceWorkerCms.Size = new System.Drawing.Size(161, 70);
            // 
            // WorkerInitNewDelMenuItem
            // 
            this.WorkerInitNewDelMenuItem.Name = "WorkerInitNewDelMenuItem";
            this.WorkerInitNewDelMenuItem.Size = new System.Drawing.Size(160, 22);
            this.WorkerInitNewDelMenuItem.Text = "设为新删除";
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
            // AuthenticationStateText
            // 
            this.AuthenticationStateText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AuthenticationStateText.DataPropertyName = "StatusText";
            this.AuthenticationStateText.FillWeight = 5F;
            this.AuthenticationStateText.HeaderText = "状态";
            this.AuthenticationStateText.Name = "AuthenticationStateText";
            this.AuthenticationStateText.ReadOnly = true;
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
            // Nation
            // 
            this.Nation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nation.DataPropertyName = "NationText";
            this.Nation.FillWeight = 5F;
            this.Nation.HeaderText = "民族";
            this.Nation.Name = "Nation";
            this.Nation.ReadOnly = true;
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
            // Mobile
            // 
            this.Mobile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Mobile.DataPropertyName = "Mobile";
            this.Mobile.FillWeight = 5F;
            this.Mobile.HeaderText = "手机号";
            this.Mobile.Name = "Mobile";
            this.Mobile.ReadOnly = true;
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
            // WorkerName
            // 
            this.WorkerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WorkerName.DataPropertyName = "WorkerName";
            this.WorkerName.FillWeight = 4F;
            this.WorkerName.HeaderText = "姓名";
            this.WorkerName.Name = "WorkerName";
            this.WorkerName.ReadOnly = true;
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
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // GridPagingNavigator
            // 
            this.GridPagingNavigator.AddNewItem = null;
            this.GridPagingNavigator.CountItem = null;
            this.GridPagingNavigator.DeleteItem = null;
            this.GridPagingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GridPagingNavigator.Location = new System.Drawing.Point(0, 673);
            this.GridPagingNavigator.MoveFirstItem = null;
            this.GridPagingNavigator.MoveLastItem = null;
            this.GridPagingNavigator.MoveNextItem = null;
            this.GridPagingNavigator.MovePreviousItem = null;
            this.GridPagingNavigator.Name = "GridPagingNavigator";
            this.GridPagingNavigator.PositionItem = null;
            this.GridPagingNavigator.Size = new System.Drawing.Size(1417, 25);
            this.GridPagingNavigator.TabIndex = 28;
            this.GridPagingNavigator.Text = "GridPagingNavigator";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(813, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(151, 24);
            this.comboBox1.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(970, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 26);
            this.button1.TabIndex = 17;
            this.button1.Text = "搜索";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(807, 26);
            this.textBox1.TabIndex = 16;
            // 
            // WorkersGrid
            // 
            this.WorkersGrid.AllowUserToAddRows = false;
            this.WorkersGrid.AllowUserToDeleteRows = false;
            this.WorkersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.WorkersGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WorkersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WorkersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.WorkerId,
            this.WorkerName,
            this.IdentityCode,
            this.Mobile,
            this.SexText,
            this.Nation,
            this.AddressNow,
            this.AuthenticationStateText,
            this.DeviceCode});
            this.WorkersGrid.ContextMenuStrip = this.FaceWorkerCms;
            this.WorkersGrid.Location = new System.Drawing.Point(3, 45);
            this.WorkersGrid.MultiSelect = false;
            this.WorkersGrid.Name = "WorkersGrid";
            this.WorkersGrid.ReadOnly = true;
            this.WorkersGrid.RowHeadersVisible = false;
            this.WorkersGrid.RowHeadersWidth = 20;
            this.WorkersGrid.RowTemplate.Height = 23;
            this.WorkersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WorkersGrid.Size = new System.Drawing.Size(1103, 625);
            this.WorkersGrid.TabIndex = 0;
            // 
            // FaceDeviceBellMenuItem
            // 
            this.FaceDeviceBellMenuItem.Name = "FaceDeviceBellMenuItem";
            this.FaceDeviceBellMenuItem.Size = new System.Drawing.Size(124, 22);
            this.FaceDeviceBellMenuItem.Text = "通知删除";
            // 
            // FaceDeviceReloadMenuItem
            // 
            this.FaceDeviceReloadMenuItem.Name = "FaceDeviceReloadMenuItem";
            this.FaceDeviceReloadMenuItem.Size = new System.Drawing.Size(124, 22);
            this.FaceDeviceReloadMenuItem.Text = "刷新";
            // 
            // FaceDevicesCms
            // 
            this.FaceDevicesCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FaceDeviceReloadMenuItem,
            this.FaceDeviceBellMenuItem});
            this.FaceDevicesCms.Name = "TeamsCms";
            this.FaceDevicesCms.Size = new System.Drawing.Size(125, 48);
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
            this.splitContainer1.Panel2.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.WorkersGrid);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("宋体", 12F);
            this.splitContainer1.Size = new System.Drawing.Size(1417, 698);
            this.splitContainer1.SplitterDistance = 237;
            this.splitContainer1.TabIndex = 27;
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
            // 
            // WorkerInfoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1417, 698);
            this.Controls.Add(this.GridPagingNavigator);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.FaceWorkerStatesCb);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchText);
            this.Name = "WorkerInfoList";
            this.Text = "WorkerInfoList";
            this.Load += new System.EventHandler(this.WorkerInfoList_Load);
            this.FaceWorkerCms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridPagingNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkersGrid)).EndInit();
            this.FaceDevicesCms.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox FaceWorkerStatesCb;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.ToolStripMenuItem WorkerAllInitNewDelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WorkerDetailMenuItem;
        private System.Windows.Forms.ContextMenuStrip FaceWorkerCms;
        private System.Windows.Forms.ToolStripMenuItem WorkerInitNewDelMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuthenticationStateText;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressNow;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nation;
        private System.Windows.Forms.DataGridViewTextBoxColumn SexText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentityCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.BindingNavigator GridPagingNavigator;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView WorkersGrid;
        private System.Windows.Forms.ToolStripMenuItem FaceDeviceBellMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FaceDeviceReloadMenuItem;
        private System.Windows.Forms.ContextMenuStrip FaceDevicesCms;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox FaceDevicesLb;
    }
}