using System;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.Organizations;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Models;
using KtpAcsMiddleware.WinForm.Shared;

namespace KtpAcsMiddleware.WinForm.Organizations
{
    public partial class UserChangePassword : FormBaseUi
    {
        public UserChangePassword()
        {
            InitializeComponent();
        }

        public void Init()
        {
            if (!string.IsNullOrEmpty(AppLoginInfo.UserId))
            {
                SubmitBtn.Enabled = false;
                MessageHelper.Show("未发现当前登录账号");
            }
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var isPrePass = true;
                PreValidationHelper.InitPreValidation(FormErrorProvider);
                PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, PasswordTxt, "原密码不允许为空", ref isPrePass);
                PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, NewPasswordTxt, "新密码不允许为空", ref isPrePass);
                PreValidationHelper.MustNotBeNullOrEmpty(
                    FormErrorProvider, NewPassword2Txt, "新密码确认不允许为空", ref isPrePass);
                if (!string.IsNullOrEmpty(NewPassword2Txt.Text) && NewPasswordTxt.Text != NewPassword2Txt.Text)
                {
                    FormErrorProvider.SetError(NewPassword2Txt, "确认密码与新密码不一致");
                    isPrePass = false;
                }
                //原密码验证
                var user = ServiceFactory.OrgUserService.Get(AppLoginInfo.UserId);
                if (!string.IsNullOrEmpty(PasswordTxt.Text) &&
                    user.Password != CryptographicHelper.Hash(PasswordTxt.Text))
                {
                    FormErrorProvider.SetError(PasswordTxt, "原密码错误");
                    if (isPrePass)
                    {
                        PreValidationHelper.ErroMsg = "原密码错误";
                    }
                    isPrePass = false;
                }
                if (!isPrePass)
                {
                    throw new PreValidationException();
                }

                ServiceFactory.OrgUserService.ChangeUserPassword(AppLoginInfo.UserId, NewPasswordTxt.Text);
                MessageHelper.Show("密码修改成功");
                Hide();
            }
            catch (PreValidationException)
            {
                MessageHelper.Show(PreValidationHelper.ErroMsg);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}