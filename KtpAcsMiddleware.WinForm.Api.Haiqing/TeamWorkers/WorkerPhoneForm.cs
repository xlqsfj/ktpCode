using KtpAcsMiddleware.KtpApiService;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
using KtpAcsMiddleware.WinForm.Api.Models;
using KtpAcsMiddleware.WinForm.Api.Shared;
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
    public partial class WorkerPhoneForm : FormBaseUi
    {
        public string _phone = "";
        public string _card = "";
        // 定时间隔：1分钟
        int Seconds = 60;
        //声明委托 和 事件
        public delegate string TransfSend(String value);
        public WorkerPhoneForm(string phone, string card)
        {
            this._phone = phone;
            this._card = card;
            InitializeComponent();
        }

        public WorkerPhoneForm()
        {
            InitializeComponent();
        }

        public event TransfSend TransfEvent;
        private void btn_submitPhone_Click(object sender, EventArgs e)
        {
            if (text_send.Text == "输入验证码")
            {
                MessageHelper.Show(@"请输入手机验证码");
            }
            else
            {
                this.Close();
                TransfEvent(text_send.Text);
                
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {

            //发送手机验证码
            IMulePusher phoneApi = new WorkerPhoneSet() { RequestParam = new { phone = _phone } };
            PushSummary pushSummary = phoneApi.Push();
            if (pushSummary.Success)
            {
                btn_send.Enabled = false;
                timer1.Enabled = true;
            }


        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            TransfEvent("close");
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btn_send.Enabled = false;
            this.timer1.Interval = 1000;
            btn_send.Text = "倒计时:" + Seconds.ToString();
            if (Seconds == 0)
            {
                //倒计时到“00”，计时器停止
                this.timer1.Stop();
                //去做其他事情
                //......
                btn_send.Enabled = true;
                timer1.Enabled = false;
                btn_send.Text = "重新发送验证码";
                Seconds = 60;
            }
            else
            {
                Seconds--;
            }
        }

        private void WorkerPhoneForm_Load(object sender, EventArgs e)
        {

        }

        private void text_send_Click(object sender, EventArgs e)
        {

        }

        private void text_send_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void text_send_Enter(object sender, EventArgs e)
        {
            if (text_send.Text == "输入验证码")
            {

                this.text_send.Text = "";
            }
        }

  
        protected override void WndProc(ref Message msg)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (msg.Msg == WM_SYSCOMMAND && ((int)msg.WParam == SC_CLOSE))
            {
                // 点击winform右上关闭按钮 
                // 加入想要的逻辑处理
                TransfEvent("close");
                this.Close();
                return;
            }
            base.WndProc(ref msg);
        }
    }
}
