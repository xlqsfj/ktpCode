using System;

namespace KtpAcsMiddleware.Domain.Dto
{
    /// <summary>
    ///     工人身份证信息
    /// </summary>
    public class WorkerIdentityDto
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
        public DateTime ModifiedTime { get; set; }
        public decimal? CreditGrade { get; set; }
        public bool IsDelete { get; set; }
    }
}