using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace jmILRL.UI
{
    /// <summary>
    /// 定义代理：翻页用
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    public delegate void EventPagingHandler(EventPagingArg e);

    /// <summary>
    /// 分页控件
    /// </summary>
    public partial class PagerEx : UserControl
    {
        //Button[] btn = new Button[6];
        Sysbtn[] btn = new Sysbtn[6];

        public PagerEx()
        {
            InitializeComponent();
            BtnInit();
            this.BackColor = Color.FromArgb(0xfa, 0xfb, 0xfd);
        }

        private Color txtColor = Color.FromArgb(0x5d, 0x5d, 0x5d);
        /// <summary>
        /// 默认txt颜色
        /// </summary>
        [Description("默认txt颜色")]
        [Category("外观")]
        public Color TxtColor
        {
            get { return txtColor; }
            set { txtColor = value; }
        }

        private Color focusTxtColor = Color.Black;
        [Description("鼠标按下颜色")]
        [Category("外观")]
        public Color FocusTxtColor
        {
            get { return focusTxtColor; }
            set { focusTxtColor = value; }
        }

        /// <summary>
        /// 初始化按键标签
        /// </summary>
        /// <param name="pages"></param>
        public void BtnInit()
        {
            int count = _pageCount > 6 ? 6 : _pageCount;
            //btn = new Button[count];
            btn = new Sysbtn[count];
            panelbtn.Controls.Clear();
            //右对齐显示
            if (btn.Length > 0)
            {
                panelbtn.Location = new Point(187 - 25 * (btn.Length), 2);
                panelbtn.Width = btn.Length * 25;
            }
            for (int i = 0; i < btn.Length; i++)
            {

                btn[i] = new Sysbtn();
                btn[i].Text = (i + 1).ToString();
                btn[i].Size = new Size(25, 20);

                btn[i].Location = new Point(25 * i, 2);
                btn[i].BackColor = this.BackColor;
                btn[i].EnterColor = Color.FromArgb(0xe5, 0xe5, 0xe5);
                btn[i].ClickColor = this.BackColor;

                btn[i].ForeColor = Color.FromArgb(0,0,0);
                btn[i].Font = this.Font;
                btn[i].Click += btn_Click;

                panelbtn.Controls.Add(btn[i]);
            }

            /*
            for (int i = btn.Length - 1; i >= 0; i--)
            {
                //btn[i] = new Button();
                btn[i] = new Sysbtn();
                btn[i].Text = (i + 1).ToString();
                btn[i].Size = new Size(25, 20);
                btn[i].Location = new Point(187  - 25 * (btn.Length - i), 4);

                //7-27
                btn[i].BackColor = this.BackColor;
                btn[i].EnterColor = Color.FromArgb(0xe5, 0xe5, 0xe5);
                btn[i].ClickColor = this.BackColor;

                btn[i].ForeColor = Color.FromArgb(0x5d, 0x5d, 0x5d);
                btn[i].Click += btn_Click;

                panelbtn.Controls.Add(btn[i]);
                //this.Controls.Add(btn[i]);
            }
            */


            if (btn.Length > 1) { 
                btn[0].ForeColor = Color.FromArgb(34, 144, 235);
                labelnext.Enabled = true;
                labelpre.Location = new Point(panelbtn.Location.X - 15, labelpre.Location.Y);
            }
            //只有一页时不显示前后翻页
            if (PageCount <= 1)
            {
                labelpre.Visible = false;
                labelnext.Visible = false;
            }
            else
            {
                labelpre.Visible = true;
                labelnext.Visible = true;
            }
        }

        /// <summary>
        /// 点击标签，选择页码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e)
        {
            Button label = sender as Button;
            int click = int.Parse(label.Text);
            if (click == _pageCurrent) return;
            _pageCurrent = click;
            
            if (this.EventPaging != null)
            {
                this.EventPaging(new EventPagingArg(this.PageCurrent));
            }
            for (int i = 0; i < btn.Length; i++)
            {
                if (!btn[i].Equals(label))
                {
                    btn[i].ForeColor = focusTxtColor;
                }
                else {
                    btn[i].ForeColor = Color.FromArgb(34, 144, 235);
                }
            }
        }

        /// <summary>
        /// 页数改变事件
        /// </summary>
        [Description("页数改变事件")]
        [CategoryAttribute("事件")]
        public event EventPagingHandler EventPaging;

        /// <summary>
        /// 每页显示记录数
        /// </summary>
        private int _pageSize = 15;
        /// <summary>
        /// 每页显示记录数
        /// </summary>
        [Description("获取或设置每页显示条数")]
        [CategoryAttribute("属性")]
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value;
                GetPageCount();
            }
        }

        private int _nMax = 0;
        /// <summary>
        /// 总记录数
        /// </summary>
        public int NMax
        {
            get { return _nMax; }
            set
            {
                _nMax = value;
                GetPageCount();
            }
        }

        private int _pageCount = 0;
        /// <summary>
        /// 页数=总记录数/每页显示记录数
        /// </summary>
        public int PageCount
        {
            get { return _pageCount; }
            set {
                _pageCount = value;
                this.labelTotal.Text = "共" + _pageCount + "页";
            }
        }

        private int _pageCurrent = 0;
        /// <summary>
        /// 当前页号
        /// </summary>
        public int PageCurrent
        {
            get { return _pageCurrent; }
            set { _pageCurrent = value; }
        }
        private void GetPageCount()
        {
            if (this.NMax > 0)
            {
                this.PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.NMax) / Convert.ToDouble(this.PageSize)));
            }
            else
            {
                this.PageCount = 0;
            }
        }

        /// <summary>
        /// 生成数据页按键
        /// </summary>
        /// <param name="pageIndex">当前页码值</param>
        /// <param name="pageCount">总的页数</param>
        /// <returns></returns>
        public void GetPageBar(int pageIndex, int pageCount)
        {
            if (pageCount == 1)
            {
                return ;
            }
            int start = pageIndex - 5;//起始位置
            if (start < 1)
            {
                start = 1;
            }
            int end = start + 5;//终止位置
            if (end > pageCount)
            {
                end = pageCount;
            }

            for (int i = start; i <= end; i++)
            {
                btn[i - start].Text = i.ToString();
                if (i != _pageCurrent)
                {
                    btn[i - start].ForeColor = Color.Black;
                }
                else
                {
                    btn[i - start].ForeColor = Color.FromArgb(34, 144, 235);
                }
            }

        }
        /// <summary>
        /// 翻页控件数据绑定的方法
        /// </summary>
        public void Bind()
        {
            if (this.EventPaging != null)
            {
                //this.NMax = this.EventPaging(new EventPagingArg(this.PageCurrent));
                this.EventPaging(new EventPagingArg(this.PageCurrent));
            }

            if (this.PageCurrent > this.PageCount)
            {
                this.PageCurrent = this.PageCount;
            }
            if (this.PageCount == 1)
            {
                this.PageCurrent = 1;
            }

            this.labelTotal.Text = "共" + PageCount + "页";

            if (this.PageCurrent == 1)
            {
                //this.btnPrev.Enabled = false;
                //this.btnFirst.Enabled = false;
                labelpre.Enabled = false;
            }
            else
            {
                //btnPrev.Enabled = true;
                //btnFirst.Enabled = true;
                labelpre.Enabled = true;
            }

            if (this.PageCurrent == this.PageCount)
            {
                //this.btnLast.Enabled = false;
                //this.btnNext.Enabled = false;
                labelnext.Enabled = false;
            }
            else
            {
                //btnLast.Enabled = true;
                //btnNext.Enabled = true;
                labelnext.Enabled = true;
            }
            /*
            if (this.NMax == 0)
            {
                //btnNext.Enabled = false;
                //btnLast.Enabled = false;
                //btnFirst.Enabled = false;
                //btnPrev.Enabled = false;
                labelpre.Enabled = false;
                labelnext.Enabled = false;
            }
            */
            GetPageBar(_pageCurrent, _pageCount);
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelnext_Click(object sender, EventArgs e)
        {
            this.PageCurrent += 1;
            if (PageCurrent > PageCount)
            {
                PageCurrent = PageCount;
            }
            //绑定
            Bind();
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelpre_Click(object sender, EventArgs e)
        {
            PageCurrent -= 1;
            if (PageCurrent <= 0)
            {
                PageCurrent = 1;
            }
            //绑定
            Bind();
        }
    }

    /// <summary>
    /// 自定义事件数据基类
    /// </summary>
    public class EventPagingArg : EventArgs
    {
        private int _intPageIndex;

        public int IntPageIndex
        {
            get { return _intPageIndex; }
            set { _intPageIndex = value; }
        }


        public EventPagingArg(int PageIndex)
        {
            _intPageIndex = PageIndex;
        }
    }
}
