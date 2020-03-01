using KtpAcs.WinForm.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcs.WinForm.Models
{
     internal  class MessageHelper
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

        public static void Show(string msg, string title)
        {
            new MessagePrompt(msg).ShowDialog();
        }

    }
}
