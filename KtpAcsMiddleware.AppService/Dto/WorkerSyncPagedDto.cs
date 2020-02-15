using System;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Serialization;

namespace KtpAcsMiddleware.AppService.Dto
{
    /// <summary>
    ///     工人同步详情Dto
    /// </summary>
    public class WorkerSyncPagedDto
    {
        /// <summary>
        ///     主键ID
        /// </summary>
        public string Id { get; set; }

        public string IdentityCode { get; set; }
        public string WorkerName { get; set; }
        public string Mobile { get; set; }
        public int ThirdPartyId { get; set; }
        public int TeamThirdPartyId { get; set; }
        public string TeamName { get; set; }

        /// <summary>
        ///     KtpApiSyncType
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        ///     SyncState
        /// </summary>
        public int Status { get; set; }

        public int? FeedbackCode { get; set; }
        public string Feedback { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifiedTime { get; set; }

        /// <summary>
        ///     是否已认证
        /// </summary>
        public bool IsAuthentication { get; set; }

        /***Extension*****************************************************************************/
        public string TypeText
        {
            get
            {
                if (Status == (int) KtpSyncState.NewAdd && FeedbackCode == null)
                {
                    return "无";
                }
                if (Type <= (int) KtpSyncType.PushEdit)
                {
                    return "推送保存";
                }
                return ((KtpSyncType) Type).ToEnumText();
            }
        }

        public string StateText
        {
            get
            {
                if (Status == (int) KtpSyncState.Success)
                {
                    return $"已{TypeText.Substring(0, 2)}";
                }
                if (Status == (int) KtpSyncState.Fail)
                {
                    return $"{TypeText.Substring(0, 2)}失败";
                }
                if ((KtpSyncState) Status == KtpSyncState.NewAdd && !IsAuthentication)
                {
                    return $"{((KtpSyncState) Status).ToEnumText()}(待认证)";
                }
                return ((KtpSyncState) Status).ToEnumText();
            }
        }
    }
}