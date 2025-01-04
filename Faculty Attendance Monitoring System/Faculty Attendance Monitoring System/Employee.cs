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
    public partial class Employee : Form
    {
        EmployeeList f = new EmployeeList();
        OleDbConnection con;
        OleDbCommand cmd;

        Connection db = new Connection();
        public Employee()
        {
            InitializeComponent();
            con = new OleDbConnection(db.GetConnection());
            btnUpdate.Enabled = false;
        }

        private void btnDispose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbrfid.Text == "" || tbname.Text == "" || cmbPosition.Text == "")
                {
                    MessageBox.Show("Required Missing Field", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    con.Open();
                    cmd = new OleDbCommand("INSERT INTO Employees ([rfid], [ename], [position], [mondaysched], [mondayvacant], [tuesdaysched], [tuesdayvacant], [wednesdaysched], [wednesdayvacant], [thursdaysched], [thursdayvacant], [fridaysched], [fridayvacant], [saturdaysched], [saturdayvacant]) " +
                        "VALUES (@rfid, @ename, @position, @mondaysched, @mondayvacant, @tuesdaysched, @tuesdayvacant, @wednesdaysched, @wednesdayvacant, @thursdaysched, @thursdayvacant, @fridaysched, @fridayvacant, @saturdaysched, @saturdayvacant)", con);
                    cmd.Parameters.AddWithValue("@rfid", tbrfid.Text);
                    cmd.Parameters.AddWithValue("@ename", tbname.Text);
                    cmd.Parameters.AddWithValue("@position", cmbPosition.Text);
                    cmd.Parameters.AddWithValue("@mondaysched", tbmonsched.Text);
                    cmd.Parameters.AddWithValue("@mondayvacant", tbmonvacant.Text);
                    cmd.Parameters.AddWithValue("@tuesdaysched", tbtuesched.Text);
                    cmd.Parameters.AddWithValue("@tuesdayvacant", tbtuesvacant.Text);
                    cmd.Parameters.AddWithValue("@wednesdaysched", tbwedsched.Text);
                    cmd.Parameters.AddWithValue("@wednesdayvacant", tbwedvacant.Text);
                    cmd.Parameters.AddWithValue("@thursdaysched", tbthursched.Text);
                    cmd.Parameters.AddWithValue("@thursdayvacant", tbthursvacant.Text);
                    cmd.Parameters.AddWithValue("@fridaysched", tbfrisched.Text);
                    cmd.Parameters.AddWithValue("@fridayvacant", tbfrivacant.Text);
                    cmd.Parameters.AddWithValue("@saturdaysched", tbsatsched.Text);
                    cmd.Parameters.AddWithValue("@saturdayvacant", tbsatvacant.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.LoadRecords();
                    this.Dispose();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to update this file?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    cmd = new OleDbCommand("UPDATE Employees SET [rfid] = @rfid, [ename] = @ename, [position] = @position, [mondaysched] = @mondaysched, [mondayvacant] = @mondayvacant, [tuesdaysched] = @tuesdaysched, [tuesdayvacant] = @tuesdayvacant, [wednesdaysched] = @wednesdaysched, [wednesdayvacant] = @wednesdayvacant, [thursdaysched] = @thursdaysched, [thursdayvacant] = @thursdayvacant, [fridaysched] = @fridaysched, [fridayvacant] = @fridayvacant, [saturdaysched] = @saturdaysched, [saturdayvacant] = @saturdayvacant WHERE [rfid] = @rfid", con);
                    cmd.Parameters.AddWithValue("@rfid", tbrfid.Text);
                    cmd.Parameters.AddWithValue("@ename", tbname.Text);
                    cmd.Parameters.AddWithValue("@position", cmbPosition.Text);
                    cmd.Parameters.AddWithValue("@mondaysched", tbmonsched.Text);
                    cmd.Parameters.AddWithValue("@mondayvacant", tbmonvacant.Text);
                    cmd.Parameters.AddWithValue("@tuesdaysched", tbtuesched.Text);
                    cmd.Parameters.AddWithValue("@tuesdayvacant", tbtuesvacant.Text);
                    cmd.Parameters.AddWithValue("@wednesdaysched", tbwedsched.Text);
                    cmd.Parameters.AddWithValue("@wednesdayvacant", tbwedvacant.Text);
                    cmd.Parameters.AddWithValue("@thursdaysched", tbthursched.Text);
                    cmd.Parameters.AddWithValue("@thursdayvacant", tbthursvacant.Text);
                    cmd.Parameters.AddWithValue("@fridaysched", tbfrisched.Text);
                    cmd.Parameters.AddWithValue("@fridayvacant", tbfrivacant.Text);
                    cmd.Parameters.AddWithValue("@saturdaysched", tbsatsched.Text);
                    cmd.Parameters.AddWithValue("@saturdayvacant", tbsatvacant.Text);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("RFID cannot be changed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            // To populate the combo box(position) in the employees form
            try
            {
                con.Open();
                cmd = new OleDbCommand("SELECT * FROM [Position]", con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                cmbPosition.DataSource = dt;
                cmbPosition.DisplayMember = "position";
                cmbPosition.ValueMember = "position";
                cmbPosition.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}
