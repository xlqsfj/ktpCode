using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Dto;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Domain.Organizations;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Search.Extensions;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Asp.Base;
using KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs.Dto;

namespace KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs.Api
{
    /// <summary>
    ///     使用开天平ASP接口进行工人拉取
    /// </summary>
    internal class KtpWorkerLoadService
    {
        private string _getTeamWorkerApiFeedback = "";
        private int _getTeamWorkerApiFeedbackCode = -1;

        /// <summary>
        ///     获取所有工人API
        /// </summary>
        private string GetTeamWorkerApi
        {
            //get { return $"{ConfigHelper.KtpApiAspBaseUrl}zj_gongren_sync.asp?pro_id={ConfigHelper.ProjectId}"; }
            get { return $"{ConfigHelper.KtpApiAspBaseUrl}/tg/findGongrenfo"; }
        }

        /// <summary>
        ///     拉取所有工人
        /// </summary>
        public void PullWorkers()
        {
            var ktpAllWorkers = GetKtpWorkers();
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
                        $"{erros}Message={ex.Message},StackTrace={ex.StackTrace},teamThirdPartyId={teamThirdPartyId},localTeamId={localTeam.Id}|";
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
                            FeedbackCode = _getTeamWorkerApiFeedbackCode,
                            Feedback = _getTeamWorkerApiFeedback,
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
                            if (ktpWorker.worker_state == 4)
                            {
                                //先下拉添加后删除(弃用此逻辑=忽略掉开太平已经被删除且本地不存在的数据)
                                //localWorker.WorkerSync = workerSync;
                                //var newWorker = Mapper.Map<Worker>(localWorker);
                                //ClientFactory.WorkerCommandRepository.Add(newWorker);
                                //ClientFactory.WorkerCommandRepository.Delete(localWorker.Id);
                                //workerSync.Id = localWorker.Id;
                                //workerSync.Type = (int) KtpSyncType.PullDelete;
                                //ClientFactory.WorkerSyncRepository.Modify(localWorker.Id, workerSync);

                                //忽略掉开太平已经被删除且本地不存在的数据
                                continue;
                            }
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
            if (workerIdentity == null)
            {
                workerIdentity = new WorkerIdentity();
            }

            var identityPicId = AddNewFile(ktpWorker.u_sfz_zpic);
            var identityBackPicId = AddNewFile(ktpWorker.u_sfz_fpic);

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
            workerIdentity.PicId = identityPicId;
            workerIdentity.BackPicId = identityBackPicId;
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
        ///     保存拉取的身份证照片信息
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

        /// <summary>
        ///     获取开天平指定工人
        /// </summary>
        public KtpWorkerApiGetResultContentUser GetKtpWorker(int ktpWorkerId)
        {
            var ktpWorkers = GetKtpWorkers();
            if (ktpWorkers == null)
            {
                return null;
            }
            return ktpWorkers.FirstOrDefault(i => i.user_id == ktpWorkerId);
        }

        /// <summary>
        ///     从云端获取开太平所有工人(API调用位置)
        /// </summary>
        public IList<KtpWorkerApiGetResultContentUser> GetKtpWorkers()
        {
            IList<KtpWorkerApiGetResultContentUser> ktpWorkers = new List<KtpWorkerApiGetResultContentUser>();
            var localTeams = DataFactory.TeamRepository.FindAll().ToList();
            foreach (var localTeam in localTeams)
            {
                if (localTeam.TeamSync == null)
                {
                    continue;
                }
                var teamThirdPartyId = localTeam.TeamSync.ThirdPartyId;
                var url =
                    $"pro_id={ConfigHelper.ProjectId}&po_id={teamThirdPartyId}&sgin={CryptographicHelper.GetKtpSgin(teamThirdPartyId)}";
                string apiResult = null;
                try
                {
                    apiResult = HttpClientHelper.Post(GetTeamWorkerApi, url);
                    var ktpWorkerApiResult = new KtpWorkerApiGetResult().FromJson(apiResult);
                    var ktpApiResult = new KtpApiResultBase
                    {
                        Status = ktpWorkerApiResult.Status,
                        BusStatus = ktpWorkerApiResult.BusStatus
                    };
                    if (KtpApiResultService.IsSuccess(ktpApiResult))
                    {
                        if (ktpWorkerApiResult.Content.user_list == null)
                        {
                            //开太平当前班组没人则pass
                            //这里的判断几乎是没用的，因为KtpApiResultService.IsSuccess通过就代表会有工人
                            //当前过滤判断仅作为保险起见
                            continue;
                        }
                        foreach (var ktpWorker in ktpWorkerApiResult.Content.user_list)
                        {
                            if (string.IsNullOrEmpty(ktpWorker.u_sfz) || string.IsNullOrEmpty(ktpWorker.u_realname))
                                continue;
                            if (ktpWorker.worker_state == 4)
                            {//如果一个工人存在在场或不在场就跳过

                                //ktp如果已删除，本地不存在，就跳过
                                bool isExit = DataFactory.WorkerQueryRepository.FindAnyIdentityCode(ktpWorker.u_sfz, "");
                                if (!isExit)
                                {

                                    continue;
                                }

                            }


                            ktpWorkers.Add(ktpWorker);
                        }
                        //设置api返回信息
                        _getTeamWorkerApiFeedbackCode = ktpWorkerApiResult.BusStatus.Code;
                        _getTeamWorkerApiFeedback = ktpWorkerApiResult.BusStatus.Msg;
                    }
                    else
                    {
                        if (apiResult.Contains("接口正确"))
                        {
                            //接口调整正确，但是当前班组下没有工人。pass
                            continue;
                        }
                        throw new Exception($"{MethodBase.GetCurrentMethod().Name}.IsSuccess=false");
                    }
                }
                catch
                {
                    if (apiResult == null)
                    {
                        throw;
                    }
                    LogHelper.ExceptionLog(new Exception($"url={url},apiResult={apiResult}"));
                    throw;
                }
            }
            if (ktpWorkers.Count == 0)
            {
                return null;
            }

            var ktpList = ktpWorkers.OrderBy(a => a.worker_state).DistinctBy(a => new { a.u_sfz }).ToList();

            return ktpList;
        }
    }
}