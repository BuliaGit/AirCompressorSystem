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
    public partial class FrmParamSet : Form
    {
        public FrmParamSet()
        {
            InitializeComponent();
            foreach (var item in this.Controls)
            {
                if(item is TextBoxControl)
                {
                    ((TextBoxControl)item).myTimer.Enabled = true;
                }
            }
        }

        private void Param_UserControlClick(object sender, EventArgs e)
        {
            string paramAddress = string.Empty;
            TextBoxControl textBoxControl = (TextBoxControl)sender;
            if (Common.addressList.ContainsKey(textBoxControl.Name))
            {
                paramAddress = Common.addressList[textBoxControl.Name];
            }
            FrmChangeParam frmChangeParam = new FrmChangeParam(textBoxControl.Tag.ToString(),textBoxControl.ActualValue, paramAddress);
            frmChangeParam.ShowDialog();
        }
    }
}
