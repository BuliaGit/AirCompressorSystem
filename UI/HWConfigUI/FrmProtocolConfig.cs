using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.HWConfigUI
{
    //串口参数设置
    public partial class FrmProtocolConfig : Form
    {
        public FrmProtocolConfig()
        {
            InitializeComponent();
        }
        //串口参数保存路径
        private string modbusSavePath = Application.StartupPath + @"\ConfigFile\" + "MODBUS.ini";

        /// <summary>
        /// 保存协议配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter(modbusSavePath);
                sw.WriteLine(cboPort.Text);
                sw.WriteLine(cboAddress.Text);
                sw.WriteLine(cboPaud.Text);
                sw.WriteLine(cboParity.Text);
                sw.WriteLine(cboDataBits.Text);
                sw.WriteLine(cboStopBits.Text);
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存文件出现异常：" + ex.Message);
            }
            MessageBox.Show("协议信息保存成功！");
        }

        /// <summary>
        /// 初始化参数控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmProtocolConfig_Load(object sender, EventArgs e)
        {
            //Port
            for (int i = 0; i < 20; i++)
            {
                cboPort.Items.Add("COM" + i);
            }
            cboPort.SelectedIndex = 1;
            //Paud
            cboPaud.Items.Add("4800");
            cboPaud.Items.Add("9600");
            cboPaud.Items.Add("14400");
            cboPaud.Items.Add("19200");
            cboPaud.Items.Add("38400");
            cboPaud.SelectedIndex = 1;
            //Parity
            cboParity.Items.Add("None");
            cboParity.Items.Add("Odd");
            cboParity.Items.Add("Even");
            cboParity.SelectedIndex = 0;
            //Adress
            for (int i = 0; i < 20; i++)
            {
                cboAddress.Items.Add(i.ToString());
            }
            cboAddress.SelectedIndex = 1;
            //DataBits
            cboDataBits.Items.Add("7");
            cboDataBits.Items.Add("8");
            cboDataBits.SelectedIndex = 1;
            //StopBits
            cboStopBits.Items.Add("1");
            cboStopBits.Items.Add("2");
            cboStopBits.SelectedIndex = 0;
        }

        private void btnCanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
