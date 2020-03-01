using System;
using System.Drawing;
using System.Linq;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Models;

namespace KtpAcsMiddleware.WinForm.WorkerAuths
{
    public partial class WorkerAuthList
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

                //筛选时间为当前日期时，设置为null，按最新打卡时间排序获取
                DateTime? clockDate = ClockDateDtp.Value;
                if (clockDate.Value.Date == DateTime.Now.Date)
                {
                    clockDate = null;
                }

                var pagedWorkers = ServiceFactory.WorkerAuthService.GetPaged(pageIndex, pageSize,
                    SearchText.Text, _currentTeamId, clockDate);
                WorkersGridPager.PageCount = (pagedWorkers.Count + pageSize - 1) / pageSize;

                _workerAuths = pagedWorkers.Entities.ToList();
                WorkersGrid.DataSource = _workerAuths;

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
                    var gridWorkerId = WorkersGrid.Rows[rowIndex].Cells[1].Value.ToString();

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
                            WorkersGrid.Rows[rowIndex].Cells[2].Style.BackColor = Color.DarkSeaGreen;
                            for (var rowCellIndex = 0;
                                rowCellIndex < WorkersGrid.Rows[rowIndex].Cells.Count;
                                rowCellIndex++)
                            {
                                var rowCell = WorkersGrid.Rows[rowIndex].Cells[rowCellIndex];
                                rowCell.ToolTipText = "班组长";
                            }
                        }
                    }
                }
                //初始化工人列表的右键项目
                InitWorkersCmsItemsVisible();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        /// <summary>
        ///     初始化工人列表的右键项目
        /// </summary>
        private void InitWorkersCmsItemsVisible()
        {
            WorkerDetailMenuItem.Visible = false;
            WorkerAuthDetailMenuItem.Visible = false;
            WorkerAuthPagedDto currentWorker = null;
            if (WorkersGrid.CurrentRow != null && WorkersGrid.CurrentRow.Cells.Count > 0)
            {
                var currentId = WorkersGrid.CurrentRow.Cells[0].Value.ToString();
                currentWorker = _workerAuths.FirstOrDefault(i => i.Id == currentId);
            }
            if (currentWorker != null)
            {
                WorkerDetailMenuItem.Visible = true;
                WorkerAuthDetailMenuItem.Visible = true;
            }
        }
    }
}