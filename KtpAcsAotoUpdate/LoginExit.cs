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
    public partial class LoginExit : Skin_Mac
    {
        public LoginExit()
        {

            InitializeComponent();
        
            this.Show();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }
    }
}
