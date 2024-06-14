using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Models
{
    public class Leave
    {
        public Leave()
        {
            empLeaves = new HashSet<EmployeeLeave>();
        }
        [Key]
        public int leaveId { get; set; }

        public string leaveName { get; set; }

        public int days { get; set; }

        public ICollection<EmployeeLeave> empLeaves { get; set; }
    }
}
