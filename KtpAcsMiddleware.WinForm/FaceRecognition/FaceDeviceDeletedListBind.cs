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
    public partial class FaceDeviceDeletedList
    {
        /// <summary>
        ///     设备列表绑定
        /// </summary>
        private void BindDevices()
        {
            try
            {
                FaceDevicesLb.Items.Clear();
                _devices = ServiceFactory.FaceWorkerDeletedService.GetDevices();
                FaceDevicesLb.Items.Add("所有"); //所有数据加载处理
                if (_devices == null || _devices.Count == 0)
                    return;
                for (var i = 0; i < _devices.Count; i++)
                {
                    var device = _devices[i];
                    FaceDevicesLb.Items.Add(device.Code);
                    if (!string.IsNullOrEmpty(_currentDeviceId) && device.Id == _currentDeviceId)
                    {
                        FaceDevicesLb.SelectedIndex = i;
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
            var list = FaceWorkerState.New.GetDescriptions()
                .Where(i => i.Key >= (int) FaceWorkerState.NewDel).ToList();
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
                var pagedResult = ServiceFactory.FaceWorkerDeletedService.GetPaged(
                    pageIndex, pageSize, _currentDeviceId, SearchText.Text, state);

                FaceWorkersGrid.AutoGenerateColumns = false;

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
                    //设备列显示处理(隐藏)，设备列为第九列
                    FaceWorkersGrid.Columns[9].Visible = false;
                }
                else
                {
                    //设备列显示处理(显示)，设备列为第九列
                    FaceWorkersGrid.Columns[9].Visible = true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageBox.Show($@"出现异常,exMessage={ex.Message}");
            }
        }

        /// <summary>
        ///     分页控件数据绑定事件设置
        /// </summary>
        private void InitGridPagingNavigatorControl()
        {
            FaceWorkersGridPager.PagingHandler = GridPagingNavigatorControlPagingEvent;
        }

        /// <summary>
        ///     分页控件数据绑定事件
        /// </summary>
        public void GridPagingNavigatorControlPagingEvent()
        {
            BindFaceWorkers();
        }

        /// <summary>
        ///     初始化设备列表的右键项目
        /// </summary>
        private void InitFaceDevicesCmsItemsVisible()
        {
            //班组右键选项
            FaceDeviceBellMenuItem.Visible = false;
            if (!string.IsNullOrEmpty(_currentDeviceId))
            {
                FaceDeviceBellMenuItem.Visible = true;
            }

            //工人右键选项
            InitWorkersCmsItemsVisible();
        }

        /// <summary>
        ///     初始化工人列表的右键项目
        /// </summary>
        private void InitWorkersCmsItemsVisible()
        {
            WorkerDetailMenuItem.Visible = false;
            WorkerInitNewDelMenuItem.Visible = false;
            WorkerAllInitNewDelMenuItem.Visible = false;

            FaceDeviceWorkerDeletedPagedDto currentFaceWorker = null;
            if (FaceWorkersGrid.CurrentRow != null && FaceWorkersGrid.CurrentRow.Cells.Count > 0)
            {
                var currentFaceWorkerId = FaceWorkersGrid.CurrentRow.Cells[0].Value.ToString();
                currentFaceWorker = _faceWorkers.FirstOrDefault(i => i.Id == currentFaceWorkerId);
            }
            if (!string.IsNullOrEmpty(_currentDeviceId))
            {
                WorkerAllInitNewDelMenuItem.Visible = true;
            }
            if (currentFaceWorker != null
                && currentFaceWorker.Status != (int) FaceWorkerState.HasDel
                && currentFaceWorker.Status != (int) FaceWorkerState.NewDel)
            {
                WorkerInitNewDelMenuItem.Visible = true;
            }
        }
    }
}