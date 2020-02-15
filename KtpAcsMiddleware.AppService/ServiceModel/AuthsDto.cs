using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Domain.WorkerAuths;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.AppService.ServiceModel
{
   public class AuthsDto
    {

        /// <summary>
        ///     主键ID
        /// </summary>
        public string Id { get; set; }

        public string WorkerId { get; set; }

        public string WorkerName { get; set; }
        public string IdentityCode { get; set; }
        public string DeviceCode { get; set; }
        public string TeamName { get; set; }

        /// <summary>
        ///     AuthenticationClockType
        /// </summary>
        public int? ClockType { get; set; }

        /// <summary>
        ///     认证时间戳
        /// </summary>
        public string AuthTimeStamp { get; set; }

        /// <summary>
        ///     对应设备认证接口result属性:0=未通过,1=通过
        /// </summary>
        public int ClockState { get; set; }

        /// <summary>
        ///     SyncState
        /// </summary>
        public int State { get; set; }

        public int? FeedbackCode { get; set; }
        public string Feedback { get; set; }

        public string ClockTypeText
        {
            get
            {
                if (ClockType == null)
                {
                    return "未知";
                }
                return ((WorkerAuthClockType)ClockType).ToEnumText();
            }
        }

        public DateTime? ClockTime
        {
            get { return FormatHelper.GetDateTimeFromStampIgnoreEx(AuthTimeStamp); }
        }

        public string ClockTimeText
        {
            get { return FormatHelper.GetIsoDateTimeString(ClockTime); }
        }

        public string ClockStateText
        {
            get
            {
                if (ClockState == 0)
                {
                    return "未通过";
                }
                return "通过";
            }
        }

        public string StateText
        {
            get { return ((KtpSyncState)State).ToEnumText(); }
        }
    }
}
