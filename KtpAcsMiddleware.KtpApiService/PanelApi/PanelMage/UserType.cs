using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApi.PanelMage
{
  public   enum UserType
    {

        /// <summary>
        ///人员库类型- 黑名单
        /// </summary>
        [Description("黑名单")] Blacklist= 1,
        /// <summary>
        /// 人员库类型- 员工
        /// </summary>
        [Description("员工")] staff = 3,

        /// <summary>
        ///人员库类型- 访客
        /// </summary>
        [Description("访客")] Visitor = 4,
    }
}
