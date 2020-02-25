using KtpAcsMiddleware.KtpApiService.Asp.Base;

namespace KtpAcsMiddleware.KtpApiService.Asp.TeamSyncs.Dto
{
    /// <summary>
    ///     班组更新和删除产生的返回值对象
    /// </summary>
    internal class KtpTeamPushApiResult : KtpApiResultBase
    {
        public KtpTeamSetApiResultParameters Parameters { get; set; }
        public KtpTeamSetApiResultContent Content { get; set; }
    }

    internal class KtpTeamSetApiResultParameters
    {
        /// <summary>
        ///     项目ID
        /// </summary>
        public int pro_id { get; set; }

        /// <summary>
        ///     班组ID
        /// </summary>
        public int po_id { get; set; }

        /// <summary>
        ///     工种ID=TeamWorkType.Value
        /// </summary>
        public int po_gzid { get; set; }

        /// <summary>
        ///     班组名称
        /// </summary>
        public string po_name { get; set; }
    }

    internal class KtpTeamSetApiResultContent
    {
        /// <summary>
        ///     班组ID
        /// </summary>
        public int po_id { get; set; }
    }
}