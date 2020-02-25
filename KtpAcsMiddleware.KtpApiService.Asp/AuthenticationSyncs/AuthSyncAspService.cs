using System;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Asp.AuthenticationSyncs.Dto;
using KtpAcsMiddleware.KtpApiService.Asp.Base;

namespace KtpAcsMiddleware.KtpApiService.Asp.AuthenticationSyncs
{
    /// <summary>
    ///     考勤同步服务统一入口
    /// </summary>
    public class AuthSyncAspService
    {
        private readonly KtpAuthService _ktpAuthService;

        public AuthSyncAspService()
        {
            _ktpAuthService = new KtpAuthService();
        }

        /// <summary>
        ///     推送指定考勤
        /// </summary>
        public void PushAuthentication(string authId)
        {
            if (string.IsNullOrEmpty(authId))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(authId));
            }
            //查询对应的上传数据
            var newAuthSyncDto = DataFactory.DomainAuthsRepository.FindNew(authId);
            if (newAuthSyncDto == null)
            {
                throw new NotFoundException(ExMessage.NotFound(nameof(newAuthSyncDto)));
            }
            //64位转图片上传到七牛
            var kPicUrl =
                QiniuHelper.GetUrlByUploadBase64StringData(newAuthSyncDto.ClockPic.Replace(" ", "+"));
            if (kPicUrl == null)
            {
                throw new Exception("打卡照片上传到七牛出错");
            }
            var parameters = new KtpAuthApiResultParameters
            {
                pro_id = ConfigHelper.ProjectId,
                user_id = newAuthSyncDto.ThirdPartyWorkerId,
                k_state = newAuthSyncDto.ClockType,
                k_pic = kPicUrl,
                clock_time = newAuthSyncDto.ClockTime
            };
            //执行上传
            _ktpAuthService.AddAuthentication(parameters, newAuthSyncDto.AuthId);
        }

        /// <summary>
        ///     推送所有考勤(忽略异常)
        /// </summary>
        public void PushAuthenticationsIgnoreEx()
        {
            try
            {
                PushAuthentications();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
            }
            finally
            {
                LogHelper.Info(@"考勤信息同步完成......");
            }
        }

        /// <summary>
        ///     推送所有考勤
        /// </summary>
        public void PushAuthentications()
        {
            int selectCount; //数据库中返回的数量
            //获取新的考勤同步数据(考勤同步的dto)
            var newAuthSyncDtos = DataFactory.AuthenticationSyncRepository.FindTopOneThousandNews(out selectCount);

            if (newAuthSyncDtos == null || newAuthSyncDtos.Count == 0)
            {
                return;
            }
            LogHelper.Info($"上传考勤人员:PushAuthentications newAuthSyncs.Count={newAuthSyncDtos.Count}");

            var erros = string.Empty;
            var newestId = string.Empty;
            var erroIds = string.Empty;
            foreach (var newAuthSyncDto in newAuthSyncDtos)
            {
                try
                {
                    var kPicUrl =
                        QiniuHelper.GetUrlByUploadBase64StringData(newAuthSyncDto.ClockPic.Replace(" ", "+"));
                    if (kPicUrl == null)
                    {
                        continue;
                    }
                    var parameters = new KtpAuthApiResultParameters
                    {
                        pro_id = ConfigHelper.ProjectId,
                        user_id = newAuthSyncDto.ThirdPartyWorkerId,
                        k_state = newAuthSyncDto.ClockType,
                        k_pic = kPicUrl,
                        clock_time = newAuthSyncDto.ClockTime
                    };
                    //执行上传
                    _ktpAuthService.AddAuthentication(parameters, newAuthSyncDto.AuthId);
                    newestId = newAuthSyncDto.AuthId;
                }
                catch (Exception ex)
                {
                    erroIds = $"{erroIds}{newAuthSyncDto.AuthId},";
                    erros = $"{erros}Message={ex.Message},StackTrace={ex.StackTrace},id={newAuthSyncDto.AuthId}|";
                }
            }
            if (erroIds != string.Empty)
            {
                erroIds = erroIds.TrimEnd('|');
                LogHelper.Info($"同步考勤异常:PushAuthentications newestId={newestId},erroIds={erroIds}");
            }
            else
            {
                //日志记录出现异常的考勤ID以及最新同步成功的考勤ID，本次同步(上传)成功的所有数据根据newestId从同步映射表中查询
                LogHelper.Info($"最后同步考勤id:PushAuthentications newestId={newestId}");
            }
            if (erros != string.Empty)
            {
                erros = erros.TrimEnd('|');
                if (selectCount < 1000)
                {
                    throw new Exception(erros);
                }
                LogHelper.ExceptionLog(erros);
            }

            if (selectCount < 1000)
            {
                return;
            }
            //因每次只操作一千条数据，此处递归，直到没有需要同步的数据
            PushAuthentications();
        }
    }
}