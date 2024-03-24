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
    public partial class FrmChangeVar : Form
    {
        //要修改的modbus变量
        public ModbusVar changeModVar;
        //要修改的报警变量
        public VarAlarm changeAlarm;
        public FrmChangeVar(ModbusVar modbusVar, VarAlarm changeAlarm)
        {
            InitializeComponent();
            //获取修改的变量实例
            this.changeModVar = modbusVar;
            this.changeAlarm = changeAlarm;
        }

        /// <summary>
        /// 窗体加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmChangeVar_Load(object sender, EventArgs e)
        {
            //变量名字当作主键
            this.txt_VarName.Enabled = false;
            InitialUIValue();
        }

        /// <summary>
        /// 点击确认修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            //Modbus变量实例
            changeModVar.StoreArea = cmb_StoreArea.Text.Trim();
            changeModVar.DataType = cmb_DataType.Text.Trim();
            changeModVar.Address = txt_Address.Text.Trim();
            changeModVar.IsFiling = chk_IsFiling.Checked ? "1" : "0";
            changeModVar.IsAlarm = chk_IsAlarm.Checked ? "1" : "0";
            changeModVar.IsReport = chk_IsReport.Checked ? "1" : "0";
            changeModVar.Note = txt_Note.Text.Trim();

            //Modbus变量报警实例
            //如果选中报警值则先清空再添加，否则直接清空报警值集合
            if (chk_High.Checked | chk_HiHi.Checked | chk_LoLo.Checked | chk_Low.Checked)
            {
                changeAlarm.VarName = this.txt_VarName.Text.Trim();
                changeAlarm.Alarms.Clear();
                if (chk_HiHi.Checked)
                {
                    changeAlarm.Alarms.Add(new Alarm()
                    {
                        Priority = Convert.ToInt32(this.txt_Priority_HiHi.Text.Trim()),
                        AlarmType = "HiHi",
                        AlarmValue = float.Parse(this.txt_Alarm_HiHi.Text.Trim()),
                        Note = this.txt_Note_HiHi.Text.Trim()
                    });
                }
                if (chk_High.Checked)
                {
                    changeAlarm.Alarms.Add(new Alarm()
                    {
                        Priority = Convert.ToInt32(this.txt_Priority_High.Text.Trim()),
                        AlarmType = "High",
                        AlarmValue = float.Parse(this.txt_Alarm_High.Text.Trim()),
                        Note = this.txt_Note_High.Text.Trim()
                    });
                }
                if (chk_LoLo.Checked)
                {
                    changeAlarm.Alarms.Add(new Alarm()
                    {
                        Priority = Convert.ToInt32(this.txt_Priority_LoLo.Text.Trim()),
                        AlarmType = "LoLo",
                        AlarmValue = float.Parse(this.txt_Alarm_LoLo.Text.Trim()),
                        Note = this.txt_Note_LoLo.Text.Trim()
                    });
                }
                if (chk_Low.Checked)
                {
                    changeAlarm.Alarms.Add(new Alarm()
                    {
                        Priority = Convert.ToInt32(this.txt_Priority_Low.Text.Trim()),
                        AlarmType = "Low",
                        AlarmValue = float.Parse(this.txt_Alarm_Low.Text.Trim()),
                        Note = this.txt_Note_Low.Text.Trim()
                    });
                }
                
            }
            else
            {
                changeAlarm.Alarms.Clear();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 初始化控件值
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void InitialUIValue()
        {
            this.txt_VarName.Text = changeModVar.VarName;
            this.cmb_DataType.Text = changeModVar.DataType;
            this.cmb_StoreArea.Text = changeModVar.StoreArea;
            this.txt_Address.Text = changeModVar.Address;
            this.txt_Note.Text = changeModVar.Note;
            this.chk_IsReport.Checked = changeModVar.IsReport == "1" ? true : false;
            this.chk_IsFiling.Checked = changeModVar.IsFiling == "1" ? true : false;
            this.chk_IsAlarm.Checked = changeModVar.IsAlarm == "1" ? true : false;
            if (changeModVar.IsAlarm == "1")//初始报警值
            {
                foreach (Alarm item in changeAlarm.Alarms)
                {
                    switch (item.AlarmType)
                    {
                        case "High":
                            this.chk_High.Checked = true;
                            this.txt_Alarm_High.Text = item.AlarmValue.ToString();
                            this.txt_Priority_High.Text = item.Priority.ToString();
                            this.txt_Note_High.Text = item.Note;
                            break;
                        case "HiHi":
                            this.chk_HiHi.Checked = true;
                            this.txt_Alarm_HiHi.Text = item.AlarmValue.ToString();
                            this.txt_Priority_HiHi.Text = item.Priority.ToString();
                            this.txt_Note_HiHi.Text = item.Note;
                            break;
                        case "Low":
                            this.chk_Low.Checked = true;
                            this.txt_Alarm_Low.Text = item.AlarmValue.ToString();
                            this.txt_Priority_Low.Text = item.Priority.ToString();
                            this.txt_Note_Low.Text = item.Note;
                            break;
                        case "LoLo":
                            this.chk_LoLo.Checked = true;
                            this.txt_Alarm_LoLo.Text = item.AlarmValue.ToString();
                            this.txt_Priority_LoLo.Text = item.Priority.ToString();
                            this.txt_Note_LoLo.Text = item.Note;
                            break;
                        default:
                            break;
                    }
                }      
            }
            else
            {
                foreach (Control item in alarmPanel.Controls)
                {
                    item.Enabled = false;
                }
            }

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
            txt_Note_LoLo.Enabled = value;
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
