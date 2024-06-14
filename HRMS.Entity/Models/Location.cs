using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Models
{
    public class Location
    {
        public Location()
        {
            employees = new HashSet<EmployeeDetail>();
        }
        [Key]
        public int locationId { get; set; }
        [Required]

        public string location {  get; set; }

        public ICollection<EmployeeDetail> employees { get; set; }
    }
}
