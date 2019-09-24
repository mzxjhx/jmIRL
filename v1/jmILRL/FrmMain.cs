using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using jmILRL.BAL;
using jmILRL.DAL;
using jmILRL.common;
using RS232;
using System.Configuration;
using System.IO;
using Zxui;
using System.Text.RegularExpressions;
using jmILRL.Class;

/// <summary>
/// 
/// </summary>
namespace jmILRL
{
    public partial class FrmMain : FrmBase
    {
        Base232 rs232 = new ZwdPort();
        /// <summary>
        /// 文件保存路径
        /// </summary>
        string filePath = "D:\\FBT";
        /// <summary>
        /// 
        /// </summary>
        NPOIHelper npoiHelper = new NPOIHelper();
        /// <summary>
        /// 
        /// </summary>
        FBT fbt = new FBT();
        /// <summary>
        /// 
        /// </summary>
        FBTService fbtService = new FBTService();

        private int curPort = 0, totalPort = 2;

        private Label[] labelIL = new Label[4];
        private Label[] labelRL = new Label[4];

        Timer timer = new Timer();

        /// <summary>
        /// 5秒内读10次
        /// </summary>
        private int timerCount = 0;
        /// <summary>
        /// 每次读取数据个数
        /// </summary>
        private int times = 0;

        private bool flag = false;
        /// <summary>
        /// 10次数组取最值
        /// </summary>
        private float[] ilstmp = new float[10];
        /// <summary>
        /// 10次数组取最值
        /// </summary>
        private float[] rlstmp = new float[10];
        /// <summary>
        /// 阈值
        /// </summary>
        private float ilLevel = 0, rlLevel = 0;
        /// <summary>
        /// 串口协议枚举
        /// </summary>
        private PortBand portBand = PortBand.Zwd;

        private int reflesh = 500;

        #region 实时数据
        /// <summary>
        /// 实时
        /// </summary>
        Timer _realTimer = new Timer();
        /// <summary>
        /// 该实时RL值要求>30
        /// </summary>
        private float _realRL = 0;

        private bool _canTest = true;

        #endregion

        public FrmMain()
        {
            InitializeComponent();
            _isResize = false;
            _isDBMax = false;

        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            rs232.OnCallBack += Rs232_DataRec;
            ReadConfig();
            if (portBand == PortBand.Hongshan)
            {
                rs232 = new HongShanPort();
                rs232.OnCallBack += Rs232_DataRec;
            }

            PortInit();
            LabelInit();

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            timer.Interval = reflesh;
            timer.Tick += (object s, EventArgs obj) => {
                if (!rs232.IsOpen)
                    return;

                if (timerCount > times - 1)
                {
                    timerCount = 0;
                    timer.Enabled = false;
                    btnTest.Enabled = true;
                    if (MessageBox.Show("是否测下一步骤?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        timer.Enabled = true;
                        btnTest.Enabled = false;
                        curPort++;
                        if (curPort == totalPort)
                        {
                            timer.Enabled = false;
                            btnTest.Enabled = true;
                            toSave();
                            curPort = 0;
                        }
                    }
                    else
                    {
                        timer.Enabled = false;
                        btnTest.Enabled = true;
                    }
                }
                else
                {
                    if (portBand == PortBand.Zwd)
                        rs232.Write(String.Format("SOUR:WAV{0}:{1}?", "1550", radioButtonIL.Checked ? "IL" : "RL"));
                    else
                        rs232.Write();
                    if (timerCount == ilstmp.Length - 1)
                        flag = true;
                }
            };

            //测试保存完，开定时器读实时数据。
            _realTimer.Interval = 200;
            _realTimer.Tick += (object s, EventArgs obj) =>
            {
                if (!rs232.IsOpen)
                    return;
                if (portBand == PortBand.Zwd)
                    rs232.Write(String.Format("SOUR:WAV{0}:{1}?", "1550", radioButtonIL.Checked ? "IL" : "RL"));
                else
                    rs232.Write();
            };
        }
        private void ReadConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            String sqlcon = config.AppSettings.Settings["connString"].Value;
            filePath = config.AppSettings.Settings["filePath"].Value;
            ilLevel = float.Parse(config.AppSettings.Settings["level_IL"].Value);
            rlLevel = float.Parse(config.AppSettings.Settings["level_RL"].Value);
            portBand = config.AppSettings.Settings["portBand"].Value == "zwd" ? PortBand.Zwd : PortBand.Hongshan;
            reflesh = int.Parse(config.AppSettings.Settings["reflesh"].Value);
            times = int.Parse(config.AppSettings.Settings["times"].Value);

            ilstmp = new float[times];
            rlstmp = new float[times];

            labelflesh.Text = string.Format("刷新频率：{0}ms", reflesh);
            labelTimes.Text = string.Format("数据量：{0}个", times);
        }

