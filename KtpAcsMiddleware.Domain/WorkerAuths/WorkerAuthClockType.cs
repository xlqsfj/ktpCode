using System.ComponentModel;

namespace KtpAcsMiddleware.Domain.WorkerAuths
{
    /// <summary>
    ///     打卡类型(对应到开太平的枚举值)
    /// </summary>
    public enum WorkerAuthClockType
    {
        /// <summary>
        ///     进场=进闸机
        /// </summary>
        [Description("进场")] JinZhaji = 1,

        /// <summary>
        ///     出场=出闸机
        /// </summary>
        [Description("出场")] ChuZhaji = 2,

        /// <summary>
        ///     进场手机考勤
        /// </summary>
        [Description("进场手机考勤")] JinchangShoujiKaoqin = 3,

        /// <summary>
        ///     出场手机考勤
        /// </summary>
        [Description("出场手机考勤")] ChuchangShoujiKaoqin = 4,

        /// <summary>
        ///     代打卡进场
        /// </summary>
        [Description("代打卡进场")] DaiDakaJinchang = 5,

        /// <summary>
        ///     代打卡出场
        /// </summary>
        [Description("代打卡出场")] DaiDakaChuchang = 6
    }
}