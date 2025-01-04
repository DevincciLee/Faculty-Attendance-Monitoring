using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculty_Attendance_Monitoring_System
{
    class Connection
    {
        public string GetConnection()
        {
            string con = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Documents\Faculty Attendance Monitoring System\FAMS_DB.accdb";
            return con;
        }
    }
}
