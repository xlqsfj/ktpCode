using System.Collections.Generic;
using KtpAcsMiddleware.KtpApiService.Asp.Base;

namespace KtpAcsMiddleware.KtpApiService.Asp.TeamSyncs.Dto
{
    /// <summary>
    ///     根据项目ID获取所有班组的返回值对象
    /// </summary>
    internal class KtpTeamGetApiResult : KtpApiResultBase
    {
        //public KtpTeamGetApiResultParameters Parameters { get; set; }
        public KtpTeamGetApiResultContent Content { get; set; }
    }

    internal class KtpTeamGetApiResultParameters
    {
        /// <summary>
        ///     项目ID
        /// </summary>
        public int pro_id { get; set; }
    }

    internal class KtpTeamGetApiResultContent
    {
        public IList<KtpTeamGetApiResultContentPo> po_list { get; set; }
    }
}