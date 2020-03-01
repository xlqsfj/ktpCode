namespace KtpAcs.WinForm.Device
{
    partial class DeviceInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.IsCheckInNoRb = new System.Windows.Forms.RadioButton();
            this.IsCheckInYesRb = new System.Windows.Forms.RadioButton();
            this.DescriptionTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CodeTxt = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.IpAddressTxt = new System.Windows.Forms.TextBox();
            this.FormErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(125, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 20);
            this.label1.TabIndex = 184;
            this.label1.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 183;
            this.label6.Text = "是进场方向";
            // 
            // IsCheckInNoRb
            // 
            this.IsCheckInNoRb.AutoSize = true;
            this.IsCheckInNoRb.Location = new System.Drawing.Point(193, 204);
            this.IsCheckInNoRb.Name = "IsCheckInNoRb";
            this.IsCheckInNoRb.Size = new System.Drawing.Size(35, 16);
            this.IsCheckInNoRb.TabIndex = 175;
            this.IsCheckInNoRb.TabStop = true;
            this.IsCheckInNoRb.Text = "否";
            this.IsCheckInNoRb.UseVisualStyleBackColor = true;
            // 
            // IsCheckInYesRb
            // 
            this.IsCheckInYesRb.AutoSize = true;
            this.IsCheckInYesRb.Location = new System.Drawing.Point(152, 204);
            this.IsCheckInYesRb.Name = "IsCheckInYesRb";
            this.IsCheckInYesRb.Size = new System.Drawing.Size(35, 16);
            this.IsCheckInYesRb.TabIndex = 174;
            this.IsCheckInYesRb.TabStop = true;
            this.IsCheckInYesRb.Text = "是";
            this.IsCheckInYesRb.UseVisualStyleBackColor = true;
            // 
            // DescriptionTxt
            // 
            this.DescriptionTxt.Location = new System.Drawing.Point(152, 130);
            this.DescriptionTxt.Multiline = true;
            this.DescriptionTxt.Name = "DescriptionTxt";
            this.DescriptionTxt.Size = new System.Drawing.Size(270, 68);
            this.DescriptionTxt.TabIndex = 173;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 182;
            this.label4.Text = "描述";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(125, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 20);
            this.label5.TabIndex = 181;
            this.label5.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(125, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 20);
            this.label8.TabIndex = 180;
            this.label8.Text = "*";
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(250, 230);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 177;
            this.CancelBtn.Text = "取消";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 179;
            this.label3.Text = "编号(设备号)";
            // 
            // CodeTxt
            // 
            this.CodeTxt.Location = new System.Drawing.Point(152, 50);
            this.CodeTxt.Name = "CodeTxt";
            this.CodeTxt.Size = new System.Drawing.Size(270, 21);
            this.CodeTxt.TabIndex = 171;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(156, 230);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 176;
            this.SaveBtn.Text = "保存";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 178;
            this.label2.Text = "IP地址";
            // 
            // IpAddressTxt
            // 
            this.IpAddressTxt.Location = new System.Drawing.Point(152, 88);
            this.IpAddressTxt.Name = "IpAddressTxt";
            this.IpAddressTxt.Size = new System.Drawing.Size(270, 21);
            this.IpAddressTxt.TabIndex = 172;
            // 
            // FormErrorProvider
            // 
            this.FormErrorProvider.ContainerControl = this;
            // 
            // DeviceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 265);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.IsCheckInNoRb);
            this.Controls.Add(this.IsCheckInYesRb);
            this.Controls.Add(this.DescriptionTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CodeTxt);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IpAddressTxt);
            this.Name = "DeviceInfo";
            this.Text = "添加设备";
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton IsCheckInNoRb;
        private System.Windows.Forms.RadioButton IsCheckInYesRb;
        private System.Windows.Forms.TextBox DescriptionTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CodeTxt;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IpAddressTxt;
        private System.Windows.Forms.ErrorProvider FormErrorProvider;
    }
}