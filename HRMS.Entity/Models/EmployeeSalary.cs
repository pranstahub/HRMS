using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Models
{
    public class EmployeeSalary
    {
        [Key]
        public int empSalaryId { get; set; }
        public int empId { get; set; }
        [Required]

        public double annualIncome { get; set; }
        [Required]

        public double taxable {  get; set; }
        [Required]

        public double pfCuts { get; set; }
        
        public EmployeeDetail empDetail { get; set; }
    }
}
