using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Dto;
using KtpAcsMiddleware.Domain.WorkerAuths;
using KtpAcsMiddleware.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.Domain.DomainAuths
{
    public class DomainAuthsRepository : AbstractRepository, IDomainAuthsRepository
    {
        /// <summary>
        /// 查询上传的考勤
        /// </summary>
        /// <param name="authId">考勤id</param>
        /// <returns></returns>
        public WorkerAuthCollectionDto FindNew(string authId)
        {
            using (var dataContext = DataContext)
            {
                var authentication = from t in dataContext.ZmskAuthentications
                                     join tworker in dataContext.Workers on t.IdNumber equals tworker.WorkerIdentity.Code
                                     join tfacedevice in dataContext.FaceDevices on t.DeviceNumber equals tfacedevice.Code
                                     where (t.Id == authId )
                                        && tfacedevice.IsCheckIn != null
                                        //必须已经同步工人
                                           && tworker.WorkerSync != null && tworker.WorkerSync.ThirdPartyId > 0
                                     select new WorkerAuthCollectionDto
                                     {
                                         AuthId = t.Id,
                                         WorkerId = tworker.Id,
                                         TeamId = tworker.TeamId,
                                         TeamName = tworker.Team.Name,
                                         ClockType = tfacedevice.IsCheckIn == true
                                             ? (int)WorkerAuthClockType.JinZhaji
                                             : (int)WorkerAuthClockType.ChuZhaji,
                                         ClockTime = FormatHelper.GetDateTimeFromStamp(t.AuthTimeStamp),
                                         ClockPic = t.Avatar,
                                         SimilarDegree = FormatHelper.GetDecimal(t.SimilarDegree),
                                         IsPass = t.Result == 1, //认证结果 0：未通过 1：通过
                                         ClientCode = t.DeviceNumber,
                                         ThirdPartyWorkerId = tworker.WorkerSync.ThirdPartyId
                                     };
                return authentication.FirstOrDefault();
            }
        }
    }
}
