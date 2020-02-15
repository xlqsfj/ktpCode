using System.ComponentModel;

namespace KtpAcsMiddleware.Domain.FaceRecognition
{
    public enum FaceWorkerState
    {
        /// <summary>
        ///     新添加
        /// </summary>
        [Description("新添加")] New,

        /// <summary>
        ///     预添加=已推送
        /// </summary>
        [Description("预添加")] PrepareAdd,

        /// <summary>
        ///     已添加=添加同步成功
        /// </summary>
        [Description("已添加")] HasAdd,

        /// <summary>
        ///     重复(已添加)
        /// </summary>
        [Description("重复(已添加)")] RepeatAdd,

        /// <summary>
        ///     添加失败(需做处理后重新添加)
        /// </summary>
        [Description("添加失败")] FailAdd,

        /// <summary>
        ///     新删除
        /// </summary>
        [Description("新删除")] NewDel,

        /// <summary>
        ///     预删除=已推送
        /// </summary>
        [Description("预删除")] PrepareDel,

        /// <summary>
        ///     已删除=删除同步成功
        /// </summary>
        [Description("已删除")] HasDel,

        /// <summary>
        ///     删除失败=(需做处理后重新删除)
        /// </summary>
        [Description("删除失败")] FailDel
    }
}