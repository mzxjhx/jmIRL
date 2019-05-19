using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace jmILRL.Class
{
    public class ZwdPort : Base232
    {

        public ZwdPort() {
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Parity = Parity.None;
            _serialPort.ReadBufferSize = 50;
            _serialPort.BaudRate = 115200;
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);

        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="com">COM端口</param>
        /// <param name="baudRate">波特率</param>
        public ZwdPort(string com, int baudRate)
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = com;
            _serialPort.BaudRate = baudRate;

        }

        public override void Open()
        {
            if (!_serialPort.IsOpen)
                _serialPort.Open();
        }

        public override void Close()
        {
            _serialPort.Close();
        }
        public override void Write() {

        }
        public override void Write(string ss)
        {
            _serialPort.Write(ss + "\r\n");
        }

        public override void Write(byte[] rx)
        {
            _serialPort.Write(rx, 0, rx.Length);
        }

        public override void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            int length = _serialPort.BytesToRead;
            byte[] rxdata = new byte[length];
            _serialPort.Read(rxdata, 0, length);
            base.EventHandler(rxdata);
        }
    }
}
