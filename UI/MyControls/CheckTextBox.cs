using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.MyControls
{
    public partial class CheckTextBox : TextBox
    {
        public CheckTextBox()
        {
            InitializeComponent();
        }

        public CheckTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// 检查当前控件文本是否为空
        /// </summary>
        /// <returns></returns>
        public bool CheckEmpty()
        {
            if (Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(this, "此项不能为空!");
                return true;
            }
            else
            {
                errorProvider1.SetError(this, "");
                return false;
            }
        }

        /// <summary>
        /// 使用正则表达式验证文本
        /// </summary>
        /// <param name="regex"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public bool CheckRegex(string regex, string errMsg)
        {
            if (CheckEmpty()) return false;
            //正则表达式验证
            Regex objRegex = new Regex(regex, RegexOptions.IgnoreCase);
            if (!objRegex.IsMatch(Text.Trim()))
            {
                errorProvider1.SetError(this, errMsg);
                return false;
            }
            else
            {
                errorProvider1.SetError(this, string.Empty);
                return true;
            }
        }
    }
}
