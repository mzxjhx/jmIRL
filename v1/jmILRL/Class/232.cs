using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
//using FormUI;
using System.Windows.Forms;
using jmILRL.Class;

namespace RS232
{
    /// <summary>
    /// 串口通讯
    /// </summary>
    public class Rs232
    {
        Button _btn = new Button();
        bool _finish = false;

        Timer _timer = new Timer();
        bool _enable = false;
        int _times = 5;



        /// <summary>
        /// 是否开启定时发送
        /// </summary>
        public bool Enable
        {
            get { return _enable; }
            set
            {
                _enable = value;
                _timer.Enabled = value;
            }
        }
        /// <summary>
        /// 定时时间隔
        /// </summary>
        public int Times
        {
            get { return _times; }
            set
            {
                _times = value;
                _timer.Interval = value * 1000;
            }
        }

        /// <summary>
        /// 一次命令发送是否成功
        /// </summary>
        public bool Finish
        {
            set { _finish = value; }
            get { return _finish; }
        }

        private SerialPort _serialPort = new SerialPort();

        private string _com = "COM1";
        /// <summary>
        /// 设置通讯COM口
        /// </summary>
        public string Com
        {
            get { return _com; }
            set
            {
                _com = value;
                _serialPort.PortName = value;
            }
        }

        /// <summary>
        /// 波特率
        /// </summary>
        public int BaudRate
        {
            get { return _baudRate; }
            set { _baudRate = value; }
        }

        public bool IsOpen
        {
            get { return this._serialPort.IsOpen; }
        }

        public Rs232()
        {
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Parity = Parity.None;
            _serialPort.ReadBufferSize = 50;
            _serialPort.BaudRate = _baudRate;
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);

            _timer.Interval = _times;
            _timer.Enabled = _enable;
            _timer.Tick += new EventHandler(_timer_Tick);

        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="com">COM端口</param>
        /// <param name="baudRate">波特率</param>
        public Rs232(string com, int baudRate)
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = com;
            _serialPort.BaudRate = _baudRate;

        }

        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            int length = _serialPort.BytesToRead;
            byte[] rxdata = new byte[length];
            _serialPort.Read(rxdata, 0, length);
            if (OnCallBack != null)
            {
                OnCallBack(rxdata);
            }
        }

        #region Event

        /// <summary>
        /// 获得回传数据
        /// </summary>
        public event OnRecHandler OnCallBack;

        #endregion

        public void Open()
        {
            if (!_serialPort.IsOpen)
                _serialPort.Open();
        }

        public void Close()
        {
            _serialPort.Close();
        }

        /// <summary>
        /// 串口开关操作
        /// </summary>
        public void Run()
        {
            try
            {
                if (!_serialPort.IsOpen)
                {
                    _serialPort.Open();
                    this._btn.Text = "关闭串口";
                    Enable = true;
                }
                else
                {
                    _serialPort.Close();
                    this._btn.Text = "打开串口";
                    if (Enable == true)
                        Enable = false;
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 定时发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _timer_Tick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 发送命令
        /// </summary>
        /// <param name="ss"></param>
        public void Write(string ss)
        {
            _serialPort.Write(ss + "\r\n");
        }

        /// <summary>
        /// 发送命令
        /// </summary>
        /// <param name="ss"></param>
        /// <param name="j"></param>
        public void Write(byte[] rx)
        {
            _serialPort.Write(rx, 0, rx.Length);
        }

    }
}

