using System;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Asp.Base;
using KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs.Dto;

namespace KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs.Api
{
    /// <summary>
    ///     使用开天平ASP接口进行工人推送
    /// </summary>
    internal class KtpWorkerUpService
    {
        /// <summary>
        ///     添加(or编辑)工人API
        /// </summary>
        private string AddWorkerApi
        {
            //get { return $"{ConfigHelper.KtpApiAspBaseUrl}gongren_add.asp"; }
            get { return $"{ConfigHelper.KtpApiAspBaseUrl}/tg/addWorkerByTg"; }
        }

        /// <summary>
        ///     删除工人API
        /// </summary>
        private string DelWorkerApi
        {
            //get { return $"{ConfigHelper.KtpApiAspBaseUrl}gongren_del.asp?"; }
            get { return $"{ConfigHelper.KtpApiAspBaseUrl}/tg/delWorkerByTg"; }
        }

        /// <summary>
        ///     推送(添加or编辑)工人
        /// </summary>
        public void PushWorker(KtpWorkerApiPushResultParameters parameters, string sourceId, bool isIgnoreExLog = false)
        {
            var url = $"pro_id={ConfigHelper.ProjectId}&u_sfzpic={parameters.u_sfzpic}&u_sfz={parameters.u_sfz}" +
                      $"&u_realname={parameters.u_realname}&po_id={parameters.po_id}&u_name={parameters.u_name}&u_sex={parameters.u_sex}" +
                      $"&u_birthday={FormatHelper.GetIsoDateString(parameters.u_birthday)}&u_cert_pic={parameters.u_cert_pic}&u_mz={parameters.u_mz}" +
                      $"&u_address={parameters.u_address}" +
                      $"&u_sfz_zpic={parameters.u_sfz_zpic}&u_sfz_fpic={parameters.u_sfz_fpic}" +
                      $"&u_start_time={parameters.u_start_time}&u_expire_time={parameters.u_expire_time}&u_org={parameters.u_org}u_bankcard={parameters.u_bankcard}u_bank={parameters.u_bank}";
            //var url =
            //    $"{AddWorkerApi}&u_sfzpic={parameters.u_sfzpic}&u_sfz={parameters.u_sfz}" +
            //    $"&u_realname={parameters.u_realname}&po_id={parameters.po_id}&u_name={parameters.u_name}";
            string apiResult = null;
            try
            {
                apiResult = HttpClientHelper.Post(AddWorkerApi,url);
                var ktpWorkerApiResult = new KtpWorkerApiPushResult().FromJson(apiResult);
                var ktpApiResult = new KtpApiResultBase
                {
                    Status = ktpWorkerApiResult.Status,
                    BusStatus = ktpWorkerApiResult.BusStatus
                };
                SaveWorkerSync(
                    sourceId, parameters.po_id, ktpApiResult, ktpWorkerApiResult, KtpSyncType.PushAdd);
            }
            catch
            {
                if (isIgnoreExLog || apiResult == null)
                {
                    throw;
                }
                LogHelper.ExceptionLog(new Exception($"url={url},apiResult={apiResult}"));
                throw;
            }
        }

        /// <summary>
        ///     推送删除工人
        /// </summary>
        public void PushDeleteWorker(string sourceId, int teamId, int userId, bool isIgnoreExLog = false)
        {
            var url = $"po_id={teamId}&user_id={userId}";
            string apiResult = null;
            try
            {
                apiResult = HttpClientHelper.Post(DelWorkerApi,url);
                var ktpWorkerApiResult = new KtpWorkerApiPushResult().FromJson(apiResult);
                var ktpApiResult = new KtpApiResultBase
                {
                    Status = ktpWorkerApiResult.Status,
                    BusStatus = ktpWorkerApiResult.BusStatus
                };
                SaveWorkerSync(
                    sourceId, teamId, ktpApiResult, ktpWorkerApiResult, KtpSyncType.PushDelete);
            }
            catch
            {
                if (isIgnoreExLog || apiResult == null)
                {
                    throw;
                }
                LogHelper.ExceptionLog(new Exception($"url={url},apiResult={apiResult}"));
                throw;
            }
        }

        /// <summary>
        ///     本地保存工人同步信息
        /// </summary>
        private void SaveWorkerSync(
            string sourceId, int teamThirdPartyId,
            KtpApiResultBase ktpApiResult, KtpWorkerApiPushResult ktpWorkerApiResult, KtpSyncType syncType)
        {
            var isSuccess = KtpApiResultService.IsSuccess(ktpApiResult);
            if (isSuccess && (ktpWorkerApiResult.Content == null || ktpWorkerApiResult.Content.user_id <= 0))
            {
                throw new Exception("云端信息错误,无法保存映射数据");
            }
            var workerSync = DataFactory.WorkerSyncRepository.FirstOrDefault(sourceId);
            var newSync = new WorkerSync
            {
                Id = sourceId,
                ThirdPartyId = ktpWorkerApiResult.Content?.user_id ?? 0,
                TeamThirdPartyId = teamThirdPartyId,
                Type = (int) syncType,
                Status = isSuccess ? (int) KtpSyncState.Success : (int) KtpSyncState.Fail,
                FeedbackCode = ktpWorkerApiResult.BusStatus.Code,
                Feedback = ktpWorkerApiResult.BusStatus.Msg
            };
            if (workerSync != null)
            {
                DataFactory.WorkerSyncRepository.Modify(sourceId, newSync);
            }
            else
            {
                DataFactory.WorkerSyncRepository.Add(newSync);
            }
        }
    }
}