namespace KtpAcsMiddleware.WinForm.Api.WorkerAuths
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.time_beginTime = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TeamsLb = new System.Windows.Forms.ListBox();
            this.SearchButton = new CCWin.SkinControl.SkinButton();
            this.label1 = new System.Windows.Forms.Label();
            this.re_Offline = new System.Windows.Forms.RadioButton();
            this.re_Online = new System.Windows.Forms.RadioButton();
            this.WorkersGridPager = new KtpAcsMiddleware.WinForm.Api.UserControls.KtpGridPager();
            this.time_endTime = new System.Windows.Forms.DateTimePicker();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.WorkersGrid = new System.Windows.Forms.DataGridView();
            this.WorkerCms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.WorkerDetailMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.poId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identityNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClockTypeText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClockTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SimilarDegree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.photoUrl1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.photoUrl = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkersGrid)).BeginInit();
            this.WorkerCms.SuspendLayout();
            this.SuspendLayout();
            // 
            // time_beginTime
            // 
            this.time_beginTime.Location = new System.Drawing.Point(525, 5);
            this.time_beginTime.Name = "time_beginTime";
            this.time_beginTime.Size = new System.Drawing.Size(200, 26);
            this.time_beginTime.TabIndex = 20;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(8, 39);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TeamsLb);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.SearchButton);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.re_Offline);
            this.splitContainer1.Panel2.Controls.Add(this.re_Online);
            this.splitContainer1.Panel2.Controls.Add(this.WorkersGridPager);
            this.splitContainer1.Panel2.Controls.Add(this.time_endTime);
            this.splitContainer1.Panel2.Controls.Add(this.time_beginTime);
            this.splitContainer1.Panel2.Controls.Add(this.SearchText);
            this.splitContainer1.Panel2.Controls.Add(this.WorkersGrid);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("宋体", 12F);
            this.splitContainer1.Size = new System.Drawing.Size(1466, 670);
            this.splitContainer1.SplitterDistance = 244;
            this.splitContainer1.TabIndex = 21;
            // 
            // TeamsLb
            // 
            this.TeamsLb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TeamsLb.Font = new System.Drawing.Font("宋体", 12F);
            this.TeamsLb.FormattingEnabled = true;
            this.TeamsLb.ItemHeight = 16;
            this.TeamsLb.Location = new System.Drawing.Point(-1, 11);
            this.TeamsLb.Name = "TeamsLb";
            this.TeamsLb.Size = new System.Drawing.Size(242, 660);
            this.TeamsLb.TabIndex = 0;
            this.TeamsLb.SelectedIndexChanged += new System.EventHandler(this.TeamsLb_SelectedIndexChanged);
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.Transparent;
            this.SearchButton.BaseColor = System.Drawing.SystemColors.ControlDark;
            this.SearchButton.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.SearchButton.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.SearchButton.DownBack = null;
            this.SearchButton.Location = new System.Drawing.Point(989, 5);
            this.SearchButton.MouseBack = null;
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.NormlBack = null;
            this.SearchButton.Size = new System.Drawing.Size(144, 26);
            this.SearchButton.TabIndex = 24;
            this.SearchButton.Text = "搜 索";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(731, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "-";
            // 
            // re_Offline
            // 
            this.re_Offline.AutoSize = true;
            this.re_Offline.Location = new System.Drawing.Point(442, 8);
            this.re_Offline.Name = "re_Offline";
            this.re_Offline.Size = new System.Drawing.Size(58, 20);
            this.re_Offline.TabIndex = 22;
            this.re_Offline.Text = "离场";
            this.re_Offline.UseVisualStyleBackColor = true;
            this.re_Offline.CheckedChanged += new System.EventHandler(this.re_Offline_CheckedChanged);
            // 
            // re_Online
            // 
            this.re_Online.AutoSize = true;
            this.re_Online.Checked = true;
            this.re_Online.Location = new System.Drawing.Point(368, 8);
            this.re_Online.Name = "re_Online";
            this.re_Online.Size = new System.Drawing.Size(58, 20);
            this.re_Online.TabIndex = 22;
            this.re_Online.TabStop = true;
            this.re_Online.Text = "在场";
            this.re_Online.UseVisualStyleBackColor = true;
            this.re_Online.CheckedChanged += new System.EventHandler(this.re_Online_CheckedChanged);
            // 
            // WorkersGridPager
            // 
            this.WorkersGridPager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WorkersGridPager.Location = new System.Drawing.Point(5, 641);
            this.WorkersGridPager.Margin = new System.Windows.Forms.Padding(4);
            this.WorkersGridPager.Name = "WorkersGridPager";
            this.WorkersGridPager.PageCount = 0;
            this.WorkersGridPager.PageIndex = 1;
            this.WorkersGridPager.PageSize = 15;
            this.WorkersGridPager.PagingHandler = null;
            this.WorkersGridPager.Size = new System.Drawing.Size(307, 25);
            this.WorkersGridPager.TabIndex = 21;
            // 
            // time_endTime
            // 
            this.time_endTime.Location = new System.Drawing.Point(753, 5);
            this.time_endTime.Name = "time_endTime";
            this.time_endTime.Size = new System.Drawing.Size(200, 26);
            this.time_endTime.TabIndex = 20;
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(23, 5);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(329, 26);
            this.SearchText.TabIndex = 16;
            this.SearchText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchText_KeyDown);
            // 
            // WorkersGrid
            // 
            this.WorkersGrid.AllowUserToAddRows = false;
            this.WorkersGrid.AllowUserToDeleteRows = false;
            this.WorkersGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WorkersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.WorkersGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WorkersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WorkersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userId,
            this.poId,
            this.recordId,
            this.TeamName,
            this.userName,
            this.identityNum,
            this.DeviceCode,
            this.ClockTypeText,
            this.ClockTime,
            this.SimilarDegree,
            this.photoUrl1,
            this.photoUrl});
            this.WorkersGrid.ContextMenuStrip = this.WorkerCms;
            this.WorkersGrid.Location = new System.Drawing.Point(5, 37);
            this.WorkersGrid.MultiSelect = false;
            this.WorkersGrid.Name = "WorkersGrid";
            this.WorkersGrid.ReadOnly = true;
            this.WorkersGrid.RowHeadersVisible = false;
            this.WorkersGrid.RowHeadersWidth = 20;
            this.WorkersGrid.RowTemplate.Height = 23;
            this.WorkersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WorkersGrid.Size = new System.Drawing.Size(1210, 597);
            this.WorkersGrid.TabIndex = 0;
            this.WorkersGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.WorkersGrid_CellContentClick);
            this.WorkersGrid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.WorkersGrid_CellMouseEnter);
            this.WorkersGrid.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.WorkersGrid_CellMouseLeave);
            // 
            // WorkerCms
            // 
            this.WorkerCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WorkerDetailMenuItem});
            this.WorkerCms.Name = "TeamsCms";
            this.WorkerCms.Size = new System.Drawing.Size(125, 26);
            // 
            // WorkerDetailMenuItem
            // 
            this.WorkerDetailMenuItem.Name = "WorkerDetailMenuItem";
            this.WorkerDetailMenuItem.Size = new System.Drawing.Size(124, 22);
            this.WorkerDetailMenuItem.Text = "工人信息";
            this.WorkerDetailMenuItem.Click += new System.EventHandler(this.WorkerDetailMenuItem_Click);
            // 
            // userId
            // 
            this.userId.DataPropertyName = "userId";
            this.userId.HeaderText = "用户id";
            this.userId.Name = "userId";
            this.userId.ReadOnly = true;
            this.userId.Visible = false;
            // 
            // poId
            // 
            this.poId.DataPropertyName = "poId";
            this.poId.HeaderText = "班组id";
            this.poId.Name = "poId";
            this.poId.ReadOnly = true;
            this.poId.Visible = false;
            // 
            // recordId
            // 
            this.recordId.DataPropertyName = "recordId";
            this.recordId.HeaderText = "recordId";
            this.recordId.Name = "recordId";
            this.recordId.ReadOnly = true;
            this.recordId.Visible = false;
            // 
            // TeamName
            // 
            this.TeamName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TeamName.DataPropertyName = "teamName";
            this.TeamName.FillWeight = 72.08121F;
            this.TeamName.HeaderText = "班组";
            this.TeamName.MinimumWidth = 280;
            this.TeamName.Name = "TeamName";
            this.TeamName.ReadOnly = true;
            // 
            // userName
            // 
            this.userName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.userName.DataPropertyName = "userName";
            this.userName.FillWeight = 0.2477048F;
            this.userName.HeaderText = "姓名";
            this.userName.MinimumWidth = 100;
            this.userName.Name = "userName";
            this.userName.ReadOnly = true;
            // 
            // identityNum
            // 
            this.identityNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.identityNum.DataPropertyName = "identityNum";
            this.identityNum.FillWeight = 1.552782F;
            this.identityNum.HeaderText = "证件号";
            this.identityNum.MinimumWidth = 200;
            this.identityNum.Name = "identityNum";
            this.identityNum.ReadOnly = true;
            // 
            // DeviceCode
            // 
            this.DeviceCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DeviceCode.DataPropertyName = "machineNum";
            this.DeviceCode.FillWeight = 2.100386F;
            this.DeviceCode.HeaderText = "设备号";
            this.DeviceCode.MinimumWidth = 100;
            this.DeviceCode.Name = "DeviceCode";
            this.DeviceCode.ReadOnly = true;
            this.DeviceCode.Visible = false;
            // 
            // ClockTypeText
            // 
            this.ClockTypeText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClockTypeText.DataPropertyName = "checkType";
            this.ClockTypeText.FillWeight = 4.261663F;
            this.ClockTypeText.HeaderText = "打卡类型";
            this.ClockTypeText.MinimumWidth = 100;
            this.ClockTypeText.Name = "ClockTypeText";
            this.ClockTypeText.ReadOnly = true;
            // 
            // ClockTime
            // 
            this.ClockTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClockTime.DataPropertyName = "checkTime";
            dataGridViewCellStyle1.Format = "F";
            dataGridViewCellStyle1.NullValue = null;
            this.ClockTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.ClockTime.FillWeight = 8.646872F;
            this.ClockTime.HeaderText = "打卡时间";
            this.ClockTime.MinimumWidth = 200;
            this.ClockTime.Name = "ClockTime";
            this.ClockTime.ReadOnly = true;
            // 
            // SimilarDegree
            // 
            this.SimilarDegree.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SimilarDegree.DataPropertyName = "similarity";
            this.SimilarDegree.FillWeight = 17.55564F;
            this.SimilarDegree.HeaderText = "相似度(%）";
            this.SimilarDegree.MinimumWidth = 120;
            this.SimilarDegree.Name = "SimilarDegree";
            this.SimilarDegree.ReadOnly = true;
            // 
            // photoUrl1
            // 
            this.photoUrl1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.photoUrl1.DataPropertyName = "photoUrl";
            this.photoUrl1.HeaderText = "打卡人脸";
            this.photoUrl1.MinimumWidth = 150;
            this.photoUrl1.Name = "photoUrl1";
            this.photoUrl1.ReadOnly = true;
            this.photoUrl1.Visible = false;
            // 
            // photoUrl
            // 
            this.photoUrl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.photoUrl.Description = "点击查看大图";
            this.photoUrl.FillWeight = 120F;
            this.photoUrl.HeaderText = "打卡人脸";
            this.photoUrl.Image = global::KtpAcsMiddleware.WinForm.Api.Chidao.Properties.Resources.img_404;
            this.photoUrl.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.photoUrl.MinimumWidth = 120;
            this.photoUrl.Name = "photoUrl";
            this.photoUrl.ReadOnly = true;
            this.photoUrl.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.photoUrl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // WorkerAuthList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 717);
            this.Controls.Add(this.splitContainer1);
            this.Name = "WorkerAuthList";
            this.Text = "班组考勤";
            this.Load += new System.EventHandler(this.WorkerAuthList_Load);
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
        private System.Windows.Forms.DateTimePicker time_beginTime;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox TeamsLb;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.DataGridView WorkersGrid;
        private System.Windows.Forms.ContextMenuStrip WorkerCms;
        private System.Windows.Forms.ToolStripMenuItem WorkerDetailMenuItem;
        private UserControls.KtpGridPager WorkersGridPager;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton re_Offline;
        private System.Windows.Forms.RadioButton re_Online;
        private System.Windows.Forms.DateTimePicker time_endTime;
        private CCWin.SkinControl.SkinButton SearchButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn userId;
        private System.Windows.Forms.DataGridViewTextBoxColumn poId;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn userName;
        private System.Windows.Forms.DataGridViewTextBoxColumn identityNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClockTypeText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClockTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn SimilarDegree;
        private System.Windows.Forms.DataGridViewTextBoxColumn photoUrl1;
        private System.Windows.Forms.DataGridViewImageColumn photoUrl;
    }
}