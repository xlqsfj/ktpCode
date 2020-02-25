using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApiHq.HqModel
{
    public class PanelPersonSend
    {


        /// <summary>
        /// 操作
        /// </summary>
        public string _operator { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        public PanelHqUserInfo info { get; set; }

        /// <summary>
        /// base64图片
        /// </summary>
        public string picinfo { get; set; }


    }
}

