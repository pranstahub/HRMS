﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entity.ViewModels
{
    public class RoleClaimsViewModel
    {
        public RoleClaimsViewModel()
        {
            Claims = new List<RoleClaim>();
        }

        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public List<RoleClaim> Claims { get; set; }

    }

    public class RoleClaim
    {
        public string ClaimType { get; set; }
        public bool IsSelected { get; set; }
    }
}
