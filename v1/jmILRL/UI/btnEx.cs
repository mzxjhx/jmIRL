using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using jmILRL.common;
namespace jmILRL.UI
{
    /// <summary>
    /// 系统关闭按键
    /// </summary>
    public class btnEx : Button
    {


        private MouseActionType mouseAction;

        private string _title = "title";
        /// <summary>
        /// 
        /// </summary>
        [Description("获取或设置标题")]
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
            }
        }

        private Color _baseColor = Color.DodgerBlue;

        private Color _clickColor = Color.FromArgb(255, 0, 0);
        [Description("鼠标按下颜色")]
        [Category("外观")]
        public Color ClickColor
        {
            get { return _clickColor; }
            set { _clickColor = value; }
        }

        private Color _enterColor = Color.Red;
        [Description("鼠标进入色")]
        [Category("外观")]
        public Color EnterColor
        {
            get { return _enterColor; }
            set { _enterColor = value; }
        }

        public btnEx()
        {
            //InitializeComponent();
            mouseAction = MouseActionType.None;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.Opaque, false);
            this.Width = 20;
            this.Height = 20;
        }


        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.CompositingQuality = CompositingQuality.HighQuality;

            Color clr = this.BackColor;
            switch (mouseAction)
            {
                case MouseActionType.None:
                    using (SolidBrush sb = new SolidBrush(BackColor))
                    {
                        g.FillRectangle(sb, this.ClientRectangle);
                    }
                    break;
                case MouseActionType.Hover:
                    using (SolidBrush sb = new SolidBrush(_enterColor))
                    {
                        g.FillRectangle(sb, this.ClientRectangle);
                    }
                    break;
                case MouseActionType.Click:
                    using (SolidBrush sb = new SolidBrush(_clickColor))
                    {
                        g.FillRectangle(sb, this.ClientRectangle);
                    }
                    break;


                default:
                    break;
            }
            if (Image != null)
                g.DrawImage(this.Image, new Rectangle((this.Width - Image.Width) / 2, (this.Height - Image.Height) / 2, Image.Width, Image.Height));

            using (Pen pen = new Pen(Color.White, 2f))
            {
                g.DrawLine(pen, new Point(4, 4), new Point(Width - 4, Height - 4));
                g.DrawLine(pen, new Point(Width - 4, 4), new Point(4, Height - 4));
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.mouseAction = MouseActionType.Click;
                this.Invalidate();
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.mouseAction = MouseActionType.Hover;
            this.Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnMouseHover(EventArgs e)
        {
            this.mouseAction = MouseActionType.Hover;
            this.Invalidate();
            base.OnMouseHover(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.mouseAction = MouseActionType.Hover;
            this.Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.mouseAction = MouseActionType.None;
            this.Invalidate();
            base.OnMouseLeave(e);
        }
    }

}


