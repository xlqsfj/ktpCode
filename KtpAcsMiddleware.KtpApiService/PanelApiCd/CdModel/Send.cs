using KtpAcsMiddleware.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApiCd
{
    public class Send
    {
        /// <summary>
        /// 接口安全校验秘钥
        /// </summary>
        public string pass
        {
            get
            {
                return ConfigHelper.CdPassPwd;
            }
        }
        /// <summary>
        /// -1、全部删除或全部查询，指定id查询当前id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 人员id
        /// </summary>
        public int personId { get; set; }
        /// <summary>
        /// 人员时间截止
        /// </summary>
        public string time{get; set;}

    }
}
