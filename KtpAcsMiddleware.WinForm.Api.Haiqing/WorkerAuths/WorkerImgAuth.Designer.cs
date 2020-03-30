namespace KtpAcsMiddleware.WinForm.Api.WorkerAuths
{
    partial class WorkerImgAuth
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lab_title = new System.Windows.Forms.Label();
            this.btn_close = new CCWin.SkinControl.SkinButton();
            this.pic_userimg = new System.Windows.Forms.PictureBox();
            this.skinButton2 = new CCWin.SkinControl.SkinButton();
            this.lab_name = new CCWin.SkinControl.SkinLabel();
            this.skinButton1 = new CCWin.SkinControl.SkinButton();
            ((System.ComponentModel.ISupportInitialize)(this.pic_userimg)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lab_title
            // 
            this.lab_title.AutoSize = true;
            this.lab_title.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_title.Location = new System.Drawing.Point(224, 58);
            this.lab_title.Name = "lab_title";
            this.lab_title.Size = new System.Drawing.Size(56, 16);
            this.lab_title.TabIndex = 1;
            this.lab_title.Text = "label1";
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_close.DownBack = null;
            this.btn_close.Location = new System.Drawing.Point(249, 409);
            this.btn_close.MouseBack = null;
            this.btn_close.Name = "btn_close";
            this.btn_close.NormlBack = null;
            this.btn_close.Size = new System.Drawing.Size(188, 36);
            this.btn_close.TabIndex = 2;
            this.btn_close.Text = "关 闭";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // pic_userimg
            // 
            this.pic_userimg.Location = new System.Drawing.Point(186, 88);
            this.pic_userimg.Name = "pic_userimg";
            this.pic_userimg.Size = new System.Drawing.Size(324, 261);
            this.pic_userimg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_userimg.TabIndex = 0;
            this.pic_userimg.TabStop = false;
            // 
            // skinButton2
            // 
            this.skinButton2.BackColor = System.Drawing.Color.Transparent;
            this.skinButton2.BaseColor = System.Drawing.SystemColors.ButtonShadow;
            this.skinButton2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton2.DownBack = null;
            this.skinButton2.Location = new System.Drawing.Point(64, 179);
            this.skinButton2.MouseBack = null;
            this.skinButton2.Name = "skinButton2";
            this.skinButton2.NormlBack = null;
            this.skinButton2.Size = new System.Drawing.Size(61, 49);
            this.skinButton2.TabIndex = 4;
            this.skinButton2.Text = "上一张";
            this.skinButton2.UseVisualStyleBackColor = false;
            this.skinButton2.Visible = false;
            // 
            // lab_name
            // 
            this.lab_name.AutoSize = true;
            this.lab_name.BackColor = System.Drawing.Color.Transparent;
            this.lab_name.BorderColor = System.Drawing.Color.White;
            this.lab_name.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_name.Location = new System.Drawing.Point(325, 7);
            this.lab_name.Name = "lab_name";
            this.lab_name.Size = new System.Drawing.Size(82, 19);
            this.lab_name.TabIndex = 5;
            this.lab_name.Text = "lab_name";
            // 
            // skinButton1
            // 
            this.skinButton1.BackColor = System.Drawing.Color.Transparent;
            this.skinButton1.BaseColor = System.Drawing.SystemColors.ButtonShadow;
            this.skinButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton1.DownBack = null;
            this.skinButton1.Location = new System.Drawing.Point(627, 179);
            this.skinButton1.MouseBack = null;
            this.skinButton1.Name = "skinButton1";
            this.skinButton1.NormlBack = null;
            this.skinButton1.Size = new System.Drawing.Size(61, 49);
            this.skinButton1.TabIndex = 4;
            this.skinButton1.Text = "下一张";
            this.skinButton1.UseVisualStyleBackColor = false;
            this.skinButton1.Visible = false;
            // 
            // WorkerImgAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 493);
            this.Controls.Add(this.lab_name);
            this.Controls.Add(this.skinButton2);
            this.Controls.Add(this.skinButton1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.lab_title);
            this.Controls.Add(this.pic_userimg);
            this.MaximizeBox = false;
            this.Name = "WorkerImgAuth";
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.pic_userimg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pic_userimg;
        private System.Windows.Forms.Label lab_title;
        private CCWin.SkinControl.SkinButton btn_close;
        private CCWin.SkinControl.SkinButton skinButton2;
        private CCWin.SkinControl.SkinLabel lab_name;
        private CCWin.SkinControl.SkinButton skinButton1;
    }
}