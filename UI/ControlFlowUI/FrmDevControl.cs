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
    public partial class FrmDevControl : Form
    {
        string startAddress = string.Empty;
        string stopAddress = string.Empty;
        string stateAddress = string.Empty;

        public FrmDevControl()
        {
            InitializeComponent();
        }

        public FrmDevControl(string DevName, string startAddress, string stopAddress, string stateAddress)
        {
            InitializeComponent();
            this.startAddress = startAddress;
            this.stopAddress = stopAddress;
            this.lblStartName.Text = "开启" + DevName;
            this.lblStopName.Text = "关闭 " + DevName;
            this.stateAddress = stateAddress;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Common.isWriting = true;
            Thread.Sleep(500);
            bool res1 = Common.objMod.PreSetKeepReg(Common.address, int.Parse(startAddress), 256);
            bool res2 = Common.objMod.PreSetKeepReg(Common.address, int.Parse(stopAddress), 0);
            bool res3 = Common.objMod.PreSetKeepReg(Common.address, int.Parse(stateAddress), 256);
            if (res1 && res2 && res3)
            {
                MessageBox.Show(this.lblStartName.Text + "成功!");
            }
            else
            {
                MessageBox.Show(this.lblStartName.Text + "失败!");
            }
            Common.isWriting = false;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Common.isWriting = true;
            Thread.Sleep(500);
            bool res1 = Common.objMod.PreSetKeepReg(Common.address, int.Parse(stopAddress), 256);
            bool res2 = Common.objMod.PreSetKeepReg(Common.address, int.Parse(startAddress), 0);
            bool res3 = Common.objMod.PreSetKeepReg(Common.address, int.Parse(stateAddress), 0);
            if (res1 && res2 && res3)
            {
                MessageBox.Show(this.lblStopName.Text + "成功!");
            }
            else
            {
                MessageBox.Show(this.lblStopName.Text + "失败!");
            }
            Common.isWriting = false;
            this.Close();
        }
    }
}
