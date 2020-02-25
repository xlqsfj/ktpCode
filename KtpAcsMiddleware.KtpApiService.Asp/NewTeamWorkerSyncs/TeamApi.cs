using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Asp.Base;
using KtpAcsMiddleware.KtpApiService.Asp.TeamSyncs.Dto;

namespace KtpAcsMiddleware.KtpApiService.Asp.NewTeamWorkerSyncs
{
    public class TeamApi
    {


        private string _getProjectTeamsApiFeedback = "";
        private int _getProjectTeamsApiFeedbackCode = -1;
        /// <summary>
        ///     拉取班组Api模板
        /// </summary>
        private string GetProjectTeamsApi
        {
            //get { return $"{ConfigHelper.KtpApiAspBaseUrl}zj_organ_info.asp?pro_id={ConfigHelper.ProjectId}&po_name="; }
            get { return $"{ConfigHelper.KtpApiAspBaseUrl}/tg/findOrganInfo"; }
        }
        /// <summary>
        ///     拉取所有班组
        /// </summary>
        public IList<KtpTeamGetApiResultContentPo> LoadTeams()
        {
            IList<KtpTeamGetApiResultContentPo> ktpTeams = GetKtpTeams();
            if (ktpTeams == null || ktpTeams.Count == 0)
            {
                return ktpTeams;
            }
            var localTeams = DataFactory.TeamRepository.FindAll().ToList();
            var localTeamWorkTypes = DataFactory.TeamWorkTypeRepository.FindAll();
            var erros = string.Empty;
            foreach (var ktpTeam in ktpTeams)
            {
                try
                {
                    var workType = localTeamWorkTypes.FirstOrDefault(i => i.Value == ktpTeam.po_gzid);
                    if (workType == null)
                    {
                        continue;
                    }
                    var localTeam = localTeams.FirstOrDefault(
                        i => i.TeamSync != null && i.TeamSync.ThirdPartyId == ktpTeam.po_id);
                    var newTeamSync = new TeamSync
                    {
                        ThirdPartyId = ktpTeam.po_id,
                        Type = (int)KtpSyncType.PullAdd,
                        Status = (int)KtpSyncState.Success,
                        FeedbackCode = _getProjectTeamsApiFeedbackCode,
                        Feedback = _getProjectTeamsApiFeedback,
                        CreateTime = DateTime.Now,
                        ModifiedTime = DateTime.Now
                    };
                    if (localTeam == null)
                    {
                        /*******如果本地无数据：执行添加************************************/
                        var newTeam = new Team
                        {
                            Id = ConfigHelper.NewGuid,
                            ProjectId = ConfigHelper.ProjectId,
                            Name = ktpTeam.po_name.Trim(),
                            WorkTypeId = workType.Id,
                            Description = null
                        };
                        newTeamSync.Id = newTeam.Id;
                        newTeam.TeamSync = newTeamSync;
                        DataFactory.TeamRepository.Add(newTeam);
                        continue;
                        /********end********************************************************/
                    }
                    if (ktpTeam.last_operation_time != null &&
                        ktpTeam.last_operation_time > localTeam.ModifiedTime)
                    {
                        /*******如果本地存在且更新时间小于服务器更新时间：执行更新*********/
                        localTeam.Name = ktpTeam.po_name.Trim();
                        localTeam.WorkTypeId = workType.Id;
                        DataFactory.TeamRepository.Modify(localTeam, localTeam.Id);
                        /*******保存同步信息(TeamSync)*************************************/
                        newTeamSync.Id = localTeam.Id;
                        newTeamSync.Type = (int)KtpSyncType.PullEdit;
                        if (localTeam.TeamSync == null)
                        {
                            //本地无同步信息时添加同步信息
                            DataFactory.TeamSyncRepository.Add(newTeamSync);
                        }
                        else
                        {
                            //本地有同步信息时更新同步信息
                            DataFactory.TeamSyncRepository.Modify(localTeam.Id, newTeamSync);
                        }
                    }
                }
                catch (Exception ex)
                {
                    erros =
                        $"{erros}Message={ex.Message},StackTrace={ex.StackTrace},ktpTeam={ktpTeam.ToJson()}|";
                }
       
            }
         
            if (erros != string.Empty)
            {
                erros = erros.TrimEnd('|');
                throw new Exception(erros);
            }
            return ktpTeams;
        }
        /// <summary>
        ///     获取所有开太平（当前项目）班组信息(API调用位置)
        /// </summary>
        private IList<KtpTeamGetApiResultContentPo> GetKtpTeams()
        {
            var url = GetProjectTeamsApi;
            string apiResult = null;
            try
            {
                apiResult = HttpClientHelper.Post(url, $"pro_id={ConfigHelper.ProjectId}");
                var ktpTeamApiResult = new KtpTeamGetApiResult().FromJson(apiResult);
                var ktpApiResult = new KtpApiResultBase
                {
                    Status = ktpTeamApiResult.Status,
                    BusStatus = ktpTeamApiResult.BusStatus
                };
                if (KtpApiResultService.IsSuccess(ktpApiResult))
                {
                    var ktpTeams = ktpTeamApiResult.Content.po_list;
                    if (ktpTeams == null || ktpTeams.Count == 0)
                    {
                        return null;
                    }
                    //设置api返回信息并返回api班组信息
                    _getProjectTeamsApiFeedbackCode = ktpTeamApiResult.BusStatus.Code;
                    _getProjectTeamsApiFeedback = ktpTeamApiResult.BusStatus.Msg;
                    return ktpTeams;
                }
                throw new Exception($"{MethodBase.GetCurrentMethod().Name}.IsSuccess=false");
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
    }
}
