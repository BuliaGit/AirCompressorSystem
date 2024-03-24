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

namespace UI.HWConfigUI
{
    public partial class FrmNewVar : Form
    {
        public FrmNewVar()
        {
            InitializeComponent();
            this.chk_High.Enabled = false;
            this.chk_HiHi.Enabled = false;
            this.chk_Low.Enabled = false;
            this.chk_LoLo.Enabled = false;
        }

        private void FrmNewVar_Load(object sender, EventArgs e)
        {
            cmb_DataType.SelectedIndex = 6;
            cmb_StoreArea.SelectedIndex = 2;
        }


        //创建变量实例
        public ModbusVar var { get; set; }
        //创建报警变量实例
        public VarAlarm varAlarm { get; set; }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            //Modbus变量实例
            var = new ModbusVar();
            var.VarName = txt_VarName.Text.Trim();
            var.StoreArea = cmb_StoreArea.Text.Trim();
            var.DataType = cmb_DataType.Text.Trim();
            var.Address = txt_Address.Text.Trim();
            var.IsFiling = chk_IsFiling.Checked ? "1" : "0";
            var.IsAlarm = chk_IsAlarm.Checked ? "1" : "0";
            var.IsReport = chk_IsReport.Checked ? "1" : "0";
            var.Note = txt_Note.Text.Trim();

            //Modbus变量报警实例
            if (chk_High.Checked | chk_HiHi.Checked | chk_LoLo.Checked | chk_Low.Checked)
            {
                varAlarm = new VarAlarm();
                varAlarm.VarName = this.txt_VarName.Text.Trim();
                if (chk_High.Checked)
                {
                    varAlarm.Alarms.Add(new Alarm()
                    {
                        Priority = Convert.ToInt32(this.txt_Priority_High.Text.Trim()),
                        AlarmType = "High",
                        AlarmValue = float.Parse(this.txt_Alarm_High.Text.Trim()),
                        Note = this.txt_Note_High.Text.Trim()
                    });
                }
                if (chk_HiHi.Checked)
                {
                    varAlarm.Alarms.Add(new Alarm()
                    {
                        Priority = Convert.ToInt32(this.txt_Priority_HiHi.Text.Trim()),
                        AlarmType = "HiHi",
                        AlarmValue = float.Parse(this.txt_Alarm_HiHi.Text.Trim()),
                        Note = this.txt_Note_HiHi.Text.Trim()
                    });
                }
                if (chk_Low.Checked)
                {
                    varAlarm.Alarms.Add(new Alarm()
                    {
                        Priority = Convert.ToInt32(this.txt_Priority_Low.Text.Trim()),
                        AlarmType = "Low",
                        AlarmValue = float.Parse(this.txt_Alarm_Low.Text.Trim()),
                        Note = this.txt_Note_Low.Text.Trim()
                    });
                }
                if (chk_LoLo.Checked)
                {
                    varAlarm.Alarms.Add(new Alarm()
                    {
                        Priority = Convert.ToInt32(this.txt_Priority_LoLo.Text.Trim()),
                        AlarmType = "LoLo",
                        AlarmValue = float.Parse(this.txt_Alarm_LoLo.Text.Trim()),
                        Note = this.txt_Note_LoLo.Text.Trim()
                    });
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        #region CheckBox变化事件
        private void chk_IsAlarm_CheckedChanged(object sender, EventArgs e)
        {
            bool value = this.chk_IsAlarm.Checked;
            this.chk_High.Enabled = value;
            this.chk_HiHi.Enabled = value;
            this.chk_Low.Enabled = value;
            this.chk_LoLo.Enabled = value;
            if (!value)
            {
                this.chk_High.Checked = value;
                this.chk_HiHi.Checked = value;
                this.chk_Low.Checked = value;
                this.chk_LoLo.Checked = value;
            }
        }

        private void chk_LoLo_CheckedChanged(object sender, EventArgs e)
        {
            bool value = this.chk_LoLo.Checked;
            txt_Alarm_LoLo.Enabled = value;
            txt_Note_LoLo.Enabled= value;
            txt_Priority_LoLo.Enabled = value;
        }

        private void chk_Low_CheckedChanged(object sender, EventArgs e)
        {
            bool value = this.chk_Low.Checked;
            txt_Alarm_Low.Enabled = value;
            txt_Note_Low.Enabled = value;
            txt_Priority_Low.Enabled = value;
        }

        private void chk_HiHi_CheckedChanged(object sender, EventArgs e)
        {
            bool value = this.chk_HiHi.Checked;
            txt_Alarm_HiHi.Enabled = value;
            txt_Note_HiHi.Enabled = value;
            txt_Priority_HiHi.Enabled = value;
        }

        private void chk_High_CheckedChanged(object sender, EventArgs e)
        {
            bool value = this.chk_High.Checked;
            txt_Alarm_High.Enabled = value;
            txt_Note_High.Enabled = value;
            txt_Priority_High.Enabled = value;
        }

        #endregion
    }
}
