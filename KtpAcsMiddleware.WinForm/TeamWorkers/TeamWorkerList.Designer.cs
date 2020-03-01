namespace KtpAcsMiddleware.WinForm.TeamWorkers
{
    partial class TeamWorkerList
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TeamsLb = new System.Windows.Forms.ListBox();
            this.TeamsCms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TeamReloadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TeamEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TeamAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TeamWorkerAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkersGridPager = new KtpAcsMiddleware.WinForm.UserControls.KtpGridPager();
            this.WorkerAuthenticationStatesCb = new System.Windows.Forms.ComboBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.WorkersGrid = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentityCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SexText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressNow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuthenticationStateText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerCms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.WorkerDetailMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerChangeTeamMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerDelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerSetAsTeamLeaderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerSetFaceDeviceStatesToReAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.TeamsCms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkersGrid)).BeginInit();
            this.WorkerCms.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.WorkerAuthenticationStatesCb);
            this.splitContainer1.Panel2.Controls.Add(this.SearchButton);
            this.splitContainer1.Panel2.Controls.Add(this.SearchText);
            this.splitContainer1.Panel2.Controls.Add(this.WorkersGrid);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("宋体", 12F);
            this.splitContainer1.Size = new System.Drawing.Size(1333, 696);
            this.splitContainer1.SplitterDistance = 223;
            this.splitContainer1.TabIndex = 0;
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
            this.TeamReloadMenuItem,
            this.TeamEditMenuItem,
            this.TeamAddMenuItem,
            this.TeamWorkerAddMenuItem});
            this.TeamsCms.Name = "TeamsCms";
            this.TeamsCms.Size = new System.Drawing.Size(125, 92);
            // 
            // TeamReloadMenuItem
            // 
            this.TeamReloadMenuItem.Name = "TeamReloadMenuItem";
            this.TeamReloadMenuItem.Size = new System.Drawing.Size(124, 22);
            this.TeamReloadMenuItem.Text = "刷新";
            this.TeamReloadMenuItem.Click += new System.EventHandler(this.TeamReloadMenuItem_Click);
            // 
            // TeamEditMenuItem
            // 
            this.TeamEditMenuItem.Name = "TeamEditMenuItem";
            this.TeamEditMenuItem.Size = new System.Drawing.Size(124, 22);
            this.TeamEditMenuItem.Text = "编辑";
            this.TeamEditMenuItem.Click += new System.EventHandler(this.TeamEditMenuItem_Click);
            // 
            // TeamAddMenuItem
            // 
            this.TeamAddMenuItem.Name = "TeamAddMenuItem";
            this.TeamAddMenuItem.Size = new System.Drawing.Size(124, 22);
            this.TeamAddMenuItem.Text = "添加";
            this.TeamAddMenuItem.Click += new System.EventHandler(this.TeamAddMenuItem_Click);
            // 
            // TeamWorkerAddMenuItem
            // 
            this.TeamWorkerAddMenuItem.Name = "TeamWorkerAddMenuItem";
            this.TeamWorkerAddMenuItem.Size = new System.Drawing.Size(124, 22);
            this.TeamWorkerAddMenuItem.Text = "添加工人";
            this.TeamWorkerAddMenuItem.Click += new System.EventHandler(this.TeamWorkerAddMenuItem_Click);
            // 
            // WorkersGridPager
            // 
            this.WorkersGridPager.Location = new System.Drawing.Point(0, 665);
            this.WorkersGridPager.Margin = new System.Windows.Forms.Padding(4);
            this.WorkersGridPager.Name = "WorkersGridPager";
            this.WorkersGridPager.PageCount = 0;
            this.WorkersGridPager.PageIndex = 1;
            this.WorkersGridPager.PageSize = 15;
            this.WorkersGridPager.PagingHandler = null;
            this.WorkersGridPager.Size = new System.Drawing.Size(295, 25);
            this.WorkersGridPager.TabIndex = 19;
            // 
            // WorkerAuthenticationStatesCb
            // 
            this.WorkerAuthenticationStatesCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WorkerAuthenticationStatesCb.FormattingEnabled = true;
            this.WorkerAuthenticationStatesCb.Location = new System.Drawing.Point(810, 6);
            this.WorkerAuthenticationStatesCb.Name = "WorkerAuthenticationStatesCb";
            this.WorkerAuthenticationStatesCb.Size = new System.Drawing.Size(151, 24);
            this.WorkerAuthenticationStatesCb.TabIndex = 18;
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
            this.AuthenticationStateText,
            this.TeamName});
            this.WorkersGrid.ContextMenuStrip = this.WorkerCms;
            this.WorkersGrid.Location = new System.Drawing.Point(0, 37);
            this.WorkersGrid.MultiSelect = false;
            this.WorkersGrid.Name = "WorkersGrid";
            this.WorkersGrid.ReadOnly = true;
            this.WorkersGrid.RowHeadersVisible = false;
            this.WorkersGrid.RowHeadersWidth = 20;
            this.WorkersGrid.RowTemplate.Height = 23;
            this.WorkersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WorkersGrid.Size = new System.Drawing.Size(1103, 625);
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
            this.IdentityCode.FillWeight = 8F;
            this.IdentityCode.HeaderText = "证件号";
            this.IdentityCode.Name = "IdentityCode";
            this.IdentityCode.ReadOnly = true;
            // 
            // Mobile
            // 
            this.Mobile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Mobile.DataPropertyName = "Mobile";
            this.Mobile.FillWeight = 7F;
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
            this.Nation.DataPropertyName = "Nation";
            this.Nation.FillWeight = 7F;
            this.Nation.HeaderText = "民族";
            this.Nation.Name = "Nation";
            this.Nation.ReadOnly = true;
            // 
            // AddressNow
            // 
            this.AddressNow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AddressNow.DataPropertyName = "AddressNow";
            this.AddressNow.FillWeight = 20F;
            this.AddressNow.HeaderText = "地址";
            this.AddressNow.Name = "AddressNow";
            this.AddressNow.ReadOnly = true;
            // 
            // AuthenticationStateText
            // 
            this.AuthenticationStateText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AuthenticationStateText.DataPropertyName = "AuthenticationStateText";
            this.AuthenticationStateText.FillWeight = 4F;
            this.AuthenticationStateText.HeaderText = "状态";
            this.AuthenticationStateText.Name = "AuthenticationStateText";
            this.AuthenticationStateText.ReadOnly = true;
            // 
            // TeamName
            // 
            this.TeamName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TeamName.DataPropertyName = "TeamName";
            this.TeamName.FillWeight = 8F;
            this.TeamName.HeaderText = "班组";
            this.TeamName.Name = "TeamName";
            this.TeamName.ReadOnly = true;
            // 
            // WorkerCms
            // 
            this.WorkerCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WorkerDetailMenuItem,
            this.WorkerEditMenuItem,
            this.WorkerChangeTeamMenuItem,
            this.WorkerDelMenuItem,
            this.WorkerAddMenuItem,
            this.WorkerSetAsTeamLeaderMenuItem,
            this.WorkerSetFaceDeviceStatesToReAddMenuItem});
            this.WorkerCms.Name = "TeamsCms";
            this.WorkerCms.Size = new System.Drawing.Size(233, 180);
            // 
            // WorkerDetailMenuItem
            // 
            this.WorkerDetailMenuItem.Name = "WorkerDetailMenuItem";
            this.WorkerDetailMenuItem.Size = new System.Drawing.Size(232, 22);
            this.WorkerDetailMenuItem.Text = "详细";
            this.WorkerDetailMenuItem.Click += new System.EventHandler(this.WorkerDetailMenuItem_Click);
            // 
            // WorkerEditMenuItem
            // 
            this.WorkerEditMenuItem.Name = "WorkerEditMenuItem";
            this.WorkerEditMenuItem.Size = new System.Drawing.Size(232, 22);
            this.WorkerEditMenuItem.Text = "编辑";
            this.WorkerEditMenuItem.Click += new System.EventHandler(this.WorkerEditMenuItem_Click);
            // 
            // WorkerChangeTeamMenuItem
            // 
            this.WorkerChangeTeamMenuItem.Name = "WorkerChangeTeamMenuItem";
            this.WorkerChangeTeamMenuItem.Size = new System.Drawing.Size(232, 22);
            this.WorkerChangeTeamMenuItem.Text = "更换班组";
            this.WorkerChangeTeamMenuItem.Click += new System.EventHandler(this.WorkerChangeTeamMenuItem_Click);
            // 
            // WorkerDelMenuItem
            // 
            this.WorkerDelMenuItem.Name = "WorkerDelMenuItem";
            this.WorkerDelMenuItem.Size = new System.Drawing.Size(232, 22);
            this.WorkerDelMenuItem.Text = "删除";
            this.WorkerDelMenuItem.Click += new System.EventHandler(this.WorkerDelMenuItem_Click);
            // 
            // WorkerAddMenuItem
            // 
            this.WorkerAddMenuItem.Name = "WorkerAddMenuItem";
            this.WorkerAddMenuItem.Size = new System.Drawing.Size(232, 22);
            this.WorkerAddMenuItem.Text = "添加";
            this.WorkerAddMenuItem.Click += new System.EventHandler(this.WorkerAddMenuItem_Click);
            // 
            // WorkerSetAsTeamLeaderMenuItem
            // 
            this.WorkerSetAsTeamLeaderMenuItem.Name = "WorkerSetAsTeamLeaderMenuItem";
            this.WorkerSetAsTeamLeaderMenuItem.Size = new System.Drawing.Size(232, 22);
            this.WorkerSetAsTeamLeaderMenuItem.Text = "设为班组长";
            this.WorkerSetAsTeamLeaderMenuItem.Click += new System.EventHandler(this.WorkerSetAsTeamLeaderMenuItem_Click);
            // 
            // WorkerSetFaceDeviceStatesToReAddMenuItem
            // 
            this.WorkerSetFaceDeviceStatesToReAddMenuItem.Name = "WorkerSetFaceDeviceStatesToReAddMenuItem";
            this.WorkerSetFaceDeviceStatesToReAddMenuItem.Size = new System.Drawing.Size(232, 22);
            this.WorkerSetFaceDeviceStatesToReAddMenuItem.Text = "设为需要重新添加到所有设备";
            this.WorkerSetFaceDeviceStatesToReAddMenuItem.Click += new System.EventHandler(this.WorkerSetFaceDeviceStatesToReAddMenuItem_Click);
            // 
            // TeamWorkerList
            // 
            this.AcceptButton = this.SearchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 696);
            this.Controls.Add(this.splitContainer1);
            this.Name = "TeamWorkerList";
            this.Text = "班组工人";
            this.Load += new System.EventHandler(this.TeamWorkerList_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.TeamsCms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WorkersGrid)).EndInit();
            this.WorkerCms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox TeamsLb;
        private System.Windows.Forms.ContextMenuStrip TeamsCms;
        private System.Windows.Forms.ToolStripMenuItem TeamEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TeamAddMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TeamWorkerAddMenuItem;
        private System.Windows.Forms.ContextMenuStrip WorkerCms;
        private System.Windows.Forms.ToolStripMenuItem WorkerEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WorkerDelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WorkerAddMenuItem;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.ComboBox WorkerAuthenticationStatesCb;
        private UserControls.KtpGridPager WorkersGridPager;
        private System.Windows.Forms.ToolStripMenuItem WorkerDetailMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WorkerChangeTeamMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TeamReloadMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WorkerSetAsTeamLeaderMenuItem;
        private System.Windows.Forms.DataGridView WorkersGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentityCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn SexText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nation;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressNow;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuthenticationStateText;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
        private System.Windows.Forms.ToolStripMenuItem WorkerSetFaceDeviceStatesToReAddMenuItem;
    }
}