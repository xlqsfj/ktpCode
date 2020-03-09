namespace KtpAcsMiddleware.WinForm.Api.Shared
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessagePrompt));
            this.MsgLabel = new System.Windows.Forms.Label();
            this.OkButton = new CCWin.SkinControl.SkinButton();
            this.SuspendLayout();
            // 
            // MsgLabel
            // 
            this.MsgLabel.AutoEllipsis = true;
            this.MsgLabel.AutoSize = true;
            this.MsgLabel.Location = new System.Drawing.Point(20, 43);
            this.MsgLabel.Name = "MsgLabel";
            this.MsgLabel.Size = new System.Drawing.Size(53, 12);
            this.MsgLabel.TabIndex = 1;
            this.MsgLabel.Text = "操作成功";
            this.MsgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MsgLabel.Click += new System.EventHandler(this.MsgLabel_Click);
            // 
            // OkButton
            // 
            this.OkButton.BackColor = System.Drawing.Color.Transparent;
            this.OkButton.BaseColor = System.Drawing.SystemColors.ButtonShadow;
            this.OkButton.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.OkButton.DownBack = null;
            this.OkButton.Location = new System.Drawing.Point(113, 110);
            this.OkButton.MouseBack = null;
            this.OkButton.Name = "OkButton";
            this.OkButton.NormlBack = null;
            this.OkButton.Size = new System.Drawing.Size(102, 31);
            this.OkButton.TabIndex = 3;
            this.OkButton.Text = "确 定";
            this.OkButton.UseVisualStyleBackColor = false;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // MessagePrompt
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(347, 148);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.MsgLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessagePrompt";
            this.Text = "提示";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MsgLabel;
        private CCWin.SkinControl.SkinButton OkButton;
    }
}