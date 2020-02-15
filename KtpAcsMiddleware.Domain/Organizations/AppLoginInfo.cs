using System;

namespace KtpAcsMiddleware.Domain.Organizations
{
    public class AppLoginInfo
    {
        public static string UserId { get; set; }
        public static string UserName { get; set; }
        public static string LoginName { get; set; }
        public static DateTime LoginTime { get; set; }
    }
}