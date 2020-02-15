using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Serialization;

namespace KtpAcsMiddleware.AppService.Dto
{
    public class FaceDeviceWorkerPagedDto
    {
        /// <summary>
        ///     主键ID[FaceDeviceWorker.Id]
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
        public string ErrorCode { get; set; }
        public string DeviceCode { get; set; }

        /// <summary>
        ///     用于判断状态显示文本(是否生效)
        /// </summary>
        public string FacePicId { get; set; }

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

        public string ErrorCodeText
        {
            get
            {
                if (ErrorCode == null)
                {
                    return string.Empty;
                }
                int intErrorCode;
                if (int.TryParse(ErrorCode, out intErrorCode))
                {
                    return $"{ErrorCode}.{((FaceDeviceWorkerErrorCode) intErrorCode).ToEnumText()}";
                }
                return ErrorCode;
            }
        }
    }
}