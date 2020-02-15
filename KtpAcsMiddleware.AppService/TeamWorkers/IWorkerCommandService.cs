using System.Collections.Generic;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.Dto;

namespace KtpAcsMiddleware.AppService.TeamWorkers
{
    public interface IWorkerCommandService
    {
        /// <summary>
        ///     判断当前用户身份证号的全局唯一性
        /// </summary>
        bool AnyIdentityCode(string identityCode, string excludedId);

        /// <summary>
        ///     判断当前用户手机号的全局唯一性
        /// </summary>
        bool AnyMobile(string mobile, string excludedId);

        IList<WorkerDto> GetAll();
        string Add(TeamWorkerDto dto);
        void Change(TeamWorkerDto dto, string dtoId);
        void ChangeTeam(string workerId, string teamId);
        void SaveAuthenticationIdentity(WorkerIdentityAuthenticationDto dto);
        void Remove(string workerId);

        /// <summary>
        ///     设置当前工人在所有设备的状态为新删除
        ///     删除完成后再重新添加(重新添加逻辑在删除完成后api处理)
        /// </summary>
        void ChangeWorkerFaceDeviceStatesToReAdd(string workerId);
    }
}