using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApiCd.CdModel
{
     public class PanelFaceResult
    {

        public List<PanelUserFaceInfo> data { get; set; }
        public int result { get; set; }
        public bool success { get; set; }
        public string msg { get; set; }



    }
    public class PanelUserFaceInfo
    {/// <summary>
    /// 头像id
    /// </summary>
        public string faceId { get; set; }
        /// <summary>
        /// 人脸识别头像64位
        /// </summary>
        public string feature { get; set; }
        public string featureKey { get; set; }
        /// <summary>
        /// ftp头像路径
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// 人脸用户id，保存的是我们userid
        /// </summary>
        public string personId { get; set; }
        public int type { get; set; }
    }
}
