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

namespace jmILRL
{
    public partial class FrmMain : FrmBase
    {
        Rs232 rs232 = new Rs232();
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
                richTextBox1.AppendText("未检测到串口\r\n");
            }
            else {
                try
                {
                    rs232.Com = portnames[0];
                    rs232.Open();
                    richTextBox1.AppendText("串口打开\r\n");
                }
                catch (Exception ex)
                {
                    richTextBox1.AppendText(ex.Message + "\r\n");
                }

            }
            
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
                richTextBox1.AppendText(str + "\r\n");

            }
            catch (Exception)
            {
            }
        }


        private void signleButton2_Click(object sender, EventArgs e)
        {
            if (!rs232.IsOpen)
                return;
            rs232.Write("SOUR:PM:WAVE 1550");
            rs232.Write("WAV1550:IL?");
        }

        private void signleButton1_Click(object sender, EventArgs e)
        {
            if (!rs232.IsOpen)
                return;
            rs232.Write(textBox1.Text.Trim());
        }
    }
}
