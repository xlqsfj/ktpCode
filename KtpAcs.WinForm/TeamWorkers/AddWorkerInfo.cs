using CCWin;
using KtpAcs.WinForm.Models;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Domain.Organizations;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService.Asp.WorkerSyncs;
using KtpAcsMiddleware.WinForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtpAcs.WinForm.TeamWorkers
{
    public partial class AddWorkerInfo : Skin_Color
    {
        private string _facePicId;
        private string _upic;
        //身份证头像id
        private string _ucPicId;
        private string _identityPicId;
        private string _identityBackPicId;
        private int _synIdCardPort;
        private bool _fromReader = false;
        private readonly string _msgCaption = "提示:";
        private TeamWorkerDto _workerDto;
        public AddWorkerInfo()
        {
        
            InitializeComponent();
            _workerDto = new TeamWorkerDto();
            //摄像头加载
            CameraConn();
            //民族列表加载
            BindNationsCb();
            //班级列表加载
            BindTeamsCb();
            //银行列表加载
            BindBankCardTypesCb();
        }
        /// <summary>
        /// 编辑工人
        /// </summary>
        /// <param name="workerId">工人id</param>
        /// <param name="isEdit">是否编辑或只读</param>
        public AddWorkerInfo(string workerId, bool isEdit)
        {
            InitializeComponent();

            BindWorkerDetailed(workerId, isEdit);
        }
        /// <summary>
        /// 显示工人信息
        /// </summary>
        /// <param name="workerId"></param>
        /// <param name="isEdit"></param>
        private void BindWorkerDetailed(string workerId, bool isEdit)
        {
            try
            {
                _workerDto = ServiceFactory.WorkerQueryService.Get(workerId);
                if (!isEdit)
                {//工人信息不编辑
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
                    AVidePlayer.Visible = false;
                    FacePicShow.Visible = true;
                    //点击拍照隐藏
                    btnfacePic.Visible = false;
                    btnIdentityPic.Visible = false;
                    btnIdentityBackPic.Visible = false;
                    //读取卡
                    IdentityBackPic_Click.Visible = false;
                    //摄像头
                    AForgeWorkerPicHelper.BindPicLocal(FacePicShow, _workerDto.FacePicId);

                    btnSubmit.Visible = false;
                }
                else
                {

                    FacePicShow.Visible = false;
                    CameraConn();
                }

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

                if (_workerDto.Sex == (int)WorkerSex.Man)
                {
                    ManRadio.Checked = true;
                }
                else
                {
                    LadyRadio.Checked = true;
                }
                _fromReader = _workerDto.CreateType == (int)WorkerIdentityCreateType.Reader;

                BindNationsCb(FormatHelper.GetToString(_workerDto.Nation));
                BindTeamsCb(_workerDto.TeamId);
                BindBankCardTypesCb(_workerDto.BankCardTypeId);

                AForgeWorkerPicHelper.BindPicLocal(FacePic, _workerDto.FacePicId);
                AForgeWorkerPicHelper.BindPicLocal(IdentityHeadPic, _workerDto.u_sfzpic);
                AForgeWorkerPicHelper.BindPicLocal(IdentityPic, _workerDto.IdentityPicId);
                AForgeWorkerPicHelper.BindPicLocal(IdentityBackPic, _workerDto.IdentityBackPicId);

            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageBox.Show($@"获取工人信息异常,exMessage={ex.Message}", _msgCaption);
            }
        }
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
        /// <summary>
        /// 民族列表
        /// </summary>
        /// <param name="selectedValue"></param>
        private void BindNationsCb(string selectedValue = null)
        {
            IList<DicKeyValueDto> nations = IdentityNation.Wu.GetDescriptions().Where(i => i.Key != 0).ToList();
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
        /// <summary>
        ///班级列表
        /// </summary>
        /// <param name="selectedValue"></param>
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
        /// <summary>
        /// 银行列表
        /// </summary>
        /// <param name="selectedValue"></param>
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
        private string GetPic(System.Windows.Forms.PictureBox pictureBox)
        {
            try
            {

                return AForgeWorkerPicHelper.GetPicLocal(AVidePlayer, pictureBox);

            }
            catch (NullReferenceException)
            {
                MessageHelper.Show(@"获取图像失败，请检查摄像头是否正常", _msgCaption);
                return string.Empty;
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
                return string.Empty;
            }
        }
        /// <summary>
        /// 身份证正面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIdentityPic_Click(object sender, EventArgs e)
        {
            _identityPicId = GetPic(IdentityPic);
        }
        /// <summary>
        /// 身份证反面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIdentityBackPic_Click(object sender, EventArgs e)
        {

            _identityBackPicId = GetPic(IdentityBackPic);
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
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
                    _workerDto.Sex = (int)WorkerSex.Man;
                }
                else
                {
                    _workerDto.Sex = (int)WorkerSex.Lady;
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
                //身份证头像
                if (!string.IsNullOrEmpty(_ucPicId))
                {
                    _workerDto.u_sfzpic = _ucPicId;
                }
                _workerDto.CreateType = _fromReader
                    ? (int)WorkerIdentityCreateType.Reader
                    : (int)WorkerIdentityCreateType.Manual;

                if (ServiceFactory.WorkerCommandService.AnyIdentityCode(_workerDto.IdentityCode, _workerDto.WorkerId))
                {
                    throw new PreValidationException("该工人已存在,请勿重复添加");
                }
                if (ServiceFactory.WorkerCommandService.AnyMobile(_workerDto.Mobile, _workerDto.WorkerId))
                {
                    throw new PreValidationException("手机号已存在，不允许重复使用");
                }
                string workerId = _workerDto.Id;
                if (string.IsNullOrEmpty(_workerDto.Id))
                {
                    //暂时使用admin作为创建人
                    _workerDto.WorkerCreatorId = OrgUserDataService.FindAdmin().Id;
                    workerId = ServiceFactory.WorkerCommandService.Add(_workerDto);
                }
                else
                {
                    ServiceFactory.WorkerCommandService.Change(_workerDto, _workerDto.Id);
                }
                //通知面板
                FaceDeviceWorkerEntityService.SendAllDeviceSyncFaceLibrary();
                if (ConfigHelper.KtpUploadNetWork)
                {//连接网络成功
                    var workerAspSys = new WorkerAspSys();
                    workerAspSys.PushWorker(workerId);
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
        private bool SubmitBtnPreValidation()
        {
            var isPrePass = true;
            PreValidationHelper.InitPreValidation(FormErrorProvider);
            PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, WorkerNameTxt, "姓名不允许为空", ref isPrePass);
            PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, IdentityCodeTxt, "身份证号不允许为空", ref isPrePass);
            PreValidationHelper.IsIdCard(FormErrorProvider, IdentityCodeTxt, "身份证号格式错误", ref isPrePass);
            PreValidationHelper.MustNotBeNull(FormErrorProvider, NationCb, "民族必须选择", ref isPrePass);
            PreValidationHelper.MustNotBeNullOrEmpty(
                FormErrorProvider, IssuingAuthorityTxt, "发证机关不允许为空", ref isPrePass);
            if (BirthdayDtp.Value > DateTime.Now.Date.AddYears(-18))
            {
                FormErrorProvider.SetError(BirthdayDtp, "出生日期不得小于成年人年龄");
                isPrePass = false;
            }
            if (ActivateTimeDtp.Value <= BirthdayDtp.Value)
            {
                FormErrorProvider.SetError(ActivateTimeDtp, "证件有效期(开始)必须大于出生日期");
                isPrePass = false;
            }
            if (InvalidTimeDtp.Value <= ActivateTimeDtp.Value)
            {
                FormErrorProvider.SetError(InvalidTimeDtp, "证件有效期(结束)必须大于证件有效期(开始)");
                isPrePass = false;
            }
            PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, AddressNowTxt, "现在地址不允许为空", ref isPrePass);
            PreValidationHelper.MustNotBeNullOrEmpty(FormErrorProvider, MobileTxt, "手机号码不允许为空", ref isPrePass);
            PreValidationHelper.IsMobile(FormErrorProvider, MobileTxt, "手机号码格式错误", ref isPrePass);

            if (ManRadio.Checked == false && LadyRadio.Checked == false)
            {
                FormErrorProvider.SetError(LadyRadio, "性别必须选择");
                isPrePass = false;
            }

            return isPrePass;
        }



        private void btnfacePic_Click(object sender, EventArgs e)
        {
            _facePicId = GetPic(FacePic);
            _workerDto.isAdd = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void IdentityBackPic_Click_Click(object sender, EventArgs e)
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
                MessageHelper.Show(
                    $@"{Convert.ToString(DateTime.Now, CultureInfo.InvariantCulture)} 没有找到读卡器", _msgCaption);
                return;
            }
            string stmp;
            var pucIin = new byte[4];
            var pucSn = new byte[8];
            //byte[] cPath = new byte[255];
            //图片保存路径
            var cPath = Encoding.UTF8.GetBytes(ConfigHelper.CustomFilesDir);
            // var cPath = Encoding.UTF8.GetBytes(System.Windows.Forms.Application.StartupPath);
            SynIdCardApi.Syn_SetPhotoPath(2, ref cPath[0]); //设置照片路径，iOption 路径选项：0=C:，1=当前路径，2=指定路径
            //cPhotoPath	绝对路径,仅在iOption=2时有效
            SynIdCardApi.Syn_SetPhotoType(1); //0 = bmp ,1 = jpg , 2 = base64 , 3 = WLT ,4 = 不生成
            SynIdCardApi.Syn_SetPhotoName(2); // 生成照片文件名 0=tmp 1=姓名 2=身份证号 3=姓名_身份证号 
            SynIdCardApi.Syn_SetSexType(1); // 0=卡中存储的数据	1=解释之后的数据,男、女、未知
            SynIdCardApi.Syn_SetNationType(0); // 0=卡中存储的数据	1=解释之后的数据 2=解释之后加"族"
            SynIdCardApi.Syn_SetBornType(3); // 0=YYYYMMDD,1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD
            SynIdCardApi.Syn_SetUserLifeBType(3); // 0=YYYYMMDD,1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD
                                                  // 0=YYYYMMDD(不转换),1=YYYY年MM月DD日,2=YYYY.MM.DD,3=YYYY-MM-DD,4=YYYY/MM/DD,0=长期 不转换,	1=长期转换为 有效期开始+50年
                                                  //string imgMsg = new string(' ', 1024); //身份证图片信息返回长度为1024
                                                  //IntPtr img = Marshal.StringToHGlobalAnsi(imgMsg); //身份证图片
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
                                //IdentityHeadPic.Image = Image.FromFile(cardMsg.PhotoFileName);
                                _upic = $"{cardMsg.IDCardNo}.Jpg";
                                System.IO.FileStream fs = System.IO.File.OpenRead($"{ConfigHelper.CustomFilesDir}{_upic}");
                                IdentityHeadPic.Image = Image.FromStream(fs);
                                string fId = AForgeWorkerPicHelper.AddFileMap(_upic, $"{ConfigHelper.CustomFilesDir}{_upic}", (int)fs.Length);

                                _ucPicId = fId;
                                fs.Close();

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
                            MessageHelper.Show($@"读取身份证出现错误：{ex.Message}", _msgCaption);
                        }
                    }
                    else
                    {
                        stmp = $"{FormatHelper.GetIsoDateTimeString(DateTime.Now)} 读取身份证信息错误,确认身份证放置位置，如放置正确则身份证可能损坏";
                        MessageHelper.Show(stmp, _msgCaption);
                    }
                }
            }
            else
            {
                stmp = $"{FormatHelper.GetIsoDateTimeString(DateTime.Now)} 打开端口失败,确认身份证阅读器是否正常连接";
                MessageHelper.Show(stmp, _msgCaption);
            }
        }

        private void AddWorkerInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (AVidePlayer.IsRunning)
            {
                AVidePlayer.SignalToStop();
                AVidePlayer.Stop();
            }
        }
    }
}
