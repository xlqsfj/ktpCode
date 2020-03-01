namespace KtpAcs.WinForm.Auths
{
    partial class WorkerAuths
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
            this.AuthWorkersGrid = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentityCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClockTypeText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClockTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SimilarDegree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ktpState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerCms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.WorkerDetailMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkerPushMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.com_DeviceList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.re_Offline = new System.Windows.Forms.RadioButton();
            this.re_Online = new System.Windows.Forms.RadioButton();
            this.time_endTime = new System.Windows.Forms.DateTimePicker();
            this.time_beginTime = new System.Windows.Forms.DateTimePicker();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.leb_service = new System.Windows.Forms.Label();
            this.btn_service = new CCWin.SkinControl.SkinButton();
            this.btnSyn = new CCWin.SkinControl.SkinButton();
            this.SearchButton = new CCWin.SkinControl.SkinButton();
            this.AuthWorkersGridPager = new KtpAcs.WinForm.UserControls.KtpGridPager();
            ((System.ComponentModel.ISupportInitialize)(this.AuthWorkersGrid)).BeginInit();
            this.WorkerCms.SuspendLayout();
            this.SuspendLayout();
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
            this.WorkerId,
            this.WorkerName,
            this.IdentityCode,
            this.ClockTypeText,
            this.ClockTime,
            this.DeviceCode,
            this.SimilarDegree,
            this.TeamName,
            this.ktpState});
            this.AuthWorkersGrid.ContextMenuStrip = this.WorkerCms;
            this.AuthWorkersGrid.Location = new System.Drawing.Point(11, 97);
            this.AuthWorkersGrid.MultiSelect = false;
            this.AuthWorkersGrid.Name = "AuthWorkersGrid";
            this.AuthWorkersGrid.ReadOnly = true;
            this.AuthWorkersGrid.RowHeadersVisible = false;
            this.AuthWorkersGrid.RowHeadersWidth = 20;
            this.AuthWorkersGrid.RowTemplate.Height = 23;
            this.AuthWorkersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AuthWorkersGrid.Size = new System.Drawing.Size(1266, 531);
            this.AuthWorkersGrid.TabIndex = 1;
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
            this.WorkerName.FillWeight = 5.834794F;
            this.WorkerName.HeaderText = "姓名";
            this.WorkerName.MinimumWidth = 100;
            this.WorkerName.Name = "WorkerName";
            this.WorkerName.ReadOnly = true;
            // 
            // IdentityCode
            // 
            this.IdentityCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IdentityCode.DataPropertyName = "IdentityCode";
            this.IdentityCode.FillWeight = 9.33567F;
            this.IdentityCode.HeaderText = "证件号";
            this.IdentityCode.MinimumWidth = 150;
            this.IdentityCode.Name = "IdentityCode";
            this.IdentityCode.ReadOnly = true;
            // 
            // ClockTypeText
            // 
            this.ClockTypeText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClockTypeText.DataPropertyName = "ClockTypeText";
            this.ClockTypeText.FillWeight = 48.29441F;
            this.ClockTypeText.HeaderText = "打卡类型";
            this.ClockTypeText.MinimumWidth = 100;
            this.ClockTypeText.Name = "ClockTypeText";
            this.ClockTypeText.ReadOnly = true;
            // 
            // ClockTime
            // 
            this.ClockTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClockTime.DataPropertyName = "ClockTimeText";
            this.ClockTime.FillWeight = 7.001753F;
            this.ClockTime.HeaderText = "打卡时间";
            this.ClockTime.MinimumWidth = 150;
            this.ClockTime.Name = "ClockTime";
            this.ClockTime.ReadOnly = true;
            // 
            // DeviceCode
            // 
            this.DeviceCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DeviceCode.DataPropertyName = "DeviceCode";
            this.DeviceCode.FillWeight = 5.834794F;
            this.DeviceCode.HeaderText = "设备号";
            this.DeviceCode.MinimumWidth = 110;
            this.DeviceCode.Name = "DeviceCode";
            this.DeviceCode.ReadOnly = true;
            // 
            // SimilarDegree
            // 
            this.SimilarDegree.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SimilarDegree.FillWeight = 5.834794F;
            this.SimilarDegree.HeaderText = "相似度";
            this.SimilarDegree.MinimumWidth = 110;
            this.SimilarDegree.Name = "SimilarDegree";
            this.SimilarDegree.ReadOnly = true;
            // 
            // TeamName
            // 
            this.TeamName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TeamName.DataPropertyName = "TeamName";
            this.TeamName.FillWeight = 9.33567F;
            this.TeamName.HeaderText = "班组";
            this.TeamName.MinimumWidth = 180;
            this.TeamName.Name = "TeamName";
            this.TeamName.ReadOnly = true;
            // 
            // ktpState
            // 
            this.ktpState.DataPropertyName = "StateText";
            this.ktpState.FillWeight = 50.52811F;
            this.ktpState.HeaderText = "同步状态";
            this.ktpState.MinimumWidth = 100;
            this.ktpState.Name = "ktpState";
            this.ktpState.ReadOnly = true;
            // 
            // WorkerCms
            // 
            this.WorkerCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WorkerDetailMenuItem,
            this.WorkerPushMenuItem});
            this.WorkerCms.Name = "TeamsCms";
            this.WorkerCms.Size = new System.Drawing.Size(125, 48);
            // 
            // WorkerDetailMenuItem
            // 
            this.WorkerDetailMenuItem.Name = "WorkerDetailMenuItem";
            this.WorkerDetailMenuItem.Size = new System.Drawing.Size(124, 22);
            this.WorkerDetailMenuItem.Text = "详细信息";
            // 
            // WorkerPushMenuItem
            // 
            this.WorkerPushMenuItem.Name = "WorkerPushMenuItem";
            this.WorkerPushMenuItem.Size = new System.Drawing.Size(124, 22);
            this.WorkerPushMenuItem.Text = "推送当前";
            this.WorkerPushMenuItem.Click += new System.EventHandler(this.WorkerPushMenuItem_Click);
            // 
            // com_DeviceList
            // 
            this.com_DeviceList.FormattingEnabled = true;
            this.com_DeviceList.Location = new System.Drawing.Point(1001, 55);
            this.com_DeviceList.Name = "com_DeviceList";
            this.com_DeviceList.Size = new System.Drawing.Size(121, 20);
            this.com_DeviceList.TabIndex = 3;
            this.com_DeviceList.SelectedIndexChanged += new System.EventHandler(this.com_DeviceList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(942, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "设备号：";
            // 
            // re_Offline
            // 
            this.re_Offline.AutoSize = true;
            this.re_Offline.Location = new System.Drawing.Point(407, 56);
            this.re_Offline.Name = "re_Offline";
            this.re_Offline.Size = new System.Drawing.Size(47, 16);
            this.re_Offline.TabIndex = 26;
            this.re_Offline.Text = "离场";
            this.re_Offline.UseVisualStyleBackColor = true;
            this.re_Offline.CheckedChanged += new System.EventHandler(this.re_Offline_CheckedChanged);
            // 
            // re_Online
            // 
            this.re_Online.AutoSize = true;
            this.re_Online.Checked = true;
            this.re_Online.Location = new System.Drawing.Point(333, 56);
            this.re_Online.Name = "re_Online";
            this.re_Online.Size = new System.Drawing.Size(47, 16);
            this.re_Online.TabIndex = 27;
            this.re_Online.TabStop = true;
            this.re_Online.Text = "在场";
            this.re_Online.UseVisualStyleBackColor = true;
            this.re_Online.CheckedChanged += new System.EventHandler(this.re_Online_CheckedChanged);
            // 
            // time_endTime
            // 
            this.time_endTime.Location = new System.Drawing.Point(718, 53);
            this.time_endTime.Name = "time_endTime";
            this.time_endTime.Size = new System.Drawing.Size(200, 21);
            this.time_endTime.TabIndex = 24;
            // 
            // time_beginTime
            // 
            this.time_beginTime.Location = new System.Drawing.Point(490, 53);
            this.time_beginTime.Name = "time_beginTime";
            this.time_beginTime.Size = new System.Drawing.Size(200, 21);
            this.time_beginTime.TabIndex = 25;
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(16, 54);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(300, 21);
            this.SearchText.TabIndex = 23;
            // 
            // leb_service
            // 
            this.leb_service.AutoSize = true;
            this.leb_service.ForeColor = System.Drawing.Color.Red;
            this.leb_service.Location = new System.Drawing.Point(636, 643);
            this.leb_service.Name = "leb_service";
            this.leb_service.Size = new System.Drawing.Size(293, 12);
            this.leb_service.TabIndex = 28;
            this.leb_service.Text = "服务未启动，不能自动同步到服务器，请点击重新开启";
            this.leb_service.Visible = false;
            // 
            // btn_service
            // 
            this.btn_service.BackColor = System.Drawing.Color.Gray;
            this.btn_service.BaseColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_service.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_service.DownBack = null;
            this.btn_service.Location = new System.Drawing.Point(935, 638);
            this.btn_service.MouseBack = null;
            this.btn_service.Name = "btn_service";
            this.btn_service.NormlBack = null;
            this.btn_service.Size = new System.Drawing.Size(75, 23);
            this.btn_service.TabIndex = 29;
            this.btn_service.Text = "开 启";
            this.btn_service.UseVisualStyleBackColor = false;
            this.btn_service.Visible = false;
            // 
            // btnSyn
            // 
            this.btnSyn.BackColor = System.Drawing.Color.Silver;
            this.btnSyn.BaseColor = System.Drawing.Color.DarkGray;
            this.btnSyn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSyn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSyn.DownBack = null;
            this.btnSyn.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSyn.Location = new System.Drawing.Point(1114, 634);
            this.btnSyn.MouseBack = null;
            this.btnSyn.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSyn.Name = "btnSyn";
            this.btnSyn.NormlBack = null;
            this.btnSyn.Size = new System.Drawing.Size(149, 33);
            this.btnSyn.TabIndex = 30;
            this.btnSyn.Text = "同 步";
            this.btnSyn.UseVisualStyleBackColor = false;
            this.btnSyn.Click += new System.EventHandler(this.btnSyn_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.Transparent;
            this.SearchButton.BaseColor = System.Drawing.SystemColors.ControlDark;
            this.SearchButton.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.SearchButton.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.SearchButton.DownBack = null;
            this.SearchButton.Location = new System.Drawing.Point(1137, 51);
            this.SearchButton.MouseBack = null;
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.NormlBack = null;
            this.SearchButton.Size = new System.Drawing.Size(135, 26);
            this.SearchButton.TabIndex = 31;
            this.SearchButton.Text = "搜 索";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // AuthWorkersGridPager
            // 
            this.AuthWorkersGridPager.AllowDrop = true;
            this.AuthWorkersGridPager.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AuthWorkersGridPager.Location = new System.Drawing.Point(1, 643);
            this.AuthWorkersGridPager.Name = "AuthWorkersGridPager";
            this.AuthWorkersGridPager.PageCount = 0;
            this.AuthWorkersGridPager.PageIndex = 1;
            this.AuthWorkersGridPager.PageSize = 15;
            this.AuthWorkersGridPager.PagingHandler = null;
            this.AuthWorkersGridPager.Size = new System.Drawing.Size(431, 30);
            this.AuthWorkersGridPager.TabIndex = 2;
            // 
            // WorkerAuths
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 676);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.btnSyn);
            this.Controls.Add(this.btn_service);
            this.Controls.Add(this.leb_service);
            this.Controls.Add(this.re_Offline);
            this.Controls.Add(this.re_Online);
            this.Controls.Add(this.time_endTime);
            this.Controls.Add(this.time_beginTime);
            this.Controls.Add(this.SearchText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.com_DeviceList);
            this.Controls.Add(this.AuthWorkersGridPager);
            this.Controls.Add(this.AuthWorkersGrid);
            this.Name = "WorkerAuths";
            this.Text = "考勤管理";
            this.Load += new System.EventHandler(this.WorkerAuths_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AuthWorkersGrid)).EndInit();
            this.WorkerCms.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView AuthWorkersGrid;
        private UserControls.KtpGridPager AuthWorkersGridPager;
        private System.Windows.Forms.ComboBox com_DeviceList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton re_Offline;
        private System.Windows.Forms.RadioButton re_Online;
        private System.Windows.Forms.DateTimePicker time_endTime;
        private System.Windows.Forms.DateTimePicker time_beginTime;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.Label leb_service;
        private CCWin.SkinControl.SkinButton btn_service;
        private CCWin.SkinControl.SkinButton btnSyn;
        private CCWin.SkinControl.SkinButton SearchButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentityCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClockTypeText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClockTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SimilarDegree;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ktpState;
        private System.Windows.Forms.ContextMenuStrip WorkerCms;
        private System.Windows.Forms.ToolStripMenuItem WorkerDetailMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WorkerPushMenuItem;
    }
}