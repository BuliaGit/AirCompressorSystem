using DAL;
using DAL.Helper;
using Entity;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using UI.HWConfigUI;

namespace UI
{
    public partial class FrmMain : Form
    {
        //上次报警变量的值
        private Dictionary<string, float> alarmLastValueDic = new Dictionary<string, float>();
        //插入归档数据定时器
        System.Timers.Timer timer;
        System.Timers.Timer timerShow;
        public FrmMain()
        {
            InitializeComponent();
            //实时插入归档数据定时器
            timer = new System.Timers.Timer(10000);
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            //系统时间定时器
            timerShow = new System.Timers.Timer(1000);
            timerShow.AutoReset = true;
            timerShow.Elapsed += TimerShow_Elapsed;
            timerShow.Start();
            //用户名显示
            lblAdminName.Text = Program.currentAdmin.LoginName;
        }

        /// <summary>
        /// 系统时间显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void TimerShow_Elapsed(object sender, ElapsedEventArgs e)
        {
            lblTime.BeginInvoke(new Action(() =>
            {
                lblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }));
        }

        private DataArchiveDAL archiveDAL = new DataArchiveDAL();
        private AlarmDAL alarmDAL = new AlarmDAL();
        private ReportDAL reportDAL = new ReportDAL();

        //int preHour = DateTime.Now.Hour;
        /// <summary>
        /// 定时器事件：实时插入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {

            if (Common.portOpenStatus)
            {
                if (Common.valueDic != null && Common.valueDic.Count > 0)
                {
                    InsertFilingData();
                    InsertDataHourReport();
                    //if (DateTime.Now.Minute == 0 && DateTime.Now.Hour != preHour)//整点并且与上次插入的小时不同则插入
                    //{
                    //    InsertDataHourReport();
                    //    preHour = DateTime.Now.Hour;
                    //}
                }
            }
        }



        /// <summary>
        /// 插入归档数据
        /// </summary>
        private void InsertFilingData()
        {
            List<FilingData> subList = new List<FilingData>();
            foreach (var item in Common.fileVarList)
            {
                FilingData filingData = new FilingData();
                filingData.InsertTime = DateTime.Now;
                filingData.VarName = item.VarName;
                filingData.Remark = item.Note;

                if (!Common.valueDic.ContainsKey(item.VarName) || Common.valueDic[item.VarName].Length == 0)
                {
                    filingData.Value = "0.0";
                }
                else
                {
                    filingData.Value = (Convert.ToDouble(Common.valueDic[item.VarName])).ToString();
                }
                subList.Add(filingData);
            }
            archiveDAL.InsertActualData(subList);
            if (Common.filingCacheList.Count <= Common.cacheCount)
            {
                Common.filingCacheList.Add(subList);
            }
            else
            {
                Common.filingCacheList.RemoveAt(0);
                Common.filingCacheList.Add(subList);
            }
        }

        /// <summary>
        /// 插入数据报表数据
        /// </summary>
        private void InsertDataHourReport()
        {
            List<string> array = new List<string>();
            foreach (ModbusVar item in Common.reportVarList)
            {
                double value = 0.0;
                if (Common.valueDic.ContainsKey(item.VarName))
                {
                    string resValue = Common.valueDic[item.VarName];
                    if (resValue.Length > 0)
                    {
                        value = Convert.ToDouble(resValue);
                    }
                    array.Add(value.ToString("f1"));
                }
            }
            StringBuilder sb = new StringBuilder("INSERT INTO ReportData (InsertTime,LQT_Level,LQT_InPre,LQT_InTemp,LQT_OutPre");
            sb.Append(",LQT_OutTemp,LQT_BSPre,LQB1_Current,LQB1_Fre,LQB2_Current,LQB2_Fre,KYJ1_OutTemp,KYJ2_OutTemp,KYJ3_OutTemp,CQG1_OutPre");
            sb.Append(",CQG2_OutPre,CQG3_OutPre,Env_Temp,FQG_Temp,FQG_Pre)");
            sb.Append(" values('" + DateTime.Now + "','" + array[0] + "','" + array[1]
                + "','" + array[2] + "','" + array[3] + "','" + array[4] + "','" + array[5] + "','"
                + array[6] + "','" + array[7] + "','" + array[8] + "','" + array[9] + "','" + array[10] + "','"
                + array[11] + "','" + array[12] + "','" + array[13] + "','" + array[14] + "','" + array[15] + "','"
                + array[16] + "','" + array[17] + "','" + array[18] + "')");

            SQLHelper.Update(sb.ToString());
        }


