using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Models;
using KtpAcsMiddleware.WinForm.Shared;
using KtpAcsMiddleware.WinForm.TeamWorkers;

namespace KtpAcsMiddleware.WinForm.KtpLibrary
{
    public partial class AuthenticationSyncList : FormBase
    {
        private IList<AuthenticationSyncPagedDto> _authWorkers;
        private string _currentDeviceCode;
        private IList<FaceDevice> _devices;

        public AuthenticationSyncList()
        {
            InitializeComponent();
            AuthWorkersGrid.AutoGenerateColumns = false;

            BindKtpSyncStates();
            BindDevices();
            BindAuthWorkers();
            InitGridPagingNavigatorControl();
        }

        /// <summary>
        ///     设备选中项改变事件
        /// </summary>
        private void FaceDevicesLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //设置当前设备
            if (FaceDevicesLb.SelectedItem == null || FaceDevicesLb.SelectedIndex == 0)
            {
                _currentDeviceCode = null;
            }
            else
            {
                _currentDeviceCode = FaceDevicesLb.SelectedItem.ToString();
            }
            AuthWorkersGridPager.PageIndex = 1;
            BindAuthWorkers();
            InitWorkersCmsItemsVisible();
        }

        /// <summary>
        ///     搜索按钮点击
        /// </summary>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            AuthWorkersGridPager.PageIndex = 1;
            BindAuthWorkers();
        }

        /// <summary>
        ///     工人右键-工人详情
        /// </summary>
        private void WorkerDetailMenuItem_Click(object sender, EventArgs e)
        {
            if (AuthWorkersGrid.CurrentRow != null)
            {
                var authId = AuthWorkersGrid.SelectedRows[0].Cells[0].Value.ToString();
                var authWorker = _authWorkers.FirstOrDefault(i => i.Id == authId);
                if (authWorker != null)
                {
                    new WorkerDetailed(authWorker.WorkerId, false).ShowDialog();
                }
            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }
        }

        /// <summary>
        ///     工人右键-推送当前
        /// </summary>
        private void WorkerPushMenuItem_Click(object sender, EventArgs e)
        {
            if (AuthWorkersGrid.CurrentRow == null)
            {
                MessageHelper.Show("没有选中的记录");
                return;
            }
            var authId = AuthWorkersGrid.SelectedRows[0].Cells[0].Value.ToString();
            var authWorker = _authWorkers.First(i => i.Id == authId);
            //当前状态验证
            if ((KtpSyncState) authWorker.State != KtpSyncState.Fail)
            {
                MessageHelper.Show("当前选中项状态不允许推送,考勤只允许推送上传失败的数据");
                return;
            }

            try
            {
                new AuthenticationSyncPrompt(authId).ShowDialog();
                BindAuthWorkers();
                //去除复位的实现，直接选择推送
                //var authId = AuthWorkersGrid.SelectedRows[0].Cells[0].Value.ToString();
                //var authWorker = _authWorkers.First(i => i.Id == authId);
                ////当前状态验证
                //if ((KtpSyncState)authWorker.State != KtpSyncState.Fail)
                //{
                //    MessageBox.Show(@"当前选中项状态不允许设为新添加");
                //    return;
                //}
                ////确认提示;执行设置
                //if (MessageBox.Show($@"确认要将<{authWorker.WorkerName}>设为新添加吗？", @"复位提示",
                //        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                //{
                //    ServiceFactory.AuthenticationSyncService.ResetSyncState(authId);
                //    MessageBox.Show(@"设置成功");
                //    BindAuthWorkers();
                //}
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        /// <summary>
        ///     工人右键-上传全部
        /// </summary>
        private void WorkerUpAllAuthMenuItem_Click(object sender, EventArgs e)
        {
            new AuthenticationSyncPrompt().ShowDialog();
            BindAuthWorkers();
        }

        /// <summary>
        ///     右键触发设备列表刷新
        /// </summary>
        private void FaceDeviceReloadMenuItem_Click(object sender, EventArgs e)
        {
            AuthWorkersGridPager.PageIndex = 1;
            BindDevices();
            BindAuthWorkers();
            MessageBox.Show(@"设备列表已刷新", @"刷新提示");
        }
    }
}