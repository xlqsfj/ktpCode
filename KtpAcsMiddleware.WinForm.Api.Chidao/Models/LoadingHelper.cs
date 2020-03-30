using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.WinForm.Api.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.WinForm.Api.Models
{
    public delegate void AsyncHandler();//委托的声明方式类似于函数，只是比函数多了一个delegate关键字
    class LoadingHelper
    {

        #region 相关变量定义
        /// <summary>
        /// 定义委托进行窗口关闭
        /// </summary>
        private delegate void CloseDelegate();
        private static FormLoad loadingForm;
        private static readonly Object syncLock = new Object();  //加锁使用

        #endregion

        private LoadingHelper()
        {
         
        }

        /// <summary>
        /// 显示loading框
        /// </summary>
        public static void ShowLoadingScreen()
        {
            // Make sure it is only launched once.
            if (loadingForm != null)
                return;
         
            Thread thread = new Thread(new ThreadStart(LoadingHelper.ShowForm));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
       /// <summary>
       ///
       /// </summary>
       /// <param name="showMag"></param>
        public static void ShowLoadingScreen(LoadMagEnum showMag)
        {

            dynamic mag = showMag.GetDescription();
            // Make sure it is only launched once.new ParameterizedThreadStart(Myping)
            if (loadingForm != null)
                return;
            Thread thread = new Thread(new ParameterizedThreadStart(LoadingHelper.ShowForm));
            thread.IsBackground = false;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start(mag);
        }
        /// <summary>
        /// 显示窗口
        /// </summary>
        public static void ShowForm()
        {
            if (loadingForm != null)
            {
                loadingForm.closeOrder();
                loadingForm = null;
            }
            loadingForm = new FormLoad();
            loadingForm.TopMost = true;
            loadingForm.ShowDialog();
        }
        /// <summary>
        /// 显示窗口
        /// </summary>
        public static  void ShowForm(dynamic showMag)
        {
            if (loadingForm != null)
            {
                loadingForm.closeOrder();
                loadingForm = null;
              
            }

         
                loadingForm = new FormLoad(showMag);
                loadingForm.TopMost = true;
                loadingForm.ShowDialog();
         

        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        public static void CloseForm()
        {
            Thread.Sleep(50); //可能到这里线程还未起来，所以进行延时，可以确保线程起来，彻底关闭窗口
            if (loadingForm != null)
            {
                lock (syncLock)
                {
                    Thread.Sleep(50);
                    if (loadingForm != null)
                    {
                        Thread.Sleep(50);  //通过三次延时，确保可以彻底关闭窗口
                        loadingForm.Invoke(new CloseDelegate(LoadingHelper.CloseFormInternal));
                    }
                }
            }
        }

        /// <summary>
        /// 关闭窗口，委托中使用
        /// </summary>
        private static void CloseFormInternal()
        {

            loadingForm.closeOrder();
            loadingForm = null;

        }
    }
}
