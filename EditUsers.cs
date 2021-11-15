using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Computer_User_Management_System
{
    public partial class EditUsers : Form
    {
        DBConnection Conn;
        MySqlDataReader sdr;
        String cell;
        public EditUsers()
        {
            InitializeComponent();
            Conn = new DBConnection();
            Conn.ConnectToDB();
        }

        private void Searchbtn_Click(object sender, EventArgs e)
        {
            cell= cellnumtxt.Text.ToString();
            try
            {
                MySqlCommand comman = new MySqlCommand("Select* From UserTable Where PhoneNum = '" + cellnumtxt.Text + "'", Conn.Connection);
                sdr = comman.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            while (sdr.Read())
            {
                nametxt.Text = sdr.GetValue(1).ToString();
                passtxt.Text = sdr.GetValue(2).ToString();
                passtxt2.Text = sdr.GetValue(2).ToString();
                hrstxt.Text = sdr.GetValue(3).ToString();
            }
            sdr.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Select Account Status");
            }


            if (passtxt.Text != passtxt2.Text)
            {
                MessageBox.Show("Passwords Dont Match", "Error");
                return;
            }

            else
            {
                try
                {
                    MySqlCommand comman = new MySqlCommand("Update UserTable set UserName = '" + nametxt.Text + "' , Password = '" + passtxt.Text + "' ,Time = '" + hrstxt.Text + "' ,AccountStatus = '" + comboBox1.SelectedIndex.ToString() + "' Where PhoneNum = " + cell , Conn.Connection);
                    comman.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return;
                }


                MessageBox.Show("Updated User Data");
            }


        }

        private void cellnumtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void hrstxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex== 0)
            {
                MessageBox.Show("Selecting Disable will Disable the account activity");
            }
        }

        private void EditUsers_Load(object sender, EventArgs e)
        {

        }

        private void hrstxt_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Minimum 10 Hours\n Time is Entered in 1000 Format\n As 1000 for 10 Hours\n And 1030 for 10 Hours 30 Mins", hrstxt);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("User Deleted Succesfully");

            if (string.IsNullOrEmpty(cellnumtxt.Text))
            {
                MessageBox.Show("User ID is Empty, Please Enter");
                return;
            }

            else
            {
                try
                {
                    MySqlCommand comman = new MySqlCommand("Delete from UserTable Where PhoneNum = '" + cellnumtxt.Text + "'", Conn.Connection);
                    comman.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message, "User Not Found");
                }

            }

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolTip2.Show("This will permanently Delete the user",button2);
        }
    }
}
