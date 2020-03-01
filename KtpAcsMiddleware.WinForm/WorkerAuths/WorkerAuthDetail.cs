using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Domain.WorkerAuths;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.WinForm.Models;
using KtpAcsMiddleware.WinForm.Shared;

namespace KtpAcsMiddleware.WinForm.WorkerAuths
{
    public partial class WorkerAuthDetail : FormBaseUi
    {
        private readonly string _workerId;

        public WorkerAuthDetail()
        {
            InitializeComponent();
        }

        public WorkerAuthDetail(string workerId)
        {
            InitializeComponent();
            _workerId = workerId;
            ClockDateDtpBegin.Value = ClockDateDtpEnd.Value = DateTime.Now;
        }

        private void WorkerAuthDetail_Load(object sender, EventArgs e)
        {
            WorkingTimeChart.BackColor = Color.Transparent;
            WorkingTimeChart.Legends[0].Position.Auto = true;
            WorkingTimeChart.Titles.Add("WorkingTimeChartTitle");
            WorkingTimeChart.Titles[0].Text = "工时";

            WorkingTimeChart.ChartAreas[0].BackColor = Color.Transparent;
            WorkingTimeChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false; //不显示网格线
            WorkingTimeChart.ChartAreas[0].AxisX.Title = "日期";
            WorkingTimeChart.ChartAreas[0].AxisX.Interval = 1; //间隔
            WorkingTimeChart.ChartAreas[0].AxisX.IntervalOffset = 1; //间隔偏移量
            WorkingTimeChart.ChartAreas[0].AxisY.IntervalType = DateTimeIntervalType.Number; //间隔类型
            WorkingTimeChart.ChartAreas[0].AxisX.TextOrientation = TextOrientation.Horizontal;
            WorkingTimeChart.ChartAreas[0].AxisX.LabelStyle.Format = "MM-dd"; //时间格式。
            //WorkingTimeChart.ChartAreas[0].AxisX.LabelStyle.IsStaggered = true;
            //WorkingTimeChart.ChartAreas[0].AxisX.IsLabelAutoFit = false;

            WorkingTimeChart.ChartAreas[0].AxisY.Interval = 1;
            WorkingTimeChart.ChartAreas[0].AxisY.IntervalOffset = 1;
            WorkingTimeChart.ChartAreas[0].AxisY.Minimum = 0;
            WorkingTimeChart.ChartAreas[0].AxisY.Maximum = 24;
            WorkingTimeChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false; //不显示网格线
            WorkingTimeChart.ChartAreas[0].AxisY.Title = "当日工时";

            WorkingTimeChart.Series.Clear();
            WorkingTimeChart.Series.Add("工时");
            WorkingTimeChart.Series[0].Color = Color.Lime;
            WorkingTimeChart.Series[0].IsValueShownAsLabel = true;
            WorkingTimeChart.Series[0].CustomProperties = "DrawingStyle=Cylinder";

            //_workerId = ConfigHelper.NewGuid;
            BindWorkingTimes();
        }

        private void BindWorkingTimes()
        {
            try
            {
                ClockTimeList.Items.Clear();
                WorkingTimeChart.Series[0].Points.Clear();

                DateTime? beginTime = ClockDateDtpBegin.Value.Date;
                DateTime? endTime = ClockDateDtpEnd.Value.Date;
                if (beginTime > endTime)
                {
                    MessageHelper.Show("时间范围错误，开始时间不允许大于结束时间");
                    return;
                }
                //当前日期，获取默认范围(有记录的最近十天)
                if (beginTime.Value.Date == endTime.Value.Date && beginTime.Value.Date == DateTime.Now.Date)
                {
                    beginTime = null;
                    endTime = null;
                }

                //绑定打卡记录数据
                var wokerClockList = ServiceFactory.WorkerAuthService.GetCycleList(_workerId, beginTime, endTime);
                if (wokerClockList == null)
                {
                    return;
                }
                foreach (var wokerClock in wokerClockList)
                {
                    var wokerClockStr =
                        $"{FormatHelper.GetIsoDateTimeString(wokerClock.ClockTime)} {((WorkerAuthClockType) wokerClock.ClockType).ToEnumText()}";
                    ClockTimeList.Items.Add(wokerClockStr);
                }

                //报表根据打卡记录获取统计
                beginTime = wokerClockList.Last().ClockTime.Date;
                endTime = wokerClockList.First().ClockTime;
                var wrkerDailyWorkingTimes =
                    ServiceFactory.WorkerAuthService.GetWorkerDailyWorkingTimes(_workerId, beginTime.Value, endTime);

                IList<DateTime> xList = new List<DateTime>();
                IList<decimal> yList = new List<decimal>();
                foreach (var workerDailyWorkingTime in wrkerDailyWorkingTimes)
                {
                    if (xList.Contains(workerDailyWorkingTime.WorkDate))
                    {
                        continue;
                    }
                    xList.Add(workerDailyWorkingTime.WorkDate);
                    yList.Add(workerDailyWorkingTime.WorkingHour);
                }
                WorkingTimeChart.Series[0].Points.DataBindXY(xList, yList);
                ////数据写入报表中
                //IList<DateTime> x = new List<DateTime>();
                //IList<decimal> y = new List<decimal>();
                //var xTime = endTime;
                //while (true)
                //{
                //    x.Add(xTime.Value);
                //    var wrkerDailyWorkingTime =
                //        wrkerDailyWorkingTimes.FirstOrDefault(i => i.WorkDate.Date == xTime.Value.Date);
                //    y.Add(wrkerDailyWorkingTime != null ? wrkerDailyWorkingTime.WorkingHour : 0);

                //    xTime = xTime.Value.AddDays(-1);
                //    if (xTime < beginTime)
                //    {
                //        break;
                //    }
                //}
                //WorkingTimeChart.Series[0].Points.DataBindXY(x, y);
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                MessageHelper.Show(ex);
            }
        }

        /// <summary>
        ///     右键-刷新
        /// </summary>
        private void AuthReloadMenuItem_Click(object sender, EventArgs e)
        {
            BindWorkingTimes();
        }

        /// <summary>
        ///     开始时间改变
        /// </summary>
        private void ClockDateDtpBegin_ValueChanged(object sender, EventArgs e)
        {
            if (ClockDateDtpBegin.Value > DateTime.Now)
            {
                MessageHelper.Show("被选中的时间不得大于当前时间");
                ClockDateDtpEnd.Value = ClockDateDtpBegin.Value = DateTime.Now;
                return;
            }
            if (ClockDateDtpBegin.Value > ClockDateDtpEnd.Value)
            {
                ClockDateDtpEnd.Value = ClockDateDtpBegin.Value;
            }
            BindWorkingTimes();
        }

        /// <summary>
        ///     结束时间改变
        /// </summary>
        private void ClockDateDtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (ClockDateDtpEnd.Value > DateTime.Now)
            {
                MessageHelper.Show("被选中的时间不得大于当前时间");
                ClockDateDtpEnd.Value = ClockDateDtpBegin.Value = DateTime.Now;
                return;
            }
            if (ClockDateDtpEnd.Value < ClockDateDtpBegin.Value)
            {
                ClockDateDtpBegin.Value = ClockDateDtpEnd.Value;
            }
            BindWorkingTimes();
        }
    }
}