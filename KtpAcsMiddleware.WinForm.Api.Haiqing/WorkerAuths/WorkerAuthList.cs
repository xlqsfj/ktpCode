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
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtpAcsMiddleware.WinForm.Api.WorkerAuths
{
    public partial class WorkerAuthList : Skin_Color
    {
        private string _currentTeamId;

        private List<KtpApiService.TeamWorkers.Team> _teams;




        public WorkerAuthList()
        {
            InitializeComponent();
            this.Text = "【" + ConfigHelper.KtpLoginProjectName + "】项目考勤";
            BindTeams();
            BindWorkers();
            InitGridPagingNavigatorControl();
        }

        private void WorkerAuthList_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        ///工人考勤列表绑定
        /// </summary>
        private void BindWorkers(string workerId = null)
        {
            try
            {
                var pageSize = WorkersGridPager.PageSize;
                var pageIndex = WorkersGridPager.PageIndex;

                string beginTime = time_beginTime.Value.ToString("yyyy-MM-dd 00:00:00");
                string endTime = time_endTime.Value.ToString("yyyy-MM-dd 23:59:59");
                int is_on = re_Online.Checked ? 0 : 4;
                WorkerSend workerSend = new WorkerSend
                {
                    projectId = ConfigHelper.KtpLoginProjectId,
                    pageNum = pageIndex,
                    pageSize = pageSize,
                    startTime = beginTime,
                    endTime = endTime,
                    teamId = FormatHelper.StringToInt(_currentTeamId),
                    keyWord = SearchText.Text.Trim(),
                    popState = is_on

                };

                WorkersGrid.BeginInvoke((EventHandler)delegate
                {

                    IMulePusher pusher = new WokerAuthGet() { RequestParam = workerSend };
                    PushSummary push = pusher.Push();
                    WorkerAuthResult r = push.ResponseData;
                    WorkersGridPager.PageCount = (r.data.total + pageSize - 1) / pageSize;
                    this.WorkersGrid.AutoGenerateColumns = false;//不自动 
                    this.WorkersGrid.RowTemplate.Height = 50;
                    WorkersGrid.DataSource = r.data.list.ToList();
                    WorkersGrid.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    WorkersGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                });

                WorkersGrid.BeginInvoke((EventHandler)delegate
                {

                    for (int i = 0; i < this.WorkersGrid.Rows.Count; i++)
                    {


                        //DataGridViewTextBoxCell txtcell = new DataGridViewTextBoxCell();
                        //txtcell.Value = "已成功";
                        //skingrid_sysPanel.Rows[i].Cells[3] = txtcell;
                        object path = WorkersGrid.Rows[i].Cells[10].Value;
                        Image image = GetImage(path.ToString());
                        if (image != null)
                            this.WorkersGrid.Rows[i].Cells[11].Value = image;


                    }
                });




            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }
        /// <summary>
        ///班组列表绑定
        /// </summary>
        private void BindTeams()
        {
            try
            {
                TeamsLb.Items.Clear();
                TeamsLb.Items.Add("所有");
                IMulePusher pusher = new TeamGet() { RequestParam = new { projectId = ConfigHelper.KtpLoginProjectId } };
                PushSummary push = pusher.Push();
                TeamResult r = push.ResponseData;
                _teams = r.data;



                if (_teams == null || _teams.Count == 0)
                    return;
                for (var i = 0; i < _teams.Count; i++)
                {
                    var team = _teams[i];
                    TeamsLb.Items.Add(team.organName);
                    if (!string.IsNullOrEmpty(_currentTeamId) && team.sectionId.ToString() == _currentTeamId)
                    {
                        TeamsLb.SelectedIndex = i + 1;
                    }
                }
                //if (string.IsNullOrEmpty(_currentTeamId))
                //{
                //    //_currentTeamId = _teams[0].Id;
                //    TeamsLb.SelectedIndex = 0;
                //}
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        public System.Drawing.Image GetImage(string path)
        {
            //System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open);
            //System.Drawing.Image result = System.Drawing.Image.FromStream(fs);
            Image img = null;
            try
            {
                img = Image.FromStream(System.Net.WebRequest.Create(path).GetResponse().GetResponseStream());
                Size size = new Size(100, 100);

                Point ulCorner = new Point(100, 100);
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog(ex.Message);

                return null;
                throw;
            }

            return img;

        }

        private void TeamsLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TeamsLb.SelectedItem == null)
            {
                return;
            }
            var teamName = TeamsLb.SelectedItem.ToString();
            this.Text = "【" + ConfigHelper.KtpLoginProjectName + "】项目-[" + teamName + "]组考勤";
            var team = _teams.FirstOrDefault(i => i.organName == teamName);
            _currentTeamId = team == null ? string.Empty : team.sectionId.ToString();


            WorkersGridPager.PageIndex = 1;

            //InitTeamsCmsItemsVisible();
        }

        /// <summary>
        ///     分页控件翻页事件绑定
        /// </summary>
        private void InitGridPagingNavigatorControl()
        {
            WorkersGridPager.PagingHandler = GridPagingNavigatorControlPagingEvent;
        }

        /// <summary>
        ///     分页控件翻页事件
        /// </summary>
        public void GridPagingNavigatorControlPagingEvent()
        {
            //不是点击搜索的情况下

            BindWorkers();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (time_endTime.Value.Date < time_beginTime.Value.Date)
            {
                MessageHelper.Show("结束时间不能小于开始时间！");
                return;
            }

            WorkersGridPager.PageIndex = 1;

        }

        private void WorkerDetailMenuItem_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.CurrentRow != null)
            {
                var workerId = WorkersGrid.CurrentRow.Cells["userId"].Value.ToString();
                var teamId = WorkersGrid.CurrentRow.Cells["poId"].Value.ToString();
                var recordId = WorkersGrid.CurrentRow.Cells["recordId"].Value.ToString();

                KtpApiService.TeamWorkers.Team team = _teams.Where(a => a.sectionId == FormatHelper.StringToInt(teamId.ToString())).FirstOrDefault();
                bool isEdit = false;
                new AddWorkerInfo(FormatHelper.StringToInt(workerId), isEdit, team.state, Convert.ToInt32(teamId), FormatHelper.StringToInt(recordId)).ShowDialog();
                BindWorkers(workerId);
            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }
        }

        private void re_Offline_CheckedChanged(object sender, EventArgs e)
        {


      
            if (re_Offline.Checked)
            {

                WorkersGridPager.PageIndex = 1;


            }

        }

        private void re_Online_CheckedChanged(object sender, EventArgs e)
        {

      

            if (re_Online.Checked)
            {

                WorkersGridPager.PageIndex = 1;



            }

        }

        /// <summary>
        /// 图片下载完毕，显示于对应的CELL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void wc_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            ////如果下载过程未发生错误，并且未被中途取消
            if (e.Error == null && !e.Cancelled)
            {
                ////将图片显示于对应的指定单元格， e.UserState 就是传入的 e.RowIndex
                ////e.Result 就是下载结果
                //this.WorkersGrid.Rows[(int)e.UserState].Cells["photoUrl"].Value = e.Result;

                DataGridViewImageCell imgCell = new DataGridViewImageCell();

                imgCell.Value = e.Result;
                this.WorkersGrid.Rows[(int)e.UserState].Cells[10] = imgCell;
            }
        }

        private void WorkersGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                //点击button按钮事件
                if (WorkersGrid.Columns[e.ColumnIndex].Name == "photoUrl")
                {
                    string value = this.WorkersGrid.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                    string name = this.WorkersGrid.Rows[e.RowIndex].Cells["userName"].Value.ToString();
                    string time = this.WorkersGrid.Rows[e.RowIndex].Cells["ClockTime"].Value.ToString();
                    WorkerImgAuth workerImgAuth = new WorkerImgAuth(value, name, time);
                    workerImgAuth.ShowDialog();
                }
            }
        }

        private void TeamReloadMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void WorkerAuthDetailMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键

            {

                WorkersGridPager.PageIndex = 1;

            }

        }

        private void WorkersGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //点击button按钮事件
            if (WorkersGrid.Columns[e.ColumnIndex].Name == "photoUrl")
            {
                Type t = Type.GetType(sender.GetType().AssemblyQualifiedName);

                t.GetProperty("Cursor").SetValue(sender, System.Windows.Forms.Cursors.Hand);

            }



        }

        private void WorkersGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (WorkersGrid.Columns[e.ColumnIndex].Name == "photoUrl")
            {
                Type t = Type.GetType(sender.GetType().AssemblyQualifiedName);

                t.GetProperty("Cursor").SetValue(sender, System.Windows.Forms.Cursors.Default);

            }
        }
    }
}
