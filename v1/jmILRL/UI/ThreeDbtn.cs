using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using jmILRL.common;

namespace jmILRL.UI
{
    /// <summary>
    /// 贴图三态按键，png图片上横向三个状态：正常、划过、按下
    /// </summary>
    public class ThreeDbtn : Button
    {
        public ThreeDbtn()
        {
            base.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.Opaque, false);
        }

        private MouseActionType mouseAction;

        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);
            Graphics g = pevent.Graphics;

            Color clr = this.BackColor;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            //根据鼠标状态选图像区域
            switch (mouseAction)
            {
                case MouseActionType.None:
                    rect = new Rectangle(0, 0, this.Width, this.Height);
                    break;
                case MouseActionType.Hover:
                    rect = new Rectangle(this.Width, 0, this.Width, this.Height);
                    break;
                case MouseActionType.Click:
                    rect = new Rectangle(this.Width * 2, 0, this.Width, this.Height);
                    break;
                default:
                    break;
            }
            using (SolidBrush sb = new SolidBrush(BackColor))
            {
                g.FillRectangle(sb, this.ClientRectangle);
            }
            if (BackgroundImage != null)
            {
                g.DrawImage(BackgroundImage, this.ClientRectangle, rect, GraphicsUnit.Pixel);
            }

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            //sf.Trimming = StringTrimming.EllipsisCharacter;
            using (Brush b = new SolidBrush(base.ForeColor))
            {
                g.DrawString(base.Text, this.Font, b, new Rectangle(this.ClientRectangle.X ,this.ClientRectangle.Y,Width,this.Height + 2), sf);
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
            //this.mouseAction = MouseActionType.Hover;
            this.mouseAction = MouseActionType.None;
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
