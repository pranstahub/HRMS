using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Models
{
    public class News
    {
        [Key]
        public int newsId { get; set; }
        [Required]

        public string description { get; set; }
        [Required]

        public string summary { get; set; }

        public int empId { get; set; }

        public EmployeeDetail empDetail { get; set; }
    }
}
