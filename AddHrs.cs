using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Computer_User_Management_System
{
    public partial class AddHrs : Form
    {
        DBConnection Conn;
        private string timeupdate;
        private int totaltime;
        private int minutes;
        private int hours;

        public AddHrs()
        {
            Conn = new DBConnection();
            Conn.ConnectToDB();
            InitializeComponent();

        }

        private void cellnumtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int addhrs = totaltime + int.Parse(textBox1.Text);

            if(addhrs%100 == 60)
            {
                addhrs += 40;
            }

            MySqlCommand comman = new MySqlCommand("Update UserTable set Time = '" + addhrs.ToString() + "' Where PhoneNum = '" + cellnumtxt.Text + "'", Conn.Connection);
            comman.ExecuteNonQuery();
            MessageBox.Show("Time Updated");
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Clear();
                }
            }
        }

        private void AddHrs_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlCommand comman = new MySqlCommand("Select Time From UserTable Where PhoneNum = '" + cellnumtxt.Text + "'", Conn.Connection);
            timeupdate = comman.ExecuteScalar().ToString();
            totaltime = Int32.Parse(timeupdate);
            minutes = totaltime % 100;
            hours = totaltime / 100;
            currenthours.Text = hours.ToString() + ":" + minutes.ToString();
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Minimum 10 Hours\n Time is Entered in 1000 Format\n As 1000 for 10 Hours\n And 1030 for 10 Hours 30 Mins", textBox1);

        }
    }
}
