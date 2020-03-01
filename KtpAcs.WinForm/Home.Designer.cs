namespace KtpAcs.WinForm
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
            this.dataGridDivce = new System.Windows.Forms.DataGridView();
            this.dId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aaa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultMag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOper = new System.Windows.Forms.DataGridViewButtonColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.con_updateDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.con_current_notice = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Auth = new System.Windows.Forms.Button();
            this.btnSyn = new CCWin.SkinControl.SkinButton();
            this.button_viewDeviceUserInfo = new System.Windows.Forms.Button();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.label_proCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lab_sumCount = new System.Windows.Forms.Label();
            this.lalUnCertTotalProCount = new System.Windows.Forms.Label();
            this.label_proId = new System.Windows.Forms.Label();
            this.lab_projoectName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.btn_service = new CCWin.SkinControl.SkinButton();
            this.leb_service = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labIp = new CCWin.SkinControl.SkinLabel();
            this.lab_web = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menu_application = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu_application_IsManualAddInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_application_journal = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_application_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button_addDevice = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pic_ts = new System.Windows.Forms.PictureBox();
            this.pl_wl = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDivce)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.skinPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menu_application.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_addDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ts)).BeginInit();
            this.pl_wl.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridDivce
            // 
            this.dataGridDivce.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDivce.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dId,
            this.dName,
            this.IpAddress,
            this.direction,
            this.state,
            this.description,
            this.aaa,
            this.resultMag,
            this.btnOper});
            this.dataGridDivce.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridDivce.Location = new System.Drawing.Point(35, 112);
            this.dataGridDivce.Name = "dataGridDivce";
            this.dataGridDivce.ReadOnly = true;
            this.dataGridDivce.RowHeadersVisible = false;
            this.dataGridDivce.RowTemplate.Height = 23;
            this.dataGridDivce.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridDivce.Size = new System.Drawing.Size(983, 429);
            this.dataGridDivce.TabIndex = 0;
            this.dataGridDivce.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridDivce_CellMouseClick);
            // 
            // dId
            // 
            this.dId.DataPropertyName = "Id";
            this.dId.HeaderText = "id";
            this.dId.Name = "dId";
            this.dId.ReadOnly = true;
            this.dId.Visible = false;
            // 
            // dName
            // 
            this.dName.DataPropertyName = "Code";
            this.dName.HeaderText = "设备号";
            this.dName.Name = "dName";
            this.dName.ReadOnly = true;
            // 
            // IpAddress
            // 
            this.IpAddress.DataPropertyName = "IpAddress";
            this.IpAddress.HeaderText = "设备ip号";
            this.IpAddress.Name = "IpAddress";
            this.IpAddress.ReadOnly = true;
            this.IpAddress.Width = 150;
            // 
            // direction
            // 
            this.direction.DataPropertyName = "IsCheckIn";
            this.direction.HeaderText = "进场方向";
            this.direction.Name = "direction";
            this.direction.ReadOnly = true;
            // 
            // state
            // 
            this.state.DataPropertyName = "DState";
            this.state.HeaderText = "状态";
            this.state.Name = "state";
            this.state.ReadOnly = true;
            // 
            // description
            // 
            this.description.DataPropertyName = "Description";
            this.description.HeaderText = "描 述";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // aaa
            // 
            this.aaa.DataPropertyName = "DCount";
            this.aaa.HeaderText = "设备人数";
            this.aaa.Name = "aaa";
            this.aaa.ReadOnly = true;
            // 
            // resultMag
            // 
            this.resultMag.DataPropertyName = "CurrentMag";
            this.resultMag.HeaderText = "最近返回消息";
            this.resultMag.Name = "resultMag";
            this.resultMag.ReadOnly = true;
            this.resultMag.Width = 200;
            // 
            // btnOper
            // 
            this.btnOper.HeaderText = "操作";
            this.btnOper.Name = "btnOper";
            this.btnOper.ReadOnly = true;
            this.btnOper.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnOper.Text = "人员信息";
            this.btnOper.ToolTipText = "点击查看保存人员信息";
            this.btnOper.UseColumnTextForButtonValue = true;
            this.btnOper.Width = 130;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.con_updateDevice,
            this.con_current_notice});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 48);
            // 
            // con_updateDevice
            // 
            this.con_updateDevice.Name = "con_updateDevice";
            this.con_updateDevice.Size = new System.Drawing.Size(148, 22);
            this.con_updateDevice.Text = "编辑设备";
            this.con_updateDevice.Click += new System.EventHandler(this.con_updateDevice_Click);
            // 
            // con_current_notice
            // 
            this.con_current_notice.Name = "con_current_notice";
            this.con_current_notice.Size = new System.Drawing.Size(148, 22);
            this.con_current_notice.Text = "通知当前设备";
            this.con_current_notice.Click += new System.EventHandler(this.con_current_notice_Click);
            // 
            // btn_Auth
            // 
            this.btn_Auth.Location = new System.Drawing.Point(1057, 141);
            this.btn_Auth.Name = "btn_Auth";
            this.btn_Auth.Size = new System.Drawing.Size(149, 38);
            this.btn_Auth.TabIndex = 33;
            this.btn_Auth.Text = "项目考勤";
            this.btn_Auth.UseVisualStyleBackColor = true;
            this.btn_Auth.Click += new System.EventHandler(this.btn_Auth_Click);
            // 
            // btnSyn
            // 
            this.btnSyn.BackColor = System.Drawing.Color.Silver;
            this.btnSyn.BaseColor = System.Drawing.Color.DarkGray;
            this.btnSyn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSyn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSyn.DownBack = null;
            this.btnSyn.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSyn.Location = new System.Drawing.Point(1050, 209);
            this.btnSyn.MouseBack = null;
            this.btnSyn.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSyn.Name = "btnSyn";
            this.btnSyn.NormlBack = null;
            this.btnSyn.Size = new System.Drawing.Size(149, 33);
            this.btnSyn.TabIndex = 30;
            this.btnSyn.Text = "通知面板";
            this.btnSyn.UseVisualStyleBackColor = false;
            this.btnSyn.Click += new System.EventHandler(this.btnSyn_Click);
            // 
            // button_viewDeviceUserInfo
            // 
            this.button_viewDeviceUserInfo.Location = new System.Drawing.Point(1057, 69);
            this.button_viewDeviceUserInfo.Name = "button_viewDeviceUserInfo";
            this.button_viewDeviceUserInfo.Size = new System.Drawing.Size(149, 38);
            this.button_viewDeviceUserInfo.TabIndex = 28;
            this.button_viewDeviceUserInfo.Text = "项目人员列表";
            this.button_viewDeviceUserInfo.UseVisualStyleBackColor = true;
            this.button_viewDeviceUserInfo.Click += new System.EventHandler(this.button_viewDeviceUserInfo_Click);
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.label_proCount);
            this.skinPanel1.Controls.Add(this.label3);
            this.skinPanel1.Controls.Add(this.label4);
            this.skinPanel1.Controls.Add(this.lab_sumCount);
            this.skinPanel1.Controls.Add(this.lalUnCertTotalProCount);
            this.skinPanel1.Controls.Add(this.label_proId);
            this.skinPanel1.Controls.Add(this.lab_projoectName);
            this.skinPanel1.Controls.Add(this.label5);
            this.skinPanel1.Controls.Add(this.label6);
            this.skinPanel1.Controls.Add(this.label8);
            this.skinPanel1.Controls.Add(this.label7);
            this.skinPanel1.Controls.Add(this.label9);
            this.skinPanel1.Controls.Add(this.Label2);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(33, 52);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(924, 46);
            this.skinPanel1.TabIndex = 34;
            this.skinPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.skinPanel1_Paint);
            // 
            // label_proCount
            // 
            this.label_proCount.AutoSize = true;
            this.label_proCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_proCount.Location = new System.Drawing.Point(847, 17);
            this.label_proCount.Name = "label_proCount";
            this.label_proCount.Size = new System.Drawing.Size(26, 12);
            this.label_proCount.TabIndex = 32;
            this.label_proCount.Text = "130";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(733, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "项目未同步人数：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(879, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 30;
            this.label4.Text = "人";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab_sumCount
            // 
            this.lab_sumCount.AutoSize = true;
            this.lab_sumCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_sumCount.Location = new System.Drawing.Point(461, 17);
            this.lab_sumCount.Name = "lab_sumCount";
            this.lab_sumCount.Size = new System.Drawing.Size(26, 12);
            this.lab_sumCount.TabIndex = 29;
            this.lab_sumCount.Text = "120";
            // 
            // lalUnCertTotalProCount
            // 
            this.lalUnCertTotalProCount.AutoSize = true;
            this.lalUnCertTotalProCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lalUnCertTotalProCount.Location = new System.Drawing.Point(645, 17);
            this.lalUnCertTotalProCount.Name = "lalUnCertTotalProCount";
            this.lalUnCertTotalProCount.Size = new System.Drawing.Size(26, 12);
            this.lalUnCertTotalProCount.TabIndex = 29;
            this.lalUnCertTotalProCount.Text = "130";
            // 
            // label_proId
            // 
            this.label_proId.AutoSize = true;
            this.label_proId.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_proId.Location = new System.Drawing.Point(282, 17);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 9F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(569, 17);
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
            this.label6.Location = new System.Drawing.Point(677, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "人";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("宋体", 9F);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(493, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "人";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("宋体", 9F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(378, 17);
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
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("宋体", 9F);
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(222, 17);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(65, 12);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "项目编号：";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_service
            // 
            this.btn_service.BackColor = System.Drawing.Color.Transparent;
            this.btn_service.BaseColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_service.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_service.DownBack = null;
            this.btn_service.Location = new System.Drawing.Point(768, 555);
            this.btn_service.MouseBack = null;
            this.btn_service.Name = "btn_service";
            this.btn_service.NormlBack = null;
            this.btn_service.Size = new System.Drawing.Size(113, 26);
            this.btn_service.TabIndex = 36;
            this.btn_service.Text = "开 启";
            this.btn_service.UseVisualStyleBackColor = false;
            this.btn_service.Visible = false;
            this.btn_service.Click += new System.EventHandler(this.btn_service_Click);
            // 
            // leb_service
            // 
            this.leb_service.AutoSize = true;
            this.leb_service.ForeColor = System.Drawing.Color.Red;
            this.leb_service.Location = new System.Drawing.Point(469, 569);
            this.leb_service.Name = "leb_service";
            this.leb_service.Size = new System.Drawing.Size(293, 12);
            this.leb_service.TabIndex = 35;
            this.leb_service.Text = "服务未启动，不能自动同步到服务器，请点击重新开启";
            this.leb_service.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("宋体", 9F);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(971, 569);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 37;
            this.label10.Text = "本机IP:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labIp
            // 
            this.labIp.AutoSize = true;
            this.labIp.BackColor = System.Drawing.Color.Transparent;
            this.labIp.BorderColor = System.Drawing.Color.White;
            this.labIp.Font = new System.Drawing.Font("宋体", 9F);
            this.labIp.Location = new System.Drawing.Point(1036, 569);
            this.labIp.Name = "labIp";
            this.labIp.Size = new System.Drawing.Size(23, 12);
            this.labIp.TabIndex = 38;
            this.labIp.Text = "130";
            this.labIp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab_web
            // 
            this.lab_web.AutoSize = true;
            this.lab_web.ForeColor = System.Drawing.Color.Red;
            this.lab_web.Location = new System.Drawing.Point(18, 7);
            this.lab_web.Name = "lab_web";
            this.lab_web.Size = new System.Drawing.Size(185, 12);
            this.lab_web.TabIndex = 39;
            this.lab_web.Text = "无网络状态，不能同步到服务器！";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KtpAcs.WinForm.Properties.Resources.shuaxin;
            this.pictureBox1.Location = new System.Drawing.Point(975, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 42);
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            // pictureBox2
            // 
            this.pictureBox2.Image = global::KtpAcs.WinForm.Properties.Resources.off;
            this.pictureBox2.Location = new System.Drawing.Point(1062, 499);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(119, 42);
            this.pictureBox2.TabIndex = 41;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            // 
            // button_addDevice
            // 
            this.button_addDevice.Image = global::KtpAcs.WinForm.Properties.Resources.mianban;
            this.button_addDevice.Location = new System.Drawing.Point(1062, 384);
            this.button_addDevice.Name = "button_addDevice";
            this.button_addDevice.Size = new System.Drawing.Size(119, 41);
            this.button_addDevice.TabIndex = 42;
            this.button_addDevice.TabStop = false;
            this.button_addDevice.Click += new System.EventHandler(this.pictureBox3_Click);
            this.button_addDevice.MouseEnter += new System.EventHandler(this.pictureBox3_MouseEnter);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::KtpAcs.WinForm.Properties.Resources.gongren;
            this.pictureBox3.Location = new System.Drawing.Point(1062, 271);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(119, 41);
            this.pictureBox3.TabIndex = 43;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click_1);
            this.pictureBox3.MouseEnter += new System.EventHandler(this.pictureBox3_MouseEnter_1);
            // 
            // pic_ts
            // 
            this.pic_ts.Image = global::KtpAcs.WinForm.Properties.Resources.wl;
            this.pic_ts.Location = new System.Drawing.Point(1, 7);
            this.pic_ts.Name = "pic_ts";
            this.pic_ts.Size = new System.Drawing.Size(15, 15);
            this.pic_ts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_ts.TabIndex = 44;
            this.pic_ts.TabStop = false;
            // 
            // pl_wl
            // 
            this.pl_wl.Controls.Add(this.lab_web);
            this.pl_wl.Controls.Add(this.pic_ts);
            this.pl_wl.Location = new System.Drawing.Point(75, 562);
            this.pl_wl.Name = "pl_wl";
            this.pl_wl.Size = new System.Drawing.Size(226, 26);
            this.pl_wl.TabIndex = 45;
            this.pl_wl.Visible = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 599);
            this.Controls.Add(this.pl_wl);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.button_addDevice);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labIp);
            this.Controls.Add(this.btn_service);
            this.Controls.Add(this.leb_service);
            this.Controls.Add(this.skinPanel1);
            this.Controls.Add(this.btn_Auth);
            this.Controls.Add(this.btnSyn);
            this.Controls.Add(this.button_viewDeviceUserInfo);
            this.Controls.Add(this.dataGridDivce);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.Text = "建信开太平二代闸机【项目名称】";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDivce)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menu_application.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_addDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ts)).EndInit();
            this.pl_wl.ResumeLayout(false);
            this.pl_wl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridDivce;
        private System.Windows.Forms.Button btn_Auth;
        private CCWin.SkinControl.SkinButton btnSyn;
        private System.Windows.Forms.Button button_viewDeviceUserInfo;
        private CCWin.SkinControl.SkinPanel skinPanel1;
        private System.Windows.Forms.Label lab_sumCount;
        private System.Windows.Forms.Label label_proId;
        private System.Windows.Forms.Label lab_projoectName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Label2;
        private CCWin.SkinControl.SkinButton btn_service;
        private System.Windows.Forms.Label leb_service;
        private System.Windows.Forms.Label label10;
        private CCWin.SkinControl.SkinLabel labIp;
        private System.Windows.Forms.Label lab_web;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem con_updateDevice;
        private System.Windows.Forms.Label label_proCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lalUnCertTotalProCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem con_current_notice;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip menu_application;
        private System.Windows.Forms.ToolStripMenuItem menu_application_IsManualAddInfo;
        private System.Windows.Forms.ToolStripMenuItem menu_application_journal;
        private System.Windows.Forms.ToolStripMenuItem menu_application_Exit;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox button_addDevice;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn direction;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn aaa;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultMag;
        private System.Windows.Forms.DataGridViewButtonColumn btnOper;
        private System.Windows.Forms.PictureBox pic_ts;
        private System.Windows.Forms.Panel pl_wl;
    }
}