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

namespace KtpAcsAotoUpdate
{
    public partial class DownloadConfirm : Skin_Mac
    {
        List<DownloadFileInfo> downloadFileList = null;


        public DownloadConfirm() {

            InitializeComponent();
        }
        public DownloadConfirm(List<DownloadFileInfo> dfl)
        {
            InitializeComponent();

            downloadFileList = dfl;
        }

        private void OnLoad(object sender, EventArgs e)
        {
       
            skinLabel2.Text = this.downloadFileList[0].LastVer;
            string updateText = "";
            foreach (DownloadFileInfo file in this.downloadFileList)
            {
                if(!string.IsNullOrEmpty(file.Explain))
                updateText += file.Explain +"\n";
            }
            lab_Explain.Text = updateText;
            this.Activate();
            this.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
