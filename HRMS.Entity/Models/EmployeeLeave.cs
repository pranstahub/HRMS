using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Models
{
    public class EmployeeLeave
    {
        [Key]
        public int empLeaveId { get; set; }

        public int empId { get; set; }

        public int leaveId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime startDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime endDate { get; set; }

        public double totalDays { get; set; }

        public EmployeeDetail empDetail { get; set; }

        public Leave leave { get; set; }

    }
}
