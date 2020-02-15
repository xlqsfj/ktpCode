using System.Collections.Generic;
using KtpAcsMiddleware.Domain.Data;

namespace KtpAcsMiddleware.AppService.FaceRecognition
{
    public interface IFaceDeviceService
    {
        FaceDevice Get(string id);
        FaceDevice GetByIdentityId(int identityId);
        FaceDevice GetByCode(string code);
        bool Any(string code, string excludedId);
        IList<FaceDevice> GetAll();
        void Change(FaceDevice dto, string deviceId);
        void ChangeIpAddress(string deviceId, string ipAddress);
        string Add(FaceDevice dto);
        void Remove(string deviceId);

        /// <summary>
        ///     把设备所有预添加或者添加失败的数据改成新添加
        /// </summary>
        void ChangeDeviceUnSyncAddWorkersToNewState(string deviceId);

        /// <summary>
        ///     把设备所有预删除或者删除失败的数据改成新删除
        /// </summary>
        void ChangeDeviceUnSyncDelWorkersToNewDelState(string deviceId);
    }
}