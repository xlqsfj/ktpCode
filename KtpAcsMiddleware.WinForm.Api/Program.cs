using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Api.Models;
using KtpAcsMiddleware.WinForm.Api.TeamWorkers;
using KtpAcsMiddleware.WinForm.FaceRecognition;
using System;
using System.Windows.Forms;

namespace KtpAcsMiddleware.WinForm.Api
{
    internal static class Program
    {
        /// <summary>
        ///     应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                //设置应用程序处理异常方式：ThreadException处理
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Login());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"系统出现异常：{ex.Message}");
                throw;
            }
            //Debug
            //var user = ServiceFactory.OrgUserService.GetByAccount("admin");
            //AppLoginInfo.UserId = user.Id;
            //AppLoginInfo.LoginName = user.Account;
            //AppLoginInfo.UserName = user.Name;
            //Application.Run(new Home());
        }
        /// <summary>
        /// 处理非UI线程异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception str = e.ExceptionObject as Exception;
            LogHelper.ExceptionLog(str);
            LoadingHelper.CloseForm();
            MessageBox.Show("调用接口失败请重试！", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
         
        }
        /// <summary>
        /// 处理UI线程异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string str = "";
            string strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now.ToString() + "\r\n";
            Exception error = e.Exception as Exception;
            if (error != null)
            {
                str = string.Format(strDateInfo + "异常类型：{0}\r\n异常消息：{1}\r\n异常信息：{2}\r\n",
                error.GetType().Name, error.Message, error.StackTrace);
            }
            else
            {
                str = string.Format("应用程序线程错误:{0}", e);
            }
            LogHelper.ErrorLog(str);
            LoadingHelper.CloseForm();
            MessageBox.Show("无响应请重新！", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
         
        }


    }
}