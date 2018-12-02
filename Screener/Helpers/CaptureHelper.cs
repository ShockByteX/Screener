using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Screener.Native;

namespace Screener.Helpers
{
    public static class CaptureHelper
    {
        public static Bitmap Capture(Screen screen) => Capture(new Rectangle(screen.Bounds.Location, screen.Bounds.Size));
        public static Bitmap Capture(Rectangle rect)
        {
            Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
            using (Graphics g = Graphics.FromImage(bitmap)) g.CopyFromScreen(rect.Location, Point.Empty, rect.Size);
            return bitmap;
        }
        public static Bitmap Capture(IntPtr hWnd)
        {
            User32.GetWindowRect(hWnd, out RECT rect);
            Bitmap bitmap = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                IntPtr hdc = g.GetHdc();
                User32.PrintWindow(hWnd, hdc, 0);
                g.ReleaseHdc();
            }
            return bitmap;
        }
    }
}