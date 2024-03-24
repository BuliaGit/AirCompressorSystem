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
    //硬件组态窗口
    public partial class FrmHWConfig : Form
    {
        public FrmHWConfig()
        {
            InitializeComponent();
        }



        //串口参数
        private void btnProtocol_Click(object sender, EventArgs e)
        {
            
            ShowForm(new FrmProtocolConfig());
            BtnClickColorSet((Button)sender);
            //对退出取消复原
            Common.IOExitCanel = false;
        }

        //IO变量
        private void btnIO_Click(object sender, EventArgs e)
        {
            
            ShowForm(new FrmIOVarManage());
            BtnClickColorSet((Button)sender);
            //对退出取消复原
            Common.IOExitCanel = false;
        }

        //参数设置
        private void btnParam_Click(object sender, EventArgs e)
        {
            
            ShowForm(new FrmParamConfig());
            BtnClickColorSet((Button)sender);
            //对退出取消复原
            Common.IOExitCanel = false;
        }

        //报警
        private void btnAlarm_Click(object sender, EventArgs e)
        {
            
            ShowForm(new FrmAlarm());
            BtnClickColorSet((Button)sender);
            //对退出取消复原
            Common.IOExitCanel = false;
        }

        //趋势
        private void btnTrend_Click(object sender, EventArgs e)
        {
           
            ShowForm(new FrmTrend());
            BtnClickColorSet((Button)sender);
            //对退出取消复原
            Common.IOExitCanel = false;
        }

        //报表
        private void btnReport_Click(object sender, EventArgs e)
        {
            
            ShowForm(new FrmReport());
            BtnClickColorSet((Button)sender);
            //对退出取消复原
            Common.IOExitCanel = false;
        }

        //用户权限
        private void btnUser_Click(object sender, EventArgs e)
        {
           
            ShowForm(new FrmUserRight());
            BtnClickColorSet((Button)sender);
            //对退出取消复原
            Common.IOExitCanel = false;
        }


        /// <summary>
        /// 显示指定名称窗口
        /// </summary>
        /// <param name="showForm"></param>
        private void ShowForm(Form showForm)
        {
            foreach (Control item in rightPanel.Controls)
            {
                if(item.Name == showForm.Name)
                {
                    //如果包含有显示窗体则不进行任何操作
                    return;
                }
                if (item is Form)
                {
                    Form form = (Form)item;
                    form.Close();
                }
            }
            if (Common.IOExitCanel)
            {
                //如果取消关闭IO变量窗口则不进行显示其他窗口操作
                return;
            }
            showForm.TopLevel = false;
            showForm.FormBorderStyle = FormBorderStyle.None;
            showForm.Dock = DockStyle.Fill;
            showForm.Parent = rightPanel;
            showForm.Show();
        }

        /// <summary>
        /// 点击按钮背景色设置
        /// </summary>
        /// <param name="clickBtn"></param>
        private void BtnClickColorSet(Button clickBtn)
        {
            if (Common.IOExitCanel) return;
            foreach (Control c in leftPanel.Controls)
            {
                if (c is Button)
                {
                    c.BackColor = Color.LightBlue;
                }
            }
            clickBtn.BackColor = Color.MediumSlateBlue;
        }

        private void FrmHWConfig_Load(object sender, EventArgs e)
        {
            btnIO_Click(this.btnIO, null);
        }
    }
}
