using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.WinForm.Api.Models
{
  public    enum LoadMagEnum
    {
        /// <summary>
        ///加载等待
        /// </summary>
        [Description("加载中，请稍等...")] Loading = 1,
        /// <summary>
        ///加载等待:添加中
        /// </summary>
        [Description("保存中，请稍等...")] Add = 2,
        /// <summary>
        ///加载等待:同步中
        /// </summary>
        [Description("同步中，请稍等...")] Syn =3,
        /// <summary>
        ///加载等待:删除中
        /// </summary>
        [Description("删除中，请稍等...")] Delete =4,
    }
}
