namespace KtpAcs.WinForm.TeamWorkers
{
    partial class WorkerDeviceInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkerDeviceInfo));
            this.btnSyn = new CCWin.SkinControl.SkinButton();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.WorkerDetailMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerCms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.con_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.con_update_add = new System.Windows.Forms.ToolStripMenuItem();
            this.con_reset_add = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkersGrid = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelStateCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentityCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SexText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressNow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ktpState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelMag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamsLb = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.com_DeviceList = new System.Windows.Forms.ComboBox();
            this.ktpGridPager = new KtpAcs.WinForm.UserControls.KtpGridPager();
            this.WorkerCms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkersGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSyn
            // 
            this.btnSyn.BackColor = System.Drawing.Color.Silver;
            this.btnSyn.BaseColor = System.Drawing.Color.DarkGray;
            this.btnSyn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSyn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSyn.DownBack = null;
            this.btnSyn.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSyn.Location = new System.Drawing.Point(1158, 670);
            this.btnSyn.MouseBack = null;
            this.btnSyn.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSyn.Name = "btnSyn";
            this.btnSyn.NormlBack = null;
            this.btnSyn.Size = new System.Drawing.Size(149, 33);
            this.btnSyn.TabIndex = 38;
            this.btnSyn.Text = "同 步";
            this.btnSyn.UseVisualStyleBackColor = false;
            this.btnSyn.Click += new System.EventHandler(this.btnSyn_Click);
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(275, 55);
            this.SearchText.Multiline = true;
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(631, 26);
            this.SearchText.TabIndex = 35;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(1166, 55);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(141, 29);
            this.btn_Search.TabIndex = 34;
            this.btn_Search.Text = "搜索";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // WorkerDetailMenuItem
            // 
            this.WorkerDetailMenuItem.Name = "WorkerDetailMenuItem";
            this.WorkerDetailMenuItem.Size = new System.Drawing.Size(196, 22);
            this.WorkerDetailMenuItem.Text = "工人信息";
            this.WorkerDetailMenuItem.Click += new System.EventHandler(this.WorkerDetailMenuItem_Click);
            // 
            // WorkerCms
            // 
            this.WorkerCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WorkerDetailMenuItem,
            this.con_Edit,
            this.con_update_add,
            this.con_reset_add});
            this.WorkerCms.Name = "TeamsCms";
            this.WorkerCms.Size = new System.Drawing.Size(197, 92);
            // 
            // con_Edit
            // 
            this.con_Edit.Name = "con_Edit";
            this.con_Edit.Size = new System.Drawing.Size(196, 22);
            this.con_Edit.Text = "编辑";
            this.con_Edit.Click += new System.EventHandler(this.con_Edit_Click);
            // 
            // con_update_add
            // 
            this.con_update_add.Name = "con_update_add";
            this.con_update_add.Size = new System.Drawing.Size(196, 22);
            this.con_update_add.Text = "设备为新添加";
            this.con_update_add.Click += new System.EventHandler(this.con_update_add_Click);
            // 
            // con_reset_add
            // 
            this.con_reset_add.Name = "con_reset_add";
            this.con_reset_add.Size = new System.Drawing.Size(196, 22);
            this.con_reset_add.Text = "设为所有设备为新添加";
            this.con_reset_add.Click += new System.EventHandler(this.con_reset_add_Click);
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
            this.dId,
            this.panelStateCode,
            this.WorkerName,
            this.IdentityCode,
            this.Mobile,
            this.SexText,
            this.Nation,
            this.AddressNow,
            this.TeamName,
            this.ktpState,
            this.panelState,
            this.panelMag});
            this.WorkersGrid.ContextMenuStrip = this.WorkerCms;
            this.WorkersGrid.Location = new System.Drawing.Point(204, 90);
            this.WorkersGrid.MultiSelect = false;
            this.WorkersGrid.Name = "WorkersGrid";
            this.WorkersGrid.ReadOnly = true;
            this.WorkersGrid.RowHeadersVisible = false;
            this.WorkersGrid.RowHeadersWidth = 20;
            this.WorkersGrid.RowTemplate.Height = 23;
            this.WorkersGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WorkersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WorkersGrid.Size = new System.Drawing.Size(1207, 574);
            this.WorkersGrid.TabIndex = 33;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // dId
            // 
            this.dId.DataPropertyName = "dId";
            this.dId.HeaderText = "dId";
            this.dId.Name = "dId";
            this.dId.ReadOnly = true;
            this.dId.Visible = false;
            // 
            // panelStateCode
            // 
            this.panelStateCode.DataPropertyName = "panelStateCode";
            this.panelStateCode.HeaderText = "panelStateCode";
            this.panelStateCode.Name = "panelStateCode";
            this.panelStateCode.ReadOnly = true;
            this.panelStateCode.Visible = false;
            // 
            // WorkerName
            // 
            this.WorkerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WorkerName.DataPropertyName = "WorkerName";
            this.WorkerName.FillWeight = 88.19517F;
            this.WorkerName.HeaderText = "姓名";
            this.WorkerName.MinimumWidth = 70;
            this.WorkerName.Name = "WorkerName";
            this.WorkerName.ReadOnly = true;
            // 
            // IdentityCode
            // 
            this.IdentityCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IdentityCode.DataPropertyName = "IdentityCode";
            this.IdentityCode.FillWeight = 1.574387F;
            this.IdentityCode.HeaderText = "证件号";
            this.IdentityCode.MinimumWidth = 150;
            this.IdentityCode.Name = "IdentityCode";
            this.IdentityCode.ReadOnly = true;
            // 
            // Mobile
            // 
            this.Mobile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Mobile.DataPropertyName = "Mobile";
            this.Mobile.FillWeight = 1.377588F;
            this.Mobile.HeaderText = "手机号";
            this.Mobile.MinimumWidth = 100;
            this.Mobile.Name = "Mobile";
            this.Mobile.ReadOnly = true;
            // 
            // SexText
            // 
            this.SexText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SexText.DataPropertyName = "Sex";
            this.SexText.FillWeight = 0.7871934F;
            this.SexText.HeaderText = "性别";
            this.SexText.MinimumWidth = 70;
            this.SexText.Name = "SexText";
            this.SexText.ReadOnly = true;
            // 
            // Nation
            // 
            this.Nation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nation.DataPropertyName = "Nation";
            this.Nation.FillWeight = 58.6282F;
            this.Nation.HeaderText = "民族";
            this.Nation.MinimumWidth = 70;
            this.Nation.Name = "Nation";
            this.Nation.ReadOnly = true;
            // 
            // AddressNow
            // 
            this.AddressNow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AddressNow.DataPropertyName = "AddressNow";
            this.AddressNow.FillWeight = 3.935966F;
            this.AddressNow.HeaderText = "地址";
            this.AddressNow.MinimumWidth = 200;
            this.AddressNow.Name = "AddressNow";
            this.AddressNow.ReadOnly = true;
            // 
            // TeamName
            // 
            this.TeamName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TeamName.DataPropertyName = "TeamName";
            this.TeamName.FillWeight = 1.574387F;
            this.TeamName.HeaderText = "班组";
            this.TeamName.MinimumWidth = 170;
            this.TeamName.Name = "TeamName";
            this.TeamName.ReadOnly = true;
            // 
            // ktpState
            // 
            this.ktpState.DataPropertyName = "ktpState";
            this.ktpState.FillWeight = 37.4611F;
            this.ktpState.HeaderText = "同步开太平";
            this.ktpState.MinimumWidth = 90;
            this.ktpState.Name = "ktpState";
            this.ktpState.ReadOnly = true;
            // 
            // panelState
            // 
            this.panelState.DataPropertyName = "panelState";
            this.panelState.FillWeight = 37.4611F;
            this.panelState.HeaderText = "同步面板";
            this.panelState.MinimumWidth = 90;
            this.panelState.Name = "panelState";
            this.panelState.ReadOnly = true;
            // 
            // panelMag
            // 
            this.panelMag.DataPropertyName = "ErrorCodeText";
            this.panelMag.HeaderText = "返回消息";
            this.panelMag.MinimumWidth = 150;
            this.panelMag.Name = "panelMag";
            this.panelMag.ReadOnly = true;
            // 
            // TeamsLb
            // 
            this.TeamsLb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TeamsLb.FormattingEnabled = true;
            this.TeamsLb.ItemHeight = 16;
            this.TeamsLb.Location = new System.Drawing.Point(8, 49);
            this.TeamsLb.Name = "TeamsLb";
            this.TeamsLb.Size = new System.Drawing.Size(190, 612);
            this.TeamsLb.TabIndex = 32;
            this.TeamsLb.SelectedIndexChanged += new System.EventHandler(this.TeamsLb_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(924, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 40;
            this.label1.Text = "设备号：";
            // 
            // com_DeviceList
            // 
            this.com_DeviceList.FormattingEnabled = true;
            this.com_DeviceList.Location = new System.Drawing.Point(983, 58);
            this.com_DeviceList.Name = "com_DeviceList";
            this.com_DeviceList.Size = new System.Drawing.Size(155, 20);
            this.com_DeviceList.TabIndex = 39;
            this.com_DeviceList.SelectedIndexChanged += new System.EventHandler(this.com_DeviceList_SelectedIndexChanged);
            // 
            // ktpGridPager
            // 
            this.ktpGridPager.AllowDrop = true;
            this.ktpGridPager.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ktpGridPager.Location = new System.Drawing.Point(215, 677);
            this.ktpGridPager.Name = "ktpGridPager";
            this.ktpGridPager.PageCount = 0;
            this.ktpGridPager.PageIndex = 1;
            this.ktpGridPager.PageSize = 15;
            this.ktpGridPager.PagingHandler = null;
            this.ktpGridPager.Size = new System.Drawing.Size(343, 26);
            this.ktpGridPager.TabIndex = 36;
            // 
            // WorkerDeviceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 714);
            this.Controls.Add(this.WorkersGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.com_DeviceList);
            this.Controls.Add(this.btnSyn);
            this.Controls.Add(this.ktpGridPager);
            this.Controls.Add(this.SearchText);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.TeamsLb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WorkerDeviceInfo";
            this.Text = "设备人员管理";
            this.WorkerCms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WorkersGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinButton btnSyn;
        private UserControls.KtpGridPager ktpGridPager;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.ToolStripMenuItem WorkerDetailMenuItem;
        private System.Windows.Forms.ContextMenuStrip WorkerCms;
        private System.Windows.Forms.DataGridView WorkersGrid;
        private System.Windows.Forms.ListBox TeamsLb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox com_DeviceList;
        private System.Windows.Forms.ToolStripMenuItem con_Edit;
        private System.Windows.Forms.ToolStripMenuItem con_update_add;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dId;
        private System.Windows.Forms.DataGridViewTextBoxColumn panelStateCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentityCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn SexText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nation;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressNow;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ktpState;
        private System.Windows.Forms.DataGridViewTextBoxColumn panelState;
        private System.Windows.Forms.DataGridViewTextBoxColumn panelMag;
        private System.Windows.Forms.ToolStripMenuItem con_reset_add;
    }
}