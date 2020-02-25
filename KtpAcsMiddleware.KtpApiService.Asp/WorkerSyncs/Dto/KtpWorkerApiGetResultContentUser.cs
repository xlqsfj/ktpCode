using System;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs.Dto
{
    /// <summary>
    ///     根据班组和项目ID获取所有工人的返回值user_list对象
    /// </summary>
    public class KtpWorkerApiGetResultContentUser
    {
        /// <summary>
        ///     用户ID
        /// </summary>
        public int user_id { get; set; }

        /// <summary>
        ///     项目ID
        /// </summary>
        public int pro_id { get; set; }

        /// <summary>
        ///     部门(班组)ID
        /// </summary>
        public int po_id { get; set; }

        /// <summary>
        ///     工人姓名
        /// </summary>
        public string u_realname { get; set; }

        /// <summary>
        ///     手机号
        /// </summary>
        public string u_phone { get; set; }

        /// <summary>
        ///     工人身份证号
        /// </summary>
        public string u_sfz { get; set; }

        /// <summary>
        ///     性别(1男,2女)
        /// </summary>
        public int? u_sex { get; set; }

        /// <summary>
        ///     生日
        /// </summary>
        public string u_birthday { get; set; }

        /// <summary>
        ///     工人身份证照片:七牛URL
        /// </summary>
        public string u_sfzpic { get; set; }

        /// <summary>
        ///     工人录入人脸照片:七牛URL
        /// </summary>
        public string u_cert_pic { get; set; }

        /// <summary>
        ///     民族
        /// </summary>
        public string u_mz { get; set; }

        /// <summary>
        ///     发证机关
        /// </summary>
        public string u_org { get; set; }

        /// <summary>
        ///     住址
        /// </summary>
        public string u_address { get; set; }

        /// <summary>
        ///     身份证正面照片
        /// </summary>
        public string u_sfz_zpic { get; set; }

        /// <summary>
        ///     身份证反面照片
        /// </summary>
        public string u_sfz_fpic { get; set; }

        /// <summary>
        ///     身份证有效开始时间
        /// </summary>
        public string u_start_time { get; set; }

        /// <summary>
        ///     身份证到期时间
        /// </summary>
        public string u_expire_time { get; set; }

        /// <summary>
        ///     最后更新时间
        /// </summary>
        public DateTime? last_operation_time { get; set; }

        /// <summary>
        ///     工人状态:0=在场,4=离场
        /// </summary>
        public int worker_state { get; set; }

        /***Extension*****************************************************************************/

        /// <summary>
        ///     生日
        /// </summary>
        public DateTime Birthday
        {
            get { return FormatHelper.GetDateValueNoErro(u_birthday) ?? DateTime.Now; }
        }

        /// <summary>
        ///     身份证有效开始时间
        /// </summary>
        public DateTime ActivateTime
        {
            get { return FormatHelper.GetDateValueNoErro(u_start_time) ?? DateTime.Now; }
        }

        /// <summary>
        ///     身份证到期时间
        /// </summary>
        public DateTime InvalidTime
        {
            get { return FormatHelper.GetDateValueNoErro(u_expire_time) ?? DateTime.Now; }
        }
    }
}