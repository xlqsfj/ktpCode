using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApi.PanelMage
{
 public   enum WorkerSex
    {

        /// 成员性别
        ///0：未知	1：男性
        ///2：女性	9：未说明
        /// <summary>
        /// 0：未知	
        /// </summary>
        [Description("未知")] Unknown = 0,
        /// <summary>
        /// 1：男性
        /// </summary>
        [Description("男性")] Man=1,
        /// <summary>
        /// 2：女性
        /// </summary>
        [Description("女性")] Lady=2,
        /// <summary>
        /// 9：未说明
        /// </summary>
        [Description("未说明")] Unstated = 9,
    }
}
