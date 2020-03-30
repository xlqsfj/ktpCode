using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService;
using KtpAcsMiddleware.KtpApiService.PanelApi;
using KtpAcsMiddleware.KtpApiService.PanelApi.PanelMage;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
using KtpAcsMiddleware.WinForm.Api.Shared;
using static KtpAcsMiddleware.KtpApiService.PanelApi.PanelWorkerSend;
using RestSharp;
using KtpAcsMiddleware.KtpApiService.TeamWorkers.Model;
using KtpAcsMiddleware.WinForm.TeamWorkers;
using KtpAcsMiddleware.WinForm.Api.Models;
using KtpAcsMiddleware.KtpApiService.Base;
using KtpAcsMiddleware.KtpApiService.PanelApiCd.CdModel;
using KtpAcsMiddleware.KtpApiService.PanelApiCd;
using KtpAcsMiddleware.KtpApiService.Api;

namespace KtpAcsMiddleware.WinForm.Api.KtpLibrary
{
    public partial class WorkerSyncPrompt : FormBaseUi
    {
        /// <summary>
        ///     类型：1=推送，2=拉取，3=同步，4=拉取所有班组和工人并推送考勤
        /// </summary>
        private List<string> _ip;
        private readonly Thread _workthread;
        private static object objLock = new object();//对象锁的对象
                                                     //声明委托重新提交
        public delegate void AddExceptionShow();
        //声明事件
        public event AddExceptionShow ShowSubmit;
        private static ManualResetEvent _hasNew = new ManualResetEvent(false);
        List<Workers> workers;
        private static int _numerOfThreadsNotYetCompleted = 100;

        public WorkerSyncPrompt()
        {
            InitializeComponent();
        }



        /// <summary>
        ///     入口：同步全部工人，走同步逻辑
        /// </summary>
        /// <param name="type">类型：1=推送，2=拉取，3=同步，4=拉取所有班组和工人并推送考勤</param>
        public WorkerSyncPrompt(List<string> list)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            _ip = list;

            _workthread = null;
            _workthread = new Thread(SyncWorkers) { IsBackground = true };
            _workthread.Start();
        }



