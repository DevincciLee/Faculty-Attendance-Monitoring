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
    public partial class Records : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        Connection db = new Connection();
        public Records()
        {
            InitializeComponent();
            con = new OleDbConnection(db.GetConnection());
            LoadRec();
        }
        public void LoadRec()
        {
            // Displaying daily time record for the day
            try
            {
                dgvrecords.Rows.Clear();
                int g = 0;
                con.Open();

                DateTime selecteddate = dtp1.Value.Date;
                cmd = new OleDbCommand("SELECT * FROM Records WHERE [calendar] = @selecteddate", con);
                cmd.Parameters.AddWithValue("@selecteddate", selecteddate);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    g++;
                    dgvrecords.Rows.Add(g, dr["rfid"].ToString(), dr["empname"].ToString(), dr["emposition"].ToString(), DateTime.Parse(dr["calendar"].ToString()).ToShortDateString(), DateTime.Parse(dr["Timein"].ToString()).ToLongTimeString(), DateTime.Parse(dr["Timeout"].ToString()).ToLongTimeString());
                }
                dr.Close();
                con.Close();
                dgvrecords.ClearSelection();
            }
            catch
            {
                con.Close();
                MessageBox.Show("Someone didn't Timed out recently", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void dgvrecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {
            dtp1.MaxDate = DateTime.Now.Date;
            LoadRec();
        }
    }
}
