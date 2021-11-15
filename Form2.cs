using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Computer_User_Management_System
{
    public partial class AdminPortal : Form
    {
        public AdminPortal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowState= FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            lbltxt.Text = adduserbtn.Text;
            this.frmloader.Controls.Clear();
            adduser addusrfrm = new adduser()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            addusrfrm.FormBorderStyle = FormBorderStyle.None;
            this.frmloader.Controls.Add(addusrfrm);
            addusrfrm.Show();
            Cursor.Current = Cursors.Default;
        }

        private void addcreditsbtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            lbltxt.Text = addcreditsbtn.Text;
            this.frmloader.Controls.Clear();
            AddHrs addhrsfrm = new AddHrs()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            addhrsfrm.FormBorderStyle = FormBorderStyle.None;
            this.frmloader.Controls.Add(addhrsfrm);
            addhrsfrm.Show();
            Cursor.Current = Cursors.Default;
        }

        private void editusrbtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            lbltxt.Text = editusrbtn.Text;
            this.frmloader.Controls.Clear();
            EditUsers editusr = new EditUsers()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            editusr.FormBorderStyle = FormBorderStyle.None;
            this.frmloader.Controls.Add(editusr);
            editusr.Show();
            Cursor.Current = Cursors.Default;
        }

        private void chngadminpasbtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            lbltxt.Text = chngadminpasbtn.Text;
            this.frmloader.Controls.Clear();
            ChangeAdminPass passchnage = new ChangeAdminPass()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            passchnage.FormBorderStyle = FormBorderStyle.None;
            this.frmloader.Controls.Add(passchnage);
            passchnage.Show();
            Cursor.Current = Cursors.Default;
        }

        private void viewallusr_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            lbltxt.Text = viewallusr.Text;
            this.frmloader.Controls.Clear();
            viewallusers allusers = new viewallusers()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            allusers.FormBorderStyle = FormBorderStyle.None;
            this.frmloader.Controls.Add(allusers);
            allusers.Show();
            Cursor.Current = Cursors.Default;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Lock_Click(object sender, EventArgs e)
        { 
            this.Close();
            Global.GetGlobalLocked().Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }
    }
}
