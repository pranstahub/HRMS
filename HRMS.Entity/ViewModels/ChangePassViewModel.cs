using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.ViewModels
{
    public class ChangePassViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]

        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]

        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match!")]
        [Display(Name = "Confirm New Password")]

        public string ConfirmNewPassword { get; set; }
    }
}
