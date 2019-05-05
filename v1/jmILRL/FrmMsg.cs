using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace jmILRL
{
    public partial class FrmMsg : FrmBase
    {
        public FrmMsg()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// 消息框标题
        /// </summary>
        public string Title {
            get { return this.label1.Text; }
            set { this.label1.Text = value; }
        }
        /// <summary>
        /// 提示框要显示的内容
        /// </summary>
        public string Message {
            get { return this.label2.Text; }
            set { this.label2.Text = value; }
        }
    }
}
