using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Api.Models;
using System;
using System.Linq;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using AForge.Controls;
using AForge.Video.DirectShow;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
using KtpAcsMiddleware.KtpApiService;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.WinForm.Api.Shared;
using CCWin;
using System.Runtime.InteropServices;
using KtpAcsMiddleware.WinForm.Api.TeamWorkers;
using KtpAcsMiddleware.KtpApiService.Api;
using KtpAcsMiddleware.KtpApiService.TeamWorkers.Model;
using System.Threading;
using System.Configuration;
using static KtpAcsMiddleware.WinForm.Api.TeamWorkers.WorkerAddState;

namespace KtpAcsMiddleware.WinForm.TeamWorkers
{
    public partial class AddWorkerInfo : Skin_Color
    {
        //端口号
        private int _synIdCardPort;
        private readonly string _msgCaption = "提示:";
        private bool _fromReader = false;
        bool IsManualAddInfo = FormatHelper.GetStringToBoolean(ConfigurationManager.AppSettings["IsManualAddInfo"]);
        private bool _isColse = false;
        private string _facePicId;
        private string _identityBackPicId;
        //头像
        private string _upic;
        private string _url_upic;
        private string _identityPicId;
        private string _url_facePicId;
        private string _url_identityBackPicId;
        private int? teamType;
        private int? _userId = null;
        private string _url_identityPicId;
        private string _send;
        private bool _isSys = false;
        WorkerAddState _workerAddState;
        public AddWorkerInfo(int teamType)
        {
            InitializeComponent();
            SetformSize();
            CameraConn();
            BindNationsCb();
            //班组
            BindTeamsCb(teamType);
            //银行
            BindBankCardTypesCb();
            this.teamType = teamType;
        }

        public AddWorkerInfo(int workerId, bool isEdit, int teamType, int teamId, int recordId, bool isSys = false)
        {


            _isSys = isSys;
            _isColse = true;
            _userId = workerId;
            InitializeComponent();

            SetformSize();
            if (isEdit)
            {
                CameraConn();
            }
            BindNationsCb();
            this.teamType = teamType;
            _fromReader = isEdit;
            BindWorkerDetailed(workerId, isEdit, teamType, teamId, recordId);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string date = "yyyy年MM月dd日";
            //身份证有效开始时间
            this.ActivateTimeDtp.CustomFormat = date;
            //使用自定义格式
            this.ActivateTimeDtp.Format = DateTimePickerFormat.Custom;
            //时间控件的启用
            this.ActivateTimeDtp.ShowUpDown = true;
            //身份证有效结束时间
            this.InvalidTimeDtp.CustomFormat = date;
            //使用自定义格式
            this.InvalidTimeDtp.Format = DateTimePickerFormat.Custom;
            //时间控件的启用
            this.InvalidTimeDtp.ShowUpDown = true;
            //身份证生日时间
            this.BirthdayDtp.CustomFormat = date;
            //使用自定义格式
            this.BirthdayDtp.Format = DateTimePickerFormat.Custom;
            //时间控件的启用
            this.BirthdayDtp.ShowUpDown = true;
            if (teamType == 1)
            {
                this.lalTeam.Text = "部门";
                this.Text = "添加项目人员";
            }
            else
            {
                this.lalTeam.Text = "班组";
                this.Text = "添加工人";
            }
            if (!IsManualAddInfo)
            {//新增时放开身份证信息
                colRead();
            }

        }

