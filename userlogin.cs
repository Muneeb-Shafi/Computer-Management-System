using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Computer_User_Management_System
{
    public partial class userlogin : Form
    {
        DBConnection Conn;
        string password;
        string id;
        int stats;
        private string timeupdate;

        public userlogin()
        {
            InitializeComponent();
            Conn = new DBConnection();
            Conn.ConnectToDB();
        }

        private void userloginbtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (string.IsNullOrEmpty(cellnum.Text) || string.IsNullOrEmpty(pass.Text))
            {
                MessageBox.Show("Please Fill all Fields");
                return;
            }
            else
            {
                try
                {
                    using (MySqlCommand command = new MySqlCommand("SELECT PhoneNum FROM `UserTable` where PhoneNum = '" + cellnum.Text + "'", Conn.Connection))
                    {
                        id = (string)command.ExecuteScalar();
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Invalid User ID" + ex.Message);
                    return;
                }

                try
                {
                    using (MySqlCommand command = new MySqlCommand("SELECT PASSWORD FROM `UserTable` where PhoneNum = '" + id + "'", Conn.Connection))
                    {
                        password = (string)command.ExecuteScalar();
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Invalid User ID or Password" + ex.Message);
                    return;
                }
            }

            if (pass.Text.ToString() == password)
            {
                try
                {
                    using (MySqlCommand command = new MySqlCommand("SELECT AccountStatus FROM `UserTable` where PhoneNum = " + cellnum.Text, Conn.Connection))
                    {
                        stats = int.Parse(command.ExecuteScalar().ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (stats == 1)
                {
                    try
                    {
                        using (MySqlCommand comman = new MySqlCommand("Select Time From UserTable Where PhoneNum = '" + id + "'", Conn.Connection))
                        {
                            timeupdate = comman.ExecuteScalar().ToString();

                            if(timeupdate.ToString() == "00")
                            {
                                MessageBox.Show("Not Enough Credit in Account", "Purchase Credits");
                            }
                            else
                            {
                                MessageBox.Show("Login Successfull");
                                Global.setactiveuser(id);
                                UserTimer panel = new UserTimer();
                                panel.Show();
                                this.Hide();
                                Global.GetGlobalLocked().unhook();
                                Global.GetGlobalLocked().Hide();
                                Cursor.Current = Cursors.Default;
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
               
                }
                else
                {
                    MessageBox.Show("Account Disabled By Admin", "Error");
                }

            }
            else
            {
                MessageBox.Show("Incorrect Password or Username");
                return;
            }
        }

        private void cellnum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
