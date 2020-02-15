using System;
using System.IO;
using System.Web.Mvc;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.AppService.FileMaps;
using KtpAcsMiddleware.AppService.TeamWorkers;
using KtpAcsMiddleware.Domain.Base;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Controllers
{
    public class UserControlController : ControllerBase
    {
        private readonly IFileMapService _fileMapService;
        private readonly IWorkerIdentityService _workerIdentityService;

        public UserControlController(IFileMapService fileMapService, IWorkerIdentityService workerIdentityService)
        {
            _fileMapService = fileMapService;
            _workerIdentityService = workerIdentityService;
        }

        public PartialViewResult FileUpload()
        {
            return PartialView();
        }

        public PartialViewResult FileUploadList()
        {
            return PartialView();
        }

        public PartialViewResult CanvasUpload()
        {
            return PartialView();
        }

        public PartialViewResult IdentityCardReader()
        {
            return PartialView();
        }

        public string GetIdentityNation(int value)
        {
            try
            {
                return Ok(IdentityNationService.GetText(value));
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return Ok(false, ex.Message);
            }
        }

        public string GetIdentity(string dto)
        {
            try
            {
                var identitySynDto = new IdentitySynDto().FromJson(dto);
                var identity = _workerIdentityService.ReaderAdd(identitySynDto);
                return Ok(new IdentityDto
                {
                    Id = ConfigHelper.NewGuid,
                    CreateTime = DateTime.Now,
                    CreateType = (int) WorkerIdentityCreateType.Reader,
                    Code = identity.Code,
                    Name = identity.Name,
                    Sex = identity.Sex,
                    Nation = identity.Nation,
                    Birthday = identity.Birthday,
                    Address = identity.Address,
                    IssuingAuthority = identity.IssuingAuthority,
                    ActivateTime = identity.ActivateTime,
                    InvalidTime = identity.InvalidTime,
                    Base64Photo = identity.Base64Photo
                });
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex, $"UserControl.GetIdentity,{dto}");
                return Ok(false, ex.Message);
            }
        }

        /// <summary>
        ///     上传文件(jquery-fileupload)
        /// </summary>
        /// <returns></returns>
        public string UploadFile()
        {
            try
            {
                if (Request.Files.Count != 1)
                {
                    return Ok(false, "Files count not equal to 1");
                }
                var file = Request.Files[0];
                if (file == null)
                {
                    return Ok(false, "The first file is null");
                }
                var physicalFileName = $"{ConfigHelper.NewTimeGuid}-{file.FileName}";
                file.SaveAs($"{ConfigHelper.CustomFilesDir}{physicalFileName}");

                var fileLength = file.ContentLength;
                var newFileMap = _fileMapService.Add(new FileMap
                {
                    FileName = file.FileName,
                    PhysicalFileName = physicalFileName,
                    Length = fileLength
                });
                newFileMap.PhysicalFileName = FileMapEntityService.GetFileSrc(newFileMap);
                return Ok(newFileMap);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return Ok(false, ex.Message);
            }
        }

        public string UploadImage(string imageData)
        {
            try
            {
                var data = Convert.FromBase64String(imageData);
                var newFileMap = new FileMap
                {
                    FileName = $"{ConfigHelper.NewTimeGuid}.jpg",
                    Length = data.Length
                };
                var fileName = ConfigHelper.CustomFilesDir + newFileMap.FileName;
                using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    fileStream.Write(data, 0, data.Length);
                    //fileStream.Close();
                }
                newFileMap = _fileMapService.Add(newFileMap);
                newFileMap.PhysicalFileName = FileMapEntityService.GetFileSrc(newFileMap);
                return Ok(newFileMap);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return Ok(false, ex.Message);
            }
        }
    }
}