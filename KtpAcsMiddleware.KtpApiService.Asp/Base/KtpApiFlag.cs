using System.ComponentModel;

namespace KtpAcsMiddleware.KtpApiService.Asp.Base
{
    /// <summary>
    ///     保留，暂时无用
    /// </summary>
    internal enum KtpApiFlag
    {
        /// <summary>
        ///     成功
        /// </summary>
        [Description("成功")] Success,

        /// <summary>
        ///     失败
        /// </summary>
        [Description("失败")] Fail,

        /// <summary>
        ///     超时
        /// </summary>
        [Description("超时")] Overtime
    }
}