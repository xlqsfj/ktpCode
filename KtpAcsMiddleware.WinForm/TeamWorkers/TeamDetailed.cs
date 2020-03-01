using System;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Models;
using KtpAcsMiddleware.WinForm.Shared;

namespace KtpAcsMiddleware.WinForm.TeamWorkers
{
    public partial class TeamDetailed : FormBaseUi
    {
        public TeamDetailed()
        {
            InitializeComponent();
            BindWorkTypeIdsCb("");
        }

        public TeamDetailed(string id)
        {
            InitializeComponent();

            var team = ServiceFactory.TeamService.Get(id);
            TeamIdLabel.Text = team.Id;
            NameTxt.Text = team.Name;

            BindWorkTypeIdsCb(team.WorkTypeId);
        }

        private void BindWorkTypeIdsCb(string selectedValue)
        {
            var workTypes = ServiceFactory.TeamService.GetAllWorkTypes();
            workTypes.Add(new TeamWorkType {Id = string.Empty, Name = "选择"});
            WorkTypeIdsCb.DataSource = workTypes;
            WorkTypeIdsCb.DisplayMember = "Name";
            WorkTypeIdsCb.ValueMember = "Id";
            WorkTypeIdsCb.SelectedValue = selectedValue;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var isPrePass = true;
                PreValidationHelper.InitPreValidation(FormErrorProvider);
                PreValidationHelper.MustNotBeNull(FormErrorProvider, WorkTypeIdsCb, "工种必需选择", ref isPrePass);
                PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, NameTxt, "班组名称不能为空", ref isPrePass);
                if (!isPrePass)
                {
                    throw new PreValidationException(PreValidationHelper.ErroMsg);
                }

                var name = NameTxt.Text.Trim();
                var id = TeamIdLabel.Text;
                var team = new Team {Id = id, Name = name, WorkTypeId = WorkTypeIdsCb.SelectedValue.ToString()};
                if (ServiceFactory.TeamService.Any(name, id))
                {
                    FormErrorProvider.SetError(NameTxt, "班组名称不允许重复");
                    throw new PreValidationException("班组名称不允许重复");
                }
                if (!string.IsNullOrEmpty(id))
                {
                    ServiceFactory.TeamService.Change(team, id);
                }
                else
                {
                    ServiceFactory.TeamService.Add(team);
                }
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