namespace KtpAcs.WinForm.Shared
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
            this.OkButton = new CCWin.SkinControl.SkinButton();
            this.MsgLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.BackColor = System.Drawing.Color.Transparent;
            this.OkButton.BaseColor = System.Drawing.SystemColors.ButtonShadow;
            this.OkButton.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.OkButton.DownBack = null;
            this.OkButton.Location = new System.Drawing.Point(148, 120);
            this.OkButton.MouseBack = null;
            this.OkButton.Name = "OkButton";
            this.OkButton.NormlBack = null;
            this.OkButton.Size = new System.Drawing.Size(102, 31);
            this.OkButton.TabIndex = 5;
            this.OkButton.Text = "确 定";
            this.OkButton.UseVisualStyleBackColor = false;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // MsgLabel
            // 
            this.MsgLabel.AutoEllipsis = true;
            this.MsgLabel.AutoSize = true;
            this.MsgLabel.Location = new System.Drawing.Point(101, 56);
            this.MsgLabel.Name = "MsgLabel";
            this.MsgLabel.Size = new System.Drawing.Size(53, 12);
            this.MsgLabel.TabIndex = 4;
            this.MsgLabel.Text = "操作成功";
            this.MsgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MessagePrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 165);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.MsgLabel);
            this.Name = "MessagePrompt";
            this.Text = "提示：";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinButton OkButton;
        private System.Windows.Forms.Label MsgLabel;
    }
}