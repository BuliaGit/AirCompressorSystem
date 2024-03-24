using System;
using System.Collections.Generic;
using System.Text;

namespace DataType
{
    public static class Int
    {

        #region 将字节数组转换成16位整型
        public static Int16 FromByteArray(byte[] b)
        {
            short s = 0;
            short s0 = (short)(b[0] & 0xff);// 最低位 
            short s1 = (short)(b[1] & 0xff);
            s1 <<= 8;
            s = (short)(s0 | s1);
            return s;
        }

        #endregion

        #region 将2个字节转换成16位整型
        public static Int16 FromBytes(byte LoVal, byte HiVal)
        {
            return (Int16)(HiVal * 256 + LoVal);
        }
        #endregion

        #region 将16位整型转换成字节数组
        public static byte[] ToByteArray(Int16 value)
        {
            byte[] bytes = new byte[2];
            int x = 2;
            long valLong = (long)((Int16)value);
            for (int cnt = 0; cnt < x; cnt++)
            {
                Int64 x1 = (Int64)Math.Pow(256, (cnt));

                Int64 x3 = (Int64)(valLong / x1);
                bytes[x - cnt - 1] = (byte)(x3 & 255);
                valLong -= bytes[x - cnt - 1] * x1;
            }
            return bytes;
        }

        public static byte[] ToByteArray(Int16[] value)
        {
            ByteArray arr = new ByteArray();
            foreach (Int16 val in value)
                arr.Add(ToByteArray(val));
            return arr.array;
        }
        #endregion

        #region 将字节数组转换成16位整型数组
        public static Int16[] ToArray(byte[] bytes)
        {
            Int16[] values = new Int16[bytes.Length / 2];

            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 2; cnt++)
                values[cnt] = FromByteArray(new byte[] { bytes[counter++], bytes[counter++] });

            return values;
        }
        #endregion

        #region 将32位整型转换成16位整型
        public static Int16 CWord(int value)
        {
            if (value > 32767)
            {
                value -= 32768;
                value = 32768 - value;
                value *= -1;
            }
            return (short)value;
        }
        #endregion
    }
}
