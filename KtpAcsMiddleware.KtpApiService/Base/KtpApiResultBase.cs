namespace KtpAcsMiddleware.KtpApiService.Base
{
    internal class KtpApiResultBase
    {
        public KtpApiResultStatus Status { get; set; }

        public KtpApiResultStatus BusStatus { get; set; }
    }

    internal class KtpApiResultStatus
    {
        public int Code { get; set; }
        public string Msg { get; set; }
    }
}