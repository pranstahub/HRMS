using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Models
{
    public class Training
    {
        public Training()
        {
            employeeTraining = new HashSet<EmployeeTraining>();
        }
        [Key]
        public int trainingId { get; set; }
        [Required]

        public string training {  get; set; }

        public ICollection<EmployeeTraining> employeeTraining { get; set; }
    }
}
