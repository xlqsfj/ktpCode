using System.ComponentModel;

namespace KtpAcsMiddleware.Domain.Workers
{
    public enum WorkerIdentityCreateType
    {
        /// <summary>
        ///     阅读器
        /// </summary>
        [Description("阅读器")] Reader,

        /// <summary>
        ///     手动
        /// </summary>
        [Description("手动")] Manual
    }
}