
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;
namespace KtpAcsAotoUpdate
{

    public class AutoUpdater
    {
        static string FILENAME = "update.config";
        private Config config = null;
        private bool bNeedRestart = false;

        public AutoUpdater()
        {
            config = Config.LoadConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME));
        }
        /// <summary>
        /// 升级应用
        /// </summary>
        /// <param name="PanelApi">2、二代闸机 3、三代闸机 4、赤道5、海清</param>
        public AutoUpdater(int PanelApi)
        {
            if (PanelApi == 2)
            {
                FILENAME = "update2.config";
                config = Config.LoadConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "update2.config"));
            }
            if (PanelApi == 4)
            {
                FILENAME = "update4.config";
                config = Config.LoadConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "update4.config"));
            }
            if (PanelApi == 5)
            {
                FILENAME = "update5.config";
                config = Config.LoadConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "update5.config"));
            }
        }
        /// <summary>
        /// 检查新版本
        /// </summary>
        /// <exception cref="System.Net.WebException">无法找到指定资源</exception>
        /// <exception cref="System.NotSupportException">升级地址配置错误</exception>
        /// <exception cref="System.Xml.XmlException">下载的升级文件有错误</exception>
        /// <exception cref="System.ArgumentException">下载的升级文件有错误</exception>
        /// <exception cref="System.Excpetion">未知错误</exception>
        /// <returns></returns>
        public void Update()
        {
            if (!config.Enabled)

                return;
            /*
             * 请求Web服务器，得到当前最新版本的文件列表，格式同本地的FileList.xml。
             * 与本地的FileList.xml比较，找到不同版本的文件
             * 生成一个更新文件列表，开始DownloadProgress
             * <UpdateFile>
             *  <File path="" url="" lastver="" size=""></File>
             * </UpdateFile>
             * path为相对于应用程序根目录的相对目录位置，包括文件名
             */
            WebClient client = new WebClient();
            string strXml = client.DownloadString(config.ServerUrl);

            Dictionary<string, RemoteFile> listRemotFile = ParseRemoteXml(strXml);

            List<DownloadFileInfo> downloadList = new List<DownloadFileInfo>();

            //某些文件不再需要了，删除
            List<LocalFile> preDeleteFile = new List<LocalFile>();

            foreach (LocalFile file in config.UpdateFileList)
            {
                if (listRemotFile.ContainsKey(file.Path))
                {
                    RemoteFile rf = listRemotFile[file.Path];
                    if (rf.LastVer != file.LastVer)
                    {
                        downloadList.Add(new DownloadFileInfo(rf.Url, file.Path, rf.LastVer, rf.Size, rf.Explain));
                        file.LastVer = rf.LastVer;
                        file.Size = rf.Size;

                        if (rf.NeedRestart)
                            bNeedRestart = true;
                    }

                    listRemotFile.Remove(file.Path);
                }
                else
                {
                    preDeleteFile.Add(file);
                }
            }

            foreach (RemoteFile file in listRemotFile.Values)
            {
                downloadList.Add(new DownloadFileInfo(file.Url, file.Path, file.LastVer, file.Size, file.Explain));
                config.UpdateFileList.Add(new LocalFile(file.Path, file.LastVer, file.Size));

                if (file.NeedRestart)
                    bNeedRestart = true;
            }

            if (downloadList.Count > 0)
            {
                DownloadConfirm dc = new DownloadConfirm(downloadList);

                if (this.OnShow != null)
                    this.OnShow();

                if (DialogResult.OK == dc.ShowDialog())
                {
                    foreach (LocalFile file in preDeleteFile)
                    {
                        Process[] pra = Process.GetProcesses();
                        foreach (Process pro in pra)
                        {
                            if (pro.ProcessName.ToLower().StartsWith("ktpacsmiddleware.winform.api"))
                            {
                                pro.Kill();
                                pro.Close();
                            }
                        }

                        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file.Path);
                        if (File.Exists(filePath))
                            File.Delete(filePath);

                        config.UpdateFileList.Remove(file);
                    }

                    StartDownload(downloadList);
                }
            }
            else
            {
                // MessageBox.Show("当前已是最新版本。", "自动更新", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void StartDownload(List<DownloadFileInfo> downloadList)
        {
            DownloadProgress dp = new DownloadProgress(downloadList);
            if (dp.ShowDialog() == DialogResult.OK)
            {
                //更新成功
                config.SaveConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME));

                if (bNeedRestart)
                {
                    MessageBox.Show("系统应用已更新，请点击确定重新启动程序。", "自动更新", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DOUAC();

                }

            }


        }

        public static void DoWork()
        {

            Process.Start(System.Windows.Forms.Application.ExecutablePath);
            Environment.Exit(0);
        }

        public static void DOUAC()
        {
            //获得当前登录的Windows用户标示
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            //判断当前登录用户是否为管理员
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                //如果是管理员，则直接运行
                //AddSecurity();
                Thread newThread = new Thread(AutoUpdater.DoWork);
                newThread.SetApartmentState(ApartmentState.STA);
                newThread.Start();
            }
            else
            {
                //创建启动对象
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.UseShellExecute = true;
                string path = System.Windows.Forms.Application.StartupPath.Replace("program", "");

                startInfo.WorkingDirectory = Environment.CurrentDirectory;
                startInfo.FileName = System.Windows.Forms.Application.ExecutablePath;
                //设置启动动作,确保以管理员身份运行
                startInfo.Verb = "runas";
                try
                {
                    System.Diagnostics.Process.Start(startInfo);
                }
                catch
                {
                    return;
                }
                //退出
                System.Windows.Forms.Application.Exit();
            }
        }

        private Dictionary<string, RemoteFile> ParseRemoteXml(string xml)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            Dictionary<string, RemoteFile> list = new Dictionary<string, RemoteFile>();
            foreach (XmlNode node in document.DocumentElement.ChildNodes)
            {
                list.Add(node.Attributes["path"].Value, new RemoteFile(node));
            }

            return list;
        }
        public event ShowHandler OnShow;
    }



    public class RemoteFile
    {
        private string path = "";
        private string url = "";
        private string lastver = "";
        private int size = 0;
        private bool needRestart = false;
        private string explain = "";


        public string Path { get { return path; } }
        public string Url { get { return url; } }
        public string LastVer { get { return lastver; } }
        public int Size { get { return size; } }
        public bool NeedRestart { get { return needRestart; } }
        public string Explain { get { return explain; } }

        public RemoteFile(XmlNode node)
        {
            this.path = node.Attributes["path"].Value;
            this.url = node.Attributes["url"].Value;
            this.lastver = node.Attributes["lastver"].Value;
            this.size = Convert.ToInt32(node.Attributes["size"].Value);
            this.needRestart = Convert.ToBoolean(node.Attributes["needRestart"].Value);
            this.explain = node.Attributes["Explain"].Value;
        }

    }

    public class LocalFile
    {
        private string path = "";
        private string lastver = "";
        private int size = 0;

        [XmlAttribute("path")]
        public string Path { get { return path; } set { path = value; } }
        [XmlAttribute("lastver")]
        public string LastVer { get { return lastver; } set { lastver = value; } }
        [XmlAttribute("size")]
        public int Size { get { return size; } set { size = value; } }

        public LocalFile(string path, string ver, int size)
        {
            this.path = path;
            this.lastver = ver;
            this.size = size;
        }
        public LocalFile()
        {

        }

    }
    public class xmlClass
    {
        public static T DESerializer<T>(string strXML) where T : class
        {
            try
            {
                using (StringReader sr = new StringReader(strXML))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return serializer.Deserialize(sr) as T;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }

    public delegate void ShowHandler();

    public class DownloadFileInfo
    {
        string downloadUrl = "";
        string fileName = "";
        string lastver = "";
        int size = 0;

        string explain = "";
        /// <summary>
        /// 要从哪里下载文件
        /// </summary>
        public string DownloadUrl { get { return downloadUrl; } }
        /// <summary>
        /// 下载完成后要放到哪里去
        /// </summary>
        public string FileFullName { get { return fileName; } }
        public string FileName { get { return Path.GetFileName(FileFullName); } }
        public string LastVer { get { return lastver; } set { lastver = value; } }
        public int Size { get { return size; } }
        public string Explain { get { return explain; } }

        public DownloadFileInfo(string url, string name, string ver, int size, string explain)
        {
            this.downloadUrl = url;
            this.fileName = name;
            this.lastver = ver;
            this.size = size;
            this.explain = explain;
        }
    }
}
