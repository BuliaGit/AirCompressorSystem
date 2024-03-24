using DAL.Helper;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdminDAL
    {
        /// <summary>
        /// 用户登录判断
        /// </summary>
        /// <param name="sysAdmins"></param>
        /// <returns></returns>
        public SysAdmins AdminLogin(SysAdmins sysAdmins)
        {
            string sql = $"Select LoginName,Role from SysAdmins where LoginId={sysAdmins.LoginId} " +
                $"and LoginPwd={sysAdmins.LoginPwd}";
            DataSet ds = SQLHelper.GetDataSet(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                sysAdmins.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                sysAdmins.Role = Convert.ToInt32(ds.Tables[0].Rows[0]["Role"]);
                return sysAdmins;
            }
            else
            {
                return null;
            }
        }
    }
}
