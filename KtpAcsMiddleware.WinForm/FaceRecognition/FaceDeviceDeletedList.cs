using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Models;
using KtpAcsMiddleware.WinForm.Shared;
using KtpAcsMiddleware.WinForm.TeamWorkers;

namespace KtpAcsMiddleware.WinForm.FaceRecognition
{
    public partial class FaceDeviceDeletedList : FormBase
    {
        private string _currentDeviceId;
        private IList<FaceDevice> _devices;
        private IList<FaceDeviceWorkerDeletedPagedDto> _faceWorkers;

        public FaceDeviceDeletedList()
        {
            InitializeComponent();
            InitGridPagingNavigatorControl();
        }

        /// <summary>
        ///     窗口初始化
        /// </summary>
        private void FaceDeviceDeletedList_Load(object sender, EventArgs e)
        {
            BindDevices();
            BindFaceDeviceWorkerStates();
            BindFaceWorkers();
            InitFaceDevicesCmsItemsVisible();
        }

        /// <summary>
        ///     设备选中项改变
        /// </summary>
        private void FaceDevicesLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //设置当前设备
            if (FaceDevicesLb.SelectedItem == null)
            {
                return;
            }
            var currentDeviceCode = FaceDevicesLb.SelectedItem.ToString();
            var device = _devices.FirstOrDefault(i => i.Code == currentDeviceCode);
            _currentDeviceId = device == null ? string.Empty : device.Id;

            if (FaceWorkerStatesCb.SelectedValue != null)
            {
                FaceWorkersGridPager.PageIndex = 1;
                BindFaceWorkers();
            }
            InitFaceDevicesCmsItemsVisible();
        }

        /// <summary>
        ///     搜索按钮
        /// </summary>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            FaceWorkersGridPager.PageIndex = 1;
            BindFaceWorkers();
        }

        /// <summary>
        ///     右键触发工人详情
        /// </summary>
        private void WorkerDetailMenuItem_Click(object sender, EventArgs e)
        {
            if (FaceWorkersGrid.CurrentRow != null)
            {
                var workerId = FaceWorkersGrid.SelectedRows[0].Cells[1].Value.ToString();
                new WorkerDetailed(workerId, false).ShowDialog();
            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }
        }

        /// <summary>
        ///     右键触发通知设备
        /// </summary>
        private void FaceDeviceBellMenuItem_Click(object sender, EventArgs e)
        {
            FaceDevice currentDevice = null;
            try
            {
                currentDevice = _devices.FirstOrDefault(i => i.Id == _currentDeviceId);
                if (currentDevice == null)
                {
                    throw new PreValidationException("没有选中的设备");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.Show(ex);
            }
            if (currentDevice != null)
            {
                new BellFaceDevicePrompt(currentDevice.IpAddress).ShowDialog();
            }
        }

        /// <summary>
        ///     右键触发刷新设备
        /// </summary>
        private void FaceDeviceReloadMenuItem_Click(object sender, EventArgs e)
        {
            BindDevices();
            SearchText.Text = string.Empty;
            FaceWorkersGridPager.PageIndex = 1;
            BindFaceWorkers();
            MessageBox.Show(@"设备列表已刷新", @"刷新提示");
        }

        /// <summary>
        ///     工人列表右键-设为新删除
        /// </summary>
        private void WorkerInitNewDelMenuItem_Click(object sender, EventArgs e)
        {
            if (FaceWorkersGrid.CurrentRow != null)
            {
                try
                {
                    var faceWorkerId = FaceWorkersGrid.SelectedRows[0].Cells[0].Value.ToString();
                    var faceWorker = _faceWorkers.First(t => t.Id == faceWorkerId);
                    //确认提示;执行设置
                    if (MessageBox.Show($@"确认要将<{faceWorker.WorkerName}>设为新删除吗？", @"复位提示",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        ServiceFactory.FaceDeviceWorkerService.ChangeState(faceWorkerId, FaceWorkerState.NewDel);
                        MessageHelper.Show("设置成功");
                        BindFaceWorkers();
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.ExceptionLog(ex);
                    MessageHelper.Show(ex);
                }
            }
            else
            {
                MessageHelper.Show("没有选中的工人");
            }
        }

        /// <summary>
        ///     工人列表右键-全部设为新删除
        /// </summary>
        private void WorkerAllInitNewDelMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_currentDeviceId))
                {
                    MessageHelper.Show("没有选中的设备");
                    return;
                }
                if (MessageBox.Show(@"确认要将当前设备所有预删除或删除失败的数据都设为新删除吗？", @"复位提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ServiceFactory.FaceDeviceService.ChangeDeviceUnSyncDelWorkersToNewDelState(_currentDeviceId);
                    MessageHelper.Show("设置成功");
                    BindFaceWorkers();
                }
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        /// <summary>
        ///     工人列表选中项改变
        /// </summary>
        private void FaceWorkersGrid_SelectionChanged(object sender, EventArgs e)
        {
            InitWorkersCmsItemsVisible();
        }
    }
}