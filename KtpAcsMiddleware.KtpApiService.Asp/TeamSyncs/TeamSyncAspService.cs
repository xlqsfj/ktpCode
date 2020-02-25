using System;
using System.Linq;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Asp.Base;
using KtpAcsMiddleware.KtpApiService.Asp.TeamSyncs.Api;

namespace KtpAcsMiddleware.KtpApiService.Asp.TeamSyncs
{
    /// <summary>
    ///     班组同步服务统一入口
    /// </summary>
    public class TeamSyncAspService
    {
        private readonly KtpTeamLoadService _ktpTeamLoadService;
        private readonly KtpTeamUpService _ktpTeamUpService;

        public TeamSyncAspService()
        {
            _ktpTeamLoadService = new KtpTeamLoadService();
            _ktpTeamUpService = new KtpTeamUpService();
        }

        /// <summary>
        ///     同步所有班组(忽略异常)
        /// </summary>
        public void SyncTeamsIgnoreEx(bool isLoadKtpData = false)
        {
            if (!isLoadKtpData)
            {
                isLoadKtpData = ConfigHelper.IsLoadKtpData;
            }
            if (isLoadKtpData)
            {
                PullTeamsIgnoreEx();
                LogHelper.Info(@"从开太平同步班组完成......");
            }
            PushNewTeamsIgnoreEx();
            LogHelper.Info(@"添加班组到开太平完成......");
            PushEditTeamsIgnoreEx();
            LogHelper.Info(@"编辑班组到开太平完成......");
        }

        /// <summary>
        ///     同步所有班组
        /// </summary>
        public void SyncTeams(bool isLoadKtpData = false)
        {
            if (!isLoadKtpData)
            {
                isLoadKtpData = ConfigHelper.IsLoadKtpData;
            }
            if (isLoadKtpData)
            {
                PullTeams();
            }
            PushNewTeams();
            PushEditTeams();
        }

        /// <summary>
        ///     拉取所有班组
        /// </summary>
        public void PullTeams()
        {
            _ktpTeamLoadService.LoadTeams();
        }

        /// <summary>
        ///     拉取所有班组(忽略异常)
        /// </summary>
        public void PullTeamsIgnoreEx()
        {
            try
            {
                _ktpTeamLoadService.LoadTeams();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
            }
        }

