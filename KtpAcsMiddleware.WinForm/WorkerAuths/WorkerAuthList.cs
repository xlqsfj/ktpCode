using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.WinForm.Models;
using KtpAcsMiddleware.WinForm.Shared;
using KtpAcsMiddleware.WinForm.TeamWorkers;

namespace KtpAcsMiddleware.WinForm.WorkerAuths
{
    public partial class WorkerAuthList : FormBase
    {
        private string _currentTeamId;
        private IList<Team> _teams;
        private IList<WorkerAuthPagedDto> _workerAuths;

        public WorkerAuthList()
        {
            InitializeComponent();
            WorkersGrid.AutoGenerateColumns = false;
            ClockDateDtp.Value = DateTime.Now;
            InitGridPagingNavigatorControl();
        }

        /// <summary>
        ///     窗口加载时
        /// </summary>
        private void WorkerAuthList_Load(object sender, EventArgs e)
        {
            BindTeams();
            BindWorkers();
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

            ClockDateDtp.Value = DateTime.Now;
            WorkersGridPager.PageIndex = 1;
        }

        /// <summary>
        ///     班组右键-刷新
        /// </summary>
        private void TeamReloadMenuItem_Click(object sender, EventArgs e)
        {
            new WorkerAuthCollectionPrompt().ShowDialog();
            BindTeams();
            BindWorkers();
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
        ///     工人右键-工人信息
        /// </summary>
        private void WorkerDetailMenuItem_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.CurrentRow != null)
            {
                var workerId = WorkersGrid.CurrentRow.Cells[1].Value.ToString();
                new WorkerDetailed(workerId, false).ShowDialog();
            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }
        }

        /// <summary>
        ///     工人右键-工人考勤
        /// </summary>
        private void WorkerAuthDetailMenuItem_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.CurrentRow != null)
            {
                var workerId = WorkersGrid.CurrentRow.Cells[1].Value.ToString();
                new WorkerAuthDetail(workerId).ShowDialog();
            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }
        }
    }
}