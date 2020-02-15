using System;
using System.Collections.Generic;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Search.Paging;

namespace KtpAcsMiddleware.AppService.WorkerAuths
{
    public interface IWorkerAuthService
    {
        /// <summary>
        ///     从原始的考勤数据(ZmskAuthentication)中采集工人考勤数据
        /// </summary>
        void CollectionWorkerAuths();

        PagedResult<WorkerAuthPagedDto> GetPaged(
            int pageIndex, int pageSize, string keywords, string teamId, DateTime? authDate);

        /// <summary>
        ///     获取工人某个时间段的打卡记录（2019-02-26 13:50 上班）
        /// </summary>
        /// <param name="workerId">工人ID</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间(null=当前时间)</param>
        /// <returns></returns>
        IList<WorkerAuth> GetCycleList(string workerId, DateTime? beginTime, DateTime? endTime);

        /// <summary>
        ///     获取工人某个时间段的日工时
        /// </summary>
        /// <param name="workerId">工人ID</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间,null=当前时间</param>
        /// <returns></returns>
        IList<WorkerDailyWorkingTimeDto> GetWorkerDailyWorkingTimes(
            string workerId, DateTime beginTime, DateTime? endTime);
    }
}