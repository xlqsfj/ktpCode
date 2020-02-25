using AutoMapper;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Dto;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Domain.Organizations;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Asp.Base;
using KtpAcsMiddleware.KtpApiService.Asp.TeamSyncs;
using KtpAcsMiddleware.KtpApiService.Asp.TeamSyncs.Api;
using KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs.Api
{
    /// <summary>
    /// 获取Ktp工人列表
    /// </summary>
    public class KtpWokerObtainList
    {

        /// <summary>
        ///     拉取所有工人
        /// </summary>
        public void PullWorkers()
        {
            KtpWorkerLoadService ktpWorkerLoadService = new KtpWorkerLoadService();

            //获取班组列表到本地
            var teamSyncService = new KtpTeamLoadService();
            teamSyncService.LoadTeams();
            //获取工人列表api
            var ktpAllWorkers = ktpWorkerLoadService.GetKtpWorkers();
            if (ktpAllWorkers == null)
            {
                return;
            }

            var localTeams = DataFactory.TeamRepository.FindAll().ToList();
            var localWorkers = DataFactory.WorkerQueryRepository.FindAll(true).ToList();
            var creatorUser = OrgUserDataService.FindAdmin();
            var erros = string.Empty;
            foreach (var localTeam in localTeams)
            {
                if (localTeam.TeamSync == null || localTeam.TeamSync.ThirdPartyId <= 0)
                {
                    //过滤不存在映射数据的班组
                    continue;
                }
                var teamThirdPartyId = localTeam.TeamSync.ThirdPartyId;
                /********获取当前班组下的工人(云端)**************************************************/
                IList<KtpWorkerApiGetResultContentUser> ktpTeamWorkers = null;
                try
                {
                    ktpTeamWorkers = ktpAllWorkers.Where(i => i.po_id == teamThirdPartyId).ToList();
                    if (ktpTeamWorkers == null || ktpTeamWorkers.Count == 0)
                    {
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    erros =
                        $"本地班组对应:{erros}Message={ex.Message},StackTrace={ex.StackTrace},teamThirdPartyId={teamThirdPartyId},localTeamId={localTeam.Id}|";
                }




                /********遍历当前班组下的工人(云端)-保存到本地*****************************************/
                foreach (var ktpWorker in ktpTeamWorkers)
                {
                    try
                    {
                        //身份证信息同步处理
                        var workerIdentity = PullWorkerIdentity(ktpWorker);
                        /********工人信息同步处理**************************************************/
                        var newWorkerSyncDto = new WorkerSyncDto
                        {
                            ThirdPartyId = ktpWorker.user_id,
                            TeamThirdPartyId = teamThirdPartyId,
                            Type = (int)KtpSyncType.PullAdd,
                            Status = (int)KtpSyncState.Success,
                            FeedbackCode = 100,
                            Feedback = "",
                            CreateTime = DateTime.Now,
                            ModifiedTime = DateTime.Now
                        };
                        var facePicId = AddNewFile(ktpWorker.u_cert_pic);
                        //获取本地已经关联的工人
                        var localWorkerDto = localWorkers.FirstOrDefault(
                            i => i.Sync != null && i.Sync.ThirdPartyId == ktpWorker.user_id);
                        if (localWorkerDto == null)
                        {
                            //获取本地身份证对应的生效的工人(本地已经关联的工人不存在)
                            localWorkerDto = localWorkers.FirstOrDefault(
                                i => i.Identity.Code == ktpWorker.u_sfz && i.IsDelete == false);
                        }
                        if (localWorkerDto == null)
                        {
                            //获取本地身份证对应的已删除工人(本地身份证对应的生效的工人不存在)
                            localWorkerDto =
                                localWorkers.FirstOrDefault(i => i.Identity.Code == ktpWorker.u_sfz);
                        }
                        Worker localWorker;
                        if (localWorkerDto == null)
                        {
                            localWorker = new Worker();
                        }
                        else
                        {
                            localWorker = Mapper.Map<Worker>(localWorkerDto);
                        }
                        localWorker.Status = (int)WorkerPositionState.Zaichang;
                        localWorker.Mobile = ktpWorker.u_phone.Trim();
                        localWorker.CreatorId = creatorUser.Id;
                        localWorker.Name = ktpWorker.u_realname.Trim();
                        localWorker.IdentityId = workerIdentity.Id;
                        localWorker.AddressNow = ktpWorker.u_address.Trim();
                        localWorker.FacePicId = facePicId;

                        if (string.IsNullOrEmpty(localWorker.Id))
                        {
                            /********本地无关联工人执行添加逻辑*****************/
                            localWorker.InTime = DateTime.Now;
                            localWorker.TeamId = localTeam.Id;
                            localWorker.Id = ConfigHelper.NewGuid;
                            var workerSync = Mapper.Map<WorkerSync>(newWorkerSyncDto);

                            //设置工人同步映射数据并保存工人数据和映射数据
                            localWorker.WorkerSync = workerSync;
                            var newWorker = Mapper.Map<Worker>(localWorker);
                            DataFactory.WorkerCommandRepository.Add(newWorker);
                            DataFactory.WorkerCommandRepository.AddToAllFaceDevice(localWorker.Id);
                        }
                        else
                        {
                            /********本地有关联工人执行添加逻辑*****************/
                            newWorkerSyncDto.Id = localWorker.Id;
                            if (ktpWorker.last_operation_time >= localWorker.ModifiedTime)
                            {
                                //开太平最后更新时间大于本地就执行更新
                                localWorker.TeamId = localTeam.Id;
                                DataFactory.WorkerCommandRepository.ModifySimple(localWorker, localWorker.Id);
                                newWorkerSyncDto.Type = (int)KtpSyncType.PullEdit;
                            }
                            if (ktpWorker.worker_state == 4)
                            {
                                //开太平数据状态为删除时，处理本地数据删除
                                if (localWorker.IsDelete)
                                {
                                    //to本地已删除数据
                                    if (localWorkerDto.Sync == null ||
                                        (localWorkerDto.Sync.Type != (int)KtpSyncType.PullDelete &&
                                         localWorkerDto.Sync.Type != (int)KtpSyncType.PushDelete))
                                    {
                                        //设置同步状态为拉取删除
                                        newWorkerSyncDto.Type = (int)KtpSyncType.PullDelete;
                                    }
                                    else
                                    {
                                        //保持原来状态
                                        newWorkerSyncDto.Type = localWorkerDto.Sync.Type;
                                    }
                                }
                                else if ((localWorkerDto.Sync != null &&
                                          localWorkerDto.Sync.ThirdPartyId == ktpWorker.user_id)
                                         || (localWorkerDto.ModifiedTime < localWorker.ModifiedTime))
                                {
                                    //to本地已关联ID的数据或者本地最后更新时间小于开太平时间的，执行删除，并设置状态为下拉删除成功
                                    DataFactory.WorkerCommandRepository.Delete(
                                        localWorker.Id, Mapper.Map<WorkerSync>(newWorkerSyncDto));
                                    newWorkerSyncDto.Type = (int)KtpSyncType.PullDelete;
                                }
                                //本地新建数据，最后更新时间会大于开太平状态时间，放置不管，在同步添加时同步到开太平
                            }
                            else
                            {
                                //添加数据所有设备
                                DataFactory.WorkerCommandRepository.AddToAllFaceDevice(localWorker.Id);
                            }

                            if (newWorkerSyncDto.Type == (int)KtpSyncType.PullEdit ||
                                newWorkerSyncDto.Type == (int)KtpSyncType.PullDelete ||
                                newWorkerSyncDto.Type == (int)KtpSyncType.PushDelete)
                            {
                                //保存同步映射数据
                                if (localWorkerDto != null && localWorkerDto.Sync == null)
                                {
                                    newWorkerSyncDto.Id = localWorker.Id;
                                    DataFactory.WorkerSyncRepository.Add(
                                        Mapper.Map<WorkerSync>(newWorkerSyncDto));
                                }
                                else
                                {
                                    if (newWorkerSyncDto.Type == localWorkerDto.Sync.Type)
                                    {
                                        continue;
                                    }
                                    var workerSync = Mapper.Map<WorkerSync>(newWorkerSyncDto);
                                    DataFactory.WorkerSyncRepository.Modify(localWorker.Id, workerSync);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        erros =
                            $"{erros}Message={ex.Message},StackTrace={ex.StackTrace},ktpWorker={ktpWorker.ToJson()}|";
                    }
                }
                FaceDeviceWorkerEntityService.SendAllDeviceSyncFaceLibrary();
            }
            if (erros != string.Empty)
            {
                erros = erros.TrimEnd('|');
                throw new Exception(erros);
            }
        }

        /// <summary>
        ///     保存拉取的身份证信息
        /// </summary>
        public WorkerIdentity PullWorkerIdentity(KtpWorkerApiGetResultContentUser ktpWorker)
        {
            var workerIdentity = DataFactory.WorkerIdentityRepository.FindByCode(ktpWorker.u_sfz);
            //不存在工人身份证创建新的
            if (workerIdentity == null)
            {
                workerIdentity = new WorkerIdentity();
            }
            //身份证正面照片
            var identityPicId = AddNewFile(ktpWorker.u_sfz_zpic);
            //身份证反面照片
            var identityBackPicId = AddNewFile(ktpWorker.u_sfz_fpic);

            //身份证头像
            var identitySfzpicId = AddNewFile(ktpWorker.u_sfzpic);

            workerIdentity.CreateType = (int)WorkerIdentityCreateType.Manual;
            workerIdentity.Code = ktpWorker.u_sfz.Trim();
            workerIdentity.Name = ktpWorker.u_realname.Trim();
            workerIdentity.Sex = (ktpWorker.u_sex != null && ktpWorker.u_sex == 2)
                ? (int)WorkerSex.Lady
                : (int)WorkerSex.Man;
            workerIdentity.Nation = IdentityNationService.GetNotNullValue(ktpWorker.u_mz.Trim());
            workerIdentity.Address = ktpWorker.u_address.Trim();
            workerIdentity.Birthday = ktpWorker.Birthday;
            workerIdentity.IssuingAuthority = ktpWorker.u_org.Trim();
            workerIdentity.ActivateTime = ktpWorker.ActivateTime;
            workerIdentity.InvalidTime = ktpWorker.InvalidTime;

            if (!string.IsNullOrEmpty(identityPicId))
                workerIdentity.PicId = identityPicId;
            if (!string.IsNullOrEmpty(identityBackPicId))
                workerIdentity.BackPicId = identityBackPicId;

            if (!string.IsNullOrEmpty(identitySfzpicId))
                workerIdentity.Base64Photo = identitySfzpicId;
            if (string.IsNullOrEmpty(workerIdentity.Id))
            {
                workerIdentity.Id = ConfigHelper.NewGuid;
                DataFactory.WorkerIdentityRepository.Add(workerIdentity);
            }
            else
            {
                if (ktpWorker.last_operation_time >= workerIdentity.ModifiedTime)
                {
                    DataFactory.WorkerIdentityRepository.Modify(workerIdentity.Id, workerIdentity);
                }
            }
            return workerIdentity;
        }

        /// <summary>
        ///保存拉取的身份证照片信息
        /// </summary>
        public string AddNewFile(string picUrl)
        {
            if (string.IsNullOrEmpty(picUrl))
            {
                return string.Empty;
            }
            var newFileMap = DataFactory.FileMapRepository.FindByUrl(picUrl);
            if (newFileMap != null)
            {
                return newFileMap.Id;
            }
            var picKey = picUrl.Substring(picUrl.LastIndexOf("/", StringComparison.Ordinal) + 1);
            //保存图片到本地
            var picPhysicalFileName = FileIoHelper.GetImageFromUrl(picUrl);
            var newId = DataFactory.FileMapRepository.Add(new FileMap
            {
                FileName = picPhysicalFileName,
                Length = 1024, //不记录大小
                QiniuKey = picKey,
                QiniuUrl = picUrl
            });
            return newId;
        }
    }
}
