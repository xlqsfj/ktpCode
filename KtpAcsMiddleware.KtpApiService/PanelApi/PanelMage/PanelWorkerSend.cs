using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApi
{

    /// <summary>
    /// 面板新增人员信息
    /// </summary>
  public  class PanelWorkerSend
    {

        /// <summary>
        ///人员库人员个数
        ///批量单次最多 6 个
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 人员信息
        /// </summary>
        public List<PersonInfoListItem> PersonInfoList { get; set; }


        public class TimeTemplate
        {
            /// <summary>
            /// 时间模板生效起始时间(unix 时间戳)
           /// 若未配置，填写 0
            /// </summary>
            public int BeginTime { get; set; }

            /// <summary>
            /// 时间模板生效结束时间(unix 时间戳)
           ///  若 未 配 置 ， 填 写
          ///4294967295(0xFFFFFFFF)
            /// </summary>
            public long EndTime { get; set; }

            /// <summary>
            /// 时间模板索引
            ///若未配置，填写 0；
            /// </summary>
            public int Index { get; set; }

        }



        public class IdentificationListItem
        {
            /// <summary>
            /// 证件类型
             ///0:身份证	1:IC 卡
             ///99:其他
            /// </summary>
            public int Type { get; set; }

            /// <summary>
            /// 证件号，
            /// 范围:[1, 20]
            /// </summary>
            public string Number { get; set; }

        }



        public class ImageListItem
        {
            /// <summary>
            /// 
            /// </summary>
            public int? FaceID { get; set; }

            /// <summary>
            /// 文件名称，
            ///  范围[1, 16]。
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 文件大小，单位:字节。范围:[0, 1M(1048576)]长度
            /// </summary>
            public int Size { get; set; }

            /// <summary>
            /// 文件Base64 编码数据。
            /// </summary>
            public string Data { get; set; }

        }


        /// <summary>
        /// 
        /// </summary>
        public class PersonInfoListItem
        {
            /// <summary>
            /// 人员 ID
            /// </summary>
            public int? PersonID { get; set; }

            /// <summary>
            /// 人员信息最后修改时间 (Unix 时间戳)
            /// </summary>
            public long LastChange { get; set; }

            /// <summary>
            /// 人员名字
            /// </summary>
            public string PersonName { get; set; }

            /// <summary>
            /// 成员性别
           ///0：未知	1：男性
           ///2：女性	9：未说明
            /// </summary>
            public int Gender { get; set; }

            /// <summary>
            /// 时间模板相关信息，
            /// </summary>
            public TimeTemplate TimeTemplate { get; set; }

            /// <summary>
            /// 证件信息个数范围:[0, 2]
            /// 注：PTS 当前仅支持一个
            /// </summary>
            public int IdentificationNum { get; set; }

            /// <summary>
            /// 成员证件信息
            /// </summary>
            public List<IdentificationListItem> IdentificationList { get; set; }

            /// <summary>
            /// 人脸图片个数
            /// </summary>
            public int ImageNum { get; set; }

            /// <summary>
            /// 人脸图片信息列表.
            /// </summary>
            public List<ImageListItem> ImageList { get; set; }

        }




     

    }
}
