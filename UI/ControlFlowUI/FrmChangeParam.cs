using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmChangeParam : Form
    {
        string paramName = string.Empty;
        string paramAddress = string.Empty;
        public FrmChangeParam()
        {
            InitializeComponent();
        }

        public FrmChangeParam(string paramName,string initalValue,string paramAddress)
        {
            InitializeComponent();
            this.paramName = paramName;
            this.paramAddress = paramAddress;
            this.lblInitalValue.Text = initalValue;
            this.groupBox1.Text = $"【{paramName}】参数设置：";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Common.isWriting = true;
            Thread.Sleep(500);
            if (Common.objMod.PreSetFloatReg(Common.address, int.Parse(paramAddress), float.Parse(txtChangeValue.Text)))
            {
                MessageBox.Show($"修改【{paramName}】参数成功！");
            }
            else
            {
                MessageBox.Show($"修改【{paramName}】参数成功！");
            }
            Common.isWriting = false;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
