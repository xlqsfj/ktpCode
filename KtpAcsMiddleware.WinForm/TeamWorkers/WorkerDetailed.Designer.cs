namespace KtpAcsMiddleware.WinForm.TeamWorkers
{
    partial class WorkerDetailed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkerDetailed));
            this.TeamCb = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.IdentityCardReaderBtn = new System.Windows.Forms.Button();
            this.lalBankCardBack = new System.Windows.Forms.Label();
            this.lalBankCardFront = new System.Windows.Forms.Label();
            this.lalFace = new System.Windows.Forms.Label();
            this.IdentityBackPic = new AForge.Controls.PictureBox();
            this.IdentityPic = new AForge.Controls.PictureBox();
            this.FacePic = new AForge.Controls.PictureBox();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lal1 = new System.Windows.Forms.Label();
            this.AddressTxt = new System.Windows.Forms.TextBox();
            this.lalNative = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BirthdayDtp = new System.Windows.Forms.DateTimePicker();
            this.InvalidTimeDtp = new System.Windows.Forms.DateTimePicker();
            this.ActivateTimeDtp = new System.Windows.Forms.DateTimePicker();
            this.lalValidity = new System.Windows.Forms.Label();
            this.IdentityCodeTxt = new System.Windows.Forms.TextBox();
            this.lalIdCard = new System.Windows.Forms.Label();
            this.MobileTxt = new System.Windows.Forms.TextBox();
            this.AddressNowTxt = new System.Windows.Forms.TextBox();
            this.IssuingAuthorityTxt = new System.Windows.Forms.TextBox();
            this.WorkerNameTxt = new System.Windows.Forms.TextBox();
            this.NationCb = new System.Windows.Forms.ComboBox();
            this.LadyRadio = new System.Windows.Forms.RadioButton();
            this.ManRadio = new System.Windows.Forms.RadioButton();
            this.AVidePlayer = new AForge.Controls.VideoSourcePlayer();
            this.lalPhoneNum = new System.Windows.Forms.Label();
            this.lalNation = new System.Windows.Forms.Label();
            this.lalAddr = new System.Windows.Forms.Label();
            this.lalLia = new System.Windows.Forms.Label();
            this.lalSex = new System.Windows.Forms.Label();
            this.lalBrithday = new System.Windows.Forms.Label();
            this.lalName = new System.Windows.Forms.Label();
            this.lalTeam = new System.Windows.Forms.Label();
            this.IdentityHeadPic = new AForge.Controls.PictureBox();
            this.FormErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.BankCardTypeCb = new System.Windows.Forms.ComboBox();
            this.BankCardCodeTxt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.FacePicShow = new AForge.Controls.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.IdentityBackPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IdentityPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IdentityHeadPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacePicShow)).BeginInit();
            this.SuspendLayout();
            // 
            // TeamCb
            // 
            this.TeamCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TeamCb.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.TeamCb.FormattingEnabled = true;
            this.TeamCb.Location = new System.Drawing.Point(814, 263);
            this.TeamCb.Name = "TeamCb";
            this.TeamCb.Size = new System.Drawing.Size(262, 28);
            this.TeamCb.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(794, 267);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 20);
            this.label11.TabIndex = 99;
            this.label11.Text = "*";
            // 
            // IdentityCardReaderBtn
            // 
            this.IdentityCardReaderBtn.Location = new System.Drawing.Point(890, 459);
            this.IdentityCardReaderBtn.Name = "IdentityCardReaderBtn";
            this.IdentityCardReaderBtn.Size = new System.Drawing.Size(186, 50);
            this.IdentityCardReaderBtn.TabIndex = 20;
            this.IdentityCardReaderBtn.Text = "读取身份证";
            this.IdentityCardReaderBtn.UseVisualStyleBackColor = true;
            this.IdentityCardReaderBtn.Click += new System.EventHandler(this.IdentityCardReaderBtn_Click);
            // 
            // lalBankCardBack
            // 
            this.lalBankCardBack.AutoSize = true;
            this.lalBankCardBack.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lalBankCardBack.Location = new System.Drawing.Point(688, 612);
            this.lalBankCardBack.Name = "lalBankCardBack";
            this.lalBankCardBack.Size = new System.Drawing.Size(84, 20);
            this.lalBankCardBack.TabIndex = 97;
            this.lalBankCardBack.Text = "身份证背面";
            // 
            // lalBankCardFront
            // 
            this.lalBankCardFront.AutoSize = true;
            this.lalBankCardFront.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lalBankCardFront.Location = new System.Drawing.Point(392, 613);
            this.lalBankCardFront.Name = "lalBankCardFront";
            this.lalBankCardFront.Size = new System.Drawing.Size(84, 20);
            this.lalBankCardFront.TabIndex = 96;
            this.lalBankCardFront.Text = "身份证正面";
            // 
            // lalFace
            // 
            this.lalFace.AutoSize = true;
            this.lalFace.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lalFace.Location = new System.Drawing.Point(89, 613);
            this.lalFace.Name = "lalFace";
            this.lalFace.Size = new System.Drawing.Size(99, 20);
            this.lalFace.TabIndex = 95;
            this.lalFace.Text = "人脸采集图像";
            // 
            // IdentityBackPic
            // 
            this.IdentityBackPic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("IdentityBackPic.BackgroundImage")));
            this.IdentityBackPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IdentityBackPic.Image = null;
            this.IdentityBackPic.Location = new System.Drawing.Point(605, 361);
            this.IdentityBackPic.Name = "IdentityBackPic";
            this.IdentityBackPic.Size = new System.Drawing.Size(250, 250);
            this.IdentityBackPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IdentityBackPic.TabIndex = 94;
            this.IdentityBackPic.TabStop = false;
            this.IdentityBackPic.Click += new System.EventHandler(this.IdentityBackPic_Click);
            // 
            // IdentityPic
            // 
            this.IdentityPic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("IdentityPic.BackgroundImage")));
            this.IdentityPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IdentityPic.Image = null;
            this.IdentityPic.Location = new System.Drawing.Point(309, 361);
            this.IdentityPic.Name = "IdentityPic";
            this.IdentityPic.Size = new System.Drawing.Size(250, 250);
            this.IdentityPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IdentityPic.TabIndex = 93;
            this.IdentityPic.TabStop = false;
            this.IdentityPic.Click += new System.EventHandler(this.IdentityPic_Click);
            // 
            // FacePic
            // 
            this.FacePic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FacePic.BackgroundImage")));
            this.FacePic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.FacePic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FacePic.Image = null;
            this.FacePic.Location = new System.Drawing.Point(13, 361);
            this.FacePic.Name = "FacePic";
            this.FacePic.Size = new System.Drawing.Size(250, 250);
            this.FacePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FacePic.TabIndex = 92;
            this.FacePic.TabStop = false;
            this.FacePic.Click += new System.EventHandler(this.FacePic_Click);
            // 
            // ResetBtn
            // 
            this.ResetBtn.Location = new System.Drawing.Point(987, 515);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(87, 30);
            this.ResetBtn.TabIndex = 21;
            this.ResetBtn.Text = "重置";
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Location = new System.Drawing.Point(890, 561);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(186, 50);
            this.SubmitBtn.TabIndex = 22;
            this.SubmitBtn.Text = "提交";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(578, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 20);
            this.label8.TabIndex = 84;
            this.label8.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(795, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 20);
            this.label7.TabIndex = 82;
            this.label7.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(795, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 20);
            this.label6.TabIndex = 81;
            this.label6.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(795, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 20);
            this.label5.TabIndex = 80;
            this.label5.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(381, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 20);
            this.label4.TabIndex = 79;
            this.label4.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(381, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 20);
            this.label3.TabIndex = 78;
            this.label3.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(381, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 20);
            this.label2.TabIndex = 83;
            this.label2.Text = "*";
            // 
            // lal1
            // 
            this.lal1.AutoSize = true;
            this.lal1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lal1.ForeColor = System.Drawing.Color.Red;
            this.lal1.Location = new System.Drawing.Point(381, 39);
            this.lal1.Name = "lal1";
            this.lal1.Size = new System.Drawing.Size(16, 20);
            this.lal1.TabIndex = 77;
            this.lal1.Text = "*";
            // 
            // AddressTxt
            // 
            this.AddressTxt.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.AddressTxt.Location = new System.Drawing.Point(814, 167);
            this.AddressTxt.Multiline = true;
            this.AddressTxt.Name = "AddressTxt";
            this.AddressTxt.Size = new System.Drawing.Size(262, 76);
            this.AddressTxt.TabIndex = 11;
            // 
            // lalNative
            // 
            this.lalNative.AutoSize = true;
            this.lalNative.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lalNative.Location = new System.Drawing.Point(761, 169);
            this.lalNative.Name = "lalNative";
            this.lalNative.Size = new System.Drawing.Size(39, 20);
            this.lalNative.TabIndex = 76;
            this.lalNative.Text = "籍贯";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(933, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 20);
            this.label1.TabIndex = 75;
            this.label1.Text = "至";
            // 
            // BirthdayDtp
            // 
            this.BirthdayDtp.CalendarFont = new System.Drawing.Font("微软雅黑", 11F);
            this.BirthdayDtp.Location = new System.Drawing.Point(814, 40);
            this.BirthdayDtp.Name = "BirthdayDtp";
            this.BirthdayDtp.Size = new System.Drawing.Size(260, 21);
            this.BirthdayDtp.TabIndex = 4;
            // 
            // InvalidTimeDtp
            // 
            this.InvalidTimeDtp.CalendarFont = new System.Drawing.Font("微软雅黑", 11F);
            this.InvalidTimeDtp.Location = new System.Drawing.Point(963, 123);
            this.InvalidTimeDtp.Name = "InvalidTimeDtp";
            this.InvalidTimeDtp.Size = new System.Drawing.Size(113, 21);
            this.InvalidTimeDtp.TabIndex = 9;
            // 
            // ActivateTimeDtp
            // 
            this.ActivateTimeDtp.CalendarFont = new System.Drawing.Font("微软雅黑", 11F);
            this.ActivateTimeDtp.Location = new System.Drawing.Point(814, 124);
            this.ActivateTimeDtp.Name = "ActivateTimeDtp";
            this.ActivateTimeDtp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ActivateTimeDtp.Size = new System.Drawing.Size(113, 21);
            this.ActivateTimeDtp.TabIndex = 8;
            // 
            // lalValidity
            // 
            this.lalValidity.AutoSize = true;
            this.lalValidity.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lalValidity.Location = new System.Drawing.Point(746, 124);
            this.lalValidity.Name = "lalValidity";
            this.lalValidity.Size = new System.Drawing.Size(54, 20);
            this.lalValidity.TabIndex = 74;
            this.lalValidity.Text = "有效期";
            // 
            // IdentityCodeTxt
            // 
            this.IdentityCodeTxt.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.IdentityCodeTxt.Location = new System.Drawing.Point(397, 79);
            this.IdentityCodeTxt.Name = "IdentityCodeTxt";
            this.IdentityCodeTxt.Size = new System.Drawing.Size(333, 27);
            this.IdentityCodeTxt.TabIndex = 5;
            // 
            // lalIdCard
            // 
            this.lalIdCard.AutoSize = true;
            this.lalIdCard.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lalIdCard.Location = new System.Drawing.Point(332, 82);
            this.lalIdCard.Name = "lalIdCard";
            this.lalIdCard.Size = new System.Drawing.Size(54, 20);
            this.lalIdCard.TabIndex = 73;
            this.lalIdCard.Text = "身份证";
            // 
            // MobileTxt
            // 
            this.MobileTxt.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.MobileTxt.Location = new System.Drawing.Point(397, 264);
            this.MobileTxt.Name = "MobileTxt";
            this.MobileTxt.Size = new System.Drawing.Size(333, 27);
            this.MobileTxt.TabIndex = 12;
            // 
            // AddressNowTxt
            // 
            this.AddressNowTxt.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.AddressNowTxt.Location = new System.Drawing.Point(397, 167);
            this.AddressNowTxt.Multiline = true;
            this.AddressNowTxt.Name = "AddressNowTxt";
            this.AddressNowTxt.Size = new System.Drawing.Size(333, 76);
            this.AddressNowTxt.TabIndex = 10;
            // 
            // IssuingAuthorityTxt
            // 
            this.IssuingAuthorityTxt.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.IssuingAuthorityTxt.Location = new System.Drawing.Point(397, 121);
            this.IssuingAuthorityTxt.Name = "IssuingAuthorityTxt";
            this.IssuingAuthorityTxt.Size = new System.Drawing.Size(333, 27);
            this.IssuingAuthorityTxt.TabIndex = 7;
            // 
            // WorkerNameTxt
            // 
            this.WorkerNameTxt.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.WorkerNameTxt.Location = new System.Drawing.Point(397, 36);
            this.WorkerNameTxt.Name = "WorkerNameTxt";
            this.WorkerNameTxt.Size = new System.Drawing.Size(165, 27);
            this.WorkerNameTxt.TabIndex = 1;
            // 
            // NationCb
            // 
            this.NationCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NationCb.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.NationCb.FormattingEnabled = true;
            this.NationCb.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.NationCb.Location = new System.Drawing.Point(814, 79);
            this.NationCb.Name = "NationCb";
            this.NationCb.Size = new System.Drawing.Size(262, 28);
            this.NationCb.TabIndex = 6;
            // 
            // LadyRadio
            // 
            this.LadyRadio.AutoSize = true;
            this.LadyRadio.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.LadyRadio.Location = new System.Drawing.Point(688, 37);
            this.LadyRadio.Name = "LadyRadio";
            this.LadyRadio.Size = new System.Drawing.Size(42, 24);
            this.LadyRadio.TabIndex = 3;
            this.LadyRadio.TabStop = true;
            this.LadyRadio.Text = "女";
            this.LadyRadio.UseVisualStyleBackColor = true;
            // 
            // ManRadio
            // 
            this.ManRadio.AutoSize = true;
            this.ManRadio.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.ManRadio.Location = new System.Drawing.Point(637, 37);
            this.ManRadio.Name = "ManRadio";
            this.ManRadio.Size = new System.Drawing.Size(42, 24);
            this.ManRadio.TabIndex = 2;
            this.ManRadio.TabStop = true;
            this.ManRadio.Text = "男";
            this.ManRadio.UseVisualStyleBackColor = true;
            // 
            // AVidePlayer
            // 
            this.AVidePlayer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AVidePlayer.BackgroundImage")));
            this.AVidePlayer.Location = new System.Drawing.Point(12, 36);
            this.AVidePlayer.Name = "AVidePlayer";
            this.AVidePlayer.Size = new System.Drawing.Size(300, 300);
            this.AVidePlayer.TabIndex = 70;
            this.AVidePlayer.Text = "videoSourcePlayer1";
            this.AVidePlayer.VideoSource = null;
            // 
            // lalPhoneNum
            // 
            this.lalPhoneNum.AutoSize = true;
            this.lalPhoneNum.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lalPhoneNum.Location = new System.Drawing.Point(332, 267);
            this.lalPhoneNum.Name = "lalPhoneNum";
            this.lalPhoneNum.Size = new System.Drawing.Size(54, 20);
            this.lalPhoneNum.TabIndex = 67;
            this.lalPhoneNum.Text = "手机号";
            // 
            // lalNation
            // 
            this.lalNation.AutoSize = true;
            this.lalNation.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lalNation.Location = new System.Drawing.Point(761, 81);
            this.lalNation.Name = "lalNation";
            this.lalNation.Size = new System.Drawing.Size(39, 20);
            this.lalNation.TabIndex = 65;
            this.lalNation.Text = "民族";
            // 
            // lalAddr
            // 
            this.lalAddr.AutoSize = true;
            this.lalAddr.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lalAddr.Location = new System.Drawing.Point(347, 169);
            this.lalAddr.Name = "lalAddr";
            this.lalAddr.Size = new System.Drawing.Size(39, 20);
            this.lalAddr.TabIndex = 63;
            this.lalAddr.Text = "住址";
            // 
            // lalLia
            // 
            this.lalLia.AutoSize = true;
            this.lalLia.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lalLia.Location = new System.Drawing.Point(317, 124);
            this.lalLia.Name = "lalLia";
            this.lalLia.Size = new System.Drawing.Size(69, 20);
            this.lalLia.TabIndex = 62;
            this.lalLia.Text = "发证机关";
            // 
            // lalSex
            // 
            this.lalSex.AutoSize = true;
            this.lalSex.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lalSex.Location = new System.Drawing.Point(589, 39);
            this.lalSex.Name = "lalSex";
            this.lalSex.Size = new System.Drawing.Size(54, 20);
            this.lalSex.TabIndex = 59;
            this.lalSex.Text = "性别：";
            // 
            // lalBrithday
            // 
            this.lalBrithday.AutoSize = true;
            this.lalBrithday.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lalBrithday.Location = new System.Drawing.Point(761, 39);
            this.lalBrithday.Name = "lalBrithday";
            this.lalBrithday.Size = new System.Drawing.Size(39, 20);
            this.lalBrithday.TabIndex = 58;
            this.lalBrithday.Text = "生日";
            // 
            // lalName
            // 
            this.lalName.AutoSize = true;
            this.lalName.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lalName.Location = new System.Drawing.Point(347, 39);
            this.lalName.Name = "lalName";
            this.lalName.Size = new System.Drawing.Size(39, 20);
            this.lalName.TabIndex = 55;
            this.lalName.Text = "姓名";
            // 
            // lalTeam
            // 
            this.lalTeam.AutoSize = true;
            this.lalTeam.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lalTeam.Location = new System.Drawing.Point(755, 266);
            this.lalTeam.Name = "lalTeam";
            this.lalTeam.Size = new System.Drawing.Size(42, 21);
            this.lalTeam.TabIndex = 52;
            this.lalTeam.Text = "班组";
            this.lalTeam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IdentityHeadPic
            // 
            this.IdentityHeadPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IdentityHeadPic.Image = null;
            this.IdentityHeadPic.Location = new System.Drawing.Point(890, 361);
            this.IdentityHeadPic.Name = "IdentityHeadPic";
            this.IdentityHeadPic.Size = new System.Drawing.Size(184, 95);
            this.IdentityHeadPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IdentityHeadPic.TabIndex = 101;
            this.IdentityHeadPic.TabStop = false;
            // 
            // FormErrorProvider
            // 
            this.FormErrorProvider.ContainerControl = this;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(381, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 20);
            this.label12.TabIndex = 102;
            this.label12.Text = "*";
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(890, 515);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(93, 30);
            this.CloseButton.TabIndex = 103;
            this.CloseButton.Text = "关闭";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // BankCardTypeCb
            // 
            this.BankCardTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BankCardTypeCb.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.BankCardTypeCb.FormattingEnabled = true;
            this.BankCardTypeCb.Location = new System.Drawing.Point(812, 309);
            this.BankCardTypeCb.Name = "BankCardTypeCb";
            this.BankCardTypeCb.Size = new System.Drawing.Size(262, 28);
            this.BankCardTypeCb.TabIndex = 105;
            // 
            // BankCardCodeTxt
            // 
            this.BankCardCodeTxt.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.BankCardCodeTxt.Location = new System.Drawing.Point(397, 308);
            this.BankCardCodeTxt.Name = "BankCardCodeTxt";
            this.BankCardCodeTxt.Size = new System.Drawing.Size(333, 27);
            this.BankCardCodeTxt.TabIndex = 104;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label13.Location = new System.Drawing.Point(317, 312);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 20);
            this.label13.TabIndex = 107;
            this.label13.Text = "银行卡号";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label14.Location = new System.Drawing.Point(742, 310);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 21);
            this.label14.TabIndex = 106;
            this.label14.Text = "所属行";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FacePicShow
            // 
            this.FacePicShow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FacePicShow.BackgroundImage")));
            this.FacePicShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.FacePicShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FacePicShow.Image = null;
            this.FacePicShow.Location = new System.Drawing.Point(12, 36);
            this.FacePicShow.Name = "FacePicShow";
            this.FacePicShow.Size = new System.Drawing.Size(300, 300);
            this.FacePicShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FacePicShow.TabIndex = 109;
            this.FacePicShow.TabStop = false;
            this.FacePicShow.Visible = false;
            // 
            // WorkerDetailed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 641);
            this.Controls.Add(this.FacePicShow);
            this.Controls.Add(this.BankCardTypeCb);
            this.Controls.Add(this.BankCardCodeTxt);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.IdentityHeadPic);
            this.Controls.Add(this.TeamCb);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.IdentityCardReaderBtn);
            this.Controls.Add(this.lalBankCardBack);
            this.Controls.Add(this.lalBankCardFront);
            this.Controls.Add(this.lalFace);
            this.Controls.Add(this.IdentityBackPic);
            this.Controls.Add(this.IdentityPic);
            this.Controls.Add(this.FacePic);
            this.Controls.Add(this.ResetBtn);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lal1);
            this.Controls.Add(this.AddressTxt);
            this.Controls.Add(this.lalNative);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BirthdayDtp);
            this.Controls.Add(this.InvalidTimeDtp);
            this.Controls.Add(this.ActivateTimeDtp);
            this.Controls.Add(this.lalValidity);
            this.Controls.Add(this.IdentityCodeTxt);
            this.Controls.Add(this.lalIdCard);
            this.Controls.Add(this.MobileTxt);
            this.Controls.Add(this.AddressNowTxt);
            this.Controls.Add(this.IssuingAuthorityTxt);
            this.Controls.Add(this.WorkerNameTxt);
            this.Controls.Add(this.NationCb);
            this.Controls.Add(this.LadyRadio);
            this.Controls.Add(this.ManRadio);
            this.Controls.Add(this.AVidePlayer);
            this.Controls.Add(this.lalPhoneNum);
            this.Controls.Add(this.lalNation);
            this.Controls.Add(this.lalAddr);
            this.Controls.Add(this.lalLia);
            this.Controls.Add(this.lalSex);
            this.Controls.Add(this.lalBrithday);
            this.Controls.Add(this.lalName);
            this.Controls.Add(this.lalTeam);
            this.Name = "WorkerDetailed";
            this.Text = "班组工人信息";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkerDetailed_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.IdentityBackPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IdentityPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IdentityHeadPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacePicShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox TeamCb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button IdentityCardReaderBtn;
        private System.Windows.Forms.Label lalBankCardBack;
        private System.Windows.Forms.Label lalBankCardFront;
        private System.Windows.Forms.Label lalFace;
        private AForge.Controls.PictureBox IdentityBackPic;
        private AForge.Controls.PictureBox IdentityPic;
        private AForge.Controls.PictureBox FacePic;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lal1;
        private System.Windows.Forms.TextBox AddressTxt;
        private System.Windows.Forms.Label lalNative;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker BirthdayDtp;
        private System.Windows.Forms.DateTimePicker InvalidTimeDtp;
        private System.Windows.Forms.DateTimePicker ActivateTimeDtp;
        private System.Windows.Forms.Label lalValidity;
        private System.Windows.Forms.TextBox IdentityCodeTxt;
        private System.Windows.Forms.Label lalIdCard;
        private System.Windows.Forms.TextBox MobileTxt;
        private System.Windows.Forms.TextBox AddressNowTxt;
        private System.Windows.Forms.TextBox IssuingAuthorityTxt;
        private System.Windows.Forms.TextBox WorkerNameTxt;
        private System.Windows.Forms.ComboBox NationCb;
        private System.Windows.Forms.RadioButton LadyRadio;
        private System.Windows.Forms.RadioButton ManRadio;
        private AForge.Controls.VideoSourcePlayer AVidePlayer;
        private System.Windows.Forms.Label lalPhoneNum;
        private System.Windows.Forms.Label lalNation;
        private System.Windows.Forms.Label lalAddr;
        private System.Windows.Forms.Label lalLia;
        private System.Windows.Forms.Label lalSex;
        private System.Windows.Forms.Label lalBrithday;
        private System.Windows.Forms.Label lalName;
        private System.Windows.Forms.Label lalTeam;
        private AForge.Controls.PictureBox IdentityHeadPic;
        private System.Windows.Forms.ErrorProvider FormErrorProvider;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.ComboBox BankCardTypeCb;
        private System.Windows.Forms.TextBox BankCardCodeTxt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private AForge.Controls.PictureBox FacePicShow;
    }
}