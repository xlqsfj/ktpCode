namespace KtpAcsMiddleware.KtpApiService.Asp.Base
{
    internal class KtpApiResultBase
    {
        public KtpApiResultStatus Status { get; set; }

        public KtpApiResultStatus BusStatus { get; set; }
        //public object Content { get; set; }
        //public object Parameters { get; set; }
    }

    internal class KtpApiResultStatus
    {
        public int Code { get; set; }
        public string Msg { get; set; }
    }
}