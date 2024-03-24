using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class StoreAreaEntity
    {
        //存储区域类型
        public string StoreType { get; set; }
        //开始地址
        public int StartReg { get; set; }
        //长度
        public int Length { get; set; }
    }
}
