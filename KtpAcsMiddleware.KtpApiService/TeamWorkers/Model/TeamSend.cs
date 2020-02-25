using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.TeamWorkers
{


    public class DataItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string organName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? sectionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int state { get; set; }
      
        public long createTime { get; set; }
       
        /// <summary>
        /// 项目id
        /// </summary>
        public int uproid { get; set; }
        /// <summary>
        /// 班组工种类型
        /// </summary>
        public int teamWorkType { get; set; }


        /// <summary>
        /// 姓名  
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string identityNum { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string phoneNum { get; set; }
    }

    public class TeamSend
    {
        /// <summary>
        /// 
        /// </summary>
        public List<DataItem> data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string success { get; set; }
    }
}

