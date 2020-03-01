using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.WinForm.Models;
using KtpAcsMiddleware.WinForm.Shared;
using KtpAcsMiddleware.WinForm.TeamWorkers;

namespace KtpAcsMiddleware.WinForm.KtpLibrary
{
    public partial class WorkerSyncList : FormBase
    {
        private string _currentTeamId;
        private IList<Team> _teams;
        private IList<WorkerSyncPagedDto> _workers;

        public WorkerSyncList()
        {
            InitializeComponent();
            WorkersGrid.AutoGenerateColumns = false;

            InitGridPagingNavigatorControl();
            BindKtpSyncStates();
        }

        /// <summary>
        ///     窗口加载时
        /// </summary>
        private void WorkerSyncList_Load(object sender, EventArgs e)
        {
            BindTeams();
            BindTeamWorkers();
        }

        /// <summary>
        ///     班组选中项改变事件
        /// </summary>
        private void TeamsLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TeamsLb.SelectedItem == null)
            {
                return;
            }
            //设置当前班组ID
            var teamName = TeamsLb.SelectedItem.ToString();
            var team = _teams.FirstOrDefault(i => i.Name == teamName);
            _currentTeamId = team == null ? string.Empty : team.Id;

            if (KtpSyncStatesCb.SelectedValue != null)
            {
                WorkersGridPager.PageIndex = 1;
                BindTeamWorkers();
            }
            InitWorkersCmsItemsVisible();
        }

        /// <summary>
        ///     搜索按钮点击事件
        /// </summary>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            WorkersGridPager.PageIndex = 1;
            BindTeamWorkers();
        }

        /// <summary>
        ///     右键触发工人详情
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
        ///     右键触发拉取当前工人
        /// </summary>
        private void WorkerPullMenuItem_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.CurrentRow != null)
            {
                var workerId = WorkersGrid.SelectedRows[0].Cells[0].Value.ToString();
                var workerName = WorkersGrid.SelectedRows[0].Cells[1].Value.ToString();
                if (MessageBox.Show($@"确认使用云端数据覆盖<{workerName}>吗？", @"拉取提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //var workerId = WorkersGrid.SelectedRows[0].Cells[0].Value.ToString();
                    new WorkerSyncPrompt(workerId, 2).ShowDialog();
                    BindTeamWorkers(workerId);
                }
            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }
        }

        /// <summary>
        ///     右键触发推送当前工人
        /// </summary>
        private void WorkerPushMenuItem_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.CurrentRow != null)
            {
                var workerId = WorkersGrid.SelectedRows[0].Cells[0].Value.ToString();
                var workerName = WorkersGrid.SelectedRows[0].Cells[1].Value.ToString();
                if (MessageBox.Show($@"确认使用本地数据覆盖云端<{workerName}>吗？", @"推送提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    new WorkerSyncPrompt(workerId, 1).ShowDialog();
                    BindTeamWorkers(workerId);
                }
            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }
        }

        /// <summary>
        ///     右键触发拉取所有工人
        /// </summary>
        private void WorkerPullAllMenuItem_Click(object sender, EventArgs e)
        {
            new WorkerSyncPrompt(2).ShowDialog();
            BindTeams();
        }

        /// <summary>
        ///     右键触发推送所有工人
        /// </summary>
        private void WorkerPushAllMenuItem_Click(object sender, EventArgs e)
        {
            new WorkerSyncPrompt(1).ShowDialog();
            BindTeams();
        }

        /// <summary>
        ///     右键触发同步所有工人
        /// </summary>
        private void WorkerSyncMenuItem_Click(object sender, EventArgs e)
        {
            new WorkerSyncPrompt(3).ShowDialog();
            BindTeams();
        }

        /// <summary>
        ///     班组右键-刷新
        /// </summary>
        private void TeamsReloadMenuItem_Click(object sender, EventArgs e)
        {
            WorkersGridPager.PageIndex = 1;
            BindTeams();
            BindTeamWorkers();
            MessageBox.Show(@"班组列表已刷新", @"刷新提示");
        }

        /// <summary>
        ///     班组右键-拉取刷新(拉取所有班组和工人并推送考勤)
        /// </summary>
        private void TeamsPullAllMenuItem_Click(object sender, EventArgs e)
        {
            new WorkerSyncPrompt(4).ShowDialog();
            BindTeams();
            BindTeamWorkers();
        }

        /// <summary>
        ///     工人同步列表选中项改变事件
        /// </summary>
        private void WorkersGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (WorkersGrid.CurrentRow == null || WorkersGrid.CurrentRow.Cells.Count == 0)
            {
                return;
            }
            var workerId = WorkersGrid.CurrentRow.Cells[0].Value.ToString();
            var selectWorker = _workers.FirstOrDefault(i => i.Id == workerId);
            if (selectWorker != null && selectWorker.Status == (int) KtpSyncState.NewAdd)
            {
                WorkerPullMenuItem.Visible = false;
            }
            else
            {
                WorkerPullMenuItem.Visible = true;
            }
        }
    }
}