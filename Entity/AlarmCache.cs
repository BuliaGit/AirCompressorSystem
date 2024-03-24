using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AlarmCache
    {
        public AlarmCache(string insertTime,string varName,string alarmState,string alarmType,float value,float alarmValue,string op,string note,int priority)
        {
            this.InsertTime = DateTime.Parse(insertTime);
            this.VarName = varName;
            this.AlarmState = alarmState;
            this.AlarmType = alarmType;
            this.AlarmValue = alarmValue;
            this.Operator = op;
            this.Note = note;
            this.Value = value;
            this.Priority = priority;
        }
        //报警插入时间
        public DateTime InsertTime { get; set; }
        //变量名称
        public string VarName { get; set; } 
        public int Priority { get; set; }
        //报警状态
        public string AlarmState { get; set; }
        //报警类型
        public string AlarmType { get; set; }
        //报警实时值
        public float Value { get; set; }
        //报警值
        public float AlarmValue { get; set; }
        //操作人员
        public string Operator { get; set; }
        //注释
        public string Note { get; set; }
    }
}
