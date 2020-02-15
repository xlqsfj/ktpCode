using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Domain.FaceRecognition
{
    public class FaceDeviceWorkerEntityService
    {
        public static FaceDeviceWorker Create(string deviceId, string workerId)
        {
            var now = DateTime.Now;
            return new FaceDeviceWorker
            {
                Id = ConfigHelper.NewGuid,
                CreateTime = now,
                ModifiedTime = now,
                IsDelete = false,
                WorkerId = workerId,
                DeviceId = deviceId,
                Status = (int) FaceWorkerState.New
            };
        }

        /// <summary>
        ///     通知所有人脸设备进行同步（忽略通知API调用导致的错误）
        /// </summary>
        public static void SendAllDeviceSyncFaceLibrary()
        {
            var faceDevices = UnitOfWork.DataContext.FaceDevices.Where(t => t.IsDelete == false).ToArray();
            if (faceDevices.Length == 0)
            {
                return;
            }
            foreach (var faceDevice in faceDevices)
            {
                BellDeviceSyncFaceLibraryAsync(faceDevice.IpAddress);
            }
        }

        /// <summary>
        ///     通知指定人脸设备进行同步
        /// </summary>
        public static void SendDeviceSyncFaceLibrary(string faceDeviceId)
        {
            if (faceDeviceId == null)
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(faceDeviceId)));
            }
            using (var dataContext = UnitOfWork.DataContext)
            {
                var faceDevice = dataContext.FaceDevices.FirstOrDefault(t => t.Id == faceDeviceId);
                if (faceDevice == null)
                {
                    return;
                }
                if (string.IsNullOrEmpty(faceDevice.IpAddress))
                {
                    return;
                }
                BellDeviceSyncFaceLibraryAsync(faceDevice.IpAddress);
            }
        }

        /// <summary>
        ///     异步发送通知设备请求
        /// </summary>
        private static void BellDeviceSyncFaceLibraryAsync(string faceDeviceIpAddress)
        {
            var url = $"http://{faceDeviceIpAddress}:8080/?action=2";
            try
            {
                var httpClient = new HttpClient();
                // 创建一个异步GET请求，当请求返回时继续处理
                httpClient.GetAsync(url).ContinueWith(
                    requestTask =>
                    {
                        try
                        {
                            var response = requestTask.Result;
                            // 确认响应成功，否则抛出异常
                            response.EnsureSuccessStatusCode();
                            // 异步读取响应为字符串
                            response.Content.ReadAsStringAsync().ContinueWith(
                                readTask => Console.WriteLine(readTask.Result));
                        }
                        catch (Exception ex)
                        {
                            LogHelper.ExceptionLog(ex, $"url={url}");
                        }
                    });
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex, $"url={url}");
            }
        }

        /// <summary>
        ///     发送通知设备请求
        /// </summary>
        public static void BellDeviceSyncFaceLibrary(string faceDeviceIpAddress)
        {
            if (string.IsNullOrEmpty(faceDeviceIpAddress))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(faceDeviceIpAddress)));
            }
            var url = $"http://{faceDeviceIpAddress}:8080/?action=2";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var apiResult = response.Content.ReadAsStringAsync().Result;
                    return;
                }
                throw new Exception($"通知失败请检查面板是否连接网络或打开,StatusCode={response.StatusCode}");
            }
        }
    }
}