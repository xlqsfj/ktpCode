using System;
using System.Collections.Generic;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Dto;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Paging;

namespace KtpAcsMiddleware.Domain.WorkerAuths
{
    public interface IWorkerAuthRepository
    {
        IList<WorkerAuthCollectionDto> FindTopOneThousandNews();

        string Add(WorkerAuth dto);

        /// <summary>
        ///     清理原始考勤数据的图片数据(通过递归的方式每次清理一千条数据，直到清理完成)
        ///     Base64String to fileId
        /// </summary>
        void ClearAuthClockPics();

        PagedResult<WorkerAuth> FindPaged(SearchCriteria<WorkerAuth> searchCriteria);

        /// <summary>
        ///     获取工人某个时间段的打卡记录
        /// </summary>
        /// <param name="workerId">工人ID</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        IList<WorkerAuth> FindCycle(string workerId, DateTime beginTime, DateTime endTime);

        /// <summary>
        ///     获取工人某个日期之前的最后一条记录
        /// </summary>
        /// <param name="workerId">工人ID</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        WorkerAuth FindDatePreviousOne(string workerId, DateTime date);

        /// <summary>
        ///     获取工人某个日期之后第一条记录
        /// </summary>
        /// <param name="workerId">工人ID</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        WorkerAuth FindDateLatterOne(string workerId, DateTime date);

        /// <summary>
        ///     获取工人最后一次打卡记录
        /// </summary>
        /// <param name="workerId">工人ID</param>
        /// <returns></returns>
        WorkerAuth FindLast(string workerId);
    }
}