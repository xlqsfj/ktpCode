using System;
using System.Linq;
using System.Web.Mvc;
using KtpAcsMiddleware.AppService.FaceRecognition;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.Models;
using HtmlHelper = KtpAcsMiddleware.Infrastructure.Utilities.HtmlHelper;

namespace KtpAcsMiddleware.Controllers
{
    public class FaceDeviceDeletedController : ControllerBase
    {
        private readonly IFaceWorkerDeletedService _deletedService;
        private readonly FaceRecognitionDeviceWorkerJsonService _jsonService;

        public FaceDeviceDeletedController(IFaceWorkerDeletedService deletedService)
        {
            _deletedService = deletedService;
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
                var devices = _deletedService.GetDevices();
                ViewBag.devices = devices;
                if (devices != null && devices.Count > 0)
                {
                    ViewBag.deviceId = devices[0].Id;
                    ViewBag.activeMenuulName = devices[0].Code;
                }
                ViewBag.states = FaceWorkerState.New.GetDescriptions()
                    .Where(i => i.Key >= (int) FaceWorkerState.NewDel).ToArray();
                return View("../FaceRecognition/DeletedList");
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return ErrorView(ex.Message);
            }
        }

        [HttpGet]
        public string GetWorkerList(int page, int rows, string deviceId, string keywords, int state)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                var result = _deletedService.GetPaged(page, rows, deviceId, keywords, state);
                return _jsonService.GetJqGridJson(result, page, rows);
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