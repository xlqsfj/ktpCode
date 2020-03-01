using System;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Organizations;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Models;
using KtpAcsMiddleware.WinForm.Shared;

namespace KtpAcsMiddleware.WinForm.Organizations
{
    public partial class UserDetailed : FormBaseUi
    {
        public UserDetailed()
        {
            InitializeComponent();
            BirthdayDtp.Value = BirthdayDtp.MinDate;
        }

        public UserDetailed(string id)
        {
            InitializeComponent();

            UserIdLabel.Text = id;
            var user = ServiceFactory.OrgUserService.Get(id);
            NameTxt.Text = user.Name;
            LoginNameTxt.Text = user.Account;
            CodeTxt.Text = user.Code ?? string.Empty;

            if (id == OrgUserDataService.FindAdmin().Id)
            {
                NameTxt.ReadOnly = true;
                LoginNameTxt.ReadOnly = true;
                CodeTxt.ReadOnly = true;
            }
            BirthdayDtp.Value = user.Birthday ?? BirthdayDtp.MinDate;
            MailTxt.Text = user.Mail ?? string.Empty;
            MobileTxt.Text = user.Mobile ?? string.Empty;

            if (user.Status == (int) OrgUserState.Cancle)
            {
                ReactivationButton.Visible = true;
                SaveBtn.Visible = false;
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var isPrePass = true;
                PreValidationHelper.InitPreValidation(FormErrorProvider);
                PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, NameTxt, "姓名不允许为空", ref isPrePass);
                PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, LoginNameTxt, "登录名不允许为空", ref isPrePass);
                PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, MailTxt, "邮箱不允许为空", ref isPrePass);
                PreValidationHelper.IsMail(FormErrorProvider, MailTxt, "邮箱格式错误", ref isPrePass);
                PreValidationHelper.IsMobile(FormErrorProvider, MobileTxt, "手机格式错误", ref isPrePass);
                if (!isPrePass)
                {
                    throw new PreValidationException(PreValidationHelper.ErroMsg);
                }
                var id = UserIdLabel.Text;
                var user = new OrgUser
                {
                    Id = id,
                    Name = NameTxt.Text.Trim(),
                    Code = CodeTxt.Text,
                    Account = LoginNameTxt.Text.Trim(),
                    Mobile = MobileTxt.Text,
                    Mail = MailTxt.Text
                };
                if (BirthdayDtp.Value != BirthdayDtp.MinDate)
                {
                    user.Birthday = BirthdayDtp.Value;
                }

                if (ServiceFactory.OrgUserService.AnyLoginName(user.Account, id))
                {
                    FormErrorProvider.SetError(LoginNameTxt, "登录名不允许重复");
                    throw new PreValidationException("登录名不允许重复");
                }
                if (!string.IsNullOrEmpty(user.Code) && ServiceFactory.OrgUserService.AnyCode(user.Code, id))
                {
                    FormErrorProvider.SetError(CodeTxt, "编号不允许重复");
                    throw new PreValidationException("编号不允许重复");
                }
                if (!string.IsNullOrEmpty(id))
                {
                    ServiceFactory.OrgUserService.ChangeUser(user);
                    MessageHelper.Show("用户更新成功");
                }
                else
                {
                    ServiceFactory.OrgUserService.AddUser(user);
                    MessageHelper.Show("用户新建成功");
                }
                Hide();
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
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void ReactivationButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(UserIdLabel.Text))
                {
                    throw new PreValidationException("目标用户ID不允许为空");
                }
                ServiceFactory.OrgUserService.ReactivationUser(UserIdLabel.Text);
                MessageHelper.Show("重新激活成功");
                Hide();
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
        }
    }
}