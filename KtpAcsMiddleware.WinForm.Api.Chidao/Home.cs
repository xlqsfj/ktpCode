using CCWin;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService;
using KtpAcsMiddleware.KtpApiService.Device;
using KtpAcsMiddleware.KtpApiService.PanelApi;
using KtpAcsMiddleware.KtpApiService.PanelApi.PanelMage;
using KtpAcsMiddleware.KtpApiService.PanelApiCd;
using KtpAcsMiddleware.KtpApiService.PanelApiCd.CdModel;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
using KtpAcsMiddleware.KtpApiService.TeamWorkers.Model;
using KtpAcsMiddleware.WinForm.Api.FaceRecognition;
using KtpAcsMiddleware.WinForm.Api.KtpLibrary;
using KtpAcsMiddleware.WinForm.Api.Models;
using KtpAcsMiddleware.WinForm.Api.Shared;
using KtpAcsMiddleware.WinForm.Api.TeamWorkers;
using KtpAcsMiddleware.WinForm.Api.WorkerAuths;
using KtpAcsMiddleware.WinForm.TeamWorkers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KtpAcsMiddleware.KtpApiService.PanelApi.PanelWorkerSend;

namespace KtpAcsMiddleware.WinForm
{


    public partial class Home : Skin_Color
    {
        public static Home homeform;
        static int isEnd = 0;
        static int dataCount = 0;
        public Home()
        {


            InitializeComponent();
            homeform = this;
            homeform.Enabled = false;
            WorkSysFail.workAdd.Clear();
            isEnd = 0;
            CheckForIllegalCrossThreadCalls = false;//干掉检测 不再检测跨线程
            LoadingHelper.ShowLoadingScreen();//显示

            //Thread childThread = new Thread(GetVeiveInfo);
            //childThread.Start();




        }

        private void Home_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void Home_Deactivate(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
            //this.Close();
        }
        /// <summary>
        /// 添加设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_addDevice_Click(object sender, EventArgs e)
        {
            FaceDeviceDetail addForm = new FaceDeviceDetail();
            addForm.ShowDialog();
            GetVeiveInfo();//重新绑定


        }
        /// <summary>
        /// 新增人员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWorker_Click(object sender, EventArgs e)
        {
            AddWorkerInfo worker = new AddWorkerInfo(1);
            worker.ShowDialog();
            GetVeiveInfo();
        }

        /// <summary>
        /// 查询所有设备信息
        /// </summary>
        public void GetVeiveInfo()
        {


            try
            {
                IMulePusher PanelLibrarySet = new WorkerAllGet() { RequestParam = new { id = ConfigHelper.KtpLoginProjectId } };

                PushSummary pushSummary = PanelLibrarySet.Push();
                if (!pushSummary.Success)
                {
                    MessageHelper.Show(pushSummary.Message);
                    Application.Exit();
                    return;

                }
                WorkerAllResult rr = pushSummary.ResponseData;
                label_proCount.Text = rr.data.certTotal.ToString();
                lalUnCertTotalProCount.Text = rr.data.unCertTotal.ToString();
                lab_sumCount.Text = rr.data.perTotal.ToString();
                IMulePusher pusher = new DeviceGet() { RequestParam = new { projectId = ConfigHelper.KtpLoginProjectId } };
                PushSummary push = pusher.Push();
                if (push.Success)
                {

                    dataGridView_deviceList.DataSource = push.ResponseData;


                    dataGridView_deviceList.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView_deviceList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    DataGridViewRowCollection dataGridView = dataGridView_deviceList.Rows;
                    dataCount = dataGridView.Count;
                    if (dataCount > 0)
                    {
                        //通过线程读取ip是否连接
                        for (int i = 0; i < dataGridView.Count; i++)
                        {

                            DataGridViewRow dgr = dataGridView_deviceList.Rows[i];

                            Thread t = new Thread(new ParameterizedThreadStart(Myping));
                            //t.Priority = ThreadPriority.Highest;
                            t.IsBackground = true; //关闭窗体继续执行
                            t.Start(dgr);
                            //if (i+1 == dataCount)
                            //{
                            //    t.Join();
                            //}
                        }
                    }
                    else
                    {
                        homeform.Enabled = true;
                        LoadingHelper.CloseForm();//关闭

                    }
                }
                else
                {


                    MessageHelper.Show(push.Message);
                }


            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }



        }



