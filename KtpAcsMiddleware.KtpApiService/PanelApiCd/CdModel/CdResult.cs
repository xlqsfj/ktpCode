using KtpAcsMiddleware.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApiCd.CdModel
{
    public class CdResult
    {
        public string _msg { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string msg
        {
            get { return this._msg; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    this._msg = value;
                else
                    this._msg = value= FormatHelper.GetStringIntercept(value, "expDesc='","'") ?? value;
            }
        }

        /// <summary>
        ///1
        /// </summary>
        public int result { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool success { get; set; }
    }
}
