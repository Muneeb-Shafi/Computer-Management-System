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
    public partial class viewallusers : Form
    {
        DBConnection Conn;
        public viewallusers()
        {
            InitializeComponent();
            Conn=new DBConnection();
            Conn.ConnectToDB();
        }

        private void viewallusers_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlDataAdapter comman = new MySqlDataAdapter("SELECT * FROM `UserTable` where 1 ", Conn.Connection))
                {
                    DataTable tb = new DataTable();
                    comman.Fill(tb);
                    dataGridView1.DataSource = tb;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
