using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApiHq.HqModel
{
    public class HqResult
    {

        /// <summary>
        /// 
        /// </summary>
        public string _operator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Info info { get; set; }

        public int code { get; set; }

        public bool success
        {
            get { return success; }

            set
            {
                success = info.Result == "ok" ? true : false;
            }
        }

        public string mag { get; set; }
    }
    public class Info
    {
        /// <summary>
        /// 成功ok/失败Fail
        /// </summary>
        public string Result { get; set; }
        public int CustomizeID { get; set; }
        public List<PanelHqUserInfo> List { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 设备id
        /// </summary>
        public int DeviceID { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }

        public int PersonNum { get; set; }

  

    }
}
