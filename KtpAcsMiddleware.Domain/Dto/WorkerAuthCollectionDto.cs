using System;

namespace KtpAcsMiddleware.Domain.Dto
{
    /// <summary>
    ///     工人考勤数据采集Dto
    ///     用户从原始考勤数据中整理出标准数据
    /// </summary>
    public class WorkerAuthCollectionDto
    {
        /// <summary>
        ///     原始考勤数据(ZmskAuthentication)的ID
        /// </summary>
        public string AuthId { get; set; }

        public string WorkerId { get; set; }

        /// <summary>
        ///     班组ID，记录考勤当时的班组ID
        /// </summary>
        public string TeamId { get; set; }

        /// <summary>
        ///     班组名称，记录考勤当时的班组名称
        ///     当TeamId找不到对应的班组信息时，以此显示考勤班组名
        /// </summary>
        public string TeamName { get; set; }

        /// <summary>
        ///     打卡类型:WorkerAuthClockType
        /// </summary>
        public int ClockType { get; set; }

        /// <summary>
        ///     打卡时间
        /// </summary>
        public DateTime ClockTime { get; set; }

        /// <summary>
        ///     打卡当时的照片信息(Base64String)
        /// </summary>
        public string ClockPic { get; set; }

        /// <summary>
        ///     相似度
        /// </summary>
        public decimal? SimilarDegree { get; set; }

        /// <summary>
        ///     是否通过
        /// </summary>
        public bool IsPass { get; set; }

        /// <summary>
        ///     打卡端(设备)的编号
        /// </summary>
        public string ClientCode { get; set; }

        /***Extension*****************************************************************************/

        /// <summary>
        ///     工人第三方ID(考勤同步使用)
        /// </summary>
        public int ThirdPartyWorkerId { get; set; }

        /// <summary>
        ///     工人是否已被删除(用于优先获取未删除的工人的标记)
        /// </summary>
        public bool WorkerIsDelete { get; set; }
    }
}