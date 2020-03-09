using System;
using System.Drawing;
using System.IO;
using AForge.Controls;

using KtpAcsMiddleware.Infrastructure.Utilities;

using PictureBox = System.Windows.Forms.PictureBox;

namespace KtpAcsMiddleware.WinForm.Api.Models
{
    internal class AForgeWorkerPicHelper
    {
      

        static AForgeWorkerPicHelper()
        {
           

        }


        public static string GetPicLocal(VideoSourcePlayer aVidePlayer, PictureBox pictureBox)
        {
            var picBitmap = new Bitmap(aVidePlayer.Width, aVidePlayer.Height);
            aVidePlayer.DrawToBitmap(picBitmap, new Rectangle(0, 0, aVidePlayer.Width, aVidePlayer.Height));
            //保存图片==单机做法，若web端与此端不在同一机子则需要通过webservice获取流
            var physicalFileName = $"{ConfigHelper.NewTimeGuid}.jpg";
            var physicalFullName = $"{ConfigHelper.CustomFilesDir}{physicalFileName}";
            //var bytes = FileIoHelper.Bitmap2Bytes(picBitmap);
            var bytes = PictureCompressHelper.CompressImage(picBitmap);
            //创建一个文件流
            using (var fileStream = new FileStream(physicalFullName, FileMode.Create))
            {
                fileStream.Write(bytes, 0, bytes.Length);
                //fileStream.Close();
            }
            //var newFileMap = ServiceFactory.FileMapService.Add(new FileMap
            //{
            //    FileName = physicalFileName,
            //    PhysicalFileName = physicalFileName,
            //    PhysicalFullName = physicalFullName,
            //    Length = bytes.Length
            //});
            //绘制图形到窗口
            pictureBox.Image = FileIoHelper.Bytes2Bitmap(bytes);
            //faceBitmap.Dispose();
            return physicalFileName;
        }

        public static void BindPicLocal(PictureBox pictureBox, string fileId)
        {
            if (string.IsNullOrEmpty(fileId))
            {
                return;
            }
            //var fileMap = FileMapDataService.Get(fileId);
            ////单机做法，若web端与此端不在同一机子则需要通过webservice获取流
            //using (var fileStream = new FileStream($@"{ConfigHelper.CustomFilesDir}{fileMap.PhysicalFileName}",
            //    FileMode.Open))
            //{
            //    pictureBox.BackgroundImage = null;
            //    pictureBox.Image = new Bitmap(new Bitmap(fileStream));
            //    //fileStream.Close();
            //}
        }
    }
}