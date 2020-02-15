using System;
using System.ComponentModel;
using System.IO;
using System.Web.Services;
using KtpAcsMiddleware.Domain.Base;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Api
{
    /// <summary>
    ///     FileWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class FileWebService : WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        ///     文件上传（简单调用,不支持分块上传）
        /// </summary>
        /// <param name="fileName">文件名称(不含整体路径，带扩展名)</param>
        /// <param name="fileContent">文件流</param>
        /// <returns></returns>
        [WebMethod]
        public string PostFile(string fileName, byte[] fileContent)
        {
            FileStream fileStream = null;
            try
            {
                var fileLength = fileContent.Length;
                if (fileLength == 0)
                {
                    LogHelper.ExceptionLog("fileContent.Length=0");
                    return null;
                }
                var physicalFileName = $"{ConfigHelper.NewTimeGuid}-{fileName}";
                //创建一个文件流
                fileStream = new FileStream($"{ConfigHelper.CustomFilesDir}{physicalFileName}", FileMode.Create);
                //将byte数组写入文件中
                fileStream.Write(fileContent, 0, fileLength);
                //所有流类型都要关闭流，否则会出现内存泄露问题
                fileStream.Close();
                var newFileMap = FileMapDataService.Add(new FileMap
                {
                    FileName = fileName,
                    PhysicalFileName = physicalFileName,
                    Length = fileLength
                });
                return newFileMap.Id;
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return null;
            }
            finally
            {
                fileStream?.Close();
            }
        }

        /// <summary>
        ///     获取文件Bytes
        /// </summary>
        /// <param name="fileId">文件ID</param>
        /// <returns></returns>
        [WebMethod]
        public byte[] GetFileBytes(string fileId)
        {
            if (string.IsNullOrEmpty(fileId))
            {
                return null;
            }
            FileStream fileStream = null;
            try
            {
                var fileMap = FileMapDataService.Get(fileId);
                //创建一个文件流
                fileStream = new FileStream(
                    $"{ConfigHelper.CustomFilesDir}{fileMap.PhysicalFileName}", FileMode.Open, FileAccess.Read);
                var buffur = new byte[fileStream.Length];
                fileStream.Read(buffur, 0, (int) fileStream.Length);
                fileStream.Close();
                return buffur;
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                return null;
            }
            finally
            {
                fileStream?.Close();
            }
        }
    }
}