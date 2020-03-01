using System;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.Organizations;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Models;
using KtpAcsMiddleware.WinForm.Shared;
using CCWin;

namespace KtpAcsMiddleware.WinForm.TeamWorkers
{
    public partial class WorkerDetailed : Skin_Mac
    {
        private readonly string _msgCaption = "提示:";
        private string _facePicId;
        private bool _fromReader;
        private string _identityBackPicId;

        private string _identityPicId;

        //端口号
        private int _synIdCardPort;

        private TeamWorkerDto _workerDto;

        public WorkerDetailed()
        {
            InitializeComponent();
        }

        public WorkerDetailed(string teamId)
        {
            InitializeComponent();
            BindNationsCb();
            BindTeamsCb(teamId);
            BindBankCardTypesCb();
            _workerDto = null;
            _facePicId = string.Empty;
            _identityPicId = string.Empty;
            _identityBackPicId = string.Empty;
            CameraConn();
        }

        public WorkerDetailed(string workerId, bool isEdit)
        {
            InitializeComponent();
            BindWorkerDetailed(workerId, isEdit);
        }

        private void WorkerDetailed_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AVidePlayer.IsRunning)
            {
                AVidePlayer.SignalToStop();
                AVidePlayer.Stop();
            }
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SubmitBtnPreValidation())
                {
                    throw new PreValidationException(PreValidationHelper.ErroMsg);
                }
                if (_workerDto == null)
                {
                    _workerDto = new TeamWorkerDto();
                }
                _workerDto.WorkerName = WorkerNameTxt.Text.Trim();
                _workerDto.Birthday = BirthdayDtp.Value;
                _workerDto.IdentityCode = IdentityCodeTxt.Text.Trim();
                _workerDto.IssuingAuthority = IssuingAuthorityTxt.Text.Trim();
                _workerDto.ActivateTime = ActivateTimeDtp.Value;
                _workerDto.InvalidTime = InvalidTimeDtp.Value;
                _workerDto.AddressNow = AddressNowTxt.Text.Trim();
                _workerDto.Address = AddressTxt.Text;
                _workerDto.Mobile = MobileTxt.Text.Trim();
                _workerDto.BankCardCode = BankCardCodeTxt.Text;
                if (BankCardTypeCb.SelectedValue != null)
                {
                    _workerDto.BankCardTypeId = int.Parse(BankCardTypeCb.SelectedValue.ToString());
                }
                if (ManRadio.Checked)
                {
                    _workerDto.Sex = (int) WorkerSex.Man;
                }
                else
                {
                    _workerDto.Sex = (int) WorkerSex.Lady;
                }
                _workerDto.Nation = int.Parse(NationCb.SelectedValue.ToString());
                _workerDto.TeamId = TeamCb.SelectedValue.ToString();
                if (!string.IsNullOrEmpty(_facePicId))
                {
                    _workerDto.FacePicId = _facePicId;
                }
                if (!string.IsNullOrEmpty(_identityPicId))
                {
                    _workerDto.IdentityPicId = _identityPicId;
                }
                if (!string.IsNullOrEmpty(_identityBackPicId))
                {
                    _workerDto.IdentityBackPicId = _identityBackPicId;
                }
                _workerDto.CreateType = _fromReader
                    ? (int) WorkerIdentityCreateType.Reader
                    : (int) WorkerIdentityCreateType.Manual;

                if (ServiceFactory.WorkerCommandService.AnyIdentityCode(_workerDto.IdentityCode, _workerDto.WorkerId))
                {
                    throw new PreValidationException("该工人已存在,请勿重复添加");
                }
                if (ServiceFactory.WorkerCommandService.AnyMobile(_workerDto.Mobile, _workerDto.WorkerId))
                {
                    throw new PreValidationException("手机号已存在，不允许重复使用");
                }
                if (string.IsNullOrEmpty(_workerDto.Id))
                {
                    //暂时使用admin作为创建人
                    _workerDto.WorkerCreatorId = OrgUserDataService.FindAdmin().Id;
                    ServiceFactory.WorkerCommandService.Add(_workerDto);
                }
                else
                {
                    ServiceFactory.WorkerCommandService.Change(_workerDto, _workerDto.Id);
                }
                MessageHelper.Show(@"保存工人信息成功");
                Hide();
            }
            catch (PreValidationException ex)
            {
                MessageBox.Show(ex.Message, _msgCaption);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        private void FacePic_Click(object sender, EventArgs e)
        {
            _facePicId = GetPic(FacePic);
        }

        private void IdentityPic_Click(object sender, EventArgs e)
        {
            _identityPicId = GetPic(IdentityPic);
        }

        private void IdentityBackPic_Click(object sender, EventArgs e)
        {
            _identityBackPicId = GetPic(IdentityBackPic);
        }

        private void IdentityCardReaderBtn_Click(object sender, EventArgs e)
        {
            /***初始化控件************************************************************/
            if (IdentityHeadPic.Image != null)
            {
                IdentityHeadPic.Image.Dispose();
                IdentityHeadPic.Image = null;
            }
            /***阅读器设置************************************************************/
            if (_synIdCardPort <= 0)
            {
                //查找读卡器，获取端口
                _synIdCardPort = SynIdCardApi.Syn_FindUSBReader();
            }
            var nPort = _synIdCardPort;
            if (nPort == 0)
            {
                MessageBox.Show(
                    $@"{Convert.ToString(DateTime.Now, CultureInfo.InvariantCulture)} 没有找到读卡器", _msgCaption);
                return;
            }
            string stmp;
            var pucIin = new byte[4];
            var pucSn = new byte[8];
            //图片保存路径
            var cPath = Encoding.UTF8.GetBytes(ConfigHelper.CustomFilesDir);
            //var cPath = Encoding.UTF8.GetBytes(System.Windows.Forms.Application.StartupPath + @"\_Files");
            SynIdCardApi.Syn_SetPhotoPath(2, ref cPath[0]); //设置照片路径，iOption 路径选项：0=C:，1=当前路径，2=指定路径
            //cPhotoPath	绝对路径,仅在iOption=2时有效
            SynIdCardApi.Syn_SetPhotoType(1); //0 = bmp ,1 = jpg , 2 = base64 , 3 = WLT ,4 = 不生成
            SynIdCardApi.Syn_SetPhotoName(3); // 生成照片文件名 0=tmp 1=姓名 2=身份证号 3=姓名_身份证号 
            SynIdCardApi.Syn_SetSexType(1); // 0=卡中存储的数据	1=解释之后的数据,男、女、未知
            SynIdCardApi.Syn_SetNationType(0); // 0=卡中存储的数据	1=解释之后的数据 2=解释之后加"族"
            SynIdCardApi.Syn_SetBornType(3); // 0=YYYYMMDD,1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD
            SynIdCardApi.Syn_SetUserLifeBType(3); // 0=YYYYMMDD,1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD
            // 0=YYYYMMDD(不转换),1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD,0=长期 不转换,	1=长期转换为 有效期开始+50年
            SynIdCardApi.Syn_SetUserLifeEType(3, 1);
            /***打开读取信息************************************************************/
            if (SynIdCardApi.Syn_OpenPort(nPort) == 0)
            {
                if (SynIdCardApi.Syn_SetMaxRFByte(nPort, 80, 0) == 0)
                {
                    var cardMsg = new SynIdCardDto();
                    SynIdCardApi.Syn_StartFindIDCard(nPort, ref pucIin[0], 0);
                    SynIdCardApi.Syn_SelectIDCard(nPort, ref pucSn[0], 0);
                    var readMsgResult = SynIdCardApi.Syn_ReadMsg(nPort, 0, ref cardMsg);
                    if (readMsgResult == 0 || readMsgResult == 1)
                    {
                        try
                        {
                            if (cardMsg.Sex == "女")
                            {
                                LadyRadio.Checked = true;
                            }
                            else
                            {
                                ManRadio.Checked = true;
                            }
                            WorkerNameTxt.Text = cardMsg.Name.Trim();
                            BirthdayDtp.Value = DateTime.Parse(cardMsg.Born);
                            IdentityCodeTxt.Text = cardMsg.IDCardNo.Trim();
                            IssuingAuthorityTxt.Text = cardMsg.GrantDept.Trim();
                            ActivateTimeDtp.Value = DateTime.Parse(cardMsg.UserLifeBegin);
                            AddressNowTxt.Text = cardMsg.Address.Trim();
                            AddressTxt.Text = cardMsg.Address.Trim();
                            NationCb.SelectedIndex = (int.Parse(cardMsg.Nation) - 1);

                            if (!string.IsNullOrEmpty(cardMsg.PhotoFileName))
                            {
                                IdentityHeadPic.Image = Image.FromFile(cardMsg.PhotoFileName);
                            }
                            DateTime invalidTime;
                            if (DateTime.TryParse(cardMsg.UserLifeEnd, out invalidTime))
                            {
                                InvalidTimeDtp.Value = invalidTime;
                            }
                            else
                            {
                                InvalidTimeDtp.Value = ActivateTimeDtp.Value.AddYears(50);
                            }

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
                            _fromReader = true;
                        }
                        catch (Exception ex)
                        {
                            LogHelper.ExceptionLog(ex);
                            MessageBox.Show($@"读取身份证出现错误：{ex.Message}", _msgCaption);
                        }
                    }
                    else
                    {
                        stmp = $"{FormatHelper.GetIsoDateTimeString(DateTime.Now)} 读取身份证信息错误,确认身份证放置位置，如放置正确则身份证可能损坏";
                        MessageBox.Show(stmp, _msgCaption);
                    }
                }
            }
            else
            {
                stmp = $"{FormatHelper.GetIsoDateTimeString(DateTime.Now)} 打开端口失败,确认身份证阅读器是否正常连接";
                MessageBox.Show(stmp, _msgCaption);
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}