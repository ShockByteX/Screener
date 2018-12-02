using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Screener.GUI.Forms
{
    public partial class PreviewForm : Form
    {
        private Bitmap _bitmap;
        public PreviewForm(Bitmap bitmap)
        {
            InitializeComponent();
            _bitmap = bitmap;
            pbPreview.Image = _bitmap;
            Text = $"Screener - Preview ({_bitmap.Width}x{_bitmap.Height})";
            btnSave.Click += btnSave_Click;
            FormClosing += PreviewForm_FormClosing;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dlgSaveFile.ShowDialog() != DialogResult.OK) return;
            _bitmap.Save(dlgSaveFile.FileName, IndexToImageFormat(dlgSaveFile.FilterIndex));
        }
        private ImageFormat IndexToImageFormat(int index)
        {
            Console.WriteLine(index);
            switch (index)
            {
                case 1: return ImageFormat.Jpeg;
                case 2: return ImageFormat.Png;
                default: throw new Exception("Not supported.");
            }
        }
        private void PreviewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _bitmap.Dispose();
        }
    }
}