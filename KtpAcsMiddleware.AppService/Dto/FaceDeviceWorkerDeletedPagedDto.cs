using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Serialization;

namespace KtpAcsMiddleware.AppService.Dto
{
    public class FaceDeviceWorkerDeletedPagedDto
    {
        /// <summary>
        ///     主键ID
        /// </summary>
        public string Id { get; set; }

        public string WorkerId { get; set; }
        public string WorkerName { get; set; }
        public string IdentityCode { get; set; }
        public string Mobile { get; set; }
        public int Sex { get; set; }
        public int Nation { get; set; }
        public string AddressNow { get; set; }
        public int Status { get; set; }
        public string DeviceCode { get; set; }

        public string SexText
        {
            get { return ((WorkerSex) Sex).ToEnumText(); }
        }

        public string NationText
        {
            get { return IdentityNationService.GetText(Nation); }
        }

        public string StatusText
        {
            get { return ((FaceWorkerState) Status).ToEnumText(); }
        }
    }
}