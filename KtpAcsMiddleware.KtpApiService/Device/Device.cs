using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.Device
{
   public  class Device
    {
        /// <summary>
        /// 项目id
        /// </summary>
        public int proId { get; set; }
        /// <summary>
        /// 设备号
        /// </summary>
        public string deviceNo { get; set; }
        /// <summary>
        /// 设备ip
        /// </summary>
        public string deviceIp { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 是否进场方向 0否 1是
        /// </summary>
        public int  deviceIn { get; set; }
        /// <summary>
        /// 主键id 空为新增 否则为修改
        /// </summary>
       public int  id { get; set; }
        /// <summary>
        /// 在线状态 0离线 1在线
        /// </summary>
        public int  state { get; set;  }
       
    }
  
}
