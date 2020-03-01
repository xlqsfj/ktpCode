namespace KtpAcsMiddleware.WinForm.Organizations
{
    partial class UserList
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
            this.UsersGrid = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentityCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthdayText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTimeText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifiedTimeText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserCms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.UserAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserDelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserResetPasswordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.UsersGridPager = new KtpAcsMiddleware.WinForm.UserControls.KtpGridPager();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LoginTimeLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.ChangePasswordButton = new System.Windows.Forms.Button();
            this.ChangeLoginUserInfoButton = new System.Windows.Forms.Button();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.UserLoginNameLabel = new System.Windows.Forms.Label();
            this.UserStatesCb = new System.Windows.Forms.ComboBox();
            this.AddUserButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UsersGrid)).BeginInit();
            this.UserCms.SuspendLayout();
            this.SuspendLayout();
            // 
            // UsersGrid
            // 
            this.UsersGrid.AllowUserToAddRows = false;
            this.UsersGrid.AllowUserToDeleteRows = false;
            this.UsersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UsersGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UsersGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.UsersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.WorkerName,
            this.TeamName,
            this.IdentityCode,
            this.Mobile,
            this.BirthdayText,
            this.CreateTimeText,
            this.ModifiedTimeText});
            this.UsersGrid.ContextMenuStrip = this.UserCms;
            this.UsersGrid.Location = new System.Drawing.Point(3, 33);
            this.UsersGrid.MultiSelect = false;
            this.UsersGrid.Name = "UsersGrid";
            this.UsersGrid.ReadOnly = true;
            this.UsersGrid.RowHeadersVisible = false;
            this.UsersGrid.RowHeadersWidth = 20;
            this.UsersGrid.RowTemplate.Height = 23;
            this.UsersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UsersGrid.Size = new System.Drawing.Size(1158, 632);
            this.UsersGrid.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // WorkerName
            // 
            this.WorkerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WorkerName.DataPropertyName = "Name";
            this.WorkerName.FillWeight = 5F;
            this.WorkerName.HeaderText = "名称";
            this.WorkerName.MinimumWidth = 4;
            this.WorkerName.Name = "WorkerName";
            this.WorkerName.ReadOnly = true;
            // 
            // TeamName
            // 
            this.TeamName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TeamName.DataPropertyName = "LoginName";
            this.TeamName.FillWeight = 5F;
            this.TeamName.HeaderText = "登录名";
            this.TeamName.MinimumWidth = 6;
            this.TeamName.Name = "TeamName";
            this.TeamName.ReadOnly = true;
            // 
            // IdentityCode
            // 
            this.IdentityCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IdentityCode.DataPropertyName = "Mail";
            this.IdentityCode.FillWeight = 8F;
            this.IdentityCode.HeaderText = "邮箱";
            this.IdentityCode.Name = "IdentityCode";
            this.IdentityCode.ReadOnly = true;
            // 
            // Mobile
            // 
            this.Mobile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Mobile.DataPropertyName = "Mobile";
            this.Mobile.FillWeight = 7F;
            this.Mobile.HeaderText = "手机号码";
            this.Mobile.Name = "Mobile";
            this.Mobile.ReadOnly = true;
            // 
            // BirthdayText
            // 
            this.BirthdayText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BirthdayText.DataPropertyName = "BirthdayText";
            this.BirthdayText.FillWeight = 7F;
            this.BirthdayText.HeaderText = "出生日期";
            this.BirthdayText.Name = "BirthdayText";
            this.BirthdayText.ReadOnly = true;
            // 
            // CreateTimeText
            // 
            this.CreateTimeText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CreateTimeText.DataPropertyName = "CreateTimeText";
            this.CreateTimeText.FillWeight = 7F;
            this.CreateTimeText.HeaderText = "创建时间";
            this.CreateTimeText.Name = "CreateTimeText";
            this.CreateTimeText.ReadOnly = true;
            // 
            // ModifiedTimeText
            // 
            this.ModifiedTimeText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ModifiedTimeText.DataPropertyName = "ModifiedTimeText";
            this.ModifiedTimeText.FillWeight = 7F;
            this.ModifiedTimeText.HeaderText = "最后修改";
            this.ModifiedTimeText.Name = "ModifiedTimeText";
            this.ModifiedTimeText.ReadOnly = true;
            // 
            // UserCms
            // 
            this.UserCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UserAddMenuItem,
            this.UserEditMenuItem,
            this.UserDelMenuItem,
            this.UserResetPasswordMenuItem});
            this.UserCms.Name = "TeamsCms";
            this.UserCms.Size = new System.Drawing.Size(125, 92);
            // 
            // UserAddMenuItem
            // 
            this.UserAddMenuItem.Name = "UserAddMenuItem";
            this.UserAddMenuItem.Size = new System.Drawing.Size(124, 22);
            this.UserAddMenuItem.Text = "添加";
            this.UserAddMenuItem.Click += new System.EventHandler(this.UserAddMenuItem_Click);
            // 
            // UserEditMenuItem
            // 
            this.UserEditMenuItem.Name = "UserEditMenuItem";
            this.UserEditMenuItem.Size = new System.Drawing.Size(124, 22);
            this.UserEditMenuItem.Text = "编辑";
            this.UserEditMenuItem.Click += new System.EventHandler(this.UserEditMenuItem_Click);
            // 
            // UserDelMenuItem
            // 
            this.UserDelMenuItem.Name = "UserDelMenuItem";
            this.UserDelMenuItem.Size = new System.Drawing.Size(124, 22);
            this.UserDelMenuItem.Text = "删除";
            this.UserDelMenuItem.Click += new System.EventHandler(this.UserDelMenuItem_Click);
            // 
            // UserResetPasswordMenuItem
            // 
            this.UserResetPasswordMenuItem.Name = "UserResetPasswordMenuItem";
            this.UserResetPasswordMenuItem.Size = new System.Drawing.Size(124, 22);
            this.UserResetPasswordMenuItem.Text = "重设密码";
            this.UserResetPasswordMenuItem.Click += new System.EventHandler(this.UserResetPasswordMenuItem_Click);
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(3, 7);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(926, 21);
            this.SearchText.TabIndex = 15;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(1092, 5);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(69, 23);
            this.SearchButton.TabIndex = 14;
            this.SearchButton.Text = "搜索";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // UsersGridPager
            // 
            this.UsersGridPager.Location = new System.Drawing.Point(3, 668);
            this.UsersGridPager.Name = "UsersGridPager";
            this.UsersGridPager.PageCount = 0;
            this.UsersGridPager.PageIndex = 1;
            this.UsersGridPager.PageSize = 10;
            this.UsersGridPager.PagingHandler = null;
            this.UsersGridPager.Size = new System.Drawing.Size(291, 25);
            this.UsersGridPager.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1170, 247);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(155, 12);
            this.label15.TabIndex = 44;
            this.label15.Text = "-------------------------";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1170, 190);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(155, 12);
            this.label13.TabIndex = 42;
            this.label13.Text = "-------------------------";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1170, 116);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(155, 12);
            this.label12.TabIndex = 28;
            this.label12.Text = "-------------------------";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1170, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 34;
            this.label5.Text = "登录时间：";
            // 
            // LoginTimeLabel
            // 
            this.LoginTimeLabel.AutoSize = true;
            this.LoginTimeLabel.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LoginTimeLabel.Location = new System.Drawing.Point(1183, 226);
            this.LoginTimeLabel.Name = "LoginTimeLabel";
            this.LoginTimeLabel.Size = new System.Drawing.Size(43, 21);
            this.LoginTimeLabel.TabIndex = 33;
            this.LoginTimeLabel.Text = "***";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1173, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 29;
            this.label2.Text = "登录名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1170, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "当前用户：";
            // 
            // LogoutButton
            // 
            this.LogoutButton.Location = new System.Drawing.Point(1172, 341);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(153, 31);
            this.LogoutButton.TabIndex = 48;
            this.LogoutButton.Text = "注销";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // ChangePasswordButton
            // 
            this.ChangePasswordButton.Location = new System.Drawing.Point(1172, 305);
            this.ChangePasswordButton.Name = "ChangePasswordButton";
            this.ChangePasswordButton.Size = new System.Drawing.Size(153, 30);
            this.ChangePasswordButton.TabIndex = 47;
            this.ChangePasswordButton.Text = "修改密码";
            this.ChangePasswordButton.UseVisualStyleBackColor = true;
            this.ChangePasswordButton.Click += new System.EventHandler(this.ChangePasswordButton_Click);
            // 
            // ChangeLoginUserInfoButton
            // 
            this.ChangeLoginUserInfoButton.Location = new System.Drawing.Point(1172, 262);
            this.ChangeLoginUserInfoButton.Name = "ChangeLoginUserInfoButton";
            this.ChangeLoginUserInfoButton.Size = new System.Drawing.Size(153, 38);
            this.ChangeLoginUserInfoButton.TabIndex = 46;
            this.ChangeLoginUserInfoButton.Text = "详细信息";
            this.ChangeLoginUserInfoButton.UseVisualStyleBackColor = true;
            this.ChangeLoginUserInfoButton.Click += new System.EventHandler(this.ChangeLoginUserInfoButton_Click);
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserNameLabel.Location = new System.Drawing.Point(1185, 70);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(72, 35);
            this.UserNameLabel.TabIndex = 32;
            this.UserNameLabel.Text = "***";
            // 
            // UserLoginNameLabel
            // 
            this.UserLoginNameLabel.AutoSize = true;
            this.UserLoginNameLabel.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserLoginNameLabel.Location = new System.Drawing.Point(1183, 161);
            this.UserLoginNameLabel.Name = "UserLoginNameLabel";
            this.UserLoginNameLabel.Size = new System.Drawing.Size(43, 21);
            this.UserLoginNameLabel.TabIndex = 50;
            this.UserLoginNameLabel.Text = "***";
            // 
            // UserStatesCb
            // 
            this.UserStatesCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserStatesCb.FormattingEnabled = true;
            this.UserStatesCb.Location = new System.Drawing.Point(935, 7);
            this.UserStatesCb.Name = "UserStatesCb";
            this.UserStatesCb.Size = new System.Drawing.Size(151, 20);
            this.UserStatesCb.TabIndex = 11;
            // 
            // AddUserButton
            // 
            this.AddUserButton.Location = new System.Drawing.Point(1167, 5);
            this.AddUserButton.Name = "AddUserButton";
            this.AddUserButton.Size = new System.Drawing.Size(153, 23);
            this.AddUserButton.TabIndex = 51;
            this.AddUserButton.Text = "新建用户";
            this.AddUserButton.UseVisualStyleBackColor = true;
            this.AddUserButton.Click += new System.EventHandler(this.AddUserButton_Click);
            // 
            // UserList
            // 
            this.AcceptButton = this.SearchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 696);
            this.Controls.Add(this.UsersGrid);
            this.Controls.Add(this.UsersGridPager);
            this.Controls.Add(this.AddUserButton);
            this.Controls.Add(this.UserStatesCb);
            this.Controls.Add(this.UserLoginNameLabel);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.ChangePasswordButton);
            this.Controls.Add(this.ChangeLoginUserInfoButton);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LoginTimeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchText);
            this.Controls.Add(this.SearchButton);
            this.Name = "UserList";
            this.Text = "用户管理";
            ((System.ComponentModel.ISupportInitialize)(this.UsersGrid)).EndInit();
            this.UserCms.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView UsersGrid;
        private System.Windows.Forms.ContextMenuStrip UserCms;
        private System.Windows.Forms.ToolStripMenuItem UserEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UserDelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UserAddMenuItem;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentityCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthdayText;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTimeText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifiedTimeText;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LoginTimeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Button ChangePasswordButton;
        private System.Windows.Forms.Button ChangeLoginUserInfoButton;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Label UserLoginNameLabel;
        private System.Windows.Forms.ToolStripMenuItem UserResetPasswordMenuItem;
        private System.Windows.Forms.ComboBox UserStatesCb;
        private System.Windows.Forms.Button AddUserButton;
        private UserControls.KtpGridPager UsersGridPager;
    }
}