        private void Home_Load(object sender, EventArgs e)
        {
            this.Text = $"建信开太平【{ConfigHelper.KtpLoginProjectName}】_cd";
            lab_projoectName.Text = ConfigHelper.KtpLoginProjectName;
            label_proId.Text = ConfigHelper.KtpLoginProjectId.ToString();

            string hostName = Dns.GetHostName();//本机名              
            System.Net.IPAddress[] ipHost = Dns.GetHostAddresses(hostName);//会返回所有地址，包括IPv4和IPv6 
            foreach (IPAddress ip in ipHost)

            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    labIp.Text = ip.ToString();
                }

            }


            GetVeiveInfo();
        }

        private void button_viewDeviceUserInfo_Click(object sender, EventArgs e)
        {
            new TeamWorkerList().Show();
        }


        /// <summary>
        /// 右键编辑设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceEditMenuItem_Click(object sender, EventArgs e)
        {


            if (dataGridView_deviceList.CurrentRow != null)
            {
                //var currentRowIndex = WorkersGrid.CurrentRow.Index;
                //var workerId = WorkersGrid.Rows[currentRowIndex].Cells[0].Value.ToString();
                var DeviceId = dataGridView_deviceList.SelectedRows[0].Cells[1].Value.ToString();
                new FaceDeviceDetail(DeviceId).ShowDialog();
                GetVeiveInfo();//重新绑定

            }
            else
            {
                MessageHelper.Show("没有选中设备");
            }
        }



        private void DeviceDelMenuItem_Click(object sender, EventArgs e)
        {


            if (dataGridView_deviceList.CurrentRow != null)
            {
                try
                {
                    var DeviceId = dataGridView_deviceList.SelectedRows[0].Cells[1].Value;
                    var DeviceIp = dataGridView_deviceList.SelectedRows[0].Cells[3].Value;

                    if (MessageBox.Show($@"删除将清空人脸识别的人员,确认要删除<{DeviceIp}>吗？", @"删除提示",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        LoadingHelper.ShowLoadingScreen(LoadMagEnum.Delete);
                        IMulePusher wDeleteApi = new DeviceDelete() { RequestParam = new { proId = (int)ConfigHelper.KtpLoginProjectId, id = (int)DeviceId, ip = DeviceIp } };

                        PushSummary pushSummary = wDeleteApi.Push();
                        if (!pushSummary.Success)
                        {

                            MessageHelper.Show($"<{DeviceIp}>" + pushSummary.Message + "");
                            return;
                        }

                        DeviceDeleteResult rr = pushSummary.ResponseData;



                        if (rr.success)
                        {

                            MessageHelper.Show($"<{DeviceIp}>删除成功");
                            GetVeiveInfo();
                        }
                        else
                        {
                            MessageHelper.Show($"<{DeviceIp}>" + rr.msg + "");
                            LogHelper.EntryLog(DeviceId.ToString(), $"DelTeamWorker,id={DeviceId}");

                        }

                    }
                }
                catch (Exception ex)
                {
                    LogHelper.ExceptionLog(ex);
                    MessageHelper.Show(ex);
                }
            }
            else
            {
                MessageHelper.Show("没有选中设备");
            }

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            FormHelper.CloseOpenForms(Name);
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            AddWorkerInfo worker = new AddWorkerInfo(2);
            worker.ShowDialog();
            GetVeiveInfo();

        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit();
        }


        /// <summary>
        /// 同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSyn_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            int count = dataGridView_deviceList.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView_deviceList.Rows[i].Cells[0];
                Boolean flag = Convert.ToBoolean(checkCell.Value);
                if (flag == true)
                {
                    string check_ip = this.dataGridView_deviceList.Rows[i].Cells[3].Value.ToString();
                    //string isConn = this.dataGridView_deviceList.Rows[i].Cells[7].Value.ToString();

                    if (ConfigHelper.MyPing(check_ip))
                    {
                        list.Add(check_ip);
                    }

                }
            }
            if (list.Count() < 1)
            {
                MessageHelper.Show("未选择同步的面板");
                return;
            }
            //清空上次同步失败的人员
            WorkSysFail.list.Clear();
            WorkerSyncPrompt frm = new WorkerSyncPrompt(list);
            //注册事件
            frm.ShowSubmit += ShowExptForm;
            frm.ShowDialog();


            GetVeiveInfo();


        }
        public void ShowExptForm()
        {
            if (WorkSysFail.list.Count() > 0)
            {

                new WorkerSynFail().ShowDialog();
            }

        }

        private void labIp_Click(object sender, EventArgs e)
        {

        }

        private void shuaxin_Click(object sender, EventArgs e)
        {
            WorkSysFail.workAdd.Clear();
            homeform.Enabled = false;
            isEnd = 0;
            LoadingHelper.ShowLoadingScreen();//显示
            GetVeiveInfo();

        }

        private void Home_SizeChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public static void Myping(dynamic dgr)
        {

            bool isConn = true;
            dynamic ip = dgr.Cells["deviceIp"].Value;
            dynamic deviceNo = dgr.Cells["machineNum"].Value;
            dynamic deviceIn = dgr.Cells["Title_direction"].Value;
            var workAdd = WorkSysFail.workAdd.FirstOrDefault(a => a.deviceIp == ip);
            if (workAdd != null)
            {
                isConn = workAdd.isConn;

            }
            else
            {

                //设备是否连接
                isConn = ConfigHelper.MyPing(ip);

                if (isConn)
                {
                    var okConnPanelInfo = new WorkAddInfo { deviceIp = ip, isConn = true, deviceIn = deviceIn, deviceNo = deviceNo, magAdd = "添加中.." };
                    WorkSysFail.workAdd.Add(okConnPanelInfo);

                }

                isEnd++;

            }
            //  dgr.Cells["Title_deviceStatus"].Value = isConn ? "是" : "否";
            dgr.Cells[7].Value = isConn ? "是" : "否";
            if (isConn)
            {
                //返回设备的数量

                try
                {
                    List<PanelUserInfo> liblist = PanelBaseCd.GetPersonInfo(ip);
                  
                        //设备数量

                        dgr.Cells["panelCount"].Value = liblist.Count;
                    
                }
                catch (Exception ex)
                {

                    WorkSysFail.DeleteDeviceInfo(ip);
                    dgr.Cells[7].Value = "否";
                }

            }
            if (dgr.Cells[7].Value.ToString() == "否")//
            {


                dgr.Cells[7].Style.ForeColor = Color.Red;//将前景色设置为红色，即字体颜色设置为红色

            }

            if (isEnd == dataCount)
            {
                homeform.Enabled = true;
                LoadingHelper.CloseForm();//关闭




            }


        }

        private void lalUnCertTotalProCount_Click(object sender, EventArgs e)
        {

        }

        private void btn_Auth_Click(object sender, EventArgs e)
        {
            new WorkerAuthList().Show();
        }
        /// <summary>
        /// 系统菜单-退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_application_Exit_Click(object sender, EventArgs e)
        {
            FormHelper.CloseOpenForms(Name);
            Application.Exit();
        }

        /// <summary>
        /// 系统菜单-打开日志
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WorkSysFail.workAdd.Clear();
            homeform.Enabled = false;
            isEnd = 0;
            LoadingHelper.ShowLoadingScreen();//显示
            GetVeiveInfo();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            Type t = Type.GetType(sender.GetType().AssemblyQualifiedName);

            t.GetProperty("Cursor").SetValue(sender, System.Windows.Forms.Cursors.Hand);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Type t = Type.GetType(sender.GetType().AssemblyQualifiedName);

            t.GetProperty("Cursor").SetValue(sender, System.Windows.Forms.Cursors.Hand);
        }
    }
}
