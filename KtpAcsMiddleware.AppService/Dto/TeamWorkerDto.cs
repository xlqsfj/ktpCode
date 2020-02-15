using System;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.AppService.Dto
{
    /// <summary>
    ///     班组中的工人详情Dto(涉及前端js ajax对象映射)
    /// </summary>
    public class TeamWorkerDto
    {
        /***TeamWorker*****************************************************************************/
        /// <summary>
        ///     WorkerId
        /// </summary>
        public string Id { get; set; }

        public string TeamId { get; set; }
        public string WorkerId { get; set; }
        public DateTime InTime { get; set; }
        public DateTime? OutTime { get; set; }
        public string Mobile { get; set; }
        public int Status { get; set; }
        public string ContractPicId { get; set; }
        public DateTime CreateTime { get; set; }

        public DateTime ModifiedTime { get; set; }

        /***Worker*****************************************************************************/
        public string WorkerName { get; set; }

        public string IdentityId { get; set; }
        public decimal? IdentityFaceSim { get; set; }

        /// <summary>
        ///     现在住址
        /// </summary>
        public string AddressNow { get; set; }

        public string FacePicId { get; set; }
        public string WorkerCreatorId { get; set; }
        public DateTime WorkerCreateTime { get; set; }
        public bool WorkerIsDelete { get; set; }

        public int? BankCardTypeId { get; set; }
        public string BankCardCode { get; set; }

        /***WorkerIdentity*******************************************************************/
        public string IdentityCode { get; set; }

        public int Sex { get; set; }

        /// <summary>
        ///     民族
        /// </summary>
        public int Nation { get; set; }

        public DateTime Birthday { get; set; }

        /// <summary>
        ///     身份证上的地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///     身份证发证机关
        /// </summary>
        public string IssuingAuthority { get; set; }

        /// <summary>
        ///     身份证激活时间
        /// </summary>
        public DateTime ActivateTime { get; set; }

        /// <summary>
        ///     身份证失效时间
        /// </summary>
        public DateTime InvalidTime { get; set; }

        public string IdentityPicId { get; set; }
        public string IdentityBackPicId { get; set; }
        /// <summary>
        /// 身份证头像照片
        /// </summary>
        public string u_sfzpic { get; set; }

        /// <summary>
        ///     身份证创建类型(0=来自读卡器;1=手动)
        /// </summary>
        public int CreateType { get; set; }

        public DateTime IdentityCreateTime { get; set; }

        /// <summary>
        ///     身份证信用分
        /// </summary>
        public decimal? CreditGrade { get; set; }

        public bool IdentityCardIsDelete { get; set; }

        /***Team*****************************************************************************/
        public int ProjectId { get; set; }

        public string TeamName { get; set; }
        public string TeamWorkTypeId { get; set; }
        public string TeamDescription { get; set; }
        public DateTime TeamCreateTime { get; set; }
        public DateTime TeamModifiedTime { get; set; }

        public bool TeamIsDelete { get; set; }

        /***Extension*****************************************************************************/
        public string IdentityPicFileName { get; set; }

        public string IdentityBackPicFileName { get; set; }
        public string ContractPicFileName { get; set; }
        public string FacePicFileName { get; set; }
        public int TeamWorkTypValue { get; set; }
        public string TeamWorkTypeName { get; set; }

        public bool isAdd { get; set; }

        public string InTimeText
        {
            get { return FormatHelper.GetIsoDateString(InTime); }
        }

        public string OutTimeText
        {
            get { return FormatHelper.GetIsoDateString(OutTime); }
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

        public string NationText
        {
            get { return ((IdentityNation) Nation).ToEnumText(); }
        }

        public string SexText
        {
            get { return ((WorkerSex) Sex).ToEnumText(); }
        }

        public string BankCardTypeText
        {
            get
            {
                if (BankCardTypeId == null)
                {
                    return string.Empty;
                }
                return ((BankCardType) BankCardTypeId).ToEnumText();
            }
        }
    }
}