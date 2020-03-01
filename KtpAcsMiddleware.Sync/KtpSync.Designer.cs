namespace KtpAcsMiddleware.Sync
{
    partial class KtpSync
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
            this.StopButton = new System.Windows.Forms.Button();
            this.StartServiceButton = new System.Windows.Forms.Button();
            this.SingleTimeSyncButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.CoverPushButton = new System.Windows.Forms.Button();
            this.RePushExceptionsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(418, 10);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 8;
            this.StopButton.Text = "停止";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // StartServiceButton
            // 
            this.StartServiceButton.Location = new System.Drawing.Point(95, 10);
            this.StartServiceButton.Name = "StartServiceButton";
            this.StartServiceButton.Size = new System.Drawing.Size(75, 23);
            this.StartServiceButton.TabIndex = 7;
            this.StartServiceButton.Text = "同步";
            this.StartServiceButton.UseVisualStyleBackColor = true;
            this.StartServiceButton.Click += new System.EventHandler(this.StartServiceButton_Click);
            // 
            // SingleTimeSyncButton
            // 
            this.SingleTimeSyncButton.Location = new System.Drawing.Point(176, 10);
            this.SingleTimeSyncButton.Name = "SingleTimeSyncButton";
            this.SingleTimeSyncButton.Size = new System.Drawing.Size(75, 23);
            this.SingleTimeSyncButton.TabIndex = 9;
            this.SingleTimeSyncButton.Text = "单次同步";
            this.SingleTimeSyncButton.UseVisualStyleBackColor = true;
            this.SingleTimeSyncButton.Click += new System.EventHandler(this.SingleTimeSyncButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(12, 10);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 10;
            this.ExitButton.Text = "关闭";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // CoverPushButton
            // 
            this.CoverPushButton.Location = new System.Drawing.Point(257, 10);
            this.CoverPushButton.Name = "CoverPushButton";
            this.CoverPushButton.Size = new System.Drawing.Size(75, 23);
            this.CoverPushButton.TabIndex = 11;
            this.CoverPushButton.Text = "覆盖推送";
            this.CoverPushButton.UseVisualStyleBackColor = true;
            this.CoverPushButton.Click += new System.EventHandler(this.CoverPushButton_Click);
            // 
            // RePushExceptionsButton
            // 
            this.RePushExceptionsButton.Location = new System.Drawing.Point(337, 10);
            this.RePushExceptionsButton.Name = "RePushExceptionsButton";
            this.RePushExceptionsButton.Size = new System.Drawing.Size(75, 23);
            this.RePushExceptionsButton.TabIndex = 12;
            this.RePushExceptionsButton.Text = "重推异常";
            this.RePushExceptionsButton.UseVisualStyleBackColor = true;
            this.RePushExceptionsButton.Click += new System.EventHandler(this.RePushExceptionsButton_Click);
            // 
            // KtpSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 43);
            this.Controls.Add(this.RePushExceptionsButton);
            this.Controls.Add(this.CoverPushButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.SingleTimeSyncButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartServiceButton);
            this.Name = "KtpSync";
            this.Text = "KtpAcsMiddleware数据同步";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KtpSync_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button StartServiceButton;
        private System.Windows.Forms.Button SingleTimeSyncButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button CoverPushButton;
        private System.Windows.Forms.Button RePushExceptionsButton;
    }
}