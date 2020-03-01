namespace KtpAcsMiddleware.WinForm.TeamWorkers
{
    partial class WorkerChangeTeamDetailed
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
            this.label2 = new System.Windows.Forms.Label();
            this.TeamsCb = new System.Windows.Forms.ComboBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.FormErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.CancelBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 165;
            this.label2.Text = "工种";
            // 
            // TeamsCb
            // 
            this.TeamsCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TeamsCb.FormattingEnabled = true;
            this.TeamsCb.Location = new System.Drawing.Point(55, 39);
            this.TeamsCb.Name = "TeamsCb";
            this.TeamsCb.Size = new System.Drawing.Size(193, 20);
            this.TeamsCb.TabIndex = 164;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(55, 70);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 162;
            this.SaveBtn.Text = "保存";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // FormErrorProvider
            // 
            this.FormErrorProvider.ContainerControl = this;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(173, 70);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 167;
            this.CancelBtn.Text = "取消";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(33, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 20);
            this.label8.TabIndex = 166;
            this.label8.Text = "*";
            // 
            // WorkerChangeTeamDetailed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 100);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TeamsCb);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.label8);
            this.Name = "WorkerChangeTeamDetailed";
            this.Text = "更换班组";
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox TeamsCb;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.ErrorProvider FormErrorProvider;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label label8;
    }
}