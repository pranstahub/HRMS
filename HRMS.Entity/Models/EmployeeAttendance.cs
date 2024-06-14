using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Models
{
    public class EmployeeAttendance
    {
        [Key]
        public int attendanceId { get; set; }

        public int empId { get; set; }

        public DateTime timeIn { get; set; }

        public DateTime timeOut { get; set; }

        //public string remarks { get; set; }

        public EmployeeDetail empDetail { get; set; }

    }
}
