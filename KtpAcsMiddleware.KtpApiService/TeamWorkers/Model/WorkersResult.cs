using KtpAcsMiddleware.KtpApiService.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.TeamWorkers
{
    public class WorkersResult
    {


        public Data data { get; set; }

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
    public class Data
    {

        /// <summary>
        /// 总数
        /// </summary>
        public int perTotal { get; set; }
        //已认证人数
        public int certTotal { get; set; }
        //未认证人数
        public int unCertTotal { get; set; }

        public int total { get; set; }
        /// <summary>
        /// 查询所有人员信息
        /// </summary>
        public List<WokersList> list { get; set; }
    }
    public class WokersList
    {
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


        private string _sex;
        /// <summary>
        /// 性别 1男2 女
        /// </summary>
        public string sex
        {
            get { return _sex; }
            set
            {

                _sex = value == "1" ? "男" : "女";
            }
        }

        /// <summary>
        /// 民族
        /// </summary>
        public string nation { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// 认证状态 1未认证 2已认证
        /// </summary>
        public string _certificationStatus;
        /// <summary>
        /// 同步时失败原因
        /// </summary>
        public string reason { get; set; }


        /// <summary>
        /// 是否认证
        /// </summary>
        public string certificationStatus
        {

            get { return _certificationStatus; }
            set
            {

                _certificationStatus = value == "1" ? "未认证" : "已认证";
            }
        }

        /// <summary>
        /// 劳务孵化中心
        /// </summary>
        public string teamName { get; set; }

        /// <summary>
        /// 班组ID
        /// </summary>
        public string teamId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string userId { get; set; }

        public bool isSyn { get; set; }
        /// <summary>
        /// 记录ID
        /// </summary>
        public int recordId { get; set; }
        public string ktpMag { get; set; }

    }
}
