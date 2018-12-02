using System;
using System.Threading;
using System.Windows.Forms;
using Screener.GUI.Forms;

namespace Screener
{
    static class Program
    {
        public const string APP_NAME = "Screener";
        private const string MTX_INSTANCE_NAME = "MTX_APP_SCREENER";
        [STAThread]
        static void Main()
        {
            try
            {
                Mutex.OpenExisting(MTX_INSTANCE_NAME);
                MessageBox.Show("Application is already running.", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            catch
            {
                new Mutex(true, MTX_INSTANCE_NAME);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new NotifyIconForm());
            }
        }
    }
}