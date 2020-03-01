using CCWin;
using KtpAcsMiddleware.KtpApiService.Asp.NewTeamWorkerSyncs;
using KtpAcsMiddleware.KtpApiService.Asp.TeamSyncs.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcs.WinForm.Models;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.AppService.ServiceModel;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Organizations;
using KtpAcs.WinForm.Shared;
using KtpAcsMiddleware.Infrastructure.Serialization;

namespace KtpAcs.WinForm.TeamWorkers
{
    public partial class WorkerInfo : Skin_Color
    {
        private IList<Team> _teams;
        private string _currentTeamId;
        private int? _currentState;
        private IList<WorkerDto> _workers;
        public WorkerInfo()
        {
            InitializeComponent();
            LoadTeam();
            //加载控件
            InitGridPagingNavigatorControl();
            //工人认证状态
            BindWorkerAuthenticationStates();
            //工人列表
            BindTeamWorkers();

        }

        /// <summary>
        ///     分页控件翻页事件绑定
        /// </summary>
        private void InitGridPagingNavigatorControl()
        {
            ktpGridPager.PagingHandler = GridPagingNavigatorControlPagingEvent;
        }

        /// <summary>
        ///     分页控件翻页事件
        /// </summary>
        public void GridPagingNavigatorControlPagingEvent()
        {
            BindTeamWorkers();
        }

