using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Domain.Organizations;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Models;
using KtpAcsMiddleware.WinForm.Shared;
using KtpAcsMiddleware.WinForm.TeamWorkers;

namespace KtpAcsMiddleware.WinForm.FaceRecognition
{
    public partial class FaceWorkerList : FormBase
    {
        private string _currentDeviceId;
        private IList<FaceDevice> _devices;
        private IList<FaceDeviceWorkerPagedDto> _faceWorkers;

        public FaceWorkerList()
        {
            InitializeComponent();
            FaceWorkersGrid.AutoGenerateColumns = false;

            BindFaceDeviceWorkerStates();
            BindDevices();
            BindFaceWorkers();
            InitGridPagingNavigatorControl();
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
        ///     工人列表右键-工人详情
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
        ///     工人列表右键-设为新添加
        /// </summary>
        private void WorkerInitNewMenuItem_Click(object sender, EventArgs e)
        {
            if (FaceWorkersGrid.CurrentRow != null)
            {
                try
                {
                    var faceWorkerId = FaceWorkersGrid.SelectedRows[0].Cells[0].Value.ToString();
                    var faceWorker = _faceWorkers.First(t => t.Id == faceWorkerId);
                    var state = (FaceWorkerState) faceWorker.Status;
                    //当前状态验证
                    if (state != FaceWorkerState.PrepareAdd &&
                        state != FaceWorkerState.FailAdd &&
                        state != FaceWorkerState.RepeatAdd)
                    {
                        MessageHelper.Show("当前选中项状态不允许设为新添加");
                        return;
                    }
                    //确认提示;执行设置
                    if (MessageBox.Show($@"确认要将<{faceWorker.WorkerName}>设为新添加吗？", @"复位提示",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        ServiceFactory.FaceDeviceWorkerService.ChangeState(faceWorkerId, FaceWorkerState.New);
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
                    var state = (FaceWorkerState) faceWorker.Status;
                    //当前状态验证
                    if (state != FaceWorkerState.PrepareDel && state != FaceWorkerState.FailDel)
                    {
                        MessageHelper.Show("当前选中项状态不允许设为新删除");
                        return;
                    }
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
        ///     设备列表右键-刷新
        /// </summary>
        private void FaceDeviceReloadMenuItem_Click(object sender, EventArgs e)
        {
            FaceWorkersGridPager.PageIndex = 1;
            BindDevices();
            BindFaceWorkers();
            MessageBox.Show(@"设备列表已刷新", @"刷新提示");
        }

        /// <summary>
        ///     设备列表右键-设备编辑
        /// </summary>
        private void FaceDeviceEditMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentDeviceId))
            {
                new FaceDeviceDetail(_currentDeviceId).ShowDialog();
                BindDevices();
                BindFaceWorkers();
            }
            else
            {
                MessageHelper.Show("没有选中的设备");
            }
        }

        /// <summary>
        ///     设备列表右键-设备删除
        /// </summary>
        private void FaceDeviceDelMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentDeviceId))
            {
                var deviceCode = _devices.First(i => i.Id == _currentDeviceId).Code;
                if (MessageBox.Show($@"确认要删除<{deviceCode}>吗？", @"删除提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ServiceFactory.FaceDeviceService.Remove(_currentDeviceId);
                    LogHelper.EntryLog(AppLoginInfo.UserId, $"DelDevice,id={_currentDeviceId}");

                    _currentDeviceId = null;
                    BindDevices();
                    BindFaceWorkers();
                }
            }
            else
            {
                MessageHelper.Show("没有选中的设备");
            }
        }

        /// <summary>
        ///     设备列表右键-设备添加
        /// </summary>
        private void FaceDeviceAddMenuItem_Click(object sender, EventArgs e)
        {
            new FaceDeviceDetail().ShowDialog();

            BindDevices();
            BindFaceWorkers();
        }

        /// <summary>
        ///     设备列表右键-通知当前设备
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
            catch (PreValidationException ex)
            {
                MessageHelper.Show(ex.Message);
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
        ///     设备列表右键-通知所有设备
        /// </summary>
        private void FaceDeviceBellAllMenuItem_Click(object sender, EventArgs e)
        {
            new BellFaceDevicePrompt().ShowDialog();
        }

        /// <summary>
        ///     设备列表右键-复位所有工人为新添加
        /// </summary>
        private void FaceWorkersAllInitNewMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_currentDeviceId))
                {
                    MessageHelper.Show("没有选中的设备");
                    return;
                }
                if (MessageBox.Show(@"确认要将当前设备所有预添加或添加失败的数据都设为新添加吗？", @"复位提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ServiceFactory.FaceDeviceService.ChangeDeviceUnSyncAddWorkersToNewState(_currentDeviceId);
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