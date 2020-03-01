
using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtpAcs.WinForm.Shared
{
    public partial class MessagePrompt : Skin_Color
    {
        private readonly string _fullMsg;
        public MessagePrompt()
        {
            InitializeComponent();
        }
        public MessagePrompt(string msg)
        {
            InitializeComponent();

            _fullMsg = msg;
            //17个字符
            //14个字符+省略号

            if (msg == null)
            {
                msg = "空信息";
            }
            if (msg.Length > 17)
            {
                _fullMsg = msg;
                msg = $"{msg.Substring(0, 30)}/n";
            }
            int LblNum = msg.Length;   //Label内容长度
            int RowNum = 20;   //每行显示的字数
            float FontWidth = MsgLabel.Width / MsgLabel.Text.Length;    //每个字符的宽度
            int RowHeight = 15;   //每行的高度
            int ColNum = (LblNum - (LblNum / RowNum) * RowNum) == 0 ? (LblNum / RowNum) : (LblNum / RowNum) + 1;   //列数
            MsgLabel.AutoSize = false;    //设置AutoSize
            MsgLabel.Width = (int)(FontWidth * 20.0);   //设置显示宽度
            MsgLabel.Height = RowHeight * ColNum;   //设置显示高度

            MsgLabel.Text = msg;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
