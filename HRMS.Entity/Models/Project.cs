using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Models
{
    public class Project
    {
        public Project()
        {
            employeeProjects = new HashSet<EmployeeProject>();  
        }
        [Key]
        public int projectId { get; set; }
        [Required]

        public string project {  get; set; }

        public ICollection<EmployeeProject>? employeeProjects { get; set; }
    }
}
