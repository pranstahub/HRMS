using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.ViewModels
{
    public class RoleViewModel
    {
        [Display(Name = "Role")]
        public string Name { get; set; }
    }
}
