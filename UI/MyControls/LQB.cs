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
    public partial class LQB : UserControl
    {
        public LQB()
        {
            InitializeComponent();
            mytimer = new Timer();
            mytimer.Interval = 10;
            mytimer.Tick += mytimer_Tick;
        }

        void mytimer_Tick(object sender, EventArgs e)
        {
            if (this.DeviceStateName != null)
            {
                if (Common.valueDic != null && Common.valueDic.ContainsKey(DeviceStateName))
                {
                    Start = Common.valueDic[DeviceStateName] == "1" ? true : false;
                }
            }
            if (Start)
            {
                if (this.index < this.indexMax)
                {
                    this.index++;
                }
                else
                {
                    this.index = 0;
                }
            }
            this.change();
        }

        private void change()
        {
            switch (this.index)
            {
                case 0: this.MainPic.Image = Properties.Resources._1; break;
                case 1: this.MainPic.Image = Properties.Resources._2; break;
                case 2: this.MainPic.Image = Properties.Resources._3; break;
                case 3: this.MainPic.Image = Properties.Resources._4; break;
                case 4: this.MainPic.Image = Properties.Resources._5; break;
                case 5: this.MainPic.Image = Properties.Resources._6; break;
                case 6: this.MainPic.Image = Properties.Resources._7; break;
                case 7: this.MainPic.Image = Properties.Resources._8; break;
                case 8: this.MainPic.Image = Properties.Resources._9; break;
                case 9: this.MainPic.Image = Properties.Resources._10; break;
                case 10: this.MainPic.Image = Properties.Resources._11; break;
                default: this.MainPic.Image = Properties.Resources._1; break;
            }

        }

        //当前选择的图片序号
        private int index;

        //定义一个定时器
        public Timer mytimer;

        //定义定时器的时间间隔
        private int interval = 10;

        //定义设备状态变量
        private string DeviceStateName { get { return this.Name; } set { } }

        //定义设备启动变量
        public string DeviceStartName { get; set; }

        //定义设备停止变量
        public string DeviceStopName { get; set; }

        //定义设备名称
        public string DeviceName { get; set; }


        public int Interval
        {

            get { return mytimer.Interval; }
            set
            {

                if (value != mytimer.Interval)
                {
                    mytimer.Interval = value;
                }
            }
        }

        //定义控件的转动属性
        private bool start = false;
        public bool Start
        {
            get { return start; }
            set { start = value; }
        }

        //最大图片数目
        private int indexMax = 11;
        public int IndexMax
        {
            get { return indexMax; }
            set { indexMax = value; }
        }

        public delegate void PumpClickDelegate(object sender, EventArgs e);

        public event PumpClickDelegate UserControlClick;

        private void MainPic_DoubleClick(object sender, EventArgs e)
        {
            if (UserControlClick != null)
            {
                UserControlClick(this, new EventArgs());
            }
        }

    }
}
