using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;

namespace KtpAcsMiddleware.Infrastructure.Utilities
{
    public class FileIoHelper
    {
        /// <summary>
        ///     byte[]转换成Bitmap
        /// </summary>
        /// <returns></returns>
        public static Bitmap Bytes2Bitmap(byte[] value)
        {
            if (value.Length == 0)
            {
                return null;
            }
            var ic = new ImageConverter();
            var img = (Image) ic.ConvertFrom(value);
            if (img == null)
            {
                return null;
            }
            return new Bitmap(img);
        }

        /// <summary>
        ///     Bitmap转换成byte[]
        /// </summary>
        /// <returns></returns>
        public static byte[] Bitmap2Bytes(Bitmap bm)
        {
            var ms = new MemoryStream();
            bm.Save(ms, ImageFormat.Bmp);
            var bytes = ms.GetBuffer(); //byte[]   bytes=   ms.ToArray(); 这两句都可以
            ms.Close();
            return bytes;
        }

        /// <summary>
        ///     获取文件Base64String
        /// </summary>
        /// <param name="fileName">文件名称(全路径)</param>
        /// <returns></returns>
        public static string GetFileBase64String(string fileName)
        {

            

                   FileStream fs = null;
            try
            {
                //fs = new FileStream(fileName, FileMode.Open);

               fs = System.IO.File.OpenRead(fileName);
                //获取文件大小
                var size = fs.Length;
                var fbyte = new byte[size];
                //将文件读到byte数组中
                fs.Read(fbyte, 0, fbyte.Length);
                fs.Close();
                return Convert.ToBase64String(fbyte);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        /// <summary>
        ///     通过url获取图片
        /// </summary>
        /// <param name="url">图片URL</param>
        /// <param name="fileName">保存的文件名(不含路径)</param>
        /// <returns>图片名称(不含路径)</returns>
        public static string GetImageFromUrl(string url, string fileName = null)
        {
            Image downImage = null;
            try
            {
                //创建一个request 同时可以配置requst其余属性
                var imgRequst = WebRequest.Create(url);
                var imgStream = imgRequst.GetResponse().GetResponseStream();
                if (imgStream == null)
                {
                    return null;
                }
                //在这里以流的方式保存图片
                downImage = Image.FromStream(imgStream);
                if (fileName == null)
                {
                    fileName =
                        $"{ConfigHelper.NewTimeGuid}{url.Substring(url.LastIndexOf(".", StringComparison.Ordinal))}";
                }

                if (!Directory.Exists(ConfigHelper.CustomFilesDir))
                {
                    Directory.CreateDirectory(ConfigHelper.CustomFilesDir);
                }
                downImage.Save(ConfigHelper.CustomFilesDir + fileName);
                downImage.Dispose();
           
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                throw new Exception(ex.Message);
              
             
            }
            finally
            {
                downImage?.Dispose();
            }
            return fileName;
        }



  

    }
}