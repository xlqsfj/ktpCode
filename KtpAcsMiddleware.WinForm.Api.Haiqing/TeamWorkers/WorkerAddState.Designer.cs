namespace KtpAcsMiddleware.WinForm.Api.TeamWorkers
{
    partial class WorkerAddState
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkerAddState));
            this.skin_close = new CCWin.SkinControl.SkinButton();
            this.skingrid_sysPanel = new CCWin.SkinControl.SkinDataGridView();
            this.deviceIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deviceIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.magAdd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReason = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.skinlable_addworkImg = new System.Windows.Forms.Label();
            this.skin_retry = new CCWin.SkinControl.SkinButton();
            ((System.ComponentModel.ISupportInitialize)(this.skingrid_sysPanel)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skin_close
            // 
            this.skin_close.BackColor = System.Drawing.Color.Transparent;
            this.skin_close.BaseColor = System.Drawing.SystemColors.AppWorkspace;
            this.skin_close.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skin_close.DownBack = null;
            this.skin_close.Enabled = false;
            this.skin_close.Location = new System.Drawing.Point(194, 279);
            this.skin_close.MouseBack = null;
            this.skin_close.Name = "skin_close";
            this.skin_close.NormlBack = null;
            this.skin_close.Size = new System.Drawing.Size(236, 32);
            this.skin_close.TabIndex = 2;
            this.skin_close.Text = "返 回 编 辑";
            this.skin_close.UseVisualStyleBackColor = false;
            this.skin_close.Click += new System.EventHandler(this.skin_close_Click);
            // 
            // skingrid_sysPanel
            // 
            this.skingrid_sysPanel.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.skingrid_sysPanel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.skingrid_sysPanel.BackgroundColor = System.Drawing.SystemColors.Window;
            this.skingrid_sysPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.skingrid_sysPanel.ColumnFont = null;
            this.skingrid_sysPanel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.skingrid_sysPanel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.skingrid_sysPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.skingrid_sysPanel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deviceIP,
            this.deviceIn,
            this.magAdd,
            this.btnReason});
            this.skingrid_sysPanel.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.skingrid_sysPanel.DefaultCellStyle = dataGridViewCellStyle3;
            this.skingrid_sysPanel.EnableHeadersVisualStyles = false;
            this.skingrid_sysPanel.GridColor = System.Drawing.SystemColors.ScrollBar;
            this.skingrid_sysPanel.HeadFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skingrid_sysPanel.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.skingrid_sysPanel.Location = new System.Drawing.Point(0, 44);
            this.skingrid_sysPanel.Name = "skingrid_sysPanel";
            this.skingrid_sysPanel.ReadOnly = true;
            this.skingrid_sysPanel.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.skingrid_sysPanel.RowHeadersVisible = false;
            this.skingrid_sysPanel.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.skingrid_sysPanel.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.skingrid_sysPanel.RowTemplate.Height = 23;
            this.skingrid_sysPanel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.skingrid_sysPanel.Size = new System.Drawing.Size(618, 165);
            this.skingrid_sysPanel.SkinGridColor = System.Drawing.SystemColors.ScrollBar;
            this.skingrid_sysPanel.TabIndex = 1;
            this.skingrid_sysPanel.TitleBack = null;
            this.skingrid_sysPanel.TitleBackColorBegin = System.Drawing.Color.White;
            this.skingrid_sysPanel.TitleBackColorEnd = System.Drawing.SystemColors.ActiveBorder;
            this.skingrid_sysPanel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.skingrid_sysPanel_CellContentClick);
            // 
            // deviceIP
            // 
            this.deviceIP.DataPropertyName = "deviceIP";
            this.deviceIP.HeaderText = "设备Ip号";
            this.deviceIP.Name = "deviceIP";
            this.deviceIP.ReadOnly = true;
            // 
            // deviceIn
            // 
            this.deviceIn.DataPropertyName = "deviceIn";
            this.deviceIn.HeaderText = "是否进出方向";
            this.deviceIn.Name = "deviceIn";
            this.deviceIn.ReadOnly = true;
            this.deviceIn.Width = 102;
            // 
            // magAdd
            // 
            this.magAdd.DataPropertyName = "magAdd";
            this.magAdd.HeaderText = "添加消息";
            this.magAdd.Name = "magAdd";
            this.magAdd.ReadOnly = true;
            this.magAdd.Width = 320;
            // 
            // btnReason
            // 
            this.btnReason.DataPropertyName = "reason";
            this.btnReason.HeaderText = "操作";
            this.btnReason.Name = "btnReason";
            this.btnReason.ReadOnly = true;
            this.btnReason.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnReason.Text = "重试";
            this.btnReason.ToolTipText = "失败重试";
            this.btnReason.UseColumnTextForButtonValue = true;
            this.btnReason.Width = 90;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.skingrid_sysPanel);
            this.panel2.Location = new System.Drawing.Point(11, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(621, 212);
            this.panel2.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.skinlable_addworkImg);
            this.panel1.Controls.Add(this.skin_retry);
            this.panel1.Location = new System.Drawing.Point(13, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 38);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "向云端添加";
            // 
            // skinlable_addworkImg
            // 
            this.skinlable_addworkImg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.skinlable_addworkImg.AutoSize = true;
            this.skinlable_addworkImg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinlable_addworkImg.Location = new System.Drawing.Point(121, 12);
            this.skinlable_addworkImg.Name = "skinlable_addworkImg";
            this.skinlable_addworkImg.Size = new System.Drawing.Size(72, 16);
            this.skinlable_addworkImg.TabIndex = 6;
            this.skinlable_addworkImg.Text = "添加中..\r\n";
            this.skinlable_addworkImg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skin_retry
            // 
            this.skin_retry.BackColor = System.Drawing.Color.Transparent;
            this.skin_retry.BaseColor = System.Drawing.SystemColors.ButtonShadow;
            this.skin_retry.BorderColor = System.Drawing.Color.Silver;
            this.skin_retry.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skin_retry.DownBack = null;
            this.skin_retry.Location = new System.Drawing.Point(453, 3);
            this.skin_retry.MouseBack = null;
            this.skin_retry.Name = "skin_retry";
            this.skin_retry.NormlBack = null;
            this.skin_retry.Size = new System.Drawing.Size(108, 31);
            this.skin_retry.TabIndex = 5;
            this.skin_retry.Text = "重试";
            this.skin_retry.UseVisualStyleBackColor = false;
            this.skin_retry.Click += new System.EventHandler(this.skin_retry_Click);
            // 
            // WorkerAddState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 321);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.skin_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WorkerAddState";
            this.Text = "";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkerAddState_FormClosing);
            this.Load += new System.EventHandler(this.WorkerAddState_Load);
            ((System.ComponentModel.ISupportInitialize)(this.skingrid_sysPanel)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private CCWin.SkinControl.SkinButton skin_close;
        private CCWin.SkinControl.SkinDataGridView skingrid_sysPanel;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label skinlable_addworkImg;
        private CCWin.SkinControl.SkinButton skin_retry;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn magAdd;
        private System.Windows.Forms.DataGridViewButtonColumn btnReason;
    }
}