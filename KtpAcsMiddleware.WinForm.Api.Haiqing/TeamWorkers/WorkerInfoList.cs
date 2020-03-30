using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
using KtpAcsMiddleware.WinForm.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtpAcsMiddleware.WinForm.Api.TeamWorkers
{
    public partial class WorkerInfoList : Form
    {
        public WorkerInfoList()
        {
            InitializeComponent();
        }

        private void WorkerInfoList_Load(object sender, EventArgs e)
        {
            BindWorkers();

        }

        /// <summary>
        ///     工人列表绑定
        /// </summary>
        private void BindWorkers(string workerId = null)
        {
            try
            {
                WorkerSend workerSend = new WorkerSend { projectId = ConfigHelper.KtpLoginProjectId, pageNum = 1, pageSize = 20 };
                IMulePusher pusher = new WokersGet() { RequestParam = workerSend };
                PushSummary push = pusher.Push();
                WorkersResult r = push.ResponseData;
                WorkersGrid.DataSource = r.data.list.ToList();

            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }
    }
}
