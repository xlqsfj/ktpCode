namespace KtpAcsMiddleware.WinForm.WorkerAuths
{
    partial class WorkerAuthList
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
            this.WorkerAuthDetailMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkersGridPager = new KtpAcsMiddleware.WinForm.UserControls.KtpGridPager();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.TeamReloadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TeamsCms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TeamsLb = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ClockDateDtp = new System.Windows.Forms.DateTimePicker();
            this.WorkersGrid = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentityCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClockTypeText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClockTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SimilarDegree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerCms.SuspendLayout();
            this.TeamsCms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkersGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // WorkerDetailMenuItem
            // 
            this.WorkerDetailMenuItem.Name = "WorkerDetailMenuItem";
            this.WorkerDetailMenuItem.Size = new System.Drawing.Size(124, 22);
            this.WorkerDetailMenuItem.Text = "工人信息";
            this.WorkerDetailMenuItem.Click += new System.EventHandler(this.WorkerDetailMenuItem_Click);
            // 
            // WorkerCms
            // 
            this.WorkerCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WorkerDetailMenuItem,
            this.WorkerAuthDetailMenuItem});
            this.WorkerCms.Name = "TeamsCms";
            this.WorkerCms.Size = new System.Drawing.Size(125, 48);
            // 
            // WorkerAuthDetailMenuItem
            // 
            this.WorkerAuthDetailMenuItem.Name = "WorkerAuthDetailMenuItem";
            this.WorkerAuthDetailMenuItem.Size = new System.Drawing.Size(124, 22);
            this.WorkerAuthDetailMenuItem.Text = "工人考勤";
            this.WorkerAuthDetailMenuItem.Click += new System.EventHandler(this.WorkerAuthDetailMenuItem_Click);
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
            this.SearchText.Size = new System.Drawing.Size(755, 26);
            this.SearchText.TabIndex = 16;
            // 
            // TeamReloadMenuItem
            // 
            this.TeamReloadMenuItem.Name = "TeamReloadMenuItem";
            this.TeamReloadMenuItem.Size = new System.Drawing.Size(124, 22);
            this.TeamReloadMenuItem.Text = "刷新数据";
            this.TeamReloadMenuItem.Click += new System.EventHandler(this.TeamReloadMenuItem_Click);
            // 
            // TeamsCms
            // 
            this.TeamsCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TeamReloadMenuItem});
            this.TeamsCms.Name = "TeamsCms";
            this.TeamsCms.Size = new System.Drawing.Size(125, 26);
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
            this.splitContainer1.Panel2.Controls.Add(this.ClockDateDtp);
            this.splitContainer1.Panel2.Controls.Add(this.WorkersGridPager);
            this.splitContainer1.Panel2.Controls.Add(this.SearchButton);
            this.splitContainer1.Panel2.Controls.Add(this.SearchText);
            this.splitContainer1.Panel2.Controls.Add(this.WorkersGrid);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("宋体", 12F);
            this.splitContainer1.Size = new System.Drawing.Size(1333, 696);
            this.splitContainer1.SplitterDistance = 223;
            this.splitContainer1.TabIndex = 2;
            // 
            // ClockDateDtp
            // 
            this.ClockDateDtp.Location = new System.Drawing.Point(761, 5);
            this.ClockDateDtp.Name = "ClockDateDtp";
            this.ClockDateDtp.Size = new System.Drawing.Size(200, 26);
            this.ClockDateDtp.TabIndex = 20;
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
            this.ClockTypeText,
            this.ClockTime,
            this.DeviceCode,
            this.SimilarDegree,
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
            // ClockTypeText
            // 
            this.ClockTypeText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClockTypeText.DataPropertyName = "ClockTypeText";
            this.ClockTypeText.FillWeight = 5F;
            this.ClockTypeText.HeaderText = "打卡类型";
            this.ClockTypeText.Name = "ClockTypeText";
            this.ClockTypeText.ReadOnly = true;
            // 
            // ClockTime
            // 
            this.ClockTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClockTime.DataPropertyName = "ClockTimeText";
            this.ClockTime.FillWeight = 6F;
            this.ClockTime.HeaderText = "打卡时间";
            this.ClockTime.Name = "ClockTime";
            this.ClockTime.ReadOnly = true;
            // 
            // DeviceCode
            // 
            this.DeviceCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DeviceCode.DataPropertyName = "ClientCode";
            this.DeviceCode.FillWeight = 5F;
            this.DeviceCode.HeaderText = "设备号";
            this.DeviceCode.Name = "DeviceCode";
            this.DeviceCode.ReadOnly = true;
            // 
            // SimilarDegree
            // 
            this.SimilarDegree.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SimilarDegree.FillWeight = 5F;
            this.SimilarDegree.HeaderText = "相似度";
            this.SimilarDegree.Name = "SimilarDegree";
            this.SimilarDegree.ReadOnly = true;
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
            // WorkerAuthList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 696);
            this.Controls.Add(this.splitContainer1);
            this.Name = "WorkerAuthList";
            this.Text = "班组工人考勤";
            this.Load += new System.EventHandler(this.WorkerAuthList_Load);
            this.WorkerCms.ResumeLayout(false);
            this.TeamsCms.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WorkersGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem WorkerDetailMenuItem;
        private System.Windows.Forms.ContextMenuStrip WorkerCms;
        private UserControls.KtpGridPager WorkersGridPager;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.ToolStripMenuItem TeamReloadMenuItem;
        private System.Windows.Forms.ContextMenuStrip TeamsCms;
        private System.Windows.Forms.ListBox TeamsLb;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView WorkersGrid;
        private System.Windows.Forms.DateTimePicker ClockDateDtp;
        private System.Windows.Forms.ToolStripMenuItem WorkerAuthDetailMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentityCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClockTypeText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClockTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SimilarDegree;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
    }
}