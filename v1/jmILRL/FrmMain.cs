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

/// <summary>
/// 
/// </summary>
namespace jmILRL
{
    public partial class FrmMain : FrmBase
    {
        Rs232 rs232 = new Rs232();
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

        private int curPort = 1;

        private Label[] il = new Label[4];
        private Label[] rl = new Label[4];

        Timer timer = new Timer();
        /// <summary>
        /// 5秒内读10次
        /// </summary>
        private int timerCount = 0;
        /// <summary>
        /// 10次数组取最值
        /// </summary>
        private float[] ILs = new float[10];
        /// <summary>
        /// 10次数组取最值
        /// </summary>
        private float[] RLs = new float[10];

        public FrmMain()
        {
            InitializeComponent();
            _isResize = false;
            _isDBMax = false;
            //this.WindowState = FormWindowState.Maximized;
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
            PortInit();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            String sqlcon = config.AppSettings.Settings["connString"].Value;
            filePath = config.AppSettings.Settings["filePath"].Value;

            LabelInit();

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            timer.Interval = 500;
            timer.Tick += (object s, EventArgs obj) => {
                if (!rs232.IsOpen)
                    return;

                if (timerCount > 9)
                {
                    timerCount = 0;
                    timer.Enabled = false;
                    btnTest.Enabled = true;
                }
                else {
                    rs232.Write(String.Format("SOUR:WAV{0}:{1}?", "1550", comboBoxILRL.Text));
                    timerCount++;
                }
            };
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
            else {
                try
                {
                    rs232.Com = portnames[0];
                    rs232.Open();

                }
                catch (Exception ex)
                {

                }

            }
            
        }

        private void LabelInit() {
            for (int i = 0; i < il.Length; i++)
            {
                il[i] = new Label();
            }
            il[0] = IL1;
            il[1] = IL2;
            il[2] = IL3;
            il[3] = IL4;

            for (int i = 0; i < rl.Length; i++)
            {
                rl[i] = new Label();
            }
            rl[0] = RL1;
            rl[1] = RL2;
            rl[2] = RL3;
            rl[3] = RL4;
        }

        /// <summary>
        /// 2019-4-26 
        /// </summary>
        /// <param name="bs"></param>
        void Rs232_DataRec(byte[] bs)
        {
            try
            {
                string str = System.Text.Encoding.Default.GetString(bs);
                labelget.Text = string.Format("get:{0}", str);
                string[] tmp = Regex.Split(str, "\r\n", RegexOptions.IgnoreCase);
                if (comboBoxILRL.Text == "IL")
                {
                    il[curPort].Text = tmp[0];
                    ILs[timerCount] = float.Parse(Tools.killdB(tmp[0]));
                    if (timerCount == ILs.Length - 1) {
                        float tt = Tools.getMin(ILs);
                        il[curPort].Text = tt + "dB";
                        fbt.IL[curPort - 1] = tt;
                    }
                }
                else {
                    rl[curPort].Text = tmp[0];
                    //fbt.RL[curPort - 1] = Tools.killdB(tmp[0]);
                    RLs[timerCount] = float.Parse(Tools.killdB(tmp[0]));
                    if (timerCount == RLs.Length - 1) {
                        float tt = Tools.getMin(RLs);
                        rl[curPort].Text = tt + "dB";
                        fbt.RL[curPort - 1] = tt;
                    }
                }
                
            }
            catch (Exception)
            {
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //if (!rs232.IsOpen)
            //    return;

            //rs232.Write(String.Format("SOUR:WAV{0}:{1}?", "1550", comboBoxILRL.Text));
            timer.Enabled = true;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (serialNumber.Text.Trim() == "") {
                MessageBox.Show("请填写SN号");
                return;
            }
            fbt.serialNumber = serialNumber.Text.Trim();
            fbt.batchNumber = batchNumber.Text.Trim();
            fbt.staff = textBoxID.Text.Trim();
            fbt.PortType = comboBoxPortType.Text;
            npoiHelper.dataToExcel(Path.Combine(filePath, serialNumber.Text + ".xls"), fbt);
            /*
           fbtService.addNewFBT(fbt);
           */
        }

        private void comboBoxPortType_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxPort.Items.Clear();
            for (int i = 0; i < comboBoxPortType.SelectedIndex + 2; i++)
            {
                comboBoxPort.Items.Add(i + 1);
            }
        }

        private void comboBoxPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            curPort = comboBoxPort.SelectedIndex + 1;
        }


    }
}
