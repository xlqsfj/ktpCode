using KtpAcsMiddleware.KtpApiService.PanelApi.PanelMage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.Api
{
    public class Result
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
        public Data data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
        public string ip { get; set; }
        public string imgBase64 { get; set; }
        public int  userId { get; set; }
        public int usex { get; set; }
        public string urealname { get; set; }
        public string uname { get; set; }
        public string usfz { get; set; }
        //时间截止
        public string planExitTime { get; set; }
    }
    public class ResultNoData
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


    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 是否需要验证 false:需要,true:不需要
        /// </summary>
        public bool verificationFlag { get; set; }

    }



}
