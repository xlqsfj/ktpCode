using System.Data.SqlClient;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.WorkerAuths;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Domain.Dto
{
    internal class WorkerAuthCollectionDataMap
    {
        public static WorkerAuthCollectionDto Mapping(SqlDataReader reader)
        {
            var entity = new WorkerAuthCollectionDto();
            entity.AuthId = EntityDataService.GetNoNullReaderValue(reader, "Id");
            entity.WorkerId = EntityDataService.GetNoNullReaderValue(reader, "WorkerId");
            entity.TeamId = EntityDataService.GetNoNullReaderValue(reader, "TeamId");
            entity.TeamName = EntityDataService.GetNoNullReaderValue(reader, "TeamName");
            entity.ClockPic = EntityDataService.GetNoNullReaderValue(reader, "Avatar");
            entity.SimilarDegree = EntityDataService.GetReaderValueTDecimal(reader, "SimilarDegree");
            entity.ClientCode = EntityDataService.GetNoNullReaderValue(reader, "DeviceNumber");
            var isCheckIn = EntityDataService.GetReaderValueTBoolNoNull(reader, "IsCheckIn");
            entity.ClockType = isCheckIn ? (int) WorkerAuthClockType.JinZhaji : (int) WorkerAuthClockType.ChuZhaji;
            var clockTimeStamp = EntityDataService.GetNoNullReaderValue(reader, "AuthTimeStamp");
            entity.ClockTime = FormatHelper.GetDateTimeFromStamp(clockTimeStamp);
            var isPass = EntityDataService.GetReaderValueTIntNoNull(reader, "Result");
            entity.IsPass = isPass == 1; //认证结果 0：未通过 1：通过
            return entity;
        }
    }
}