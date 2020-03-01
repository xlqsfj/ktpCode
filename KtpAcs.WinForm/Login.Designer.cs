namespace KtpAcs.WinForm
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.ExitButton = new System.Windows.Forms.Button();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UserNameTxt = new System.Windows.Forms.TextBox();
            this.FormErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pl_ts = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pic_ts = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).BeginInit();
            this.pl_ts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ts)).BeginInit();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(208, 148);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 36);
            this.ExitButton.TabIndex = 26;
            this.ExitButton.Text = "退出";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(289, 148);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(75, 36);
            this.LoginBtn.TabIndex = 23;
            this.LoginBtn.Text = "登录";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "密码";
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Location = new System.Drawing.Point(183, 106);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.Size = new System.Drawing.Size(254, 21);
            this.PasswordTxt.TabIndex = 22;
            this.PasswordTxt.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "用户名";
            // 
            // UserNameTxt
            // 
            this.UserNameTxt.Location = new System.Drawing.Point(183, 68);
            this.UserNameTxt.Name = "UserNameTxt";
            this.UserNameTxt.Size = new System.Drawing.Size(254, 21);
            this.UserNameTxt.TabIndex = 21;
            // 
            // FormErrorProvider
            // 
            this.FormErrorProvider.ContainerControl = this;
            // 
            // pl_ts
            // 
            this.pl_ts.Controls.Add(this.label3);
            this.pl_ts.Controls.Add(this.pic_ts);
            this.pl_ts.Location = new System.Drawing.Point(499, 176);
            this.pl_ts.Name = "pl_ts";
            this.pl_ts.Size = new System.Drawing.Size(105, 28);
            this.pl_ts.TabIndex = 27;
            this.pl_ts.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(33, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "无网络状态";
            // 
            // pic_ts
            // 
            this.pic_ts.Image = global::KtpAcs.WinForm.Properties.Resources.wl;
            this.pic_ts.Location = new System.Drawing.Point(12, 7);
            this.pic_ts.Name = "pic_ts";
            this.pic_ts.Size = new System.Drawing.Size(15, 15);
            this.pic_ts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_ts.TabIndex = 21;
            this.pic_ts.TabStop = false;
            // 
            // Login
            // 
            this.AcceptButton = this.LoginBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 208);
            this.Controls.Add(this.pl_ts);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PasswordTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserNameTxt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Text = "用户登录";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).EndInit();
            this.pl_ts.ResumeLayout(false);
            this.pl_ts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PasswordTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserNameTxt;
        private System.Windows.Forms.ErrorProvider FormErrorProvider;
        private System.Windows.Forms.Panel pl_ts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pic_ts;
    }
}