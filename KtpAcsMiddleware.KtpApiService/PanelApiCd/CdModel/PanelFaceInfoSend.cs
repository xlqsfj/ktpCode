using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApiCd.CdModel
{
   public  class PanelFaceInfoSend:Send
    {
        /// <summary>
        /// 不加头部，如：data:image/jpg;base64
        /// </summary>
        public string imgBase64 { get; set; }
        /// <summary>
        /// 若faceId传入内容为空，则系统会自动生成faceId并在照片创建成功后返回
        /// </summary>
        public int faceId { get; set; }
        /// <summary>
        /// 用于标识该照片属于某个人员id
        ///必须先创建人，才能添加照片
        /// </summary>
        public int personId { get; set; }
    }
}
