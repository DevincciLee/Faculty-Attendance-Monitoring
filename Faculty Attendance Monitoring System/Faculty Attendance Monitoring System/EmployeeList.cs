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
    public partial class EmployeeList : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        Connection db = new Connection();
        public EmployeeList()
        {
            InitializeComponent();
            con = new OleDbConnection(db.GetConnection());
            LoadRecords();
        }
        public void LoadRecords()
        {           
                dgvEmployee.Rows.Clear();
                int i = 0;
                con.Open();
                cmd = new OleDbCommand("SELECT [rfid], [ename], [position] FROM Employees", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dgvEmployee.Rows.Add(i, dr["rfid"].ToString(), dr["ename"].ToString(), dr["position"].ToString());
                }
                dr.Close();
                con.Close();           
        }
       
        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Show employee form
            Employee f = new Employee();
            f.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Edit and delete buttons 
            string colname = dgvEmployee.Columns[e.ColumnIndex].Name;

            if (colname == "colEdit")
            {
                Employee f = new Employee();
                con.Open();
                cmd = new OleDbCommand("SELECT * FROM Employees WHERE [rfid] = @rfid", con);
                cmd.Parameters.AddWithValue("@rfid", dgvEmployee.Rows[e.RowIndex].Cells[1].Value.ToString());
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    f.tbrfid.Text = dgvEmployee.Rows[e.RowIndex].Cells[1].Value.ToString();
                    f.tbname.Text = dgvEmployee.Rows[e.RowIndex].Cells[2].Value.ToString();
                    f.cmbPosition.Text = dgvEmployee.Rows[e.RowIndex].Cells[3].Value.ToString();
                    f.tbmonsched.Text = dr["mondaysched"].ToString();
                    f.tbmonvacant.Text = dr["mondayvacant"].ToString();
                    f.tbtuesched.Text = dr["tuesdaysched"].ToString();
                    f.tbtuesvacant.Text = dr["tuesdayvacant"].ToString();
                    f.tbwedsched.Text = dr["wednesdaysched"].ToString();
                    f.tbwedvacant.Text = dr["wednesdayvacant"].ToString();
                    f.tbthursched.Text = dr["thursdaysched"].ToString();
                    f.tbthursvacant.Text = dr["thursdayvacant"].ToString();
                    f.tbfrisched.Text = dr["fridaysched"].ToString();
                    f.tbfrivacant.Text = dr["fridayvacant"].ToString();
                    f.tbsatsched.Text = dr["saturdaysched"].ToString();
                    f.tbsatvacant.Text = dr["saturdayvacant"].ToString();
                    f.tbrfid.Enabled = false;
                    f.btnSave.Enabled = false;
                    f.btnUpdate.Enabled = true;
                    f.ShowDialog();

                }
                con.Close();
            }
            else if (colname == "colDelete")
            {
                if (MessageBox.Show("You want to delete this file?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new OleDbCommand("DELETE FROM Employees WHERE [rfid] = @rfid", con);
                    {
                        cmd.Parameters.AddWithValue("@rfid", dgvEmployee.Rows[e.RowIndex].Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@ename", dgvEmployee.Rows[e.RowIndex].Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@position", dgvEmployee.Rows[e.RowIndex].Cells[3].Value.ToString());
                    }
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Successfully Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRecords();

                }
            }
            else if (colname == "colview")
            {
                
                Check_Attendance g = new Check_Attendance();             
                g.Show();
                g.lblView.Text = dgvEmployee.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //Show Check_Attendance form
           Check_Attendance f = new Check_Attendance();
            f.Show();
        }
    }
}
