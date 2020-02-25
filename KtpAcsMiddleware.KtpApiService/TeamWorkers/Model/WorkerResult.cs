using KtpAcsMiddleware.KtpApiService.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.TeamWorkers
{
    public class WorkerResult
    {


        public List<Workers> data { get; set; }

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
        public bool success { get; set; }

    }
    /// <summary>
    /// 查询所有人员
    /// </summary>
    public class WorkerAllResult
    {


        public  Data data { get; set; }

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
        public bool success { get; set; }

    }

    public class WorkerDeleteResult
    {


        public string data { get; set; }

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
        public bool success { get; set; }

    }

    public class WorkerDeleteSend
    {


        /// <summary>
        /// 
        /// </summary>
        public int projectId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string teamId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string userId { get; set; }

    }


}
