using KtpAcsMiddleware.Domain.Data;

namespace KtpAcsMiddleware.Domain.Workers
{
    public interface IWorkerCommandRepository
    {
        /// <summary>
        ///     添加工人
        /// </summary>
        void Add(Worker dto);

        /// <summary>
        ///     更新Worker实体本身
        /// </summary>
        void ModifySimple(Worker dto, string id);

        /// <summary>
        ///     修改身份认证信息
        /// </summary>
        void ModifyIdentityAuth(
            string workerId, string facePicId, string identityPicId, string identityBackPicId);

        /// <summary>
        ///     修改所属班组ID
        /// </summary>
        void ModifyTeamId(string workerId, string teamId);

        /// <summary>
        ///     删除工人
        /// </summary>
        void Delete(string workerId, WorkerSync sync = null);

        /// <summary>
        ///     添加工人到所有设备
        /// </summary>
        void AddToAllFaceDevice(string workerId);


        /// <summary>
        ///     设置当前工人在所有设备的状态为新删除
        /// </summary>
        void ModifyFaceDevicesStateNewDel(string workerId);
    }
}