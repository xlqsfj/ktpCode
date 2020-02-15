using System;

namespace KtpAcsMiddleware.Domain.Dto
{
    /// <summary>
    ///     工人同步信息
    /// </summary>
    public class WorkerSyncDto
    {
        public string Id { get; set; }
        public int ThirdPartyId { get; set; }
        public int TeamThirdPartyId { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public int? FeedbackCode { get; set; }
        public string Feedback { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifiedTime { get; set; }
    }
}