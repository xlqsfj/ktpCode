using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.WinForm.Api.Models
{
    internal class FormHelper
    {
        public static void CloseOpenForms(string excludedName)
        {
            //关闭窗口(当前允许关闭的)
            IList<string> closeTargetFormNames = new List<string>();
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == excludedName)
                {
                    continue;
                }
                //注销调用时排除登录窗口的关闭
                if (openForm.Name == "Login" )
                {
                    continue;
                }
                closeTargetFormNames.Add(openForm.Name);
            }
            foreach (var closeTargetFormName in closeTargetFormNames)
            {
                try
                {
                    var openFormsCount = Application.OpenForms.Count;
                    for (var i = 0; i < openFormsCount; i++)
                    {
                        var closeTargetForm = Application.OpenForms[0];
                        if (closeTargetForm.Name == closeTargetFormName)
                        {
                            closeTargetForm.Close();
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.ExceptionLog(ex);
                }
            }
        }
    }
}