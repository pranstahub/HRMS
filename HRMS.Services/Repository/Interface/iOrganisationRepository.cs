using HRMS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Services.Repository.Interface
{
    public interface iOrganisationRepository
    {
        Task<List<Position>> GetPositions();
        Task<List<Department>> GetDepartments();
        Task<List<Location>> GetLocations();

        Task AddPosition(Position position);
        Task UpdatePosition(Position position);
        Task DeletePosition(int id);
        Task<Position> GetPositionById(int id);


        Task AddDepartment(Department department);
        Task UpdateDepartment(Department department);
        Task DeleteDepartment(int id);
        Task<Department> GetDepartmentById(int id);


        Task AddLocation(Location location);
        Task UpdateLocation(Location location);
        Task DeleteLocation(int id);
        Task<Location> GetLocationById(int id);


    }
}
