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
    public partial class FrmControlFlow : Form
    {
        public FrmControlFlow()
        {
            InitializeComponent();
            foreach (var item in this.Controls)
            {
                if (item is TextBoxControl)
                {
                    ((TextBoxControl)item).myTimer.Enabled = true;
                }
                else if (item is TapControl)
                {
                    ((TapControl)item).mytimer.Enabled = true;
                }else if(item is LQB)
                {
                    ((LQB)item).mytimer.Enabled = true;
                }
            }
            //LQT_InPre.myTimer.Enabled = true;
            //LQT_InTemp.myTimer.Enabled = true;
            //LQT_Level.myTimer.Enabled = true;
            //LQT_OutPre.myTimer.Enabled = true;
            //LQT_OutTemp.myTimer.Enabled = true;
            //LQB1_Run_State.mytimer.Enabled = true;
            //LQB2_Run_State.mytimer.Enabled = true;
            //FQG_Pre.myTimer.Enabled = true;
            //FQG_Temp.myTimer.Enabled = true;
            //KYJ1_OutTemp.myTimer.Enabled = true;
            //KYJ2_OutTemp.myTimer.Enabled = true;
            //KYJ3_OutTemp.myTimer.Enabled = true;
            //CQG1_OutPre.myTimer.Enabled = true;
            //CQG2_OutPre.myTimer.Enabled = true;
            //CQG3_OutPre.myTimer.Enabled = true;
            //Env_Temp.myTimer.Enabled = true;
            //KYJ1In_Run_State.mytimer.Enabled = true;
            //KYJ2In_Run_State.mytimer.Enabled = true;
            //KYJ3In_Run_State.mytimer.Enabled = true;
            //CQG1_Out_State.mytimer.Enabled = true;
            //CQG2_Out_State.mytimer.Enabled = true;
            //CQG3_Out_State.mytimer.Enabled = true;
        }

        private void Device_UserControlClick(object sender, EventArgs e)
        {
            string devName = string.Empty;
            string stateName = string.Empty;
            string stateAddress = string.Empty;
            string startAddress = string.Empty;
            string stopAddress = string.Empty;
            string devStartName = string.Empty;
            string devStopName = string.Empty;
            //设备判断
            if (sender is LQB)//冷却泵控件
            {
                LQB lqb = (LQB)sender;
                devName = lqb.DeviceName;
                stateName = lqb.Name;
                devStartName = lqb.DeviceStartName;
                devStopName = lqb.DeviceStopName;
            }
            else if (sender is TapControl)//阀门控件
            {
                TapControl tap = (TapControl)sender;
                devName = tap.DeviceName;
                stateName = tap.Name;
                devStartName = tap.DeviceStartName;
                devStopName = tap.DeviceStopName;
            }
            //获取数据
            if (Common.addressList.ContainsKey(devStartName))
            {
                startAddress = Common.addressList[devStartName];
            }
            if (Common.addressList.ContainsKey(devStopName))
            {
                stopAddress = Common.addressList[devStopName];
            }
            if (Common.addressList.ContainsKey(stateName))
            {
                stateAddress = Common.addressList[stateName];
            }
            //传值设备名、开启地址、关闭地址
            FrmDevControl frmDevControl = new FrmDevControl(devName, startAddress, stopAddress, stateAddress);
            frmDevControl.ShowDialog();
        }
    }
}
