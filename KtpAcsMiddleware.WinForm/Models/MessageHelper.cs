using System;
using KtpAcsMiddleware.WinForm.Shared;

namespace KtpAcsMiddleware.WinForm.Models
{
    internal class MessageHelper
    {
        public static void Show(string msg)
        {
            //MessageBox.Show(msg);
            new MessagePrompt(msg).ShowDialog();
        }

        public static void Show(Exception ex)
        {
            new MessagePrompt($"出现异常：{ex.Message}").ShowDialog();
        }
    }
}