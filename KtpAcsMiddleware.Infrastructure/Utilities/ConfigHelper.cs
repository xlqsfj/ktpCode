using System;
using System.Configuration;
using System.IO;
using System.Net.NetworkInformation;
using System.Web;

namespace KtpAcsMiddleware.Infrastructure.Utilities
{
    public class ConfigHelper
    {
        /// <summary>
        ///     是否属于调式环境
        /// </summary>
        public static bool IsDebug
        {
            get
            {
                return false;
                //if (ConfigurationManager.AppSettings["IsDebug"] != null)
                //    return bool.Parse(ConfigurationManager.AppSettings["IsDebug"]);
                //return true;false
            }
        }

        /// <summary>
        ///     是否拉取开太平数据
        /// </summary>
        public static bool IsLoadKtpData
        {
            get
            {
                if (ConfigurationManager.AppSettings["IsLoadKtpData"] != null)
                    return bool.Parse(ConfigurationManager.AppSettings["IsLoadKtpData"]);
                return false;
            }
        }
        /// <summary>
        ///保存图片是否是在应用目录上传
        /// </summary>
        public static bool IsApplicationUpload { get; set; }
        public static bool isDivceAdd;
        public static string _isDivceAddString;
        /// <summary>
        /// 是否已有面板连接
        /// </summary>
        public static bool IsDivceAdd
        {
            get
            {

                if (string.IsNullOrEmpty(_isDivceAddString))
                {
                    if (ConfigurationManager.AppSettings["IsDivceAdd"] != null)
                        return bool.Parse(ConfigurationManager.AppSettings["IsDivceAdd"]);
                    return true;
                }
                else {
                    return isDivceAdd;
                }
                 
             
            }
            set
            {
                _isDivceAddString = "1";
                isDivceAdd = value;
            }

        }

        /// <summary>
        ///     KtpAcsMiddleware数据库链接
        /// </summary>
        public static string Conn
        {
            get
            {
                if (ConfigurationManager.AppSettings["Conn"] != null)
                    return ConfigurationManager.AppSettings["Conn"];
                return "Data Source=.;Initial Catalog=KtpAcsMiddleware;Integrated Security=True";
            }
        }

        /// <summary>
        ///     开太平对接签名token
        /// </summary>
        public static string KtpSginToken
        {
            get
            {
                if (ConfigurationManager.AppSettings["KtpSginToken"] != null)
                    return ConfigurationManager.AppSettings["KtpSginToken"];
                return "GRMd9m4GbH";
            }
        }

        /// <summary>
        ///     开太平对接签名key
        /// </summary>
        public static string KtpSginKey
        {
            get
            {
                if (ConfigurationManager.AppSettings["KtpSginKey"] != null)
                    return ConfigurationManager.AppSettings["KtpSginKey"];
                return "q8AKR3by";
            }
            set { }
        }
        private static int _PanelApiType;
        /// <summary>
        ///面板厂商类型
        /// </summary>
        public static int PanelApiType
        {
            get { return _PanelApiType; }
            set { _PanelApiType = value; }
        }
        /// <summary>
        ///     开太平登录对接LoginToken
        /// </summary>
        public static string KtpLoginToken
        {
            get { return _KtpLoginToken; }
            set { _KtpLoginToken = value; }
        }

        public static string _KtpLoginToken;

        /// <summary>
        ///     开太平登录对接返回的项目id
        /// </summary>
        public static int KtpLoginProjectId
        {
            get { return _KtpLoginProjectId; }
            set { _KtpLoginProjectId = value; }
        }
        /// <summary>
        ///开太平登录对接返回的项目名字
        /// </summary>
        public static string KtpLoginProjectName
        {
            get { return _KtpLoginProjectName; }
            set { _KtpLoginProjectName = value; }
        }
        private static bool _KtpUploadNetWork;
        /// <summary>
        /// 是否连接网络，用于是否下发接口
        /// </summary>
        public static bool KtpUploadNetWork {
            get { return _KtpUploadNetWork; }
            set { _KtpUploadNetWork = value; }
        }
        /// <summary>
        ///     开太平登录对接返回的项目id
        /// </summary>
        public static int _KtpLoginProjectId;

