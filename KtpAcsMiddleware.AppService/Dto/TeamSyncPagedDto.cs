using System;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Serialization;

namespace KtpAcsMiddleware.AppService.Dto
{
    /// <summary>
    ///     班组同步详情Dto
    /// </summary>
    public class TeamSyncPagedDto
    {
        /// <summary>
        ///     (Team)主键ID
        /// </summary>
        public string Id { get; set; }

        public int ThirdPartyId { get; set; }

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
        public string WorkTypeName { get; set; }
        public string TeamName { get; set; }
        public DateTime TeamModifiedTime { get; set; }

        /***Extension*****************************************************************************/
        public string TypeText
        {
            get
            {
                if (Status == (int) KtpSyncState.NewAdd && FeedbackCode == null)
                {
                    return "无";
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
                return ((KtpSyncState) Status).ToEnumText();
            }
        }
    }
}