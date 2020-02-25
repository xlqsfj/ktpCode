using System;

namespace KtpAcsMiddleware.KtpApiService.Asp.TeamSyncs.Dto
{
    /// <summary>
    ///     根据项目ID获取所有班组的返回值po_list对象
    /// </summary>
    public class KtpTeamGetApiResultContentPo
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

        /// <summary>
        ///     最后更新时间
        /// </summary>
        public DateTime? last_operation_time { get; set; }
    }
}