        /// <summary>
        ///     同步(拉取/推送/双向同步)全部工人
        /// </summary>
        private void SyncWorkers()
        {
            try
            {

                workerSyn();
                closeOrder();
                if (WorkSysFail.list.Count() > 0)
                {

                    MessageHelper.Show("同步失败,请选择人员，重新拍照");
                    ShowSubmit();

                }
                else
                {


                    MessageHelper.Show("同步成功");


                }


            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);

                MessageHelper.Show(ex.Message);
            }
            finally
            {
                ControlBox = true;

            }
        }

        /// <summary>
        ///     确认按钮事件
        /// </summary>
        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///     窗口关闭事件
        /// </summary>
        private void WorkerSyncPrompt_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_workthread != null && _workthread.IsAlive)
                {
                    _workthread.Resume();
                    _workthread.Abort();
                }
            }
            catch
            {
                // ignored
            }
        }
        /// <summary>
        /// 同步
        /// </summary>
        /// <returns></returns>
        private string workerSyn()
        {
            try
            {
                foreach (var ip in _ip)
                {

                    if (string.IsNullOrEmpty(ip))
                    {
                        continue;
                    }
                    LogHelper.ExceptionLog($"1、同步到workerSyn:{ip}");
                    ThreadPool.QueueUserWorkItem(new WaitCallback(AddPaneIpInfo),

                     ip);
                    Thread.Sleep(10000);
                
                }
                _hasNew.WaitOne();
                // 接收到信号后，重置“信号器”，信号关闭。
                _hasNew.Reset();
            }
            catch (Exception ex)
            {


                LogHelper.ExceptionLog(ex.Message);
                throw new Exception(ex.Message, ex);
            }

            return "";
        }

        public void AddPaneIpInfo(dynamic ip)
        {
            LogHelper.ExceptionLog($"2、同步到AddPaneIpInfo:{ip}");
            lock (objLock)
            {
                if (workers == null)
                {
                    //查询所有人员的详细接口
                    IMulePusher PanelLibrarySet = new WorkerGet() { RequestParam = new { projectId = ConfigHelper.KtpLoginProjectId, certificationStatus = 2 } };

                    PushSummary pushSummary = PanelLibrarySet.Push();
                    WorkerResult rr = pushSummary.ResponseData;
                    workers = rr.data;

                }
            }
            List<PanelUserInfo> liblist = new List<PanelUserInfo>();
            try
            {
                liblist = PanelBaseCd.GetPersonInfo(ip);
            }
            catch (Exception ex)
            {
           
                LogHelper.ExceptionLog(ex.Message);
                throw new Exception(ex.Message, ex);

            

        }

            //循环面板的人员，跟项目人员对比，不存在进行删除
            foreach (PanelUserInfo items in liblist)
            {
                var p = workers.Where(a => a.userId.ToString() == items.id).Count();
                if (p == 0)
                {

                    IMulePusher panelDeleteApi = new PanelDeletePersonApi()
                    { PanelIp = ip, RequestParam = new Send { id = FormatHelper.StringToInt(items.id) } };

                    PushSummary pushSummarySet = panelDeleteApi.PushForm();
                }


            }
            //循环项目的人员，跟面板人员对比，不存在进行添加，存在跳过
            int panelCount = 0;
            _numerOfThreadsNotYetCompleted = workers.Count();
            foreach (Workers items in workers)
            {
                panelCount++;
                var isExit = liblist.Where(a => a.id == items.userId.ToString()).Count();
                if (isExit > 0)
                {
                    _numerOfThreadsNotYetCompleted = _numerOfThreadsNotYetCompleted - 1;
                    continue;

                }
                if (WorkSysFail.list.Where(a => a.userId == items.userId.ToString()).Count() > 0)
                {
                    _numerOfThreadsNotYetCompleted = _numerOfThreadsNotYetCompleted - 1;
                    continue;
                }

                if (string.IsNullOrEmpty(items.userCertPic))
                {
                    AddSysFail(items, "错误信息:不存在人脸识别的图片");
                    _numerOfThreadsNotYetCompleted = _numerOfThreadsNotYetCompleted - 1;
                    continue;
                }
                if (items.usex < 1 || string.IsNullOrEmpty(items.urealname) || string.IsNullOrEmpty(items.usfz))
                {
                    AddSysFail(items, "错误信息:基本信息不全");
                    _numerOfThreadsNotYetCompleted = _numerOfThreadsNotYetCompleted - 1;
                    continue;

                }

                items.panelIp = ip;
                //ThreadPool.QueueUserWorkItem(new WaitCallback(AddPanePerson),

                //   (object)items);

                LogHelper.ExceptionLog($"3、循环同步到面板AddPanePerson:{items.panelIp}");
                try
                {
                    AddPanePerson(items);
                }
                catch (Exception ex)
                {
 
                    LogHelper.ExceptionLog(ex.Message);
                    throw new Exception(ex.Message, ex);
                
            }
            }
            _ip = _ip.Where(a => a != ip).ToList();
            if (_ip.Count < 1)
                _hasNew.Set();





        }
        public void AddPanePerson(Workers items)
        {
            LogHelper.ExceptionLog($"4、同步到面板图片AddPanePerson:{items.panelIp}");
            try

            {
                string img64 = "";
                //保存图片

                // items.userCertPic = "https://zj.ktpis.com/2345_201903190854504199064.jpg";

                if (string.IsNullOrEmpty(items.userCertPic))
                {
                    LogHelper.ExceptionLog("找不到人脸识别的图片详细错误");
                    AddSysFail(items, "找不到人脸识别的图片详细错误");

                    return;
                }
                string fileName = items.userCertPic.Substring(items.userCertPic.LastIndexOf("/", StringComparison.Ordinal) + 1);
                try
                {

                    var picPhysicalFileName = FileIoHelper.GetImageFromUrl(items.userCertPic, fileName);
                    // 图片转64位
                    var file = $"{ConfigHelper.CustomFilesDir}{picPhysicalFileName}";
                    img64 = FileIoHelper.GetFileBase64String(file);
                    items.userCertPic64 = img64;
                }
                catch (Exception ex)
                {
                    AddSysFail(items, "找不到人脸识别的图片详细错误：" + ex.Message);
                    LogHelper.ExceptionLog(ex);
                    return;
                }

                AddCdPanel(items);


            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex.Message);
                throw new Exception(ex.Message, ex);
            }
            finally
            {

                //if (Interlocked.Decrement(ref _numerOfThreadsNotYetCompleted) == 0)
                //    _hasNew.Set();
            }


        }
        /// <summary>
        /// 同步到面板
        /// </summary>
        /// <param name="info"></param>
        public void AddCdPanel(Workers receiveData)
        {
            LogHelper.ExceptionLog($"5、同步到面板AddCdPanel:{receiveData.panelIp}");
            PanelCreateSend geteLibraryRequest = new PanelCreateSend
            {
                person = new Person
                {
                    age = "",
                    idcardNum = receiveData.usfz,
                    id = (int)receiveData.userId,
                    name = receiveData.urealname,
                    phone = receiveData.uname,
                    sex = receiveData.usex == 1 ? "男" : "女"

                }
            };

            try
            {
                //调用添加人员接口
                IMulePusher panelApi = new PanelCreatePersonApi() { RequestParam = geteLibraryRequest, PanelIp = receiveData.panelIp };

                PushSummary pushSummarySet = panelApi.PushForm();
                if (pushSummarySet.Success)
                {//添加人员成功后，添加照片接口
                    PanelFaceInfoSend panelFaceInfoSend = new PanelFaceInfoSend
                    {

                        faceId = (int)receiveData.userId,
                        personId = (int)receiveData.userId,
                        imgBase64 = receiveData.userCertPic64

                    };

                    //调用添加照片接口
                    IMulePusher faceApi = new PanelFacePersonApi() { RequestParam = panelFaceInfoSend, PanelIp = receiveData.panelIp };

                    PushSummary pushFace = faceApi.PushForm();
                    if (!pushFace.Success)
                    {
                        AddSysFail(receiveData, pushFace.Message);
                        return;
                    }

                    PanelObjectResult panelDeleteApiR = pushSummarySet.ResponseData;

                    //进场截止时间
                    if (!string.IsNullOrEmpty(receiveData.planExitTime))
                    {
                        //调用删除接口
                        IMulePusher dateDateleApi = new PanelDateBeginPersonApi() { RequestParam = new Send { personId = (int)receiveData.userId }, API = "/person/permissionsDelete", PanelIp = receiveData.panelIp };

                        PushSummary pushFace11 = dateDateleApi.PushForm();
                        //调用添加照片接口
                        IMulePusher dateApi = new PanelDateBeginPersonApi() { RequestParam = new Send { personId = (int)receiveData.userId, time = receiveData.planExitTime }, PanelIp = receiveData.panelIp };

                        PushSummary pushaDteApi = dateApi.PushForm();
                        if (!pushaDteApi.Success)
                        {
                            AddSysFail(receiveData, pushaDteApi.Message);
                        }
                    }


                }
                else
                {
                    AddSysFail(receiveData, pushSummarySet.Message);
                    return;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }


        }

        /// <summary>
        /// 添加到同步失败列表
        /// </summary>
        /// <param name="items">详情</param>
        /// <param name="mag">失败原因</param>
        public void AddSysFail(Workers items, string mag)
        {
            try
            {
                object isExit = null;
                if (string.IsNullOrEmpty(items.usfz) || string.IsNullOrEmpty(items.urealname))
                {

                }
                else
                {
                    isExit = WorkSysFail.list.FirstOrDefault(a => a.identityNum == items.usfz && a.userName == items.urealname);
                }

                if (isExit == null)
                {
                    WokersList wokersList = new WokersList
                    {
                        teamId = FormatHelper.GetToString(items.teamId),
                        identityNum = items.usfz,
                        sex = FormatHelper.GetToString(items.usex),
                        userId = FormatHelper.GetToString(items.userId),
                        userName = items.urealname,
                        teamName = items.poName,
                        phoneNum = items.uname,
                        reason = mag
                    };
                    WorkSysFail.list.Add(wokersList);
                }

            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddWorkerInfo(1).ShowDialog();
        }


        /// <summary>
        /// 关闭命令
        /// </summary>
        public void closeOrder()
        {
            if (this.InvokeRequired)
            {
                //这里利用委托进行窗体的操作，避免跨线程调用时抛异常，后面给出具体定义
                CONSTANTDEFINE.SetUISomeInfo UIinfo = new CONSTANTDEFINE.SetUISomeInfo(new Action(() =>
                {
                    while (!this.IsHandleCreated)
                    {
                        ;
                    }
                    if (this.IsDisposed)
                        return;
                    if (!this.IsDisposed)
                    {
                        this.Dispose();
                    }

                }));
                this.Invoke(UIinfo);
            }
            else
            {
                if (this.IsDisposed)
                    return;
                if (!this.IsDisposed)
                {
                    this.Dispose();
                }
            }
        }

    }
}