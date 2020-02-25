using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Dto;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Asp.Base;
using KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs.Api;
using KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs.Dto;

namespace KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs
{
    /// <summary>
    ///     单个推送或拉取工人服务(手动触发)
    /// </summary>
    public class WorkerSyncAspDesignatedService
    {
        private readonly KtpWorkerLoadService _ktpWorkerLoadService;
        private readonly KtpWorkerUpService _ktpWorkerUpService;

        public WorkerSyncAspDesignatedService()
        {
            _ktpWorkerLoadService = new KtpWorkerLoadService();
            _ktpWorkerUpService = new KtpWorkerUpService();
        }

        /// <summary>
        ///     拉取工人:单个拉取，直接以云端为主覆盖本地
        /// </summary>
        public void PullWorker(string workerId)
        {
            if (string.IsNullOrEmpty(workerId))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(workerId)));
            }
            //获取本地工人
            var localWorker = DataFactory.WorkerQueryRepository.Find(workerId);
            if (localWorker.WorkerSync == null || localWorker.WorkerSync.TeamThirdPartyId <= 0)
            {
                throw new NotFoundException("当前工人无云端信息");
            }
            var ktpWorker = _ktpWorkerLoadService.GetKtpWorker(localWorker.WorkerSync.ThirdPartyId);
            //更新身份证信息
            _ktpWorkerLoadService.PullWorkerIdentity(ktpWorker);
            /********使用开太平工人信息更新本地数据*****************/
            var newWorkerSyncDto = new WorkerSyncDto
            {
                Id = localWorker.Id,
                ThirdPartyId = ktpWorker.user_id,
                TeamThirdPartyId = localWorker.WorkerSync.TeamThirdPartyId,
                Type = (int) KtpSyncType.PullEdit,
                Status = (int) KtpSyncState.Success,
                FeedbackCode = 100, //默认接口正确(接口正确才会更新)
                Feedback = "正确",
                CreateTime = DateTime.Now,
                ModifiedTime = DateTime.Now
            };
            //获取云端对应本地所在班组
            var localTeamSync =
                DataFactory.TeamSyncRepository.FindByThirdPartyId(ktpWorker.po_id);
            if (localTeamSync == null)
            {
                throw new NotFoundException("云端所在班组无本地映射");
            }
            //面部照片处理
            var facePicId = _ktpWorkerLoadService.AddNewFile(ktpWorker.u_cert_pic);
            //目前没有离职一说，直接就是删除
            localWorker.Status = (int) WorkerPositionState.Zaichang;
            localWorker.Mobile = ktpWorker.u_phone.Trim();
            localWorker.Name = ktpWorker.u_realname.Trim();
            localWorker.AddressNow = ktpWorker.u_address.Trim();
            localWorker.FacePicId = facePicId;
            //开太平最后更新时间大于本地就执行更新
            localWorker.TeamId = localTeamSync.Id;
            DataFactory.WorkerCommandRepository.ModifySimple(localWorker, localWorker.Id);
            newWorkerSyncDto.Type = (int) KtpSyncType.PullEdit;

            //云端工人属于离职状态的处理
            if (ktpWorker.worker_state == 4)
            {
                //开太平数据状态为删除时，处理本地数据删除
                if (localWorker.IsDelete)
                {
                    //to本地已删除数据
                    if (localWorker.WorkerSync.Type != (int) KtpSyncType.PullDelete &&
                        localWorker.WorkerSync.Type != (int) KtpSyncType.PushDelete)
                    {
                        //设置同步状态为拉取删除
                        newWorkerSyncDto.Type = (int) KtpSyncType.PullDelete;
                    }
                    else
                    {
                        //保持原来状态
                        newWorkerSyncDto.Type = localWorker.WorkerSync.Type;
                    }
                }
                else
                {
                    //to本地未删除数据，执行删除，并设置状态为下拉删除成功
                    DataFactory.WorkerCommandRepository.Delete(
                        localWorker.Id, Mapper.Map<WorkerSync>(newWorkerSyncDto));
                    newWorkerSyncDto.Type = (int) KtpSyncType.PullDelete;
                }
            }
            else
            {
                //添加数据所有设备
                DataFactory.WorkerCommandRepository.AddToAllFaceDevice(localWorker.Id);
            }

            if (newWorkerSyncDto.Type == (int) KtpSyncType.PullEdit ||
                newWorkerSyncDto.Type == (int) KtpSyncType.PullDelete ||
                newWorkerSyncDto.Type == (int) KtpSyncType.PushDelete)
            {
                //保存同步映射数据
                var workerSync = Mapper.Map<WorkerSync>(newWorkerSyncDto);
                DataFactory.WorkerSyncRepository.Modify(localWorker.Id, workerSync);
            }
        }

        /// <summary>
        ///     推送工人：单个推送，直接以本地为主覆盖云端
        /// </summary>
        public void PushWorker(string workerId, bool isIgnoreExLog = false)
        {
            if (string.IsNullOrEmpty(workerId))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(workerId)));
            }
            //获取工人
            var worker = DataFactory.WorkerQueryRepository.Find(workerId);
            //获取班组第三方ID
            var teamSync = DataFactory.TeamSyncRepository.FirstOrDefault(worker.TeamId);
            if (teamSync == null)
            {
                throw new NotFoundException("当前工人所属班组无云端信息");
            }
            /********认证照片(面部、身份证正面、身份证背面)处理********************************************/
            if (string.IsNullOrEmpty(worker.FacePicId) ||
                string.IsNullOrEmpty(worker.WorkerIdentity.PicId) ||
                string.IsNullOrEmpty(worker.WorkerIdentity.BackPicId))
            {
                throw new NotFoundException("当前工人认证(面部、身份证正面、身份证背面)照片不全");
            }
            IList<string> fileMapIds = new List<string>();
            fileMapIds.Add(worker.FacePicId);
            fileMapIds.Add(worker.WorkerIdentity.PicId);
            fileMapIds.Add(worker.WorkerIdentity.BackPicId);
            var qiniuFileCriteria = new SearchCriteria<FileMap>();
            qiniuFileCriteria.AddFilterCriteria(t => fileMapIds.ToArray().Contains(t.Id));
            qiniuFileCriteria.AddFilterCriteria(t => t.QiniuKey != null && t.QiniuUrl != null);
            var qiniuFiles = DataFactory.FileMapRepository.Find(qiniuFileCriteria).ToList();
            //人脸识别照片Url设置
            var qiniuFacePic = qiniuFiles.FirstOrDefault(i => i.Id == worker.FacePicId);
            if (qiniuFacePic == null)
            {
                throw new NotFoundException("当前工人面部照片不存在");
            }
            var qiniuFacePicUrl = qiniuFacePic.QiniuUrl;
            //身份证正面照片Url设置
            var qiniuIdentityPic = qiniuFiles.FirstOrDefault(i => i.Id == worker.WorkerIdentity.PicId);
            if (qiniuIdentityPic == null)
            {
                throw new NotFoundException("当前工人身份证正面照片不存在");
            }
            var qiniuIdentityPicUrl = qiniuIdentityPic.QiniuUrl;
            //身份证背面照片Url设置
            var qiniuIdentityBackPic = qiniuFiles.FirstOrDefault(i => i.Id == worker.WorkerIdentity.BackPicId);
            if (qiniuIdentityBackPic == null)
            {
                throw new NotFoundException("当前工人身份证背面照片不存在");
            }
            var qiniuIdentityBackPicUrl = qiniuIdentityBackPic.QiniuUrl;

            /********设置参数、执行推送********************************************/
            var parameters =
                new KtpWorkerApiPushResultParameters
                {
                    pro_id = ConfigHelper.ProjectId,
                    u_sfzpic = qiniuIdentityPicUrl,
                    u_sfz = worker.WorkerIdentity.Code,
                    u_realname = worker.WorkerIdentity.Name,
                    po_id = teamSync.ThirdPartyId,
                    u_name = worker.Mobile,
                    u_sex = worker.WorkerIdentity.Sex == (int) WorkerSex.Man ? 1 : 2,
                    u_birthday = worker.WorkerIdentity.Birthday,
                    u_cert_pic = qiniuFacePicUrl,
                    u_mz = ((IdentityNation) worker.WorkerIdentity.Nation).ToEnumText()
                        .Replace("族", string.Empty),
                    //u_jiguan = newWorker.WorkerIdentity.Address,
                    u_address = worker.AddressNow,
                    u_sfz_zpic = qiniuIdentityPicUrl,
                    u_sfz_fpic = qiniuIdentityBackPicUrl,
                    u_start_time = worker.WorkerIdentity.ActivateTime,
                    u_expire_time = worker.WorkerIdentity.InvalidTime,
                    u_org = worker.WorkerIdentity.IssuingAuthority
                };
            _ktpWorkerUpService.PushWorker(parameters, worker.Id, isIgnoreExLog);
        }
    }
}