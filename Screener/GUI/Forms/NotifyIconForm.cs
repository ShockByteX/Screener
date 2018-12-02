using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Screener.Helpers;

namespace Screener.GUI.Forms
{
    public partial class NotifyIconForm : Form
    {
        private bool _useVisibleCore = false;
        private bool _areaSnippingMode = false;
        private Queue<SnippingForm> _sfQueue = new Queue<SnippingForm>();
        public static Screen SelectedScreen { get; private set; }
        public NotifyIconForm()
        {
            InitializeComponent();
            FormClosing += MainForm_FormClosing;
            cmsNotifyIcon.VisibleChanged += cmsNotifyIcon_VisibleChanged;
            cmsiQuit.Click += (s, e) => Application.Exit();
            cmsiCaptureWindow.Click += (s, e) => new WindowForm().Show();
            cmsiCaptureArea.Click += cmsiCaptureArea_Click;
        }
        //private void ChangeFormVisibility_MouseAction(object sender, MouseEventArgs e)
        //{
        //    if (e.Button != MouseButtons.Left) return;
        //    if (!_useVisibleCore) _useVisibleCore = true;
        //    if (!Visible) UpdateSettings();
        //    Visible = !Visible;
        //}
        private void cmsNotifyIcon_VisibleChanged(object sender, EventArgs e)
        {
            if (cmsNotifyIcon.Visible == true)
            {
                cmsiCaptureScreen.DropDownItems.Clear();
                foreach (Screen screen in Screen.AllScreens) cmsiCaptureScreen.DropDownItems.Add(screen.DeviceName, null, delegate { ShowPreview(CaptureHelper.Capture(screen)); });
            }
        }
        private void cmsiCaptureArea_Click(object sender, EventArgs e)
        {
            if (_areaSnippingMode) return;
            _areaSnippingMode = true;
            foreach (Screen screen in Screen.AllScreens)
            {
                SnippingForm form = new SnippingForm(screen);
                _sfQueue.Enqueue(form);
                form.AreaSelected += SnippingForm_AreaSelected;
                form.Show();
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
        private void SnippingForm_AreaSelected(Rectangle rect)
        {
            while (_sfQueue.Count > 0)
            {
                SnippingForm form = _sfQueue.Dequeue();
                form.AreaSelected -= SnippingForm_AreaSelected;
                form.Close();
            }
            _areaSnippingMode = false;
            ShowPreview(CaptureHelper.Capture(rect));
        }
        private void ShowPreview(Bitmap bitmap) => new PreviewForm(bitmap).Show();
        protected override void SetVisibleCore(bool value) => base.SetVisibleCore(_useVisibleCore ? value : false);
    }
}