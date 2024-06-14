using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.Models
{
    public class EmployeeDetail
    {
        public EmployeeDetail()
        {
            attendances = new HashSet<EmployeeAttendance>();
            leaves = new HashSet<EmployeeLeave>();
            jnEmployeeProjects = new HashSet<JnEmployeeProject>();
            jnEmpTraining = new HashSet<JnEmployeeTraining>();
            news = new HashSet<News>();
        }

        [Key]
        [Display(Name = "Emp ID")]
        public int empId { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Display(Name = "Middle Name")]
        public string? midName { get; set; }

        [Required]
        [Display(Name = "Position ID")]
        public int positionId { get; set; }

        [Required]
        [Display(Name = "Department ID")]
        public int deptId { get; set; }

        [Required]
        [Display(Name = "Location ID")]
        public int locationId { get; set; }

        [Required]
        [Display(Name = "DOB")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime birthDate { get; set; }

        [Display(Name = "Age")]
        public int age { get; set; }

        [Required]
        [Display(Name = "Sex")]
        public string sex { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string address { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        [Display(Name = "Date of Employment")]
        public DateTime employedDate { get; set; }

        [Display(Name = "Supervisor")]
        public int? supervisorId { get; set; }

        //[Required]
        [Display(Name = "PFP")]
        public string? image { get; set; }

        [NotMapped]
        public IFormFile? filepath { get; set; }

        public Department? department { get; set; }

        public ICollection<EmployeeAttendance>? attendances { get; set; }
        public ICollection<EmployeeLeave>? leaves { get; set; }
        public ICollection<JnEmployeeProject>? jnEmployeeProjects { get; set; }
        
        public EmployeeSalary? salary { get; set; }

        public ICollection<JnEmployeeTraining>? jnEmpTraining { get; set; }

        public Location? location{ get; set; }

        public ICollection<News>? news { get; set; }

        public Position? position { get; set; }

    }
}
