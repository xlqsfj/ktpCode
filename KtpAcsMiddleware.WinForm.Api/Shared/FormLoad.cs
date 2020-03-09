using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtpAcsMiddleware.WinForm.Api.Shared
{
    public partial class FormLoad : Skin_Mac
    {    //保存父窗口信息，主要用于居中显示加载窗体

        public FormLoad()
        {
            InitializeComponent();
            
        }
        public FormLoad(string showMag)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            this.lbl_tips.Text = showMag;
        }

        /// <summary>
        /// 关闭命令
        /// </summary>
        public void closeOrder()
        {
            if (this.InvokeRequired)
            {
                //这里利用委托进行窗体的操作，避免跨线程调用时抛异常，后面给出具体定义
                CONSTANTDEFINE.SetUISomeInfo UIinfo = new CONSTANTDEFINE.SetUISomeInfo(new Action(() =>
                {
                    while (!this.IsHandleCreated)
                    {
                        ;
                    }
                    if (this.IsDisposed)
                        return;
                    if (!this.IsDisposed)
                    {
                        this.Dispose();
                    }

                }));
                this.Invoke(UIinfo);
            }
            else
            {
                if (this.IsDisposed)
                    return;
                if (!this.IsDisposed)
                {
                    this.Dispose();
                }
            }
        }



        private void FormLoad_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FormLoad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.IsDisposed)
            {
                this.Dispose(true);
            }
        }

        private void FormLoad_Load(object sender, EventArgs e)
        {
            //设置一些Loading窗体信息
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ControlBox = false;
            //// 下面的方法用来使得Loading窗体居中父窗体显示
            //int parentForm_Position_x = this.partentForm.Location.X;
            //int parentForm_Position_y = this.partentForm.Location.Y;
            //int parentForm_Width = this.partentForm.Width;
            //int parentForm_Height = this.partentForm.Height;

            //int start_x = (int)(parentForm_Position_x + (parentForm_Width - this.Width) / 2);
            //int start_y = (int)(parentForm_Position_y + (parentForm_Height - this.Height) / 2);
            //this.Location = new System.Drawing.Point(start_x, start_y);
        }
        public delegate DialogResult InvokeDelegate(Form parent);
        public DialogResult xShowDialog(Form parent)
        {
            if (parent.InvokeRequired)
            {
                InvokeDelegate xShow = new InvokeDelegate(xShowDialog);
                parent.Invoke(xShow, new object[] { parent });
                return DialogResult;
            }

            return this.ShowDialog(parent);
        }
    }
    public class CONSTANTDEFINE
    {

        public delegate void SetUISomeInfo();
    }
}
