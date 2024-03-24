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
    public partial class FrmReportQuery : Form
    {
        public FrmReportQuery()
        {
            InitializeComponent();
        }
        public List<string> reportItemList = new List<string>();

        private void FrmReportQuery_Load(object sender, EventArgs e)
        {
            this.cmb_Zone.Items.Add("冷却水区域");
            this.cmb_Zone.Items.Add("压缩空气区域");
            this.cmb_Zone.SelectedIndex = 0;
            this.rdo_ZoneSel.Checked = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.rdo_ZoneSel.Checked)
            {
                if (this.cmb_Zone.SelectedIndex == 0)
                {
                    reportItemList.Add("LQT_Level");
                    reportItemList.Add("LQT_InPre");
                    reportItemList.Add("LQT_InTemp");
                    reportItemList.Add("LQT_OutPre");
                    reportItemList.Add("LQT_OutTemp");
                    reportItemList.Add("LQT_BSPre");
                    reportItemList.Add("LQB1_Current");
                    reportItemList.Add("LQB1_Fre");
                    reportItemList.Add("LQB2_Current");
                    reportItemList.Add("LQB2_Fre");
                }
                else if (this.cmb_Zone.SelectedIndex == 1)
                {
                    reportItemList.Add("KYJ1_OutTemp");
                    reportItemList.Add("KYJ2_OutTemp");
                    reportItemList.Add("KYJ3_OutTemp");
                    reportItemList.Add("CQG1_OutPre");
                    reportItemList.Add("CQG2_OutPre");
                    reportItemList.Add("CQG3_OutPre");
                    reportItemList.Add("Env_Temp");
                    reportItemList.Add("FQG_Temp");
                    reportItemList.Add("FQG_Pre");
                }
            }
            else if (this.rdo_default.Checked)
            {
                reportItemList.Add("LQT_Level");
                reportItemList.Add("LQT_InPre");
                reportItemList.Add("LQT_InTemp");
                reportItemList.Add("LQT_OutPre");
                reportItemList.Add("LQT_OutTemp");
                reportItemList.Add("LQT_BSPre");
                reportItemList.Add("LQB1_Current");
                reportItemList.Add("LQB1_Fre");
                reportItemList.Add("LQB2_Current");
                reportItemList.Add("LQB2_Fre");
            }
            else if (this.rdo_SelfSet.Checked)
            {
                if (reportItemList.Count == 0)
                {
                    MessageBox.Show("请自定义报表配置！");
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void rdo_SelfSet_CheckedChanged(object sender, EventArgs e)
        {
            this.btn_ReportSet.Enabled = this.rdo_SelfSet.Checked;
        }

        private void btn_ReportSet_Click(object sender, EventArgs e)
        {
            FrmReportConfig frmReportConfig = new FrmReportConfig();
            DialogResult res = frmReportConfig.ShowDialog();
            if(res == DialogResult.OK)
            {
                reportItemList = frmReportConfig.selVarNameList;
            }
        }
    }
}
