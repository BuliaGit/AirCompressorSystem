using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ModbusVar
    {
        //变量名
        public string VarName { get; set; }
        //存储区域
        public string StoreArea { get; set; }
        //地址
        public string Address { get; set; }
        //数据类型
        public string DataType { get; set; }
        //是否归档
        public string IsFiling { get; set; }
        //是否报警
        public string IsAlarm { get; set; }
        //是否参与报表
        public string IsReport { get; set; }
        //注释与说明
        public string Note { get; set; }
        //绝对地址
        private string absoluteAddress;

        public string AbsoluteAddress
        {
            get
            {
                int store = 0;
                switch (StoreArea)
                {
                    case "01 Coil Status(0x)":
                        store = 0;break;
                    case "02 Input Status(1x)":
                        store = 1;break;
                    case "03 Holding Register(4x)":
                        store = 4;break;
                    case "04 Input Registers(3x)":
                        store = 3;break;
                    default:
                        store = 4;
                        break;
                }
                return (store * 10000 + Convert.ToInt32(Address)).ToString();
            }
            set { absoluteAddress = value; }
        }


    }
}
