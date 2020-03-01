namespace KtpAcs.WinForm.TeamWorkers
{
    partial class addTeam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addTeam));
            this.label2 = new System.Windows.Forms.Label();
            this.WorkTypeIdsCb = new System.Windows.Forms.ComboBox();
            this.TeamIdLabel = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.FormErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 165;
            this.label2.Text = "工种";
            // 
            // WorkTypeIdsCb
            // 
            this.WorkTypeIdsCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WorkTypeIdsCb.FormattingEnabled = true;
            this.WorkTypeIdsCb.Location = new System.Drawing.Point(121, 73);
            this.WorkTypeIdsCb.Name = "WorkTypeIdsCb";
            this.WorkTypeIdsCb.Size = new System.Drawing.Size(193, 20);
            this.WorkTypeIdsCb.TabIndex = 164;
            // 
            // TeamIdLabel
            // 
            this.TeamIdLabel.AutoSize = true;
            this.TeamIdLabel.Location = new System.Drawing.Point(104, 109);
            this.TeamIdLabel.Name = "TeamIdLabel";
            this.TeamIdLabel.Size = new System.Drawing.Size(0, 12);
            this.TeamIdLabel.TabIndex = 163;
            this.TeamIdLabel.Visible = false;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(121, 152);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 29);
            this.SaveBtn.TabIndex = 162;
            this.SaveBtn.Text = "保存";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // NameTxt
            // 
            this.NameTxt.Location = new System.Drawing.Point(121, 112);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(193, 21);
            this.NameTxt.TabIndex = 161;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 160;
            this.label1.Text = "名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(99, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 20);
            this.label3.TabIndex = 168;
            this.label3.Text = "*";
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(239, 152);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 29);
            this.CancelBtn.TabIndex = 167;
            this.CancelBtn.Text = "取消";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(99, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 20);
            this.label8.TabIndex = 166;
            this.label8.Text = "*";
            // 
            // FormErrorProvider
            // 
            this.FormErrorProvider.ContainerControl = this;
            // 
            // addTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 192);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WorkTypeIdsCb);
            this.Controls.Add(this.TeamIdLabel);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.NameTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.label8);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "addTeam";
            this.Text = "添加班组";
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox WorkTypeIdsCb;
        private System.Windows.Forms.Label TeamIdLabel;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.TextBox NameTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider FormErrorProvider;
    }
}