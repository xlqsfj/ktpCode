using AForge.Controls;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.Base;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtpAcs.WinForm.Models
{
    class AForgeWorkerPicHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aVidePlayer"></param>
        /// <param name="pictureBox"></param>
        /// <returns></returns>
        public static string GetPicLocal(VideoSourcePlayer aVidePlayer, System.Windows.Forms.PictureBox pictureBox)
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

            }
            //绘制图形到窗口
            pictureBox.Image = FileIoHelper.Bytes2Bitmap(bytes);
            //faceBitmap.Dispose();
            return AddFileMap(physicalFileName, physicalFullName, bytes.Length);
        }
        /// <summary>
        /// 添加图片到FileMap表
        /// </summary>
        /// <param name="physicalFileName"></param>
        /// <param name="physicalFullName">图片绝对路径</param>
        /// <param name="Length">图片长度</param>
        /// <returns>FileMap表id</returns>
        public static string AddFileMap(string physicalFileName, string physicalFullName, int Length)
        {

            var newFileMap = ServiceFactory.FileMapService.Add(new FileMap
            {
                FileName = physicalFileName,
                PhysicalFileName = physicalFileName,
                PhysicalFullName = physicalFullName,
                Length = Length
            });
            return newFileMap.Id;
        }
        /// <summary>
        /// 图片控件
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="fileId">文件id</param>
        public static void BindPicLocal(System.Windows.Forms.PictureBox pictureBox, string fileId)
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
