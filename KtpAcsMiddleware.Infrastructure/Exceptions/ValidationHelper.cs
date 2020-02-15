using System;
using System.Text.RegularExpressions;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Infrastructure.Exceptions
{
    public class ValidationHelper
    {
        /// <summary>
        ///     用户登录名验证(字母数字下划线)
        /// </summary>
        public static bool IsLoginName(string value)
        {
            return Regex.IsMatch(value, @"^[a-zA-Z_][A-Za-z0-9_]*$");
        }

        /// <summary>
        ///     验证电话号码
        /// </summary>
        public static bool IsTelephone(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            return Regex.IsMatch(value, @"^(\d{3,4}-)?\d{6,8}$");
        }

        /// <summary>
        ///     验证手机号码
        /// </summary>
        public static bool IsMobile(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            return Regex.IsMatch(value, @"^(13|14|15|16|17|18|19)\d{9}$");
        }

        /// <summary>
        ///     验证身份证号
        /// </summary>
        public static bool IsIDcard(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            return Regex.IsMatch(value, @"(^\d{18}$)|(^\d{15}$)");
        }

        /// <summary>
        ///     验证输入为数字
        /// </summary>
        public static bool IsNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            return Regex.IsMatch(value, @"^[0-9]*$");
        }

        /// <summary>
        ///     验证邮编
        /// </summary>
        public static bool IsPostalcode(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            return Regex.IsMatch(value, @"^\d{6}$");
        }

        /// <summary>
        ///     验证邮箱
        /// </summary>
        public static bool IsMail(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            var r = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
            return r.IsMatch(value);
        }

        /// <summary>
        ///     验证IP地址
        /// </summary>
        public static bool IsIpAddress(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            return Regex.IsMatch(value, "^((2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.){3}(2[0-4]\\d|25[0-5]|[01]?\\d\\d?)$");
        }

        /// <summary>
        ///     身份证号验证(18位或15位)
        /// </summary>
        public static bool IsIdCard(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                    return false;
                if (value.Length == 15)
                {
                    return IsIdCard15(value);
                }
                if (value.Length == 18)
                {
                    return IsIdCard18(value);
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return false;
            }
        }

        /// <summary>
        ///     身份证号验证(18位)
        /// </summary>
        private static bool IsIdCard18(string value)
        {
            long n = 0;
            if (long.TryParse(value.Remove(17), out n) == false || n < Math.Pow(10, 16) ||
                long.TryParse(value.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false; //数字验证
            }

            var address =
                "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(value.Remove(2), StringComparison.Ordinal) == -1)
            {
                return false; //省份验证
            }
            var birth = value.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time;
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false; //生日验证
            }
            var arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            var wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            var ai = value.Remove(17).ToCharArray();
            var sum = 0;
            for (var i = 0; i < 17; i++)
            {
                sum += int.Parse(wi[i]) * int.Parse(ai[i].ToString());
            }
            var y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != value.Substring(17, 1).ToLower())
            {
                return false; //校验码验证
            }
            return true; //符合GB11643-1999标准
        }

        /// <summary>
        ///     身份证号验证(15位)
        /// </summary>
        private static bool IsIdCard15(string value)

        {
            long n = 0;
            if (long.TryParse(value, out n) == false || n < Math.Pow(10, 14))

            {
                return false; //数字验证
            }

            var address =
                "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(value.Remove(2), StringComparison.Ordinal) == -1)
            {
                return false; //省份验证
            }
            var birth = value.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time;
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false; //生日验证
            }
            return true; //符合15位身份证标准
        }
    }
}