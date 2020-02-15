using System.ComponentModel;

namespace KtpAcsMiddleware.Domain.KtpLibrary
{
    /// <summary>
    ///     对应到开天平的数据同步状态
    /// </summary>
    public enum KtpSyncState
    {
        /// <summary>
        ///     已同步
        /// </summary>
        [Description("已同步")] Success,

        /// <summary>
        ///     同步失败
        /// </summary>
        [Description("同步失败")] Fail,

        /// <summary>
        ///     新编辑
        /// </summary>
        [Description("新编辑")] NewEdit,

        /// <summary>
        ///     新删除
        /// </summary>
        [Description("新删除")] NewDel,

        /// <summary>
        ///     新添加(添加出现异常并调整好异常数据后可能需要指向的状态)
        /// </summary>
        [Description("新添加")] NewAdd,

        /// <summary>
        ///     忽略(本地数据已删除且不需要同步到开太平)
        /// </summary>
        [Description("忽略")] Ignore
    }
}