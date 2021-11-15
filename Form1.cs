using System;
using System.Diagnostics;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace Computer_User_Management_System
{
    public partial class Locked : Form
    {

        private LowLevelKeyboardListener _listener;
        public static Panel panelHide = new Panel();
        private int _ScreenWidth;
        private int _ScreenHeight;

        public Locked()
        {
            _listener = new LowLevelKeyboardListener();
            _listener.OnKeyPressed += _listener_OnKeyPressed;

            _listener.HookKeyboard();
            InitializeComponent();
            _ScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            _ScreenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            this.Size = new Size(_ScreenWidth,_ScreenHeight);
            panelHide = panel2;
        }

        public void unhook()
        {
            _listener.UnHookKeyboard();
        }

        void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {

            if (e.KeyPressed.ToString()=="LMenu"|| e.KeyPressed.ToString() == "LControlKey" || e.KeyPressed.ToString() == "LWin" ||
                e.KeyPressed.ToString() == "RMenu" || e.KeyPressed.ToString() == "RControlKey" || e.KeyPressed.ToString() == "RWin" ||
                e.KeyPressed.ToString() == "F4" || e.KeyPressed.ToString() == "RShiftKey" || e.KeyPressed.ToString() == "Escape")
            {
                MessageBox.Show("Function and Access Keys Are Disabled, Login To Gain Access !!!");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _listener.UnHookKeyboard();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }


        private bool PingNetwork(string hostNameOrAddress)
        {
            bool pingStatus = false;

            using (Ping p = new Ping())
            {
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;

                try
                {
                    PingReply reply = p.Send(hostNameOrAddress, timeout, buffer);
                    pingStatus = (reply.Status == IPStatus.Success);
                }
                catch (Exception)
                {
                    pingStatus = false;
                }
            }

            return pingStatus;
        }

        private void button1_Click_1(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if(!PingNetwork("Google.com"))
            {
                MessageBox.Show("No Internet Connection", "Network Error");
                return;
            }

            else
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    this.panel2.Controls.Clear();
                    adminlogin adminloginfrm = new adminlogin()
                    { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    adminloginfrm.FormBorderStyle = FormBorderStyle.None;
                    this.panel2.Controls.Add(adminloginfrm);
                    adminloginfrm.Show();
                    Cursor.Current = Cursors.Default;

                }

                else if (comboBox1.SelectedIndex == 1)
                {
                    this.panel2.Controls.Clear();
                    userlogin userloginfrm = new userlogin()
                    { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    userloginfrm.FormBorderStyle = FormBorderStyle.None;
                    this.panel2.Controls.Add(userloginfrm);
                    userloginfrm.Show();
                    Cursor.Current = Cursors.Default;
                }
            }

        }

        private void Locked_Load(object sender, System.EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, System.EventArgs e)
        {
            var psi = new ProcessStartInfo("shutdown", "/s /t 0");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }
    }
}
