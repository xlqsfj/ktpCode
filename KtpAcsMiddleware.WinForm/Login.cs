using System;
using System.Windows.Forms;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.Organizations;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Models;
using KtpAcsMiddleware.WinForm.Shared;

namespace KtpAcsMiddleware.WinForm
{
    public partial class Login : FormBaseUi
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            FormHelper.CloseOpenForms(Name);
            Application.Exit();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            var loginBtnText = LoginBtn.Text;
            try
            {
                LoginBtn.Text = @"正在登录";
                LoginBtn.Enabled = false;
                FormErrorProvider.Clear();
                var loginErroMsg = @"用户名或者密码错误";
                if (string.IsNullOrEmpty(UserNameTxt.Text))
                {
                    loginErroMsg = "用户名不允许为空";
                    FormErrorProvider.SetError(UserNameTxt, loginErroMsg);
                    throw new PreValidationException(loginErroMsg);
                }
                if (string.IsNullOrEmpty(PasswordTxt.Text))
                {
                    loginErroMsg = "密码不允许为空";
                    FormErrorProvider.SetError(PasswordTxt, loginErroMsg);
                    throw new PreValidationException(loginErroMsg);
                }
                var user = ServiceFactory.OrgUserService.GetByAccount(UserNameTxt.Text);
                if (user == null || user.Status != (int) OrgUserState.Normal)
                {
                    throw new PreValidationException(loginErroMsg);
                }
                if (user.Password != CryptographicHelper.Hash(PasswordTxt.Text))
                {
                    throw new PreValidationException(loginErroMsg);
                }
                AppLoginInfo.UserId = user.Id;
                AppLoginInfo.LoginName = user.Account;
                AppLoginInfo.UserName = user.Name;
                AppLoginInfo.LoginTime = DateTime.Now;

                Hide();
                new Home().Show();
            }
            catch (PreValidationException ex)
            {
                MessageHelper.Show(ex.Message);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
            finally
            {
                LoginBtn.Text = loginBtnText;
                LoginBtn.Enabled = true;
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AppLoginInfo.UserId != null)
            {
                return;
            }
            FormHelper.CloseOpenForms(Name);
            Application.Exit();
        }
    }
}