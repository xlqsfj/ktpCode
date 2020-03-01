namespace KtpAcs.WinForm.Shared
{
    partial class SynDeviceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SynDeviceForm));
            this.lbl_tips = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MsgLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_tips
            // 
            this.lbl_tips.AutoSize = true;
            this.lbl_tips.Location = new System.Drawing.Point(199, 79);
            this.lbl_tips.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_tips.Name = "lbl_tips";
            this.lbl_tips.Size = new System.Drawing.Size(107, 12);
            this.lbl_tips.TabIndex = 17;
            this.lbl_tips.Text = "同步中，请稍等...";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(96, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 69);
            this.label1.TabIndex = 16;
            // 
            // MsgLabel
            // 
            this.MsgLabel.AutoSize = true;
            this.MsgLabel.Location = new System.Drawing.Point(164, 139);
            this.MsgLabel.Name = "MsgLabel";
            this.MsgLabel.Size = new System.Drawing.Size(41, 12);
            this.MsgLabel.TabIndex = 18;
            this.MsgLabel.Text = "label2";
            this.MsgLabel.Visible = false;
            // 
            // SynDeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 175);
            this.Controls.Add(this.MsgLabel);
            this.Controls.Add(this.lbl_tips);
            this.Controls.Add(this.label1);
            this.Name = "SynDeviceForm";
            this.Text = "通知设备提示";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_tips;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label MsgLabel;
    }
}