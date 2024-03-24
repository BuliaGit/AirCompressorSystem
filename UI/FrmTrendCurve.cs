using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DAL.Helper;
using Entity;

namespace UI
{
    public partial class FrmTrendCurve : Form
    {
        //当前显示曲线变量名集合
        private List<string> curveNameList = new List<string>();
        int count = 20;
        int lblNum = 0;
        BackgroundWorker bw = new BackgroundWorker();
        public FrmTrendCurve()
        {
            InitializeComponent();

            this.cmb_TrendType.Items.Add("实时趋势");
            this.cmb_TrendType.Items.Add("历史趋势");
            this.cmb_TrendType.SelectedIndex = 0;

            this.cmb_ZoneSel.Items.Add("冷却水区域");
            this.cmb_ZoneSel.Items.Add("压缩空气区域 ");
            this.cmb_ZoneSel.SelectedIndex = 0;
            
        }

        private void FrmTrendCurve_Load(object sender, EventArgs e)
        {
            this.chart1.Series.Clear();
            Series objSeries = new Series("冷却塔液位");
            objSeries.ChartType = SeriesChartType.Spline;
            objSeries.BorderWidth = 3;
            objSeries.XValueType = ChartValueType.DateTime;
            this.chart1.Series.Add(objSeries);
            this.Chk1_1.Checked = true;

            this.timer1.Enabled = true;

            count = int.Parse(this.txt_count.Text.Trim());
            lblNum = int.Parse(this.txt_lblNum.Text.Trim());

            bw.DoWork += Bw_DoWork;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<DataTable> list = (List<DataTable>)e.Result;
            if (list.Count == this.chart1.Series.Count)
            {
                for (int i = 0; i < this.chart1.Series.Count; i++)
                {
                    DataTable dt = list[i];
                    this.chart1.Series[i].Points.Clear();
                    this.chart1.Series[i].IsValueShownAsLabel = true;
                    this.chart1.Series[i].Points.DataBind(dt.AsEnumerable(), "Time", "Value", "");
                }
            }
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            List<DataTable> list = new List<DataTable>();
            List<DateTime> timeList = (List<DateTime>)e.Argument;
            for (int i = 0; i < this.chart1.Series.Count; i++)
            {
                string sql = $"select Value,CONVERT(varchar(100),InsertTime,108) as Time from ActualData where Remark='{this.chart1.Series[i].Name}' and InsertTime between '{timeList[0]}' and '{timeList[1]}'";
                DataTable dt = SQLHelper.GetDataSet(sql).Tables[0];
                if (dt != null)
                {
                    list.Add(dt);
                }
            }
            e.Result = list;
        }

        private void cmb_TrendType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_ZoneSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = "_" + (this.cmb_ZoneSel.SelectedIndex + 1).ToString();
            foreach (Control item in this.LeftPanel.Controls)
            {
                if (item is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)item;
                    if (checkBox.Name.Contains(str))
                    {
                        checkBox.Visible = true;
                    }
                    else
                    {
                        checkBox.Visible = false;
                    }
                }
            }
        }

        private void btn_sure_Click(object sender, EventArgs e)
        {
            this.chart1.Series.Clear();
            foreach (Control item in this.LeftPanel.Controls)
            {
                if(item is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)item;
                    if (checkBox.Checked && checkBox.Tag != null)
                    {
                        string seriesName = string.Empty;
                        if (Common.VarNameNoteDic.ContainsKey(checkBox.Tag.ToString()))
                        {
                            seriesName = Common.VarNameNoteDic[checkBox.Tag.ToString()];
                        }
                        Series objSeries = new Series(seriesName);
                        objSeries.ChartType = SeriesChartType.Spline;
                        objSeries.BorderWidth = 3;
                        objSeries.XValueType = ChartValueType.DateTime;
                        this.chart1.Series.Add(objSeries);
                    }
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.LeftPanel.Controls)   
            {
                if(item is CheckBox)
                {
                    CheckBox chk = (CheckBox)item;
                    chk.Checked = false;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Series item in this.chart1.Series)
            {
                List<DateTime> X = new List<DateTime>();
                List<string> Y = new List<string>();
                int index = Common.fileNameList.IndexOf(item.Name);
                int startIndex = Common.filingCacheList.Count <= count ? 0 : Common.filingCacheList.Count - count;
                for (int i = startIndex; i < Common.filingCacheList.Count; i++)
                {
                    List<FilingData> list = Common.filingCacheList[i];
                    X.Add(list[index].InsertTime);
                    Y.Add(list[index].Value);
                }
                item.IsValueShownAsLabel = count<= lblNum ? true:false;
                item.Points.DataBindXY(X, Y);
            }
        }

        private void txt_count_TextChanged(object sender, EventArgs e)
        {
            if (!DataValidate.IsInteger(this.txt_count.Text.Trim()))
            {
                MessageBox.Show("必须填入整数", "填写错误");
                return;
            }
            if (int.Parse(this.txt_count.Text.Trim()) > Common.cacheCount)
            {
                MessageBox.Show("填入数据不得大于" + Common.cacheCount.ToString(), "填写错误");
                return;
            }
            count = int.Parse(this.txt_count.Text.Trim());
        }

        private void txt_lblNum_TextChanged(object sender, EventArgs e)
        {
            if (!DataValidate.IsInteger(this.txt_lblNum.Text.Trim()))
            {
                MessageBox.Show("必须填入整数", "填写错误");
                return;
            }
            if (int.Parse(this.txt_lblNum.Text.Trim()) > Common.cacheCount)
            {
                MessageBox.Show("填入数据不得大于" + Common.cacheCount.ToString(), "填写错误");
                return;
            }
            lblNum = int.Parse(this.txt_lblNum.Text.Trim());
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            this.cmb_TrendType.SelectedIndex = 0;
            this.timer1.Enabled = !this.timer1.Enabled;
            if(this.timer1.Enabled )
            {
                this.btn_Update.Text = "停止更新";
            }
            else
            {
                this.btn_Update.Text = "开始更新";
            }
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            this.cmb_TrendType.SelectedIndex = 1;
            this.timer1.Enabled = false;
            this.btn_Update.Text = "开始更新";
            DateTime t1 = Convert.ToDateTime(this.dt_start.Text);
            DateTime t2 = Convert.ToDateTime(this.dt_end.Text);
            if(t1 > t2)
            {
                MessageBox.Show("开始时间必须小于结束时间!");
                return;
            }
            TimeSpan ts = t2 - t1;
            if (ts.TotalHours > 6.0)
            {
                MessageBox.Show("查询范围太多!");
                return;
            }
            List<DateTime> time = new List<DateTime>() { t1, t2 };
            if (!bw.IsBusy)
            {
                bw.RunWorkerAsync(time);
            }
        }
    }
}
