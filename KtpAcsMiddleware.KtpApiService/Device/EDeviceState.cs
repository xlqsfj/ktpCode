using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.Device
{
    public enum EDeviceState
    {
        /// <summary>
        ///连接正常
        /// </summary>
        [Description("是")] Yes,
        /// <summary>
        ///连接不正常
        /// </summary>
        [Description("否")] NO

    }
}
