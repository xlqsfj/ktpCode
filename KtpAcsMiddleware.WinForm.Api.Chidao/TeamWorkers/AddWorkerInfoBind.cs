using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService;
using KtpAcsMiddleware.KtpApiService.Base;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
using KtpAcsMiddleware.WinForm.Api.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace KtpAcsMiddleware.WinForm.TeamWorkers
{
    partial class AddWorkerInfo
    {

        private void CameraConn()
        {


            try
            {
                AForgeVidePlayerHelper.CameraConn(AVidePlayer);
            }
            catch (NotFoundException nfException)
            {
                MessageHelper.Show(nfException.Message);
            }
        }
        private void BindBankCardTypesCb(int? selectedValue = null)
        {
            IList<DicKeyValueDto> list =
                EnumHelper.GetAllValueDescriptions(typeof(BankCardType)).Where(i => i.Key != 0).ToList();
            BankCardTypeCb.DataSource = list;
            BankCardTypeCb.DisplayMember = "Value";
            BankCardTypeCb.ValueMember = "Key";
            if (selectedValue != null)
            {
                BankCardTypeCb.SelectedValue = selectedValue;
            }
            else
            {
                BankCardTypeCb.SelectedIndex = -1;
            }
        }
        private void BindNationsCb(string selectedValue = null)
        {
            IList<DicKeyValueDto> nations = KtpApiService.Base.IdentityNation.Wu.GetDescriptions().Where(i => i.Key != 0).ToList();
            NationCb.DataSource = nations;
            NationCb.DisplayMember = "Value";
            NationCb.ValueMember = "Key";
            if (selectedValue != null)
            {
                NationCb.SelectedText = selectedValue;
            }
            else
            {
                NationCb.SelectedIndex = -1;
            }
        }
        private void BindWorkerDetailed(int workerId, bool isEdit, int teamType, int teamId, int recordId)
        {
            try
            {
                if (!isEdit)
                {//查看
                    WorkerNameTxt.ReadOnly = true;
                    BirthdayDtp.Enabled = false;
                    IdentityCodeTxt.ReadOnly = true;
                    IssuingAuthorityTxt.ReadOnly = true;
                    ActivateTimeDtp.Enabled = false;
                    InvalidTimeDtp.Enabled = false;
                    AddressNowTxt.ReadOnly = true;
                    AddressTxt.ReadOnly = true;
                    NationCb.Enabled = false;
                    ManRadio.Enabled = false;
                    LadyRadio.Enabled = false;
                    BankCardCodeTxt.ReadOnly = true;
                    BankCardTypeCb.Enabled = false;
                    MobileTxt.ReadOnly = true;
                    IdentityPic.Enabled = IdentityPic.Enabled = IdentityBackPic.Enabled = false;
                    AVidePlayer.Visible = false;
                    btnSubmit.Visible = false;
                    IdentityBackPic_Click.Visible = false;
                    FacePicShow.Visible = true;
                    AVidePlayer.Visible = false;
                    btnfacePic.Visible = false;
                    btnIdentityPic.Visible = false;
                    btnIdentityBackPic.Visible = false;
                    groupBox1.Text = "人脸信息采集";
                    groupBox5.Text = "";
                    ExitDate.Enabled = false;


                }
                else
                {
                    AVidePlayer.Visible = true;
                    FacePicShow.Visible = false;
                    //  CameraConn();
                }
                colRead();
                IMulePusher PanelLibrarySet = new WorkerGet() { RequestParam = new { projectId = ConfigHelper.KtpLoginProjectId, teamId = teamId, userId = workerId, recordId = recordId } };

                PushSummary pushSummary = PanelLibrarySet.Push();
                WorkerResult rr = pushSummary.ResponseData;


                Workers workers = rr.data[0];
                WorkerNameTxt.Text = workers.urealname;
                BirthdayDtp.Value = FormatHelper.GetNonNullNumDateValueNotErro(workers.userBirthday);
                IdentityCodeTxt.Text = workers.usfz;
                IssuingAuthorityTxt.Text = workers.usOrg;
                ActivateTimeDtp.Value = FormatHelper.GetNonNullNumDateValueNotErro(workers.usStartTime);
                InvalidTimeDtp.Value = FormatHelper.GetNonNullNumDateValueNotErro(workers.usExpireTime);
                AddressNowTxt.Text = workers.usAddress;
                AddressTxt.Text = workers.usProvince;
                MobileTxt.Text = workers.uname;
                if (!string.IsNullOrEmpty(workers.planExitTime))
                {
                    this.ExitDate.Format = DateTimePickerFormat.Long;
                    ExitDate.Value = FormatHelper.GetNonNullNumDateValueNotErro(workers.planExitTime);
                }
                BankCardCodeTxt.Text = workers.popBankCard;
                //人脸采集照片
                if (!string.IsNullOrEmpty(workers.userCertPic))
                {
                    try
                    {
                        Image img = Image.FromStream(System.Net.WebRequest.Create(workers.userCertPic).GetResponse().GetResponseStream());
                        _url_facePicId = workers.userCertPic;
                        FacePicShow.Image = FacePic.Image = img;

                    }
                    catch (Exception ex)
                    {


                    }
                }
                //身份证正面
                if (!string.IsNullOrEmpty(workers.popPic2))
                {
                    try
                    {
                        Image imgPic2 = Image.FromStream(System.Net.WebRequest.Create(workers.popPic2).GetResponse().GetResponseStream());
                        _url_identityPicId = workers.popPic2;
                        IdentityPic.Image = imgPic2;
                    }
                    catch (Exception ex)
                    {


                    }
                }
                //身份证反面
                if (!string.IsNullOrEmpty(workers.popPic3))
                {
                    try
                    {
                        Image imgPic3 = Image.FromStream(System.Net.WebRequest.Create(workers.popPic3).GetResponse().GetResponseStream());
                        IdentityBackPic.Image = imgPic3;
                        _url_identityBackPicId = workers.popPic3;
                    }
                    catch (Exception ex)
                    {


                    }
                }
                //头像
                if (!string.IsNullOrEmpty(workers.upic))
                {
                    try
                    {
                        Image imgUpic = Image.FromStream(System.Net.WebRequest.Create(workers.upic).GetResponse().GetResponseStream());
                        IdentityHeadPic.Image = imgUpic;
                        _url_upic = workers.upic;
                    }
                    catch (Exception ex)
                    {


                    }
                }
                if (workers.usex == 1)
                {
                    ManRadio.Checked = true;
                }
                else
                {
                    LadyRadio.Checked = true;
                }
                // _fromReader = workers.CreateType == (int)WorkerIdentityCreateType.Reader;

                BindNationsCb(workers.usNation);
                BindTeamsCb(teamType, workers.poName);

                BindBankCardTypesCb(workers.bankId);


            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        private void BindTeamsCb(int teamType, string selectedValue = null)
        {
            //var teams = ServiceFactory.TeamService.GetAll();

            IMulePusher pusher = new TeamGet() { RequestParam = new { projectId = ConfigHelper.KtpLoginProjectId } };
            try
            {
                PushSummary push = pusher.Push();
                TeamResult r = push.ResponseData;
                List<Team> _teams = null;
                _teams = r.data.Where(a => a.state == teamType).ToList();
                TeamCb.DataSource = _teams;
                TeamCb.DisplayMember = "organName";
                TeamCb.ValueMember = "sectionId";
                int index = -1;
                for (int i = 0; i < _teams.Count; i++)
                {
                    index++;
                    if (_teams[i].organName == selectedValue)
                    {

                        break;
                    }


                }
                if (selectedValue != null)
                {
                    TeamCb.SelectedIndex = index;
                    //TeamCb.Enabled = false;
                }
                else
                {
                    TeamCb.SelectedIndex = -1;
                    TeamCb.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                MessageHelper.Show(ex);
            }
        }
        private bool SubmitBtnPreValidation()
        {
            var isPrePass = true;
            PreValidationHelper.InitPreValidation(FormErrorProvider);
            PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, WorkerNameTxt, "姓名不允许为空", ref isPrePass);
            PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, IdentityCodeTxt, "身份证号不允许为空", ref isPrePass);
            PreValidationHelper.IsIdCard(FormErrorProvider, IdentityCodeTxt, "身份证号格式错误", ref isPrePass);
            PreValidationHelper.MustNotBeNull(FormErrorProvider, NationCb, "民族必须选择", ref isPrePass);
            PreValidationHelper.MustNotBeNull(FormErrorProvider, TeamCb, "班组不能为空", ref isPrePass);
            PreValidationHelper.MustNotBeNullOrEmpty(
                FormErrorProvider, IssuingAuthorityTxt, "发证机关不允许为空", ref isPrePass);
            if (BirthdayDtp.Value > DateTime.Now.Date.AddYears(-18))
            {
                FormErrorProvider.SetError(BirthdayDtp, "出生日期不得小于成年人年龄");
                isPrePass = false;
            }
            //if (ActivateTimeDtp.Value <= BirthdayDtp.Value)
            //{
            //    FormErrorProvider.SetError(ActivateTimeDtp, "证件有效期(开始)必须大于出生日期");
            //    isPrePass = false;
            //}
            //if (InvalidTimeDtp.Value <= ActivateTimeDtp.Value)
            //{
            //    FormErrorProvider.SetError(InvalidTimeDtp, "证件有效期(结束)必须大于证件有效期(开始)");
            //    isPrePass = false;
            //}
            //workers.planExitTime = "2019-06-10 14:34:44";
            if (this.ExitDate.Text.ToString() != " " && this.ExitDate.Text.ToString() != "")
            {

                if (ExitDate.Value <= DateTime.Now)
                {
                    FormErrorProvider.SetError(ExitDate, "计划离场时间必须大于当前日期");
                    isPrePass = false;
                }
            }
            PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, AddressNowTxt, "现在地址不允许为空", ref isPrePass);
            PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, MobileTxt, "手机号码不允许为空", ref isPrePass);
            PreValidationHelper.IsMobile(FormErrorProvider, MobileTxt, "手机号码格式错误", ref isPrePass);

            if (ManRadio.Checked == false && LadyRadio.Checked == false)
            {
                FormErrorProvider.SetError(LadyRadio, "性别必须选择");
                isPrePass = false;
            }
            if (FacePic.Image == null)
            {

                FormErrorProvider.SetError(FacePic, "人脸信息采集照片不能为空");
                isPrePass = false;
            }
            if (IdentityPic.Image == null)
            {

                FormErrorProvider.SetError(IdentityPic, "身份证正面照片不能为空");
                isPrePass = false;
            }
            if (IdentityBackPic.Image == null)
            {

                FormErrorProvider.SetError(IdentityBackPic, "身份证反面照片不能为空");
                isPrePass = false;
            }

            return isPrePass;
        }
        /// <summary>
        /// 重置
        /// </summary>
        private void Reset()
        {


            if (!IsManualAddInfo)
            {//新增时放开身份证信息
                colRead();
            }
            else
            {
                WorkerNameTxt.ReadOnly = false;
                BirthdayDtp.Enabled = true;
                IdentityCodeTxt.ReadOnly = false;
                IssuingAuthorityTxt.ReadOnly = false;
                ActivateTimeDtp.Enabled = true;
                InvalidTimeDtp.Enabled = true;
                AddressNowTxt.ReadOnly = false;
                AddressTxt.ReadOnly = false;
                NationCb.Enabled = true;
                ManRadio.Enabled = true;
                LadyRadio.Enabled = true;
            }

            WorkerNameTxt.Text = "";
            BirthdayDtp.Value = DateTime.Now.AddYears(-25);
            IdentityCodeTxt.Text = "";
            IssuingAuthorityTxt.Text = "";
            ActivateTimeDtp.Value = DateTime.Now;
            InvalidTimeDtp.Value = DateTime.Now;
            AddressNowTxt.Text = "";
            AddressTxt.Text = "";
            NationCb.SelectedIndex = -1;
            BankCardCodeTxt.Text = "";
            BankCardTypeCb.SelectedIndex = -1;

            MobileTxt.Text = "";
            TeamCb.SelectedIndex = -1;
            this.ExitDate.Format = DateTimePickerFormat.Custom;
            this.ExitDate.CustomFormat = " ";
            FacePic.Image = null;
            IdentityPic.Image = null;
            IdentityBackPic.Image = null;
            IdentityHeadPic.Image = null;
        }


    }


}
