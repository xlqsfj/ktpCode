using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.PanelApi;
using KtpAcsMiddleware.KtpApiService.PanelApiCd.CdModel;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
using KtpAcsMiddleware.KtpApiService.TeamWorkers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApiCd
{
    public class PanelBaseCd
    {


        public static Dictionary<string, List<PanelUserInfo>> ipList = new Dictionary<string, List<PanelUserInfo>>();
        /// <summary>
        /// 查询人员
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<PanelUserInfo> GetPersonInfo(string ip, int id = -1)
        {

            if (id > 0 && ipList.ContainsKey(ip))
            {
                var currentId = ipList[ip].Where(a => a.id == id.ToString()).ToList();
                return currentId;

            }
            List<PanelUserInfo> panelUserInfos = new List<PanelUserInfo>();
            //返回设备的数量
            IMulePusher PanelLibraryGet = new PanelGetPersonApi() { PanelIp = ip, RequestParam = new Send { id = id } };

            PushSummary pushSummary = PanelLibraryGet.PushForm();
            if (!pushSummary.Success)
            {
                if (ipList.Keys.Contains(ip))
                {
                    ipList.Remove(ip);

                }
                return panelUserInfos;
            }
            PanelListResult panelListResult = null;
            if (pushSummary.ResponseData != null)
            {
                panelListResult = pushSummary.ResponseData;

                panelUserInfos = panelListResult.data;
                if (id < 0)
                {
                    if (ipList.Keys.Contains(ip))
                    {
                        ipList.Remove(ip);

                    }

                    ipList.Add(ip, panelUserInfos);

                }

            }
            return panelUserInfos;

        }
        /// <summary>
        /// 查询人员照片
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<PanelUserFaceInfo> GetPersonFaceInfo(string ip, int id = -1)
        {
            List<PanelUserFaceInfo> panelUserFaceInfos = new List<PanelUserFaceInfo>();
            //返回设备的数量
            IMulePusher PanelLibraryGet = new PanelGetFaceApi() { PanelIp = ip, RequestParam = new Send { personId = id } };

            PushSummary pushSummary = PanelLibraryGet.PushForm();
            if (!pushSummary.Success)
            {
                return panelUserFaceInfos;
            }
            PanelFaceResult panelListResult = null;
            if (pushSummary.ResponseData != null)
            {
                panelListResult = pushSummary.ResponseData;


                return panelListResult.data;

            }
            return panelUserFaceInfos;

        }
        /// <summary>
        /// 添加到面板
        /// </summary>
        /// <param name="info"></param>
        public static void AddCdPanel(dynamic receiveData)
        {

            PanelCreateSend geteLibraryRequest = new PanelCreateSend
            {
                person = new Person
                {
                    age = "",
                    idcardNum = receiveData.usfz,
                    id = receiveData.userId,
                    name = receiveData.urealname,
                    phone = receiveData.uname,
                    sex = receiveData.usex == 1 ? "男" : "女"

                }
            };

            //调用添加人员接口
            IMulePusher panelApi = new PanelCreatePersonApi() { RequestParam = geteLibraryRequest, PanelIp = receiveData.ip };

            PushSummary pushSummarySet = panelApi.PushForm();
            if (pushSummarySet.Success)
            {//添加人员成功后，添加照片接口
                PanelFaceInfoSend panelFaceInfoSend = new PanelFaceInfoSend
                {

                    faceId = receiveData.userId,
                    personId = receiveData.userId,
                    imgBase64 = receiveData.imgBase64

                };

                //调用添加照片接口
                IMulePusher faceApi = new PanelFacePersonApi() { RequestParam = panelFaceInfoSend, PanelIp = receiveData.ip };

                PushSummary pushFace = faceApi.PushForm();
                if (!pushFace.Success)
                {
                    string panelMag = pushFace.Message;
                    WorkSysFail.dicAddMag.Add(receiveData.ip, panelMag);
                }
                else
                {



                    WorkSysFail.dicAddMag.Add(receiveData.ip, "添加成功");

                }
                PanelObjectResult panelDeleteApiR = pushSummarySet.ResponseData;

                //进场截止时间
                if (!string.IsNullOrEmpty(receiveData.planExitTime))
                {
                    //调用删除接口
                    IMulePusher dateDateleApi = new PanelDateBeginPersonApi() { RequestParam = new Send { personId = receiveData.userId }, API = "/person/permissionsDelete", PanelIp = receiveData.ip };

                    PushSummary pushFace1 = dateDateleApi.PushForm();
                    //调用添加照片接口
                    IMulePusher dateApi = new PanelDateBeginPersonApi() { RequestParam = new Send { personId = receiveData.userId, time = receiveData.planExitTime }, PanelIp = receiveData.ip };

                    PushSummary pushaDteApi = dateApi.PushForm();

                }

            }


            
        }
    }
}
