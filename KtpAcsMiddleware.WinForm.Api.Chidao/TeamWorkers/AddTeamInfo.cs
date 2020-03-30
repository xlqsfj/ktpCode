using CCWin;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
using KtpAcsMiddleware.KtpApiService.TeamWorkers.Model;
using KtpAcsMiddleware.WinForm.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtpAcsMiddleware.WinForm.Api.TeamWorkers
{
    public partial class AddTeamInfo : Skin_Color
    {
        Team team = null;
        int? _tid = null;
        public AddTeamInfo()
        {
            InitializeComponent();
            GetTeamType();
        }
        public AddTeamInfo(int tid)
        {
            InitializeComponent();
            _tid = tid;
            ShowTeamInfo(tid);

        }
        private void ShowTeamInfo(int tid)
        {

            Team team = new WorkerTeamInfo().GetTeamIdInfo(tid);
            txtName.Text = team.organName;
            TeamIdLabel.Text = team.sectionId.ToString();
            txtUserName.Text = team.userName ?? "";
            txtMobile.Text = team.phoneNum ?? "";
            txtIc.Text = team.identityNum ?? "";
            GetTeamType(team.teamWorkType.ToString());
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var isPrePass = true;
                PreValidationHelper.InitPreValidation(FormErrorProvider);
                PreValidationHelper.MustNotBeNull(FormErrorProvider, WorkTypeIdsCb, "工种必需选择", ref isPrePass);
                PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, txtName, "班组名称不能为空", ref isPrePass);
                PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, txtMobile, "班组长手机不能为空", ref isPrePass);
                PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, txtUserName, "班组长姓名不能为空", ref isPrePass);
                PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, txtIc, "班组长身份证号不能为空", ref isPrePass);
                PreValidationHelper.IsMobile(FormErrorProvider, txtMobile, "手机号码格式错误", ref isPrePass);
                PreValidationHelper.IsIdCard(FormErrorProvider, txtIc, "身份证号格式错误", ref isPrePass);
                if (!isPrePass)
                {
                    throw new PreValidationException(PreValidationHelper.ErroMsg);
                }

                var name = txtName.Text.Trim();
                var uName = txtUserName.Text;
                var mobile = txtMobile.Text;
                var ic = txtIc.Text;
                var teamWorkType = FormatHelper.StringToInt(WorkTypeIdsCb.SelectedValue.ToString());



                team = new Team
                {
                    organName = name,
                    state = 2,
                    createTime = DateTime.Now,
                    teamWorkType = teamWorkType,
                    phoneNum = mobile,
                    userName = uName,
                    identityNum = ic
                };
                var time = team.createTime;
                team.state = 2;
                team.uproid = ConfigHelper.KtpLoginProjectId;
                DataItem data = new DataItem
                {
                    createTime = (time.ToUniversalTime().Ticks - 621355968000000000) / 10000000 * 1000,
                    identityNum = team.identityNum,
                    organName = team.organName,
                    phoneNum = team.phoneNum,
                    sectionId = _tid,
                    state = team.state,
                    teamWorkType = team.teamWorkType,
                    uproid = team.uproid,
                    userName = team.userName

                };

                IMulePusher pusher = new TeamSet() { RequestParam = data };
                PushSummary push = pusher.Push();
                if (push.Success)
                {
                    MessageHelper.Show("添加成功");
                }
                else
                {
                    MessageHelper.Show("添加失败" + push.Message);

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
        public void GetTeamType(string selectedValue = "")
        {
            var workTypes = new TeamWorkType().GetTeamWork();
            WorkTypeIdsCb.DataSource = workTypes;
            WorkTypeIdsCb.DisplayMember = "Name";
            WorkTypeIdsCb.ValueMember = "Value";
            WorkTypeIdsCb.SelectedValue =FormatHelper.StringToInt(selectedValue);

     

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
