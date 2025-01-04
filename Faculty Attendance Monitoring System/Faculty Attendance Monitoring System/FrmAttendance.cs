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
    public partial class FrmAttendance : Form
    {
        int seconds = 0;
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        Connection db = new Connection();
        public FrmAttendance()
        {
            InitializeComponent();
            con = new OleDbConnection(db.GetConnection());          
        }
        public void Attendance()
        {         
            if (IsTimeInEmpty())
            {
                RecordTimeIn();
            }
            else if (IsTimeOutEmpty())
            {
                RecordTimeOut();
            }
            else
            {
                lblSuccess.ForeColor = Color.Red;
                lblSuccess.Text = "YOU'VE ALREADY TIMED-OUT";
                return;
            }
        }
        //private bool IsWithinSchedule()
        //{          
        //    using (OleDbCommand cmd = new OleDbCommand("SELECT StartTime, EndTime FROM Employees WHERE rfid = @rfid", con))
        //    {
        //        cmd.Parameters.AddWithValue("@rfid", txtSearch.Text);
        //        using (OleDbDataReader dr = cmd.ExecuteReader())
        //        {
        //            if (dr.Read())
        //            {
        //                TimeSpan startTime = TimeSpan.Parse(dr["StartTime"].ToString());
        //                TimeSpan endTime = TimeSpan.Parse(dr["EndTime"].ToString());
        //                TimeSpan currentTime = DateTime.Now.TimeOfDay;

        //                return currentTime >= startTime && currentTime <= endTime;
        //            }
        //        }
        //    }
        //    return false; // Return false if the employee has no schedule or an error occurs
        //}

        private bool IsTimeInEmpty()
        {
            // This is a method to know if there is a time-in from a specific user or if there is none. 

            using (OleDbCommand cmd = new OleDbCommand("SELECT Timein FROM Records WHERE rfid = @rfid AND calendar = @calendar", con))
            {
                cmd.Parameters.AddWithValue("@rfid", txtSearch.Text);
                cmd.Parameters.AddWithValue("@calendar", DateTime.Now.Date);
                object result = cmd.ExecuteScalar();
                return result == null || result == DBNull.Value;
            }
        }
        private bool IsTimeOutEmpty()
        {
            // This is a method to know if there is a time-out from a specific user or if there is none. 

            using (OleDbCommand cmd = new OleDbCommand("SELECT Timeout FROM Records WHERE rfid = @rfid AND calendar = @calendar", con))
            {
                cmd.Parameters.AddWithValue("@rfid", txtSearch.Text);
                cmd.Parameters.AddWithValue("@calendar", DateTime.Now.Date);
                object result = cmd.ExecuteScalar();
                return result == null || result == DBNull.Value;
            }
        }
        private void RecordTimeIn()
        {
            // Method for recording time-in

            cmd = new OleDbCommand("INSERT INTO Records ([rfid], [empname], [emposition], [calendar], [Timein]) VALUES (@rfid, @empname, @emposition, @calendar, @timein)", con);
            cmd.Parameters.AddWithValue("@rfid", txtSearch.Text);
            cmd.Parameters.AddWithValue("@empname", name.Text);
            cmd.Parameters.AddWithValue("@emposition", position.Text);
            cmd.Parameters.AddWithValue("@calendar", DateTime.Now.ToShortDateString());
            cmd.Parameters.AddWithValue("@timein", DateTime.Now.ToLongTimeString());
            cmd.ExecuteNonQuery();
            lblSuccess.ForeColor = Color.Green;
            lblSuccess.Text = "TIME-IN RECORDED!";
        }
        private void RecordTimeOut()
        {
            // Method for recording time-out

            cmd = new OleDbCommand("UPDATE Records SET [Timeout] = @timeout WHERE [rfid] = @rfid AND [calendar] = @calendar", con);
            cmd.Parameters.AddWithValue("@timeout", DateTime.Now.ToLongTimeString());
            cmd.Parameters.AddWithValue("@rfid", txtSearch.Text);
            cmd.Parameters.AddWithValue("@calendar", DateTime.Now.Date);
            cmd.ExecuteNonQuery();
            lblSuccess.Text = "TIME-OUT RECORDED!";
            lblSuccess.ForeColor = Color.Red;

        }
             
        private void Login_Click(object sender, EventArgs e)
        {
            //For the picture box(logo of bpc) to display the login form and for the admin to access the dashboard. 

            Login f = new Login();
            f.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Timer for how long should the information of the user be displayed on the screen
            // If the time is less than 0 already, the information will vanished. 

            lblScreen.Text = seconds--.ToString();
            if (seconds < 0)
            {
                timer1.Stop();
                name.Text = "";
                position.Text = "";            
                lblSuccess.Text = "";
                txtSearch.Text = "";
                date.Text = "";
                time.Text = "";
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //For displaying date and time in the attendance interface
           
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 10)
            {
                seconds = 8; // 8 seconds to display the information of the user
                timer1.Start();

                con.Open();
                cmd = new OleDbCommand("SELECT [ename], [position] FROM Employees WHERE [rfid] = @rfid", con);
                cmd.Parameters.AddWithValue("@rfid", txtSearch.Text);
                dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    date.Text = DateTime.Now.ToString("MMMM dd, yyyy");
                    time.Text = DateTime.Now.ToString("h:mm:ss tt");
                    time.BackColor = Color.Transparent;
                    name.Text = dr["ename"].ToString();
                    position.Text = dr["position"].ToString();
                    txtSearch.SelectAll();
                    txtSearch.Focus();

                    Attendance();

                }
                else
                {
                    // If the card isn't registered yet in the system
                    dr.Close();
                    name.Text = "NO RECORD FOUND";
                    position.Text = "NO RECORD FOUND";
                    lblSuccess.Text = "NO RECORD FOUND";
                    lblSuccess.ForeColor = Color.Red;
                    txtSearch.SelectAll();
                    txtSearch.Focus();
                }
                txtSearch.SelectAll();
                txtSearch.Focus();
                dr.Close();
                con.Close();
            }
        }
    }
}
