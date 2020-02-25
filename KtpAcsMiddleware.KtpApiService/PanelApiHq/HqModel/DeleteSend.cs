using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApiHq.HqModel
{
    public class DeleteSend
    {
        /// <summary>
        /// 
        /// </summary>
        public string _operator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserDelete info { get; set; }

    }

    public class UserDelete
    {
        /// <summary>
        /// 
        /// </summary>
        public int DeviceID { get; set; }

        /// <summary>
        /// 此次操作需要删除多少个 人员信息
        /// </summary>
        public int TotalNum { get; set; }

        /// <summary>
        /// 0: 用户自定义的 CustomizeID，1:设备数据库 LibID,2、PersonUUID
        /// </summary>
        public int IdType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<int> CustomizeID { get; set; }
        /// <summary>
        /// 删除全部默认1
        /// </summary>
        public int DefaltPerson { get; set; }

    }




}