        /// <summary>
        ///     拉取班组:单个拉取，直接以云端为主覆盖本地
        /// </summary>
        public void PullTeam(string teamId)
        {
            if (string.IsNullOrEmpty(teamId))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(teamId)));
            }
            //获取班组
            var team = DataFactory.TeamRepository.Find(teamId);
            if (team.TeamSync == null || team.TeamSync.ThirdPartyId <= 0)
            {
                throw new NotFoundException("当前班组无云端信息");
            }
            _ktpTeamLoadService.PullTeam(team, team.TeamSync.ThirdPartyId);
        }

        /// <summary>
        ///     推送所有新添加班组(忽略异常)
        /// </summary>
        public void PushNewTeamsIgnoreEx()
        {
            try
            {
                PushNewTeams();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
            }
        }

        /// <summary>
        ///     推送所有新添加班组
        /// </summary>
        public void PushNewTeams()
        {
            //获取新添加状态的班组
            var searchCriteria = new SearchCriteria<Team>();
            searchCriteria.AddFilterCriteria(t => t.TeamSync == null || t.TeamSync.Status == (int)KtpSyncState.NewAdd);
            var newTeams = DataFactory.TeamRepository.Find(searchCriteria).ToList();
            if (newTeams.Count == 0)
            {
                return;
            }
            LogHelper.Info($"PushNewTeams newTeams.Count={newTeams.Count}");
            //遍历并执行推送
            var erros = string.Empty;
            foreach (var newTeam in newTeams)
            {
                try
                {
                    _ktpTeamUpService.PushNewTeam(newTeam.Name, newTeam.TeamWorkType.Value, newTeam.Id);
                }
                catch (Exception ex)
                {
                    erros = $"{erros}Message={ex.Message},StackTrace={ex.StackTrace},id={newTeam.Id}|";
                }
            }
            if (erros != string.Empty)
            {
                erros = erros.TrimEnd('|');
                throw new Exception(erros);
            }
        }
        /// <summary>
        ///     推送所有新添加班组
        /// </summary>
        public void PushNewTeams(string  currentId)
        {
            //获取新编辑状态的班组
            var searchCriteria = new SearchCriteria<Team>();
            searchCriteria.AddFilterCriteria(
                t => t.TeamSync != null && t.TeamSync.Status == (int)KtpSyncState.NewEdit);
            var editTeams = DataFactory.TeamRepository.Find(searchCriteria).ToList();
            if (editTeams.Count == 0)
            {
                return;
            }
            LogHelper.Info($"PushEditTeams newTeams.Count={editTeams.Count}");
            var erros = string.Empty;
            //遍历并执行推送
            foreach (var editTeam in editTeams)
            {
                try
                {
                    //_ktpTeamUpService.PushEditTeam(
                    //    editTeam.TeamSync.ThirdPartyId, editTeam.Name, editTeam.TeamWorkType.Value, editTeam.Id);
                    _ktpTeamUpService.PushNewTeam(editTeam.Name, editTeam.TeamWorkType.Value, editTeam.Id,false, editTeam.TeamSync.ThirdPartyId);
                }
                catch (Exception ex)
                {
                    erros = $"{erros}Message={ex.Message},StackTrace={ex.StackTrace},id={editTeam.Id}|";
                }
            }
            if (erros != string.Empty)
            {
                erros = erros.TrimEnd('|');
                throw new Exception(erros);
            }
        }
        public void SynCurrentTeams(string teamName, int workTypeValue, string Id)
        {
            var erros = string.Empty;

            try
            {
                _ktpTeamUpService.PushNewTeam(teamName, workTypeValue, Id);
            }
            catch (Exception ex)
            {
                erros = $"{erros}Message={ex.Message},StackTrace={ex.StackTrace},id={Id}|";
            }
        }
        /// <summary>
        ///推送所有新编辑班组(忽略异常)
        /// </summary>
        public void PushEditTeamsIgnoreEx()
        {
            try
            {
                PushEditTeams();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
            }
        }

        /// <summary>
        ///     推送所有新编辑班组
        /// </summary>
        public void PushEditTeams()
        {
            //获取新编辑状态的班组
            var searchCriteria = new SearchCriteria<Team>();
            searchCriteria.AddFilterCriteria(
                t => t.TeamSync != null && t.TeamSync.Status == (int)KtpSyncState.NewEdit);
            var editTeams = DataFactory.TeamRepository.Find(searchCriteria).ToList();
            if (editTeams.Count == 0)
            {
                return;
            }
            LogHelper.Info($"PushEditTeams newTeams.Count={editTeams.Count}");
            var erros = string.Empty;
            //遍历并执行推送
            foreach (var editTeam in editTeams)
            {
                try
                {
                    _ktpTeamUpService.PushEditTeam(
                        editTeam.TeamSync.ThirdPartyId, editTeam.Name, editTeam.TeamWorkType.Value, editTeam.Id);
                }
                catch (Exception ex)
                {
                    erros = $"{erros}Message={ex.Message},StackTrace={ex.StackTrace},id={editTeam.Id}|";
                }
            }
            if (erros != string.Empty)
            {
                erros = erros.TrimEnd('|');
                throw new Exception(erros);
            }
        }

        /// <summary>
        ///     推送班组:单个推送，直接以本地为主覆盖云端
        /// </summary>
        public void PushTeam(string teamId)
        {
            if (string.IsNullOrEmpty(teamId))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(teamId)));
            }
            //获取班组
            var team = DataFactory.TeamRepository.Find(teamId);
            if (team.TeamSync == null || team.TeamSync.ThirdPartyId <= 0)
            {
                //执行推送添加
                _ktpTeamUpService.PushNewTeam(team.Name, team.TeamWorkType.Value, team.Id);
                return;
            }
            //执行推送更新
            _ktpTeamUpService.PushEditTeam(
                team.TeamSync.ThirdPartyId, team.Name, team.TeamWorkType.Value, team.Id);
        }

        /// <summary>
        ///     推送所有出现异常的班组
        /// </summary>
        public void PushExceptionTeams()
        {
            var erros = string.Empty;
            //推送添加异常的班组处理
            var searchCriteria = new SearchCriteria<Team>();
            searchCriteria.AddFilterCriteria(
                t => t.TeamSync != null && t.TeamSync.Status == (int)KtpSyncState.Fail
                     && t.TeamSync.Type == (int)KtpSyncType.PushAdd);
            var exceptionTeams = DataFactory.TeamRepository.Find(searchCriteria).ToList();
            foreach (var exceptionTeam in exceptionTeams)
            {
                try
                {
                    _ktpTeamUpService.PushNewTeam(
                        exceptionTeam.Name, exceptionTeam.TeamWorkType.Value, exceptionTeam.Id, true);
                }
                catch (Exception ex)
                {
                    erros = $"{erros}Message={ex.Message},StackTrace={ex.StackTrace},id={exceptionTeam.Id}|";
                }
            }
            //推送编辑异常的班组处理
            searchCriteria = new SearchCriteria<Team>();
            searchCriteria.AddFilterCriteria(
                t => t.TeamSync != null && t.TeamSync.Status == (int)KtpSyncState.Fail
                     && t.TeamSync.Type == (int)KtpSyncType.PushEdit);
            exceptionTeams = DataFactory.TeamRepository.Find(searchCriteria).ToList();
            foreach (var exceptionTeam in exceptionTeams)
            {
                try
                {
                    _ktpTeamUpService.PushEditTeam(exceptionTeam.TeamSync.ThirdPartyId,
                        exceptionTeam.Name, exceptionTeam.TeamWorkType.Value, exceptionTeam.Id, true);
                }
                catch (Exception ex)
                {
                    erros = $"{erros}Message={ex.Message},StackTrace={ex.StackTrace},id={exceptionTeam.Id}|";
                }
            }
            //推送删除异常的班组处理
            searchCriteria = new SearchCriteria<Team>();
            searchCriteria.AddFilterCriteria(
                t => t.TeamSync != null && t.TeamSync.Status == (int)KtpSyncState.Fail
                     && t.TeamSync.Type == (int)KtpSyncType.PushDelete);
            exceptionTeams = DataFactory.TeamRepository.Find(searchCriteria).ToList();
            foreach (var exceptionTeam in exceptionTeams)
            {
                try
                {
                    _ktpTeamUpService.PushDeleteTeam(exceptionTeam.TeamSync.ThirdPartyId,
                        exceptionTeam.Name, exceptionTeam.TeamWorkType.Value, exceptionTeam.Id, true);
                }
                catch (Exception ex)
                {
                    erros = $"{erros}Message={ex.Message},StackTrace={ex.StackTrace},id={exceptionTeam.Id}|";
                }
            }
            if (erros != string.Empty)
            {
                erros = erros.TrimEnd('|');
                throw new Exception(erros);
            }
        }
    }
}