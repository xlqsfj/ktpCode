using System;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.AppService.Dto
{
    /// <summary>
    ///     身份证信息详情Dto
    /// </summary>
    public class IdentityDto
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Sex { get; set; }
        public int Nation { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string IssuingAuthority { get; set; }
        public DateTime ActivateTime { get; set; }
        public DateTime InvalidTime { get; set; }
        public string PicId { get; set; }
        public string BackPicId { get; set; }
        public string Base64Photo { get; set; }
        public int CreateType { get; set; }
        public DateTime CreateTime { get; set; }

        public decimal? CreditGrade { get; set; }

        //public bool IsDelete { get; set; }
        /***Extension*****************************************************************************/
        public string SexText
        {
            get { return ((WorkerSex) Sex).ToEnumText(); }
        }

        public string BirthdayText
        {
            get { return FormatHelper.GetIsoDateString(Birthday); }
        }

        public string ActivateTimeText
        {
            get { return FormatHelper.GetIsoDateString(ActivateTime); }
        }

        public string InvalidTimeText
        {
            get { return FormatHelper.GetIsoDateString(InvalidTime); }
        }

        public string CreateTypeText
        {
            get { return ((WorkerIdentityCreateType) CreateType).ToEnumText(); }
        }

        public string CreateTimeText
        {
            get { return FormatHelper.GetIsoDateString(CreateTime); }
        }

        public string CreditGradeText
        {
            get { return FormatHelper.GetDecimalString(CreditGrade); }
        }

        public string NationText
        {
            get { return ((IdentityNation) Nation).ToEnumText(); }
        }
    }
}