using System;
using System.Web.Mvc;
using KtpAcsMiddleware.AppService.Organizations;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Organizations;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.Models;
using HtmlHelper = KtpAcsMiddleware.Infrastructure.Utilities.HtmlHelper;

namespace KtpAcsMiddleware.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly OrganizationJsonService _orgJsonService;
        private readonly IOrgUserService _userService;

        public UserController(IOrgUserService userService, OrganizationJsonService orgJsonService)
        {
            _userService = userService;
            _orgJsonService = orgJsonService;
        }

        public ActionResult UserList()
        {
            try
            {
                if (!IsValidAccount())
                    return ErrorLoginView();
                return View();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return ErrorView(ex.Message);
            }
        }

        public ActionResult UserDetail(string id)
        {
            try
            {
                if (!IsValidAccount())
                    return ErrorLoginView();
                if (!string.IsNullOrEmpty(id))
                {
                    var user = _userService.Get(id);

                    ViewData["userId"] = user.Id;
                    ViewData["status"] = user.Status;
                    ViewData["statusName"] = ((OrgUserState) user.Status).ToEnumText();
                    ViewData["account"] = user.Account;
                    ViewData["name"] = user.Name;
                    ViewData["code"] = user.Code;
                    ViewData["mobile"] = user.Mobile;
                    ViewData["mail"] = user.Mail;
                }
                return View();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return ErrorView(ex.Message);
            }
        }

        /// <summary>
        ///     获取用户列表
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="rows">每页显示行数</param>
        /// <param name="keywords">模糊条件</param>
        /// <param name="userStatus">用户状态</param>
        /// <returns></returns>
        [HttpGet]
        public string GetUserList(int page, int rows, string keywords, int userStatus)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                var result = _userService.GetPaged(page, rows, userStatus, keywords);
                return _orgJsonService.GetJqGridJson(result, page, rows);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                return Ok(false, result);
            }
        }

        [HttpPost]
        public string PutUser(FormCollection form)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                var adminUser = OrgUserDataService.FindAdmin();
                if (SessionUserId != adminUser.Id)
                {
                    return Ok(false, "当前用户无权限");
                }
                var dto = new OrgUser
                {
                    Account = form["account"],
                    Name = form["name"],
                    Code = form["code"],
                    Mobile = form["mobile"],
                    Mail = form["mail"]
                };
                if (!string.IsNullOrEmpty(form["userId"]))
                {
                    dto.Id = form["userId"];
                }
                if (!string.IsNullOrEmpty(form["status"]))
                {
                    dto.Status = int.Parse(form["status"]);
                }
                if (!string.IsNullOrEmpty(form["birthday"]))
                {
                    dto.Birthday = FormatHelper.GetNonNullIsoDateValue(form["birthday"]);
                }
                if (string.IsNullOrEmpty(dto.Id))
                {
                    _userService.AddUser(dto);
                }
                else
                {
                    _userService.ChangeUser(dto);
                }
                return Ok($"{dto.Id},{ConfigHelper.DefaultUserPwd}");
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                var result = HtmlHelper.Encode(ex.Message);
                if (result.Contains("account must be unique"))
                {
                    return Ok(false, "用户登录名必需唯一");
                }
                if (result.Contains("code must be unique"))
                {
                    return Ok(false, "用户编号必需唯一");
                }
                return Ok(false, result);
            }
        }

        [HttpPost]
        public string PutUserCancle(string id)
        {
            try
            {
                if (!IsValidAccount())
                {
                    return OkLoginError();
                }
                if (string.IsNullOrEmpty(id))
                {
                    return Ok(false, "用户ID不允许为空。");
                }
                _userService.CancleUser(id);
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