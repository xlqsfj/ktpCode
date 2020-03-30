using KtpAcsMiddleware.KtpApiService;
using KtpAcsMiddleware.KtpApiService.Api;
using KtpAcsMiddleware.KtpApiService.Device;
using KtpAcsMiddleware.WinForm.Api.FaceRecognition;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtpAcsMiddleware.WinForm.FaceRecognition
{
    public partial class DeviceListForm : Form
    {
        public DeviceListForm()
        {
            InitializeComponent();
            LoadDeviceList();
        }

        public void LoadDeviceList() {


            IMulePusher pusher = new DeviceGet();
            PushSummary push = pusher.Push();

         
            DeviceListGrid.DataSource = push.ResponseData;
            DeviceListGrid.AutoGenerateColumns = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FaceDeviceDetail faceDeviceDetail = new FaceDeviceDetail();
            faceDeviceDetail.Show();
        }

        private void DeviceListForm_Load(object sender, EventArgs e)
        {

        }

        private void btnsyn_Click(object sender, EventArgs e)
        {

        }
    }
}
