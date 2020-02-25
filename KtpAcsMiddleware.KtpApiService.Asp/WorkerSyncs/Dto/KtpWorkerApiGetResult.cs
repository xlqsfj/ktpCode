using System.Collections.Generic;
using KtpAcsMiddleware.KtpApiService.Asp.Base;

namespace KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs.Dto
{
    internal class KtpWorkerApiGetResult : KtpApiResultBase
    {
        public KtpWorkerGetApiResultParameters Parameters { get; set; }
        public KtpWorkerGetApiResultContent Content { get; set; }
    }

    internal class KtpWorkerGetApiResultParameters
    {
        /// <summary>
        ///     项目ID
        /// </summary>
        public int pro_id { get; set; }

        /// <summary>
        ///     部门(班组)ID
        /// </summary>
        public int po_id { get; set; }
    }

    internal class KtpWorkerGetApiResultContent
    {
        public IList<KtpWorkerApiGetResultContentUser> user_list { get; set; }
    }
}