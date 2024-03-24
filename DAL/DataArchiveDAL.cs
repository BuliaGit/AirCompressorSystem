using DAL.Helper;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DAL
{
    public class DataArchiveDAL
    {
        /// <summary>
        /// 数据库插入多条归档数据
        /// </summary>
        public void InsertActualData(List<FilingData> filingDataList)
        {
            List<string> sqlList = new List<string>();
            foreach (FilingData item in filingDataList)
            {
                string sql = $"Insert into ActualData(InsertTime,VarName,Value,Remark) values('{item.InsertTime}','{item.VarName}','{item.Value}','{item.Remark}')";
                sqlList.Add(sql);
            }
            SQLHelper.UpdateByTran(sqlList);
        }
    }
}
