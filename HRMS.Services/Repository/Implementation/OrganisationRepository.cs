using HRMS.Entity.Models;
using HRMS.Services.Repository.Interface;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Services.Repository.Implementation
{
    public class OrganisationRepository : iOrganisationRepository
    {
        private readonly ApplicationDbContext _context;

        public OrganisationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Position>> GetPositions()
        {
                return await _context.Positions.ToListAsync();
        }
        public async Task<List<Department>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }
        public async Task<List<Location>> GetLocations()
        {
            return await _context.Locations.ToListAsync();
        }


        public async Task AddPosition(Position pos)
        {
            _context.Positions.Add(pos);
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePosition(Position pos)
        {
            _context.Positions.Update(pos);
            await _context.SaveChangesAsync();
        }
        public async Task DeletePosition(int id)
        {
            var pos = await _context.Positions.FindAsync(id);
            _context.Positions.Remove(pos);
            await _context.SaveChangesAsync();
        }
        public async Task<Position> GetPositionById(int id)
        {
            return await _context.Positions.FindAsync(id);
        }


        public async Task AddDepartment(Department dept)
        {
            _context.Departments.Add(dept);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateDepartment(Department dept)
        {
            _context.Departments.Update(dept);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteDepartment(int id)
        {
            var dept = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(dept);
            await _context.SaveChangesAsync();
        }
        public async Task<Department> GetDepartmentById(int id)
        {
            return await _context.Departments.FindAsync(id);
        }


        public async Task AddLocation(Location loc)
        {
            _context.Locations.Add(loc);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateLocation(Location loc)
        {
            _context.Locations.Update(loc);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteLocation(int id)
        {
            var loc = await _context.Locations.FindAsync(id);
            _context.Locations.Remove(loc);
            await _context.SaveChangesAsync();
        }
        public async Task<Location> GetLocationById(int id)
        {
            return await _context.Locations.FindAsync(id);
        }

    }
}
