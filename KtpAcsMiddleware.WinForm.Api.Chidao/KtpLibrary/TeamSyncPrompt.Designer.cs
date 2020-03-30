namespace KtpAcsMiddleware.WinForm.Api.KtpLibrary
{
    partial class TeamSyncPrompt
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
            this.OkButton = new System.Windows.Forms.Button();
            this.MsgLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(80, 60);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 3;
            this.OkButton.Text = "确定";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // MsgLabel
            // 
            this.MsgLabel.AutoSize = true;
            this.MsgLabel.Location = new System.Drawing.Point(12, 37);
            this.MsgLabel.Name = "MsgLabel";
            this.MsgLabel.Size = new System.Drawing.Size(83, 12);
            this.MsgLabel.TabIndex = 2;
            this.MsgLabel.Text = "正在同步.....";
            // 
            // TeamSyncPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 87);
            this.ControlBox = false;
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.MsgLabel);
            this.Name = "TeamSyncPrompt";
            this.Text = "班组同步提示";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TeamSyncPrompt_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label MsgLabel;
    }
}