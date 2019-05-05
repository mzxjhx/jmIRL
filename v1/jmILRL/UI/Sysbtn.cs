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
    /// 自定义背景色Button
    /// </summary>
    public partial class Sysbtn : Button
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

        private Color _clickColor = Color.DarkBlue;
        [Description("鼠标按下颜色")]
        [Category("外观")]
        public Color ClickColor
        {
            get { return _clickColor; }
            set { _clickColor = value; }
        }

        private Color _enterColor = Color.FromArgb(32, 124, 218);
        [Description("鼠标进入色")]
        [Category("外观")]
        public Color EnterColor
        {
            get { return _enterColor; }
            set { _enterColor = value; }
        }

        public Sysbtn()
        {
            //InitializeComponent();
            mouseAction = MouseActionType.None;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.Opaque, false);
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

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            sf.Trimming = StringTrimming.EllipsisCharacter;
            using (Brush b = new SolidBrush(base.ForeColor))
            {
                g.DrawString(base.Text, this.Font, b, ClientRectangle, sf);
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

