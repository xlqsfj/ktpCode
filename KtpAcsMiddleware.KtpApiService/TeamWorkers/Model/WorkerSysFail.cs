using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.TeamWorkers.Model
{
   public static class WorkSysFail
    {
        /// <summary>
        /// 查询所有人员信息
        /// </summary>
        public static List<WokersList> list = new List<WokersList>();
        /// <summary>
        /// ip是否连接
        /// </summary>
        public static  List<WorkAddInfo> workAdd = new List<WorkAddInfo>();
        /// <summary>
        ///多线程执行添加到面板
        /// </summary>
        public static Dictionary<string, string> dicAddMag = new Dictionary<string, string>();
        public static Dictionary<bool, string>  dicWorkadd = new Dictionary<bool, string>();

        /// <summary>
        /// 删除当前编辑错误人员的信息
        /// </summary>
        /// <param name="uid">用户id</param>
        public static void DeleteWorker(string uid) {

            var lists = list.Where(a => a.userId != uid).ToList();
             list = lists;
        }
        /// <summary>
        /// 删除当前编辑错误人员的信息
        /// </summary>
        /// <param name="uid">用户id</param>
        public static void DeleteDeviceInfo(string deviceIp)
        {

            var lists = workAdd.Where(a => a.deviceIp != deviceIp).ToList();
            workAdd = lists;
        }
    }

    public  class WorkAddInfo
    {

        /// <summary>
        /// 设备号
        /// </summary>
        public string deviceNo { get; set; }
        /// <summary>
        /// 设备ip
        /// </summary>
        public string deviceIp { get; set; }
        /// <summary>
        /// 添加信息
        /// </summary>
        public string magAdd { get; set; }
        /// <summary>
        /// 是否进场方向 0否 1是
        /// </summary>
        public string deviceIn { get; set; }
        /// <summary>
        /// 面板是否连接
        /// </summary>
        public bool isConn { get; set; }

    }
}
