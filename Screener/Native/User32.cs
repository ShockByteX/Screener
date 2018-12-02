using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Screener.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        private int _left, _top, _right, _bottom;
        public int Left { get => _left; set => _left = value; }
        public int Top { get => _top; set => _top = value; }
        public int Right { get => _right; set => _right = value; }
        public int Bottom { get => _bottom; set => _bottom = value; }
        public int X { get => _left; set => _left = value; }
        public int Y { get => _top; set => _top = value; }
        public int Height { get => _bottom - _top; set => _bottom = value + _top; }
        public int Width { get => _right - _left; set => _right = value + _left; }
        public Point Location
        {
            get => new Point(Left, Top);
            set
            {
                _left = value.X;
                _top = value.Y;
            }
        }
        public Size Size
        {
            get => new Size(Width, Height);
            set
            {
                _right = value.Width + _left;
                _bottom = value.Height + _top;
            }
        }
        public RECT(RECT rect) : this(rect.Left, rect.Top, rect.Right, rect.Bottom) { }
        public RECT(int left, int top, int right, int bottom)
        {
            _left = left;
            _top = top;
            _right = right;
            _bottom = bottom;
        }
        public bool Equals(RECT rect) => rect.Left == _left && rect.Top == _top && rect.Right == _right && rect.Bottom == _bottom;
        public override bool Equals(object obj) => obj is RECT ? Equals((RECT)obj) : false;
        public override string ToString() => $"Left: {_left}, Top: {_top}, Right: {_right}, Bottom: {_bottom}";
        public override int GetHashCode() => ToString().GetHashCode();
        public static implicit operator Rectangle(RECT rect) => new Rectangle(rect.Left, rect.Top, rect.Width, rect.Height);
        public static implicit operator RECT(Rectangle rect) => new RECT(rect.Left, rect.Top, rect.Right, rect.Bottom);
        public static bool operator ==(RECT rect1, RECT rect2) => rect1.Equals(rect2);
        public static bool operator !=(RECT rect1, RECT rect2) => !rect1.Equals(rect2);
    }
    public static class User32
    {
        public const string LibraryName = "user32.dll";
        [DllImport(LibraryName)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [DllImport(LibraryName)]
        public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);
    }
}