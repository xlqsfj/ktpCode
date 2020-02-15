using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace KtpAcsMiddleware.Infrastructure.Utilities
{
    public class PictureCompressHelper
    {
        /// <summary>
        ///     无损压缩图片
        /// </summary>
        /// <param name="sFile">原图片Bitmap</param>
        /// <param name="flag">压缩质量（数字越小压缩率越高）1-100</param>
        /// <param name="size">压缩后图片的最大大小。单位kb,即50代表目标图片小于50kb</param>
        /// <param name="sfsc">是否是第一次调用。外部调用时默认都为true。</param>
        /// <returns></returns>
        public static byte[] CompressImage(Bitmap sFile, int flag = 90, int size = 300, bool sfsc = true)
        {
            var tFormat = sFile.RawFormat;
            //var dHeight = sFile.Height / 2;
            //var dWidth = sFile.Width / 2;
            //int sWidth, sHeight;
            ////按比例缩放
            //var temSize = new Size(sFile.Width, sFile.Height);
            //if (temSize.Width > dHeight || temSize.Width > dWidth)
            //{
            //    if ((temSize.Width * dHeight) > (temSize.Width * dWidth))
            //    {
            //        sWidth = dWidth;
            //        sHeight = (dWidth * temSize.Height) / temSize.Width;
            //    }
            //    else
            //    {
            //        sHeight = dHeight;
            //        sWidth = (temSize.Width * dHeight) / temSize.Height;
            //    }
            //}
            //else
            //{
            //    sWidth = temSize.Width;
            //    sHeight = temSize.Height;
            //}

            var dHeight = sFile.Height;
            var dWidth = sFile.Width;
            var sHeight = sFile.Height;
            var sWidth = sFile.Width;

            var ob = new Bitmap(dWidth, dHeight);
            var g = Graphics.FromImage(ob);
            g.Clear(Color.WhiteSmoke);
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(sFile, new Rectangle(0, 0, sWidth, sHeight), 0, 0,
                sWidth, sHeight, GraphicsUnit.Pixel);
            g.Dispose();

            //以下代码为保存图片时，设置压缩质量
            var encoderParameters = new EncoderParameters
            {
                //设置压缩的比例1-100
                Param = {[0] = new EncoderParameter(Encoder.Quality, new long[] {flag})}
            };

            try
            {
                var arrayIci = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegIcIinfo = null;
                for (var x = 0; x < arrayIci.Length; x++)
                {
                    if (arrayIci[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegIcIinfo = arrayIci[x];
                        break;
                    }
                }
                if (jpegIcIinfo != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        ob.Save(ms, jpegIcIinfo, encoderParameters);
                        return ms.ToArray();
                    }
                }
                else
                {
                    using (var ms = new MemoryStream())
                    {
                        ob.Save(ms, tFormat);
                        return ms.ToArray();
                    }
                }
            }
            finally
            {
                sFile.Dispose();
                ob.Dispose();
            }
        }
    }
}