using KtpAcs.WinService;
using KtpAcsMiddleware.Infrastructure.Utilities;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KtpAcs.WinServiceClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        string serviceFilePath = $"{Application.StartupPath}\\KtpAcs.WinService.exe";

        string serviceName = "ktpService";
        /// <summary>
        /// 安装服务事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "服务安装中";
            if (ServiceConfig.IsServiceExisted(serviceName))
            {
                MessageBox.Show("服务已安装");
            }
            //    this.UninstallService(serviceName);

            this.InstallService(serviceFilePath);
            MessageBox.Show("服务安装完成");
            button1.Text = "服务安装";
        }




        //安装服务

        private void InstallService(string serviceFilePath)

        {

            using (AssemblyInstaller installer = new AssemblyInstaller())

            {

                installer.UseNewContext = true;

                installer.Path = serviceFilePath;

                IDictionary savedState = new Hashtable();

                installer.Install(savedState);

                installer.Commit(savedState);

            }

        }



        //卸载服务

        private void UninstallService(string serviceFilePath)

        {

            using (AssemblyInstaller installer = new AssemblyInstaller())

            {

                installer.UseNewContext = true;

                installer.Path = serviceFilePath;

                installer.Uninstall(null);

            }

        }

   



        //停止服务

        private void ServiceStop(string serviceName)

        {

            using (ServiceController control = new ServiceController(serviceName))

            {

                if (control.Status == ServiceControllerStatus.Running)

                {

                    control.Stop();

                }

            }

        }
        /// <summary>
        /// 启动服务事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = "服务启动中";
            if (ServiceConfig.IsServiceExisted(serviceName))
                ServiceConfig.ServiceStart(serviceName);

            MessageBox.Show("服务已启动");
            button2.Text = "服务启动";
        }

        /// <summary>
        ///停止事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            button4.Text = "服务停止中";
            if (ServiceConfig.IsServiceExisted(serviceName)) this.ServiceStop(serviceName);
            MessageBox.Show("服务已停止");
            button4.Text = "服务停止";
        }

        /// <summary>
        /// 卸载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            button3.Text = "服务卸载中";
            if (ServiceConfig.IsServiceExisted(serviceName))

            {

                this.ServiceStop(serviceName);

                this.UninstallService(serviceFilePath);

            }
            MessageBox.Show("服务已卸载");
            button3.Text = "卸载服务";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Service1 service1 = new Service1();
            service1.ontest();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Text = "上传中。。";
            //var faceDevices = UnitOfWork.DataContext.FaceDevices.Where(t => t.IsDelete == false).ToArray();
            try
            {
                string connectionString = ConfigHelper.Conn;
                string sql = "select * from[dbo].[FileMap]";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                DataTable dt = SqlHelper.ExecuteDataTable(sqlConnection, sql, CommandType.Text, null);

                foreach (DataRow r in dt.Rows)
                {
                    var localFile = r["PhysicalFullName"].ToString();
                    var currentName = r["QiniuKey"].ToString();
                    if (string.IsNullOrEmpty(localFile) || string.IsNullOrEmpty(currentName))
                        continue;

                    var qinieKey = QiniuHelper.UploadFile(localFile, currentName);
                }

            }
            catch (Exception ex)
            {

                LogHelper.ErrorLog(ex.Message);
            }
            MessageBox.Show("上传结束");
            button7.Text = "上传图片";
        }
    }
}
