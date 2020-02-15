using System;
using System.Web.Mvc;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.AppService.KtpLibrary;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.Models;
using HtmlHelper = KtpAcsMiddleware.Infrastructure.Utilities.HtmlHelper;

namespace KtpAcsMiddleware.Controllers
{
    public class KtpLibraryApiController : ControllerBase
    {
        private readonly IAuthenticationSyncService _authenticationSyncService;
        private readonly KtpLibraryJsonService _jsonService;
        private readonly ITeamSyncService _teamSyncService;
        private readonly IWorkerSyncService _workerSyncService;

        public KtpLibraryApiController(
            IWorkerSyncService workerSyncService,
            ITeamSyncService teamSyncService,
            IAuthenticationSyncService authenticationSyncService)
        {
            _workerSyncService = workerSyncService;
            _teamSyncService = teamSyncService;
            _authenticationSyncService = authenticationSyncService;
            _jsonService = new KtpLibraryJsonService();
        }

        [HttpGet]
        public string GetTeamSyncList(
            int page, int rows, string keywords, string workTypeId, KtpSyncState? state)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                PagedResult<TeamSyncPagedDto> result;
                if (state >= 0)
                {
                    result = _teamSyncService.GetPaged(page, rows, keywords, workTypeId, (KtpSyncState) state);
                }
                else
                {
                    result = _teamSyncService.GetPaged(page, rows, keywords, workTypeId, null);
                }
                return _jsonService.GetTeamSyncJqGridJson(result, page, rows);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }

        [HttpGet]
        public string GetWorkerSyncList(
            int page, int rows, string keywords, string teamId, int state)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                PagedResult<WorkerSyncPagedDto> result;
                if (state >= 0)
                {
                    result = _workerSyncService.GetPaged(page, rows, keywords, teamId, (KtpSyncState) state);
                }
                else
                {
                    result = _workerSyncService.GetPaged(page, rows, keywords, teamId, null);
                }
                return _jsonService.GetWorkerSyncJqGridJson(result, page, rows);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }

        [HttpGet]
        public string GetAuthenticationSyncList(
            int page, int rows, string keywords, string deviceCode, int state)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                PagedResult<AuthenticationSyncPagedDto> result;
                if (state >= 0)
                {
                    result = _authenticationSyncService.GetPaged(page, rows, keywords, deviceCode,
                        (KtpSyncState) state);
                }
                else
                {
                    result = _authenticationSyncService.GetPaged(page, rows, keywords, deviceCode, null);
                }
                return _jsonService.GetAuthenticationSyncJqGridJson(result, page, rows);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }

        [HttpPost]
        public string PutTeamSyncInitNewStatus(string id)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                _teamSyncService.ResetSyncState(id);
                return Ok();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }

        [HttpPost]
        public string PutWorkerSyncInitNewStatus(string id)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                _workerSyncService.ResetSyncState(id);
                return Ok();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }

        [HttpPost]
        public string PutAuthenticationSyncInitNewStatus(string id)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                _authenticationSyncService.ResetSyncState(id);
                return Ok();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }
    }
}