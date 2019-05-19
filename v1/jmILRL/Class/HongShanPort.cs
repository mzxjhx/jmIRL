using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace jmILRL.Class
{
    public class HongShanPort : Base232
    {
        /// <summary>
        /// 红杉设备通讯连接命令
        /// </summary>
        private byte[] Con = new byte[]
        {
            0x61,0x03,0x01,0x9b,0x01
        };

        /// <summary>
        /// 断开串口连接
        /// </summary>
        private byte[] Off = new byte[]
        {
            0x61,0x03,0xf0,0xca,0x01
        };

        /// <summary>
        /// 获取数据
        /// </summary>
        //private byte[] GetData = new byte[]
        //{
        //    0x61,0x03,0x50,0x4c,0x01
        //};

        private byte[] GetData = new byte[]
        {
            0x61,0x03,0x0d,0x8f,0x01
        };

        public HongShanPort() {

            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Parity = Parity.None;
            _serialPort.ReadBufferSize = 50;
            _serialPort.BaudRate = 38400;
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
        }

        public HongShanPort(int baudrate) {
            _serialPort.StopBits = StopBits.One;
            _serialPort.Parity = Parity.None;
            _serialPort.ReadBufferSize = 50;
            _serialPort.BaudRate = baudrate;
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
        }

        public override void Open()
        {
            if (!_serialPort.IsOpen)
            {
                _serialPort.Open();
                System.Threading.Thread.Sleep(200);
                BeginToConnect();
            }
        }

        public override void Close()
        {
            _serialPort.Close();
        }


        public override void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int length = _serialPort.BytesToRead;
            byte[] rxdata = new byte[length];
            _serialPort.Read(rxdata, 0, length);
            base.EventHandler(rxdata);
        }

        public override void Write()
        {
            HongShanProtical();
        }

        public override void Write(string ss)
        {
            _serialPort.Write(ss);
        }

        public override void Write(byte[] rx)
        {
            _serialPort.Write(rx, 0, rx.Length);
        }

        /// <summary>
        /// 鸿珊设备先要连接
        /// </summary>
        public void BeginToConnect()
        {
            _serialPort.Write(Con, 0, Con.Length);
        }

        public void ConnectOFF()
        {
            _serialPort.Write(Off, 0, Off.Length);
        }

        public void HongShanProtical()
        {
            _serialPort.Write(GetData, 0, GetData.Length);
        }
    }
}