        public void LoadTeam()
        {

            if (ConfigHelper.KtpUploadNetWork)
            {//网络连接正常情况下拉取班组
                TeamApi teamApi = new TeamApi();
                teamApi.LoadTeams();
            }

            try
            {
                TeamsLb.Items.Clear();
                TeamsLb.Items.Add("所有");
                _teams = ServiceFactory.TeamService.GetAll();
                if (_teams == null || _teams.Count == 0)
                    return;
                for (var i = 0; i < _teams.Count; i++)
                {
                    var team = _teams[i];
                    TeamsLb.Items.Add(team.Name);
                    if (!string.IsNullOrEmpty(_currentTeamId) && team.Id == _currentTeamId)
                    {
                        TeamsLb.SelectedIndex = i + 1;
                    }
                }
                if (string.IsNullOrEmpty(_currentTeamId))
                {
                    //_currentTeamId = _teams[0].Id;
                    TeamsLb.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        /// <summary>
        ///     班组列表绑定
        /// </summary>
        private void BindTeams()
        {
            try
            {
                TeamsLb.Items.Clear();
                TeamsLb.Items.Add("所有");
                _teams = ServiceFactory.TeamService.GetAll();
                if (_teams == null || _teams.Count == 0)
                    return;
                for (var i = 0; i < _teams.Count; i++)
                {
                    var team = _teams[i];
                    TeamsLb.Items.Add(team.Name);
                    if (!string.IsNullOrEmpty(_currentTeamId) && team.Id == _currentTeamId)
                    {
                        TeamsLb.SelectedIndex = i + 1;
                    }
                }
                if (string.IsNullOrEmpty(_currentTeamId))
                {
                    //_currentTeamId = _teams[0].Id;
                    TeamsLb.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        /// <summary>
        ///     工人列表绑定
        /// </summary>
        private void BindTeamWorkers(string workerId = null)
        {
            try
            {
                var pageSize = ktpGridPager.PageSize;
                var pageIndex = ktpGridPager.PageIndex;

                PagedResult<WorkerDto> pagedTeamWorkers;

                pagedTeamWorkers = ServiceFactory.WorkerService.GetPaged(pageIndex, pageSize,
                _currentTeamId, SearchText.Text,
          (WorkerAuthenticationState)_currentState);

                //总页数
                ktpGridPager.PageCount = (pagedTeamWorkers.Count + pageSize - 1) / pageSize;

                _workers = pagedTeamWorkers.Entities.ToList();
                this.WorkersGrid.AutoGenerateColumns = false;//不自动 
                WorkersGrid.DataSource = _workers;
                for (var rowIndex = 0; rowIndex < WorkersGrid.Rows.Count; rowIndex++)
                {
                    var gridWorkerId = WorkersGrid.Rows[rowIndex].Cells["Id"].Value.ToString();
                    var gridWorker = _workers.First(i => i.Id == gridWorkerId);
                    if (gridWorkerId == workerId)
                    {
                        WorkersGrid.Rows[rowIndex].Selected = true;
                    }

                }

            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        private void btn_addTeam_Click(object sender, EventArgs e)
        {
            new addTeam().ShowDialog();
        }

        private void WorkerInfo_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        ///     工人认证状态下拉框绑定
        /// </summary>
        private void BindWorkerAuthenticationStates()
        {
            var authenticationStates = WorkerAuthenticationState.All.GetDescriptions();
            WorkerStatesCb.DataSource = authenticationStates;
            WorkerStatesCb.DisplayMember = "Value";
            WorkerStatesCb.ValueMember = "Key";
            // WorkerStatesCb.SelectedIndex = (int)WorkerAuthenticationState.All;
        }
        private void TeamsLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TeamsLb.SelectedItem == null)
            {
                return;
            }
            //设置当前班组ID
            var teamName = TeamsLb.SelectedItem.ToString();
            var team = _teams.FirstOrDefault(i => i.Name == teamName);
            _currentTeamId = team == null ? string.Empty : team.Id.ToString();
            if (TeamsLb.SelectedItem != null)
            {
                ktpGridPager.PageIndex = 1;
            }


        }


        private void WorkerPushMenuItem_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.CurrentRow != null)
            {
                var workerId = WorkersGrid.SelectedRows[0].Cells[0].Value.ToString();
                var workerName = WorkersGrid.SelectedRows[0].Cells[1].Value.ToString();
                if (MessageBox.Show($@"确认使用本地数据覆盖云端<{workerName}>吗？", @"推送提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    new SynWorkerForm(workerId).ShowDialog();
                    BindTeamWorkers(workerId);
                }
            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }
        }

        private void btnSyn_Click(object sender, EventArgs e)
        {
            new SynWorkerForm().ShowDialog();
            BindTeamWorkers();
        }

        private void WorkerAuthenticationStatesCb_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (_currentState == null)
            {
                _currentState = 0;
            }
            else
            {
                _currentState = FormatHelper.StringToInt(WorkerStatesCb.SelectedValue.ToString());
                ktpGridPager.PageIndex = 1;
            }
        }


        private void btn_Search_Click(object sender, EventArgs e)
        {
            ktpGridPager.PageIndex = 1;
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.CurrentRow != null)
            {
                try
                {
                    var workerId = WorkersGrid.SelectedRows[0].Cells["Id"].Value.ToString();
                    var workerName = WorkersGrid.SelectedRows[0].Cells["WorkerName"].Value.ToString();
                    if (MessageBox.Show($@"确认要删除<{workerName}>吗？", @"删除提示",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        ServiceFactory.WorkerCommandService.Remove(workerId);
                        LogHelper.EntryLog(AppLoginInfo.UserId, $"DelTeamWorker,id={workerId}");

                        MessageHelper.Show($"<{workerName}>删除成功");
                        BindTeamWorkers();
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
                MessageHelper.Show("没有选中的工人");
            }
        }
        /// <summary>
        /// 查看工人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkerDetailMenuItem_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.CurrentRow != null)
            {
                //var currentRowIndex = WorkersGrid.CurrentRow.Index;
                //var workerId = WorkersGrid.Rows[currentRowIndex].Cells[0].Value.ToString();
                var workerId = WorkersGrid.SelectedRows[0].Cells["Id"].Value.ToString();
                new AddWorkerInfo(workerId, false).ShowDialog();

            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void con_Edit_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.CurrentRow != null)
            {
                //var currentRowIndex = WorkersGrid.CurrentRow.Index;
                //var workerId = WorkersGrid.Rows[currentRowIndex].Cells[0].Value.ToString();
                var workerId = WorkersGrid.SelectedRows[0].Cells["Id"].Value.ToString();
                new AddWorkerInfo(workerId, true).ShowDialog();
                ktpGridPager.PageIndex = 1;
            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }
        }
        /// <summary>
        /// 拉取所有工人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkerPullMenuItem_Click(object sender, EventArgs e)
        {
            new SynWorkerForm(1).ShowDialog();
            ktpGridPager.PageIndex = 1;
        }
        /// <summary>
        /// 设置为新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void con_reset_add_Click(object sender, EventArgs e)
        {

            if (WorkersGrid.CurrentRow == null)
            {
                MessageHelper.Show("没有选中的工人");
                return;
            }
            try
            {
                var workerId = WorkersGrid.SelectedRows[0].Cells["Id"].Value.ToString();
                var workerName = WorkersGrid.SelectedRows[0].Cells["WorkerName"].Value.ToString();
                if (MessageBox.Show($@"确认要从所有设备中将<{workerName}>设为新添加吗？", @"设置新添加提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ServiceFactory.WorkerCommandService.ChangeWorkerFaceDeviceStatesToReAdd(workerId);
                    MessageHelper.Show($"<{workerName}>已从所有设备中设为删除，稍后设备会过来重新请求");
                    ktpGridPager.PageIndex = 1;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        private void TeamAddMenuItem_Click(object sender, EventArgs e)
        {
            addTeam team = new addTeam();
            team.Show();


        }

        private void TeamWorkerAddMenuItem_Click(object sender, EventArgs e)
        {
            WorkerInfo addTeam = new WorkerInfo();
            addTeam.Show();
            BindTeams();
        }

        private void TeamEditMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentTeamId))
            {
                MessageHelper.Show("没有选中的班组");
                return;
            }
            new addTeam(_currentTeamId).ShowDialog();
            BindTeams();
            ktpGridPager.PageIndex = 1;
        }
    }
}
