using System;

namespace KtpAcsMiddleware.AppService.Dto
{
    public class WorkerDailyWorkingTimeDto
    {
        public string WorkerId { get; set; }

        /// <summary>
        ///     取打卡时的班组ID
        /// </summary>
        public string TeamId { get; set; }

        /// <summary>
        ///     所属日期
        /// </summary>
        public DateTime WorkDate { get; set; }

        /// <summary>
        ///     工时(秒:24小时=86400)
        /// </summary>
        public decimal WorkingTime { get; set; }

        /***Extension*****************************************************************************/

        public decimal WorkingHour
        {
            get
            {
                if (WorkingTime == 0)
                {
                    return 0;
                }
                return decimal.Parse((WorkingTime / 3600).ToString("f2"));
            }
        }
    }
}