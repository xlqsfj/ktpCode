namespace KtpAcsMiddleware.WinForm.Api.TeamWorkers
{
    partial class WorkerPhoneForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkerPhoneForm));
            this.btn_close = new CCWin.SkinControl.SkinButton();
            this.btn_send = new CCWin.SkinControl.SkinButton();
            this.text_send = new CCWin.SkinControl.SkinTextBox();
            this.btn_submitPhone = new CCWin.SkinControl.SkinButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.BaseColor = System.Drawing.SystemColors.ButtonShadow;
            this.btn_close.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_close.DownBack = null;
            this.btn_close.Location = new System.Drawing.Point(378, 142);
            this.btn_close.MouseBack = null;
            this.btn_close.Name = "btn_close";
            this.btn_close.NormlBack = null;
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 0;
            this.btn_close.Text = "关闭";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_send
            // 
            this.btn_send.BackColor = System.Drawing.Color.Transparent;
            this.btn_send.BaseColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_send.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_send.DownBack = null;
            this.btn_send.Location = new System.Drawing.Point(273, 92);
            this.btn_send.MouseBack = null;
            this.btn_send.Name = "btn_send";
            this.btn_send.NormlBack = null;
            this.btn_send.Size = new System.Drawing.Size(75, 28);
            this.btn_send.TabIndex = 1;
            this.btn_send.Text = "发送验证码";
            this.btn_send.UseVisualStyleBackColor = false;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // text_send
            // 
            this.text_send.BackColor = System.Drawing.Color.Transparent;
            this.text_send.DownBack = null;
            this.text_send.Icon = null;
            this.text_send.IconIsButton = false;
            this.text_send.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.text_send.IsPasswordChat = '\0';
            this.text_send.IsSystemPasswordChar = false;
            this.text_send.Lines = new string[] {
        "输入验证码"};
            this.text_send.Location = new System.Drawing.Point(68, 92);
            this.text_send.Margin = new System.Windows.Forms.Padding(0);
            this.text_send.MaxLength = 32767;
            this.text_send.MinimumSize = new System.Drawing.Size(28, 28);
            this.text_send.MouseBack = null;
            this.text_send.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.text_send.Multiline = false;
            this.text_send.Name = "text_send";
            this.text_send.NormlBack = null;
            this.text_send.Padding = new System.Windows.Forms.Padding(5);
            this.text_send.ReadOnly = false;
            this.text_send.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.text_send.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.text_send.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_send.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_send.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.text_send.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.text_send.SkinTxt.Name = "BaseText";
            this.text_send.SkinTxt.Size = new System.Drawing.Size(175, 18);
            this.text_send.SkinTxt.TabIndex = 0;
            this.text_send.SkinTxt.Text = "输入验证码";
            this.text_send.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.text_send.SkinTxt.WaterText = "";
            this.text_send.TabIndex = 2;
            this.text_send.Text = "输入验证码";
            this.text_send.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.text_send.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.text_send.WaterText = "";
            this.text_send.WordWrap = true;
            this.text_send.Click += new System.EventHandler(this.text_send_Click);
            this.text_send.Enter += new System.EventHandler(this.text_send_Enter);
            this.text_send.MouseClick += new System.Windows.Forms.MouseEventHandler(this.text_send_MouseClick);
            // 
            // btn_submitPhone
            // 
            this.btn_submitPhone.BackColor = System.Drawing.Color.Transparent;
            this.btn_submitPhone.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_submitPhone.DownBack = null;
            this.btn_submitPhone.Location = new System.Drawing.Point(110, 129);
            this.btn_submitPhone.MouseBack = null;
            this.btn_submitPhone.Name = "btn_submitPhone";
            this.btn_submitPhone.NormlBack = null;
            this.btn_submitPhone.Size = new System.Drawing.Size(94, 36);
            this.btn_submitPhone.TabIndex = 0;
            this.btn_submitPhone.Text = "提交";
            this.btn_submitPhone.UseVisualStyleBackColor = false;
            this.btn_submitPhone.Click += new System.EventHandler(this.btn_submitPhone_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "系统检测你输入的手机号需要验证请点击发送验证码 \r\n\r\n                    在点击提交";
            // 
            // WorkerPhoneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 177);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_send);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.btn_submitPhone);
            this.Controls.Add(this.btn_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WorkerPhoneForm";
            this.Text = "手机号验证";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.WorkerPhoneForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinButton btn_close;
        private CCWin.SkinControl.SkinButton btn_send;
        private CCWin.SkinControl.SkinTextBox text_send;
        private CCWin.SkinControl.SkinButton btn_submitPhone;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
}