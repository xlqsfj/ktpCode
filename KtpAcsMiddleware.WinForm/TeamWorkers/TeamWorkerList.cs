using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Organizations;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Models;
using KtpAcsMiddleware.WinForm.Shared;

namespace KtpAcsMiddleware.WinForm.TeamWorkers
{
    public partial class TeamWorkerList : FormBase
    {
        private string _currentTeamId;
        private IList<Team> _teams;
        private IList<TeamWorkerPagedDto> _workers;

        public TeamWorkerList()
        {
            InitializeComponent();
            WorkersGrid.AutoGenerateColumns = false;

            BindWorkerAuthenticationStates();
            InitGridPagingNavigatorControl();
        }

        /// <summary>
        ///     窗口加载时
        /// </summary>
        private void TeamWorkerList_Load(object sender, EventArgs e)
        {
            BindTeams();
            BindWorkers();
            InitTeamsCmsItemsVisible();
        }

        /// <summary>
        ///     班组选中项改变
        /// </summary>
        private void TeamsLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TeamsLb.SelectedItem == null)
            {
                return;
            }
            var teamName = TeamsLb.SelectedItem.ToString();
            var team = _teams.FirstOrDefault(i => i.Name == teamName);
            _currentTeamId = team == null ? string.Empty : team.Id;

            if (WorkerAuthenticationStatesCb.SelectedValue != null)
            {
                WorkersGridPager.PageIndex = 1;
            }
            InitTeamsCmsItemsVisible();
        }

        /// <summary>
        ///     班组列表右键-刷新
        /// </summary>
        private void TeamReloadMenuItem_Click(object sender, EventArgs e)
        {
            BindTeams();
            BindWorkers();
            MessageHelper.Show("班组列表已刷新");
        }

        /// <summary>
        ///     班组列表右键-班组编辑
        /// </summary>
        private void TeamEditMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentTeamId))
            {
                MessageHelper.Show("没有选中的班组");
                return;
            }
            new TeamDetailed(_currentTeamId).ShowDialog();
            BindTeams();
            BindWorkers();
        }

        /// <summary>
        ///     班组列表右键-班组添加
        /// </summary>
        private void TeamAddMenuItem_Click(object sender, EventArgs e)
        {
            new TeamDetailed().ShowDialog();
            BindTeams();
            BindWorkers();
        }

        /// <summary>
        ///     班组列表右键-发工人添加
        /// </summary>
        private void TeamWorkerAddMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentTeamId))
            {
                MessageHelper.Show("没有选中的班组");
                return;
            }
            new WorkerDetailed(_currentTeamId).ShowDialog();
            BindWorkers();
        }

        /// <summary>
        ///     工人列表右键-工人编辑
        /// </summary>
        private void WorkerEditMenuItem_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.CurrentRow != null)
            {
                //var currentRowIndex = WorkersGrid.CurrentRow.Index;
                //var workerId = WorkersGrid.Rows[currentRowIndex].Cells[0].Value.ToString();
                var workerId = WorkersGrid.SelectedRows[0].Cells[0].Value.ToString();
                new WorkerDetailed(workerId, true).ShowDialog();
                BindWorkers(workerId);
            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }
        }

        /// <summary>
        ///     工人列表右键-工人删除
        /// </summary>
        private void WorkerDelMenuItem_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.CurrentRow != null)
            {
                try
                {
                    var workerId = WorkersGrid.SelectedRows[0].Cells[0].Value.ToString();
                    var workerName = WorkersGrid.SelectedRows[0].Cells[1].Value.ToString();
                    if (MessageBox.Show($@"确认要删除<{workerName}>吗？", @"删除提示",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        ServiceFactory.WorkerCommandService.Remove(workerId);
                        LogHelper.EntryLog(AppLoginInfo.UserId, $"DelTeamWorker,id={workerId}");

                        MessageHelper.Show($"<{workerName}>删除成功");
                        BindWorkers();
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
        ///     工人列表右键-工人添加
        /// </summary>
        private void WorkerAddMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentTeamId))
            {
                MessageHelper.Show("没有选中的班组");
                return;
            }
            new WorkerDetailed(_currentTeamId).ShowDialog();
            BindWorkers();
        }

        /// <summary>
        ///     工人列表右键-工人详情
        /// </summary>
        private void WorkerDetailMenuItem_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.CurrentRow != null)
            {
                var workerId = WorkersGrid.SelectedRows[0].Cells[0].Value.ToString();
                new WorkerDetailed(workerId, false).ShowDialog();
            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }
        }

        /// <summary>
        ///     工人列表右键-更换班组
        /// </summary>
        private void WorkerChangeTeamMenuItem_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.CurrentRow != null)
            {
                var workerId = WorkersGrid.SelectedRows[0].Cells[0].Value.ToString();
                var selectWorker = _workers.First(i => i.Id == workerId);
                var selectWorkerAtTeam = _teams.FirstOrDefault(i => i.Id == selectWorker.TeamId);
                if (selectWorkerAtTeam != null && selectWorkerAtTeam.LeaderId == workerId)
                {
                    MessageHelper.Show("班组长不允许更换班组");
                    return;
                }

                new WorkerChangeTeamDetailed(workerId, _currentTeamId).ShowDialog();
                BindWorkers();
            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }
        }

        /// <summary>
        ///     工人列表右键-设为班组长
        /// </summary>
        private void WorkerSetAsTeamLeaderMenuItem_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.CurrentRow == null)
            {
                MessageHelper.Show("没有选中的工人");
                return;
            }
            if (string.IsNullOrEmpty(_currentTeamId))
            {
                MessageHelper.Show("没有选中的班组");
                return;
            }
            try
            {
                var workerId = WorkersGrid.SelectedRows[0].Cells[0].Value.ToString();
                var workerName = WorkersGrid.SelectedRows[0].Cells[1].Value.ToString();
                if (MessageBox.Show($@"确认要将<{workerName}>设为当前班组组长吗？", @"设置班组长提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ServiceFactory.TeamService.ChangeLeaderId(_currentTeamId, workerId);
                    MessageHelper.Show($"<{workerName}>已被设为当前班组组长");
                    BindWorkers(workerId);
                }
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        /// <summary>
        ///     工人列表右键-设为需要重新添加到所有设备
        /// </summary>
        private void WorkerSetFaceDeviceStatesToReAddMenuItem_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.CurrentRow == null)
            {
                MessageHelper.Show("没有选中的工人");
                return;
            }
            try
            {
                var workerId = WorkersGrid.SelectedRows[0].Cells[0].Value.ToString();
                var workerName = WorkersGrid.SelectedRows[0].Cells[1].Value.ToString();
                if (MessageBox.Show($@"确认要从所有设备中将<{workerName}>设为新删除(删除设备中当前的数据后会重新添加最新数据)吗？", @"设置新添加提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ServiceFactory.WorkerCommandService.ChangeWorkerFaceDeviceStatesToReAdd(workerId);
                    MessageHelper.Show($"<{workerName}>已从所有设备中设为新删除");
                    BindWorkers(workerId);
                }
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        /// <summary>
        ///     搜索按钮
        /// </summary>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            WorkersGridPager.PageIndex = 1;
            BindWorkers();
        }

        /// <summary>
        ///     工人列表选中项改变
        /// </summary>
        private void WorkersGrid_SelectionChanged(object sender, EventArgs e)
        {
            InitWorkersCmsItemsVisible();
        }
    }
}