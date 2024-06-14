using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Models
{
    public class EmployeeProject
    {
        public EmployeeProject()
        {
            jnEmployeeProjects = new HashSet<JnEmployeeProject>();
        }
        [Key]
        public int empProjectId { get; set; }

        public int empId { get; set; }

        public int projectId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime dateStarted { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime dateEnded { get; set; }

        public string status { get; set; }

        public ICollection<JnEmployeeProject> jnEmployeeProjects { get; set; }

        public Project project { get; set; }

    }
}
