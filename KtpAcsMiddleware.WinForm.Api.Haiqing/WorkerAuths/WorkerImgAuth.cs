using CCWin;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtpAcsMiddleware.WinForm.Api.WorkerAuths
{
    public partial class WorkerImgAuth :Skin_Mac
    {
        public WorkerImgAuth(string path,string name,string time)
        {
            InitializeComponent();

            lab_title.Text =  "打卡时间：_" + time;
            lab_name.Text = name;
            pic_userimg.Image = GetImage(path);
        }

        public System.Drawing.Image GetImage(string path)
        {
            //System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open);
            //System.Drawing.Image result = System.Drawing.Image.FromStream(fs);
            Image img = null;
            try
            {
                 img = Image.FromStream(System.Net.WebRequest.Create(path).GetResponse().GetResponseStream());
                Size size = new Size(100, 100);

                Point ulCorner = new Point(100, 100);
            }
            catch (Exception ex )
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex.Message); 
          
             
            }

            return img;

        }
   
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
