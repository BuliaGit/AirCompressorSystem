using DAL.Helper;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace UI
{
    public static class Common
    {
        static Common()
        {
            InitCommon();
        }

        //从站地址
        public static int address = 0;

        //Modbus路径
        public static string modbusPath = Application.StartupPath + @"\ConfigFile\" + "MODBUS.ini";
        //创建Modbus变量路径
        public static string varModbusPath = Application.StartupPath + @"\ConfigFile\" + "Variable_Modbus.xml";
        //创建Modbus报警变量路径
        public static string varAlarmPath = Application.StartupPath + @"\ConfigFile\" + "VarAlarm_Modbus.xml";
        //存储区域路径 
        public static string storeAreaPath = Application.StartupPath + @"\ConfigFile\" + "StoreArea.xml";

        //ModbusEntity对象
        public static ModbusEntity objModbusEntity;

        //Modbus变量集合
        public static List<ModbusVar> modbusVarList;
        //各存储区域的变量列表
        public static List<ModbusVar> modVarList_0x = new List<ModbusVar>();
        public static List<ModbusVar> modVarList_1x = new List<ModbusVar>();
        public static List<ModbusVar> modVarList_4x = new List<ModbusVar>();
        public static List<ModbusVar> modVarList_3x = new List<ModbusVar>();
        //报警变量集合
        public static List<VarAlarm> alarmList;
        //存储区域集合
        public static List<StoreAreaEntity> storeAreaList;
        //字典集合
        public static Dictionary<string, string> valueDic = new Dictionary<string, string>();
        //归档变量集合
        public static List<ModbusVar> fileVarList = new List<ModbusVar>();
        //归档注释集合
        public static List<string> fileNameList = new List<string>();
        //数据报表变量集合
        public static List<ModbusVar> reportVarList = new List<ModbusVar>();
        //变量名地址字典集合
        public static Dictionary<string, string> addressList = new Dictionary<string, string>();

        //归档数据缓存集合
        public static List<List<FilingData>> filingCacheList = new List<List<FilingData>>();
        //归档缓存数量(10分钟)
        public static int cacheCount = 600;

        //变量名和注释的字典集合
        public static Dictionary<string,string> VarNameNoteDic = new Dictionary<string,string>();

        //定义报警缓冲大小
        public static int AlarmCacheCount = 60;
        //报警缓存集合
        public static List<AlarmCache> alarmCacheList = new List<AlarmCache>();

        //IO变量窗口退出时是否取消
        public static bool IOExitCanel = false;

        //创建Modbus工具类实例
        public static Modbus objMod = new Modbus();
        //通讯状态标志位
        public static bool portOpenStatus = false;
        //数据写入的标志位
        public static bool isWriting = false;
        //报警实时检测标志位
        public static bool isAlarmCheck = false;

        //报警更新事件
        public static event EventHandler AlarmUpdateHandler;

        /// <summary>
        /// 根据modbus变量初始化字典、归档集合、报表集合
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private static void InitCommon()
        {
            //加载文件初始化集合
            //Modbus配置信息
            GetModConfigInfo();
            //modbus变量
            LoadModVarXML();
            //报警变量
            LoadAlarmXML();
            //存储区域
            LoadStoreAreaXML();
            //其他字典、集合初始化
            foreach (var item in modbusVarList)
            {
                if (!valueDic.ContainsKey(item.VarName))
                {
                    valueDic.Add(item.VarName, "");
                }
                if (!addressList.ContainsKey(item.VarName))
                {
                    addressList.Add(item.VarName,item.Address);
                }
                if (item.IsFiling == "1")
                {
                    fileVarList.Add(item);
                    fileNameList.Add(item.Note);
                }
                if (item.IsReport == "1")
                {
                    reportVarList.Add(item);
                }
                if (!VarNameNoteDic.ContainsKey(item.VarName))
                {
                    VarNameNoteDic.Add(item.VarName, item.Note);
                }
                StoreAreaCategoryAdd(item);
            }

        }


        /// <summary>
        /// 根据modbus变量存储区域进行分类添加到集合中
        /// </summary>
        /// <param name="item"></param>
        private static void StoreAreaCategoryAdd(ModbusVar item)
        {
            if (item.StoreArea == "01 Coil Status(0x)")
            {
                modVarList_0x.Add(item);
                return;
            }
            if (item.StoreArea == "02 Input Status(1x)")
            {
                modVarList_1x.Add(item);
                return;
            }
            if (item.StoreArea == "03 Holding Register(4x)")
            {
                modVarList_4x.Add(item);
                return;
            }
            if (item.StoreArea == "04 Input Registers(3x)")
            {
                modVarList_3x.Add(item);
            }
        }

        /// <summary>
        /// 获取文件ini配置信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static void GetModConfigInfo()
        {
            StreamReader sr = new StreamReader(modbusPath, Encoding.Default);
            List<string> list = new List<string>();
            while (!sr.EndOfStream)
            {
                list.Add(sr.ReadLine());
            }
            if (list.Count == 6)
            {
                address = Convert.ToInt32(list[1]);
                objModbusEntity = new ModbusEntity()
                {
                    Port = list[0],
                    Paud = Convert.ToInt32(list[2]),
                    ModParity = (Parity)Enum.Parse(typeof(Parity), list[3]),
                    DataBit = Convert.ToInt32(list[4])
                };
                switch (list[5])
                {
                    case "1":
                        objModbusEntity.ModStopBit = StopBits.One; break;
                    case "2":
                        objModbusEntity.ModStopBit = StopBits.Two; break;
                    default:
                        objModbusEntity.ModStopBit = StopBits.None;
                        break;
                }
            }
        }

        /// <summary>
        /// 加载Modbus变量XMl文件
        /// </summary>
        /// <param name="xmlPath"></param>
        /// <returns></returns>
        public static void LoadModVarXML()
        {
            if (!File.Exists(varModbusPath))
            {
                return;
            }
            else
            {
                modbusVarList = new List<ModbusVar>();
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(varModbusPath);
                XmlElement nodeRoot = xmlDocument.DocumentElement;
                foreach (XmlNode varNode in nodeRoot.ChildNodes)
                {
                    if (varNode.Name == "Variable")
                    {
                        ModbusVar objVar = new ModbusVar()
                        {
                            VarName = varNode.Attributes["VarName"].Value,
                            Address = varNode.Attributes["Address"].Value,
                            DataType = varNode.Attributes["DataType"].Value,
                            StoreArea = varNode.Attributes["StoreArea"].Value,
                            Note = varNode.Attributes["Note"].Value,
                            IsFiling = varNode.Attributes["IsFiling"].Value,
                            IsAlarm = varNode.Attributes["IsAlarm"].Value,
                            IsReport = varNode.Attributes["IsReport"].Value,
                            AbsoluteAddress = varNode.Attributes["AbsoluteAddress"].Value
                        };
                        modbusVarList.Add(objVar);
                    }
                }
            }
        }

        /// <summary>
        /// 加载报警变量XMl文件
        /// </summary>
        /// <param name="xmlPath"></param>
        /// <returns></returns>
        public static void LoadAlarmXML()
        {
            if (!File.Exists(varAlarmPath))
            {
                return;
            }
            else
            {
                alarmList = new List<VarAlarm>();
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(varAlarmPath);
                XmlElement nodeRoot = xmlDocument.DocumentElement;
                foreach (XmlNode alarmNode in nodeRoot.ChildNodes)
                {
                    if (alarmNode.Name == "VarAlarm")
                    {
                        VarAlarm objVar = new VarAlarm();
                        objVar.VarName = alarmNode.Attributes["VarName"].Value;
                        string alarmsStr = alarmNode.Attributes["Alarms"].Value;//Low;100;1;none|Low;100;1;none|...
                        string[] alarmsArr = alarmsStr.Split('|');
                        foreach (string alram in alarmsArr)
                        {
                            if (alram != "")
                            {
                                string[] alarmArr = alram.Split(';');
                                objVar.Alarms.Add(new Alarm()
                                {
                                    AlarmType = alarmArr[0],
                                    AlarmValue = float.Parse(alarmArr[1]),
                                    Priority = Convert.ToInt32(alarmArr[2]),
                                    Note = alarmArr[3]
                                });
                            }
                        }
                        alarmList.Add(objVar);
                    }
                }
            }
        }

        /// <summary>
        /// 加载存储区域XML文件
        /// </summary>
        public static void LoadStoreAreaXML()
        {
            if (!File.Exists(storeAreaPath))
            {
                return;
            }
            else
            {
                storeAreaList = new List<StoreAreaEntity>();
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(storeAreaPath);
                XmlElement nodeRoot = xmlDocument.DocumentElement;
                foreach (XmlNode storeAreaNode in nodeRoot.ChildNodes)
                {
                    if (storeAreaNode.Name == "StoreArea")
                    {
                        StoreAreaEntity objStore = new StoreAreaEntity();
                        objStore.StoreType = storeAreaNode.Attributes["StoreType"].Value;
                        objStore.StartReg = Convert.ToInt32(storeAreaNode.Attributes["StartReg"].Value);
                        objStore.Length = Convert.ToInt32(storeAreaNode.Attributes["Length"].Value);
                        storeAreaList.Add(objStore);
                    }
                }
            }
        }

        /// <summary>
        /// 根据集合保存modbus变量、报警变量、存储区域变量到XML文件中
        /// </summary>
        public static void SaveToXML()
        {
            try
            {
                //【1】保存Modbus变量到XML文件
                XmlDocument rootXml = new XmlDocument();//文档对象
                XmlElement rootNode = rootXml.CreateElement("Root");//根节点元素
                foreach (var item in modbusVarList)
                {
                    XmlElement xmle = rootXml.CreateElement("Variable");//变量节点元素
                    XMLAttributeAppend(rootXml, "VarName", item.VarName, xmle);//该变量节点属性
                    XMLAttributeAppend(rootXml, "Address", item.Address, xmle);
                    XMLAttributeAppend(rootXml, "DataType", item.DataType, xmle);
                    XMLAttributeAppend(rootXml, "StoreArea", item.StoreArea, xmle);
                    XMLAttributeAppend(rootXml, "Note", item.Note, xmle);
                    XMLAttributeAppend(rootXml, "IsFiling", item.IsFiling, xmle);
                    XMLAttributeAppend(rootXml, "IsAlarm", item.IsAlarm, xmle);
                    XMLAttributeAppend(rootXml, "IsReport", item.IsReport, xmle);
                    XMLAttributeAppend(rootXml, "AbsoluteAddress", item.AbsoluteAddress, xmle);
                    rootNode.AppendChild(xmle);
                }
                rootXml.AppendChild(rootNode);
                if (File.Exists(Common.varModbusPath))
                {
                    File.Delete(Common.varModbusPath);
                }
                rootXml.Save(Common.varModbusPath);

                //【2】 保存存储区域 
                //先遍历集合变量计算出存储区域集合
                CalculateStoreList();
                XmlDocument rootXml1 = new XmlDocument();//文档对象
                XmlElement rootNode1 = rootXml1.CreateElement("Root");//根节点元素
                foreach (var item in storeAreaList)
                {
                    XmlElement xmle1 = rootXml1.CreateElement("StoreArea");//变量节点元素
                    XMLAttributeAppend(rootXml1, "StoreType", item.StoreType, xmle1);//该变量节点属性
                    XMLAttributeAppend(rootXml1, "StartReg", item.StartReg.ToString(), xmle1);
                    XMLAttributeAppend(rootXml1, "Length", item.Length.ToString(), xmle1);
                    rootNode1.AppendChild(xmle1);
                }
                rootXml1.AppendChild(rootNode1);
                if (File.Exists(Common.storeAreaPath))
                {
                    File.Delete(Common.storeAreaPath);
                }
                rootXml1.Save(Common.storeAreaPath);

                //【3】 保存报警变量
                XmlDocument rootXml2 = new XmlDocument();//文档对象
                XmlElement rootNode2 = rootXml2.CreateElement("Root");//根节点元素
                foreach (var item in alarmList)
                {
                    XmlElement xmle2 = rootXml2.CreateElement("VarAlarm");//变量节点元素
                    XMLAttributeAppend(rootXml2, "VarName", item.VarName, xmle2);//该变量节点属性
                    string alarmStr = string.Empty;
                    foreach (var item1 in item.Alarms)
                    {
                        alarmStr += $"{item1.AlarmType};{item1.AlarmValue};{item1.Priority};{item1.Note}|";
                    }
                    XMLAttributeAppend(rootXml2, "Alarms", alarmStr, xmle2);
                    rootNode2.AppendChild(xmle2);
                }
                rootXml2.AppendChild(rootNode2);
                if (File.Exists(Common.varAlarmPath))
                {
                    File.Delete(Common.varAlarmPath);
                }
                rootXml2.Save(Common.varAlarmPath);
                MessageBox.Show("保存成功！");

            }
            catch (Exception ex)
            {
                MessageBox.Show("保存出现错误：" + ex.Message);
            }
        }

        /// <summary>
        /// 事件调用方法
        /// </summary>
        public static void UpdateAlarm()
        {
            AlarmUpdateHandler?.Invoke(null,null);
        }


        /// <summary>
        /// 向XML文件中添加节点属性信息
        /// </summary>
        /// <param name="rootXml"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="head"></param>
        private static void XMLAttributeAppend(XmlDocument rootXml, string name, string value, XmlElement head)
        {
            XmlAttribute att = rootXml.CreateAttribute(name);
            att.Value = value;
            head.Attributes.Append(att);
        }

        #region 根据当前变量集合进行自动计算，计算出存储区域的集合
        /// <summary>
        /// 根据当前变量集合进行自动计算，计算出存储区域的集合
        /// </summary>
        /// <returns></returns>
        private static void CalculateStoreList()
        {
            storeAreaList.Clear();//清空原先加载存储区域文件的实例，再根据当前modbus变量集合添加存储区域
            List<ModbusVar> List_0x = new List<ModbusVar>();
            List<ModbusVar> List_1x = new List<ModbusVar>();
            List<ModbusVar> List_3x = new List<ModbusVar>();
            List<ModbusVar> List_4x = new List<ModbusVar>();
            foreach (ModbusVar item in modbusVarList)
            {
                if (item.StoreArea == "01 Coil Status(0x)")
                {
                    List_0x.Add(item);
                }
                if (item.StoreArea == "02 Input Status(1x)")
                {
                    List_1x.Add(item);
                }
                if (item.StoreArea == "03 Holding Register(4x)")
                {
                    List_4x.Add(item);
                }
                if (item.StoreArea == "04 Input Registers(3x)")
                {
                    List_3x.Add(item);
                }
            }
            if (List_0x.Count > 0)
            {
                storeAreaList.Add(new StoreAreaEntity()
                {
                    StoreType = "01 Coil Status(0x)",
                    StartReg = AnalyseVar(List_0x)[0],
                    Length = AnalyseVar(List_0x)[1]
                });
            }
            if (List_4x.Count > 0)
            {
                storeAreaList.Add(new StoreAreaEntity()
                {
                    StoreType = "03 Holding Register(4x)",
                    StartReg = AnalyseVar(List_4x)[0],
                    Length = AnalyseVar(List_4x)[1]
                });
            }
        }


        /// <summary>
        /// 对一种类型的Modbus变量集合进行分析，返回第一个数值为起始地址，第二个数值为长度
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static List<int> AnalyseVar(List<ModbusVar> list)
        {
            List<int> ResultList = new List<int>(2);
            List<int> AddressList = new List<int>();
            int Start = 0;
            int End = 0;
            int Length = 0;
            string DataType = string.Empty;
            foreach (ModbusVar item in list)
            {
                AddressList.Add(int.Parse(item.Address));
            }
            Start = AddressList.Min();
            End = AddressList.Max();
            foreach (ModbusVar item in list)
            {
                if (item.Address == End.ToString())
                {
                    DataType = item.DataType;
                }
            }
            switch (DataType)
            {
                case "Bool":
                    Length = End - Start + 1;
                    break;
                case "Float":
                    Length = End - Start + 2;
                    break;
                case "Float Inverse":
                    Length = End - Start + 2;
                    break;
                case "Long":
                    Length = End - Start + 2;
                    break;
                case "Long Inverse":
                    Length = End - Start + 2;
                    break;
                case "Double":
                    Length = End - Start + 4;
                    break;
                case "Double Inverse":
                    Length = End - Start + 4;
                    break;
                default:
                    Length = End - Start + 2;
                    break;
            }
            ResultList.Add(Start);
            ResultList.Add(Length);
            return ResultList;
        }
        #endregion
    }
}
