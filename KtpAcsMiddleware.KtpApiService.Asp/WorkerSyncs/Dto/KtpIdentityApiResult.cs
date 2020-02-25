using KtpAcsMiddleware.KtpApiService.Asp.Base;

namespace KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs.Dto
{
    internal class KtpIdentityApiResult : KtpApiResultBase
    {
        public KtpIdentityApiResultParameters Parameters { get; set; }
        public KtpIdentityApiResultContent Content { get; set; }
    }

    internal class KtpIdentityApiResultParameters
    {
        public string u_sfz { get; set; }
    }

    internal class KtpIdentityApiResultContent
    {
        public decimal u_xyf { get; set; }
        public string u_jnf { get; set; }
    }
}