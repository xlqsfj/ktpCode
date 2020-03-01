using CCWin;
using KtpAcs.WinForm.Models;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Asp.TeamSyncs;
using KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtpAcs.WinForm.TeamWorkers
{
    public partial class addTeam : Skin_Color
    {
        private string WorkTypeId = null;
        public addTeam()
        {
            InitializeComponent();
            BindWorkTypeIdsCb("");
        }
        public addTeam(string id)
        {
            InitializeComponent();

            var team = ServiceFactory.TeamService.Get(id);
            TeamIdLabel.Text = team.Id;
            NameTxt.Text = team.Name;
            WorkTypeId = id;
            BindWorkTypeIdsCb(team.WorkTypeId);
        }
        private void BindWorkTypeIdsCb(string selectedValue)
        {
            var workTypes = ServiceFactory.TeamService.GetAllWorkTypes();
            workTypes.Add(new TeamWorkType { Id = string.Empty, Name = "选择" });
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
                var team = new Team { Id = id, Name = name, WorkTypeId = WorkTypeIdsCb.SelectedValue.ToString() };
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
              if (ConfigHelper.KtpUploadNetWork)
                {//连接网络成功

                    string erros = string.Empty;
                    try
                    {
                        TeamSyncAspService teamSyncAspService = new TeamSyncAspService();

                        //teamSyncAspService.SynCurrentTeams(team.Name, Convert.ToInt32(team.WorkTypeId), team.Id);
                        if (WorkTypeId == null)
                            teamSyncAspService.PushNewTeams();
                        else {
                            teamSyncAspService.PushNewTeams(WorkTypeId);
                        }
                    }
                    catch (Exception ex)
                    {
                        erros = $"{erros}Message={ex.Message},StackTrace={ex.StackTrace},id={ team.Id}|";
                    }
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
    }
}
