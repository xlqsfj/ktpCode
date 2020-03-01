using System;
using System.Drawing;
using System.Linq;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Models;

namespace KtpAcsMiddleware.WinForm.KtpLibrary
{
    public partial class WorkerSyncList
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
        ///     工人列表绑定
        /// </summary>
        private void BindTeamWorkers(string workerId = null)
        {
            try
            {
                var pageSize = WorkersGridPager.PageSize;
                var pageIndex = WorkersGridPager.PageIndex;

                PagedResult<WorkerSyncPagedDto> pagedTeamWorkers;
                var state = int.Parse(KtpSyncStatesCb.SelectedValue.ToString());
                if (state >= 0)
                {
                    pagedTeamWorkers = ServiceFactory.WorkerSyncService.GetPaged(
                        pageIndex, pageSize, SearchText.Text, _currentTeamId, (KtpSyncState) state);
                }
                else
                {
                    pagedTeamWorkers = ServiceFactory.WorkerSyncService.GetPaged(
                        pageIndex, pageSize, SearchText.Text, _currentTeamId, null);
                }

                WorkersGridPager.PageCount = (pagedTeamWorkers.Count + pageSize - 1) / pageSize;

                _workers = pagedTeamWorkers.Entities.ToList();
                WorkersGrid.DataSource = _workers;
                for (var rowIndex = 0; rowIndex < WorkersGrid.Rows.Count; rowIndex++)
                {
                    var gridWorkerId = WorkersGrid.Rows[rowIndex].Cells[0].Value.ToString();
                    var gridWorker = _workers.First(i => i.Id == gridWorkerId);
                    if (gridWorkerId == workerId)
                    {
                        WorkersGrid.Rows[rowIndex].Selected = true;
                    }
                    if ((KtpSyncState) gridWorker.Status == KtpSyncState.NewAdd && !gridWorker.IsAuthentication)
                    {
                        //认证与未认证高亮处理
                        WorkersGrid.Rows[rowIndex].Cells["StateText"].Style.BackColor = Color.Red;
                    }
                }
                if (!string.IsNullOrEmpty(_currentTeamId))
                {
                    //班组列显示处理(隐藏)，班组列为第八列
                    WorkersGrid.Columns[8].Visible = false;
                }
                else
                {
                    //班组列显示处理(显示)，班组列为第八列
                    WorkersGrid.Columns[8].Visible = true;
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
            BindTeamWorkers();
        }

        /// <summary>
        ///     初始化工人列表的右键选项
        /// </summary>
        private void InitWorkersCmsItemsVisible()
        {
            //隐藏指定工人的操作选项
            WorkerDetailMenuItem.Visible = false;
            WorkerPullMenuItem.Visible = false;
            WorkerPushMenuItem.Visible = false;
            //隐藏推送所有和同步所有
            WorkerPushAllMenuItem.Visible = false;
            WorkerSyncMenuItem.Visible = false;

            if (_workers.Count == 0)
            {
                return;
            }
            //有本地数据,显示推送所有和同步所有
            WorkerPushAllMenuItem.Visible = true;
            WorkerSyncMenuItem.Visible = true;

            //有选中的工人，显示指定工人的操作选项
            if (WorkersGrid.CurrentRow != null && WorkersGrid.CurrentRow.Cells.Count > 0)
            {
                WorkerDetailMenuItem.Visible = true;
                WorkerPullMenuItem.Visible = true;
                WorkerPushMenuItem.Visible = true;
            }
        }
    }
}