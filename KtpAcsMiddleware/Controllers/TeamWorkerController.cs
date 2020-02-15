using System;
using System.Linq;
using System.Web.Mvc;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.AppService.TeamWorkers;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs;
using KtpAcsMiddleware.Models;
using HtmlHelper = KtpAcsMiddleware.Infrastructure.Utilities.HtmlHelper;

namespace KtpAcsMiddleware.Controllers
{
    public class TeamWorkerController : ControllerBase
    {
        private readonly TeamWorkerJsonService _jsonService;
        private readonly ITeamService _teamService;
        private readonly IWorkerCommandService _workerCommandService;
        private readonly IWorkerQueryService _workerQueryService;

        public TeamWorkerController(
            ITeamService teamService,
            IWorkerCommandService workerQueryService,
            IWorkerQueryService workerCommandService)
        {
            _teamService = teamService;
            _workerCommandService = workerQueryService;
            _workerQueryService = workerCommandService;
            _jsonService = new TeamWorkerJsonService();
        }

        public ActionResult Index()
        {
            try
            {
                if (!IsValidAccount())
                {
                    return ErrorLoginView();
                }
                var teams = _teamService.GetAll();
                ViewBag.teams = teams;
                if (teams != null && teams.Count > 0)
                {
                    ViewBag.teamId = teams[0].Id;
                    ViewBag.teamName = teams[0].Name;
                }
                ViewBag.authenticationStates = WorkerAuthenticationState.Already.GetDescriptions();
                ViewBag.teamWorkTypes = _teamService.GetAllWorkTypes();
                ViewBag.nations = IdentityNation.Wu.GetDescriptions().Where(i => i.Key != 0);
                ViewBag.bankCardTypes = EnumHelper.GetAllValueDescriptions(typeof(BankCardType));
                ViewBag.workerSexMan = (int) WorkerSex.Man;
                ViewBag.workerSexLady = (int) WorkerSex.Lady;
                return View();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return ErrorView(ex.Message);
            }
        }

        public ActionResult TeamWorkerDetail(string id)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return ErrorLoginView();
                }
                return View(_workerQueryService.Get(id));
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return ErrorView(ex.Message);
            }
        }

        public PartialViewResult TeamWorkerMgmt()
        {
            return PartialView();
        }

        public PartialViewResult TeamMgmt()
        {
            return PartialView();
        }

        public PartialViewResult WorkerIdentityAuthentication()
        {
            return PartialView();
        }

        [HttpGet]
        public string GetTeamWorkerList(int page, int rows, string teamId, string keywords, int authenticationState)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                var result = _workerQueryService.GetPaged(page, rows, teamId, keywords,
                    (WorkerAuthenticationState) authenticationState);
                return _jsonService.GetJqGridJson(result, page, rows);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }

        [HttpGet]
        public string GetTeamWorker(string id)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                return _workerQueryService.Get(id).ToJson();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }

        [HttpPost]
        public string PutTeamWorker(TeamWorkerDto dto, string id)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                if (_workerCommandService.AnyIdentityCode(dto.IdentityCode, id))
                {
                    return Ok(false, "身份证号不允许重复");
                }
                if (_workerCommandService.AnyMobile(dto.Mobile, dto.WorkerId))
                {
                    return Ok(false, "手机号已存在，不允许重复使用");
                }
                if (string.IsNullOrEmpty(id))
                {
                    dto.WorkerCreatorId = SessionUserId;
                    var newId = _workerCommandService.Add(dto);
                    return Ok(newId);
                }
                _workerCommandService.Change(dto, id);
                return Ok();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex, $"PutTeamWorker,{dto.ToJson()}");
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }

        [HttpPost]
        public string DelTeamWorker(string id)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                _workerCommandService.Remove(id);
                LogHelper.EntryLog(SessionUserId, $"DelTeamWorker,id={id}");
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
        public string PutWorkerAuthentication(WorkerIdentityAuthenticationDto dto)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                _workerCommandService.SaveAuthenticationIdentity(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }

        [HttpGet]
        public string GetIdentityCreditScore(string code)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                var ktpIdentityService = new WorkerIdentityAspService();
                var result = ktpIdentityService.GetCreditScore(code);
                if (result != null)
                {
                    return Ok(result);
                }
                return Ok(false, "credit score is null");
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