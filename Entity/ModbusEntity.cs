using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ModbusEntity
    {
        //端口号
        public string Port { get; set; }
        //波特率
        public int Paud { get; set; }
        //数据位
        public int DataBit { get; set; }
        //校验位
        public Parity ModParity { get; set; }
        //停止位
        public StopBits ModStopBit { get; set; }
    }
}
