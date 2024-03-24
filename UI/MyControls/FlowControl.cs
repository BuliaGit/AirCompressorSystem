using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace UI
{
    public partial class FlowControl : UserControl
    {
        public FlowControl()
        {
            InitializeComponent();
            //防止控件闪烁
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            Timer mytimer = new Timer();
            mytimer.Interval = 500;
            mytimer.Tick += mytimer_Tick;
            mytimer.Enabled = true;
        }

        void mytimer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private Graphics g;
        private int width;
        private int height;

        //定义是否流动
        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        //定义流动颜色
        private Color runColor = Color.FromArgb(128, 128, 255);
        public Color RunColor
        {
            get { return runColor; }
            set { runColor = value; }
        }

        //定义开始颜色
        private Color startColor = Color.FromArgb(73, 73, 73);
        public Color StartColor
        {
            get { return startColor; }
            set { startColor = value; }
        }

        //定义结束颜色
        private Color endColor = Color.FromArgb(247, 247, 247);
        public Color EndColor
        {
            get { return endColor; }
            set { endColor = value; }
        }

        //定义流动条长度
        private int length = 10;
        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        //定义流动条宽度占比
        private double extent = 0.75;
        public double Extent
        {
            get { return extent; }
            set { extent = value; }
        }

        //定义流动条间距
        private int space = 5;
        public int Space
        {
            get { return space; }
            set { space = value; }
        }

        //定义流动速度
        private int speed = 5;
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        //定义水平或者竖直
        private bool isVertical = false;
        public bool IsVertical
        {
            get { return isVertical; }
            set { isVertical = value; }
        }

        //定义流动状态  1：从左到右  2：从右到左  3：从上到下  4：从下到上
        private int flowNum = 1;
        public int FlowNum
        {
            get { return flowNum; }
            set { flowNum = value; }
        }

        int X;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.SmoothingMode = SmoothingMode.HighQuality;
            width = this.Width;
            height = this.Height;

            //绘制第一步：绘制渐变色外框
            if (isVertical == false)//水平
            {
                if (height % 2 == 0)
                {
                    //[1]先画上半部分
                    LinearGradientBrush brush;
                    RectangleF rec1 = new RectangleF(0, 0, width, (float)(height / 2));
                    brush = new LinearGradientBrush(rec1, startColor, endColor, LinearGradientMode.Vertical);
                    //[2]再画下半部分
                    g.FillRectangle(brush, rec1);
                    RectangleF rec2 = new RectangleF(0, (float)((height / 2) - 0.5), width, (float)((height / 2) + 0.5));
                    brush = new LinearGradientBrush(rec2, endColor, startColor, LinearGradientMode.Vertical);
                    g.FillRectangle(brush, rec2);
                }
                else
                {
                    //[1]先画上半部分
                    LinearGradientBrush brush;
                    RectangleF rec1 = new RectangleF(0, 0, width, (float)(height / 2));
                    brush = new LinearGradientBrush(rec1, startColor, endColor, LinearGradientMode.Vertical);
                    //[2]再画下半部分
                    g.FillRectangle(brush, rec1);
                    RectangleF rec2 = new RectangleF(0, (float)((height / 2) - 0.5), width, (float)((height / 2) + 0.5));
                    brush = new LinearGradientBrush(rec2, endColor, startColor, LinearGradientMode.Vertical);
                    g.FillRectangle(brush, rec2);

                }
            }
            else//垂直
            {
                if (width / 2 == 0)
                {
                    //[1]先画左半部分
                    LinearGradientBrush brush;
                    RectangleF rec1 = new RectangleF(0, 0, (float)(width / 2), height);
                    brush = new LinearGradientBrush(rec1, startColor, endColor, LinearGradientMode.Horizontal);
                    //[2]再画右半部分
                    g.FillRectangle(brush, rec1);
                    RectangleF rec2 = new RectangleF((float)((width / 2) - 0.5), 0, (float)((width / 2) + 0.5), height);
                    brush = new LinearGradientBrush(rec2, endColor, startColor, LinearGradientMode.Horizontal);
                    g.FillRectangle(brush, rec2);
                }
                else
                {
                    //[1]先画左半部分
                    LinearGradientBrush brush;
                    RectangleF rec1 = new RectangleF(0, 0, (float)(width / 2), height);
                    brush = new LinearGradientBrush(rec1, startColor, endColor, LinearGradientMode.Horizontal);
                    //[2]再画右半部分
                    g.FillRectangle(brush, rec1);
                    RectangleF rec2 = new RectangleF((float)((width / 2) - 0.5), 0, (float)((width / 2) + 0.5), height);
                    brush = new LinearGradientBrush(rec2, endColor, startColor, LinearGradientMode.Horizontal);
                    g.FillRectangle(brush, rec2);

                }

            }
            //第二步：绘制流动条
            SolidBrush sb;
            switch (FlowNum)
            {
                case 1:
                    if (isActive)
                    {
                        sb = new SolidBrush(RunColor);
                        int LS = Length + Space;
                        if (X > ((Length + Space) / Speed))
                        {
                            X = 0;
                        }
                        for (int i = 0; i < width / LS; i++)//i决定总共能容纳多少个流动条
                        {
                            int recheight = Convert.ToInt32(((1 - Extent) / 2) * height);
                            g.FillRectangle(sb, LS * i + Speed * X, recheight, Length, (int)(height * Extent));
                        }
                        X++;
                    }
                    break;
                case 2:
                    if (isActive)
                    {
                        sb = new SolidBrush(RunColor);
                        int LS = Length + Space;
                        if (X > ((Length + Space) / Speed))
                        {
                            X = 0;
                        }
                        for (int i = 0; i < width / LS; i++)//i决定总共能容纳多少个流动条
                        {
                            int recheight = Convert.ToInt32(((1 - Extent) / 2) * height);
                            g.FillRectangle(sb, (width - Length) - LS * i - Speed * X, recheight, Length, (int)(height * Extent));
                        }
                        X++;
                    }
                    break;
                case 3:
                    if (isActive)
                    {
                        sb = new SolidBrush(RunColor);
                        int LS = Length + Space;
                        if (X > ((Length + Space) / Speed))
                        {
                            X = 0;
                        }
                        for (int i = 0; i < height / LS; i++)//i决定总共能容纳多少个流动条
                        {
                            int recwidth = Convert.ToInt32(((1 - Extent) / 2) * width);
                            g.FillRectangle(sb, recwidth, LS * i + Speed * X, (int)(width * Extent), Length);
                        }
                        X++;
                    }
                    break;
                case 4:
                    if (isActive)
                    {
                        sb = new SolidBrush(RunColor);
                        int LS = Length + Space;
                        if (X > ((Length + Space) / Speed))
                        {
                            X = 0;
                        }
                        for (int i = 0; i < height / LS; i++)//i决定总共能容纳多少个流动条
                        {
                            int recwidth = Convert.ToInt32(((1 - Extent) / 2) * width);
                            g.FillRectangle(sb, recwidth, (height - length) - LS * i - Speed * X, (int)(width * Extent), Length);
                        }
                        X++;
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
