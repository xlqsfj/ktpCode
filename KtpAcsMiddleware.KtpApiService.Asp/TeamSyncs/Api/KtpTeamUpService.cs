using System;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Asp.Base;
using KtpAcsMiddleware.KtpApiService.Asp.TeamSyncs.Dto;

namespace KtpAcsMiddleware.KtpApiService.Asp.TeamSyncs.Api
{
    /// <summary>
    ///     使用开天平ASP接口进行班组推送
    /// </summary>
    internal class KtpTeamUpService
    {
        /// <summary>
        ///     获取班组Api模板
        /// </summary>
        public static string GetTeamIdApi
        {
            //get { return $"{ConfigHelper.KtpApiAspBaseUrl}organ_info.asp?pro_id={ConfigHelper.ProjectId}&po_name="; }
            get { return $"{ConfigHelper.KtpApiAspBaseUrl}/tg/findOrganInfo?pro_id={ConfigHelper.ProjectId}&po_name="; }
        }

        /// <summary>
        ///     添加班组Api模板
        /// </summary>
        public static string AddTeamApi
        {
            //get { return $"{ConfigHelper.KtpApiAspBaseUrl}zj_organ_add.asp?pro_id={ConfigHelper.ProjectId}"; }
            get { return $"{ConfigHelper.KtpApiAspBaseUrl}/tg/addOrganByTg"; }
        }

        /// <summary>
        ///     编辑班组Api模板
        /// </summary>
        public static string EditTeamApi
        {
            //get { return $"{ConfigHelper.KtpApiAspBaseUrl}zj_organ_edit.asp?pro_id={ConfigHelper.ProjectId}"; }
            get { return $"{ConfigHelper.KtpApiAspBaseUrl}/tg/editOrganByTg"; }
        }

        /// <summary>
        ///     删除班组Api模板
        /// </summary>
        public static string DelTeamApi
        {
            //get { return $"{ConfigHelper.KtpApiAspBaseUrl}zj_organ_del.asp?pro_id={ConfigHelper.ProjectId}"; }
            get { return $"{ConfigHelper.KtpApiAspBaseUrl}/tg/delOrganByTg"; }
        }

