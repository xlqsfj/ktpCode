using System;
using System.Web.Mvc;
using KtpAcsMiddleware.AppService.Organizations;
using KtpAcsMiddleware.Domain.Organizations;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using HtmlHelper = KtpAcsMiddleware.Infrastructure.Utilities.HtmlHelper;

namespace KtpAcsMiddleware.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly IOrgUserService _orgUserService;

        public HomeController(IOrgUserService orgUserService)
        {
            _orgUserService = orgUserService;
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            if (!IsValidAccount())
            {
                return ErrorLoginView();
            }
            return View();
        }

        public ActionResult UserProfile()
        {
            try
            {
                if (!IsValidAccount())
                    return ErrorLoginView();
                var user = _orgUserService.Get(SessionUserId);
                ViewBag.Status = ((OrgUserState) user.Status).ToEnumText();
                return View(user);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return ErrorView(ex.Message);
            }
        }

        [HttpPost]
        public string PostLogin(string loginName, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(loginName))
                {
                    return Ok(false, "用户名不允许为空。");
                }
                if (string.IsNullOrEmpty(password))
                {
                    return Ok(false, "密码不允许为空。");
                }
                var user = _orgUserService.GetByAccount(loginName);
                if (user == null)
                {
                    return Ok(false, "用户名或者密码错误。");
                }
                if (user.Password != CryptographicHelper.Hash(password))
                {
                    return Ok(false, "用户名或者密码错误。");
                }
                SessionUserId = user.Id;
                SessionUserRealName = user.Name;
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
        public string PutPassword(string password, string newPassword)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                if (string.IsNullOrEmpty(password))
                {
                    return Ok(false, "密码不允许为空。");
                }
                var user = _orgUserService.Get(SessionUserId);
                if (user == null)
                {
                    return Ok(false, "用于已被注销。");
                }
                if (user.Password != CryptographicHelper.Hash(password))
                {
                    return Ok(false, "原密码错误。");
                }
                if (string.IsNullOrEmpty(newPassword))
                {
                    return Ok(false, "新密码不允许为空。");
                }
                _orgUserService.ChangeUserPassword(user.Id, newPassword);
                return Ok();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }

        public RedirectResult Logout()
        {
            SessionUserId = null;
            SessionUserRealName = null;
            return Redirect("Login");
        }
    }
}