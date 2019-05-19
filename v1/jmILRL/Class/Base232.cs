using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace jmILRL.Class
{
    /// <summary>
    /// 通讯基类
    /// </summary>
    public abstract class Base232
    {
        protected SerialPort _serialPort = new SerialPort();

        protected string _com = "COM1";
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
            get { return _serialPort.BaudRate; }
            set { _serialPort.BaudRate = value; }
        }

        public bool IsOpen
        {
            get { return this._serialPort.IsOpen; }
        }

        /// <summary>
        /// 事件：处理回传数据
        /// </summary>
        public event OnRecHandler OnCallBack;

        public abstract void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e);
        public abstract void Open();

        public abstract void Close();

        public abstract void Write();
        /// <summary>
        /// 发送命令
        /// </summary>
        /// <param name="ss"></param>
        public abstract void Write(string ss);

        /// <summary>
        /// 发送命令
        /// </summary>
        /// <param name="ss"></param>
        /// <param name="j"></param>
        public abstract void Write(byte[] rx);

        protected void EventHandler(byte[] bs) {
            if (OnCallBack != null)
            {
                OnCallBack(bs);
            }
        }

        
    }

    public delegate void OnRecHandler(byte[] bs);
}
