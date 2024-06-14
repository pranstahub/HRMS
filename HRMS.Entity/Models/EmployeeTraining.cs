using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Models
{
    public class EmployeeTraining
    {
        public EmployeeTraining()
        {
            jnEmpTraining = new HashSet<JnEmployeeTraining>();
        }
        [Key]
        public int empTrainingId { get; set; }

        public int empId { get; set; }

        public int trainingId { get; set; }

        public int projectId { get; set; }

        public double bond { get; set; }

        public ICollection<JnEmployeeTraining> jnEmpTraining { get; set;}

        public Training training { get; set; }
    }
}
