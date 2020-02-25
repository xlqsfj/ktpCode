using KtpAcsMiddleware.KtpApiService.Asp.Base;

namespace KtpAcsMiddleware.KtpApiService.Asp.AuthenticationSyncs.Dto
{
    internal class KtpAuthApiResult : KtpApiResultBase
    {
        public KtpAuthApiResultParameters Parameters { get; set; }
        public KtpAuthAspApiResultContent Content { get; set; }
    }

    internal class KtpAuthAspApiResultContent
    {
        public string msg { get; set; }
    }
}