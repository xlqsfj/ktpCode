using System;
using System.Web.Mvc;
using KtpAcsMiddleware.AppService.FaceRecognition;
using KtpAcsMiddleware.AppService.FileMaps;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Api
{
    public class FaceAuthenticationApiController : ApiBaseController
    {
        private readonly IFaceAuthService _authService;
        private readonly IFileMapService _fileMapService;

        public FaceAuthenticationApiController(
            IFaceAuthService authenticationService, IFileMapService fileMapService)
        {
            _authService = authenticationService;
            _fileMapService = fileMapService;
        }

        /// <summary>
        ///     添加认证记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string PostRecord(
            string name, string idNumber, string nation, string address,
            string avatar, int? sex, int type, int result, string deviceNumber,
            string authTimeStamp, string idcardImage)
        {
            LogHelper.Info($"添加考勤记录:FaceAuthenticationApi.PostRecord:name={name},idNumber={idNumber}");
            //string groupId,string idcardInfo,
            //,string signOffice, string legalDate, string birthday, string similarDegree
            try
            {
                var authentication = new ZmskAuthentication
                {
                    Name = name, //名称
                    IdNumber = idNumber, //身份证号
                    Nation = nation, //民族
                    Address = address, //身份证地址
                    Avatar = avatar.Replace(" ", "+"), //头像
                    Sex = sex, //性别1：女 2：男
                    Type = type, //类型1：人证，2人脸
                    Result = result, //认证结果 0：未通过 1：通过
                    DeviceNumber = deviceNumber, //设备编号
                    //GroupId = groupId,//所属分组Id,不是必填，默认为0
                    AuthTimeStamp = authTimeStamp, //认证时间戳
                    IdcardImage = idcardImage.Replace(" ", "+") //身份证图片地址，默认值为空字符串
                    //IdcardInfo = idcardInfo,//身份证基本信息，默认值为空字符串
                    //SimilarDegree = similarDegree//对比相似度,默认值为空字符串
                    //SignOffice = signOffice,
                    //LegalDate = legalDate,
                    //Birthday = birthday,
                };
                _authService.Add(authentication);
                return Ok200Success();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return OkFail();
            }
        }

        /// <summary>
        ///     上传文件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string UploadFile()
        {
            try
            {
                if (Request.Files.Count != 1)
                {
                    return OkFail("Files count not equal to 1");
                }
                var file = Request.Files[0];
                if (file == null)
                {
                    return OkFail("The first file is null");
                }
                var physicalFileName = $"{ConfigHelper.NewTimeGuid}-{file.FileName}";
                file.SaveAs($"{ConfigHelper.CustomFilesDir}{physicalFileName}");

                var fileLength = file.ContentLength;
                var bytes = new byte[fileLength];
                file.InputStream.Read(bytes, 0, fileLength);
                var newFileMap = _fileMapService.Add(new FileMap
                {
                    FileName = file.FileName,
                    PhysicalFileName = physicalFileName,
                    Length = fileLength
                });

                return Ok200Success(newFileMap.Id);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return OkFail();
            }
        }

        /// <summary>
        ///     添加认证记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string Post(ZmskAuthentication zmskAuthentication)
        {
            LogHelper.Info($"{zmskAuthentication}PostRecord-zmskAuthentication");
            try
            {
                _authService.Add(zmskAuthentication);
                return Ok200Success();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return OkFail();
            }
        }
    }
}