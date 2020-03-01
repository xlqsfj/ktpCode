using System.Collections.Generic;
using System.Windows.Forms;
using KtpAcsMiddleware.Domain.Organizations;
using KtpAcsMiddleware.WinForm.FaceRecognition;
using KtpAcsMiddleware.WinForm.KtpLibrary;
using KtpAcsMiddleware.WinForm.Models;
using KtpAcsMiddleware.WinForm.Organizations;
using KtpAcsMiddleware.WinForm.Shared;
using KtpAcsMiddleware.WinForm.TeamWorkers;
using KtpAcsMiddleware.WinForm.WorkerAuths;

namespace KtpAcsMiddleware.WinForm
{
    public partial class Home : FormBaseUi
    {
        public Home()
        {
            InitializeComponent();
            //AddTabPage("班组工人 ", new TeamWorkerList());
            //AddTabPage("用户管理 ", new UserList());
            //设置显示的标签页
            //MainTabControl.SelectTab(0);
            InitForms();
        }

        /// <summary>
        ///     初始化窗口
        /// </summary>
        private void InitForms()
        {
            var tabForms = new Dictionary<string, Form>
            {
                {"班组工人", new TeamWorkerList()},
                {"人脸识别", new FaceWorkerList()},
                {"工人同步", new WorkerSyncList()},
                {"班组同步", new TeamSyncList()},
                {"考勤同步", new AuthenticationSyncList()},
                {"用户管理", new UserList()},
                {"已删除的设备", new FaceDeviceDeletedList()},
                {"工人考勤", new WorkerAuthList()}
            };
            foreach (var form in tabForms)
            {
                AddTabPage(form.Key, form.Value);
            }
            MainTabControl.SelectTab(0);
        }

        //将标题添加进tabpage中
        public void AddTabPage(string str, Form form)
        {
            if (!TabControlCheckHave(MainTabControl, str))
            {
                MainTabControl.TabPages.Add(str);
                MainTabControl.SelectTab(MainTabControl.TabPages.Count - 1);
                form.FormBorderStyle = FormBorderStyle.None;
                form.ShowInTaskbar = false; //隐藏任务栏
                form.TopLevel = false;
                form.Show();
                form.Parent = MainTabControl.SelectedTab;
            }
        }

        //看tabpage中是否已有窗体
        public bool TabControlCheckHave(TabControl tab, string tabName)
        {
            for (var i = 0; i < tab.TabCount; i++)
            {
                if (tab.TabPages[i].Text == tabName)
                {
                    tab.SelectedIndex = i;
                    return true;
                }
            }
            return false;
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormHelper.CloseOpenForms(Name);
            if (AppLoginInfo.UserId != null)
            {
                Application.Exit();
            }
        }
    }
}