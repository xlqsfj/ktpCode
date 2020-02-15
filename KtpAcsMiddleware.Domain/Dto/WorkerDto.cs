using System;

namespace KtpAcsMiddleware.Domain.Dto
{
    /// <summary>
    ///     工人详情
    /// </summary>
    public class WorkerDto
    {
        public string Id { get; set; }
        public string IdentityId { get; set; }
        public string TeamId { get; set; }
        public DateTime InTime { get; set; }
        public DateTime? OutTime { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public int Status { get; set; }
        public decimal? IdentityFaceSim { get; set; }
        public string AddressNow { get; set; }
        public string ContractPicId { get; set; }
        public string FacePicId { get; set; }
        public string CreatorId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public bool IsDelete { get; set; }

        public WorkerIdentityDto Identity { get; set; }
        public WorkerSyncDto Sync { get; set; }
    }
}