using System.ComponentModel;

namespace KtpAcsMiddleware.Domain.Organizations
{
    public enum OrgUserState
    {
        /// <summary>
        ///     正常
        /// </summary>
        [Description("正常")] Normal,

        /// <summary>
        ///     注销
        /// </summary>
        [Description("注销")] Cancle

        ///// <summary>
        /////     停用(暂停)
        ///// </summary>
        //, [Description("停用")] Suspend
    }
}