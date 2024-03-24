using DAL.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReportDAL
    {
        public DataTable Query(string content,string condition)
        {
            string sql = $"select {content} from ReportData where 1=1 {condition}";
            return SQLHelper.GetDataSet(sql).Tables[0];
        }
    }
}
