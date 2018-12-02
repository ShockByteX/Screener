namespace Screener.GUI.Forms
{
    partial class NotifyIconForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifyIconForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiCapture = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiCaptureScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiCaptureArea = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiCaptureWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsNotifyIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.cmsNotifyIcon;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Screener";
            this.notifyIcon.Visible = true;
            // 
            // cmsNotifyIcon
            // 
            this.cmsNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiCapture,
            this.cmsiQuit});
            this.cmsNotifyIcon.Name = "cmsNotifyIcon";
            this.cmsNotifyIcon.Size = new System.Drawing.Size(181, 70);
            // 
            // cmsiCapture
            // 
            this.cmsiCapture.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiCaptureScreen,
            this.cmsiCaptureArea,
            this.cmsiCaptureWindow});
            this.cmsiCapture.Name = "cmsiCapture";
            this.cmsiCapture.Size = new System.Drawing.Size(180, 22);
            this.cmsiCapture.Text = "Capture";
            // 
            // cmsiCaptureScreen
            // 
            this.cmsiCaptureScreen.Name = "cmsiCaptureScreen";
            this.cmsiCaptureScreen.Size = new System.Drawing.Size(180, 22);
            this.cmsiCaptureScreen.Text = "Screen";
            // 
            // cmsiCaptureArea
            // 
            this.cmsiCaptureArea.Name = "cmsiCaptureArea";
            this.cmsiCaptureArea.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.End)));
            this.cmsiCaptureArea.Size = new System.Drawing.Size(180, 22);
            this.cmsiCaptureArea.Text = "Area";
            // 
            // cmsiCaptureWindow
            // 
            this.cmsiCaptureWindow.Name = "cmsiCaptureWindow";
            this.cmsiCaptureWindow.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.End)));
            this.cmsiCaptureWindow.Size = new System.Drawing.Size(180, 22);
            this.cmsiCaptureWindow.Text = "Window";
            // 
            // cmsiQuit
            // 
            this.cmsiQuit.Name = "cmsiQuit";
            this.cmsiQuit.Size = new System.Drawing.Size(180, 22);
            this.cmsiQuit.Text = "Quit Screener";
            // 
            // NotifyIconForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(310, 263);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotifyIconForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screener";
            this.cmsNotifyIcon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip cmsNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem cmsiQuit;
        private System.Windows.Forms.ToolStripMenuItem cmsiCapture;
        private System.Windows.Forms.ToolStripMenuItem cmsiCaptureScreen;
        private System.Windows.Forms.ToolStripMenuItem cmsiCaptureArea;
        private System.Windows.Forms.ToolStripMenuItem cmsiCaptureWindow;
    }
}