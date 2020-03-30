using System;
using System.Drawing;
using System.Linq;

using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Api.Models;
using KtpAcsMiddleware.KtpApiService;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KtpAcsMiddleware.WinForm.Api.TeamWorkers
{
    public partial class TeamWorkerList
    {

        public string _certificationStatus = null;
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


                int? teamId = null;
                int popState = 0;
                string certificationStatus = null;
                if (!string.IsNullOrEmpty(_currentTeamId))
                    teamId = FormatHelper.StringToInt(_currentTeamId);
                if (_certificationStatus == "4")
                {
                    popState = 4;
                    WorkerCms.Items[1].Visible = false;
                    WorkerCms.Items[2].Visible = false;
                }
                else
                if (!string.IsNullOrEmpty(_certificationStatus) && _certificationStatus != "0")
                    certificationStatus = _certificationStatus;
                else
                {
                    WorkerCms.Items[1].Visible = true;
                    WorkerCms.Items[2].Visible = true;
                }

                WorkerSend workerSend = new WorkerSend { certificationStatus = certificationStatus, teamId = teamId, projectId = ConfigHelper.KtpLoginProjectId, pageNum = pageIndex, pageSize = pageSize, keyWord = SearchText.Text.Trim(), popState = popState };
                IMulePusher pusher = new WokersGet() { RequestParam = workerSend };
                PushSummary push = pusher.Push();
                WorkersResult r = push.ResponseData;
                WorkersGridPager.PageCount = (r.data.total + pageSize - 1) / pageSize;

                WorkersGrid.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                WorkersGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                List<WokersList> list = r.data.list.ToList();



                WorkersGrid.DataSource = list;

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
            WorkerAuthenticationStatesCb.SelectedIndex = (int)WorkerAuthenticationState.All;
        }

        /// <summary>
        ///     初始化班组列表的右键项目
        /// </summary>
        private void InitTeamsCmsItemsVisible()
        {
            //班组右键选项

            TeamWorkerAddMenuItem.Visible = false;
            if (!string.IsNullOrEmpty(_currentTeamId))
            {

                TeamWorkerAddMenuItem.Visible = true;
            }

        }


    }
}