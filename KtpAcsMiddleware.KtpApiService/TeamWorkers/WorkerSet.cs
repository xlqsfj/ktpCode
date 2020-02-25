using KS.Resting;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Api;
using KtpAcsMiddleware.KtpApiService.Device;
using KtpAcsMiddleware.KtpApiService.PanelApi;
using KtpAcsMiddleware.KtpApiService.PanelApi.PanelMage;
using KtpAcsMiddleware.KtpApiService.PanelApiCd;
using KtpAcsMiddleware.KtpApiService.PanelApiHq;
using KtpAcsMiddleware.KtpApiService.TeamWorkers.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static KtpAcsMiddleware.KtpApiService.PanelApi.PanelWorkerSend;

namespace KtpAcsMiddleware.KtpApiService.TeamWorkers
{/// <summary>
/// 人员新增接口
/// </summary>
    public class WorkerSet : ApiBase<Workers, Result>
    {

        string panelMag = "";
        public WorkerSet()
          : base()
        {

            base.API = "/user/add";
            base.ServiceName = ApiType.KTP;
            base.MethodType = Method.POST;
            base.Token = ConfigHelper.KtpLoginToken;
        }

        /// <summary>
        /// 请求的方法
        /// </summary>
        /// <returns>传输的参数</returns>
        protected override Workers FetchDataToPush()
        {

            Workers workers = base.RequestParam;

            if (!string.IsNullOrEmpty(workers.localImgFileName))

                workers.userCertPic = GetImgUrl(workers.localImgFileName);
            if (!string.IsNullOrEmpty(workers.localImgFileName1))
                workers.popPic2 = GetImgUrl(workers.localImgFileName1);
            if (!string.IsNullOrEmpty(workers.localImgFileName2))
                workers.popPic3 = GetImgUrl(workers.localImgFileName2);
            if (!string.IsNullOrEmpty(workers.localImgUpic))
                workers.upic = GetImgUrl(workers.localImgUpic);

            return workers;
        }

