using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Screener.GUI.Forms
{
    public partial class SnippingForm : Form
    {
        private Rectangle _rect;
        private Point _point;
        private Pen _pen = new Pen(new SolidBrush(Color.Red), 2);
        private bool _snippingMode = false;
        public SnippingForm(Screen screen)
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            Location = screen.Bounds.Location;
            Size = screen.Bounds.Size;
            WindowState = FormWindowState.Maximized;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            _rect = new Rectangle(0, 0, 0, 0);
            _point = new Point(e.X, e.Y);
            _snippingMode = true;
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (!_snippingMode) return;
            _snippingMode = false;
            if (_rect.Width < 4 || _rect.Height < 4) return;
            _rect.X += Location.X;
            _rect.Y += Location.Y;
            AreaSelected?.Invoke(_rect);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!_snippingMode) return;
            if (e.X > _point.X)
            {
                _rect.X = _point.X;
                _rect.Width = e.X - _point.X;
            }
            else
            {
                _rect.X = e.X;
                _rect.Width = _point.X - e.X;
            }
            if (e.Y > _point.Y)
            {
                _rect.Y = _point.Y;
                _rect.Height = e.Y - _point.Y;
            }
            else
            {
                _rect.Y = e.Y;
                _rect.Height = _point.Y - e.Y;
            }
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.FillRectangle(new SolidBrush(Color.Transparent), new Rectangle(Location.X, Location.Y, Width, Height));
            graphics.DrawRectangle(_pen, _rect);
        }
        public event Action<Rectangle> AreaSelected;
    }
}