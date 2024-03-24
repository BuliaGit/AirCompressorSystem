using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Helper
{
    public class Modbus
    {
        #region 相关属性
        //串口对象
        private SerialPort serialPort;

        public SerialPort SerialPortObject
        {
            get { return serialPort; }
        }
        //校验高低位
        private byte ucCRCHi = 0xFF;
        private byte ucCRCLo = 0xFF;

        byte[] receiveBytes = new byte[1024];//定义接收报文字节数组
        byte receiveByte;//当前接收字节
        int receiveByteCount = 0;//接收数量
        int coilLen; //线圈长度
        public int regCount;//寄存器数量
        public int devAddress;//设备地址
        public string backMsg;//返回处理后报文数据

        #endregion

        public Modbus()
        {
            serialPort = new SerialPort();
        }

        /// <summary>
        /// 打开串口方法【9600 N 8 1】
        /// </summary>
        /// <param name="iBaudRate">波特率</param>
        /// <param name="iPortNo">端口号</param>
        /// <param name="iDataBits">数据位</param>
        /// <param name="iParity">校验位</param>
        /// <param name="iStopBits">停止位</param>
        /// <returns></returns>
        public bool OpenOrClosePort(string portName, int baudRate, int dataBits, Parity parity, StopBits stopBits)
        {
            try
            {
                //串口如果打开则关闭
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                //设置属性
                serialPort.PortName = portName;//只有端口没有打开时才能设置名称
                serialPort.BaudRate = baudRate;
                serialPort.DataBits = dataBits;
                serialPort.Parity = parity;
                serialPort.StopBits = stopBits;
                serialPort.ReceivedBytesThreshold= 1;
                serialPort.DataReceived += SerialPort_DataReceived;
                serialPort.Open();
                return serialPort.IsOpen;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ClosePort()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            return !serialPort.IsOpen;
        }


        /// <summary>
        /// 接收数据事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //循环读取到字节数组
            //01 03 14 03 DC 03 D9 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 77 38(十六进制)
            while (serialPort.BytesToRead > 0)
            {
                receiveByte = (byte)serialPort.ReadByte();//(转成十进制字节)
                receiveBytes[receiveByteCount] = receiveByte;
                receiveByteCount += 1;
                if (receiveByteCount >= 1024)
                {
                    receiveByteCount = 0;
                    //清除输入缓存区
                    serialPort.DiscardInBuffer();
                    return;
                }
            }
            //解析符合条件的报文
            //读取保持型寄存器 功能码0x03
            if (receiveBytes[0] == (byte)devAddress && receiveBytes[1] == 0x03 && receiveByteCount >= regCount * 2 + 5)
            {
                backMsg = "";//清空上次报文数据，以获取最新的报文
                for (int i = 0; i < regCount * 2 + 5; i++)
                {
                    backMsg = backMsg + " " + receiveBytes[i].ToString("X2");//十进制字节数组转成十六进制字符串
                }
                serialPort.DiscardInBuffer();
            }
            //预置单保存寄存器 功能码0x06
            if (receiveBytes[0] == (byte)devAddress && receiveBytes[1] == 0x06 && receiveByteCount >= 8)
            {
                backMsg = "";//清空上次报文数据，以获取最新的报文
                for (int i = 0; i < 8; i++)
                {
                    backMsg = backMsg + " " + receiveBytes[i].ToString("X2");//十进制字节数组转成十六进制字符串
                }
                serialPort.DiscardInBuffer();
            }
            //预置双字保存寄存器 功能码0x10
            if (receiveBytes[0] == (byte)devAddress && receiveBytes[1] == 0x10 && receiveByteCount >= 8)
            {
                backMsg = "";//清空上次报文数据，以获取最新的报文
                for (int i = 0; i < 8; i++)
                {
                    backMsg = backMsg + " " + receiveBytes[i].ToString("X2");//十进制字节数组转成十六进制字符串
                }
                serialPort.DiscardInBuffer();
            }
            //读取输出状态（线圈）功能码0x01
            if (receiveBytes[0] == (byte)devAddress && receiveBytes[1] == 0x01 && receiveByteCount >= coilLen + 5)
            {
                backMsg = "";//清空上次报文数据，以获取最新的报文
                for (int i = 0; i < coilLen + 5; i++)
                {
                    backMsg = backMsg + " " + receiveBytes[i].ToString("X2");//十进制字节数组转成十六进制字符串
                }
                serialPort.DiscardInBuffer();
            }
            //读取输入状态（线圈）功能码0x02
            if (receiveBytes[0] == (byte)devAddress && receiveBytes[1] == 0x02 && receiveByteCount >= coilLen + 5)
            {
                backMsg = "";//清空上次报文数据，以获取最新的报文
                for (int i = 0; i < coilLen + 5; i++)
                {
                    backMsg = backMsg + " " + receiveBytes[i].ToString("X2");//十进制字节数组转成十六进制字符串
                }
                serialPort.DiscardInBuffer();
            }
            //强置单线圈 功能码0x05
            if (receiveBytes[0] == (byte)devAddress && receiveBytes[1] == 0x05 && receiveByteCount >= 8)
            {
                backMsg = "";//清空上次报文数据，以获取最新的报文
                for (int i = 0; i < 8; i++)
                {
                    backMsg = backMsg + " " + receiveBytes[i].ToString("X2");//十进制字节数组转成十六进制字符串
                }
                serialPort.DiscardInBuffer();
            }
        }

        //---------------------------------------------------------------------
        /// <summary>
        /// 读取保存型寄存器 功能码0x03
        /// </summary>
        /// <param name="devAddress"></param>
        /// <param name="regAddress"></param>
        /// <param name="regCount"></param>
        /// <returns></returns>
        public byte[] ReadKeepReg(int devAddress, int regAddress, int regCount)//地址  寄存器地址  寄存器数量
        {
            this.devAddress = devAddress;
            this.regCount = regCount;
            //【1】拼接报文
            byte[] sendCommand = new byte[8];
            sendCommand[0] = (byte)devAddress;
            sendCommand[1] = 0x03;
            sendCommand[2] = (byte)((regAddress - regAddress % 256) / 256);
            sendCommand[3] = (byte)(regAddress % 256);
            sendCommand[4] = (byte)((regCount - regCount % 256) / 256);
            sendCommand[5] = (byte)(regCount % 256);
            Crc16(sendCommand, 6);
            sendCommand[6] = ucCRCLo;
            sendCommand[7] = ucCRCHi;

            //【2】发送报文
            serialPort.Write(sendCommand, 0, 8);

            //【3】解析报文
            receiveByteCount = 0;
            Thread.Sleep(300);
            //截取掉地址、功能码、字节数、校验码共5位，只取数据位
            return HexStringToByteArray(backMsg,3,2);// 十六进制字符串转成十六进制字节数组
        }

        /// <summary>
        /// 预置单字保存型寄存器 功能码0x06
        /// </summary>
        /// <param name="devAddress"></param>
        /// <param name="regAddress"></param>
        /// <param name="setValue"></param>
        /// <returns></returns>
        public bool PreSetKeepReg(int devAddress, int regAddress, int setValue)
        {
            bool isEqual = true;
            byte[] resByte;
            byte[] sendCommand = new byte[8];
            this.devAddress = devAddress;
            //【拼接报文】
            sendCommand[0] = (byte)devAddress;
            sendCommand[1] = 0x06;
            sendCommand[2] = (byte)((regAddress - regAddress % 256) / 256);
            sendCommand[3] = (byte)(regAddress % 256);
            sendCommand[4] = (byte)((setValue - setValue % 256) / 256);
            sendCommand[5] = (byte)(setValue % 256);
            Crc16(sendCommand, 6);
            sendCommand[6] = ucCRCLo;
            sendCommand[7] = ucCRCHi;
            //【2】发送报文
            serialPort.Write(sendCommand, 0, 8);
            receiveByteCount = 0;
            Thread.Sleep(100);
            //【3】解析报文
            resByte = HexStringToByteArray(backMsg);// 十六进制字符串转成十六进制字节数组

            return ByteArrayEqual(sendCommand, resByte);
        }

        /// <summary>
        /// 预置双字保存型寄存器 功能码0x10
        /// </summary>
        /// <param name="devAddress"></param>
        /// <param name="regAddress"></param>
        /// <param name="setValue"></param>
        /// <returns></returns>
        public bool PreSetFloatReg(int devAddress, int regAddress, float setValue)
        {
            byte[] resByte;
            byte[] sendCommand = new byte[13];
            this.devAddress = devAddress;
            //【拼接报文】
            sendCommand[0] = (byte)devAddress;
            sendCommand[1] = 0x10;
            sendCommand[2] = (byte)((regAddress - regAddress % 256) / 256);
            sendCommand[3] = (byte)(regAddress % 256);
            sendCommand[4] = 0x00;
            sendCommand[5] = 0x02;
            sendCommand[6] = 0x04;
            byte[] byteSetValue = BitConverter.GetBytes(setValue);
            sendCommand[7] = byteSetValue[3];
            sendCommand[8] = byteSetValue[2];
            sendCommand[9] = byteSetValue[1];
            sendCommand[10] = byteSetValue[0];
            Crc16(sendCommand, 11);
            sendCommand[11] = ucCRCLo;
            sendCommand[12] = ucCRCHi;
            //【2】发送报文
            serialPort.Write(sendCommand, 0, 13);
            receiveByteCount = 0;
            Thread.Sleep(100);
            //【3】解析报文
            resByte = HexStringToByteArray(backMsg);// 十六进制字符串转成十六进制字节数组
            byte[] byteTemp = GetByteArray(resByte, 0, 6);
            byte[] byteCrc = GetByteArray(resByte, 6, 2);
            //判断应答报文前6位和校验码是否一致
            Crc16(byteTemp, 6);
            if (!ByteArrayEqual(GetByteArray(sendCommand, 0, 6), byteTemp)) return false;
            if (byteCrc[0] != ucCRCLo || byteCrc[1] != ucCRCHi) return false;
            return true;
        }

        //---------------------------------------------------------------------------------
        /// <summary>
        /// 读取输出状态 功能码0x01
        /// </summary>
        /// <param name="devAddress"></param>
        /// <param name="address"></param>
        /// <param name="coilCount"></param>
        /// <returns></returns>
        public byte[] ReadOutputStatus(int devAddress, int address, int coilCount)
        {
            byte[] sendCommand = new byte[8];
            this.devAddress = devAddress;
            if (coilCount % 8 == 0)
            {
                coilLen = coilCount / 8;
            }
            else
            {
                coilLen = coilCount / 8 + 1;
            }
            //【1】拼接报文
            sendCommand[0] = (byte)devAddress;
            sendCommand[1] = 0x01;
            sendCommand[2] = (byte)((address - address % 256) / 256);
            sendCommand[3] = (byte)(address % 256);
            sendCommand[4] = (byte)((coilCount - coilCount % 256) / 256);
            sendCommand[5] = (byte)(coilCount % 256);
            Crc16(sendCommand, 6);
            sendCommand[6] = ucCRCLo;
            sendCommand[7] = ucCRCHi;

            //【2】发送报文
            serialPort.Write(sendCommand, 0, 8);

            //【3】解析报文
            receiveByteCount = 0;
            Thread.Sleep(100);
            return HexStringToByteArray(backMsg, 3, 2);
        }

        /// <summary>
        /// 读取输入状态 功能码0x02
        /// </summary>
        /// <param name="devAddress"></param>
        /// <param name="address"></param>
        /// <param name="coilCount"></param>
        /// <returns></returns>
        public byte[] ReadInputStatus(int devAddress, int address, int coilCount)
        {
            byte[] sendCommand = new byte[8];
            this.devAddress = devAddress;
            if (coilCount % 8 == 0)
            {
                coilLen = coilCount / 8;
            }
            else
            {
                coilLen = coilCount / 8 + 1;
            }
            //【1】拼接报文
            sendCommand[0] = (byte)devAddress;
            sendCommand[1] = 0x02;
            sendCommand[2] = (byte)((address - address % 256) / 256);
            sendCommand[3] = (byte)(address % 256);
            sendCommand[4] = (byte)((coilCount - coilCount % 256) / 256);
            sendCommand[5] = (byte)(coilCount % 256);
            Crc16(sendCommand, 6);
            sendCommand[6] = ucCRCLo;
            sendCommand[7] = ucCRCHi;

            //【2】发送报文
            serialPort.Write(sendCommand, 0, 8);

            //【3】解析报文
            receiveByteCount = 0;
            Thread.Sleep(100);
            return HexStringToByteArray(backMsg, 3, 2);
        }

        //-----------------------------------------------------------------------------------------

        /// <summary>
        /// 强置单线圈 功能码0x05
        /// </summary>
        /// <param name="devAddress"></param>
        /// <param name="address"></param>
        /// <param name="setValue"></param>
        /// <returns></returns>
        public bool ForceCoil(int devAddress, int address, bool setValue)
        {
            this.devAddress = devAddress;
            byte[] resBytes;
            //【1】拼接报文
            byte[] sendCommand = new byte[8];
            sendCommand[0] = (byte)devAddress;
            sendCommand[1] = 0x05;
            sendCommand[2] = (byte)((address - address % 256) / 256);
            sendCommand[3] = (byte)(address % 256);
            if (setValue)
            {
                sendCommand[4] = 0xFF;
            }
            else
            {
                sendCommand[4] = 0x00;
            }
            sendCommand[5] = 0x00;
            Crc16(sendCommand, 6);
            sendCommand[6] = ucCRCLo;
            sendCommand[7] = ucCRCHi;
            //【2】发送报文
            serialPort.Write(sendCommand, 0, 8);
            //【3】判断报文
            receiveByteCount = 0;
            Thread.Sleep(100);
            resBytes = HexStringToByteArray(backMsg);
            return ByteArrayEqual(sendCommand, resBytes);
        }

        //-------------------------------------------------------------------------------------
        /// <summary>
        /// 十六进制字符串转成十六进制字节数组
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private byte[] HexStringToByteArray(string s, int frontRemove = 0, int backRemove = 0)
        {
            byte[] res = null;
            if (s != null && s.Length > frontRemove + backRemove)
            {
                string[] str = s.Trim().Split(' ');
                string[] result = new string[str.Length - frontRemove - backRemove];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = str[i + frontRemove];
                }
                res = new byte[result.Length];
                for (int i = 0; i < result.Length; i++)
                {
                    res[i] = Convert.ToByte(result[i], 16);
                }
            }
            return res;
        }

        #region  CRC校验
        private static readonly byte[] aucCRCHi = {
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
             0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40
         };
        private static readonly byte[] aucCRCLo = {
             0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06, 0x07, 0xC7,
             0x05, 0xC5, 0xC4, 0x04, 0xCC, 0x0C, 0x0D, 0xCD, 0x0F, 0xCF, 0xCE, 0x0E,
             0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09, 0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9,
             0x1B, 0xDB, 0xDA, 0x1A, 0x1E, 0xDE, 0xDF, 0x1F, 0xDD, 0x1D, 0x1C, 0xDC,
             0x14, 0xD4, 0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3,
             0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3, 0xF2, 0x32,
             0x36, 0xF6, 0xF7, 0x37, 0xF5, 0x35, 0x34, 0xF4, 0x3C, 0xFC, 0xFD, 0x3D,
             0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A, 0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38,
             0x28, 0xE8, 0xE9, 0x29, 0xEB, 0x2B, 0x2A, 0xEA, 0xEE, 0x2E, 0x2F, 0xEF,
             0x2D, 0xED, 0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26,
             0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60, 0x61, 0xA1,
             0x63, 0xA3, 0xA2, 0x62, 0x66, 0xA6, 0xA7, 0x67, 0xA5, 0x65, 0x64, 0xA4,
             0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F, 0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB,
             0x69, 0xA9, 0xA8, 0x68, 0x78, 0xB8, 0xB9, 0x79, 0xBB, 0x7B, 0x7A, 0xBA,
             0xBE, 0x7E, 0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5,
             0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71, 0x70, 0xB0,
             0x50, 0x90, 0x91, 0x51, 0x93, 0x53, 0x52, 0x92, 0x96, 0x56, 0x57, 0x97,
             0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C, 0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E,
             0x5A, 0x9A, 0x9B, 0x5B, 0x99, 0x59, 0x58, 0x98, 0x88, 0x48, 0x49, 0x89,
             0x4B, 0x8B, 0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C,
             0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42, 0x43, 0x83,
             0x41, 0x81, 0x80, 0x40
         };
        private void Crc16(byte[] pucFrame, int usLen)
        {
            int i = 0;
            //重置保证校验位正确
            ucCRCHi = 0xFF;
            ucCRCLo = 0xFF;
            ushort iIndex = 0x0000;
            while (usLen-- > 0)
            {
                iIndex = (ushort)(ucCRCLo ^ pucFrame[i++]);
                ucCRCLo = (byte)(ucCRCHi ^ aucCRCHi[iIndex]);
                ucCRCHi = aucCRCLo[iIndex];
            }

        }

        #endregion

        /// <summary>
        /// 判断两个字节数组是否相等
        /// </summary>
        /// <param name="byteFirst"></param>
        /// <param name="byteSecond"></param>
        /// <returns></returns>
        private bool ByteArrayEqual(byte[] byteFirst, byte[] byteSecond)
        {
            if (byteFirst.Length != byteSecond.Length) return false;
            if (byteFirst == null || byteSecond == null) return false;
            for (int i = 0; i < byteFirst.Length; i++)
            {
                if (!byteFirst[i].Equals(byteSecond[i]))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 截取字节数组
        /// </summary>
        /// <param name="byteArr"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private byte[] GetByteArray(byte[] byteArr, int start, int length)
        {
            byte[] res = new byte[length];
            if (byteArr != null && byteArr.Length > length)
            {
                for (int i = 0; i < length; i++)
                {
                    res[i] = byteArr[i + start];
                }
            }
            return res;
        }
    }

}

