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
    public partial class ChangeAdminPass : Form
    {
        DBConnection Conn;
        string check;
        public ChangeAdminPass()
        {
            InitializeComponent();
            Conn = new DBConnection();
            Conn.ConnectToDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand comman = new MySqlCommand("Select Password From AdminTable", Conn.Connection);
                check = comman.ExecuteScalar().ToString();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            if (check == textBox1.Text)
            {

                if (textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("Passwords Dont Match", "Error");
                    return;
                }

                else
                {
                    try
                    {
                        MySqlCommand comman = new MySqlCommand("Update AdminTable set Password = '" + textBox2.Text + "'", Conn.Connection);
                        comman.ExecuteNonQuery();
                        MessageBox.Show("Password Updated", "Success");
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }

                }
            }
            else
            {
                MessageBox.Show("Incorrect Old Password","Error");
            }

        }
    }
}
