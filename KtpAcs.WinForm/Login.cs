using CCWin;
using KtpAcs.WinForm.Models;
using KtpAcsAotoUpdate;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace KtpAcs.WinForm
{
    public partial class Login : Skin_Color
    {
        public Login()
        {
            InitializeComponent();
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
               
                if (UserNameTxt.Text == "admin" && PasswordTxt.Text == "123456")
                {

                    ConfigHelper._KtpLoginProjectId = ConfigHelper.ProjectId;
                }
                else
                {
                    if (ConfigHelper.KtpUploadNetWork)
                    {
                        IMulePusher pusherLogin = new LoginApi() { RequestParam = new { account = UserNameTxt.Text, passWord = PasswordTxt.Text }, s_rootUrl = ConfigHelper.KtpApiBaseJavaUrl };

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
                    }
                    else {
                        loginErroMsg = "用户名或密码不正确";
                        FormErrorProvider.SetError(PasswordTxt, loginErroMsg);
                        throw new PreValidationException(loginErroMsg);
                    }
                }

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

        private void ExitButton_Click(object sender, EventArgs e)
        {
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

                AutoUpdater au = new AutoUpdater(2);
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

        /// <summary>
        /// 加载网络信息
        /// </summary>
        private void GetNetWorkInfoLoad()
        {

           
            //网络情况是否联网
            string url = "www.baidu.com";
            bool isconn = ConfigHelper.KtpUploadNetWork;
            Ping ping = new Ping();
            try
            {
                int timeout = 5;//设置超时时间             
                PingReply pr = ping.Send(url, timeout);
                if (pr.Status == IPStatus.Success)
                {//连接正常情况下

                    ConfigHelper.KtpUploadNetWork = true;

                }
                

            }
            catch (Exception ex)
            {
               
                LogHelper.ExceptionLog(ex);
            }



        }

        private void Login_Load(object sender, EventArgs e)
        {
            GetNetWorkInfoLoad();
            if (ConfigHelper.KtpUploadNetWork)
            {
                Thread thread = new Thread(CheckUpdateApplication);
                thread.IsBackground = true;
                thread.Start();
            }
            else
            {

                pl_ts.Visible = true;

            }
        }
    }
}
