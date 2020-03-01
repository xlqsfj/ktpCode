namespace KtpAcsMiddleware.WinForm.KtpLibrary
{
    partial class TeamSyncList
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
            this.SearchText = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TeamWorkTypesLb = new System.Windows.Forms.ListBox();
            this.TeamsGridPager = new KtpAcsMiddleware.WinForm.UserControls.KtpGridPager();
            this.KtpSyncStatesCb = new System.Windows.Forms.ComboBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.TeamsGrid = new System.Windows.Forms.DataGridView();
            this.TeamSyncCms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TeamPullMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TeamPushMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TeamPullAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TeamPushAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TeamSyncAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SexText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressNow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuthenticationStateText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TeamsGrid)).BeginInit();
            this.TeamSyncCms.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.TeamWorkTypesLb);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TeamsGridPager);
            this.splitContainer1.Panel2.Controls.Add(this.KtpSyncStatesCb);
            this.splitContainer1.Panel2.Controls.Add(this.SearchButton);
            this.splitContainer1.Panel2.Controls.Add(this.SearchText);
            this.splitContainer1.Panel2.Controls.Add(this.TeamsGrid);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("宋体", 12F);
            this.splitContainer1.Size = new System.Drawing.Size(1333, 696);
            this.splitContainer1.SplitterDistance = 223;
            this.splitContainer1.TabIndex = 3;
            // 
            // TeamWorkTypesLb
            // 
            this.TeamWorkTypesLb.Font = new System.Drawing.Font("宋体", 12F);
            this.TeamWorkTypesLb.FormattingEnabled = true;
            this.TeamWorkTypesLb.ItemHeight = 16;
            this.TeamWorkTypesLb.Location = new System.Drawing.Point(0, 0);
            this.TeamWorkTypesLb.Name = "TeamWorkTypesLb";
            this.TeamWorkTypesLb.Size = new System.Drawing.Size(222, 692);
            this.TeamWorkTypesLb.TabIndex = 0;
            this.TeamWorkTypesLb.SelectedIndexChanged += new System.EventHandler(this.TeamWorkTypesLb_SelectedIndexChanged);
            // 
            // TeamsGridPager
            // 
            this.TeamsGridPager.Location = new System.Drawing.Point(0, 665);
            this.TeamsGridPager.Margin = new System.Windows.Forms.Padding(4);
            this.TeamsGridPager.Name = "TeamsGridPager";
            this.TeamsGridPager.PageCount = 0;
            this.TeamsGridPager.PageIndex = 1;
            this.TeamsGridPager.PageSize = 10;
            this.TeamsGridPager.PagingHandler = null;
            this.TeamsGridPager.Size = new System.Drawing.Size(302, 25);
            this.TeamsGridPager.TabIndex = 19;
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
            // TeamsGrid
            // 
            this.TeamsGrid.AllowUserToAddRows = false;
            this.TeamsGrid.AllowUserToDeleteRows = false;
            this.TeamsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TeamsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TeamsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TeamsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.WorkerName,
            this.Mobile,
            this.SexText,
            this.Nation,
            this.AddressNow,
            this.AuthenticationStateText,
            this.WorkTypeName});
            this.TeamsGrid.ContextMenuStrip = this.TeamSyncCms;
            this.TeamsGrid.Location = new System.Drawing.Point(0, 32);
            this.TeamsGrid.MultiSelect = false;
            this.TeamsGrid.Name = "TeamsGrid";
            this.TeamsGrid.ReadOnly = true;
            this.TeamsGrid.RowHeadersVisible = false;
            this.TeamsGrid.RowHeadersWidth = 20;
            this.TeamsGrid.RowTemplate.Height = 23;
            this.TeamsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TeamsGrid.Size = new System.Drawing.Size(1103, 630);
            this.TeamsGrid.TabIndex = 0;
            this.TeamsGrid.SelectionChanged += new System.EventHandler(this.TeamsGrid_SelectionChanged);
            // 
            // TeamSyncCms
            // 
            this.TeamSyncCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TeamPullMenuItem,
            this.TeamPushMenuItem,
            this.TeamPullAllMenuItem,
            this.TeamPushAllMenuItem,
            this.TeamSyncAllMenuItem});
            this.TeamSyncCms.Name = "TeamsCms";
            this.TeamSyncCms.Size = new System.Drawing.Size(125, 114);
            // 
            // TeamPullMenuItem
            // 
            this.TeamPullMenuItem.Name = "TeamPullMenuItem";
            this.TeamPullMenuItem.Size = new System.Drawing.Size(124, 22);
            this.TeamPullMenuItem.Text = "拉取当前";
            this.TeamPullMenuItem.Click += new System.EventHandler(this.TeamPullMenuItem_Click);
            // 
            // TeamPushMenuItem
            // 
            this.TeamPushMenuItem.Name = "TeamPushMenuItem";
            this.TeamPushMenuItem.Size = new System.Drawing.Size(124, 22);
            this.TeamPushMenuItem.Text = "推送当前";
            this.TeamPushMenuItem.Click += new System.EventHandler(this.TeamPushMenuItem_Click);
            // 
            // TeamPullAllMenuItem
            // 
            this.TeamPullAllMenuItem.Name = "TeamPullAllMenuItem";
            this.TeamPullAllMenuItem.Size = new System.Drawing.Size(124, 22);
            this.TeamPullAllMenuItem.Text = "拉取所有";
            this.TeamPullAllMenuItem.Click += new System.EventHandler(this.TeamPullAllMenuItem_Click);
            // 
            // TeamPushAllMenuItem
            // 
            this.TeamPushAllMenuItem.Name = "TeamPushAllMenuItem";
            this.TeamPushAllMenuItem.Size = new System.Drawing.Size(124, 22);
            this.TeamPushAllMenuItem.Text = "推送所有";
            this.TeamPushAllMenuItem.Click += new System.EventHandler(this.TeamPushAllMenuItem_Click);
            // 
            // TeamSyncAllMenuItem
            // 
            this.TeamSyncAllMenuItem.Name = "TeamSyncAllMenuItem";
            this.TeamSyncAllMenuItem.Size = new System.Drawing.Size(124, 22);
            this.TeamSyncAllMenuItem.Text = "同步所有";
            this.TeamSyncAllMenuItem.Click += new System.EventHandler(this.TeamSyncAllMenuItem_Click);
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
            this.WorkerName.DataPropertyName = "TeamName";
            this.WorkerName.FillWeight = 5F;
            this.WorkerName.HeaderText = "名称";
            this.WorkerName.Name = "WorkerName";
            this.WorkerName.ReadOnly = true;
            // 
            // Mobile
            // 
            this.Mobile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Mobile.DataPropertyName = "TypeText";
            this.Mobile.FillWeight = 5F;
            this.Mobile.HeaderText = "最近操作";
            this.Mobile.Name = "Mobile";
            this.Mobile.ReadOnly = true;
            // 
            // SexText
            // 
            this.SexText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SexText.DataPropertyName = "StateText";
            this.SexText.FillWeight = 5F;
            this.SexText.HeaderText = "当前状态";
            this.SexText.Name = "SexText";
            this.SexText.ReadOnly = true;
            // 
            // Nation
            // 
            this.Nation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nation.DataPropertyName = "FeedbackCode";
            this.Nation.FillWeight = 6F;
            this.Nation.HeaderText = "最近返回值";
            this.Nation.Name = "Nation";
            this.Nation.ReadOnly = true;
            // 
            // AddressNow
            // 
            this.AddressNow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AddressNow.DataPropertyName = "Feedback";
            this.AddressNow.FillWeight = 18F;
            this.AddressNow.HeaderText = "最近返回信息";
            this.AddressNow.Name = "AddressNow";
            this.AddressNow.ReadOnly = true;
            // 
            // AuthenticationStateText
            // 
            this.AuthenticationStateText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AuthenticationStateText.DataPropertyName = "ModifiedTime";
            this.AuthenticationStateText.FillWeight = 7F;
            this.AuthenticationStateText.HeaderText = "最后更新";
            this.AuthenticationStateText.Name = "AuthenticationStateText";
            this.AuthenticationStateText.ReadOnly = true;
            // 
            // WorkTypeName
            // 
            this.WorkTypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WorkTypeName.DataPropertyName = "WorkTypeName";
            this.WorkTypeName.FillWeight = 9F;
            this.WorkTypeName.HeaderText = "工种类型";
            this.WorkTypeName.Name = "WorkTypeName";
            this.WorkTypeName.ReadOnly = true;
            // 
            // TeamSyncList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 696);
            this.Controls.Add(this.splitContainer1);
            this.Name = "TeamSyncList";
            this.Text = "开天平班组同步";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TeamsGrid)).EndInit();
            this.TeamSyncCms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox TeamWorkTypesLb;
        private UserControls.KtpGridPager TeamsGridPager;
        private System.Windows.Forms.ComboBox KtpSyncStatesCb;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DataGridView TeamsGrid;
        private System.Windows.Forms.ContextMenuStrip TeamSyncCms;
        private System.Windows.Forms.ToolStripMenuItem TeamPullMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TeamPullAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TeamPushMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TeamPushAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TeamSyncAllMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn SexText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nation;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressNow;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuthenticationStateText;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkTypeName;
    }
}