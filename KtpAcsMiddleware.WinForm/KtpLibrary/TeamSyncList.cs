using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.WinForm.Models;
using KtpAcsMiddleware.WinForm.Shared;

namespace KtpAcsMiddleware.WinForm.KtpLibrary
{
    public partial class TeamSyncList : FormBase
    {
        private string _currentTeamWorkTypeId;
        private IList<TeamSyncPagedDto> _teams;
        private IList<TeamWorkType> _teamWorkTypes;

        public TeamSyncList()
        {
            InitializeComponent();
            TeamsGrid.AutoGenerateColumns = false;

            BindWorkTypes();
            BindKtpSyncStates();
            BindTeams();
            InitGridPagingNavigatorControl();
        }

        /// <summary>
        ///     工种类型改变事件
        /// </summary>
        private void TeamWorkTypesLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //设置当前工种类型ID
            var workTypeName = TeamWorkTypesLb.SelectedItem.ToString();
            var workType = _teamWorkTypes.FirstOrDefault(i => i.Name == workTypeName);
            _currentTeamWorkTypeId = workType == null ? string.Empty : workType.Id;

            if (KtpSyncStatesCb.SelectedValue != null)
            {
                TeamsGridPager.PageIndex = 1;
                BindTeams();
            }
        }

        /// <summary>
        ///     搜索按钮点击事件
        /// </summary>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            TeamsGridPager.PageIndex = 1;
            BindTeams();
        }

        /// <summary>
        ///     右键触发拉取当前班组
        /// </summary>
        private void TeamPullMenuItem_Click(object sender, EventArgs e)
        {
            if (TeamsGrid.CurrentRow != null)
            {
                var teamId = TeamsGrid.SelectedRows[0].Cells[0].Value.ToString();
                var teamName = TeamsGrid.SelectedRows[0].Cells[1].Value.ToString();
                if (MessageBox.Show($@"确认使用云端数据覆盖<{teamName}>吗？", @"拉取提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    new TeamSyncPrompt(teamId, 2).ShowDialog();
                    BindTeams();
                }
            }
            else
            {
                MessageHelper.Show("没有选中的班组");
            }
        }

        /// <summary>
        ///     右键触发推送当前班组
        /// </summary>
        private void TeamPushMenuItem_Click(object sender, EventArgs e)
        {
            if (TeamsGrid.CurrentRow != null)
            {
                var teamId = TeamsGrid.SelectedRows[0].Cells[0].Value.ToString();
                var teamName = TeamsGrid.SelectedRows[0].Cells[1].Value.ToString();
                if (MessageBox.Show($@"确认使用本地数据覆盖云端<{teamName}>吗？", @"推送提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    new TeamSyncPrompt(teamId, 1).ShowDialog();
                    BindTeams();
                }
            }
            else
            {
                MessageHelper.Show("没有选中的班组");
            }
        }

        /// <summary>
        ///     右键触发拉取全部班组
        /// </summary>
        private void TeamPullAllMenuItem_Click(object sender, EventArgs e)
        {
            new TeamSyncPrompt(2).ShowDialog();
            BindTeams();
        }

        /// <summary>
        ///     右键触发推送全部班组
        /// </summary>
        private void TeamPushAllMenuItem_Click(object sender, EventArgs e)
        {
            new TeamSyncPrompt(1).ShowDialog();
            BindTeams();
        }

        /// <summary>
        ///     右键触发同步全部班组
        /// </summary>
        private void TeamSyncAllMenuItem_Click(object sender, EventArgs e)
        {
            new TeamSyncPrompt(3).ShowDialog();
            BindTeams();
        }

        /// <summary>
        ///     班组同步列表选中项改变事件
        /// </summary>
        private void TeamsGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (TeamsGrid.CurrentRow == null || TeamsGrid.CurrentRow.Cells.Count == 0)
            {
                return;
            }
            var teamId = TeamsGrid.CurrentRow.Cells[0].Value.ToString();
            //工种选中项触发的TeamsGrid数据变更，_teams已改，导致null
            var selectTeam = _teams.FirstOrDefault(i => i.Id == teamId);
            if (selectTeam != null && selectTeam.Status == (int) KtpSyncState.NewAdd)
            {
                TeamPullMenuItem.Visible = false;
            }
            else
            {
                TeamPullMenuItem.Visible = true;
            }
            InitTeamCmsItemsVisible();
        }
    }
}