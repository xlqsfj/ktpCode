using System;
using System.Drawing;
using AForge.Controls;
using AForge.Video.DirectShow;
using KtpAcsMiddleware.Infrastructure.Exceptions;

namespace KtpAcsMiddleware.WinForm.Api.Models
{
    public class AForgeVidePlayerHelper
    {
        /// <summary>
        ///连接摄像头(有多个时默认获取第0个)
        /// </summary>
        public static void CameraConn(VideoSourcePlayer aVidePlayer)
        {
            //创建视频驱动对象
            FilterInfoCollection videoDevices = null;
            try
            {
                // 枚举所有视频输入设备
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count == 0)
                {
                    throw new NotFoundException("未发现摄像头驱动,请检查是否连接摄像头");
                }
                //使用默认摄像头
                var videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                //重新绘制摄像头画面大小300*300
                videoSource.DesiredFrameSize = new Size(300, 300);
                //设置摄像头获取每秒帧数
                videoSource.DesiredFrameRate = 30;
                aVidePlayer.VideoSource = videoSource;
                aVidePlayer.Start();
            }
            catch (NullReferenceException)
            {
                throw new NotFoundException("未发现摄像头驱动,请检查是否连接摄像头");
            }
        }

        /// <summary>
        /// 获取照片
        /// </summary>
        public static Bitmap GetPic(VideoSourcePlayer aVidePlayer)
        {
            var picBitmap = new Bitmap(aVidePlayer.Width, aVidePlayer.Height);
            aVidePlayer.DrawToBitmap(picBitmap, new Rectangle(0, 0, aVidePlayer.Width, aVidePlayer.Height));
            return picBitmap;
        }
    }
}