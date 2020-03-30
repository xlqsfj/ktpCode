using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using CCWin;
using KtpAcsAotoUpdate;


using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService;

using KtpAcsMiddleware.WinForm.Api.Models;
using KtpAcsMiddleware.WinForm.Api.Shared;

namespace KtpAcsMiddleware.WinForm.Api
{
    public partial class Login : Skin_Color
    {
        public Login()
        {
            InitializeComponent();
            
            Thread thread = new Thread(CheckUpdateApplication);

            thread.IsBackground = false;
            thread.Start();
            ConfigHelper.PanelApiType = (int)EPanelApiType.chidao;

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            FormHelper.CloseOpenForms(Name);
            Application.Exit();
        }
        private static void CheckUpdateApplication()
        {
            if (ConfigurationManager.AppSettings["IsAutoUpdater"] == "True")
            {
                //Application.EnableVisualStyles();
                ////  Application.SetCompatibleTextRenderingDefault(false);

                //GetAutoUpdater au = new GetAutoUpdater();

                Application.EnableVisualStyles();
                //  Application.SetCompatibleTextRenderingDefault(false);

                AutoUpdater au = new AutoUpdater(4);
                try
                {
                    au.Update();
                }
                catch (WebException exp)
                {
                    MessageBox.Show(String.Format("更新无法找到指定资源\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (XmlException exp)
                {
                    MessageBox.Show(String.Format("下载的升级文件有错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (NotSupportedException exp)
                {
                    MessageBox.Show(String.Format("升级地址配置错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (ArgumentException exp)
                {
                    MessageBox.Show(String.Format("下载的升级文件有错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(String.Format("升级过程中发生错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

                IMulePusher pusherLogin = new LoginApi() { RequestParam = new { account = UserNameTxt.Text, passWord = PasswordTxt.Text } };
                PushSummary pushLogin = pusherLogin.Push();
                if (!pushLogin.Success)
                {
                    MessageHelper.Show(pushLogin.Message);
                    return;
                }
                LoginResult rpushLogin = pushLogin.ResponseData;
                if (!rpushLogin.success)
                {
                    loginErroMsg = "用户名或密码不正确";
                    FormErrorProvider.SetError(PasswordTxt, loginErroMsg);
                    throw new PreValidationException(loginErroMsg);
                }
                ConfigHelper.KtpUploadNetWork = true;

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
                MessageHelper.Show(ex.Message);
            }
            finally
            {
                LoginBtn.Text = loginBtnText;
                LoginBtn.Enabled = true;
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {

            FormHelper.CloseOpenForms(Name);
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void menu_application_Exit_Click(object sender, EventArgs e)
        {
            FormHelper.CloseOpenForms(Name);
            Application.Exit();
        }

        private void menu_application_journal_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\logs";
            if (Directory.Exists(path))
                System.Diagnostics.Process.Start(path);
            else
                MessageHelper.Show("日志目录还未生成！");
        }

        private void menu_application_IsManualAddInfo_CheckStateChanged(object sender, EventArgs e)
        {
            CheckState check = menu_application_IsManualAddInfo.CheckState;
            if (check == CheckState.Checked)
                modifyItem("IsManualAddInfo", "True");
            else
                modifyItem("IsManualAddInfo", "False");
        }
        public void modifyItem(string keyName, string newKeyValue)
        {    //修改配置文件中键为keyName的项的值   

            //读取程序集的配置文件
            string assemblyConfigFile = Assembly.GetEntryAssembly().Location;
            string appDomainConfigFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //获取appSettings节点
            AppSettingsSection appSettings = (AppSettingsSection)config.GetSection("appSettings");

            //删除name，然后添加新值
            appSettings.Settings.Remove(keyName);
            appSettings.Settings.Add(keyName, newKeyValue);
            //保存配置文件
            config.Save();
        }
    }
}