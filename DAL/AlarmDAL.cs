using DAL.Helper;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AlarmDAL
    {
        public void InsertAlarm(AlarmCache objAlarm)
        {
            string sql = $"Insert into AlarmData(InsertTime,VarName,AlarmState,Priority,AlarmType,Value,AlarmValue,Operator,Note) " +
               $"values('{objAlarm.InsertTime}','{objAlarm.VarName}','{objAlarm.AlarmState}','{objAlarm.Priority}','{objAlarm.AlarmType}','{objAlarm.Value}','{objAlarm.AlarmValue}','{objAlarm.Operator}','{objAlarm.Note}')";
            SQLHelper.Update(sql);
        }
    }
}