        //modbus配置
        private ModbusEntity modbusEntity;
        //Modbus变量集合
        private List<ModbusVar> varList;
        //报警变量集合
        private List<VarAlarm> alarmList;
        //存储区域集合
        private List<StoreAreaEntity> storeList;

        //实例化通讯线程类
        CommHelper commThread = new CommHelper();

        /// <summary>
        /// 窗体加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //初始化文件信息
            InitialTxt();
            //打开串口并返回赋值
            Common.portOpenStatus = OpenPort(modbusEntity);
            if (Common.portOpenStatus)
            {
                //开启线程（实时通讯读取硬件数据）
                commThread.thread.Start();
            }
            else
            {
                //打开串口失败
                MessageBox.Show("串口打开失败！");
            }
            //默认打开控制流程界面 
            btnControlFlow_Click(btnControlFlow, null);
            //实时添加归档数据
            timer.Start();
            Thread.Sleep(500);
            //初始化报警缓存集合
            InitialAlarm();
            //开线程检测报警
            Thread alarmCheckT = new Thread(CheckAlarm);
            alarmCheckT.IsBackground = true;
            alarmCheckT.Start();
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="modbusEntity"></param>
        /// <returns></returns>
        private bool OpenPort(ModbusEntity modbusEntity)
        {
            return Common.objMod.OpenOrClosePort(modbusEntity.Port, modbusEntity.Paud, modbusEntity.DataBit, modbusEntity.ModParity, modbusEntity.ModStopBit);
        }


        /// <summary>
        ///  初始化
        /// </summary>
        private void InitialTxt()
        {
            //获取加载的各集合引用实例
            modbusEntity = Common.objModbusEntity;
            varList = Common.modbusVarList;
            alarmList = Common.alarmList;
            storeList = Common.storeAreaList;

        }

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="showForm"></param>
        private void ShowForm(Form showForm)
        {
            foreach (Control item in mainPanel.Controls)
            {
                if (item.Name == showForm.Name)
                {
                    //如果包含有显示窗体则不进行任何操作
                    return;
                }
                if (item is Form)
                {
                    Form form = (Form)item;
                    CloseSubForm(form, "FrmIOVarManage");//关闭父窗体内的IO变量子窗体触发关闭事件（是否保存）
                    if (!Common.IOExitCanel)//如果确定IO变量窗体退出则关闭父窗体
                    {
                        form.Close();
                    }
                }
            }
            //当跳转页面时判断IO页面退出是否取消
            if (Common.IOExitCanel)
            {
                return;
            }
            showForm.TopLevel = false;
            showForm.FormBorderStyle = FormBorderStyle.None;
            showForm.Dock = DockStyle.Fill;
            showForm.Parent = mainPanel;
            showForm.Show();
        }


        /// <summary>
        /// 根据名字递归关闭父窗体的子控件
        /// </summary>
        /// <param name="parentForm"></param>
        /// <param name="findFormName"></param>
        private void CloseSubForm(Control parentForm, string findFormName)
        {
            foreach (Control item in parentForm.Controls)
            {
                if (item.Name == findFormName)
                {
                    Form findForm = (Form)item;
                    findForm.Close();
                    break;
                }
                else
                {
                    CloseSubForm(item, findFormName);
                }
            }
        }

