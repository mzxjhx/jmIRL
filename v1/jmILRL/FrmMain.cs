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

        private int curPort = 0, totalPort = 2;

        private Label[] labelIL = new Label[4];
        private Label[] labelRL = new Label[4];

        Timer timer = new Timer();
        /// <summary>
        /// 5秒内读10次
        /// </summary>
        private int timerCount = 0;

        private bool flag = false;
        /// <summary>
        /// 10次数组取最值
        /// </summary>
        private float[] ilstmp = new float[10];
        /// <summary>
        /// 10次数组取最值
        /// </summary>
        private float[] rlstmp = new float[10];

        private float ilLevel = 0,rlLevel=0;

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
            PortInit();
            ReadConfig();
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
                    rs232.Write(String.Format("SOUR:WAV{0}:{1}?", "1550", radioButtonIL.Checked ? "IL" : "RL"));
                    if (timerCount == ilstmp.Length - 1)
                        flag = true;
                }
            };

        }

        private void ReadConfig() {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            String sqlcon = config.AppSettings.Settings["connString"].Value;
            filePath = config.AppSettings.Settings["filePath"].Value;
            ilLevel = float.Parse(config.AppSettings.Settings["level_IL"].Value);
            rlLevel = float.Parse(config.AppSettings.Settings["level_RL"].Value);
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
                    labelCom.Text = string.Format("COM：{0}", "已连接");
                }
                catch (Exception ex)
                {
                    labelCom.Text = string.Format("COM：{0}", ex.Message);
                }

            }
            
        }

        private void LabelInit() {
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
        /// </summary>
        /// <param name="bs"></param>
        void Rs232_DataRec(byte[] bs)
        {
            try
            {
                string str = System.Text.Encoding.Default.GetString(bs);
                string[] tmp = Regex.Split(str, "\r\n", RegexOptions.IgnoreCase);
                if (radioButtonIL.Checked)
                {
                    labelIL[curPort].Text = String.Format("IL{0}: {1} dB ",curPort, Tools.killdB(tmp[0]));
                    ilstmp[timerCount++] = float.Parse(Tools.killdB(tmp[0]));
                    //循环次数到
                    if (flag) {
                        flag = !flag;
                        float tt = Tools.getMin(ilstmp);
                        labelIL[curPort].Text = tt + "dB";
                        fbt.IL[curPort] = tt;
                        level.ShowResult = Tools.isBeyond(totalPort, fbt, ilLevel) ? Result.result.failed : Result.result.pass;
                    }
                }
                else {
                    labelRL[curPort].Text = String.Format("RL{0}: {1} dB ", curPort, Tools.killdB(tmp[0]));
                    rlstmp[timerCount++] = float.Parse(Tools.killdB(tmp[0]));
                    //循环次数到
                    if (flag) {
                        flag = !flag;
                        float tt = Tools.getMin(rlstmp);
                        labelRL[curPort].Text = tt + "dB";
                        fbt.RL[curPort] = tt;
                        level.ShowResult = Tools.isBelow(totalPort, fbt, rlLevel) ? Result.result.failed : Result.result.pass;
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
            switch (comboBoxPortType.SelectedIndex)
            {
                case 0:
                    IL3.Text = IL4.Text = "";
                    RL3.Text = RL4.Text = "";
                    totalPort = 2;
                    break;
                case 1:
                    IL4.Text = "";
                    RL4.Text = "";
                    totalPort = 3;
                    break;
                case 2:
                    totalPort = 4;
                    break
                        ;
                default:
                    totalPort = 2;
                    break;
            }
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(155, 0, 155, 0);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
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
