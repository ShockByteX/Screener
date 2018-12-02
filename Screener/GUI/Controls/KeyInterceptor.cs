using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Screener.GUI.Controls
{
    public class KeysInfo
    {
        public bool ControlKey { get; set; }
        public bool AltKey { get; set; }
        public bool ShiftKey { get; set; }
        public Keys Key;
        public bool IsValid => Key != Keys.None && (ControlKey || AltKey || ShiftKey);
        public KeysInfo(bool control, bool alt, bool shift, Keys key)
        {
            ControlKey = control;
            AltKey = alt;
            ShiftKey = shift;
            Key = key;
        }
        public override string ToString()
        {
            string text = string.Empty;
            if (ControlKey) text += "CTRL + ";
            if (AltKey) text += "ALT + ";
            if (ShiftKey) text += "SHIFT + ";
            return text + Key;
        }
    }
    public class KeyInterceptor : TextBox
    {
        private bool _intercept;
        private KeysInfo _currentKeys = new KeysInfo(false, false, false, Keys.M);
        [Browsable(true)]
        public KeysInfo KeysInfo { get; set; } = new KeysInfo(false, true, false, Keys.M);
        public KeyInterceptor()
        {
            ReadOnly = true;
            TextAlign = HorizontalAlignment.Center;
            Text = "ALT + F4";
        }
        private void SwitchInterceptionMode(bool value)
        {
            if (_intercept == value) return;
            BackColor = value ? Color.Thistle : Color.White;
            _intercept = value;
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (!_intercept) return;
            if (e.KeyCode != Keys.Enter)
            {
                _currentKeys.ControlKey = e.Control;
                _currentKeys.AltKey = e.Alt;
                _currentKeys.ShiftKey = e.Shift;
                _currentKeys.Key = (e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.Menu || e.KeyCode == Keys.ShiftKey) ? Keys.None : e.KeyCode;
                if (_currentKeys.IsValid)
                {
                    BackColor = Color.LightSeaGreen;
                }
                else
                {
                    BackColor = Color.IndianRed;
                }
                Text = _currentKeys.ToString();
            }
            else
            {
                SwitchInterceptionMode(false);
                if (_currentKeys.IsValid) KeysInfo = new KeysInfo(_currentKeys.ControlKey, _currentKeys.AltKey, _currentKeys.ShiftKey, _currentKeys.Key);
                Text = KeysInfo.ToString();
            }
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !_intercept) SwitchInterceptionMode(true);
        }
    }
}