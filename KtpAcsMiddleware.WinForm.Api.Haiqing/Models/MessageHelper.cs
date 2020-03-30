using KtpAcsMiddleware.WinForm.Api.Shared;
using System;


namespace KtpAcsMiddleware.WinForm.Api.Models
{
    internal class MessageHelper
    {
        public static void Show(string msg)
        {
            LoadingHelper.CloseForm();
            //MessageHelper.Show(msg);
            new MessagePrompt(msg).ShowDialog();
        }

        public static void Show(Exception ex)
        {
            new MessagePrompt(ex.Message).ShowDialog();
        }

        public static void Show(string msg,string  title)
        {
            new MessagePrompt(msg).ShowDialog();
        }
    }
}