using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Models;

namespace KtpAcsMiddleware.WinForm.TeamWorkers
{
    public partial class WorkerDetailed
    {
        private void CameraConn()
        {
            try
            {
                AForgeVidePlayerHelper.CameraConn(AVidePlayer);
            }
            catch (NotFoundException nfException)
            {
                MessageBox.Show(nfException.Message, _msgCaption);
            }
        }

        private void BindNationsCb(int? selectedValue = null)
        {
            IList<DicKeyValueDto> nations = IdentityNation.Wu.GetDescriptions().Where(i => i.Key != 0).ToList();
            NationCb.DataSource = nations;
            NationCb.DisplayMember = "Value";
            NationCb.ValueMember = "Key";
            if (selectedValue != null)
            {
                NationCb.SelectedValue = selectedValue;
            }
            else
            {
                NationCb.SelectedIndex = -1;
            }
        }

        private void BindTeamsCb(string selectedValue = null)
        {
            var teams = ServiceFactory.TeamService.GetAll();
            TeamCb.DataSource = teams;
            TeamCb.DisplayMember = "Name";
            TeamCb.ValueMember = "Id";
            if (selectedValue != null)
            {
                TeamCb.SelectedValue = selectedValue;
                TeamCb.Enabled = false;
            }
            else
            {
                TeamCb.SelectedIndex = -1;
                TeamCb.Enabled = true;
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

        private void BindWorkerDetailed(string workerId, bool isEdit)
        {
            try
            {
                if (!isEdit)
                {
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
                    FacePic.Enabled = IdentityPic.Enabled = IdentityBackPic.Enabled = false;
                    IdentityCardReaderBtn.Enabled = ResetBtn.Enabled = SubmitBtn.Enabled = false;
                    IdentityCardReaderBtn.Visible = ResetBtn.Visible = SubmitBtn.Visible = false;
                    CloseButton.Width = IdentityCardReaderBtn.Width;
                    AVidePlayer.Visible = false;
                    FacePicShow.Visible = true;
                }
                else
                {
                    AVidePlayer.Visible = true;
                    FacePicShow.Visible = false;
                    CameraConn();
                }
                _workerDto = ServiceFactory.WorkerQueryService.Get(workerId);
                WorkerNameTxt.Text = _workerDto.WorkerName;
                BirthdayDtp.Value = _workerDto.Birthday;
                IdentityCodeTxt.Text = _workerDto.IdentityCode;
                IssuingAuthorityTxt.Text = _workerDto.IssuingAuthority;
                ActivateTimeDtp.Value = _workerDto.ActivateTime;
                InvalidTimeDtp.Value = _workerDto.InvalidTime;
                AddressNowTxt.Text = _workerDto.AddressNow;
                AddressTxt.Text = _workerDto.Address;
                MobileTxt.Text = _workerDto.Mobile;
                BankCardCodeTxt.Text = _workerDto.BankCardCode;

                if (_workerDto.Sex == (int) WorkerSex.Man)
                {
                    ManRadio.Checked = true;
                }
                else
                {
                    LadyRadio.Checked = true;
                }
                _fromReader = _workerDto.CreateType == (int) WorkerIdentityCreateType.Reader;

                BindNationsCb(_workerDto.Nation);
                BindTeamsCb(_workerDto.TeamId);
                BindBankCardTypesCb(_workerDto.BankCardTypeId);

                if (ConfigHelper.CustomFilesDirIsLocal)
                {
                    AForgeWorkerPicHelper.BindPicLocal(FacePicShow, _workerDto.FacePicId);
                    AForgeWorkerPicHelper.BindPicLocal(FacePic, _workerDto.FacePicId);
                    AForgeWorkerPicHelper.BindPicLocal(IdentityPic, _workerDto.IdentityPicId);
                    AForgeWorkerPicHelper.BindPicLocal(IdentityBackPic, _workerDto.IdentityBackPicId);
                }
                else
                {
                    AForgeWorkerPicHelper.BindPicLocal(FacePicShow, _workerDto.FacePicId);
                    AForgeWorkerPicHelper.BindPic(FacePic, _workerDto.FacePicId);
                    AForgeWorkerPicHelper.BindPic(IdentityPic, _workerDto.IdentityPicId);
                    AForgeWorkerPicHelper.BindPic(IdentityBackPic, _workerDto.IdentityBackPicId);
                }
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageBox.Show($@"��ȡ������Ϣ�쳣,exMessage={ex.Message}", _msgCaption);
            }
        }

        private string GetPic(PictureBox pictureBox)
        {
            try
            {
                if (ConfigHelper.CustomFilesDirIsLocal)
                {
                    return AForgeWorkerPicHelper.GetPicLocal(AVidePlayer, pictureBox);
                }
                return AForgeWorkerPicHelper.GetPic(AVidePlayer, pictureBox);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show(@"��ȡͼ��ʧ�ܣ���������ͷ�Ƿ�����", _msgCaption);
                return string.Empty;
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
                return string.Empty;
            }
        }

        private bool SubmitBtnPreValidation()
        {
            var isPrePass = true;
            PreValidationHelper.InitPreValidation(FormErrorProvider);
            PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, WorkerNameTxt, "����������Ϊ��", ref isPrePass);
            PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, IdentityCodeTxt, "���֤�Ų�����Ϊ��", ref isPrePass);
            PreValidationHelper.IsIdCard(FormErrorProvider, IdentityCodeTxt, "���֤�Ÿ�ʽ����", ref isPrePass);
            PreValidationHelper.MustNotBeNull(FormErrorProvider, NationCb, "�������ѡ��", ref isPrePass);
            PreValidationHelper.MustNotBeNullOrEmpty(
                FormErrorProvider, IssuingAuthorityTxt, "��֤���ز�����Ϊ��", ref isPrePass);
            if (BirthdayDtp.Value > DateTime.Now.Date.AddYears(-18))
            {
                FormErrorProvider.SetError(BirthdayDtp, "�������ڲ���С�ڳ���������");
                isPrePass = false;
            }
            if (ActivateTimeDtp.Value <= BirthdayDtp.Value)
            {
                FormErrorProvider.SetError(ActivateTimeDtp, "֤����Ч��(��ʼ)������ڳ�������");
                isPrePass = false;
            }
            if (InvalidTimeDtp.Value <= ActivateTimeDtp.Value)
            {
                FormErrorProvider.SetError(InvalidTimeDtp, "֤����Ч��(����)�������֤����Ч��(��ʼ)");
                isPrePass = false;
            }
            PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, AddressNowTxt, "���ڵ�ַ������Ϊ��", ref isPrePass);
            PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, MobileTxt, "�ֻ����벻����Ϊ��", ref isPrePass);
            PreValidationHelper.IsMobile(FormErrorProvider, MobileTxt, "�ֻ������ʽ����", ref isPrePass);

            if (ManRadio.Checked == false && LadyRadio.Checked == false)
            {
                FormErrorProvider.SetError(LadyRadio, "�Ա����ѡ��");
                isPrePass = false;
            }

            return isPrePass;
        }

        private void Reset()
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
            _fromReader = false;


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

            FacePic.Image = null;
            IdentityPic.Image = null;
            IdentityBackPic.Image = null;
            IdentityHeadPic.Image = null;
        }
    }
}