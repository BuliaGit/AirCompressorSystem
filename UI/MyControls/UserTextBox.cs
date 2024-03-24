using System;
using System.Windows.Forms;


namespace UI
{
    public partial class TextBoxControl : UserControl
    {
        private string BindTag { get { return this.Name; }}
        public Timer myTimer;
        public TextBoxControl() 
        {
            InitializeComponent();
            myTimer = new Timer();
            myTimer.Interval = 1000;
            myTimer.Tick += Mytimer_Tick;
        }

        private void Mytimer_Tick(object sender, EventArgs e)
        {
            //------------------------------------------------？？？？？？？？？？？
            //this.ParentForm.Invoke(new Action(() =>
            //{
            //    if (BindTag != null)
            //    {
            //        if (Common.valueDic != null && Common.valueDic.ContainsKey(BindTag))
            //        {
            //            this.ActualValue = Common.valueDic[BindTag];
            //        }
            //    }
            //}));
            if (BindTag != null)
            {
                if (Common.valueDic != null && Common.valueDic.ContainsKey(BindTag))
                {
                    this.ActualValue = Common.valueDic[BindTag];
                }
            }
        }

        //数值
        private string actualValue = "000.0";
        public string ActualValue
        {
            get { return actualValue; }
            set
            {
                actualValue = value;
                this.lbl_data.Text = actualValue;
            }
        }

        /// <summary>
        /// 单位
        /// </summary>
        private string unit = "Mpa";
        public string Unit
        {
            get { return unit; }
            set
            {
                unit = value;
                this.lbl_unit.Text = unit;
            }
        }

        public delegate void BtnClickDelagate(object sender, EventArgs e);

        public event BtnClickDelagate UserControlClick;

        private void lbl_data_DoubleClick(object sender, EventArgs e)
        {
            if (UserControlClick != null)
            {
                UserControlClick(this, new EventArgs());//把按钮自身作为参数传递
            }
        }
    }
}
