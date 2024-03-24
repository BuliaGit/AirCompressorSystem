using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI;

namespace UI
{
    public partial class TapControl : UserControl
    {
        public Timer mytimer;
        public TapControl()
        {
            InitializeComponent();
            mytimer = new Timer();
            mytimer.Interval = 1000;
            mytimer.Tick += Mytimer_Tick;
            this.Load += Tap_Load;
        }

        private void Mytimer_Tick(object sender, EventArgs e)
        {
            if (this.DeviceStateName != null)
            {
                if (Common.valueDic != null && Common.valueDic.ContainsKey(DeviceStateName))
                {
                    ActualValue = Common.valueDic[DeviceStateName] == "1" ? true : false;
                }
            }

        }

        void Tap_Load(object sender, EventArgs e)
        {
            if (actualValue)
            {
                this.MainPic.Image = UI.Properties.Resources.tapOpen;
            }
            else
            {
                this.MainPic.Image = UI.Properties.Resources.tapClose;
            }
        }
        //定义设备状态变量
        private string DeviceStateName { get { return this.Name; } set { } }

        //定义设备启动变量
        public string DeviceStartName { get; set; }

        //定义设备停止变量
        public string DeviceStopName { get; set; }

        //定义设备名称
        public string DeviceName { get; set; }

        private bool actualValue = false;
        public bool ActualValue
        {
            get { return actualValue; }
            set
            {
                actualValue = value;
                if (actualValue)
                {
                    this.MainPic.Image = UI.Properties.Resources.tapOpen;
                }
                else
                {
                    this.MainPic.Image = UI.Properties.Resources.tapClose;
                }
            }
        }

        public delegate void TapClickDelegate(object sender, EventArgs e);

        public event TapClickDelegate UserControlClick;

        private void MainPic_DoubleClick(object sender, EventArgs e)
        {
            if (UserControlClick != null)
            {
                UserControlClick(this, new EventArgs());
            }
        }
    }
}
