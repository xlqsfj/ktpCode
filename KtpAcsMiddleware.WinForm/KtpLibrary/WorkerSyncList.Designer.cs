namespace KtpAcsMiddleware.WinForm.KtpLibrary
{
    partial class WorkerSyncList
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
            this.KtpSyncStatesCb = new System.Windows.Forms.ComboBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.TeamsLb = new System.Windows.Forms.ListBox();
            this.TeamsCms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TeamsReloadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TeamsPullAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.WorkersGridPager = new KtpAcsMiddleware.WinForm.UserControls.KtpGridPager();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.WorkersGrid = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentityCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StateText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressNow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuthenticationStateText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerCms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.WorkerDetailMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerPullMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerPushMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerPullAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerPushAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerSyncMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TeamsCms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkersGrid)).BeginInit();
            this.WorkerCms.SuspendLayout();
            this.SuspendLayout();
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
            // TeamsLb
            // 
            this.TeamsLb.ContextMenuStrip = this.TeamsCms;
            this.TeamsLb.Font = new System.Drawing.Font("宋体", 12F);
            this.TeamsLb.FormattingEnabled = true;
            this.TeamsLb.ItemHeight = 16;
            this.TeamsLb.Location = new System.Drawing.Point(0, 0);
            this.TeamsLb.Name = "TeamsLb";
            this.TeamsLb.Size = new System.Drawing.Size(222, 692);
            this.TeamsLb.TabIndex = 0;
            this.TeamsLb.SelectedIndexChanged += new System.EventHandler(this.TeamsLb_SelectedIndexChanged);
            // 
            // TeamsCms
            // 
            this.TeamsCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TeamsReloadMenuItem,
            this.TeamsPullAllMenuItem});
            this.TeamsCms.Name = "TeamsCms";
            this.TeamsCms.Size = new System.Drawing.Size(181, 70);
            // 
            // TeamsReloadMenuItem
            // 
            this.TeamsReloadMenuItem.Name = "TeamsReloadMenuItem";
            this.TeamsReloadMenuItem.Size = new System.Drawing.Size(180, 22);
            this.TeamsReloadMenuItem.Text = "刷新";
            this.TeamsReloadMenuItem.Click += new System.EventHandler(this.TeamsReloadMenuItem_Click);
            // 
            // TeamsPullAllMenuItem
            // 
            this.TeamsPullAllMenuItem.Name = "TeamsPullAllMenuItem";
            this.TeamsPullAllMenuItem.Size = new System.Drawing.Size(180, 22);
            this.TeamsPullAllMenuItem.Text = "拉取刷新";
            this.TeamsPullAllMenuItem.ToolTipText = "拉取所有班组和工人并推送考勤";
            this.TeamsPullAllMenuItem.Click += new System.EventHandler(this.TeamsPullAllMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TeamsLb);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.WorkersGridPager);
            this.splitContainer1.Panel2.Controls.Add(this.KtpSyncStatesCb);
            this.splitContainer1.Panel2.Controls.Add(this.SearchButton);
            this.splitContainer1.Panel2.Controls.Add(this.SearchText);
            this.splitContainer1.Panel2.Controls.Add(this.WorkersGrid);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("宋体", 12F);
            this.splitContainer1.Size = new System.Drawing.Size(1333, 696);
            this.splitContainer1.SplitterDistance = 223;
            this.splitContainer1.TabIndex = 2;
            // 
            // WorkersGridPager
            // 
            this.WorkersGridPager.Location = new System.Drawing.Point(0, 665);
            this.WorkersGridPager.Margin = new System.Windows.Forms.Padding(4);
            this.WorkersGridPager.Name = "WorkersGridPager";
            this.WorkersGridPager.PageCount = 0;
            this.WorkersGridPager.PageIndex = 1;
            this.WorkersGridPager.PageSize = 10;
            this.WorkersGridPager.PagingHandler = null;
            this.WorkersGridPager.Size = new System.Drawing.Size(299, 25);
            this.WorkersGridPager.TabIndex = 19;
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(0, 2);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(807, 26);
            this.SearchText.TabIndex = 16;
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
            this.StateText,
            this.Nation,
            this.AddressNow,
            this.AuthenticationStateText,
            this.TeamName});
            this.WorkersGrid.ContextMenuStrip = this.WorkerCms;
            this.WorkersGrid.Location = new System.Drawing.Point(0, 32);
            this.WorkersGrid.MultiSelect = false;
            this.WorkersGrid.Name = "WorkersGrid";
            this.WorkersGrid.ReadOnly = true;
            this.WorkersGrid.RowHeadersVisible = false;
            this.WorkersGrid.RowHeadersWidth = 20;
            this.WorkersGrid.RowTemplate.Height = 23;
            this.WorkersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WorkersGrid.Size = new System.Drawing.Size(1103, 630);
            this.WorkersGrid.TabIndex = 0;
            this.WorkersGrid.SelectionChanged += new System.EventHandler(this.WorkersGrid_SelectionChanged);
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
            this.IdentityCode.FillWeight = 9F;
            this.IdentityCode.HeaderText = "证件号";
            this.IdentityCode.Name = "IdentityCode";
            this.IdentityCode.ReadOnly = true;
            // 
            // Mobile
            // 
            this.Mobile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Mobile.DataPropertyName = "TypeText";
            this.Mobile.FillWeight = 6F;
            this.Mobile.HeaderText = "最近操作";
            this.Mobile.Name = "Mobile";
            this.Mobile.ReadOnly = true;
            // 
            // StateText
            // 
            this.StateText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StateText.DataPropertyName = "StateText";
            this.StateText.FillWeight = 8F;
            this.StateText.HeaderText = "当前状态";
            this.StateText.Name = "StateText";
            this.StateText.ReadOnly = true;
            // 
            // Nation
            // 
            this.Nation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nation.DataPropertyName = "FeedbackCode";
            this.Nation.FillWeight = 6F;
            this.Nation.HeaderText = "最近返回";
            this.Nation.Name = "Nation";
            this.Nation.ReadOnly = true;
            // 
            // AddressNow
            // 
            this.AddressNow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AddressNow.DataPropertyName = "Feedback";
            this.AddressNow.FillWeight = 13F;
            this.AddressNow.HeaderText = "最近返回信息";
            this.AddressNow.Name = "AddressNow";
            this.AddressNow.ReadOnly = true;
            // 
            // AuthenticationStateText
            // 
            this.AuthenticationStateText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AuthenticationStateText.DataPropertyName = "Mobile";
            this.AuthenticationStateText.FillWeight = 7F;
            this.AuthenticationStateText.HeaderText = "手机号码";
            this.AuthenticationStateText.Name = "AuthenticationStateText";
            this.AuthenticationStateText.ReadOnly = true;
            // 
            // TeamName
            // 
            this.TeamName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TeamName.DataPropertyName = "TeamName";
            this.TeamName.FillWeight = 7F;
            this.TeamName.HeaderText = "班组";
            this.TeamName.Name = "TeamName";
            this.TeamName.ReadOnly = true;
            // 
            // WorkerCms
            // 
            this.WorkerCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WorkerDetailMenuItem,
            this.WorkerPullMenuItem,
            this.WorkerPushMenuItem,
            this.WorkerPullAllMenuItem,
            this.WorkerPushAllMenuItem,
            this.WorkerSyncMenuItem});
            this.WorkerCms.Name = "TeamsCms";
            this.WorkerCms.Size = new System.Drawing.Size(125, 136);
            // 
            // WorkerDetailMenuItem
            // 
            this.WorkerDetailMenuItem.Name = "WorkerDetailMenuItem";
            this.WorkerDetailMenuItem.Size = new System.Drawing.Size(124, 22);
            this.WorkerDetailMenuItem.Text = "工人信息";
            this.WorkerDetailMenuItem.Click += new System.EventHandler(this.WorkerDetailMenuItem_Click);
            // 
            // WorkerPullMenuItem
            // 
            this.WorkerPullMenuItem.Name = "WorkerPullMenuItem";
            this.WorkerPullMenuItem.Size = new System.Drawing.Size(124, 22);
            this.WorkerPullMenuItem.Text = "拉取当前";
            this.WorkerPullMenuItem.ToolTipText = "覆盖本地";
            this.WorkerPullMenuItem.Click += new System.EventHandler(this.WorkerPullMenuItem_Click);
            // 
            // WorkerPushMenuItem
            // 
            this.WorkerPushMenuItem.Name = "WorkerPushMenuItem";
            this.WorkerPushMenuItem.Size = new System.Drawing.Size(124, 22);
            this.WorkerPushMenuItem.Text = "推送当前";
            this.WorkerPushMenuItem.ToolTipText = "覆盖云端";
            this.WorkerPushMenuItem.Click += new System.EventHandler(this.WorkerPushMenuItem_Click);
            // 
            // WorkerPullAllMenuItem
            // 
            this.WorkerPullAllMenuItem.Name = "WorkerPullAllMenuItem";
            this.WorkerPullAllMenuItem.Size = new System.Drawing.Size(124, 22);
            this.WorkerPullAllMenuItem.Text = "拉取所有";
            this.WorkerPullAllMenuItem.ToolTipText = "按规则拉取更新本地";
            this.WorkerPullAllMenuItem.Click += new System.EventHandler(this.WorkerPullAllMenuItem_Click);
            // 
            // WorkerPushAllMenuItem
            // 
            this.WorkerPushAllMenuItem.Name = "WorkerPushAllMenuItem";
            this.WorkerPushAllMenuItem.Size = new System.Drawing.Size(124, 22);
            this.WorkerPushAllMenuItem.Text = "推送所有";
            this.WorkerPushAllMenuItem.ToolTipText = "按规则推送更新云端";
            this.WorkerPushAllMenuItem.Click += new System.EventHandler(this.WorkerPushAllMenuItem_Click);
            // 
            // WorkerSyncMenuItem
            // 
            this.WorkerSyncMenuItem.Name = "WorkerSyncMenuItem";
            this.WorkerSyncMenuItem.Size = new System.Drawing.Size(124, 22);
            this.WorkerSyncMenuItem.Text = "同步所有";
            this.WorkerSyncMenuItem.ToolTipText = "按规则更新本地和云端";
            this.WorkerSyncMenuItem.Click += new System.EventHandler(this.WorkerSyncMenuItem_Click);
            // 
            // WorkerSyncList
            // 
            this.AcceptButton = this.SearchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 696);
            this.Controls.Add(this.splitContainer1);
            this.Name = "WorkerSyncList";
            this.Text = "开太平工人同步";
            this.Load += new System.EventHandler(this.WorkerSyncList_Load);
            this.TeamsCms.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WorkersGrid)).EndInit();
            this.WorkerCms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private UserControls.KtpGridPager WorkersGridPager;
        private System.Windows.Forms.ComboBox KtpSyncStatesCb;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.ListBox TeamsLb;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.DataGridView WorkersGrid;
        private System.Windows.Forms.ContextMenuStrip WorkerCms;
        private System.Windows.Forms.ToolStripMenuItem WorkerDetailMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WorkerPullMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WorkerPushMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WorkerPullAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WorkerPushAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WorkerSyncMenuItem;
        private System.Windows.Forms.ContextMenuStrip TeamsCms;
        private System.Windows.Forms.ToolStripMenuItem TeamsReloadMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TeamsPullAllMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentityCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn StateText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nation;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressNow;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuthenticationStateText;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
    }
}