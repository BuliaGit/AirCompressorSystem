using DAL.Helper;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmFaultAlarm : Form
    {
        //显示数目
        int showCount = 0;
        //主窗体句柄
        FrmMain handlerMain;
        public FrmFaultAlarm(FrmMain handler)
        {
            InitializeComponent();
            handlerMain = handler;
        }

        private void FrmFaultAlarm_Load(object sender, EventArgs e)
        {
            this.showCount = int.Parse(this.txt_count.Text.Trim());
            this.dgv_data.AutoGenerateColumns = false;
            this.cmb_TrendType.Items.Add("实时报警");
            this.cmb_TrendType.Items.Add("历史报警");
            this.cmb_TrendType.SelectedIndex = 0;
            UpdateDGV();
            //挂载报警更新事件
            Common.AlarmUpdateHandler += Common_AlarmUpdateHandler;
            //开启报警检测
            Common.isAlarmCheck = true;
        }

        private void Common_AlarmUpdateHandler(object sender, EventArgs e)
        {
            handlerMain.Invoke(new Action(() =>
            {
                UpdateDGV();
            }));
        }

        private void UpdateDGV()
        {
            this.dgv_data.DataSource = null;
            int actualCount = Common.alarmCacheList.Count;
            //从后往前取（使最新的在0索引处）并根据显示数量范围获取
            int start = actualCount - 1;
            int end = actualCount <= showCount ? 0 : actualCount - showCount;
            List<AlarmCache> reverseList = new List<AlarmCache>();
            for (int i = start; i >= end; i--)
            {
                reverseList.Add(Common.alarmCacheList[i]);
            }
            this.dgv_data.DataSource = reverseList;
            ChangeRowColor();
        }

        /// <summary>
        /// 改变报警行和消除报警行颜色
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void ChangeRowColor()
        {
            if (this.dgv_data.RowCount <= 0) return;
            foreach (DataGridViewRow item in dgv_data.Rows)
            {
                if (((AlarmCache)item.DataBoundItem).AlarmState == "ACK")
                {
                    item.DefaultCellStyle.BackColor = Color.Crimson;
                }
                else
                {
                    item.DefaultCellStyle.BackColor = Color.FromArgb(104, 228, 243);
                }
            }
        }

        private void txt_count_TextChanged(object sender, EventArgs e)
        {
            if (!DataValidate.IsInteger(this.txt_count.Text.Trim()))
            {
                MessageBox.Show("必须填入正整数!");
                return;
            }
            if (int.Parse(this.txt_count.Text.Trim()) > Common.AlarmCacheCount)
            {
                MessageBox.Show("填入数据不得大于" + Common.AlarmCacheCount);
                return;
            }
            this.showCount = int.Parse(this.txt_count.Text.Trim());
        }

        private void dgv_data_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewStyle.DgvRowPostPaint(this.dgv_data, e);
        }

        private void FrmFaultAlarm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.isAlarmCheck = false;
            //停止更新事件
            Common.AlarmUpdateHandler -= Common_AlarmUpdateHandler;
        }

        private void dgv_data_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgv_data.ClearSelection();
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            //停止更新事件
            Common.AlarmUpdateHandler -= Common_AlarmUpdateHandler;
            this.cmb_TrendType.SelectedIndex = 1;
            string sql = $"select CONVERT(varchar(100),InsertTime,20) as InsertTime,AlarmState,Priority,AlarmType,Value,AlarmValue,Operator,Note from AlarmData where 1=1";
            DateTime t1 = Convert.ToDateTime(this.dt_Start.Text);
            DateTime t2 = Convert.ToDateTime(this.dt_End.Text);
            if (t1 > t2)
            {
                MessageBox.Show("开始时间必须小于结束时间！");
                return;
            }
            TimeSpan ts = t2 - t1;
            if (ts.TotalDays > 7.0)
            {
                MessageBox.Show("查询范围太大，请重新选择!");
                return;
            }
            sql += $" and InsertTime between '{t1}' and '{t2}'";
            sql += $" Order bt Id DESC";
            this.dgv_data.DataSource = SQLHelper.GetDataSet(sql).Tables[0];
            ChangeRowColor();
        }

        private void cmb_TrendType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmb_TrendType.SelectedIndex == 0)//实时报警
            {
                //开始更新事件
                Common.AlarmUpdateHandler += Common_AlarmUpdateHandler;
            }
        }
    }
}
