using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Infrastructure.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.AppService.ServiceModel
{
   public class WorkerDto
    {  /// <summary>
       ///     主键ID
       /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 设备id
        /// </summary>
        public string dId { get; set; }

        public string WorkerName { get; set; }
        public string IdentityCode { get; set; }
        public string Sex { get; set; }
        public string Mobile { get; set; }
        public string Nation { get; set; }
        public string AddressNow { get; set; }
        public string TeamName { get; set; }
        public string state { get; set; }
        public string TeamId { get; set; }
        public string FacePicId { get; set; }
        public string IdentityPicId { get; set; }
        public string IdentityBackPicId { get; set; }
        /// <summary>
        /// 面板状态
        /// </summary>
        public string panelState { get; set; }
        /// <summary>
        /// 面板状态Code
        /// </summary>
        public int  panelStateCode { get; set; }
        /// <summary>
        /// 太平状态
        /// </summary>
        public string ktpState { get; set; }
        /// <summary>
        /// 面板消息
        /// </summary>
        public string panelMag { get; set; }
        /// <summary>
        /// 开太平消息
        /// </summary>
        public string ktpMag { get; set; }
        public string ErrorCodeText
        {
            get
            {
                if (panelMag == null)
                {
                    return string.Empty;
                }
                int intErrorCode;
                if (int.TryParse(panelMag, out intErrorCode))
                {
                    return $"{panelMag}.{((FaceDeviceWorkerErrorCode)intErrorCode).ToEnumText()}";
                }
                return panelMag;
            }
        }
    }
}
