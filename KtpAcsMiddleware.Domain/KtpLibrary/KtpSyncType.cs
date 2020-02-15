using System.ComponentModel;

namespace KtpAcsMiddleware.Domain.KtpLibrary
{
    /// <summary>
    ///     开太平同步操作类型(最近操作)
    /// </summary>
    public enum KtpSyncType
    {
        /// <summary>
        ///     推送添加
        /// </summary>
        [Description("推送添加")] PushAdd,

        /// <summary>
        ///     推送编辑
        /// </summary>
        [Description("推送编辑")] PushEdit,

        /// <summary>
        ///     推送删除
        /// </summary>
        [Description("推送删除")] PushDelete,

        /// <summary>
        ///     拉取添加
        /// </summary>
        [Description("拉取添加")] PullAdd,

        /// <summary>
        ///     拉取编辑
        /// </summary>
        [Description("拉取编辑")] PullEdit,

        /// <summary>
        ///     拉取删除
        /// </summary>
        [Description("拉取删除")] PullDelete
    }
}