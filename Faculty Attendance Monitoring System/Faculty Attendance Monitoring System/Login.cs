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
    public partial class Login : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        Connection db = new Connection();
       
        public Login()
        {
            InitializeComponent();
            con = new OleDbConnection(db.GetConnection());
        }

        private void btnDispose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new OleDbCommand("SELECT * FROM Admin WHERE password = @password AND username = @username", con);
                cmd.Parameters.AddWithValue("password", tbPassword.Text);
                cmd.Parameters.AddWithValue("username", tbUsername.Text);
                dr = cmd.ExecuteReader();
                dr.Read();

                if (tbUsername.Text == "" && tbPassword.Text == "")
                {
                    MessageBox.Show("Required Missing Field", "Sign in Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (tbUsername.Text == "")
                {
                    MessageBox.Show("Username is Required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (tbPassword.Text == "")
                {
                    MessageBox.Show("Password is Required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (dr["username"].ToString() == tbUsername.Text && dr["password"].ToString() == tbPassword.Text)
                {
                    Dashboard f = new Dashboard();                  
                    f.BringToFront();
                    f.Show();
                    this.Close();
                   
                }
                else
                {
                    MessageBox.Show("The Username or Password is incorrect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dr.Close();
                con.Close();
            }
            catch (Exception)
            {
                con.Close();
                MessageBox.Show("The username or Password is incorrect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void chxboxShowPass_CheckedChanged(object sender, EventArgs e)
        {
           // To check password easily

            if (chxboxShowPass.Checked)
            {
                tbPassword.PasswordChar = '\0';
            }
            else
            {
                tbPassword.PasswordChar = '•';
            }
        }
    }
}
