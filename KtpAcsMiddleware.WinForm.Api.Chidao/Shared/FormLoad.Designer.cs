namespace KtpAcsMiddleware.WinForm.Api.Shared
{
    partial class FormLoad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoad));
            this.lbl_tips = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_tips
            // 
            this.lbl_tips.AutoSize = true;
            this.lbl_tips.Location = new System.Drawing.Point(166, 78);
            this.lbl_tips.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_tips.Name = "lbl_tips";
            this.lbl_tips.Size = new System.Drawing.Size(107, 12);
            this.lbl_tips.TabIndex = 9;
            this.lbl_tips.Text = "加载中，请稍等...";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Image = global::KtpAcsMiddleware.WinForm.Api.Chidao.Properties.Resources.loading3;
            this.label1.Location = new System.Drawing.Point(75, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 69);
            this.label1.TabIndex = 8;
            // 
            // FormLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 153);
            this.Controls.Add(this.lbl_tips);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLoad";
            this.Text = "温馨提示";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLoad_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLoad_FormClosed);
            this.Load += new System.EventHandler(this.FormLoad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_tips;
        private System.Windows.Forms.Label label1;
    }
}