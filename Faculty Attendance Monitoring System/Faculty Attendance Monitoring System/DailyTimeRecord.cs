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
    public partial class DailyTimeRecord : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        Connection db = new Connection();
       
        public DailyTimeRecord()
        {
            InitializeComponent();
            con = new OleDbConnection(db.GetConnection());
            
        }

        
        private void DailyTimeRecord_Load(object sender, EventArgs e)
        {         
           
        }

        private void btnDispose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvDtr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {            
           
        }
    }
}
