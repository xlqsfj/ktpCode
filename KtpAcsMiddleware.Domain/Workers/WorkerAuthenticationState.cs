using System.ComponentModel;

namespace KtpAcsMiddleware.Domain.Workers
{
    /// <summary>
    ///     工人认证状态
    /// </summary>
    public enum WorkerAuthenticationState
    {
        /// <summary>
        ///     所有
        /// </summary>
        [Description("所有")] All,

        /// <summary>
        ///     待认证
        /// </summary>
        [Description("待认证")] WaitFor,

        /// <summary>
        ///     已认证
        /// </summary>
        [Description("已认证")] Already,

        /// <summary>
        ///     已删除
        /// </summary>
        [Description("已删除")] Delete
    }
}