        public void colRead()
        {
            WorkerNameTxt.ReadOnly = true;
            BirthdayDtp.Enabled = false;
            IdentityCodeTxt.ReadOnly = true;
            //IssuingAuthorityTxt.ReadOnly = true;
            ActivateTimeDtp.Enabled = false;
            InvalidTimeDtp.Enabled = false;
            AddressNowTxt.ReadOnly = true;
            AddressTxt.ReadOnly = true;
            NationCb.Enabled = false;
            ManRadio.Enabled = false;
            LadyRadio.Enabled = false;
            IssuingAuthorityTxt.Enabled = false;
        }
        private void LadyRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lalNative_Click(object sender, EventArgs e)
        {

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
        /// 读卡器读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void IdentityPic_Click(object sender, EventArgs e)
        {

        }

        private void btnfacePic_Click(object sender, EventArgs e)
        {
            _facePicId = GetPic(FacePic);
        }
        Workers workers = null;
        Thread _threadSubForm = null;
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string submit = btnSubmit.Text;
            try
            {
                if (!SubmitBtnPreValidation())
                {
                    throw new PreValidationException(PreValidationHelper.ErroMsg);
                }
                //_threadSubForm = new Thread(ShowAddInfoForm);

                //_threadSubForm.Start();
                //_threadSubForm.Join();
                ShowAddInfoForm();
                btnSubmit.Text = @"正在提交";
                btnSubmit.Enabled = false;
                workers = new Workers();
                workers.uproid = ConfigHelper._KtpLoginProjectId;
                workers.urealname = WorkerNameTxt.Text.Trim();
                workers.userBirthday = BirthdayDtp.Value.ToString("yyyy-MM-dd 00:00:00");
                workers.usfz = IdentityCodeTxt.Text.Trim();
                workers.usOrg = IssuingAuthorityTxt.Text.Trim();
                workers.usStartTime = ActivateTimeDtp.Value.ToString("yyyy-MM-dd 00:00:00"); 
                workers.usExpireTime = InvalidTimeDtp.Value.ToString("yyyy-MM-dd 00:00:00"); 
                workers.usAddress = AddressNowTxt.Text.Trim();
                workers.usProvince = AddressTxt.Text;
                workers.uname = MobileTxt.Text.Trim();
                workers.poName = TeamCb.Text;
                workers.userId = _userId;
                workers.popBankCard = BankCardCodeTxt.Text;
                workers.poType = teamType;
                //workers.planExitTime = "2019-06-10 14:34:44";
                if (this.ExitDate.Text.ToString() != " " && this.ExitDate.Text.ToString() != "")
                {
                    workers.planExitTime = this.ExitDate.Value.ToString("yyyy-MM-dd 00:00:00");
                }
                if (BankCardTypeCb.SelectedValue != null)
                {
                    workers.bankName = BankCardTypeCb.Text;
                    workers.bankId = int.Parse(BankCardTypeCb.SelectedValue.ToString());
                }
                if (ManRadio.Checked)
                {
                    workers.usex = 1;
                }
                else
                {
                    workers.usex = 2;
                }
                workers.usNation = NationCb.Text.ToString();
                workers.poId = (int)TeamCb.SelectedValue;
                if (!string.IsNullOrEmpty(_facePicId))
                {
                    workers.localImgFileName = _facePicId;
                }
                else if (!string.IsNullOrEmpty(_url_facePicId))
                {
                    workers.userCertPic = _url_facePicId;
                }
                if (!string.IsNullOrEmpty(_identityPicId))
                {
                    workers.localImgFileName1 = _identityPicId;
                }
                else if (!string.IsNullOrEmpty(_url_identityPicId))
                {
                    workers.popPic2 = _url_identityPicId;
                }
                if (!string.IsNullOrEmpty(_identityBackPicId))
                {//头像背面
                    workers.localImgFileName2 = _identityBackPicId;
                }
                else if (!string.IsNullOrEmpty(_url_identityBackPicId))
                {
                    workers.popPic3 = _url_identityBackPicId;
                }
                if (!string.IsNullOrEmpty(_upic))
                {//本地头像
                    workers.localImgUpic = _upic;
                }
                else if (!string.IsNullOrEmpty(_url_upic))
                {
                    workers.upic = _url_upic;
                }
                //workers.CreateType = _fromReader
                //    ? (int)WorkerIdentityCreateType.Reader
                //    : (int)WorkerIdentityCreateType.Manual;

                AddSubWorkInfo("");

              
                _send = "";

                btnSubmit.Text = submit;
                btnSubmit.Enabled = true;

            }
            catch (PreValidationException ex)
            {

                MessageHelper.Show(ex.Message);
                _send = "";

                btnSubmit.Text = submit;
                btnSubmit.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageHelper.Show(ex);
                _send = "";

                btnSubmit.Text = submit;
                btnSubmit.Enabled = true;
            }

        }


