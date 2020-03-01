using System;
using System.Linq;
using System.Windows;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.WinForm.KtpLibrary
{
    public partial class AuthenticationSyncList
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
                    return;
                for (var i = 0; i < _devices.Count; i++)
                {
                    var device = _devices[i];
                    FaceDevicesLb.Items.Add(device.Code);
                    if (!string.IsNullOrEmpty(_currentDeviceCode) && device.Code == _currentDeviceCode)
                    {
                        FaceDevicesLb.SelectedIndex = i + 1;
                    }
                }
                if (string.IsNullOrEmpty(_currentDeviceCode))
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
        ///     开太平同步操作类型数据绑定
        /// </summary>
        private void BindKtpSyncStates()
        {
            var list = KtpSyncState.NewAdd.GetDescriptions().Where(i => i.Key <= (int) KtpSyncState.Fail).ToList();
            list.Add(new DicKeyValueDto {Key = -1, Value = "所有"});
            KtpSyncStatesCb.DataSource = list;
            KtpSyncStatesCb.DisplayMember = "Value";
            KtpSyncStatesCb.ValueMember = "Key";
            KtpSyncStatesCb.SelectedValue = -1;
        }

        /// <summary>
        ///     认证同步工人列表绑定
        /// </summary>
        private void BindAuthWorkers(string workerId = null)
        {
            try
            {
                var pageSize = AuthWorkersGridPager.PageSize;
                var pageIndex = AuthWorkersGridPager.PageIndex;

                PagedResult<AuthenticationSyncPagedDto> pagedResult;
                var state = int.Parse(KtpSyncStatesCb.SelectedValue.ToString());
                if (state >= 0)
                {
                    pagedResult = ServiceFactory.AuthenticationSyncService.GetPaged(
                        pageIndex, pageSize, SearchText.Text, _currentDeviceCode, (KtpSyncState) state);
                }
                else
                {
                    pagedResult = ServiceFactory.AuthenticationSyncService.GetPaged(
                        pageIndex, pageSize, SearchText.Text, _currentDeviceCode, null);
                }

                AuthWorkersGridPager.PageCount = (pagedResult.Count + pageSize - 1) / pageSize;

                _authWorkers = pagedResult.Entities.ToList();
                AuthWorkersGrid.DataSource = _authWorkers;
                if (!string.IsNullOrEmpty(workerId))
                {
                    for (var i = 0; i < AuthWorkersGrid.Rows.Count; i++)
                    {
                        if (AuthWorkersGrid.Rows[i].Cells[0].Value.ToString() == workerId)
                        {
                            AuthWorkersGrid.Rows[i].Selected = true;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(_currentDeviceCode))
                {
                    //设备列显示处理(隐藏)，设备列为第九列
                    AuthWorkersGrid.Columns[9].Visible = false;
                }
                else
                {
                    //设备列显示处理(显示)，设备列为第九列
                    AuthWorkersGrid.Columns[9].Visible = true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageBox.Show($@"出现异常,exMessage={ex.Message}");
            }
        }

        /// <summary>
        ///     分页控件翻页事件绑定
        /// </summary>
        private void InitGridPagingNavigatorControl()
        {
            AuthWorkersGridPager.PagingHandler = GridPagingNavigatorControlPagingEvent;
        }

        /// <summary>
        ///     分页控件翻页事件
        /// </summary>
        public void GridPagingNavigatorControlPagingEvent()
        {
            BindAuthWorkers();
        }

        /// <summary>
        ///     初始化工人列表的右键选项
        /// </summary>
        private void InitWorkersCmsItemsVisible()
        {
            //隐藏指定工人的操作选项
            WorkerDetailMenuItem.Visible = false;
            WorkerPushMenuItem.Visible = false;
            //隐藏推送所有
            WorkerUpAllAuthMenuItem.Visible = false;

            if (_authWorkers.Count == 0)
            {
                return;
            }
            //有本地数据,显示推送所有
            WorkerUpAllAuthMenuItem.Visible = true;

            //有选中的工人，显示指定工人的操作选项
            if (AuthWorkersGrid.CurrentRow != null && AuthWorkersGrid.CurrentRow.Cells.Count > 0)
            {
                WorkerDetailMenuItem.Visible = true;
                WorkerPushMenuItem.Visible = true;
            }
        }
    }
}