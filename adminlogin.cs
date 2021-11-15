using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Computer_User_Management_System
{
    public partial class adminlogin : Form
    {
        DBConnection Conn;
        string password;
        string id;

        public adminlogin()
        {
            InitializeComponent();
            Conn = new DBConnection();
            Conn.ConnectToDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT ID FROM `AdminTable` where ID = '" + textBox1.Text + "'", Conn.Connection);
                id = (string)command.ExecuteScalar();

                if(String.IsNullOrEmpty(id))
                {
                    MessageBox.Show("User ID Incorrect");
                    return;
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("User Not Found", ex.Message);
                return;
            }

            try
            {
                using (MySqlCommand command = new MySqlCommand("SELECT Password FROM `AdminTable` where ID = '" + id + "'", Conn.Connection))
                {
                    password = (string)command.ExecuteScalar();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (textBox2.Text.ToString() == password)
            {
                MessageBox.Show("Login Successfull");
                AdminPortal panel = new AdminPortal();
                panel.Show();
                this.Hide();
                Global.GetGlobalLocked().unhook();
                Global.GetGlobalLocked().Hide();
                Cursor.Current = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Incorrect Password");
                return;
            }





            /*  using (MySqlCommand command = new MySqlCommand("SELECT ID FROM `AdminTable` where ID = '" + textBox1.Text + "'", Conn.Connection))
              {
                  id = (string)command.ExecuteScalar();
              }

              if (textBox1.Text.ToString() == id)
              {
                  using (MySqlCommand command = new MySqlCommand("SELECT Password FROM `AdminTable` where ID = '" + id + "'", Conn.Connection))
                  {
                      password = (string)command.ExecuteScalar();
                  }

                  if (textBox2.Text.ToString() == password)
                  {
                      MessageBox.Show("Login Successfull");
                      AdminPortal panel = new AdminPortal();
                      panel.Show();
                      this.Hide();
                      Global.GetGlobalLocked().Hide();

                  }
                  else
                  {
                      MessageBox.Show("Incorrect Password");
                  }

              }
              else
              {
                  MessageBox.Show("Incorrect Admin ID");
              }*/

        }
    }
}
