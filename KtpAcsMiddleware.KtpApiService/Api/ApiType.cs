using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.Api
{
    public enum ApiType
    {
        /// <summary>
        /// 调用KTP接口
        /// </summary>
        [Description("KTP接口")] KTP = 1,
        /// <summary>
        ///调用设备面板接口
        /// </summary>
        [Description("面板接口")] Panel = 2,
        /// <summary>
        ///调用app接口
        /// </summary>
        [Description("app接口")] App = 3,
        /// <summary>
        ///调用设备面板接口
        /// </summary>
        [Description("海清面板接口")] PanelHq = 4,
    }
}
