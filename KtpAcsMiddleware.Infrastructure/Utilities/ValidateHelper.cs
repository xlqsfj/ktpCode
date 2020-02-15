namespace KtpAcsMiddleware.Infrastructure.Utilities
{
    using System;
    using System.Text.RegularExpressions;

    public class ValidateHelper
    {
        private static Regex RegCHZN = new Regex("[一-龥]");
        private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
        private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$");
        private static Regex RegEmail = new Regex(@"^[\w-]+@[\w-]+\.(com|net|org|edu|mil|tv|biz|info)$");
        private static Regex RegMobilePhone = new Regex("^13|15|18[0-9]{9}$");
        private static Regex RegMoney = new Regex("^[0-9]+|[0-9]+[.]?[0-9]+$");
        private static Regex RegNumber = new Regex("^[0-9]+$");
        private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
        private static Regex RegSend = new Regex("[0-9]{1}([0-9]+){5}");
        private static Regex RegTell = new Regex("^(([0-9]{3,4}-)|[0-9]{3.4}-)?[0-9]{7,8}$");
        private static Regex RegUrl = new Regex(@"^[a-zA-z]+://(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?|[a-zA-z]+://((?:(?:25[0-5]|2[0-4]\d|[01]?\d?\d)\.){3}(?:25[0-5]|2[0-4]\d|[01]?\d?\d))$");

        public static bool IsDateTime(string inputData)
        {
            try
            {
                Convert.ToDateTime(inputData);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsDecimal(string inputData)
        {
            return RegDecimal.Match(inputData).Success;
        }

        public static bool IsDecimalSign(string inputData)
        {
            return RegDecimalSign.Match(inputData).Success;
        }

        public static bool IsEmail(string inputData)
        {
            return RegEmail.Match(inputData).Success;
        }

        public static bool IsHasCHZN(string inputData)
        {
            return RegCHZN.Match(inputData).Success;
        }

        public static bool IsMobilePhone(string inputDate)
        {
            return RegMobilePhone.Match(inputDate).Success;
        }

        public static bool IsMoney(string inputDate)
        {
            return RegMoney.Match(inputDate).Success;
        }

        public static bool IsNumber(string inputData)
        {
            return (!string.IsNullOrEmpty(inputData) && RegNumber.Match(inputData).Success);
        }

        public static bool IsNumberSign(string inputData)
        {
            return RegNumberSign.Match(inputData).Success;
        }

        public static bool IsPhone(string inputDate)
        {
            return (!string.IsNullOrEmpty(inputDate) && RegTell.Match(inputDate).Success);
        }

        public static bool IsSend(string inputDate)
        {
            return (!string.IsNullOrEmpty(inputDate) && RegSend.Match(inputDate).Success);
        }

        public static bool IsUrl(string inputDate)
        {
            return RegUrl.Match(inputDate).Success;
        }
    }
}