        public static string _KtpLoginProjectName;
        /// <summary>
        ///     项目ID
        /// </summary>
        public static int ProjectId
        {
            get
            {
                if (KtpLoginProjectId !=0)
                    return KtpLoginProjectId;
                if (ConfigurationManager.AppSettings["ProjectId"] != null)
                    return int.Parse(ConfigurationManager.AppSettings["ProjectId"]);
                //可用户测试的项目ID：24、70
                return 138;
            }
        }

        /// <summary>
        ///     域名
        /// </summary>
        public static string BaseUrl
        {
            get
            {
                if (ConfigurationManager.AppSettings["BaseUrl"] != null)
                {
                    return ConfigurationManager.AppSettings["BaseUrl"];
                }
                if (HttpContext.Current.Request.Url.ToString().StartsWith("https://"))
                {
                    return $"https://{HttpContext.Current.Request.Url.Host}";
                }
                return $"http://{HttpContext.Current.Request.Url.Host}";
            }
        }

        /// <summary>
        ///     开太平Api基础链接
        /// </summary>
        public static string KtpApiAspBaseUrl
        {
            get
            {
               
                if (ConfigurationManager.AppSettings["KtpApiBaseUrl"] != null)
                {
                    return ConfigurationManager.AppSettings["KtpApiBaseUrl"];
                }

             
                return "http://tcs.ktpis.com/zj/";
            }
        }

        /// <summary>
        /// 赤道初始化密码
        /// </summary>
        public static string CdPassPwd
        {
            get
            {

                if (ConfigurationManager.AppSettings["CdPassPwd"] != null)
                {
                    return ConfigurationManager.AppSettings["CdPassPwd"];
                }


                return "755626";
            }
        }


        /// <summary>
        ///     开太平Java基础链接
        /// </summary>
        public static string KtpApiBaseJavaUrl
        {
            get
            {
                if (ConfigurationManager.AppSettings["KtpApiBaseJavaUrl"] != null)
                {
                    return ConfigurationManager.AppSettings["KtpApiBaseJavaUrl"];
                }
                return "https://gatetest.ktpis.com/";



            }
        }

        /// <summary>
        ///     开太平Api基础链接
        /// </summary>
        public static string KtpApiBaseUrl
        {
            get
            {
                if (ConfigurationManager.AppSettings["KtpApiBaseUrl"] != null)
                {
                    return ConfigurationManager.AppSettings["KtpApiBaseUrl"];
                }
                return "https://admin.ktpis.com/";
            }
        }

        /// <summary>
        ///     开太平ApiToken authorization
        /// </summary>
        public static string KtpApiAuthorization
        {
            get
            {
                if (ConfigurationManager.AppSettings["KtpApiAuthorization"] != null)
                {
                    return ConfigurationManager.AppSettings["KtpApiAuthorization"];
                }
                return "YXBwOk5Ja2s2OGVfM0FEYVM=";
            }
        }

        /// <summary>
        ///     新用户默认密码
        /// </summary>
        public static string DefaultUserPwd
        {
            get
            {
                if (ConfigurationManager.AppSettings["DefaultUserPwd"] != null)
                    return ConfigurationManager.AppSettings["DefaultUserPwd"];
                return "123456";
            }
        }

        /// <summary>
        ///     服务睡眠时间,默认5分钟=300000毫秒
        /// </summary>
        public static int ThreadSleepTime
        {
            get
            {
                if (ConfigurationManager.AppSettings["ThreadSleepTime"] != null)
                {
                    return int.Parse(ConfigurationManager.AppSettings["ThreadSleepTime"]);
                }
                return 300000;
            }
        }

