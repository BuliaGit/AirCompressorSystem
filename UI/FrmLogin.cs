using DAL;
using DAL.Helper;
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
    public partial class FrmLogin : Form
    {
        AdminDAL adminDAL = new AdminDAL();
        public FrmLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登录按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //是否匿名登录
            if (ckBoxNoName.Checked)
            {
                this.DialogResult = DialogResult.OK;
                Program.currentAdmin.LoginName = "None";
            }
            else//用户登录
            {
                //数据验证
                if (textLgName.CheckEmpty())
                {
                    this.textLgName.Focus();
                    return;
                }
                if (textLgPwd.CheckEmpty())
                {
                    this.textLgPwd.Focus();
                    return;
                }
                if (!textLgName.CheckRegex(@"^[1-9]\d*$", "用户名不是正整数！"))
                {
                    this.textLgName.Focus();
                    return;
                }
                //登录验证
                SysAdmins objAdmins = new SysAdmins()
                {
                    LoginId = Convert.ToInt32(textLgName.Text.Trim()),
                    LoginPwd = textLgPwd.Text.Trim()
                };
                try
                {
                    objAdmins = adminDAL.AdminLogin(objAdmins);
                    if (objAdmins == null)
                    {
                        Program.currentAdmin = objAdmins;
                        MessageBox.Show("用户名或密码错误!");
                    }
                    else
                    {
                        //登录成功
                        this.DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        /// <summary>
        /// 退出按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        #region 登录回车事件
        private void textLgName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogin_Click(null, null);
            }

        }

        private void textLgPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogin_Click(null, null);
            }
        }
        #endregion
    }
}
