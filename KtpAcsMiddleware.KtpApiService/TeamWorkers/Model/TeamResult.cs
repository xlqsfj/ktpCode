using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.TeamWorkers
{


    [Serializable]
    public class Team
    {


        /// <summary>
        /// 本地id
        /// </summary>
        public int localId { get; set; }
        /// <summary>
        /// 是否同步
        /// </summary>
        public bool isSyn { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string organName { get; set; }
        /// <summary>
        ///部门ID
        /// </summary>
        public int? sectionId { get; set; }
        /// <summary>
        ///  1、项目部 2、施工班组
        /// </summary>
        public int state { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createTime { get; set; }

    
        /// <summary>
        /// 项目id
        /// </summary>
        public int uproid { get; set; }
        /// <summary>
        /// 班组工种类型
        /// </summary>
        public int teamWorkType { get; set; }
        /// <summary>
        /// ktp返回的id
        /// </summary>
        public int? ktpTid { get; set; }

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
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool isDel { get; set; }
    }

    public class TeamResult
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Team> data { get; set; }
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
    public class TeamAddResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string  data { get; set; }
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

