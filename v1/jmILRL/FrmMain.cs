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

namespace jmILRL
{
    public partial class FrmMain : FrmBase
    {
        Rs232 rs232 = new Rs232();
        /// <summary>
        /// 文件保存路径
        /// </summary>
        string filePath = "";
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

        private Label[] il = new Label[4];
        private Label[] rl = new Label[4];

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
        }

        /// <summary>
        /// 
        /// </summary>
        private void PortInit()
        {
            string[] portnames = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string item in portnames)
            {
                
            }
            if (portnames.Length == 0)
            {

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
                    il[0].Text = tmp[0];
                else
                    rl[0].Text = tmp[0];
            }
            catch (Exception)
            {
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (!rs232.IsOpen)
                return;
            
            rs232.Write(String.Format("SOUR:WAV{0}:{1}?", "1550", comboBoxILRL.Text));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            /*
            npoiHelper.dataToExcel(Path.Combine(filePath,serialNumber+ ".xls"), fbt);
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
    }
}
