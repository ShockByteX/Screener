using Screener.Helpers;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Screener.GUI.Forms
{
    public partial class WindowForm : Form
    {
        public WindowForm()
        {
            InitializeComponent();
            ddWindows.DropDown += (s, e) =>
            {
                ddWindows.Items.Clear();
                foreach (Process process in Process.GetProcesses())
                {
                    if (!string.IsNullOrEmpty(process.MainWindowTitle) && process.MainWindowHandle != IntPtr.Zero) ddWindows.Items.Add(new ProcessWrapper(process));
                }
            };
        }
        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (!(ddWindows.SelectedItem is ProcessWrapper))
            {
                MessageBox.Show("Select window first.", "Screener", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            new PreviewForm(CaptureHelper.Capture(((ProcessWrapper)ddWindows.SelectedItem).Process.MainWindowHandle)).Show();
            Close();
        }
        private class ProcessWrapper
        {
            public readonly Process Process;
            public ProcessWrapper(Process process) => Process = process;
            public override string ToString() => $"[{Process.Id}] {Process.MainWindowTitle}";
        }
    }
}