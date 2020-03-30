namespace KtpAcsMiddleware.WinForm
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.dataGridView_deviceList = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Title_deviceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machineNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deviceIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title_direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title_deviceStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerCms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeviceEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeviceDelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnWorker = new System.Windows.Forms.Button();
            this.button_viewDeviceUserInfo = new System.Windows.Forms.Button();
            this.skinToolTip1 = new CCWin.SkinToolTip(this.components);
            this.button_addDevice = new System.Windows.Forms.Button();
            this.btnSyn = new CCWin.SkinControl.SkinButton();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.lab_sumCount = new System.Windows.Forms.Label();
            this.lalUnCertTotalProCount = new System.Windows.Forms.Label();
            this.label_proCount = new System.Windows.Forms.Label();
            this.label_proId = new System.Windows.Forms.Label();
            this.lab_projoectName = new System.Windows.Forms.Label();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labIp = new CCWin.SkinControl.SkinLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Auth = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menu_application = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu_application_IsManualAddInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_application_journal = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_application_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_deviceList)).BeginInit();
            this.WorkerCms.SuspendLayout();
            this.skinPanel1.SuspendLayout();
            this.menu_application.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_deviceList
            // 
            this.dataGridView_deviceList.AllowUserToAddRows = false;
            this.dataGridView_deviceList.AllowUserToDeleteRows = false;
            this.dataGridView_deviceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_deviceList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_deviceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_deviceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Title_deviceId,
            this.machineNum,
            this.deviceIp,
            this.Title_direction,
            this.panelCount,
            this.description,
            this.Title_deviceStatus});
            this.dataGridView_deviceList.ContextMenuStrip = this.WorkerCms;
            this.dataGridView_deviceList.Location = new System.Drawing.Point(30, 112);
            this.dataGridView_deviceList.MultiSelect = false;
            this.dataGridView_deviceList.Name = "dataGridView_deviceList";
            this.dataGridView_deviceList.RowHeadersVisible = false;
            this.dataGridView_deviceList.RowTemplate.Height = 23;
            this.dataGridView_deviceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_deviceList.Size = new System.Drawing.Size(966, 524);
            this.dataGridView_deviceList.TabIndex = 15;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "isSyn";
            this.Column2.FillWeight = 69.03552F;
            this.Column2.HeaderText = "选择";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Title_deviceId
            // 
            this.Title_deviceId.DataPropertyName = "id";
            this.Title_deviceId.HeaderText = "id";
            this.Title_deviceId.MinimumWidth = 100;
            this.Title_deviceId.Name = "Title_deviceId";
            this.Title_deviceId.Visible = false;
            // 
            // machineNum
            // 
            this.machineNum.DataPropertyName = "machineNum";
            this.machineNum.FillWeight = 109.7361F;
            this.machineNum.HeaderText = "人脸识别设备ID";
            this.machineNum.Name = "machineNum";
            // 
            // deviceIp
            // 
            this.deviceIp.DataPropertyName = "deviceIp";
            this.deviceIp.FillWeight = 109.7361F;
            this.deviceIp.HeaderText = "人脸识别设备地址";
            this.deviceIp.MinimumWidth = 150;
            this.deviceIp.Name = "deviceIp";
            this.deviceIp.ReadOnly = true;
            // 
            // Title_direction
            // 
            this.Title_direction.DataPropertyName = "deviceIn";
            this.Title_direction.FillWeight = 109.7361F;
            this.Title_direction.HeaderText = "进/出闸";
            this.Title_direction.Name = "Title_direction";
            // 
            // panelCount
            // 
            this.panelCount.DataPropertyName = "panelCount";
            this.panelCount.FillWeight = 72.54777F;
            this.panelCount.HeaderText = "在场人数";
            this.panelCount.Name = "panelCount";
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            this.description.FillWeight = 109.7361F;
            this.description.HeaderText = "描述";
            this.description.Name = "description";
            // 
            // Title_deviceStatus
            // 
            this.Title_deviceStatus.DataPropertyName = "panelIsConn";
            this.Title_deviceStatus.HeaderText = "是否连接设备";
            this.Title_deviceStatus.Name = "Title_deviceStatus";
            // 
            // WorkerCms
            // 
            this.WorkerCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeviceEditMenuItem,
            this.DeviceDelMenuItem});
            this.WorkerCms.Name = "TeamsCms";
            this.WorkerCms.Size = new System.Drawing.Size(101, 48);
            // 
            // DeviceEditMenuItem
            // 
            this.DeviceEditMenuItem.Name = "DeviceEditMenuItem";
            this.DeviceEditMenuItem.Size = new System.Drawing.Size(100, 22);
            this.DeviceEditMenuItem.Text = "编辑";
            this.DeviceEditMenuItem.Click += new System.EventHandler(this.DeviceEditMenuItem_Click);
            // 
            // DeviceDelMenuItem
            // 
            this.DeviceDelMenuItem.Name = "DeviceDelMenuItem";
            this.DeviceDelMenuItem.Size = new System.Drawing.Size(100, 22);
            this.DeviceDelMenuItem.Text = "删除";
            this.DeviceDelMenuItem.Click += new System.EventHandler(this.DeviceDelMenuItem_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("宋体", 9F);
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(312, 17);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(65, 12);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "项目编号：";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnWorker
            // 
            this.btnWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnWorker.Location = new System.Drawing.Point(1019, 401);
            this.btnWorker.Name = "btnWorker";
            this.btnWorker.Size = new System.Drawing.Size(149, 49);
            this.btnWorker.TabIndex = 19;
            this.btnWorker.Text = "添加项目部人员";
            this.btnWorker.UseVisualStyleBackColor = true;
            this.btnWorker.Click += new System.EventHandler(this.btnWorker_Click);
            // 
            // button_viewDeviceUserInfo
            // 
            this.button_viewDeviceUserInfo.Location = new System.Drawing.Point(1025, 42);
            this.button_viewDeviceUserInfo.Name = "button_viewDeviceUserInfo";
            this.button_viewDeviceUserInfo.Size = new System.Drawing.Size(149, 38);
            this.button_viewDeviceUserInfo.TabIndex = 16;
            this.button_viewDeviceUserInfo.Text = "项目人员列表";
            this.button_viewDeviceUserInfo.UseVisualStyleBackColor = true;
            this.button_viewDeviceUserInfo.Click += new System.EventHandler(this.button_viewDeviceUserInfo_Click);
            // 
            // skinToolTip1
            // 
            this.skinToolTip1.AutoPopDelay = 5000;
            this.skinToolTip1.InitialDelay = 500;
            this.skinToolTip1.OwnerDraw = true;
            this.skinToolTip1.ReshowDelay = 800;
            // 
            // button_addDevice
            // 
            this.button_addDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button_addDevice.Location = new System.Drawing.Point(1019, 228);
            this.button_addDevice.Name = "button_addDevice";
            this.button_addDevice.Size = new System.Drawing.Size(149, 49);
            this.button_addDevice.TabIndex = 14;
            this.button_addDevice.Text = "添加面板";
            this.button_addDevice.UseVisualStyleBackColor = true;
            this.button_addDevice.Click += new System.EventHandler(this.button_addDevice_Click);
            // 
            // btnSyn
            // 
            this.btnSyn.BackColor = System.Drawing.Color.Silver;
            this.btnSyn.BaseColor = System.Drawing.Color.DarkGray;
            this.btnSyn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSyn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSyn.DownBack = null;
            this.btnSyn.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSyn.Location = new System.Drawing.Point(1019, 157);
            this.btnSyn.MouseBack = null;
            this.btnSyn.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSyn.Name = "btnSyn";
            this.btnSyn.NormlBack = null;
            this.btnSyn.Size = new System.Drawing.Size(149, 33);
            this.btnSyn.TabIndex = 20;
            this.btnSyn.Text = "同 步";
            this.btnSyn.UseVisualStyleBackColor = false;
            this.btnSyn.Click += new System.EventHandler(this.btnSyn_Click);
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.lab_sumCount);
            this.skinPanel1.Controls.Add(this.lalUnCertTotalProCount);
            this.skinPanel1.Controls.Add(this.label_proCount);
            this.skinPanel1.Controls.Add(this.label_proId);
            this.skinPanel1.Controls.Add(this.lab_projoectName);
            this.skinPanel1.Controls.Add(this.skinLine1);
            this.skinPanel1.Controls.Add(this.label5);
            this.skinPanel1.Controls.Add(this.label6);
            this.skinPanel1.Controls.Add(this.label1);
            this.skinPanel1.Controls.Add(this.label8);
            this.skinPanel1.Controls.Add(this.label4);
            this.skinPanel1.Controls.Add(this.label7);
            this.skinPanel1.Controls.Add(this.label9);
            this.skinPanel1.Controls.Add(this.Label2);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(30, 51);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(917, 46);
            this.skinPanel1.TabIndex = 22;
            // 
            // lab_sumCount
            // 
            this.lab_sumCount.AutoSize = true;
            this.lab_sumCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_sumCount.Location = new System.Drawing.Point(857, 17);
            this.lab_sumCount.Name = "lab_sumCount";
            this.lab_sumCount.Size = new System.Drawing.Size(26, 12);
            this.lab_sumCount.TabIndex = 29;
            this.lab_sumCount.Text = "120";
            // 
            // lalUnCertTotalProCount
            // 
            this.lalUnCertTotalProCount.AutoSize = true;
            this.lalUnCertTotalProCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lalUnCertTotalProCount.Location = new System.Drawing.Point(694, 17);
            this.lalUnCertTotalProCount.Name = "lalUnCertTotalProCount";
            this.lalUnCertTotalProCount.Size = new System.Drawing.Size(26, 12);
            this.lalUnCertTotalProCount.TabIndex = 29;
            this.lalUnCertTotalProCount.Text = "130";
            this.lalUnCertTotalProCount.Click += new System.EventHandler(this.lalUnCertTotalProCount_Click);
            // 
            // label_proCount
            // 
            this.label_proCount.AutoSize = true;
            this.label_proCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_proCount.Location = new System.Drawing.Point(532, 17);
            this.label_proCount.Name = "label_proCount";
            this.label_proCount.Size = new System.Drawing.Size(26, 12);
            this.label_proCount.TabIndex = 29;
            this.label_proCount.Text = "160";
            // 
            // label_proId
            // 
            this.label_proId.AutoSize = true;
            this.label_proId.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_proId.Location = new System.Drawing.Point(372, 17);
            this.label_proId.Name = "label_proId";
            this.label_proId.Size = new System.Drawing.Size(26, 12);
            this.label_proId.TabIndex = 29;
            this.label_proId.Text = "130";
            // 
            // lab_projoectName
            // 
            this.lab_projoectName.AutoSize = true;
            this.lab_projoectName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_projoectName.Location = new System.Drawing.Point(85, 17);
            this.lab_projoectName.Name = "lab_projoectName";
            this.lab_projoectName.Size = new System.Drawing.Size(57, 12);
            this.lab_projoectName.TabIndex = 29;
            this.lab_projoectName.Text = "项目名称";
            // 
            // skinLine1
            // 
            this.skinLine1.BackColor = System.Drawing.Color.Transparent;
            this.skinLine1.LineColor = System.Drawing.Color.Black;
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(12, 44);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(1132, 10);
            this.skinLine1.TabIndex = 28;
            this.skinLine1.Text = "skinLine1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 9F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(618, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "项目未认证：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(726, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "人";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(564, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "人";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("宋体", 9F);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(886, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "人";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(452, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "项目已认证：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("宋体", 9F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(774, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "项目总人数：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("宋体", 9F);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(14, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "当前项目：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labIp
            // 
            this.labIp.AutoSize = true;
            this.labIp.BackColor = System.Drawing.Color.Transparent;
            this.labIp.BorderColor = System.Drawing.Color.White;
            this.labIp.Font = new System.Drawing.Font("宋体", 9F);
            this.labIp.Location = new System.Drawing.Point(1076, 623);
            this.labIp.Name = "labIp";
            this.labIp.Size = new System.Drawing.Size(23, 12);
            this.labIp.TabIndex = 23;
            this.labIp.Text = "130";
            this.labIp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labIp.Click += new System.EventHandler(this.labIp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(1013, 623);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "本机IP:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button1.Location = new System.Drawing.Point(1019, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 49);
            this.button1.TabIndex = 25;
            this.button1.Text = "添加工人";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Auth
            // 
            this.btn_Auth.Location = new System.Drawing.Point(1025, 86);
            this.btn_Auth.Name = "btn_Auth";
            this.btn_Auth.Size = new System.Drawing.Size(149, 38);
            this.btn_Auth.TabIndex = 26;
            this.btn_Auth.Text = "项目考勤";
            this.btn_Auth.UseVisualStyleBackColor = true;
            this.btn_Auth.Click += new System.EventHandler(this.btn_Auth_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.menu_application;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // menu_application
            // 
            this.menu_application.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_application_IsManualAddInfo,
            this.menu_application_journal,
            this.menu_application_Exit});
            this.menu_application.Name = "menu_application";
            this.menu_application.Size = new System.Drawing.Size(149, 70);
            // 
            // menu_application_IsManualAddInfo
            // 
            this.menu_application_IsManualAddInfo.CheckOnClick = true;
            this.menu_application_IsManualAddInfo.Name = "menu_application_IsManualAddInfo";
            this.menu_application_IsManualAddInfo.Size = new System.Drawing.Size(148, 22);
            this.menu_application_IsManualAddInfo.Text = "是否手动编辑";
            this.menu_application_IsManualAddInfo.CheckStateChanged += new System.EventHandler(this.menu_application_IsManualAddInfo_CheckStateChanged);
            // 
            // menu_application_journal
            // 
            this.menu_application_journal.Name = "menu_application_journal";
            this.menu_application_journal.Size = new System.Drawing.Size(148, 22);
            this.menu_application_journal.Text = "日志";
            this.menu_application_journal.Click += new System.EventHandler(this.menu_application_journal_Click);
            // 
            // menu_application_Exit
            // 
            this.menu_application_Exit.Name = "menu_application_Exit";
            this.menu_application_Exit.Size = new System.Drawing.Size(148, 22);
            this.menu_application_Exit.Text = "退出";
            this.menu_application_Exit.Click += new System.EventHandler(this.menu_application_Exit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KtpAcsMiddleware.WinForm.Api.Chidao.Properties.Resources.shuaxin;
            this.pictureBox1.Location = new System.Drawing.Point(953, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 42);
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::KtpAcsMiddleware.WinForm.Api.Chidao.Properties.Resources.off;
            this.pictureBox2.Location = new System.Drawing.Point(1037, 514);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(118, 38);
            this.pictureBox2.TabIndex = 42;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 647);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_Auth);
            this.Controls.Add(this.dataGridView_deviceList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.skinPanel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labIp);
            this.Controls.Add(this.btnSyn);
            this.Controls.Add(this.button_addDevice);
            this.Controls.Add(this.btnWorker);
            this.Controls.Add(this.button_viewDeviceUserInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Home";
            this.Text = "Home";
            this.Deactivate += new System.EventHandler(this.Home_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Home_FormClosed);
            this.Load += new System.EventHandler(this.Home_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Home_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_deviceList)).EndInit();
            this.WorkerCms.ResumeLayout(false);
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            this.menu_application.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_deviceList;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Button btnWorker;
        private System.Windows.Forms.Button button_viewDeviceUserInfo;
        private CCWin.SkinToolTip skinToolTip1;
        private System.Windows.Forms.Button button_addDevice;
        private System.Windows.Forms.ContextMenuStrip WorkerCms;
        private System.Windows.Forms.ToolStripMenuItem DeviceEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeviceDelMenuItem;
        private CCWin.SkinControl.SkinButton btnSyn;
        private CCWin.SkinControl.SkinPanel skinPanel1;
        private System.Windows.Forms.Button button1;
        private CCWin.SkinControl.SkinLabel labIp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private CCWin.SkinControl.SkinLine skinLine1;
        private System.Windows.Forms.Label lab_projoectName;
        private System.Windows.Forms.Label lab_sumCount;
        private System.Windows.Forms.Label lalUnCertTotalProCount;
        private System.Windows.Forms.Label label_proCount;
        private System.Windows.Forms.Label label_proId;
        private System.Windows.Forms.Button btn_Auth;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip menu_application;
        private System.Windows.Forms.ToolStripMenuItem menu_application_Exit;
        private System.Windows.Forms.ToolStripMenuItem menu_application_journal;
        private System.Windows.Forms.ToolStripMenuItem menu_application_IsManualAddInfo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title_deviceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title_direction;
        private System.Windows.Forms.DataGridViewTextBoxColumn panelCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title_deviceStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}