        /// <summary>
        //提交接口信息
        /// </summary>
        public void AddSubWorkInfo(string close)
        {
            WorkSysFail.dicAddMag.Clear();
            WorkSysFail.dicWorkadd.Clear();
            _send = "";
            if (_isColse && close == "close")
            { //编辑
                Hide();
                return;
            }
            else if (close == "close")
            {//新增

                Reset();
                return;
            }
            if (close == "3")
            {
                workers.confirmAdd = 1;
            }

            try
            {
                string usfz = workers.usfz;
                string uPhone = workers.uname;
                IMulePusher phoneApi = new WorkerPhoneGet() { RequestParam = new { identityCard = usfz, phone = uPhone } };
                PushSummary pushSummary = phoneApi.Push();


                if (!pushSummary.Success)
                {
                    MessageHelper.Show(pushSummary.Message);
                    return;

                }
                Result result = pushSummary.ResponseData;
                bool isOpen = false;
                //需要验证手机号
                if (result.data.verificationFlag && string.IsNullOrEmpty(_send))
                {


                    isOpen = true;

                    this.BeginInvoke((EventHandler)delegate
                    {
                        WorkerPhoneForm frm = new WorkerPhoneForm(workers.uname, workers.usfz);
                        //注册事件
                        frm.TransfEvent += GetSendInfo;
                        frm.ShowDialog();

                        if (_send == "close")
                        {

                            if (_workerAddState != null)
                                _workerAddState.Close();
                            btnSubmit.Enabled = true;
                            return;
                        }

                    });


                }
                else
                {
                    _send = "";
                }
                if (isOpen && string.IsNullOrEmpty(_send))
                {
                    return;
                }
                if (WorkSysFail.workAdd.Count() > 0)
                {
                    IMulePusher addworkers = new WorkerSet() { RequestParam = workers };
                    PushSummary pushAddworkers = addworkers.Push();
                }
                else
                {

                    WorkSysFail.dicWorkadd.Add(false, "添加失败，未连接人脸识别面板!");
                }




            }
            catch (Exception ex)
            {
                MessageHelper.Show(ex.Message);

                throw;
            }
        }
        public string GetSendInfo(string sendInfo)
        {
            _send = sendInfo;
            if (_send != "close")
            {

                workers.smsCode = sendInfo;
                IMulePusher addworkers = new WorkerSet() { RequestParam = workers };
                PushSummary pushAddworkers = addworkers.Push();
            }
            return _send;
        }

        public void ShowAddInfoForm()
        {

            this.BeginInvoke((EventHandler)delegate
            {
                _workerAddState = new WorkerAddState(WorkerNameTxt.Text.Trim(), IdentityCodeTxt.Text.Trim());
                _workerAddState.ShowSubmit += new AgainSubmit(AddSubWorkInfo);

                _workerAddState.ShowDialog();
            });

        }

        private void btnIdentityPic_Click(object sender, EventArgs e)
        {
            _identityPicId = GetPic(IdentityPic);
        }

        private void btnIdentityBackPic_Click(object sender, EventArgs e)
        {

            _identityBackPicId = GetPic(IdentityBackPic);

        }

        private void AddWorkerInfo_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (AVidePlayer.IsRunning)
            {
                AVidePlayer.SignalToStop();
                AVidePlayer.Stop();
            }

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void BankCardCodeTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void AddWorkerInfo_Activated(object sender, EventArgs e)
        {
            if (!_fromReader)
                btnClose.Focus();
            else
            {
                btnIdentityPic.Focus();
                btnIdentityBackPic.Focus();
                IdentityBackPic_Click.Focus();
                btnfacePic.Focus();

            }

        }

        private void ExitDate_CloseUp(object sender, EventArgs e)
        {
            ExitDate.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.ExitDate.Format = DateTimePickerFormat.Long;
            // this.ExitDate.CustomFormat = null;
        }

        private void btn_ExitDateClear_Click(object sender, EventArgs e)
        {
            this.ExitDate.Format = DateTimePickerFormat.Custom;
            this.ExitDate.CustomFormat = " ";
        }

        private void AddWorkerInfo_Resize(object sender, EventArgs e)
        {
            try
            {
                float[] scale = (float[])Tag;
                int i = 2;
                foreach (Control ctrl in this.Controls)
                {
                    ctrl.Left = (int)(Size.Width * scale[i++]);
                    ctrl.Top = (int)(Size.Height * scale[i++]);
                    ctrl.Width = (int)(Size.Width / (float)scale[0] * ((Size)ctrl.Tag).Width);
                    ctrl.Height = (int)(Size.Height / (float)scale[1] * ((Size)ctrl.Tag).Height);
                }
            }
            catch (Exception ex)
            {

                LogHelper.ExceptionLog(ex);
            }
        }
        private void SetformSize()
        {

            int count = this.Controls.Count * 2 + 2;
            float[] factor = new float[count];
            int i = 0;
            factor[i++] = Size.Width;
            factor[i++] = Size.Height;
            foreach (Control ctrl in this.Controls)
            {
                factor[i++] = ctrl.Location.X / (float)Size.Width;
                factor[i++] = ctrl.Location.Y / (float)Size.Height;
                ctrl.Tag = ctrl.Size;
            }
            Tag = factor;
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }
    }
}
