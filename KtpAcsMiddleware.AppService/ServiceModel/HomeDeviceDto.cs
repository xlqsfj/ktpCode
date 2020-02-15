using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.AppService.ServiceModel
{
  public  class HomeDeviceDto
    {

        public string Id { get; set; }

        public string Code { get; set; }
        /// <summary>
        /// ip地址
        /// </summary>
        public string IpAddress { get; set; }

        public int IdentityId { get; set; }
        /// <summary>
        /// 是否进出场
        /// </summary>
        public string IsCheckIn { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int DCount { get; set; }

        ///最近返回消息
        public string currentMag { get; set; }
        /// <summary>
        /// 设备状态
        /// </summary>
        public string DState { get; set; }

    }
}
