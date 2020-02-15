using System;
using System.IO;
using System.Web.Mvc;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Controllers
{
    public class TestController : ControllerBase
    {
        // GET: Test/Test
        public ActionResult CanvasTest()
        {
            return View();
        }

        public ActionResult FileUploadTest()
        {
            return View();
        }

        public ActionResult SynCardReaderTest()
        {
            return View();
        }

        public ActionResult FaceRecognitionApi()
        {
            return View();
        }

        public string UploadImage(string imageData)
        {
            FileStream pFileStream = null;
            try
            {
                var fileName = ConfigHelper.CustomFilesDir + ConfigHelper.NewTimeGuid + ".jpg";
                var data = Convert.FromBase64String(imageData);
                pFileStream = new FileStream(fileName, FileMode.OpenOrCreate);
                pFileStream.Write(data, 0, data.Length);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                if (pFileStream != null)
                {
                    pFileStream.Close();
                }
            }
        }
    }
}