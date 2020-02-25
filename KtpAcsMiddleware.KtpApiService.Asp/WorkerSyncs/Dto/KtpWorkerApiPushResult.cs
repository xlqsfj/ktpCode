using KtpAcsMiddleware.KtpApiService.Asp.Base;

namespace KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs.Dto
{
    /// <summary>
    ///     更新和添加工人产生的返回值对象
    /// </summary>
    internal class KtpWorkerApiPushResult : KtpApiResultBase
    {
        public KtpWorkerApiPushResultParameters Parameters { get; set; }
        public KtpWorkerSetApiResultContent Content { get; set; }
    }

    internal class KtpWorkerSetApiResultContent
    {
        public int user_id { get; set; }
    }
}