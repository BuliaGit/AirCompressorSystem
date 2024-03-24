using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Alarm
    {
        //报警类型
        public string AlarmType { get; set; }
        //报警数值
        public float AlarmValue { get; set; }
        //优先级
        public int Priority { get; set; }
        //报警注释及说明
        public string Note { get; set; }
    }
}
