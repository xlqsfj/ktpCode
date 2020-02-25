using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApiCd.CdModel
{
   public class PanelUserInfo
    { /// <summary>
      /// 创建时间
      /// </summary>
        public long createTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int faceAndCardPermission { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int facePermission { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int iDPermission { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int idCardPermission { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string idcardNum { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 删除返回有效id
        /// </summary>
        public string effective { get; set; }
        /// <summary>
        /// 删除返回无效id
        /// </summary>
        public string invalid { get; set; }
    }
}