        /// <summary>
        ///     推送班组，存在则编辑，不存在则添加
        ///     USE API
        /// </summary>
        public void PushNewTeam(
            string teamName, int workTypeValue, string sourceId, bool isIgnoreExLog = false,int?  teamId=null)
        {
            string url = null;
            string apiResult = null;
            try
            {
                //根据班组名称获取云端班组
                url = $"{GetTeamIdApi}{teamName}";
                //apiResult = HttpClientHelper.Post(url);
                //返回值处理,推送编辑或者推送添加
                //var ktpTeamApiResult = new KtpTeamPushApiResult().FromJson(apiResult);
                //var ktpApiResult = new KtpApiResultBase
                //{
                //    Status = ktpTeamApiResult.Status,
                //    BusStatus = ktpTeamApiResult.BusStatus
                //};
                //var teamId = 0;
                //if (KtpApiResultService.IsSuccess(ktpApiResult))
                //{
                //    if (ktpTeamApiResult.Content == null || ktpTeamApiResult.Content.po_id <= 0)
                //    {
                //        throw new Exception(
                //            "isSuccess && (ktpTeamApiResult.Content == null || ktpTeamApiResult.Content.po_id <= 0)");
                //    }
                //    //如果team已存在，则执行编辑
                //    teamId = ktpTeamApiResult.Content.po_id;
                //    PushEditTeam(teamId, teamName, workTypeValue, sourceId);
                //}
              
                    //如果不存在(teamId==0)，则添加
                    PushAddTeam(teamName, workTypeValue, sourceId,false,teamId);
              
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
        ///     推送添加(用于PushNewTeam的添加动作)
        ///     USE API
        /// </summary>
        private void PushAddTeam(
            string teamName, int workTypeValue, string sourceId, bool isIgnoreExLog = false,int?  teamId=null)
        {
            string url = null;
            string apiResult = null;
            try
            {
                //添加云端班组
                url = $"pro_id={ConfigHelper.ProjectId}&po_name={teamName}&po_gzid={workTypeValue}&po_id={teamId}";
                apiResult = HttpClientHelper.Post(AddTeamApi, url);
                //返回值处理,本地保存
                var ktpTeamApiResult = new KtpTeamPushApiResult().FromJson(apiResult);
                var ktpApiResult = new KtpApiResultBase
                {
                    Status = ktpTeamApiResult.Status,
                    BusStatus = ktpTeamApiResult.BusStatus
                };
                SaveTeamSync(sourceId, ktpApiResult, ktpTeamApiResult, KtpSyncType.PushAdd);
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
        ///     推送编辑
        ///     USE API
        /// </summary>
        public void PushEditTeam(
            int teamId, string teamName, int workTypeValue, string sourceTeamId, bool isIgnoreExLog = false)
        {
            string url = null;
            string apiResult = null;
            try
            {
                //编辑云端班组
                url = $"pro_id={ConfigHelper.ProjectId}&po_id={teamId}&po_name={teamName}&po_gzid={workTypeValue}";
                apiResult = HttpClientHelper.Post(EditTeamApi, url);
                //返回值处理,本地保存
                var ktpTeamApiResult = new KtpTeamPushApiResult().FromJson(apiResult);
                var ktpApiResult = new KtpApiResultBase
                {
                    Status = ktpTeamApiResult.Status,
                    BusStatus = ktpTeamApiResult.BusStatus
                };
                SaveTeamSync(sourceTeamId, ktpApiResult, ktpTeamApiResult, KtpSyncType.PushEdit);
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
        ///     推送删除(暂时不用-撤销删除班组的支持)
        /// </summary>
        public void PushDeleteTeam(
            int teamId, string teamName, int workTypeValue, string sourceId, bool isIgnoreExLog = false)
        {
            string url = null;
            string apiResult = null;
            try
            {
                //删除云端班组
                url = $"pro_id={ConfigHelper.ProjectId}&po_id={teamId}&po_name={teamName}&po_gzid={workTypeValue}";
                apiResult = HttpClientHelper.Post(DelTeamApi, url);
                //返回值处理,本地保存
                var ktpTeamApiResult = new KtpTeamPushApiResult().FromJson(apiResult);
                var ktpApiResult = new KtpApiResultBase
                {
                    Status = ktpTeamApiResult.Status,
                    BusStatus = ktpTeamApiResult.BusStatus
                };
                SaveTeamSync(sourceId, ktpApiResult, ktpTeamApiResult, KtpSyncType.PushDelete);
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
        ///     保存本地的班组同步记录
        /// </summary>
        private void SaveTeamSync(
            string sourceId, KtpApiResultBase ktpApiResult, KtpTeamPushApiResult ktpTeamApiResult,
            KtpSyncType syncType)
        {
            var isSuccess = KtpApiResultService.IsSuccess(ktpApiResult);
            if (isSuccess && (ktpTeamApiResult.Content == null || ktpTeamApiResult.Content.po_id <= 0))
            {
                throw new Exception(
                    "isSuccess && (ktpTeamApiResult.Content == null || ktpTeamApiResult.Content.po_id <= 0)");
            }
            var teamSync = DataFactory.TeamSyncRepository.FirstOrDefault(sourceId);
            var newSync = new TeamSync
            {
                Id = sourceId,
                ThirdPartyId = ktpTeamApiResult.Content?.po_id ?? 0,
                Type = (int)syncType,
                Status = isSuccess ? (int)KtpSyncState.Success : (int)KtpSyncState.Fail,
                FeedbackCode = ktpTeamApiResult.BusStatus.Code,
                Feedback = ktpTeamApiResult.BusStatus.Msg
            };
            if (teamSync != null)
            {
                DataFactory.TeamSyncRepository.Modify(sourceId, newSync);
            }
            else
            {
                DataFactory.TeamSyncRepository.Add(newSync);
            }
        }
    }
}