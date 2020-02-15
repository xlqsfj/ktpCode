using System;
using System.Linq;
using System.Web.Mvc;
using KtpAcsMiddleware.AppService.FaceRecognition;
using KtpAcsMiddleware.AppService.TeamWorkers;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Controllers
{
    public class KtpLibraryController : ControllerBase
    {
        private readonly IFaceDeviceService _faceDeviceService;
        private readonly ITeamService _teamService;

        public KtpLibraryController(
            IFaceDeviceService faceDeviceService,
            ITeamService teamService)
        {
            _teamService = teamService;
            _faceDeviceService = faceDeviceService;
        }

        public ActionResult TeamSyncList()
        {
            try
            {
                if (!IsValidAccount())
                {
                    return ErrorLoginView();
                }
                var workTypes = _teamService.GetAllWorkTypes();
                ViewBag.workTypes = workTypes;
                if (workTypes != null && workTypes.Count > 0)
                {
                    ViewBag.workTypeId = workTypes[0].Id;
                    ViewBag.workTypeName = workTypes[0].Name;
                }
                ViewBag.syncStates = KtpSyncState.NewAdd.GetDescriptions();
                return View();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return ErrorView(ex.Message);
            }
        }

        public ActionResult WorkerSyncList()
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
                ViewBag.syncStates = KtpSyncState.NewAdd.GetDescriptions();
                return View();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return ErrorView(ex.Message);
            }
        }

        public ActionResult AuthenticationSyncList()
        {
            try
            {
                if (!IsValidAccount())
                {
                    return ErrorLoginView();
                }
                var devices = _faceDeviceService.GetAll();
                ViewBag.devices = devices;
                if (devices != null && devices.Count > 0)
                {
                    ViewBag.deviceId = devices[0].Id;
                    ViewBag.activeMenuulName = devices[0].Code;
                }
                ViewBag.syncStates = KtpSyncState.NewAdd.GetDescriptions().Where(i => i.Key <= (int) KtpSyncState.Fail);
                return View();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return ErrorView(ex.Message);
            }
        }
    }
}