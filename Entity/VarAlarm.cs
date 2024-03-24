using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class VarAlarm
    {
        //变量名称
        public string VarName { get; set; }
        //报警属性
        public List<Alarm> Alarms = new List<Alarm>();
    }
}
