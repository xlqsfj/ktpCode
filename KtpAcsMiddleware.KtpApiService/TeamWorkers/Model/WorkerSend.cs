using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.TeamWorkers
{
   public  class WorkerSend
    {

        /// <summary>
        /// 认证状态 1已认证 2未认证
        /// </summary>
        public string  certificationStatus { get; set; }
        /// <summary>
        /// 模糊搜索关键字
        /// </summary>
        public string keyWord { get; set; }
        /// <summary>
        /// 当前页码值
        /// </summary>
        public int pageNum { get; set; }
        /// <summary>
        /// 每页行数
        /// </summary>
        public int pageSize { get; set; }
        /// <summary>
        /// 项目ID
        /// </summary>
        public int projectId { get; set; }
        /// <summary>
        /// 班组id
        /// </summary>
        public int? teamId { get; set; }
        /// <summary>
        ///删除状态4,0默认
        /// </summary>
        public int popState { get; set; }

        //开始考勤时间
        public string startTime { get; set; }
        //结束考勤时间
        public string endTime { get; set; }
    }
}
