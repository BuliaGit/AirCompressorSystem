using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 归档数据实体类
    /// </summary>
    public class FilingData
    {
        //插入时间
        public DateTime InsertTime { get; set; }
        //变量名
        public string VarName { get; set; }
        //值
        public string Value { get; set; }
        //注释
        public string Remark { get; set; }
    }
}
