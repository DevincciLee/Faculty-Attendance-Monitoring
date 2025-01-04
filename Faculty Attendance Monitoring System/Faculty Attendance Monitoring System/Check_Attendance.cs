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
    public partial class Check_Attendance : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        Connection db = new Connection();

        public Check_Attendance()
        {
            InitializeComponent();
            con = new OleDbConnection(db.GetConnection());
            LoadRecords();
           
        }

        private void btnDispose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void LoadRecords()
        {
            // For displaying the information in the datagridview
            try
            {
                dgvCheckAttendance.Rows.Clear();
                int g = 0;
                con.Open();

                DateTime selecteddate = dtp1.Value.Date;
                DateTime startOfMonth = new DateTime(selecteddate.Year, selecteddate.Month, 1);
                DateTime endOfMonth = new DateTime(selecteddate.Year, selecteddate.Month, 1).AddMonths(1).AddDays(-1);

                cmd = new OleDbCommand("SELECT * FROM Records WHERE [calendar] >= @startOfMonth AND [calendar] <= @endOfMonth AND [rfid] = @rfid", con);
                cmd.Parameters.AddWithValue("@startOfMonth", startOfMonth);
                cmd.Parameters.AddWithValue("@endOfMonth", endOfMonth);
                cmd.Parameters.AddWithValue("@rfid", lblView.Text.ToString());
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    g++;
                    dgvCheckAttendance.Rows.Add(g, DateTime.Parse(dr["calendar"].ToString()).ToShortDateString(), DateTime.Parse(dr["Timein"].ToString()).ToLongTimeString(), DateTime.Parse(dr["Timeout"].ToString()).ToLongTimeString());

                    lblname.Text = dr["empname"].ToString();
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {
            // Value of the date time picker is from the recent months and years but not farther than today's time and date. 
            dtp1.MaxDate = DateTime.Now.Date;
            LoadRecords();
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // This is for checking the attendance of the employees invididually 
            try
            {
                EmployeeList f = new EmployeeList();
                dgvCheckAttendance.Rows.Clear();
                int g = 0;
                con.Open();
                DateTime selecteddate = dtp1.Value.Date;

                DateTime startOfMonth = new DateTime(selecteddate.Year, selecteddate.Month, 1);

                DateTime endOfMonth = new DateTime(selecteddate.Year, selecteddate.Month, 1).AddMonths(1).AddDays(-1);

                cmd = new OleDbCommand("SELECT * FROM Records WHERE [calendar] >= @startOfMonth AND [calendar] <= @endOfMonth AND [rfid] = @rfid", con);          
                cmd.Parameters.AddWithValue("@startOfMonth", startOfMonth);
                cmd.Parameters.AddWithValue("@endOfMonth", endOfMonth);
                cmd.Parameters.AddWithValue("@rfid", lblView.Text.ToString());
                dtp1.Focus();
                dtp1.Format = DateTimePickerFormat.Custom;
                dtp1.CustomFormat = "MMMM yyyy";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    g++;
                    dgvCheckAttendance.Rows.Add(g, DateTime.Parse(dr["calendar"].ToString()).ToShortDateString(), DateTime.Parse(dr["Timein"].ToString()).ToLongTimeString(), DateTime.Parse(dr["Timeout"].ToString()).ToLongTimeString());
                    lblname.Text = dr["empname"].ToString();
                   
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void dgvCheckAttendance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DailyTimeRecord f = new DailyTimeRecord();
            f.Show();

            f.dgvPrint.Rows.Clear();
            int g = 0;
         
            DateTime selecteddate = dtp1.Value.Date;
            DateTime startOfMonth = new DateTime(selecteddate.Year, selecteddate.Month, 1);
            DateTime endOfMonth = new DateTime(selecteddate.Year, selecteddate.Month, 1).AddMonths(1).AddDays(-1);

            con.Open();
            cmd = new OleDbCommand("SELECT * FROM Records WHERE [calendar] >= @startOfMonth AND [calendar] <= @endOfMonth AND [rfid] = @rfid", con);
            cmd.Parameters.AddWithValue("@startOfMonth", startOfMonth);
            cmd.Parameters.AddWithValue("@endOfMonth", endOfMonth);
            cmd.Parameters.AddWithValue("@rfid", lblView.Text.ToString());
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                g++;
                f.dgvPrint.Rows.Add(g, DateTime.Parse(dr["calendar"].ToString()).ToShortDateString(), DateTime.Parse(dr["Timein"].ToString()).ToLongTimeString(), DateTime.Parse(dr["Timeout"].ToString()).ToLongTimeString());
                f.lblName.Text = dr["empname"].ToString();
                f.lblPotision.Text = dr["emposition"].ToString();
                string month = DateTime.Now.ToString("MMMM");
                f.lblmonth.Text = month;
            }
            dr.Close();
            con.Close();
        }
    }
}
