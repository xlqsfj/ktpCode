using System;
using System.Windows.Forms;

namespace KtpAcsMiddleware.WinForm.Shared
{
    public partial class MessagePrompt : FormBaseUi
    {
        private readonly string _fullMsg;

        public MessagePrompt()
        {
            InitializeComponent();
            //17个字符
            //14个字符+省略号
            //MsgLabel.Text = "系统提示：建信开天平系统信息......";
        }

        public MessagePrompt(string msg)
        {
            InitializeComponent();
            //17个字符
            //14个字符+省略号
            _fullMsg = null;
            if (msg == null)
            {
                msg = "空信息";
            }
            if (msg.Length > 17)
            {
                _fullMsg = msg;
                msg = $"{msg.Substring(0, 14)}......";
            }
            MsgLabel.Text = msg;
        }

        private void MsgLabel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_fullMsg))
            {
                return;
            }
            MessageBox.Show(_fullMsg);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}