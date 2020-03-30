namespace KtpAcsMiddleware.WinForm.FaceRecognition
{
    partial class DeviceListForm
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
            this.DeviceListGrid = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machineNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deviceIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deviceIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isdel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnsyn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceListGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DeviceListGrid
            // 
            this.DeviceListGrid.AllowUserToAddRows = false;
            this.DeviceListGrid.AllowUserToDeleteRows = false;
            this.DeviceListGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DeviceListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DeviceListGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.machineNum,
            this.deviceIp,
            this.deviceIn,
            this.state,
            this.description,
            this.isdel,
            this.updateTime});
            this.DeviceListGrid.Location = new System.Drawing.Point(-2, 39);
            this.DeviceListGrid.MultiSelect = false;
            this.DeviceListGrid.Name = "DeviceListGrid";
            this.DeviceListGrid.ReadOnly = true;
            this.DeviceListGrid.RowHeadersVisible = false;
            this.DeviceListGrid.RowHeadersWidth = 20;
            this.DeviceListGrid.RowTemplate.Height = 23;
            this.DeviceListGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DeviceListGrid.Size = new System.Drawing.Size(930, 523);
            this.DeviceListGrid.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // machineNum
            // 
            this.machineNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.machineNum.DataPropertyName = "machineNum";
            this.machineNum.FillWeight = 5F;
            this.machineNum.HeaderText = "设备号";
            this.machineNum.Name = "machineNum";
            this.machineNum.ReadOnly = true;
            // 
            // deviceIp
            // 
            this.deviceIp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.deviceIp.DataPropertyName = "deviceIp";
            this.deviceIp.FillWeight = 4F;
            this.deviceIp.HeaderText = "ip地址";
            this.deviceIp.Name = "deviceIp";
            this.deviceIp.ReadOnly = true;
            // 
            // deviceIn
            // 
            this.deviceIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.deviceIn.DataPropertyName = "deviceIn";
            this.deviceIn.FillWeight = 8F;
            this.deviceIn.HeaderText = "是否进场方向";
            this.deviceIn.MinimumWidth = 7;
            this.deviceIn.Name = "deviceIn";
            this.deviceIn.ReadOnly = true;
            // 
            // state
            // 
            this.state.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.state.DataPropertyName = "state";
            this.state.FillWeight = 5F;
            this.state.HeaderText = "在线状态";
            this.state.Name = "state";
            this.state.ReadOnly = true;
            // 
            // description
            // 
            this.description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.description.DataPropertyName = "description";
            this.description.FillWeight = 4F;
            this.description.HeaderText = "描述";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // isdel
            // 
            this.isdel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.isdel.DataPropertyName = "isdel";
            this.isdel.FillWeight = 5F;
            this.isdel.HeaderText = "是否删除";
            this.isdel.Name = "isdel";
            this.isdel.ReadOnly = true;
            // 
            // updateTime
            // 
            this.updateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.updateTime.DataPropertyName = "updateTime";
            this.updateTime.FillWeight = 15F;
            this.updateTime.HeaderText = "创建时间";
            this.updateTime.Name = "updateTime";
            this.updateTime.ReadOnly = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(842, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnsyn
            // 
            this.btnsyn.Location = new System.Drawing.Point(738, 10);
            this.btnsyn.Name = "btnsyn";
            this.btnsyn.Size = new System.Drawing.Size(75, 23);
            this.btnsyn.TabIndex = 3;
            this.btnsyn.Text = "同步";
            this.btnsyn.UseVisualStyleBackColor = true;
            this.btnsyn.Click += new System.EventHandler(this.btnsyn_Click);
            // 
            // DeviceListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 565);
            this.Controls.Add(this.btnsyn);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.DeviceListGrid);
            this.Name = "DeviceListForm";
            this.Text = "DeviceListForm";
            this.Load += new System.EventHandler(this.DeviceListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DeviceListGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DeviceListGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn isdel;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateTime;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnsyn;
    }
}