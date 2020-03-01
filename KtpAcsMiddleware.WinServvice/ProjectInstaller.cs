using System.ComponentModel;
using System.Configuration.Install;

namespace KtpAcsMiddleware.WinServvice
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}