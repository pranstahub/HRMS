using HRMS.Entity.Models;
using HRMS.Services.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Services.Repository.Implementation
{
    public class EmployeeRepository : iEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task<List<EmployeeDetail>> GetAllEmployees()
        {
            return await _context.EmployeeDetails.ToListAsync();
        }

        public async Task<List<EmployeeDetail>> GetDetailedEmployees()
        {
            return await _context.EmployeeDetails.Include(e => e.salary).Include(e => e.department).
                                                    Include(e => e.position).Include(e => e.location).ToListAsync();
        }

        public async Task AddEmployee(EmployeeDetail employee)
        {
            _context.EmployeeDetails.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployee(EmployeeDetail employee)
        {
            _context.EmployeeDetails.Update(employee);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteEmployee(int id)
        {
            var employee = await _context.EmployeeDetails.FindAsync(id);
            _context.EmployeeDetails.Remove(employee);
            await _context.SaveChangesAsync();
        }
        public async Task<EmployeeDetail> GetEmployeeById(int id)
        {
            return await _context.EmployeeDetails.FindAsync(id);
        }
        public async Task<EmployeeDetail> GetDetailedEmployeeById(int id)
        {
            return await _context.EmployeeDetails.Include(e => e.salary).Include(e => e.department).
                                                    Include(e => e.position).Include(e => e.location).FirstOrDefaultAsync(e=>e.empId == id);
        }



    }
}
