using Entity;
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
    public partial class FrmReportConfig : Form
    {
        public FrmReportConfig()
        {
            InitializeComponent();
        }
        //已选择报表变量名
        public List<string> selVarNameList = new List<string>();
        //UI已选择列表（Note）
        List<string> SelList = new List<string>();
        //UI未选择列表（Note）
        List<string> UnselList = new List<string>();
        Dictionary<string,string> NoteVarNameDic = new Dictionary<string,string>();

        private void FrmReportConfig_Load(object sender, EventArgs e)
        {
            foreach (ModbusVar item in Common.reportVarList)
            {
                NoteVarNameDic.Add(item.Note, item.VarName);
                UnselList.Add(item.Note);
            }
            UpdateData();
        }

        private void UpdateData()
        {
            this.selectList.DataSource = null;
            this.unSelectList.DataSource = null;
            this.selectList.DataSource = this.SelList;
            this.unSelectList.DataSource = this.UnselList;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (this.unSelectList.Items.Count == 0 || this.unSelectList.SelectedItem == null)
            {
                return;
            }
            string str = this.unSelectList.SelectedItem.ToString();
            this.UnselList.Remove(str);
            this.SelList.Add(str);
            UpdateData();
        }

        private void btn_AddAll_Click(object sender, EventArgs e)
        {
            foreach (string item in this.UnselList)
            {
                this.SelList.Add(item);
            }
            this.UnselList.Clear();
            UpdateData();
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (this.selectList.Items.Count == 0 || this.selectList.SelectedItem == null)
                return;
            string str = this.selectList.SelectedValue.ToString();
            this.SelList.Remove(str);
            this.UnselList.Add(str);
            UpdateData();
        }

        private void btn_DelAll_Click(object sender, EventArgs e)
        {
            foreach (string item in this.SelList)
            {
                this.UnselList.Add(item);
            }
            this.SelList.Clear();
            UpdateData();
        }

        private void btn_Sure_Click(object sender, EventArgs e)
        {
            if (this.SelList.Count == 0)
            {
                MessageBox.Show("至少要选择一个参数!");
                return;
            }
            foreach (string item in SelList)
            {
                if (NoteVarNameDic.ContainsKey(item))
                {
                    selVarNameList.Add(NoteVarNameDic[item]);
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult |= DialogResult.Cancel;
        }
    }
}