        /// <summary>
        ///     服务睡眠时间,默认1分钟=60000毫秒
        /// </summary>
        public static int ThreadSleepTimeAuth
        {
            get
            {
                if (ConfigurationManager.AppSettings["ThreadSleepTimeAuth"] != null)
                {
                    return int.Parse(ConfigurationManager.AppSettings["ThreadSleepTimeAuth"]);
                }
                return 60000;
            }
        }

        /// <summary>
        ///     服务运行时间(HH:mm)
        /// </summary>
        public static string ThreadRunTime
        {
            get
            {
                if (ConfigurationManager.AppSettings["ThreadRunTime"] == null
                    || ConfigurationManager.AppSettings["ThreadRunTime"].Length != 5
                    || !ConfigurationManager.AppSettings["ThreadRunTime"].Contains(":"))
                {
                    return string.Empty;
                }
                return ConfigurationManager.AppSettings["ThreadRunTime"];
            }
        }

        /// <summary>
        ///     文件路径(自定义)
        /// </summary>
        public static string CustomFilesDir
        {
            get
            {
                string dir;

                if (!ConfigHelper.KtpUploadNetWork|| ConfigHelper.IsApplicationUpload)
                {
                    dir = Path.Combine(SiteContentDir, "data\\img") + "\\";
                }
               else if (ConfigurationManager.AppSettings["CustomFilesDir"] != null)
                {
                    dir = ConfigurationManager.AppSettings["CustomFilesDir"];
                    if (!dir.EndsWith("\\"))
                    {
                        dir = dir + "\\";
                    }
                }
                else
                {
                    dir = Path.Combine(SiteContentDir, "_Files") + "\\";
                }
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                return dir;
            }
        }

        /// <summary>
        ///     文件保存文件夹是否在本机
        ///     winfrom使用，在本机则直接存储文件，不调用webservice
        /// </summary>
        public static bool CustomFilesDirIsLocal
        {
            get
            {
                if (ConfigurationManager.AppSettings["CustomFilesDirIsLocal"] != null)
                {
                    return bool.Parse(ConfigurationManager.AppSettings["CustomFilesDirIsLocal"]);
                }
                if (ConfigurationManager.AppSettings["CustomFilesDir"] != null)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///     文件存储路径网址
        /// </summary>
        public static string CustomFilesDirUrl => $"{BaseUrl}/_Files/";

        /// <summary>
        ///     获取新的Guid
        /// </summary>
        public static string NewGuid => Guid.NewGuid().ToString("N");

        /// <summary>
        ///     获取带时间的新的Guid(yyyyMMddHHmm+NewGuid)
        /// </summary>
        public static string NewTimeGuid
        {
            get { return $"{DateTime.Now:yyyyMMddHHmm}_{Guid.NewGuid():N}"; }
        }

        /// <summary>
        ///     获取当前时间全数字形式fff(24小时制-yyyyMMddHHmmssfff)
        /// </summary>
        public static string CurrentTimeNumberfff => DateTime.Now.ToString("yyyyMMddHHmmssfff");

        /// <summary>
        ///     基目录
        /// </summary>
        public static string SiteContentDir => AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        ///     根据Key获取AppSetting信息
        /// </summary>
        /// <param name="key">app setting key</param>
        /// <returns></returns>
        public static string GetAppSettings(string key)
        {
            if (ConfigurationManager.AppSettings[key] != null)
                return ConfigurationManager.AppSettings[key].Trim();
            return null;
        }

        //ping 检测连通性
        public static bool MyPing(string ip)
        {
            bool isconn = true;
            Ping ping = new Ping();
            try
            {
                PingReply pr;
                pr = ping.Send(ip);
                if (pr.Status != IPStatus.Success)
                {
                    isconn = false;
                }
            }
            catch
            {
                isconn = false;
            }
            
            return isconn;
        }

   
    }
}