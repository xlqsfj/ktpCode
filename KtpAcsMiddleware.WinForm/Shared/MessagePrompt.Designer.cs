namespace KtpAcsMiddleware.WinForm.Shared
{
    partial class MessagePrompt
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
            this.MsgLabel = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MsgLabel
            // 
            this.MsgLabel.Location = new System.Drawing.Point(7, 42);
            this.MsgLabel.Name = "MsgLabel";
            this.MsgLabel.Size = new System.Drawing.Size(232, 12);
            this.MsgLabel.TabIndex = 1;
            this.MsgLabel.Text = "操作成功";
            this.MsgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MsgLabel.Click += new System.EventHandler(this.MsgLabel_Click);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(82, 61);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "确定";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // MessagePrompt
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 90);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.MsgLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessagePrompt";
            this.Text = "提示";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label MsgLabel;
        private System.Windows.Forms.Button OkButton;
    }
}