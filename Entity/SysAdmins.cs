using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Serializable]
    public class SysAdmins
    {
        public SysAdmins() { }
        public SysAdmins(int Id, string name, string pwd, int role)
        {
            this.LoginId = Id;
            this.LoginName = name;
            this.LoginPwd = pwd;
            this.Role = role;
        }
        //登录ID
        public int LoginId { get; set; }
        //登录名称
        public string LoginName { get; set; }
        //登录密码
        public string LoginPwd { get; set; }
        //角色
        public int Role { get; set; }
    }
}
