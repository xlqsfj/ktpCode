using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.TeamWorkers.Model
{
    public class WorkerAuthResult
    {

        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }

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
        public List<ListItem> list { get; set; }
    }

    public class ListItem
    {
        /// <summary>
        /// 打卡时间
        /// </summary>
        public string checkTime { get; set; }

        /// <summary>
        /// 打卡类型 1闸机进 2闸机出
        /// </summary>
        private string _checkType { get; set; }


        /// <summary>
        /// 性别 1男2 女
        /// </summary>
        public string checkType
        {
            get { return _checkType; }
            set
            {



                switch (value)
                {
                    case "1":
                        _checkType = "闸机进";
                        break;
                    case "2":
                        _checkType = "闸机出";
                        break;
                    case "3":
                        _checkType = "手机上班";
                        break;
                    case "4":
                        _checkType = "手机下班";
                        break;
                    default:
                        _checkType = "其他"; break;
                }
            }
        }

        /// <summary>
        /// 证件号
        /// </summary>
        public string identityNum { get; set; }

        /// <summary>
        /// 设备号
        /// </summary>
        public int machineNum { get; set; }

        /// <summary>
        /// 打卡图片
        /// </summary>
        public string photoUrl { get; set; }

        /// <summary>
        /// 相似度
        /// </summary>
        public int? similarity { get; set; }

        /// <summary>
        /// 班组名
        /// </summary>
        public string teamName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string userName { get; set; }
        
        public string poId { get; set; }
        public string userId { get; set; }

        public int recordId { get; set; }

    }
}
