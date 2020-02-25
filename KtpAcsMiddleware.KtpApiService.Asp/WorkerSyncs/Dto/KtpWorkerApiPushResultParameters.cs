using System;

namespace KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs.Dto
{
    /// <summary>
    ///     新增和编辑工人的参数
    /// </summary>
    internal class KtpWorkerApiPushResultParameters
    {
        /// <summary>
        ///     项目ID
        /// </summary>
        public int pro_id { get; set; }

        /// <summary>
        ///     工人身份证照片:七牛URL
        /// </summary>
        public string u_sfzpic { get; set; }

        /// <summary>
        ///     工人身份证号
        /// </summary>
        public string u_sfz { get; set; }

        /// <summary>
        ///     工人姓名
        /// </summary>
        public string u_realname { get; set; }

        /// <summary>
        ///     部门(班组)ID
        /// </summary>
        public int po_id { get; set; }

        /// <summary>
        ///     手机号
        /// </summary>
        public string u_name { get; set; }

        /// <summary>
        ///     性别(1男,2女)
        /// </summary>
        public int? u_sex { get; set; }

        /// <summary>
        ///     生日
        /// </summary>
        public DateTime? u_birthday { get; set; }

        ///// <summary>
        ///// 工人身份证照片:七牛URL
        ///// </summary>
        //public string u_sfzpic { get; set; }

        /// <summary>
        ///     工人录入人脸照片:七牛URL
        /// </summary>
        public string u_cert_pic { get; set; }

        /// <summary>
        ///     民族
        /// </summary>
        public string u_mz { get; set; }

        ///// <summary>
        /////     籍贯==去掉
        ///// </summary>
        //public string u_jiguan { get; set; }

        /// <summary>
        ///     开户行银行名称（去除）
        /// </summary>
        public string u_bank { get; set; }

        /// <summary>
        ///     开户行银行卡号（去除）
        /// </summary>
        public string u_bankcard { get; set; }

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
        ///     发证机关
        /// </summary>
        public string u_org { get; set; }

        /// <summary>
        ///     身份证有效开始时间
        /// </summary>
        public DateTime? u_start_time { get; set; }

        /// <summary>
        ///     身份证到期时间
        /// </summary>
        public DateTime? u_expire_time { get; set; }
    }
}