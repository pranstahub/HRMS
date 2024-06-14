using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Models
{
    public class JnEmployeeProject
    {
        [Key]
        public int jnId { get; set; }

        [Required]
        public int empId { get; set; }

        [Required]
        public int projectID { get; set; }

        public EmployeeDetail employeeDetail { get; set; }
        public EmployeeProject project { get; set; }
    }
}
