using System;
using System.Net.Http;
using System.Net.Http.Headers;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Asp.Base;
using KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs.Dto;

namespace KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs
{
    /// <summary>
    ///     身份证信用分服务
    /// </summary>
    public class WorkerIdentityAspService
    {
        private readonly WorkerIdentityDataService _workerIdentityDataService;

        public WorkerIdentityAspService()
        {
            _workerIdentityDataService = new WorkerIdentityDataService();
        }


        /// <summary>
        ///     获取身份证新用户分API
        /// </summary>
        public string GetCreditScoreApi
        {
            //get { return $"{ConfigHelper.KtpApiAspBaseUrl}user_xyf.asp?u_sfz="; }
            get { return $"{ConfigHelper.KtpApiAspBaseUrl}/tg/findCreditScore"; }
        }

        /// <summary>
        ///     获取工人身份证信用分
        /// </summary>
        public decimal? GetCreditScore(string identityCode)
        {
            if (identityCode == null)
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(identityCode)));
            }
            /*******************从开太平获取身份证信用分*****************************/
            var url = $"u_sfz={identityCode}";

            var apiResult = HttpClientHelper.Post(GetCreditScoreApi, url);


            var ktpIdentityApiResult = new KtpIdentityApiResult().FromJson(apiResult);
            var ktpApiResult = new KtpApiResultBase
            {
                Status = ktpIdentityApiResult.Status,
                BusStatus = ktpIdentityApiResult.BusStatus
            };
            if (KtpApiResultService.IsSuccess(ktpApiResult))
            {
                SaveLocalCreditGrade(identityCode, ktpIdentityApiResult.Content.u_xyf);
                return ktpIdentityApiResult.Content.u_xyf;
            }

            /*******************从开天平获取信用分失败，则获取本地信用分**************/
            var identity = _workerIdentityDataService.FindByCode(identityCode);
            if (identity == null || identity.CreditGrade == null)
            {
                return null;
            }
            return identity.CreditGrade;
        }

        /// <summary>
        ///     (从开太平)拉取工人身份证信用分
        /// </summary>
        public void PullCreditScore(string identityCode)
        {
            try
            {
                var url = $"u_sfz={identityCode}";



                var apiResult = HttpClientHelper.Post(GetCreditScoreApi, url);

                try
                {
                    var ktpIdentityApiResult = new KtpIdentityApiResult().FromJson(apiResult);
                    var ktpApiResult = new KtpApiResultBase
                    {
                        Status = ktpIdentityApiResult.Status,
                        BusStatus = ktpIdentityApiResult.BusStatus
                    };
                    if (KtpApiResultService.IsSuccess(ktpApiResult))
                    {
                        SaveLocalCreditGrade(identityCode, ktpIdentityApiResult.Content.u_xyf);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.ExceptionLog(ex);
                    LogHelper.Info(apiResult);
                }
            }

            catch
            {
                // ignored
                //不记录获取身份证信用分的异常
                //LogHelper.ExceptionLog(ex, $"SedCreditScore,identityCode={identityCode}");
            }
        }

        /// <summary>
        ///     保存身份证信用分到本地
        /// </summary>
        private void SaveLocalCreditGrade(string identityCode, decimal creditGrade)
        {
            try
            {
                var identity = _workerIdentityDataService.FindByCode(identityCode);
                if (identity != null)
                {
                    _workerIdentityDataService.ModifyCreditGrade(identity.Id, creditGrade);
                }
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
            }
        }
    }
}