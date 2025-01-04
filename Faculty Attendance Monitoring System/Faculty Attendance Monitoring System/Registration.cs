using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Faculty_Attendance_Monitoring_System
{
    public partial class Registration : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;     
        Connection db = new Connection();
        public Registration()
        {
            InitializeComponent();
            con = new OleDbConnection(db.GetConnection());
        }

        private void chxboxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chxboxShowPass.Checked)
            {
                tbPassword.PasswordChar = '\0';
                tbConfirm.PasswordChar = '\0';
            }
            else
            {
                tbPassword.PasswordChar = '•';
                tbConfirm.PasswordChar = '•';
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {   
            // Registering an admin in the database

                if (tbUsername.Text == "" || tbPassword.Text == "" || tbConfirm.Text == "" || tbadmin.Text == "")
                {
                    MessageBox.Show("All information must be filled up.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (tbConfirm.Text != tbPassword.Text)
                {
                    MessageBox.Show("Password did not match. Make sure the password is similar.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbPassword.Focus();
                    return;
                }
                else
                {
                    con.Open();
                    cmd = new OleDbCommand("INSERT INTO Admin ([username], [password], [aname]) VALUES (@username, @password, @aname)", con);
                    cmd.Parameters.AddWithValue("@username", tbUsername.Text);
                    cmd.Parameters.AddWithValue("@password", tbPassword.Text);
                    cmd.Parameters.AddWithValue("@aname", tbadmin.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Your Account has been Created", "Registration Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbUsername.Text = "";
                    tbadmin.Text = "";
                    tbPassword.Text = "";
                    tbConfirm.Text = "";
                }
           
        }
    }
}
