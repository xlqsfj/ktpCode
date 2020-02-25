using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApi.PanelMage
{
    public enum MagType
    {

        /// <summary>
        ///返回消息类型 1: 成功 Succeed
        /// </summary>
        [Description("成功")] Succeed = 0,
        /// <summary>
        ///2返回消息类型 2: 通用错误 Common Error
        /// </summary>
        [Description("通用错误")] CommonError = 2,
        /// <summary>
        ///3: 参数非法 3：Invalid Arguments
        /// </summary>
        [Description("参数非法")] InvalidArguments = 3,
        /// <summary>
        ///返回消息类型4: 设备不支持 Not Supported
        /// </summary>
        [Description("设备不支持")] NotSupported = 4,
        /// <summary>
        ///返回消息类型 5： 用户状态异常
        /// </summary>
        [Description("用户状态异常")] userStatRerror = 5,
       
    }
}
