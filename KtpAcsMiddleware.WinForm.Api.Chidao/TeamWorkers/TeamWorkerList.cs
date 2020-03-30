using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Api.Models;
using KtpAcsMiddleware.WinForm.Api.Shared;
using KtpAcsMiddleware.WinForm.TeamWorkers;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
using KtpAcsMiddleware.KtpApiService;
using CCWin;

namespace KtpAcsMiddleware.WinForm.Api.TeamWorkers
{
    public partial class TeamWorkerList : Skin_Color
    {
        private string _currentTeamId;
        private List<KtpApiService.TeamWorkers.Team> _teams ;

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
        ///班组选中项改变
        /// </summary>
        private void TeamsLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TeamsLb.SelectedItem == null)
            {
                return;
            }
            var teamName = TeamsLb.SelectedItem.ToString();
           var team = _teams.FirstOrDefault(i => i.organName == teamName);
           _currentTeamId = team == null ? string.Empty : team.sectionId.ToString();

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

        }

        /// <summary>
        ///     班组列表右键-班组添加
        /// </summary>
        private void TeamAddMenuItem_Click(object sender, EventArgs e)
        {
          
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
                var teamId = WorkersGrid.SelectedRows[0].Cells[1].Value;
                var recordId = WorkersGrid.SelectedRows[0].Cells["recordId"].Value;
                KtpApiService.TeamWorkers.Team team = _teams.Where(a => a.sectionId==  FormatHelper.StringToInt(teamId.ToString())).FirstOrDefault();
                bool isEdit = true;
                new AddWorkerInfo(FormatHelper.StringToInt(workerId), isEdit, team.state, Convert.ToInt32(teamId), (int)recordId).ShowDialog();
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
                    var workerTeamId = WorkersGrid.SelectedRows[0].Cells[1].Value.ToString();
                    var workerName = FormatHelper.GetToString(WorkersGrid.SelectedRows[0].Cells[2].Value);
                    if (MessageBox.Show($@"确认要删除<{workerName}>吗？", @"删除提示",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        LoadingHelper.ShowLoadingScreen(LoadMagEnum.Delete);
                        WorkerDeleteSend send = new WorkerDeleteSend { projectId = ConfigHelper.KtpLoginProjectId, teamId = workerTeamId, userId = workerId };
                        IMulePusher wDeleteApi = new WorkerDelete() { RequestParam = send };

                        PushSummary pushSummary = wDeleteApi.Push();
                        WorkerDeleteResult workerDelete = pushSummary.ResponseData;

                        if (!workerDelete.success)
                        {
                            MessageHelper.Show($"<{workerName}>{workerDelete.msg}");
                           LogHelper.EntryLog(workerId, $"删除人员,id={workerId}");
                        }
                        else
                        {

                            MessageHelper.Show($"<{workerName}>删除成功");
                        }
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
            
            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }
        }

        /// <summary>
        ///工人列表右键-更换班组
        /// </summary>
        private void WorkerChangeTeamMenuItem_Click(object sender, EventArgs e)
        {
            //if (WorkersGrid.CurrentRow != null)
            //{
            //    var workerId = WorkersGrid.SelectedRows[0].Cells[0].Value.ToString();
            //    var selectWorker = _workers.First(i => i.Id == workerId);
            //    var selectWorkerAtTeam = _teams.FirstOrDefault(i => i.Id == selectWorker.TeamId);
            //    if (selectWorkerAtTeam != null && selectWorkerAtTeam.LeaderId == workerId)
            //    {
            //        MessageHelper.Show("班组长不允许更换班组");
            //        return;
            //    }

            //    new WorkerChangeTeamDetailed(workerId, _currentTeamId).ShowDialog();
            //    BindWorkers();
            //}
            //else
            //{
            //    MessageHelper.Show("没有选中的工人");
            //}
        }

    

      

        /// <summary>
        ///     搜索按钮
        /// </summary>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            WorkersGridPager.PageIndex = 1;
           
        }

        /// <summary>
        ///     工人列表选中项改变
        /// </summary>
        private void WorkersGrid_SelectionChanged(object sender, EventArgs e)
        {
            //  InitWorkersCmsItemsVisible();
        }

        private void TeamsCms_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

     
        private void WorkerAuthenticationStatesCb_SelectedValueChanged(object sender, EventArgs e)
        {
            _certificationStatus = WorkerAuthenticationStatesCb.SelectedValue.ToString();

            if (_certificationStatus != "KtpAcsMiddleware.Infrastructure.Utilities.DicKeyValueDto")
                BindWorkers();
            else
                _certificationStatus = null;
        }
        /// <summary>
        /// 查看菜单按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkerSeeMenuItem_Click(object sender, EventArgs e)
        {
            if (WorkersGrid.CurrentRow != null)
            {
                var workerId = WorkersGrid.SelectedRows[0].Cells[0].Value.ToString();
                var teamId = WorkersGrid.SelectedRows[0].Cells[1].Value;
                var recordId = WorkersGrid.SelectedRows[0].Cells["recordId"].Value;
                KtpApiService.TeamWorkers.Team team = _teams.Where(a => a.sectionId == FormatHelper.StringToInt(teamId.ToString())).FirstOrDefault();
                bool isEdit = false;
                new AddWorkerInfo(FormatHelper.StringToInt(workerId), isEdit, team.state, Convert.ToInt32(teamId), (int)recordId).ShowDialog();
                BindWorkers(workerId);
            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }
        }

        private void SearchText_KeyDown(object sender, KeyEventArgs e)
        {
            WorkersGridPager.PageIndex = 1;
        }

        private void con_addTeam_Click(object sender, EventArgs e)
        {
            new AddTeamInfo().ShowDialog();
            BindTeams();
        }

        private void con_editTeam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentTeamId))
            {
                MessageHelper.Show("没有选中的班组");
                return;
            }
            new AddTeamInfo(FormatHelper.StringToInt(_currentTeamId)).ShowDialog();
            BindTeams();
            BindWorkers();
        }
    }
}