        //------------------------报警-----------------------------------
        /// <summary>
        /// 初始化报警相关集合
        /// </summary>
        private void InitialAlarm()
        {
            foreach (VarAlarm item in Common.alarmList)
            {
                //填充LastValue
                if (!alarmLastValueDic.ContainsKey(item.VarName) && Common.valueDic[item.VarName].Length > 0)
                {
                    float floatValue = float.Parse(Common.valueDic[item.VarName]);
                    alarmLastValueDic.Add(item.VarName, floatValue);
                    bool HiHi = false;
                    bool lolo = false;
                    foreach (Alarm it in item.Alarms)
                    {

                        switch (it.AlarmType)
                        {
                            case "HiHi":
                                if (floatValue >= it.AlarmValue)
                                {
                                    NewAlarmHandle(new AlarmCache(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), item.VarName, "ACK", it.AlarmType, floatValue, it.AlarmValue, Program.currentAdmin.LoginName, it.Note, it.Priority));
                                    HiHi = true;
                                }
                                break;
                            case "High":
                                if (HiHi)
                                {
                                    break;
                                }
                                if (floatValue >= it.AlarmValue)
                                {
                                    NewAlarmHandle(new AlarmCache(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), item.VarName, "ACK", it.AlarmType, floatValue, it.AlarmValue, Program.currentAdmin.LoginName, it.Note, it.Priority));
                                }
                                break;
                            case "LoLo":
                                if (floatValue <= it.AlarmValue)
                                {
                                    NewAlarmHandle(new AlarmCache(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), item.VarName, "ACK", it.AlarmType, floatValue, it.AlarmValue, Program.currentAdmin.LoginName, it.Note, it.Priority));
                                    lolo = true;
                                }
                                break;
                            case "Low":
                                if (lolo)
                                {
                                    break;
                                }
                                if (floatValue <= it.AlarmValue)
                                {
                                    NewAlarmHandle(new AlarmCache(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), item.VarName, "ACK", it.AlarmType, floatValue, it.AlarmValue, Program.currentAdmin.LoginName, it.Note, it.Priority));
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
        /// 实时检测报警值
        /// </summary>
        private void CheckAlarm()
        {
            while (true)
            {
                if (Common.isAlarmCheck)
                {
                    if (Common.portOpenStatus && alarmLastValueDic.Count > 0)
                    {
                        foreach (VarAlarm item in Common.alarmList)
                        {
                            float lastValue = alarmLastValueDic[item.VarName];
                            float actualValue = float.Parse(Common.valueDic[item.VarName]);
                            bool newHiHi = false;
                            bool newLoLo = false;
                            foreach (Alarm it in item.Alarms)
                            {
                                float AlarmValue = it.AlarmValue;
                                switch (it.AlarmType)
                                {
                                    case "High":
                                    case "HiHi":
                                        //新增报警
                                        if (actualValue >= AlarmValue && actualValue != lastValue)
                                        {
                                            if (it.AlarmType == "HiHi")
                                            {
                                                Common.alarmCacheList.Remove(Common.alarmCacheList.FirstOrDefault(x => x.Note == Common.VarNameNoteDic[item.VarName] + "高高报警"));
                                                Common.alarmCacheList.Remove(Common.alarmCacheList.FirstOrDefault(x => x.Note == Common.VarNameNoteDic[item.VarName] + "高报警"));
                                                newHiHi = true;
                                            }
                                            else
                                            {
                                                if (newHiHi) break;
                                                Common.alarmCacheList.Remove(Common.alarmCacheList.FirstOrDefault(x => x.Note == Common.VarNameNoteDic[item.VarName] + "高报警"));
                                            }
                                            AlarmCache temp = new AlarmCache(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), item.VarName, "ACK", it.AlarmType, actualValue, it.AlarmValue, Program.currentAdmin.LoginName, it.Note, it.Priority);
                                            NewAlarmHandle(temp);
                                        }
                                        //消除报警
                                        if (actualValue < AlarmValue && lastValue >= AlarmValue)
                                        {
                                            if (it.AlarmType == "HiHi")
                                            {
                                                Common.alarmCacheList.Remove(Common.alarmCacheList.FirstOrDefault(x => x.Note == Common.VarNameNoteDic[item.VarName] + "高高报警"));
                                            }
                                            else
                                            {
                                                Common.alarmCacheList.Remove(Common.alarmCacheList.FirstOrDefault(x => x.Note == Common.VarNameNoteDic[item.VarName] + "高报警"));
                                            }
                                            AlarmCache temp = new AlarmCache(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), item.VarName, "UNACK", it.AlarmType, lastValue, it.AlarmValue, Program.currentAdmin.LoginName, it.Note, it.Priority);
                                            NewAlarmHandle(temp);

                                        }
                                        break;
                                    case "Low":
                                    case "LoLo":
                                        if (actualValue <= AlarmValue && actualValue != lastValue)
                                        {
                                            if (it.AlarmType == "LoLo")
                                            {
                                                Common.alarmCacheList.Remove(Common.alarmCacheList.FirstOrDefault(x => x.Note == Common.VarNameNoteDic[item.VarName] + "低低报警"));
                                                Common.alarmCacheList.Remove(Common.alarmCacheList.FirstOrDefault(x => x.Note == Common.VarNameNoteDic[item.VarName] + "低报警"));
                                                newLoLo = true;
                                            }
                                            else
                                            {
                                                if (newLoLo) break;
                                                Common.alarmCacheList.Remove(Common.alarmCacheList.FirstOrDefault(x => x.Note == Common.VarNameNoteDic[item.VarName] + "低报警"));
                                            }
                                            AlarmCache temp = new AlarmCache(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), item.VarName, "ACK", it.AlarmType, actualValue, it.AlarmValue, Program.currentAdmin.LoginName, it.Note, it.Priority);
                                            NewAlarmHandle(temp);
                                        }
                                        if (actualValue > AlarmValue && lastValue <= AlarmValue)
                                        {
                                            if (it.AlarmType == "LoLo")
                                            {
                                                Common.alarmCacheList.Remove(Common.alarmCacheList.FirstOrDefault(x => x.Note == Common.VarNameNoteDic[item.VarName] + "低低报警"));
                                            }
                                            else
                                            {
                                                Common.alarmCacheList.Remove(Common.alarmCacheList.FirstOrDefault(x => x.Note == Common.VarNameNoteDic[item.VarName] + "低报警"));
                                            }
                                            AlarmCache temp = new AlarmCache(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), item.VarName, "UNACK", it.AlarmType, lastValue, it.AlarmValue, Program.currentAdmin.LoginName, it.Note, it.Priority);
                                            NewAlarmHandle(temp);
                                        }
                                        break;
                                }
                            }
                            if (alarmLastValueDic.ContainsKey(item.VarName))
                            {
                                //重新赋值报警上次值集合
                                alarmLastValueDic[item.VarName] = actualValue;
                            }
                        }
                    }
                }
            }
        }
        private void NewAlarmHandle(AlarmCache obj)
        {
            if (Common.alarmCacheList.Count < Common.AlarmCacheCount)
            {
                Common.alarmCacheList.Add(obj);
            }
            else
            {
                Common.alarmCacheList.RemoveAt(0);
                Common.alarmCacheList.Add(obj);
            }
            //插入报警数据到数据库
            alarmDAL.InsertAlarm(obj);
            Common.UpdateAlarm();
        }
        //---------------------------------------------------------------


        /// <summary>
        /// 点击控制流程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnControlFlow_Click(object sender, EventArgs e)
        {
            ShowForm(new FrmControlFlow());
            lblTitle.Text = "控制流程";
            BtnClickColorSet((Button)sender);
            //对退出取消复原
            Common.IOExitCanel = false;
        }

        /// <summary>
        /// 点击参数设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnParamSet_Click(object sender, EventArgs e)
        {
            ShowForm(new FrmParamSet());
            lblTitle.Text = "参数设置";
            BtnClickColorSet((Button)sender);
            //对退出取消复原
            Common.IOExitCanel = false;
        }

        /// <summary>
        /// 点击趋势曲线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrendCurve_Click(object sender, EventArgs e)
        {
            ShowForm(new FrmTrendCurve());
            lblTitle.Text = "趋势曲线";
            BtnClickColorSet((Button)sender);
            //对退出取消复原
            Common.IOExitCanel = false;
        }

        /// <summary>
        /// 点击故障报警
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlarm_Click(object sender, EventArgs e)
        {
            ShowForm(new FrmFaultAlarm(this));
            lblTitle.Text = "故障报警";
            BtnClickColorSet((Button)sender);
            //对退出取消复原
            Common.IOExitCanel = false;
        }

        /// <summary>
        /// 点击数据报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDataReport_Click(object sender, EventArgs e)
        {
            ShowForm(new FrmReportData());
            lblTitle.Text = "数据报表";
            BtnClickColorSet((Button)sender);
            //对退出取消复原
            Common.IOExitCanel = false;
        }

        /// <summary>
        /// 点击硬件组态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHWConfig_Click(object sender, EventArgs e)
        {
            ShowForm(new FrmHWConfig());
            lblTitle.Text = "硬件组态";
            BtnClickColorSet((Button)sender);
            //对退出取消复原
            Common.IOExitCanel = false;
        }

        /// <summary>
        /// 点击按钮背景色设置
        /// </summary>
        /// <param name="clickBtn"></param>
        private void BtnClickColorSet(Button clickBtn)
        {
            if (Common.IOExitCanel) return;
            foreach (Control c in bottomPanel.Controls)
            {
                if (c is Button)
                {
                    c.BackColor = Color.Teal;
                }
            }
            clickBtn.BackColor = Color.MediumSlateBlue;
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
