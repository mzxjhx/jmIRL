using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using jmILRL.common;
using System.Drawing.Drawing2D;
namespace jmILRL
{
    public partial class FrmBase : Form
    {
        /// <summary>
        /// 是否允许最大化
        /// </summary>
        protected bool _isResize = false;
        /// <summary>
        /// 双击窗体最大休
        /// </summary>
        protected bool _isDBMax = false;

        #region 窗体边框阴影效果变量申明
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled;                     // variables for box shadow
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }
        //The WM_NCHITTEST message is sent to a window when the cursor moves, or when a mouse button is pressed
        //private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        public FrmBase()
        {
            m_aeroEnabled = false;
            InitializeComponent();
            //this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
        }


        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }


        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }
        #endregion
        /// <summary>
        /// 拖动窗口大小
        /// </summary>
        /// <param name="m"></param>
        private void WmNcHitTest(ref Message m)
        {
            /*
            if (this.WindowState != FormWindowState.Maximized)
            {
                int wparam = m.LParam.ToInt32();

                Point point = new Point(
                    wparam & 0xffff,
                    wparam >> 16);
                point = PointToClient(point);
                base.WndProc(ref m);
            }
            */
            if (this.WindowState != FormWindowState.Maximized)
            {
                int wparam = m.LParam.ToInt32();

                Point point = new Point(
                    wparam & 0xffff,
                    wparam >> 16);

                point = PointToClient(point);
                if (_isResize)
                {
                    //if (point.X <= 3)
                    //{
                    //    if (point.Y <= 3)
                    //        m.Result = (IntPtr)WM_NCHITTEST.HTTOPLEFT;
                    //    else if (point.Y > Height - 3)
                    //        m.Result = (IntPtr)WM_NCHITTEST.HTBOTTOMLEFT;
                    //    else
                    //        m.Result = (IntPtr)WM_NCHITTEST.HTLEFT;
                    //}
                    if (point.X >= Width - 5)
                    {
                        if (point.Y <= 3)
                            m.Result = (IntPtr)WM_NCHITTEST.HTTOPRIGHT;
                        else if (point.Y >= Height - 3)
                            m.Result = (IntPtr)WM_NCHITTEST.HTBOTTOMRIGHT;
                        else
                            m.Result = (IntPtr)WM_NCHITTEST.HTRIGHT;
                    }
                    //else if (point.Y <= 3)
                    //{
                    //    m.Result = (IntPtr)WM_NCHITTEST.HTTOP;
                    //}
                    else if (point.Y >= Height - 5)
                    {
                        m.Result = (IntPtr)15;
                    }
                    else
                    {
                        base.WndProc(ref m);
                    }
                }
                else
                {
                    base.WndProc(ref m);
                }

            }

        }

        protected override void WndProc(ref Message m)
        {

            switch (m.Msg)
            {
                case WM_NCPAINT:                        // box shadow
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 1,
                            rightWidth = 1,
                            topHeight = 1
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);

                    }
                    break;

                case (int)WindowsMessage.WM_NCHITTEST:
                    base.WndProc(ref m);
                    this.WmNcHitTest(ref m);
                    break;

                case 0xa3:  //dbclick
                    if (_isDBMax)
                        base.WndProc(ref m);
                    return;

                default:

                    base.WndProc(ref m);
                    break;
            }

            //2017-9-1 屏蔽
            //base.WndProc(ref m);

            if (m.Msg == (int)WindowsMessage.WM_NCHITTEST && (int)m.Result == HTCLIENT)     // drag the form
                m.Result = (IntPtr)HTCAPTION;

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            Graphics g = e.Graphics;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.High;
            g.SmoothingMode = SmoothingMode.HighQuality;
            using(Pen pen = new Pen(Color.FromArgb(150, 0,0,0),0.5f))
	        {
                g.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
	        }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }

    }


}
