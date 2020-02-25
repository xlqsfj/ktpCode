using System;
using System.Reflection;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Asp.AuthenticationSyncs.Dto;
using KtpAcsMiddleware.KtpApiService.Asp.Base;

namespace KtpAcsMiddleware.KtpApiService.Asp.AuthenticationSyncs
{
    /// <summary>
    ///     使用开天平ASP接口进行考勤同步
    /// </summary>
    internal class KtpAuthService
    {
        public static string AddAuthenticationApi
        {
            //get { return $"{ConfigHelper.KtpApiAspBaseUrl}kaoqin.asp?pro_id={ConfigHelper.ProjectId}"; }
            get { return $"{ConfigHelper.KtpApiAspBaseUrl}/tg/addKaoqin"; }
        }

        public void AddAuthentication(KtpAuthApiResultParameters parameters, string sourceId)
        {
            string url = null;
            string apiResult = null;
            try
            {       //上传考勤数据到云端
                url = $"pro_id={ConfigHelper.ProjectId}&user_id={parameters.user_id}&k_state={parameters.k_state}&k_pic={parameters.k_pic}&clock_time={FormatHelper.GetIsoDateTimeString(parameters.clock_time)}";

                //url = $"pro_id={ConfigHelper.ProjectId}&user_id={parameters.user_id}&k_state=2&k_pic={parameters.k_pic}&clock_time={FormatHelper.GetIsoDateTimeString(DateTime.Now)} ";
                apiResult = HttpClientHelper.Post(AddAuthenticationApi, url);
                //返回值处理,本地保存
                var ktpAuthResultApiResult = new KtpAuthApiResult().FromJson(apiResult);
                var ktpApiResult = new KtpApiResultBase
                {
                    Status = ktpAuthResultApiResult.Status,
                    BusStatus = ktpAuthResultApiResult.BusStatus
                };
                if (KtpApiResultService.IsSuccess(ktpApiResult))
                {
                    DataFactory.AuthenticationSyncRepository.Save(new ZmskAuthenticationSync
                    {
                        Id = sourceId,
                        ProjectId = ConfigHelper.ProjectId,
                        ThirdPartyWorkerId = parameters.user_id,
                        ClockType = parameters.k_state,
                        ClockPic = parameters.k_pic,
                        Status = (int)KtpSyncState.Success,
                        FeedbackCode = ktpAuthResultApiResult.BusStatus.Code,
                        Feedback = ktpAuthResultApiResult.BusStatus.Msg,
                        CreateTime = DateTime.Now,
                        ModifiedTime = DateTime.Now
                    });
                }
                else
                {
                    throw new Exception($"{MethodBase.GetCurrentMethod().Name}.IsSuccess=false");
                }
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