        protected override void OnPushFailed(RichRestRequest request, string errorSummary)
        {

        }
        /// <summary>
        /// 返回信息方法
        /// </summary>
        /// <param name="request">请求的参数</param>
        /// <param name="receiveData">返回的参数</param>
        /// <returns></returns>
        protected override PushSummary OnPushSuccess(RichRestRequest request, Result receiveData)
        {
            PushSummary mag = new PushSummary(receiveData.success, receiveData.msg, ApiType.KTP, request, "人员新增接口");
            mag.ResponseData = receiveData;
            //添加url成功后，请求面板
            List<ContentItem> Device = new DeviceInfo().GetDeviceList();


            if (!mag.Success)
            {
                //判断是否是黑名单
                if (receiveData.result == 3)
                    WorkSysFail.dicWorkadd.Add(false, "3");
                else
                    WorkSysFail.dicWorkadd.Add(false, mag.Message);
                return mag;
            }
            else
            {
                Workers workers = base.RequestParam;

                if (workers.userId == null && !ConfigHelper.IsDivceAdd && Device.Count < 1)
                {
                    //新增时如果是无闸机录入调用新增考勤接口一次
                    AuthSend auth = new AuthSend
                    {
                        type = 3,
                        image = workers.userCertPic,
                        longitude = 0,
                        latitude = 0,
                        similarity = 80,
                        userId = receiveData.data.id,
                        projectId = workers.uproid,
                        pcCheckIn = "PC"

                    };
                    IMulePusher panelDeleteApi = new WokersAuthSet() { RequestParam = auth, PanelIp = "https://api.ktpis.com" };

                    PushSummary pushSummarySet = panelDeleteApi.Push();

                }

                WorkSysFail.dicWorkadd.Add(true, "添加成功");
            }


            //添加url成功后，请求面板
            if (Device.Count > 0)
            {


                int usable = 0;
                panelMag = null;
                Workers workers = base.RequestParam;
                var fileName = "";

                if (!string.IsNullOrEmpty(workers.localImgFileName))
                {
                    fileName = $"{ConfigHelper.CustomFilesDir}{workers.localImgFileName}";
                }
                else
                {

                    fileName = workers.userCertPic.Substring(workers.userCertPic.LastIndexOf("/", StringComparison.Ordinal));
                    var picPhysicalFileName = FileIoHelper.GetImageFromUrl(workers.userCertPic, fileName);
                    // 图片转64位
                    fileName = $"{ConfigHelper.CustomFilesDir}{picPhysicalFileName}";
                }
                var avatar = FileIoHelper.GetFileBase64String(fileName);
                foreach (ContentItem device in Device)
                {
                    if (WorkSysFail.workAdd.Where(a => a.deviceIp == device.deviceIp).Count() < 1)
                    {

                        continue;
                    }
                    try
                    {
                        usable++;
                        Result result = new Result();
                        result.ip = device.deviceIp;
                        result.imgBase64 = avatar;
                        result.usex = workers.usex;
                        result.uname = workers.uname;
                        result.urealname = workers.urealname;
                        result.userId = receiveData.data.id;
                        result.usfz = workers.usfz;
                        result.planExitTime = workers.planExitTime;
                        if (ConfigHelper.PanelApiType == (int)EPanelApiType.chidao)
                        {//赤道产品

                            Thread thread = new Thread(new ParameterizedThreadStart(PanelBaseCd.AddCdPanel));
                            thread.Start(result);
                        }
                        else if (ConfigHelper.PanelApiType == (int)EPanelApiType.haiqing)
                        {//海清产品

                            Thread thread = new Thread(new ParameterizedThreadStart(PanelBaseHq.AddHqPanel));
                            thread.Start(result);
                        }
                        else
                        {//宇视产品
                            Thread thread = new Thread(new ParameterizedThreadStart(AddPanelWorkerAPi));
                            thread.Start(result);
                        }
                        LogHelper.Info("已添加ip_" + usable + "" + result.ip);

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);


                    }
                    finally
                    {

                    }

                }
            }
            return mag;
        }
        public bool isE = false;
        /// <summary>
        /// 添加到宇视的面板
        /// </summary>
        /// <param name="receiveData"></param>
        public void AddPanelWorkerAPi(dynamic receiveData)
        {

            LogHelper.Info("已添加ip_" + receiveData.ip);
            Workers workers = base.RequestParam;
            long timeStamp = 4294967295;
            if (!string.IsNullOrEmpty(workers.planExitTime))
                timeStamp = (Convert.ToDateTime(workers.planExitTime).ToUniversalTime().Ticks - 621355968000000000) / 10000000;

            PersonInfoListItem personInfoListItem = new PersonInfoListItem
            {
                Gender = workers.usex,
                PersonName = workers.urealname,
                LastChange = DateTime.Now.Ticks,
                ImageNum = 1,
                PersonID = receiveData.userId,
                IdentificationNum = 1,
                TimeTemplate = new TimeTemplate { BeginTime = 0, EndTime = timeStamp, Index = 0 },
                IdentificationList = new List<IdentificationListItem> { new IdentificationListItem { Number = workers.usfz, Type = 0 } },
                ImageList = new List<ImageListItem> { new ImageListItem { Name = $"{workers.userId}_{DateTime.Now}.jpg", Data = receiveData.imgBase64, Size = receiveData.imgBase64.Length, FaceID = receiveData.userId } }

            };
            PanelWorkerSend PanelWorkerSend = new PanelWorkerSend();
            PanelWorkerSend.Num = 1;
            PanelWorkerSend.PersonInfoList = new List<PanelWorkerSend.PersonInfoListItem>() { personInfoListItem };

            IMulePusher PanelLibrarySet = new PanelWorkerApi() { RequestParam = PanelWorkerSend, MethodType = Method.POST, PanelIp = receiveData.ip };

            PushSummary pushSummary = PanelLibrarySet.Push();
            if (!pushSummary.Success)
            {
                panelMag = pushSummary.Message;
                WorkSysFail.dicAddMag.Add(receiveData.ip, panelMag);
            }
            else
            {
                WorkSysFail.dicAddMag.Add(receiveData.ip, "添加成功");
            }

            PanelResult pr = pushSummary.ResponseData;

        }
        public string GetImgUrl(string fName)
        {

            var fileName = $"{ConfigHelper.CustomFilesDir}{fName}";
            var qinieKey = QiniuHelper.UploadFile(fileName);
            var qinieUrl = $"{QiniuHelper.QiniuBaseUrl}{qinieKey}";
            return qinieUrl;
        }
    }
}
