using CCWin;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
using KtpAcsMiddleware.KtpApiService.TeamWorkers.Model;
using KtpAcsMiddleware.WinForm.Api.Models;
using KtpAcsMiddleware.WinForm.TeamWorkers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtpAcsMiddleware.WinForm.Api.KtpLibrary
{
    public partial class WorkerSynFail : Skin_Color
    {
        public WorkerSynFail()
        {
            InitializeComponent();
            GetSysFail();
        }

        private void WorkerSynFail_Load(object sender, EventArgs e)
        {



        }

        public void GetSysFail()
        {



            this.skingrid_sysFail.AutoGenerateColumns = false;//不自动 
            BindingSource bingding = new BindingSource();
            bingding.DataSource = WorkSysFail.list;
            bingding.ResetBindings(true);
            bingding.CurrencyManager.Refresh();
            skingrid_sysFail.DataSource = null;
            skingrid_sysFail.DataSource = bingding;//绑定数据源 

            skingrid_sysFail.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            skingrid_sysFail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (skingrid_sysFail.CurrentRow != null)
            {
                //var currentRowIndex = WorkersGrid.CurrentRow.Index;
                //var workerId = WorkersGrid.Rows[currentRowIndex].Cells[0].Value.ToString();
                var workerId = skingrid_sysFail.SelectedRows[0].Cells["userId"].Value.ToString();
                var teamId = skingrid_sysFail.SelectedRows[0].Cells["teamId"].Value;
                IMulePusher pusher = new TeamGet() { RequestParam = new { projectId = ConfigHelper.KtpLoginProjectId } };
                PushSummary push = pusher.Push();
                TeamResult r = push.ResponseData;

                Team _teams = r.data.Where(a => a.sectionId == Convert.ToInt32(teamId)).FirstOrDefault();
                new AddWorkerInfo(FormatHelper.StringToInt(workerId), true, _teams.state, Convert.ToInt32(teamId), 0, true).ShowDialog();
                if (WorkSysFail.list.Count > 0)
                {

                    GetSysFail();

                }
                else
                {
                    MessageHelper.Show("同步成功");
                    this.Close();
                }
            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }

        }

        private void skingrid_sysFail_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            int CIndex = e.ColumnIndex;
            string objectId = skingrid_sysFail["btnUpdate", e.RowIndex].Value.ToString(); // 获取所要修改关联对象的主键。
            if (CIndex == 8)
            {

                if (skingrid_sysFail.CurrentRow != null)
                {
                    //var currentRowIndex = WorkersGrid.CurrentRow.Index;
                    //var workerId = WorkersGrid.Rows[currentRowIndex].Cells[0].Value.ToString();
                    var workerId = skingrid_sysFail.SelectedRows[0].Cells["userId"].Value.ToString();
                    var teamId = skingrid_sysFail.SelectedRows[0].Cells["teamId"].Value;
                    IMulePusher pusher = new TeamGet() { RequestParam = new { projectId = ConfigHelper.KtpLoginProjectId } };
                    PushSummary push = pusher.Push();
                    TeamResult r = push.ResponseData;

                    Team _teams = r.data.Where(a => a.sectionId == Convert.ToInt32(teamId)).FirstOrDefault();
                    new AddWorkerInfo(FormatHelper.StringToInt(workerId), true, _teams.state, Convert.ToInt32(teamId), 0, true).ShowDialog();
                    if (WorkSysFail.list.Count > 0)
                    {

                        GetSysFail();

                    }
                    else
                    {
                        MessageHelper.Show("同步成功");
                        this.Close();
                    }
                }
                else
                {
                    MessageHelper.Show("没有选中的工人");
                }
            }
        }
    }
}
