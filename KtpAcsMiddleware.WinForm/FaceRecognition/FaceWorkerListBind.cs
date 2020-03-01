using System;
using System.Linq;
using System.Windows;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.WinForm.FaceRecognition
{
    public partial class FaceWorkerList
    {
        /// <summary>
        ///     设备列表绑定
        /// </summary>
        private void BindDevices()
        {
            try
            {
                FaceDevicesLb.Items.Clear();
                FaceDevicesLb.Items.Add("所有");
                _devices = ServiceFactory.FaceDeviceService.GetAll();
                if (_devices == null || _devices.Count == 0)
                {
                    FaceDevicesLb.SelectedIndex = 0;
                    return;
                }
                for (var i = 0; i < _devices.Count; i++)
                {
                    var device = _devices[i];
                    FaceDevicesLb.Items.Add(device.Code);
                    if (!string.IsNullOrEmpty(_currentDeviceId) && device.Id == _currentDeviceId)
                    {
                        FaceDevicesLb.SelectedIndex = i + 1;
                    }
                }
                if (string.IsNullOrEmpty(_currentDeviceId))
                {
                    FaceDevicesLb.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageBox.Show($@"出现异常,exMessage={ex.Message}");
            }
        }

        /// <summary>
        ///     人脸识别设备同步状态数据绑定
        /// </summary>
        private void BindFaceDeviceWorkerStates()
        {
            var list = FaceWorkerState.New.GetDescriptions();
            list.Add(new DicKeyValueDto {Key = -1, Value = "所有"});
            FaceWorkerStatesCb.DataSource = list;
            FaceWorkerStatesCb.DisplayMember = "Value";
            FaceWorkerStatesCb.ValueMember = "Key";
            FaceWorkerStatesCb.SelectedValue = -1;
        }

        /// <summary>
        ///     设备工人列表绑定
        /// </summary>
        private void BindFaceWorkers(string workerId = null)
        {
            try
            {
                var pageSize = FaceWorkersGridPager.PageSize;
                var pageIndex = FaceWorkersGridPager.PageIndex;

                var state = int.Parse(FaceWorkerStatesCb.SelectedValue.ToString());
                var pagedResult = ServiceFactory.FaceDeviceWorkerService.GetPaged(
                    pageIndex, pageSize, _currentDeviceId, SearchText.Text, state);

                FaceWorkersGridPager.PageCount = (pagedResult.Count + pageSize - 1) / pageSize;

                _faceWorkers = pagedResult.Entities.ToList();
                FaceWorkersGrid.DataSource = _faceWorkers;
                if (!string.IsNullOrEmpty(workerId))
                {
                    for (var i = 0; i < FaceWorkersGrid.Rows.Count; i++)
                    {
                        if (FaceWorkersGrid.Rows[i].Cells[0].Value.ToString() == workerId)
                        {
                            FaceWorkersGrid.Rows[i].Selected = true;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(_currentDeviceId))
                {
                    //设备列显示处理(隐藏)，设备列为第十列
                    FaceWorkersGrid.Columns[10].Visible = false;
                }
                else
                {
                    //设备列显示处理(显示)，设备列为第十列
                    FaceWorkersGrid.Columns[10].Visible = true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageBox.Show($@"出现异常,exMessage={ex.Message}");
            }
        }

        /// <summary>
        ///     翻页控件翻页事件绑定
        /// </summary>
        private void InitGridPagingNavigatorControl()
        {
            FaceWorkersGridPager.PagingHandler = GridPagingNavigatorControlPagingEvent;
        }

        /// <summary>
        ///     翻页控件翻页事件
        /// </summary>
        public void GridPagingNavigatorControlPagingEvent()
        {
            BindFaceWorkers();
        }

        /// <summary>
        ///     初始化设备列表的右键选项
        /// </summary>
        private void InitFaceDevicesCmsItemsVisible()
        {
            if (string.IsNullOrEmpty(_currentDeviceId))
            {
                FaceDeviceBellMenuItem.Visible = false;
                FaceDeviceEditMenuItem.Visible = false;
                FaceDeviceDelMenuItem.Visible = false;
                FaceWorkersAllInitNewMenuItem.Visible = false;
            }
            else
            {
                FaceDeviceBellMenuItem.Visible = true;
                FaceDeviceEditMenuItem.Visible = true;
                FaceDeviceDelMenuItem.Visible = true;
                FaceWorkersAllInitNewMenuItem.Visible = true;
            }
            InitWorkersCmsItemsVisible();
        }

        /// <summary>
        ///     初始化工人列表的右键选项
        /// </summary>
        private void InitWorkersCmsItemsVisible()
        {
            WorkerInitNewMenuItem.Visible = false;
            WorkerInitNewDelMenuItem.Visible = false;

            FaceDeviceWorkerPagedDto currentWorker = null;
            if (FaceWorkersGrid.CurrentRow != null && FaceWorkersGrid.CurrentRow.Cells.Count > 0)
            {
                var currentWorkerId = FaceWorkersGrid.CurrentRow.Cells[0].Value.ToString();
                currentWorker = _faceWorkers.FirstOrDefault(i => i.Id == currentWorkerId);
            }
            if (currentWorker == null)
            {
                return;
            }
            var state = (FaceWorkerState) currentWorker.Status;
            if (!string.IsNullOrEmpty(currentWorker.FacePicId) &&
                (state == FaceWorkerState.PrepareAdd
                 || state == FaceWorkerState.FailAdd
                 || state == FaceWorkerState.RepeatAdd))
            {
                WorkerInitNewMenuItem.Visible = true;
                return;
            }
            if (state == FaceWorkerState.PrepareDel || state == FaceWorkerState.FailDel)
            {
                WorkerInitNewDelMenuItem.Visible = true;
            }
        }
    }
}