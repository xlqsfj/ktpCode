using System;
using System.Web.Mvc;
using KtpAcsMiddleware.AppService.TeamWorkers;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using HtmlHelper = KtpAcsMiddleware.Infrastructure.Utilities.HtmlHelper;

namespace KtpAcsMiddleware.Controllers
{
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public string GetTeam(string id)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                var team = _teamService.Get(id);
                return new Team
                {
                    Id = team.Id,
                    Name = team.Name,
                    WorkTypeId = team.WorkTypeId,
                    Description = team.Description
                }.ToJson();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }

        [HttpPost]
        public string PostTeam(Team dto)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                if (_teamService.Any(dto.Name, null))
                {
                    return Ok(false, @"班组名称不能重复");
                }
                _teamService.Add(dto);
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
        public string PutTeam(Team dto, string dtoId)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                if (_teamService.Any(dto.Name, dtoId))
                {
                    return Ok(false, @"班组名称不能重复");
                }
                _teamService.Change(dto, dtoId);
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
        public string DelTeam(string id)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                _teamService.Remove(id);
                LogHelper.EntryLog(SessionUserId, $"DelTeam,id={id}");
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