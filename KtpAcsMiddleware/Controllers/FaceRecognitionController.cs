using System;
using System.Linq;
using System.Web.Mvc;
using KtpAcsMiddleware.AppService.FaceRecognition;
using KtpAcsMiddleware.AppService.TeamWorkers;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.Models;
using HtmlHelper = KtpAcsMiddleware.Infrastructure.Utilities.HtmlHelper;

namespace KtpAcsMiddleware.Controllers
{
    public class FaceRecognitionController : ControllerBase
    {
        private readonly IFaceDeviceService _faceDeviceService;
        private readonly IFaceDeviceWorkerService _faceDeviceWorkerService;
        private readonly FaceRecognitionDeviceWorkerJsonService _jsonService;
        private readonly IWorkerCommandService _workerCommandService;

        public FaceRecognitionController(
            IFaceDeviceService faceDeviceService,
            IWorkerCommandService workerCommandService,
            IFaceDeviceWorkerService faceDeviceWorkerService)
        {
            _faceDeviceService = faceDeviceService;
            _faceDeviceWorkerService = faceDeviceWorkerService;
            _workerCommandService = workerCommandService;
            _jsonService = new FaceRecognitionDeviceWorkerJsonService();
        }

        public ActionResult Index()
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
                ViewBag.states = FaceWorkerState.New.GetDescriptions();
                return View();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return ErrorView(ex.Message);
            }
        }

        public PartialViewResult DeviceMgmt()
        {
            return PartialView();
        }

        public PartialViewResult WorkerSelectControl()
        {
            return PartialView();
        }

        /// <summary>
        ///     获取选择用户控件用户列表数据
        /// </summary>
        /// <param name="keywords">模糊条件</param>
        /// <returns></returns>
        [HttpGet]
        public string GetWorkerSelectControlUserList(string keywords)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                var workerList = _workerCommandService.GetAll();
                var result = workerList.Where(i =>
                        i.Name.Contains(keywords) || i.Identity.Code.Contains(keywords)
                        || i.Identity.Address.Contains(keywords)).OrderBy(i => i.Name)
                    .Select(item => new
                    {
                        item.Id,
                        item.Name,
                        IdentityCode = item.Identity.Code,
                        HouseRegister = item.Identity.Address
                    }).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return Ok(false, HtmlHelper.Encode(ex.Message));
            }
        }

        [HttpGet]
        public string GetDeviceWorkerList(int page, int rows, string deviceId, string keywords, int state)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                var result = _faceDeviceWorkerService.GetPaged(page, rows, deviceId, keywords, state);
                return _jsonService.GetJqGridJson(result, page, rows);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }

        [HttpPost]
        public string PostDeviceWorker(string workerId, string deviceId)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                var newDto = _faceDeviceWorkerService.Add(workerId, deviceId);
                return Ok(newDto.Id);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }

        [HttpPost]
        public string DelDeviceWorker(string id)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                _faceDeviceWorkerService.Remove(id);
                LogHelper.EntryLog(SessionUserId, $"DelDevice,id={id}");
                return Ok(id);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }

        [HttpPost]
        public string PutDeviceWorkerInitNewStatus(string id)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                _faceDeviceWorkerService.ChangeState(id, FaceWorkerState.New);
                return Ok(id);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }

        [HttpPost]
        public string PutDeviceWorkerInitNewDelStatus(string id)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                _faceDeviceWorkerService.ChangeState(id, FaceWorkerState.NewDel);
                return Ok(id);
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