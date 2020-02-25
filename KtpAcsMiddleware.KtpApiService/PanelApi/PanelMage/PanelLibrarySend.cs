using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApi
{
    public class PanelLibrarySend
    {
        public class LibListItem
        {
            /// <summary>
            /// 库 ID，
            ///Post 方法不用带，
            ///Get/Put 方法必带。
            /// </summary>
            public int  ID { get; set; }
            /// <summary>
            ///人员库类型
            ///0: 默认无效值;
            ///1：黑名单
            ///2:  灰名单/陌生人
            ///3：员工	4: 访客Put 方法不用带Get/Post 方法必带
            /// </summary>
            public int  Type { get; set; }
            /// <summary>
            /// 库中人脸照片总数，即有多少张人脸照片/特征;
            ///Get 方法时必带
            /// </summary>
            public int  FaceNum { get; set; }
            /// <summary>
            /// 库中人员成员的总数,即有多少个不同的 FaceID
            ///  注：如果一个人有多个底图， 此处为底图个数的总和。无底图人员，占用一个成员名额。
            //Get 方法时必带。
            /// </summary>
            public int  MemberNum { get; set; }
            /// <summary>
            /// 库信息的最后修改时间 (Unix 时间戳)
            /// </summary>
            public long  LastChange { get; set; }
            /// <summary>
            /// 库名字
            /// </summary>
            public string Name { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<LibListItem> LibList { get; set; }
    }
}
