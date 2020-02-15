using System;
using System.Configuration;
using Qiniu.Storage;
using Qiniu.Util;

namespace KtpAcsMiddleware.Infrastructure.Utilities
{
    public class QiniuHelper
    {
        /// <summary>
        ///     七牛库基础网址
        /// </summary>
        public static string QiniuBaseUrl
        {
            get
            {
                if (ConfigurationManager.AppSettings["QiniuBaseUrl"] != null)
                    return ConfigurationManager.AppSettings["QiniuBaseUrl"];
                return "https://zj.ktpis.com/";
            }
        }

        /// <summary>
        ///     七牛库AccessKey
        /// </summary>
        private static string QiniuAccessKey
        {
            get
            {
                if (ConfigurationManager.AppSettings["QiniuAccessKey"] != null)
                    return ConfigurationManager.AppSettings["QiniuAccessKey"];
                return "EbWp8FT0dOlaKyldOSpcV3-WQ_RrMhiqpFhYcUQ_";
            }
        }

        /// <summary>
        ///     七牛库Bucket
        /// </summary>
        private static string QiniuBucket
        {
            get
            {
                if (ConfigurationManager.AppSettings["QiniuBucket"] != null)
                    return ConfigurationManager.AppSettings["QiniuBucket"];
                return "ktpsix";
            }
        }

        /// <summary>
        ///     七牛库SecretKey
        /// </summary>
        private static string QiniuSecretKey
        {
            get
            {
                if (ConfigurationManager.AppSettings["QiniuSecretKey"] != null)
                    return ConfigurationManager.AppSettings["QiniuSecretKey"];
                return "t4TS9c8BWCWvgR1kky5ZEgYJloqisH9mEhT6SluS";
            }
        }

        /// <summary>
        ///     七牛库QiniuKey
        /// </summary>
        private static string QiniuSaveKeyBase
        {
            get
            {
                if (ConfigurationManager.AppSettings["QiniuSaveKeyBase"] != null)
                    return ConfigurationManager.AppSettings["QiniuSaveKeyBase"];
                var rd = new Random();
                return
                    $"{ConfigHelper.ProjectId}_{ConfigHelper.CurrentTimeNumberfff}{FormatHelper.GetIntString(rd.Next(0, 9999)).PadLeft(4, '0')}";
            }
        }

        /// <summary>
        ///     上传文件到七牛
        /// </summary>
        /// <param name="fileName">本地文件路径</param>
        /// <returns>saveKey=文件名</returns>
        public static string UploadFile(string fileName, string currentName = "")
        {
            // 上传文件名
            var fileExtensionName = fileName.Substring(fileName.LastIndexOf(".", StringComparison.Ordinal));
            fileExtensionName = fileExtensionName.ToLower();
            var saveKey = "";
            if (currentName == "")
                saveKey = $"{QiniuSaveKeyBase}{fileExtensionName}";
            else
                saveKey = currentName;

            var mac = new Mac(QiniuAccessKey, QiniuSecretKey);
            // 设置上传策略，详见：https://developer.qiniu.com/kodo/manual/1206/put-policy
            var putPolicy = new PutPolicy();
            // 设置要上传的目标空间
            putPolicy.Scope = QiniuBucket;
            // 上传策略的过期时间(单位:秒)
            putPolicy.SetExpires(3600);
            // 文件上传完毕后，在多少天后自动被删除
            //putPolicy.DeleteAfterDays = 1;
            // 生成上传token
            var token = Auth.CreateUploadToken(mac, putPolicy.ToJsonString());
            var config = new Config();
            // 设置上传区域
            config.Zone = Zone.ZONE_CN_South;
            //// 设置 http 或者 https 上传
            //config.UseHttps = true;
            //config.UseCdnDomains = true;
            //config.ChunkSize = ChunkUnit.U512K;
            // 表单上传
            var target = new FormUploader(config);
            var result = target.UploadFile(fileName, saveKey, token, null);
            if (result.Code == 200)
            {
                return saveKey;
            }
            throw new Exception($"Upload file qiniu exception,result.Code={result.Code},result.Text={result.Text}");
        }

        public static string GetUrlByUploadBase64StringData(string base64Data)
        {
            var saveKey = UploadBase64StringData(base64Data);
            if (string.IsNullOrEmpty(saveKey))
            {
                return null;
            }
            return $"{QiniuBaseUrl}{saveKey}";
        }

        /// <summary>
        ///     上传文件(FromBase64String)到七牛
        /// </summary>
        /// <param name="base64Data">文件字节数据(Base64String)</param>
        /// <returns>saveKey=文件名</returns>
        public static string UploadBase64StringData(string base64Data)
        {
            try
            {
                if (string.IsNullOrEmpty(base64Data))
                {
                    return null;
                }
                var saveKey = $"{QiniuSaveKeyBase}.jpg";
                var mac = new Mac(QiniuAccessKey, QiniuSecretKey);
                var data = Convert.FromBase64String(base64Data);
                var putPolicy = new PutPolicy();
                putPolicy.Scope = QiniuBucket;
                // 上传策略有效期(对应于生成的凭证的有效期)          
                putPolicy.SetExpires(3600);
                // 生成上传凭证，参见
                // https://developer.qiniu.com/kodo/manual/upload-token            
                var jstr = putPolicy.ToJsonString();
                var token = Auth.CreateUploadToken(mac, jstr);
                var config = new Config();
                // 设置上传区域
                config.Zone = Zone.ZONE_CN_South;
                var fu = new FormUploader(config);
                var result = fu.UploadData(data, saveKey, token, null);
                if (result.Code == 200)
                {
                    return saveKey;
                }
                LogHelper.ExceptionLog(new Exception($"qiniu result erro,code={result.Code},text={result.Text}"));
                return string.Empty;
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                throw;
            }
        }
    }
}