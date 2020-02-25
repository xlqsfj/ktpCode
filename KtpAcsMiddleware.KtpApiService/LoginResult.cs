using KtpAcsMiddleware.KtpApiService.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService
{
  public  class LoginResult: Result
    {
      new   public Login data { get; set; }
    }
    public class Login
    {
        /// <summary>
        /// 项目id
        /// </summary>
        public int proId { get; set; }

        /// <summary>
        /// 广东开太平信息科技有限责任公司
        /// </summary>
        public string proName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string token { get; set; }

    }

}
