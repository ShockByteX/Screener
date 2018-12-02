namespace Screener.GUI.Forms
{
    partial class WindowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowForm));
            this.ddWindows = new System.Windows.Forms.ComboBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ddWindows
            // 
            this.ddWindows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddWindows.FormattingEnabled = true;
            this.ddWindows.Location = new System.Drawing.Point(8, 8);
            this.ddWindows.Name = "ddWindows";
            this.ddWindows.Size = new System.Drawing.Size(300, 21);
            this.ddWindows.TabIndex = 0;
            // 
            // btnCapture
            // 
            this.btnCapture.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapture.Location = new System.Drawing.Point(8, 35);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(300, 22);
            this.btnCapture.TabIndex = 9;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // WindowForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(314, 65);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.ddWindows);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WindowForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screener - Select Window";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ddWindows;
        private System.Windows.Forms.Button btnCapture;
    }
}