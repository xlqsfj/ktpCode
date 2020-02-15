using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console; //静态类Uing
namespace KtpAcsMiddleware.Infrastructure.Utilities
{
    /// <summary>
    /// 扩展方法
    /// </summary>
   public  static class ExtendMethod
    {

        public static string ConvertToString(this object s)
        {
            if (s == null)
            {
                return "";
            }
            else
            {
                return Convert.ToString(s);
            }
        }
        /// <summary>
        /// string 转34位
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Int32 ConvertToInt32(this string s)
        {
            int i = 0;
            if (s == null)
            {
                return 0;
            }
            else
            {
                int.TryParse(s, out i);
               
            }
            return i;
        }
    }
}
