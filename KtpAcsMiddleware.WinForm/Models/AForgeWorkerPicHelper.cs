using System;
using System.Drawing;
using System.IO;
using AForge.Controls;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.Base;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.KtpAcsMiddlewareFileService;
using PictureBox = System.Windows.Forms.PictureBox;

namespace KtpAcsMiddleware.WinForm.Models
{
    internal class AForgeWorkerPicHelper
    {
        private static readonly FileWebService FileService;

        static AForgeWorkerPicHelper()
        {
            FileService = new FileWebService();
        }

        public static string GetPic(VideoSourcePlayer aVidePlayer, PictureBox pictureBox)
        {
            var picBitmap = new Bitmap(aVidePlayer.Width, aVidePlayer.Height);
            aVidePlayer.DrawToBitmap(picBitmap, new Rectangle(0, 0, aVidePlayer.Width, aVidePlayer.Height));
            var physicalFileName = $"{ConfigHelper.NewTimeGuid}.jpg";
            var bytes = PictureCompressHelper.CompressImage(picBitmap);
            //var bytes = FileIoHelper.Bitmap2Bytes(picBitmap);
            var fileId = FileService.PostFile(physicalFileName, bytes);
            if (!string.IsNullOrEmpty(fileId))
            {
                //绘制图形到窗口
                //pictureBox.Image = picBitmap;
                pictureBox.Image = FileIoHelper.Bytes2Bitmap(bytes);
            }
            else
            {
                throw new Exception(
                    $"FileService.PostFile Exception,bytes.Length={bytes.Length},physicalFileName={physicalFileName}");
            }
            return fileId;
        }

        public static void BindPic(PictureBox pictureBox, string fileId)
        {
            if (string.IsNullOrEmpty(fileId))
            {
                return;
            }
            var bytes = FileService.GetFileBytes(fileId);
            if (bytes == null)
            {
                throw new Exception($"FileService.GetFileBytes Exception:bytes=null,fileId={fileId}");
            }
            pictureBox.BackgroundImage = null;
            pictureBox.Image = FileIoHelper.Bytes2Bitmap(bytes);
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
            var newFileMap = ServiceFactory.FileMapService.Add(new FileMap
            {
                FileName = physicalFileName,
                PhysicalFileName = physicalFileName,
                PhysicalFullName = physicalFullName,
                Length = bytes.Length
            });
            //绘制图形到窗口
            pictureBox.Image = FileIoHelper.Bytes2Bitmap(bytes);
            //faceBitmap.Dispose();
            return newFileMap.Id;
        }

        public static void BindPicLocal(PictureBox pictureBox, string fileId)
        {
            if (string.IsNullOrEmpty(fileId))
            {
                return;
            }
            var fileMap = FileMapDataService.Get(fileId);
            //单机做法，若web端与此端不在同一机子则需要通过webservice获取流
            using (var fileStream = new FileStream($@"{ConfigHelper.CustomFilesDir}{fileMap.PhysicalFileName}",
                FileMode.Open))
            {
                pictureBox.BackgroundImage = null;
                pictureBox.Image = new Bitmap(new Bitmap(fileStream));
                //fileStream.Close();
            }
        }
    }
}