using HRMS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Services.Repository.Interface
{
    public interface iEmployeeRepository
    {
        Task<List<EmployeeDetail>> GetAllEmployees();
        Task<List<EmployeeDetail>> GetDetailedEmployees();
        Task AddEmployee(EmployeeDetail employee);
        Task UpdateEmployee(EmployeeDetail employee);
        Task DeleteEmployee(int id);
        Task<EmployeeDetail> GetEmployeeById(int id);
        Task<EmployeeDetail> GetDetailedEmployeeById(int id);

    }
}
