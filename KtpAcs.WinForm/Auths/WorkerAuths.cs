using CCWin;
using KtpAcs.WinForm.Models;
using KtpAcs.WinForm.Shared;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.AppService.ServiceModel;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KtpAcs.WinForm.Auths
{
    public partial class WorkerAuths : Skin_Color
    {
        private IList<FaceDevice> _devices;
        private string _currentDeviceCode;
        private IList<AuthsDto> _authWorkers;
        public WorkerAuths()
        {
            InitializeComponent();
            BindDevices();
            BindAuthWorkers();
            //分页控件
            InitGridPagingNavigatorControl();
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
        ///     设备列表绑定
        /// </summary>
        private void BindDevices()
        {
            try
            {
                com_DeviceList.Items.Clear();
                com_DeviceList.Items.Add("所有");
                _devices = ServiceFactory.FaceDeviceService.GetAll();
                if (_devices == null || _devices.Count == 0)
                    return;
                for (var i = 0; i < _devices.Count; i++)
                {
                    var device = _devices[i];
                    com_DeviceList.Items.Add(device.Code);
                    if (!string.IsNullOrEmpty(_currentDeviceCode) && device.Code == _currentDeviceCode)
                    {
                        com_DeviceList.SelectedIndex = i + 1;
                    }
                }
                if (string.IsNullOrEmpty(_currentDeviceCode))
                {
                    com_DeviceList.SelectedIndex = 0;
                }


            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageBox.Show($@"出现异常,exMessage={ex.Message}");
            }
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

                PagedResult<AuthsDto> pagedResult;
                bool isBePresent = re_Online.Checked == true ? false : true;
                string beginTime = time_beginTime.Value.ToString("yyyy-MM-dd 00:00:00");
                string endTime = time_endTime.Value.ToString("yyyy-MM-dd 23:59:59");
                pagedResult = ServiceFactory.WorkerAuthsServiceAuths.GetPaged(
                    pageIndex, pageSize, SearchText.Text, _currentDeviceCode, beginTime, endTime, isBePresent);


                AuthWorkersGridPager.PageCount = (pagedResult.Count + pageSize - 1) / pageSize;

                _authWorkers = pagedResult.Entities.ToList();
                //表格居中
                AuthWorkersGrid.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                AuthWorkersGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.AuthWorkersGrid.AutoGenerateColumns = false;//不自动 
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
                //if (!string.IsNullOrEmpty(_currentDeviceCode))
                //{
                //    //设备列显示处理(隐藏)，设备列为第九列
                //    AuthWorkersGrid.Columns[9].Visible = false;
                //}
                //else
                //{
                //    //设备列显示处理(显示)，设备列为第九列
                //    AuthWorkersGrid.Columns[9].Visible = true;
                //}
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageBox.Show($@"出现异常,exMessage={ex.Message}");
            }
        }

        private void com_DeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentDeviceCode = com_DeviceList.Text == "所有" ? null : com_DeviceList.Text;
            AuthWorkersGridPager.PageIndex = 1;
        }
        /// <summary>
        /// 点击搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (time_endTime.Value.Date < time_beginTime.Value.Date)
            {
                MessageHelper.Show("结束时间不能小于开始时间！");
                return;
            }

            AuthWorkersGridPager.PageIndex = 1;
        }
        /// <summary>
        /// 点击离场
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void re_Offline_CheckedChanged(object sender, EventArgs e)
        {
            if (re_Offline.Checked)
            {

                AuthWorkersGridPager.PageIndex = 1;


            }
        }
        /// <summary>
        /// 点击在场
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void re_Online_CheckedChanged(object sender, EventArgs e)
        {
            if (re_Online.Checked)
            {

                AuthWorkersGridPager.PageIndex = 1;


            }
        }
        //同步
        private void btnSyn_Click(object sender, EventArgs e)
        {
            new SynAuthForm().ShowDialog();
            AuthWorkersGridPager.PageIndex = 1;

        }
        //同步当前行
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
            if ((KtpSyncState)authWorker.State != KtpSyncState.Fail)
            {
                MessageHelper.Show("当前选中项状态不允许推送,考勤只允许推送上传失败的数据");
                return;
            }

            try
            {
                new SynAuthForm(authId).ShowDialog();
                BindAuthWorkers();

            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        private void WorkerAuths_Load(object sender, EventArgs e)
        {
            //string date = "yyyy年MM月dd日";
            ////身份证有效开始时间
            //this.time_beginTime.CustomFormat = date;
            ////使用自定义格式
            //this.time_beginTime.Format = DateTimePickerFormat.Custom;
            ////时间控件的启用
            //this.time_beginTime.ShowUpDown = true;
            ////身份证有效开始时间
            //this.time_endTime.CustomFormat = date;
            ////使用自定义格式
            //this.time_endTime.Format = DateTimePickerFormat.Custom;
            ////时间控件的启用
            //this.time_endTime.ShowUpDown = true;
            //服务是否启动
            try
            {
                ServiceController cs = new ServiceController();
                cs.MachineName = "localhost"; //主机名称
                cs.ServiceName = "ktpService"; //服务名称
                cs.Refresh();
                if (cs.Status == ServiceControllerStatus.Running)
                {
                    //判断已经运行
                }
                else if (cs.Status == ServiceControllerStatus.Stopped)
                {
                    leb_service.Visible = true;
                    btn_service.Visible = true;

                }
                else
                {

                    leb_service.Visible = true;
                    btn_service.Visible = true;
                }
            }
            catch (Exception ex)
            {

                leb_service.Text = "服务未安装或已删除，不能自动同步到服务器，请安装ktpService服务";
                leb_service.Visible = true;
                btn_service.Visible = false;
                LogHelper.ExceptionLog(ex);
            }
            finally
            {

            }
        }
    }
}
