using System;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Models;
using KtpAcsMiddleware.WinForm.Shared;

namespace KtpAcsMiddleware.WinForm.TeamWorkers
{
    public partial class WorkerChangeTeamDetailed : FormBaseUi
    {
        private readonly string _workerId;

        public WorkerChangeTeamDetailed()
        {
            InitializeComponent();
        }

        public WorkerChangeTeamDetailed(string workerId, string teamId)
        {
            InitializeComponent();

            _workerId = workerId;
            if (string.IsNullOrEmpty(teamId))
            {
                teamId = ServiceFactory.WorkerQueryService.Get(workerId).TeamId;
            }
            BindTeams(teamId);
        }

        /// <summary>
        ///     班组列表绑定
        /// </summary>
        private void BindTeams(string selectedValue)
        {
            try
            {
                var teams = ServiceFactory.TeamService.GetAll();
                TeamsCb.DataSource = teams;
                TeamsCb.DisplayMember = "Name";
                TeamsCb.ValueMember = "Id";
                if (selectedValue != null)
                {
                    TeamsCb.SelectedValue = selectedValue;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_workerId))
                {
                    throw new PreValidationException("目标工人错误");
                }
                if (TeamsCb.SelectedValue == null || TeamsCb.SelectedValue.ToString() == string.Empty)
                {
                    throw new PreValidationException("班组错误");
                }

                MessageHelper.Show("更换班组成功");

                var newTeamId = TeamsCb.SelectedValue.ToString();
                ServiceFactory.WorkerCommandService.ChangeTeam(_workerId, newTeamId);

                Hide();
            }
            catch (PreValidationException ex)
            {
                MessageHelper.Show(ex.Message);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}