using CCWin;
using KtpAcs.WinForm.Auths;
using KtpAcs.WinForm.Device;
using KtpAcs.WinForm.Models;
using KtpAcs.WinForm.Shared;
using KtpAcs.WinForm.TeamWorkers;
using KtpAcs.WinServiceClient;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.AppService.ServiceModel;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtpAcs.WinForm
{
    public partial class Home : Skin_Color
    {
        public Home()
        {
            InitializeComponent();
            GetDeviceInfo();
            GetNetWorkInfoLoad();
        }

        public void GetDeviceInfo()
        {

            IList<HomeDeviceDto> _devices = ServiceFactory.FaceWorkerServiceDevice.GetDeviceList();


            this.dataGridDivce.AutoGenerateColumns = false;//不自动 
            dataGridDivce.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridDivce.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridDivce.DataSource = _devices;
            DataGridViewRowCollection dataGridView = dataGridDivce.Rows;
            //通过线程读取ip是否连接
            for (int i = 0; i < dataGridView.Count; i++)
            {




                DataGridViewRow dgr = dataGridDivce.Rows[i];

                Thread t = new Thread(new ParameterizedThreadStart(Myping));
                t.IsBackground = true; //关闭窗体继续执行
                t.Start(dgr);

            }
        }
        //判断面板是否连接成功
        public void Myping(dynamic dgv)
        {
            DataGridViewRow dgr = dgv;
            dynamic ip = dgr.Cells["IpAddress"].Value;
            bool isConn = BellDeviceSyncFaceLibrary(ip);
            dgr.Cells[4].Value = isConn ? "是" : "否";
            if (dgr.Cells[4].Value.ToString() == "否")//
            {


                dgr.Cells[4].Style.ForeColor = Color.Red;//将前景色设置为红色，即字体颜色设置为红色

            }
        }

        /// <summary>
        ///     发送通知设备请求
        /// </summary>
        private static bool BellDeviceSyncFaceLibrary(string faceDeviceIpAddress)
        {
            if (string.IsNullOrEmpty(faceDeviceIpAddress))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(faceDeviceIpAddress)));
            }
            var url = $"http://{faceDeviceIpAddress}:8080/?action=2";
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = httpClient.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {

                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception)
            {
                return false;

            }
        }
        //通知
        private void btnSyn_Click(object sender, EventArgs e)
        {
            new SynDeviceForm().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddWorkerInfo().Show();
        }

        private void button_addDevice_Click(object sender, EventArgs e)
        {
            new DeviceInfo().ShowDialog();
        }

        private void btnWorker_Click(object sender, EventArgs e)
        {

        }

        private void btn_Auth_Click(object sender, EventArgs e)
        {
            new WorkerAuths().Show();
        }
        /// <summary>
        /// 人员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_viewDeviceUserInfo_Click(object sender, EventArgs e)
        {
            WorkerInfo workerInfo = new WorkerInfo();
            workerInfo.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void skinPanel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, skinPanel1.ClientRectangle,
Color.DimGray, 1, ButtonBorderStyle.Dashed, //左边
   Color.DimGray, 1, ButtonBorderStyle.Dashed, //上边
   Color.DimGray, 1, ButtonBorderStyle.Dashed, //右边
   Color.DimGray, 1, ButtonBorderStyle.Dashed);//底边
        }

        private void Home_Load(object sender, EventArgs e)
        {
            LoadDataMethod();

        }
        /// <summary>
        /// 加载主页数据
        /// </summary>
        private void LoadDataMethod()
        {
            this.Text = $"建行开太平【{ConfigHelper.KtpLoginProjectName}】";
            lab_projoectName.Text = ConfigHelper.KtpLoginProjectName;
            label_proId.Text = ConfigHelper.KtpLoginProjectId.ToString();
            int count = ServiceFactory.WorkerService.GetWorkerCount(WorkerAuthenticationState.All);
            lab_sumCount.Text = count.ToString();
            lalUnCertTotalProCount.Text = ServiceFactory.WorkerService.GetWorkerCount(WorkerAuthenticationState.WaitFor).ToString();
            label_proCount.Text = ServiceFactory.WorkerService.GetWorkerCount(WorkerAuthenticationState.Delete).ToString();
        }

        /// <summary>
        /// 加载网络信息
        /// </summary>
        private void GetNetWorkInfoLoad()
        {

            //ip号检测
            string hostName = Dns.GetHostName();//本机名              
            System.Net.IPAddress[] ipHost = Dns.GetHostAddresses(hostName);//会返回所有地址，包括IPv4和IPv6 
            foreach (IPAddress ip in ipHost)

            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    labIp.Text = ip.ToString();
                }

            }

            //网络情况是否联网
            string url = "www.baidu.com";
            bool isconn = ConfigHelper.KtpUploadNetWork;
            Ping ping = new Ping();
            try
            {
                int timeout = 5;//设置超时时间             
                PingReply pr = ping.Send(url, timeout);
                if (pr.Status == IPStatus.Success)
                {//连接正常情况下

                    ConfigHelper.KtpUploadNetWork = true;

                }
                if (pr.Status == IPStatus.TimedOut)
                    pl_wl.Visible = true;

            }
            catch (Exception ex)
            {

                pl_wl.Visible = true;
                LogHelper.ExceptionLog(ex);
            }


            //服务是否启动
            try
            {
                ServiceController cs = new ServiceController();
                cs.MachineName = "localhost"; //主机名称
                cs.ServiceName = "ktpService"; //服务名称
                cs.Refresh();
                if (cs.Status == ServiceControllerStatus.Running)
                {
                    //判断已经运行
                }
                else if (cs.Status == ServiceControllerStatus.Stopped)
                {
                    leb_service.Visible = true;
                    btn_service.Visible = true;

                }
                else
                {

                    leb_service.Visible = true;
                    btn_service.Visible = true;
                }
            }
            catch (Exception ex)
            {

                leb_service.Text = "服务未安装或已删除，不能自动同步到服务器，请安装ktpService服务";
                leb_service.Visible = true;
                btn_service.Visible = false;
                LogHelper.ExceptionLog(ex);
            }

        }

        private void btn_service_Click(object sender, EventArgs e)
        {
            try
            {
                string serviceName = "ktpService";
                if (ServiceConfig.IsServiceExisted(serviceName))
                    ServiceConfig.ServiceStart(serviceName);
                MessageHelper.Show("服务已启动");
                btn_service.Visible = false;
                leb_service.Visible = false;
            }
            catch (Exception ex)
            {
                MessageHelper.Show("服务启动失败，请重新安装服务");

                LogHelper.ExceptionLog(ex);

            }
        }
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GetDeviceInfo();
            GetNetWorkInfoLoad();
            LoadDataMethod();

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Type t = Type.GetType(sender.GetType().AssemblyQualifiedName);

            t.GetProperty("Cursor").SetValue(sender, System.Windows.Forms.Cursors.Hand);
        }
        /// <summary>
        /// 点击操作进设备工人列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridDivce_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int CIndex = e.ColumnIndex;
            string objectId = dataGridDivce["btnOper", e.RowIndex].Value.ToString(); // 获取所要修改关联对象的主键。
            if (CIndex == 8)
            {
                if (dataGridDivce.CurrentRow != null)
                {
                    var dName = dataGridDivce.SelectedRows[0].Cells["dName"].Value;
                    new WorkerDeviceInfo(dName).Show();
                }
            }
        }

        /// <summary>
        /// 点击右键下拉框编辑设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void con_updateDevice_Click(object sender, EventArgs e)
        {
            if (dataGridDivce.CurrentRow != null)
            {
                try
                {
                    //设备id
                    var deviceId = dataGridDivce.SelectedRows[0].Cells["dId"].Value.ToString();

                    new DeviceInfo(deviceId).ShowDialog();
                    GetDeviceInfo();

                }
                catch (Exception ex)
                {
                    LogHelper.ExceptionLog(ex);
                    MessageHelper.Show(ex);
                }
            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }
        }
        /// <summary>
        /// 通知当前设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void con_current_notice_Click(object sender, EventArgs e)
        {
            var ip = "";
            try
            {

                if (dataGridDivce.CurrentRow == null)
                {
                    throw new PreValidationException("没有选中的设备");
                }
                ip = dataGridDivce.SelectedRows[0].Cells["IpAddress"].Value.ToString();
                new SynDeviceForm(ip).ShowDialog();

            }


            catch (PreValidationException ex)
            {
                MessageHelper.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageHelper.Show(ex);
            }

        }
        /// <summary>
        /// 定时执行刷新数据900000=15分钟刷新一次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {

            GetDeviceInfo();
            GetNetWorkInfoLoad();
            LoadDataMethod();
        }
        /// <summary>
        /// 打开日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_application_journal_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\logs";
            if (Directory.Exists(path))
                System.Diagnostics.Process.Start(path);
            else
                MessageHelper.Show("日志目录还未生成！");
        }
        /// <summary>
        /// 退出应用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_application_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// 增加时是否可以编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_application_IsManualAddInfo_CheckStateChanged(object sender, EventArgs e)
        {
            CheckState check = menu_application_IsManualAddInfo.CheckState;
            if (check == CheckState.Checked)
                modifyItem("IsManualAddInfo", "True");
            else
                modifyItem("IsManualAddInfo", "False");
        }
        public void modifyItem(string keyName, string newKeyValue)
        {    //修改配置文件中键为keyName的项的值   

            //读取程序集的配置文件
            string assemblyConfigFile = Assembly.GetEntryAssembly().Location;
            string appDomainConfigFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //获取appSettings节点
            AppSettingsSection appSettings = (AppSettingsSection)config.GetSection("appSettings");

            //删除name，然后添加新值
            appSettings.Settings.Remove(keyName);
            appSettings.Settings.Add(keyName, newKeyValue);
            //保存配置文件
            config.Save();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            Type t = Type.GetType(sender.GetType().AssemblyQualifiedName);

            t.GetProperty("Cursor").SetValue(sender, System.Windows.Forms.Cursors.Hand);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            Type t = Type.GetType(sender.GetType().AssemblyQualifiedName);

            t.GetProperty("Cursor").SetValue(sender, System.Windows.Forms.Cursors.Hand);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new DeviceInfo().ShowDialog();
        }

        private void pictureBox3_MouseEnter_1(object sender, EventArgs e)
        {
            Type t = Type.GetType(sender.GetType().AssemblyQualifiedName);

            t.GetProperty("Cursor").SetValue(sender, System.Windows.Forms.Cursors.Hand);

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            new AddWorkerInfo().Show();
        }
    }
}
