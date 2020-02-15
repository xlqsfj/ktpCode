using KtpAcsMiddleware.AppService.ServiceModel;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.AppService.ServiceAuths
{
    public interface IServiceAuthsWorker
    {
        /// <summary>
        /// 查询考勤数据
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">总页数</param>
        /// <param name="keywords">模糊查询</param>
        /// <param name="deviceCode">设备号</param>
        /// <param name="beginDate">查询开始时间</param>
        /// <param name="endDate">查询结束时间</param>
        /// <param name="isBePresent">是否在场</param>
        /// <returns>AuthsDto</returns>
        PagedResult<AuthsDto> GetPaged(
    int pageIndex, int pageSize, string keywords, string deviceCode, string beginDate, string endDate, bool isBePresent);
    }
}
