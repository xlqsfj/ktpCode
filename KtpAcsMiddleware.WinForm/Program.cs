using System;
using System.Windows.Forms;

namespace KtpAcsMiddleware.WinForm
{
    internal static class Program
    {
        /// <summary>
        ///     应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            //Debug
            //var user = ServiceFactory.OrgUserService.GetByAccount("admin");
            //AppLoginInfo.UserId = user.Id;
            //AppLoginInfo.LoginName = user.Account;
            //AppLoginInfo.UserName = user.Name;
            //Application.Run(new Home());
        }
    }
}