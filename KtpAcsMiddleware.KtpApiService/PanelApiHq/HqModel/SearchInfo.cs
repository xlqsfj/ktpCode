using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApiHq.HqModel
{
    public class SearchInfo
    {
        /// <summary>
        /// 设备id
        /// </summary>
        public int DeviceID { get; set; }

        /// <summary>
        /// 0、白名单 1、黑名单
        /// </summary>
        public int PersonType { get { return 0; } set { } }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string BeginTime { get { return "2019-11-27T00:00:00"; } set { } }

        /// <summary>
        ///结束时间
        /// </summary>
        public string EndTime { get { return "2039-12-03T23:59:59"; } set { } }

        /// <summary>
        /// 2、不分男女
        /// </summary>
        public int Gender { get { return 2; } set { } }

        /// <summary>
        /// 
        /// </summary>
        public string Age { get { return "0-100"; } set{ } }

        /// <summary>
        /// 
        /// </summary>
        public int MjCardNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        public string CustomizeID { get; set; }

        /// <summary>
        /// 0:CustomizeID1:UUID 2:数据库ID
        /// </summary>
        public int SearchType { get; set; }

        /// <summary>
        /// SearchID、UUID内容或者数据库ID
        /// </summary>
        public string SearchID { get; set; }

        /// <summary>
        /// 是否包含图片信息
        /// </summary>
        public int Picture { get; set; }





    }
}
