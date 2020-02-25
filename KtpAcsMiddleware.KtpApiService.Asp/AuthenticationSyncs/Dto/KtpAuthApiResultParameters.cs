using System;

namespace KtpAcsMiddleware.KtpApiService.Asp.AuthenticationSyncs.Dto
{
    internal class KtpAuthApiResultParameters
    {
        /// <summary>
        ///     项目ID
        /// </summary>
        public int pro_id { get; set; }

        /// <summary>
        ///     用户ID
        /// </summary>
        public int user_id { get; set; }

        /// <summary>
        ///     打卡方式(KtpAuthenticationClockType)
        /// </summary>
        public int k_state { get; set; }

        /// <summary>
        ///     进出闸机识别人脸照片(七牛Url)
        /// </summary>
        public string k_pic { get; set; }

        /// <summary>
        ///     打卡时间(新增)
        /// </summary>
        public DateTime? clock_time { get; set; }

        /// <summary>
        ///     打卡经度(放空)
        /// </summary>
        public string k_lbsx { get; set; }

        /// <summary>
        ///     打卡纬度(放空)
        /// </summary>
        public string k_lbsy { get; set; }

        /// <summary>
        ///     范围(放空)
        /// </summary>
        public string k_xsd { get; set; }
    }
}