
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace UI
{
    /// <summary>
    /// 通讯工具类
    /// </summary>
    public class CommHelper
    {
        public Thread thread;

        //起始地址
        int StartAddress = 0;
        //错误次数
        int ErrorCount = 0;


        public CommHelper()
        {
            thread = new Thread(Communication);
            thread.IsBackground = true;
        }

        /// <summary>
        /// 实时通讯读取数据并分配
        /// </summary>
        public void Communication()
        {
            while (true)
            {
                if (!Common.isWriting)//未在写数据就读取数据
                {
                    foreach (StoreAreaEntity storeItem in Common.storeAreaList.ToArray())
                    {
                        int count = 0;
                        List<byte> byteList = null;
                        //根据存储区域类型,从开始地址到长度或分批次读取一串字节数据，进而进行解析数据并分配
                        switch (storeItem.StoreType)
                        {
                            case "01 Coil Status(0x)":
                                byteList = new List<byte>();
                                //如果长度过大，分批次去读（一批长度暂为100）
                                if (storeItem.Length > 100)
                                {
                                    StartAddress = storeItem.StartReg;
                                    //读取次数
                                    count = storeItem.Length / 100;
                                    for (int i = 0; i <= count; i++)
                                    {
                                        //本次读取长度
                                        int readLength = i == count ? storeItem.Length - 100 * i : 100;
                                        //读输出线圈
                                        byte[] res = Common.objMod.ReadOutputStatus(Common.address, StartAddress + 100 * i, readLength);
                                        if (res != null)//读取成功
                                        {
                                            ErrorCount = 0;
                                            byteList.AddRange(res);
                                        }
                                        else//读取失败
                                        {
                                            ErrorCount += 1;
                                        }
                                    }
                                }
                                else//长度小于等于100
                                {
                                    byte[] res = Common.objMod.ReadOutputStatus(Common.address, StartAddress, storeItem.Length);
                                    if (res != null)//读取成功
                                    {
                                        ErrorCount = 0;
                                        byteList.AddRange(res);
                                    }
                                    else//读取失败
                                    {
                                        ErrorCount += 1;
                                    }
                                }
                                //解析数据
                                //根据存储区域长度得出线圈数量
                                int coilCount = storeItem.Length % 8 == 0 ? storeItem.Length / 8 : storeItem.Length / 8 + 1;
                                if (byteList.Count == coilCount)
                                {
                                    AnalyseData_0x(byteList);
                                }
                                break;
                            case "03 Holding Register(4x)":
                                byteList = new List<byte>();
                                //如果长度过大，分批次去读（一批长度暂为100）
                                if (storeItem.Length > 100)
                                {
                                    StartAddress = storeItem.StartReg;
                                    //读取次数
                                    count = storeItem.Length / 100;
                                    for (int i = 0; i <= count; i++)
                                    {
                                        //本次读取长度
                                        int readLength = i == count ? storeItem.Length - 100 * i : 100;
                                        //读输出线圈
                                        byte[] res = Common.objMod.ReadKeepReg(Common.address, StartAddress + 100 * i, readLength);
                                        if (res != null)//读取成功
                                        {
                                            ErrorCount = 0;
                                            byteList.AddRange(res);
                                        }
                                        else//读取失败
                                        {
                                            ErrorCount += 1;
                                        }
                                    }
                                }
                                else//长度小于等于100
                                {
                                    byte[] res = Common.objMod.ReadKeepReg(Common.address, StartAddress, storeItem.Length);
                                    if (res != null)//读取成功
                                    {
                                        ErrorCount = 0;
                                        byteList.AddRange(res);
                                    }
                                    else//读取失败
                                    {
                                        ErrorCount += 1;
                                    }
                                }
                                //解析数据
                                //根据存储区域长度得出线圈数量
                                if (byteList.Count == storeItem.Length * 2)
                                {
                                    AnalyseData_4x(byteList);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 解析0x区域数据并分配
        /// </summary>
        /// <param name="byteList"></param>
        private void AnalyseData_0x(List<Byte> byteList)
        {
            if (byteList != null && byteList.Count > 0)
            {
                foreach (ModbusVar item in Common.modVarList_0x)
                {
                    //获取当前modbus变量地址在读取的字节集合中的索引，以便于分配数据
                    int totalIndex = int.Parse(item.Address) - StartAddress;
                    //字节
                    int byteIndex = totalIndex / 8;
                    //位
                    int bitIndex = totalIndex % 8;
                    switch (item.DataType)
                    {
                        case "Bool":
                            string byteStr = (Convert.ToInt32(Convert.ToString(Convert.ToInt32(byteList[byteIndex]), 2))).ToString("0#######");
                            Common.valueDic[item.VarName] = byteStr.Substring(7 - bitIndex, 1);
                            break;
                        default:
                            break;
                    }
                }
            }
        }


        /// <summary>
        /// 解析4x区域数据并分配
        /// </summary>
        /// <param name="byteList"></param>
        private void AnalyseData_4x(List<Byte> byteList)
        {
            int startByte;
            byte[] res = null;
            if (byteList != null && byteList.Count > 0)
            {
                foreach (ModbusVar item in Common.modVarList_4x)
                {
                    switch (item.DataType)
                    {
                        case "Float":
                            startByte = int.Parse(item.Address) * 2;
                            res = new byte[4] { byteList[startByte], byteList[startByte + 1], byteList[startByte + 2], byteList[startByte + 3] };
                            Common.valueDic[item.VarName] = (Convert.ToDouble(DataType.Double.BytetoFloatByPoint(res))).ToString("f1");
                            break;
                        case "Unsigned":
                            startByte = int.Parse(item.Address) * 2;
                            res = new byte[2] { byteList[startByte], byteList[startByte + 1] };
                            Common.valueDic[item.VarName] = DataType.Int.FromByteArray(res).ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
