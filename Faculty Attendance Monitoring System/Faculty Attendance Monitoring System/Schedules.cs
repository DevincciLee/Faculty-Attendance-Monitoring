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
    public partial class Schedules : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        Connection db = new Connection();      
        public Schedules()
        {
            InitializeComponent();
            con = new OleDbConnection(db.GetConnection());
            LoadRecords();
           
        }
        public void LoadRecords()
        {          
                dgvSched.Rows.Clear();
                int i = 0;
                con.Open();
                cmd = new OleDbCommand("SELECT * FROM Employees", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dgvSched.Rows.Add(i, dr["ename"].ToString());
                }
                dr.Close();
                con.Close();     

        }

        public void ShowSchedule()
        {          
           
        }
        private void dgvSched_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmployeeList f = new EmployeeList();
            string colname = dgvSched.Columns[e.ColumnIndex].Name;

            if (colname == "colview")
            {
                con.Open();
                cmd = new OleDbCommand("SELECT * FROM Employees WHERE [rfid] = @rfid", con);
                cmd.Parameters.AddWithValue("@rfid", f.dgvEmployee.Rows[e.RowIndex].Cells[1].Value.ToString());
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    monsched.Text = dr["mondaysched"].ToString();
                    monvacant.Text = dr["mondayvacant"].ToString();
                    tuesched.Text = dr["tuesdaysched"].ToString();
                    tuesvacant.Text = dr["tuesdayvacant"].ToString();
                    wedsched.Text = dr["wednesdaysched"].ToString();
                    wedvacant.Text = dr["wednesdayvacant"].ToString();
                    thursched.Text = dr["thursdaysched"].ToString();
                    thursvacant.Text = dr["thursdayvacant"].ToString();
                    frisched.Text = dr["fridaysched"].ToString();
                    frivacant.Text = dr["fridayvacant"].ToString();
                    satsched.Text = dr["saturdaysched"].ToString();
                    satvacant.Text = dr["saturdayvacant"].ToString();
                }
                con.Close();
                dr.Close();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
