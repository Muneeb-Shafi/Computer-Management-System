using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace Computer_User_Management_System
{
    public partial class UserTimer : Form
    {
        DateTime time = DateTime.Now;
        DBConnection Conn;
        string timeupdate, currentime;
        int hours, minutes, totaltime;

        public UserTimer()
        {
            InitializeComponent();
            Conn = new DBConnection();
            Conn.ConnectToDB();
            starttime.Text = DateTime.Now.ToString("hh:mm:ss");
            FormProgress();
        }
        public void FormProgress()
        {

            MySqlCommand comman = new MySqlCommand("Select Time From UserTable Where PhoneNum = '" + Global.getactiveuser() + "'", Conn.Connection);
            timeupdate = comman.ExecuteScalar().ToString();
            totaltime = Int32.Parse(timeupdate);
            minutes = totaltime % 100;
            hours = totaltime / 100;
            remTime.Text = hours.ToString() + ":" + minutes.ToString();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
        }



        private static void StartShutDown(string param)
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.FileName = "cmd";
            proc.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Arguments = "/C shutdown " + param;
            Process.Start(proc);
        }


        public static void Restart()
        {
            StartShutDown("-f -r -t 5");
        }


        public static string purgeit(string str)
        {
            char[] buffer = new char[str.Length];
            int idx = 0;

            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9'))
                {
                    buffer[idx] = c;
                    idx++;
                }
            }
            return new string(buffer, 0, idx);
        }


        private void UserTimer_Load(object sender, EventArgs e)
        {

            timer1.Start();
            timer2.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan time2 = DateTime.Now - time;
            currenttime.Text = time2.ToString(@"hh\:mm");
            currentime = purgeit(currenttime.Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();

            try 
            {
                string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

                foreach (string file in files)
                {
                    File.Delete(file);
                }

                files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));

                foreach (string file in files)
                {
                    File.Delete(file);
                }

                files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));

                foreach (string file in files)
                {
                    File.Delete(file);
                }

                files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));

                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Some files cannot be deleted due to Access Issues");
            }

            Global.GetGlobalLocked().Show();
            Restart();
            
            this.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            minutes -= 1;

            if (minutes <= 0 && hours > 0)
            {
                minutes = 59;
                hours -= 1;
               // MessageBox.Show(minutes.ToString());
            }

            if (hours <= 0 && minutes <= 0)
            {
                hours = 0;
                minutes = 0;
                MessageBox.Show("Times Up, Pc Will Logout in 1 Min", "Buy Credit");
                timer1.Stop();
                timer2.Stop();
                Thread.Sleep(6000);
                Global.GetGlobalLocked().Show();
                this.Close();
            }


            remTime.Text = hours.ToString() + ":" + minutes.ToString();

            MySqlCommand comman = new MySqlCommand("update UserTable set Time = '" + hours.ToString() + minutes.ToString() + "' where PhoneNum ='" + Global.getactiveuser() + "'", Conn.Connection);
            comman.ExecuteNonQuery();

        }
    }
}
