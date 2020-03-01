using System;
using System.Drawing;
using System.Linq;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Models;

namespace KtpAcsMiddleware.WinForm.TeamWorkers
{
    public partial class TeamWorkerList
    {
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
            BindWorkers();
        }

        /// <summary>
        ///     工人列表绑定
        /// </summary>
        private void BindWorkers(string workerId = null)
        {
            try
            {
                var pageSize = WorkersGridPager.PageSize;
                var pageIndex = WorkersGridPager.PageIndex;

                var pagedTeamWorkers = ServiceFactory.WorkerQueryService.GetPaged(pageIndex, pageSize,
                    _currentTeamId, SearchText.Text,
                    (WorkerAuthenticationState) int.Parse(WorkerAuthenticationStatesCb.SelectedValue.ToString()));

                WorkersGridPager.PageCount = (pagedTeamWorkers.Count + pageSize - 1) / pageSize;

                _workers = pagedTeamWorkers.Entities.ToList();
                WorkersGrid.DataSource = _workers;
                string currentTeamLeaderId = null;
                if (!string.IsNullOrEmpty(_currentTeamId))
                {
                    var currentTeam = _teams.FirstOrDefault(i => i.Id == _currentTeamId);
                    if (currentTeam != null && currentTeam.LeaderId != null)
                    {
                        currentTeamLeaderId = currentTeam.LeaderId;
                    }
                    //班组列显示处理(隐藏)，班组列为第八列
                    WorkersGrid.Columns[8].Visible = false;
                }
                else
                {
                    //班组列显示处理(显示)，班组列为第八列
                    WorkersGrid.Columns[8].Visible = true;
                }
                for (var rowIndex = 0; rowIndex < WorkersGrid.Rows.Count; rowIndex++)
                {
                    var gridWorkerId = WorkersGrid.Rows[rowIndex].Cells[0].Value.ToString();
                    var gridWorker = _workers.First(i => i.Id == gridWorkerId);

                    if (!string.IsNullOrEmpty(workerId))
                    {
                        //按照当前工人设置选中行
                        if (gridWorkerId == workerId)
                        {
                            WorkersGrid.Rows[rowIndex].Selected = true;
                        }
                    }
                    if (currentTeamLeaderId != null)
                    {
                        //班组长高亮显示处理
                        if (gridWorkerId == currentTeamLeaderId)
                        {
                            //高亮显示班组长
                            WorkersGrid.Rows[rowIndex].Cells[1].Style.BackColor = Color.DarkSeaGreen;
                            for (var rowCellIndex = 0;
                                rowCellIndex < WorkersGrid.Rows[rowIndex].Cells.Count;
                                rowCellIndex++)
                            {
                                var rowCell = WorkersGrid.Rows[rowIndex].Cells[rowCellIndex];
                                rowCell.ToolTipText = "班组长";
                            }
                        }
                    }
                    if (gridWorker.AuthenticationState == WorkerAuthenticationState.WaitFor)
                    {
                        //认证与未认证高亮处理，认证所在列为第七列
                        WorkersGrid.Rows[rowIndex].Cells["AuthenticationStateText"].Style.BackColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        /// <summary>
        ///     工人认证状态下拉框绑定
        /// </summary>
        private void BindWorkerAuthenticationStates()
        {
            var authenticationStates = WorkerAuthenticationState.All.GetDescriptions();
            WorkerAuthenticationStatesCb.DataSource = authenticationStates;
            WorkerAuthenticationStatesCb.DisplayMember = "Value";
            WorkerAuthenticationStatesCb.ValueMember = "Key";
            WorkerAuthenticationStatesCb.SelectedIndex = (int) WorkerAuthenticationState.All;
        }

        /// <summary>
        ///     初始化班组列表的右键项目
        /// </summary>
        private void InitTeamsCmsItemsVisible()
        {
            //班组右键选项
            TeamEditMenuItem.Visible = false;
            TeamWorkerAddMenuItem.Visible = false;
            if (!string.IsNullOrEmpty(_currentTeamId))
            {
                TeamEditMenuItem.Visible = true;
                TeamWorkerAddMenuItem.Visible = true;
            }

            //工人右键选项
            InitWorkersCmsItemsVisible();
        }

        /// <summary>
        ///     初始化工人列表的右键项目
        /// </summary>
        private void InitWorkersCmsItemsVisible()
        {
            WorkerAddMenuItem.Visible = false;
            WorkerDetailMenuItem.Visible = false;
            WorkerEditMenuItem.Visible = false;
            WorkerChangeTeamMenuItem.Visible = false;
            WorkerDelMenuItem.Visible = false;
            WorkerSetAsTeamLeaderMenuItem.Visible = false;
            TeamWorkerPagedDto currentWorker = null;
            if (WorkersGrid.CurrentRow != null && WorkersGrid.CurrentRow.Cells.Count > 0)
            {
                var currentWorkerId = WorkersGrid.CurrentRow.Cells[0].Value.ToString();
                currentWorker = _workers.FirstOrDefault(i => i.Id == currentWorkerId);
            }
            if (!string.IsNullOrEmpty(_currentTeamId))
            {
                //工人右键选项
                WorkerAddMenuItem.Visible = true;
                if (currentWorker != null)
                {
                    //非班组长的工人被选中时才显示：更换班组、设为班组长、删除
                    var selectWorkerAtTeam = _teams.First(i => i.Id == currentWorker.TeamId);
                    if (selectWorkerAtTeam.LeaderId != currentWorker.Id)
                    {
                        WorkerChangeTeamMenuItem.Visible = true;
                        WorkerSetAsTeamLeaderMenuItem.Visible = true;
                        WorkerDelMenuItem.Visible = true;
                    }
                }
            }
            if (currentWorker != null)
            {
                WorkerDetailMenuItem.Visible = true;
                WorkerEditMenuItem.Visible = true;
            }
        }
    }
}