        /// <summary>
        /// 
        /// </summary>
        private void PortInit()
        {
            string[] portnames = System.IO.Ports.SerialPort.GetPortNames();
            //foreach (string item in portnames)
            //{

            //}
            if (portnames.Length == 0)
            {
                MessageBox.Show("未找到串口，请确认！");
                return;
            }
            else
            {
                try
                {
                    rs232.Com = portnames[0];
                    rs232.Open();
                }
                catch (Exception ex)
                {
                    labelCom.Text = string.Format("COM：{0}", ex.Message);
                }

            }

        }

        private void LabelInit()
        {
            for (int i = 0; i < labelIL.Length; i++)
            {
                labelIL[i] = new Label();
            }
            labelIL[0] = IL1;
            labelIL[1] = IL2;
            labelIL[2] = IL3;
            labelIL[3] = IL4;

            for (int i = 0; i < labelRL.Length; i++)
            {
                labelRL[i] = new Label();
            }
            labelRL[0] = RL1;
            labelRL[1] = RL2;
            labelRL[2] = RL3;
            labelRL[3] = RL4;
        }

        /// <summary>
        /// 2019-4-26
        /// 串口接收
        /// </summary>
        /// <param name="bs"></param>
        public void Rs232_DataRec(byte[] bs)
        {
            try
            {
                //StringBuilder sb = new StringBuilder();
                //for (int i = 0, len = bs.Length; i < len; i++)
                //{
                //    sb.Append(bs[i].ToString("X2") + " ");
                //}
                //richTextBox1.Text = sb.ToString();

                //zwdProcess(bs);
                if (portBand == PortBand.Zwd)
                    zwdProcess(bs);
                else if (portBand == PortBand.Hongshan) {
                    hongShanProcess(bs);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 字符串协议处理
        /// </summary>
        /// <param name="bs"></param>
        private void zwdProcess(byte[] bs)
        {
            string str = System.Text.Encoding.Default.GetString(bs);
            string[] tmp = Regex.Split(str, "\r\n", RegexOptions.IgnoreCase);
            if (radioButtonIL.Checked)
            {
                labelIL[curPort].Text = String.Format("IL{0}:{1} dB ", curPort + 1, Tools.killdB(tmp[0]));
                ilstmp[timerCount++] = float.Parse(Tools.killdB(tmp[0]));

                //循环次数到
                if (flag)
                {
                    flag = !flag;
                    float tt = Tools.getMax(ilstmp);
                    labelIL[curPort].Text = String.Format("IL{0}:{1} dB ", curPort + 1, tt);
                    fbt.IL[curPort] = tt;
                    bool isfail = Tools.isBeyond(totalPort, fbt, ilLevel);
                    level.ShowResult = isfail == true ? Result.result.failed : Result.result.pass;
                    fbt.Level = isfail == true ? 0 : 1;
                    //richTextBox1.Text = string.Format("出纤数={0}, 阈值={1},il1={2},il2={3},il3={4},il4={5},等级={6}", totalPort, ilLevel, fbt.IL[0], fbt.IL[1], fbt.IL[2], fbt.IL[3], fbt.Level);
                }
            }
            else
            {
                labelRL[curPort].Text = String.Format("RL{0}:{1} dB ", curPort + 1, Tools.killdB(tmp[0]));
                rlstmp[timerCount++] = float.Parse(Tools.killdB(tmp[0]));
                
                //循环次数到
                if (flag)
                {
                    flag = !flag;
                    float tt = Tools.getMin(rlstmp);
                    labelRL[curPort].Text = String.Format("RL{0}:{1} dB ", curPort + 1, tt);
                    fbt.RL[curPort] = tt;
                    bool isfail = Tools.isBelow(totalPort, fbt, rlLevel);
                    level.ShowResult = isfail == true ? Result.result.failed : Result.result.pass;
                    fbt.Level = isfail == true ? 0 : 1;
                    //richTextBox1.Text = string.Format("出纤数={0}, 阈值={1},rl1={2},rl2={3},rl3={4},rl4={5},等级={6}", totalPort, rlLevel, fbt.RL[0], fbt.RL[1], fbt.RL[2], fbt.RL[3], fbt.Level);

                    string msg = string.Format("单次循环 SN={0},rl1={1},rl2={2},rl3={3},rl4={4},出纤={5}", fbt.serialNumber, fbt.RL[0], fbt.RL[1], fbt.RL[2], fbt.RL[3], curPort);
                    LogisTrac.WriteInfo(typeof(FrmMain), msg);
                }
            }
        }

        /// <summary>
        /// 字节数组协议处理
        /// 1310-4,8 1490-12,16 1550-20,24
        /// </summary>
        /// <param name="bs"></param>
        private void hongShanProcess(byte[] rec)
        {
            if (rec.Length == 0) return;
            //if (rec[2] != 0x51) //非上传指令
            //{
            //    return;
            //}

            //if (rec[28] == 0) //踏板无动作
            //{
            //    return;
            //}
            int sum = 0;
            for (int i = 0; i < rec.Length - 2; i++)
            {
                sum += rec[i];
            }
            sum = ~sum;
            sum += 1;
            if (rec[rec.Length - 2] != (byte)sum) return;   //校验不合格

            if (rec[2] == 0x02) {
                labelCom.Text = string.Format("COM：{0}", "已连接");
            }

            if (_realTimer.Enabled)
            {
                _realRL = rlstmp[timerCount] = BitConverter.ToSingle(rec, 8);
                if (_realRL < 30)
                    _canTest = true;
                labelTimes.Text = _realRL + "";
                return;
            }

            rlstmp[timerCount] = BitConverter.ToSingle(rec, 8);
            ilstmp[timerCount++] = BitConverter.ToSingle(rec, 17);

            labelIL[curPort].Text = String.Format("IL{0}:{1} dB ", curPort + 1, BitConverter.ToSingle(rec, 17));
            labelRL[curPort].Text = String.Format("RL{0}:{1} dB ", curPort + 1, BitConverter.ToSingle(rec, 8));
            
            //循环次数到
            if (flag)
            {
                flag = !flag;
                float tt = Tools.getMax(ilstmp);
                labelIL[curPort].Text = String.Format("IL{0}:{1} dB ", curPort + 1, tt);
                fbt.IL[curPort] = tt;
                level.ShowResult = Tools.isBeyond(totalPort, fbt, ilLevel) ? Result.result.failed : Result.result.pass;
                //回损
                tt = Tools.getMin(rlstmp);
                fbt.RL[curPort] = tt;
                labelRL[curPort].Text = String.Format("RL{0}:{1} dB ", curPort + 1, tt);
                bool isfail = Tools.isBelow(totalPort, fbt, rlLevel);
                level.ShowResult = isfail == true ? Result.result.failed : Result.result.pass;
                fbt.Level = isfail == true ? 0 : 1;
                //richTextBox1.Text = string.Format("出纤数={0}, 阈值={1},rl1={2},rl2={3},rl3={4},rl4={5},等级={6}", totalPort, rlLevel, fbt.RL[0], fbt.RL[1], fbt.RL[2], fbt.RL[3], fbt.Level);
                StringBuilder sb = new StringBuilder();
                sb.Append(String.Format("SN ={0},", serialNumber_pre.Text + serialNumber_pix.Text));
                for (int i=0;i<rlstmp.Length;i++)
                {
                    sb.Append(String.Format("RL[{1}]={0},", rlstmp[i], i));
                }
                
                //richTextBox1.Text = sb.ToString();
                LogisTrac.WriteInfo(typeof(FrmMain), sb.ToString());
            }
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            if (!_canTest)
            {
                MessageBox.Show("请融接产品重新测试！");
                return;
            }
            timer.Enabled = true;
            _realTimer.Enabled = false;

        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            LogisTrac.WriteInfo(typeof(FrmMain),String.Format("执行保存操作, SN={0}", serialNumber_pre.Text + serialNumber_pix.Text));
            toSave();
        }

        /// <summary>
        /// 保存方法
        /// </summary>
        private void toSave()
        {
            LogisTrac.WriteInfo(typeof(FrmMain), String.Format("进保存, SN={0}", serialNumber_pre.Text + serialNumber_pix.Text));
            if (serialNumber_pre.Text.Trim() == "" || serialNumber_pix.Text.Trim() == "")
            {
                MessageBox.Show("请填写SN号");
                return;
            }
            if(fbt.RL[0] < 10)
            {
				MessageBox.Show("测试数据异常，存在遗漏情况！");
				return;
            }
            fbt.serialNumber = serialNumber_pre.Text.Trim() + serialNumber_pix.Text.Trim();
            fbt.batchNumber = batchNumber.Text.Trim();
            fbt.staff = textBoxID.Text.Trim();
            fbt.PortType = comboBoxPortType.Text;
            if (fbtService.exist(fbt.serialNumber))
            {
                //已存在SN号
                if (MessageBox.Show("该SN号已存在，是否覆盖？") == DialogResult.OK)
                {
                    fbtService.update(fbt);
                    npoiHelper.dataToExcel(Path.Combine(filePath, serialNumber_pre.Text + ".xls"), fbt,rlstmp);
                }
            }
            else
            {
                npoiHelper.dataToExcel(Path.Combine(filePath, serialNumber_pre.Text + ".xls"), fbt, rlstmp);
                fbtService.addNewFBT(fbt);
            }
            serialNumber_pix.Text = "";
            MessageBox.Show("数据已保存");
            fbt = new FBT();
            curPort = 0;
            //保存完开启实时定时器
            _realTimer.Enabled = true;
            //重新融接光纤前不能测试
            _canTest = false;
        }

        /// <summary>
        /// 选端口类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxPortType_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxPort.Items.Clear();
            for (int i = 0; i < comboBoxPortType.SelectedIndex + 1; i++)
            {
                comboBoxPort.Items.Add(i + 1);
            }
            switch (comboBoxPortType.SelectedIndex)
            {

                case 0:
                    IL2.Text = IL3.Text = IL4.Text = "";
                    RL2.Text = RL3.Text = RL4.Text = "";
                    totalPort = 1;
                    break;
                case 1:
                    IL3.Text = IL4.Text = "";
                    RL3.Text = RL4.Text = "";
                    totalPort = 2;
                    break;
                case 2:
                    IL4.Text = "";
                    RL4.Text = "";
                    totalPort = 3;
                    break;
                case 3:
                    totalPort = 4;
                    break;
                default:
                    totalPort = 2;
                    break;
            }
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBoxSet.BackColor = Color.FromArgb(155, 0, 155, 0);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxSet.BackColor = Color.Transparent;
        }

        /// <summary>
        /// 数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxReview_Click(object sender, EventArgs e)
        {
            //new Sections.FormReview().ShowDialog();
            Sections.FormReview frm = new Sections.FormReview();
            frm.ShowDialog();
        }


        private void comboBoxPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            curPort = comboBoxPort.SelectedIndex;
        }
        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmOption frm = new FrmOption();
            frm.OnParamChange += (obj, parm) =>
            {
                ReadConfig();
            };
            frm.ShowDialog();
        }
    }
}
