using System;
using System.Linq;
using System.Windows.Forms;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.Organizations;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Models;
using KtpAcsMiddleware.WinForm.Shared;

namespace KtpAcsMiddleware.WinForm.Organizations
{
    public partial class UserList : FormBase
    {
        public UserList()
        {
            InitializeComponent();
            UsersGrid.AutoGenerateColumns = false;
            BindUserStatesCb();
            BindLoginInfo();
            BindUsers();
            InitGridPagingNavigatorControl();
        }

        private void BindUserStatesCb()
        {
            var userStates = OrgUserState.Normal.GetDescriptions().ToList();
            UserStatesCb.DataSource = userStates;
            UserStatesCb.DisplayMember = "Value";
            UserStatesCb.ValueMember = "Key";
        }

        private void BindLoginInfo()
        {
            if (string.IsNullOrEmpty(AppLoginInfo.UserId))
            {
                MessageHelper.Show("未发现当前登录账号");
                Logout();
            }

            UserNameLabel.Text = AppLoginInfo.UserName;
            UserLoginNameLabel.Text = AppLoginInfo.LoginName;
            LoginTimeLabel.Text = FormatHelper.GetTimeString(AppLoginInfo.LoginTime);
            if (AppLoginInfo.UserId == OrgUserDataService.FindAdmin().Id)
            {
                UserNameLabel.Text = @"管理员";
            }
        }

        private void InitGridPagingNavigatorControl()
        {
            UsersGridPager.PagingHandler = GridPagingNavigatorControlPagingEvent;
        }

        public void GridPagingNavigatorControlPagingEvent()
        {
            BindUsers();
        }

        private void BindUsers(string selectUserId = null)
        {
            var pageSize = UsersGridPager.PageSize;
            var pageIndex = UsersGridPager.PageIndex;

            var userState = (int) OrgUserState.Normal;
            if (UserStatesCb.SelectedValue != null)
            {
                userState = int.Parse(UserStatesCb.SelectedValue.ToString());
            }
            var keywords = SearchText.Text.Trim();
            var pagedUsers = ServiceFactory.OrgUserService.GetPaged(pageIndex, pageSize, userState, keywords);
            UsersGrid.DataSource = pagedUsers.Entities;

            UsersGridPager.PageCount = (pagedUsers.Count + pageSize - 1) / pageSize;

            if (!string.IsNullOrEmpty(selectUserId))
            {
                for (var i = 0; i < UsersGrid.Rows.Count; i++)
                {
                    if (UsersGrid.Rows[i].Cells[0].Value.ToString() == selectUserId)
                    {
                        UsersGrid.Rows[i].Selected = true;
                    }
                }
            }
            if (pagedUsers.Count == 0)
            {
                UserEditMenuItem.Visible = false;
                UserDelMenuItem.Visible = false;
                UserResetPasswordMenuItem.Visible = false;
            }
            else
            {
                UserEditMenuItem.Visible = true;
                UserDelMenuItem.Visible = true;
                UserResetPasswordMenuItem.Visible = true;
            }
        }

        /// <summary>
        ///     右键触发用户添加
        /// </summary>
        private void UserAddMenuItem_Click(object sender, EventArgs e)
        {
            new UserDetailed().ShowDialog();
            SearchText.Text = string.Empty;
            BindUsers();
        }

        /// <summary>
        ///     右键触发用户编辑
        /// </summary>
        private void UserEditMenuItem_Click(object sender, EventArgs e)
        {
            if (UsersGrid.CurrentRow != null)
            {
                var selectUserId = UsersGrid.SelectedRows[0].Cells[0].Value.ToString();
                new UserDetailed(selectUserId).ShowDialog();
                BindUsers(selectUserId);
            }
            else
            {
                MessageHelper.Show("没有选中的用户");
            }
        }

        /// <summary>
        ///     右键触发用户删除
        /// </summary>
        private void UserDelMenuItem_Click(object sender, EventArgs e)
        {
            if (UsersGrid.CurrentRow != null)
            {
                var selectUserId = UsersGrid.SelectedRows[0].Cells[0].Value.ToString();
                if (AppLoginInfo.UserId != null && selectUserId == AppLoginInfo.UserId)
                {
                    MessageHelper.Show("不能删除当前登录的账号");
                    return;
                }
                var selectUserName = UsersGrid.SelectedRows[0].Cells[1].Value.ToString();
                if (MessageBox.Show($@"确认要删除<{selectUserName}>吗？", @"删除提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ServiceFactory.OrgUserService.CancleUser(selectUserId);
                    LogHelper.EntryLog(AppLoginInfo.UserId, $"DelUser,id={selectUserId}");
                    MessageHelper.Show($"用户<{selectUserName}>删除成功");
                    BindUsers();
                }
            }
            else
            {
                MessageHelper.Show("没有选中的用户");
            }
        }

        /// <summary>
        ///     右键触发用户重设密码
        /// </summary>
        private void UserResetPasswordMenuItem_Click(object sender, EventArgs e)
        {
            if (UsersGrid.CurrentRow != null)
            {
                var selectUserId = UsersGrid.SelectedRows[0].Cells[0].Value.ToString();
                var selectUserName = UsersGrid.SelectedRows[0].Cells[1].Value.ToString();
                var userPwd = ConfigHelper.DefaultUserPwd;
                if (MessageBox.Show($@"确认重设<{selectUserName}>的密码吗？", @"重设密码提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ServiceFactory.OrgUserService.ChangeUserPassword(selectUserId, userPwd);
                    MessageHelper.Show($"用户<{selectUserName}>密码重设成功");
                    BindUsers(selectUserId);
                }
            }
            else
            {
                MessageHelper.Show("没有选中的用户");
            }
        }

        /// <summary>
        ///     新建用户
        /// </summary>
        private void AddUserButton_Click(object sender, EventArgs e)
        {
            new UserDetailed().ShowDialog();
            SearchText.Text = string.Empty;
            BindUsers();
        }

        /// <summary>
        ///     详细信息按钮打开当前登录用户信息编辑
        /// </summary>
        private void ChangeLoginUserInfoButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(AppLoginInfo.UserId))
            {
                new UserDetailed(AppLoginInfo.UserId).ShowDialog();
            }
            else
            {
                MessageHelper.Show("未发现当前登录账号");
            }
        }

        /// <summary>
        ///     修改密码按钮触发当前登录用户修改密码
        /// </summary>
        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            new UserChangePassword().ShowDialog();
        }

        /// <summary>
        ///     注销按钮触发当前登录用户退出登录
        /// </summary>
        private void LogoutButton_Click(object sender, EventArgs e)
        {
            AppLoginInfo.UserId = null;
            AppLoginInfo.LoginName = null;
            AppLoginInfo.UserName = null;

            Logout();
        }

        private void Logout()
        {
            var openFormsCount = Application.OpenForms.Count;
            for (var i = 0; i < openFormsCount; i++)
            {
                var openForm = Application.OpenForms[i];
                if (openForm.Name == "Home")
                {
                    openForm.Close();
                }
            }
            new Login().Show();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            BindUsers();
        }
    }
}