using System.Windows.Forms;
using KtpAcsMiddleware.Infrastructure.Exceptions;

namespace KtpAcsMiddleware.WinForm.Api.Models
{
    internal class PreValidationHelper
    {
        public static string ErroMsg { get; set; } = "输入信息验证失败，请按感叹号提示输入完整信息";

        public static void InitPreValidation(ErrorProvider errorProvider)
        {
            errorProvider.Clear();
            ErroMsg = "输入信息验证失败，请按感叹号提示输入完整信息";
        }

        public static void MustNotBeNullOrEmpty(
            ErrorProvider errorProvider, TextBox textBox, string msg, ref bool result)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                errorProvider.SetError(textBox, msg);
                result = false;
            }
        }

        public static void MustNotBeNull(
            ErrorProvider errorProvider, ComboBox comboBox, string msg, ref bool result)
        {
            if (comboBox.SelectedValue == null || comboBox.SelectedValue.ToString() == string.Empty)
            {
                errorProvider.SetError(comboBox, msg);
                result = false;
            }
        }

        public static void MustChecked(
            ErrorProvider errorProvider, ComboBox comboBox, string msg, ref bool result)
        {
            if (comboBox.SelectedValue == null || comboBox.SelectedValue.ToString() == string.Empty)
            {
                errorProvider.SetError(comboBox, msg);
                result = false;
            }
        }

        public static void IsMail(
            ErrorProvider errorProvider, TextBox textBox, string msg, ref bool result)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                return;
            }
            if (!ValidationHelper.IsMail(textBox.Text))
            {
                errorProvider.SetError(textBox, msg);
                result = false;
            }
        }

        public static void IsMobile(
            ErrorProvider errorProvider, TextBox textBox, string msg, ref bool result)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                return;
            }
            if (!ValidationHelper.IsMobile(textBox.Text))
            {
                errorProvider.SetError(textBox, msg);
                result = false;
            }
        }

        public static void IsIpAddress(
            ErrorProvider errorProvider, TextBox textBox, string msg, ref bool result)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                return;
            }
            if (!ValidationHelper.IsIpAddress(textBox.Text))
            {
                errorProvider.SetError(textBox, msg);
                result = false;
            }
        }

        public static void IsIdCard(
            ErrorProvider errorProvider, TextBox textBox, string msg, ref bool result)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                return;
            }
            if (!ValidationHelper.IsIdCard(textBox.Text))
            {
                errorProvider.SetError(textBox, msg);
                result = false;
            }
        }
    }
}