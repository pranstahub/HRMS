using HRMS.Entity.Models;
using HRMS.Services.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace HRMS.Controllers
{
    [Authorize]
    public class OrganisationController : Controller
    {
        private readonly iOrganisationRepository _repository;
        private readonly ApplicationDbContext _context;

        public OrganisationController(iOrganisationRepository repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //-----------------------------------------------------------------------------------------------
        public async Task<IActionResult> CreatePosition()
        {
            Position pos = new Position(); ;
            return View(pos);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePosition(Position pos)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddPosition(pos);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditPosition(int id)
        {
            var pos = await _repository.GetPositionById(id);
            return View(pos);
        }
        [HttpPost]
        public async Task<IActionResult> EditPosition(Position pos)
        {
            if (ModelState.IsValid)
            {
                await _repository.UpdatePosition(pos);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletePosition(int id)
        {
            var pos = await _repository.GetPositionById(id);
            return View(pos);
        }
        [HttpPost]
        [ActionName("DeletePosition")]
        public async Task<IActionResult> ConfrimDeletePosition(int id)
        {
            await _repository.DeletePosition(id);
            return RedirectToAction("Index");
        }

        //------------------------------------------------------------------------------------------------

        public async Task<IActionResult> CreateDepartment()
        {
            Department dept = new Department(); ;
            return View(dept);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDepartment(Department dept)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddDepartment(dept);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditDepartment(int id)
        {
            var dept = await _repository.GetDepartmentById(id);
            return View(dept);
        }
        [HttpPost]
        public async Task<IActionResult> EditDepartment(Department dept)
        {
            if (ModelState.IsValid)
            {
                await _repository.UpdateDepartment(dept);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var dept = await _repository.GetDepartmentById(id);
            return View(dept);
        }
        [HttpPost]
        [ActionName("DeleteDepartment")]
        public async Task<IActionResult> ConfrimDeleteDepartment(int id)
        {
            await _repository.DeleteDepartment(id);
            return RedirectToAction("Index");
        }

        //------------------------------------------------------------------------------------------------

        public async Task<IActionResult> CreateLocation()
        {
            Location loc = new Location(); ;
            return View(loc);
        }
        [HttpPost]
        public async Task<IActionResult> CreateLocation(Location loc)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddLocation(loc);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditLocation(int id)
        {
            var loc = await _repository.GetLocationById(id);
            return View(loc);
        }
        [HttpPost]
        public async Task<IActionResult> EditLocation(Location loc)
        {
            if (ModelState.IsValid)
            {
                await _repository.UpdateLocation(loc);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteLocation(int id)
        {
            var loc = await _repository.GetLocationById(id);
            return View(loc);
        }
        [HttpPost]
        [ActionName("DeleteLocation")]
        public async Task<IActionResult> ConfrimDeleteLocation(int id)
        {
            await _repository.DeleteLocation(id);
            return RedirectToAction("Index");
        }

        //----------------------------------------------------------------------------------------------
        public async Task<JsonResult> getJsonPosition()
        {
            var pos = _context.Positions.GroupJoin(_context.EmployeeDetails,
                p => p.positionId,
                e => e.positionId,
                (position, employees) => new
                    {
                        positionName = position.positionName,
                        id=position.positionId,
                        empCount = employees.Count()
                    }).ToList();

            return Json(new { data = pos });
        }

        public async Task<JsonResult> getJsonDepartment()
        {
            var dept = _context.Departments.GroupJoin(_context.EmployeeDetails,
                d => d.departmentId,
                e => e.deptId,
                (department, employees) => new
                {
                    departmentName = department.departmentName,
                    id = department.departmentId,
                    empCount = employees.Count()
                }).ToList();
            return Json(new { data = dept });
        }

        public async Task<JsonResult> getJsonLocation()
        {
            var loc = _context.Locations.GroupJoin(_context.EmployeeDetails,
                l => l.locationId,
                e => e.locationId,
                (locations, employees) => new
                {
                    locationName = locations.location,
                    id= locations.locationId,
                    empCount = employees.Count()
                }).ToList();
            return Json(new { data = loc });
        }
    }
}
