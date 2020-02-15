using System;
using KtpAcsMiddleware.Domain.WorkerAuths;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.AppService.Dto
{
    public class WorkerAuthPagedDto
    {
        /// <summary>
        ///     主键ID
        /// </summary>
        public string Id { get; set; }

        public string WorkerId { get; set; }
        public string WorkerName { get; set; }
        public string IdentityCode { get; set; }
        public int ClockType { get; set; }
        public DateTime ClockTime { get; set; }
        public decimal? SimilarDegree { get; set; }
        public string ClientCode { get; set; }
        public string TeamName { get; set; }

        /***Extension*****************************************************************************/
        public string ClockTypeText
        {
            get { return ((WorkerAuthClockType) ClockType).ToEnumText(); }
        }

        public string ClockTimeText
        {
            get { return FormatHelper.GetIsoDateString(ClockTime); }
        }

        public string SimilarDegreeText
        {
            get { return FormatHelper.GetDecimalString(SimilarDegree); }
        }
    }
}