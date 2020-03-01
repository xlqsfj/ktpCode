using System;
using System.Linq;
using System.Windows;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Models;

namespace KtpAcsMiddleware.WinForm.KtpLibrary
{
    public partial class TeamSyncList
    {
        /// <summary>
        ///     工种类型列表绑定
        /// </summary>
        private void BindWorkTypes()
        {
            try
            {
                TeamWorkTypesLb.Items.Clear();
                TeamWorkTypesLb.Items.Add("所有");
                _teamWorkTypes = ServiceFactory.TeamService.GetAllWorkTypes();
                if (_teamWorkTypes == null || _teamWorkTypes.Count == 0)
                    return;
                for (var i = 0; i < _teamWorkTypes.Count; i++)
                {
                    var teamWorkType = _teamWorkTypes[i];
                    TeamWorkTypesLb.Items.Add(teamWorkType.Name);
                    if (!string.IsNullOrEmpty(_currentTeamWorkTypeId) && teamWorkType.Id == _currentTeamWorkTypeId)
                    {
                        TeamWorkTypesLb.SelectedIndex = i + 1;
                    }
                }
                if (string.IsNullOrEmpty(_currentTeamWorkTypeId))
                {
                    TeamWorkTypesLb.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageBox.Show($@"出现异常,exMessage={ex.Message}");
            }
        }

        /// <summary>
        ///     开太平同步操作类型数据绑定
        /// </summary>
        private void BindKtpSyncStates()
        {
            var list = KtpSyncState.NewAdd.GetDescriptions();
            list.Add(new DicKeyValueDto {Key = -1, Value = "所有"});
            KtpSyncStatesCb.DataSource = list;
            KtpSyncStatesCb.DisplayMember = "Value";
            KtpSyncStatesCb.ValueMember = "Key";
            KtpSyncStatesCb.SelectedValue = -1;
        }

        /// <summary>
        ///     班组列表绑定
        /// </summary>
        private void BindTeams(string teamId = null)
        {
            try
            {
                var pageSize = TeamsGridPager.PageSize;
                var pageIndex = TeamsGridPager.PageIndex;

                PagedResult<TeamSyncPagedDto> pagedTeams;
                var state = int.Parse(KtpSyncStatesCb.SelectedValue.ToString());
                if (state >= 0)
                {
                    pagedTeams = ServiceFactory.TeamSyncService.GetPaged(
                        pageIndex, pageSize, SearchText.Text, _currentTeamWorkTypeId, (KtpSyncState) state);
                }
                else
                {
                    pagedTeams = ServiceFactory.TeamSyncService.GetPaged(
                        pageIndex, pageSize, SearchText.Text, _currentTeamWorkTypeId, null);
                }

                TeamsGridPager.PageCount = (pagedTeams.Count + pageSize - 1) / pageSize;

                _teams = pagedTeams.Entities.ToList();
                TeamsGrid.DataSource = _teams;
                if (!string.IsNullOrEmpty(teamId))
                {
                    for (var i = 0; i < TeamsGrid.Rows.Count; i++)
                    {
                        if (TeamsGrid.Rows[i].Cells[0].Value.ToString() == teamId)
                        {
                            TeamsGrid.Rows[i].Selected = true;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(_currentTeamWorkTypeId))
                {
                    //工种类型列显示处理(隐藏)，工种类型列为第七列
                    TeamsGrid.Columns[7].Visible = false;
                }
                else
                {
                    //工种类型列显示处理(显示)，工种类型列为第七列
                    TeamsGrid.Columns[7].Visible = true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        /// <summary>
        ///     分页控件翻页事件
        /// </summary>
        private void InitGridPagingNavigatorControl()
        {
            TeamsGridPager.PagingHandler = GridPagingNavigatorControlPagingEvent;
        }

        /// <summary>
        ///     分页控件翻页事件
        /// </summary>
        public void GridPagingNavigatorControlPagingEvent()
        {
            BindTeams();
        }

        /// <summary>
        ///     初始化班组列表的右键选项
        /// </summary>
        private void InitTeamCmsItemsVisible()
        {
            //隐藏指定班组的操作选项
            TeamPullMenuItem.Visible = false;
            TeamPushMenuItem.Visible = false;
            //隐藏推送所有和同步所有
            TeamPushAllMenuItem.Visible = false;
            TeamSyncAllMenuItem.Visible = false;

            if (_teams.Count == 0)
            {
                return;
            }
            //有本地数据,显示推送所有和同步所有
            TeamPushAllMenuItem.Visible = true;
            TeamSyncAllMenuItem.Visible = true;

            //有选中的工人，显示指定工人的操作选项
            if (TeamsGrid.CurrentRow != null && TeamsGrid.CurrentRow.Cells.Count > 0)
            {
                TeamPullMenuItem.Visible = true;
                TeamPushMenuItem.Visible = true;
            }
        }
    }
}