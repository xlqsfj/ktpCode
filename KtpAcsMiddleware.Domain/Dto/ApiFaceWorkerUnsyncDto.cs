using System;

namespace KtpAcsMiddleware.Domain.Dto
{
    /// <summary>
    ///     设备人脸库未同步的新数据DTO
    /// </summary>
    public class ApiFaceWorkerUnsyncDto
    {
        public string Id { get; set; }
        public int IdentityId { get; set; }
        public string WorkerId { get; set; }
        public string DeviceId { get; set; }
        public int Status { get; set; }
        public string ErrorCode { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public bool IsDelete { get; set; }
        public WorkerDto Worker { get; set; }
        public WorkerIdentityDto WorkerIdentity { get; set; }
    }
}