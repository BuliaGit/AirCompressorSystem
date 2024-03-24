using Entity;
using Microsoft.Win32.SafeHandles;
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
using System.Xml;

namespace UI.HWConfigUI
{
    //硬件组态变量管理窗口
    public partial class FrmIOVarManage : Form
    {
        public FrmIOVarManage()
        {
            InitializeComponent();
            this.dgv_data.AutoGenerateColumns = false;
        }

        //Modbus变量集合
        private List<ModbusVar> varList;
        //报警变量集合
        private List<VarAlarm> alarmList;
        //是否提示保存
        private bool hintSave = false;

        /// <summary>
        /// 窗体加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIOVarManage_Load(object sender, EventArgs e)
        {
            //传递硬件组态变量和报警变量的引用
            this.varList = Common.modbusVarList;
            this.alarmList = Common.alarmList;
            UpdateDgv();
        }

        /// <summary>
        /// 弹出新建变量窗口并添加变量实例
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_New_Click(object sender, EventArgs e)
        {
            FrmNewVar frmNewVar = new FrmNewVar();
            DialogResult Result = frmNewVar.ShowDialog();
            if (Result == DialogResult.OK)
            {
                this.varList.Add(frmNewVar.var);
                if (frmNewVar.varAlarm != null) alarmList.Add(frmNewVar.varAlarm);
                hintSave = true;
                UpdateDgv();
            }
        }

        /// <summary>
        /// 保存modbus、报警、存储区域变量到XML文件中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            Common.SaveToXML();
            UpdateDgv();
            hintSave = false;
        }

        /// <summary>
        /// 修改变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Modify_Click(object sender, EventArgs e)
        {
            if(this.dgv_data.SelectedRows.Count > 0)
            {
                ModbusVar changeModVar = this.varList[this.dgv_data.CurrentRow.Index];
                VarAlarm changeAlarm = new VarAlarm();
                if (changeModVar.IsAlarm == "1")//有报警变量
                {
                    foreach (var item in alarmList)
                    {
                        if(item.VarName == changeModVar.VarName)
                        {
                            changeAlarm = item;
                        }
                    }
                }
                FrmChangeVar frmChangeVar = new FrmChangeVar(changeModVar, changeAlarm);
                DialogResult result = frmChangeVar.ShowDialog();//显示修改变量对话框
                if (result == DialogResult.OK)//点击修改变量后
                {
                    varList.Remove(changeModVar);
                    varList.Insert(this.dgv_data.CurrentRow.Index, frmChangeVar.changeModVar);
                    //varList.Add(frmChangeVar.changeModVar);
                    if (frmChangeVar.changeAlarm.VarName != null)
                    {
                        alarmList.Remove(changeAlarm);
                        if (frmChangeVar.changeAlarm.Alarms.Count > 0)
                        {
                            alarmList.Add(frmChangeVar.changeAlarm);
                        }
                        
                    }
                    //btn_Save_Click(null, null);//自动保存
                    hintSave = true;
                    UpdateDgv();
                }
            }
            else
            {
                MessageBox.Show("请选择要修改的变量！");
            }
        }

        /// <summary>
        /// 删除变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            
            if (this.dgv_data.SelectedRows.Count > 0)
            {
                int delIndex = this.dgv_data.CurrentRow.Index;
                DialogResult delResult = MessageBox.Show($"确定要删除变量:【{varList[delIndex].VarName}】吗?","删除变量",MessageBoxButtons.OKCancel);
                if (delResult==DialogResult.OK)
                {
                    varList.RemoveAt(delIndex);
                    var delAlarm = alarmList.FirstOrDefault(item => item.VarName == varList[delIndex].VarName);
                    alarmList.Remove(delAlarm);
                    UpdateDgv();
                    //btn_Save_Click(null, null);//自动保存
                    hintSave = true;
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的变量！");
            }
            
        }

        /// <summary>
        /// 根据全局变量集合更新变量列表
        /// </summary>
        private void UpdateDgv()
        {
            this.dgv_data.DataSource = null;
            this.dgv_data.DataSource = varList;
        }

        /// <summary>
        /// 行号样式设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_data_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewStyle.DgvRowPostPaint(this.dgv_data, e);
        }

        /// <summary>
        /// 窗体关闭时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIOVarManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hintSave)
            {
                DialogResult result = MessageBox.Show("是否保存修改内容？", "退出询问",MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)//保存
                {
                    btn_Save_Click(null, null);
                }
                if(result == DialogResult.No)//不保存
                {
                    //只需重新加载XML文件modbus变量和报警变量即可还原修改前的列表
                    Common.LoadModVarXML();
                    Common.LoadAlarmXML();
                }
                if(result == DialogResult.Cancel)//取消
                {
                    Common.IOExitCanel = true;
                    e.Cancel = true;
                }
            }
            
        }
    }
}
