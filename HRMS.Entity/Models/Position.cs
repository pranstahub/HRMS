using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Models
{
    public class Position
    {
        public Position()
        {
            employees = new HashSet<EmployeeDetail>();
        }

        [Key]
        public int positionId { get; set; }
        [Required]
        public string positionName { get; set; }

        public ICollection<EmployeeDetail> employees { get; set; }
    }
}
