using KtpAcsMiddleware.KtpApiService.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.Device
{
    public class DeviceResult
    {

        /// <summary>
        /// 
        /// </summary>
        public int result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ContentItem> data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
    }

    public class DeviceDeleteResult
    {

        /// <summary>
        /// 
        /// </summary>
        public int result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
    }


    public class ContentItem
    {
        /// <summary>
        /// 设备表主键ID
        /// </summary>
        public int id { get; set; }
        ///// <summary>
        ///// 关联项目ID
        ///// </summary>
        //public int projectId { get; set; }
        /// <summary>
        /// 设备号
        /// </summary>
        public string machineNum { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string deviceIp { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string description { get; set; }
        /// <summary>
        ///是否进场方向 0否 1是
        /// </summary>
        private String _deviceIn;

        public String deviceIn

        {

            get { return _deviceIn; }

            set

            {


                _deviceIn= value == "1" ? "进口": "出口";

            }

        }
        /// <summary>
        /// 设备数量
        /// </summary>
        public int panelCount { get; set; }
        /// <summary>
        /// 设备是否连接 0否1是
        /// </summary>
        public string  panelIsConn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string isNetwork { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //public string state { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string createTime { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string updateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public int isdel { get; set; }
    }


}

