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
    public partial class adduser : Form
    {
        DBConnection Conn;
        public adduser()
        {
            InitializeComponent();
            Conn = new DBConnection();
            Conn.ConnectToDB();
        }

        private void cellnumtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void hrstxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nametxt.Text == "" || phnnum.Text == "0" || passtxt.Text == "" || passtxt2.Text == "" || hrstxt.Text == "")
            {
                MessageBox.Show("Please Input All Fields");
            }

            else if (passtxt.Text != passtxt2.Text)
            {
                MessageBox.Show("Passwords Dont Match!!");
            }

            else
            {
                try
                {
                    MySqlCommand comman = new MySqlCommand("INSERT INTO `UserTable`(`PhoneNum`, `UserName`, `Password`, `Time`, `Status`, `AccountStatus`) VALUES ('" + phnnum.Text + "','" + nametxt.Text + "','" + passtxt.Text + "','" + hrstxt.Text + "','0','1' )", Conn.Connection);
                    comman.ExecuteNonQuery();
                    MessageBox.Show("User Added Successfully");
                    foreach (Control control in this.Controls)
                    {
                        if (control is TextBox)
                        {
                            TextBox textBox = (TextBox)control;
                            textBox.Clear();
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message + "Cell No Already Exists");
                    //Conn.Connection.Close();
                }

            }
        }

        private void hrstxt_MouseHover(object sender, EventArgs e)
        {

            toolTip1.Show("Minimum 10 Hours\n Time is Entered in 1000 Format\n As 1000 for 10 Hours\n And 1030 for 10 Hours 30 Mins",hrstxt);
        }

        private void adduser_Load(object sender, EventArgs e)
        {

        }

        private void phnnum_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
