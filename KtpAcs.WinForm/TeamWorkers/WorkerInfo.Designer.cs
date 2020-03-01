namespace KtpAcs.WinForm.TeamWorkers
{
    partial class WorkerInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkerInfo));
            this.TeamsLb = new System.Windows.Forms.ListBox();
            this.WorkersGrid = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentityCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SexText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressNow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ktpState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerCms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.WorkerDetailMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerPullMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerPushMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.con_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.con_reset_add = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.ktpGridPager = new KtpAcs.WinForm.UserControls.KtpGridPager();
            this.WorkerStatesCb = new System.Windows.Forms.ComboBox();
            this.btnSyn = new CCWin.SkinControl.SkinButton();
            this.btn_Search = new System.Windows.Forms.Button();
            this.TeamsCms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TeamReloadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TeamEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TeamAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TeamWorkerAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.WorkersGrid)).BeginInit();
            this.WorkerCms.SuspendLayout();
            this.TeamsCms.SuspendLayout();
            this.SuspendLayout();
            // 
            // TeamsLb
            // 
            this.TeamsLb.ContextMenuStrip = this.TeamsCms;
            this.TeamsLb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TeamsLb.FormattingEnabled = true;
            this.TeamsLb.ItemHeight = 16;
            this.TeamsLb.Location = new System.Drawing.Point(11, 46);
            this.TeamsLb.Name = "TeamsLb";
            this.TeamsLb.Size = new System.Drawing.Size(190, 612);
            this.TeamsLb.TabIndex = 0;
            this.TeamsLb.SelectedIndexChanged += new System.EventHandler(this.TeamsLb_SelectedIndexChanged);
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
            this.WorkerName,
            this.IdentityCode,
            this.Mobile,
            this.SexText,
            this.Nation,
            this.AddressNow,
            this.TeamName,
            this.ktpState});
            this.WorkersGrid.ContextMenuStrip = this.WorkerCms;
            this.WorkersGrid.Location = new System.Drawing.Point(207, 87);
            this.WorkersGrid.MultiSelect = false;
            this.WorkersGrid.Name = "WorkersGrid";
            this.WorkersGrid.ReadOnly = true;
            this.WorkersGrid.RowHeadersVisible = false;
            this.WorkersGrid.RowHeadersWidth = 20;
            this.WorkersGrid.RowTemplate.Height = 23;
            this.WorkersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WorkersGrid.Size = new System.Drawing.Size(1103, 574);
            this.WorkersGrid.TabIndex = 3;
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
            this.WorkerName.FillWeight = 88.19517F;
            this.WorkerName.HeaderText = "姓名";
            this.WorkerName.MinimumWidth = 100;
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
            this.Mobile.MinimumWidth = 150;
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
            this.AddressNow.MinimumWidth = 170;
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
            this.ktpState.MinimumWidth = 110;
            this.ktpState.Name = "ktpState";
            this.ktpState.ReadOnly = true;
            // 
            // WorkerCms
            // 
            this.WorkerCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WorkerDetailMenuItem,
            this.WorkerPullMenuItem,
            this.WorkerPushMenuItem,
            this.删除ToolStripMenuItem,
            this.con_Edit,
            this.con_reset_add});
            this.WorkerCms.Name = "TeamsCms";
            this.WorkerCms.Size = new System.Drawing.Size(197, 136);
            // 
            // WorkerDetailMenuItem
            // 
            this.WorkerDetailMenuItem.Name = "WorkerDetailMenuItem";
            this.WorkerDetailMenuItem.Size = new System.Drawing.Size(196, 22);
            this.WorkerDetailMenuItem.Text = "工人信息";
            this.WorkerDetailMenuItem.Click += new System.EventHandler(this.WorkerDetailMenuItem_Click);
            // 
            // WorkerPullMenuItem
            // 
            this.WorkerPullMenuItem.Name = "WorkerPullMenuItem";
            this.WorkerPullMenuItem.Size = new System.Drawing.Size(196, 22);
            this.WorkerPullMenuItem.Text = "拉取所有";
            this.WorkerPullMenuItem.ToolTipText = "覆盖本地";
            this.WorkerPullMenuItem.Click += new System.EventHandler(this.WorkerPullMenuItem_Click);
            // 
            // WorkerPushMenuItem
            // 
            this.WorkerPushMenuItem.Name = "WorkerPushMenuItem";
            this.WorkerPushMenuItem.Size = new System.Drawing.Size(196, 22);
            this.WorkerPushMenuItem.Text = "推送当前";
            this.WorkerPushMenuItem.ToolTipText = "覆盖云端";
            this.WorkerPushMenuItem.Click += new System.EventHandler(this.WorkerPushMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // con_Edit
            // 
            this.con_Edit.Name = "con_Edit";
            this.con_Edit.Size = new System.Drawing.Size(196, 22);
            this.con_Edit.Text = "编辑";
            this.con_Edit.Click += new System.EventHandler(this.con_Edit_Click);
            // 
            // con_reset_add
            // 
            this.con_reset_add.Name = "con_reset_add";
            this.con_reset_add.Size = new System.Drawing.Size(196, 22);
            this.con_reset_add.Text = "设为所有设备为新添加";
            this.con_reset_add.Click += new System.EventHandler(this.con_reset_add_Click);
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(238, 55);
            this.SearchText.Multiline = true;
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(631, 26);
            this.SearchText.TabIndex = 6;
            // 
            // ktpGridPager
            // 
            this.ktpGridPager.AllowDrop = true;
            this.ktpGridPager.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ktpGridPager.Location = new System.Drawing.Point(207, 677);
            this.ktpGridPager.Name = "ktpGridPager";
            this.ktpGridPager.PageCount = 0;
            this.ktpGridPager.PageIndex = 1;
            this.ktpGridPager.PageSize = 15;
            this.ktpGridPager.PagingHandler = null;
            this.ktpGridPager.Size = new System.Drawing.Size(294, 26);
            this.ktpGridPager.TabIndex = 8;
            // 
            // WorkerStatesCb
            // 
            this.WorkerStatesCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WorkerStatesCb.FormattingEnabled = true;
            this.WorkerStatesCb.Location = new System.Drawing.Point(934, 57);
            this.WorkerStatesCb.Name = "WorkerStatesCb";
            this.WorkerStatesCb.Size = new System.Drawing.Size(172, 20);
            this.WorkerStatesCb.TabIndex = 19;
            this.WorkerStatesCb.SelectedIndexChanged += new System.EventHandler(this.WorkerAuthenticationStatesCb_SelectedIndexChanged);
            // 
            // btnSyn
            // 
            this.btnSyn.BackColor = System.Drawing.Color.Silver;
            this.btnSyn.BaseColor = System.Drawing.Color.DarkGray;
            this.btnSyn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSyn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSyn.DownBack = null;
            this.btnSyn.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSyn.Location = new System.Drawing.Point(1161, 667);
            this.btnSyn.MouseBack = null;
            this.btnSyn.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSyn.Name = "btnSyn";
            this.btnSyn.NormlBack = null;
            this.btnSyn.Size = new System.Drawing.Size(149, 33);
            this.btnSyn.TabIndex = 31;
            this.btnSyn.Text = "同 步";
            this.btnSyn.UseVisualStyleBackColor = false;
            this.btnSyn.Click += new System.EventHandler(this.btnSyn_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(1140, 50);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(141, 29);
            this.btn_Search.TabIndex = 35;
            this.btn_Search.Text = "搜索";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // TeamsCms
            // 
            this.TeamsCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TeamReloadMenuItem,
            this.TeamEditMenuItem,
            this.TeamAddMenuItem,
            this.TeamWorkerAddMenuItem});
            this.TeamsCms.Name = "TeamsCms";
            this.TeamsCms.Size = new System.Drawing.Size(181, 114);
            // 
            // TeamReloadMenuItem
            // 
            this.TeamReloadMenuItem.Name = "TeamReloadMenuItem";
            this.TeamReloadMenuItem.Size = new System.Drawing.Size(180, 22);
            this.TeamReloadMenuItem.Text = "刷新";
            // 
            // TeamEditMenuItem
            // 
            this.TeamEditMenuItem.Name = "TeamEditMenuItem";
            this.TeamEditMenuItem.Size = new System.Drawing.Size(180, 22);
            this.TeamEditMenuItem.Text = "编辑";
            this.TeamEditMenuItem.Click += new System.EventHandler(this.TeamEditMenuItem_Click);
            // 
            // TeamAddMenuItem
            // 
            this.TeamAddMenuItem.Name = "TeamAddMenuItem";
            this.TeamAddMenuItem.Size = new System.Drawing.Size(180, 22);
            this.TeamAddMenuItem.Text = "添加";
            this.TeamAddMenuItem.Click += new System.EventHandler(this.TeamAddMenuItem_Click);
            // 
            // TeamWorkerAddMenuItem
            // 
            this.TeamWorkerAddMenuItem.Name = "TeamWorkerAddMenuItem";
            this.TeamWorkerAddMenuItem.Size = new System.Drawing.Size(180, 22);
            this.TeamWorkerAddMenuItem.Text = "添加工人";
            this.TeamWorkerAddMenuItem.Click += new System.EventHandler(this.TeamWorkerAddMenuItem_Click);
            // 
            // WorkerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 708);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.btnSyn);
            this.Controls.Add(this.WorkerStatesCb);
            this.Controls.Add(this.ktpGridPager);
            this.Controls.Add(this.SearchText);
            this.Controls.Add(this.WorkersGrid);
            this.Controls.Add(this.TeamsLb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WorkerInfo";
            this.Text = "项目人员";
            this.Load += new System.EventHandler(this.WorkerInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WorkersGrid)).EndInit();
            this.WorkerCms.ResumeLayout(false);
            this.TeamsCms.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox TeamsLb;
        private System.Windows.Forms.DataGridView WorkersGrid;
        private System.Windows.Forms.TextBox SearchText;
        private UserControls.KtpGridPager ktpGridPager;
        private System.Windows.Forms.ContextMenuStrip WorkerCms;
        private System.Windows.Forms.ToolStripMenuItem WorkerDetailMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WorkerPullMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WorkerPushMenuItem;
        private System.Windows.Forms.ComboBox WorkerStatesCb;
        private CCWin.SkinControl.SkinButton btnSyn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentityCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn SexText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nation;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressNow;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ktpState;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem con_Edit;
        private System.Windows.Forms.ToolStripMenuItem con_reset_add;
        private System.Windows.Forms.ContextMenuStrip TeamsCms;
        private System.Windows.Forms.ToolStripMenuItem TeamReloadMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TeamEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TeamAddMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TeamWorkerAddMenuItem;
    }
}