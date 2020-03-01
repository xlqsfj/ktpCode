namespace KtpAcsMiddleware.WinForm.WorkerAuths
{
    partial class WorkerAuthDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.AuthCms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AuthReloadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClockDateDtpBegin = new System.Windows.Forms.DateTimePicker();
            this.ClockTimeList = new System.Windows.Forms.ListView();
            this.ClockDateDtpEnd = new System.Windows.Forms.DateTimePicker();
            this.WorkingTimeChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.AuthCms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkingTimeChart)).BeginInit();
            this.SuspendLayout();
            // 
            // AuthCms
            // 
            this.AuthCms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AuthReloadMenuItem});
            this.AuthCms.Name = "TeamsCms";
            this.AuthCms.Size = new System.Drawing.Size(101, 26);
            // 
            // AuthReloadMenuItem
            // 
            this.AuthReloadMenuItem.Name = "AuthReloadMenuItem";
            this.AuthReloadMenuItem.Size = new System.Drawing.Size(100, 22);
            this.AuthReloadMenuItem.Text = "刷新";
            this.AuthReloadMenuItem.Click += new System.EventHandler(this.AuthReloadMenuItem_Click);
            // 
            // ClockDateDtpBegin
            // 
            this.ClockDateDtpBegin.CalendarFont = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClockDateDtpBegin.Location = new System.Drawing.Point(259, 36);
            this.ClockDateDtpBegin.Name = "ClockDateDtpBegin";
            this.ClockDateDtpBegin.Size = new System.Drawing.Size(257, 21);
            this.ClockDateDtpBegin.TabIndex = 70;
            this.ClockDateDtpBegin.ValueChanged += new System.EventHandler(this.ClockDateDtpBegin_ValueChanged);
            // 
            // ClockTimeList
            // 
            this.ClockTimeList.ContextMenuStrip = this.AuthCms;
            this.ClockTimeList.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClockTimeList.Location = new System.Drawing.Point(7, 36);
            this.ClockTimeList.Name = "ClockTimeList";
            this.ClockTimeList.Scrollable = false;
            this.ClockTimeList.Size = new System.Drawing.Size(246, 684);
            this.ClockTimeList.TabIndex = 72;
            this.ClockTimeList.UseCompatibleStateImageBehavior = false;
            this.ClockTimeList.View = System.Windows.Forms.View.List;
            // 
            // ClockDateDtpEnd
            // 
            this.ClockDateDtpEnd.CalendarFont = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClockDateDtpEnd.Location = new System.Drawing.Point(522, 36);
            this.ClockDateDtpEnd.Name = "ClockDateDtpEnd";
            this.ClockDateDtpEnd.Size = new System.Drawing.Size(266, 21);
            this.ClockDateDtpEnd.TabIndex = 73;
            this.ClockDateDtpEnd.ValueChanged += new System.EventHandler(this.ClockDateDtpEnd_ValueChanged);
            // 
            // WorkingTimeChart
            // 
            chartArea2.Name = "ChartArea1";
            this.WorkingTimeChart.ChartAreas.Add(chartArea2);
            this.WorkingTimeChart.ContextMenuStrip = this.AuthCms;
            legend2.Name = "Legend1";
            this.WorkingTimeChart.Legends.Add(legend2);
            this.WorkingTimeChart.Location = new System.Drawing.Point(259, 63);
            this.WorkingTimeChart.Name = "WorkingTimeChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.WorkingTimeChart.Series.Add(series2);
            this.WorkingTimeChart.Size = new System.Drawing.Size(742, 657);
            this.WorkingTimeChart.TabIndex = 74;
            this.WorkingTimeChart.Text = "WorkingTimeChart";
            // 
            // WorkerAuthDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 724);
            this.ContextMenuStrip = this.AuthCms;
            this.Controls.Add(this.WorkingTimeChart);
            this.Controls.Add(this.ClockDateDtpEnd);
            this.Controls.Add(this.ClockTimeList);
            this.Controls.Add(this.ClockDateDtpBegin);
            this.Name = "WorkerAuthDetail";
            this.Text = "工人考勤详细";
            this.Load += new System.EventHandler(this.WorkerAuthDetail_Load);
            this.AuthCms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WorkingTimeChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip AuthCms;
        private System.Windows.Forms.ToolStripMenuItem AuthReloadMenuItem;
        private System.Windows.Forms.DateTimePicker ClockDateDtpBegin;
        private System.Windows.Forms.ListView ClockTimeList;
        private System.Windows.Forms.DateTimePicker ClockDateDtpEnd;
        private System.Windows.Forms.DataVisualization.Charting.Chart WorkingTimeChart;
    }
}