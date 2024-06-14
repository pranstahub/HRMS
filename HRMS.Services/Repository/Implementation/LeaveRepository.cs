using HRMS.Services.Repository.Interface;
using HRMS.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Services.Repository.Implementation
{
    public class LeaveRepository : iLeaveRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaveRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Leave>> GetLeaveTypes()
        {
            return await _context.Leaves.ToListAsync();
        }
    }
}
