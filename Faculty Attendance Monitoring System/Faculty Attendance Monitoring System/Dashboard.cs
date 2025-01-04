using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faculty_Attendance_Monitoring_System
{
    public partial class Dashboard : Form
    {    
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            EmployeeList f = new EmployeeList();
            f.TopLevel = false;
            DisplayPanel.Controls.Add(f);
            f.Show();
            f.BringToFront();
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            Records f = new Records();
            f.TopLevel = false;
            DisplayPanel.Controls.Add(f);
            f.Show();
            f.BringToFront();
        }

       

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            Registration f = new Registration();
            f.TopLevel = false;
            DisplayPanel.Controls.Add(f);
            f.Show();          
            f.BringToFront();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {        
            DialogResult result = MessageBox.Show("Do you want to LOGOUT?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Dispose();                         
            }
            else if (result == DialogResult.No)
            {
                return;
            }
        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            Position f = new Position();
            f.TopLevel = false;
            DisplayPanel.Controls.Add(f);
            f.Show();
            f.BringToFront();

        }

        private void btnSched_Click(object sender, EventArgs e)
        {
            Schedules f = new Schedules();
            f.TopLevel = false;
            DisplayPanel.Controls.Add(f);
            f.Show();
            f.BringToFront();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
