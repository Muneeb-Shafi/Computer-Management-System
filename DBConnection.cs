using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Computer_User_Management_System
{
    internal class DBConnection
    {
        public MySqlConnection Connection;

        public void ConnectToDB()
        {
            String ConnString = "SERVER = sql3.freesqldatabase.com;PORT=3306;DATABASE=sql3446748;UID=sql3446748;PASSWORD=wAxcfxHwq9";
            try
            {
                Connection = new MySqlConnection();
                Connection.ConnectionString = ConnString;
                Connection.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
