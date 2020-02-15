using System.ComponentModel;

namespace KtpAcsMiddleware.Domain.FaceRecognition
{
    public enum FaceDeviceWorkerErrorCode
    {
        /// <summary>
        ///     下载人脸库失败，设备保存人脸信息失败
        /// </summary>
        [Description("下载人脸库失败")] DownloadFaceFailure = 1,

        /// <summary>
        ///     重复添加人脸库，设备已经存了人脸信息，再次同步时返回值，可以视为同步成功，不影响正常使用
        /// </summary>
        [Description("人脸重复添加")] RepeatAdd = 2,

        /// <summary>
        ///     未发现人脸特征，图片不清晰或不是人脸图片，失败
        /// </summary>
        [Description("未发现人脸特征")] NotFoundFacialFeatures = 3
    }
}