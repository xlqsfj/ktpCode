using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService
{
    public enum EPanelApiType
    {
        /// <summary>
        /// 宇视
        /// </summary>
        [Description("宇视")] yushi,
        /// <summary>
        ///赤道
        /// </summary>
        [Description("赤道")] chidao,
        /// <summary>
        ///海清                   
        /// </summary>
        [Description("海清")] haiqing
    }
}
