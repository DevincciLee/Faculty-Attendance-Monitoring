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
    public partial class Position : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
       
        Connection db = new Connection();
        public Position()
        {
            InitializeComponent();
            con = new OleDbConnection(db.GetConnection());
            LoadRecords();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }
        public void LoadRecords()
        {
            // For displaying the positions in the datagridview
            dgvPosition.Rows.Clear();
            int i = 0;
            con.Open();
            cmd = new OleDbCommand("SELECT * FROM [Position]", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvPosition.Rows.Add(i, dr["position"].ToString(), dr["ID"].ToString());
            }
            dr.Close();
            con.Close();

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Inserting data in the database

            try
            {
                if (txtposition.Text == "")
                {
                    MessageBox.Show("Required Missing Field", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                con.Open();
                cmd = new OleDbCommand("INSERT INTO [Position] ([position], [ID]) VALUES (@position, @ID)", con);
                cmd.Parameters.AddWithValue("@position", txtposition.Text);
                cmd.Parameters.AddWithValue("@ID", txtID.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRecords();
                txtposition.Text = "";
                txtID.Text = "";
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Updating data in the database

            DialogResult result = MessageBox.Show("Do you want to update this file?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    cmd = new OleDbCommand("UPDATE [Position] SET [position] = @position, [ID] = @ID WHERE [ID] = @ID", con);
                    cmd.Parameters.AddWithValue("@position", txtposition.Text);
                    cmd.Parameters.AddWithValue("@ID", txtID.Text);
                    int rowsaffected = cmd.ExecuteNonQuery();
                    con.Close();

                    if (rowsaffected > 0)
                    {
                        MessageBox.Show("Record Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRecords();
                        txtposition.Text = "";
                        txtID.Text = "";
                        btnSave.Enabled = true;
                        btnUpdate.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Record not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvPosition_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Edit and delete buttons 

            string colname = dgvPosition.Columns[e.ColumnIndex].Name;

            if (colname == "columnEdit")
            {
                con.Open();
                txtposition.Text = dgvPosition.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtID.Text = dgvPosition.Rows[e.RowIndex].Cells[2].Value.ToString();
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                con.Close();
            }
            else if (colname == "columnDelete")
                if (MessageBox.Show("You want to delete this file?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new OleDbCommand("DELETE FROM [Position] WHERE [ID] = @ID", con);
                    {                      
                        cmd.Parameters.AddWithValue("@ID", dgvPosition.Rows[e.RowIndex].Cells[2].Value.ToString());
                    }
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Successfully Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRecords();
                }
        }
    }
}
