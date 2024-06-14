using HRMS.Entity.Models;
using HRMS.Entity.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace HRMS.Controllers
{
    [Authorize]
    public class WorkController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public WorkController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        public async Task<IActionResult> Index()
        {
            var proj = new List<EmployeeProject>();
            proj = await _context.EmployeeProjects.Include(p => p.project).ToListAsync();
            ViewBag.projects = proj;
            var tr = new List<EmployeeTraining>();
            tr = await _context.EmployeeTrainings.Include(t => t.training).ToListAsync();
            ViewBag.trainings = tr;
            var user = await _userManager.GetUserAsync(User);
            ViewBag.userId = user.EmployeeId;
            return View();
        }

        public async Task<IActionResult> CreateProject()
        {
            Project project = new Project(); 
            return View(project);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProject(Project pos)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.AddAsync(pos);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateTraining()
        {
            Training training = new Training(); 
            return View(training);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTraining(Training t)
        {
            if (ModelState.IsValid)
            {
                _context.Trainings.AddAsync(t);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AssignProject()
        {
            EmployeeProject project = new EmployeeProject();
            var employees = await _context.EmployeeDetails.ToListAsync();
            var projects = await _context.Projects.ToListAsync();
            ViewBag.projects = projects;
            ViewBag.employees = employees;
            return View(project);
        }
        [HttpPost]
        public async Task<IActionResult> AssignProject(EmployeeProject pos)
        {
           
                _context.EmployeeProjects.AddAsync(pos);
                await _context.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }
    }
}
