using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Models
{
    public class Department
    {
        public Department()
        {
            employeeDetails = new HashSet<EmployeeDetail>();
        }

        [Key]
        public int departmentId { get; set; }
        [Required]

        public string departmentName { get; set; }  

        public ICollection<EmployeeDetail> employeeDetails { get; set; }
    }
}
