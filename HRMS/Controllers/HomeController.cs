using HRMS.Entity.Models;
using HRMS.Entity.Security;
using HRMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HRMS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var news = new List<News>();
            news = await _context.News.Include(e => e.empDetail).ToListAsync();
            ViewBag.news = news;
            var projects = await _context.EmployeeProjects.Include(p => p.project).ToListAsync();
            ViewBag.projects = projects;
            var trainings = await _context.EmployeeTrainings.Include(t => t.training).ToListAsync();
            ViewBag.trainings = trainings;
            var user = await _userManager.GetUserAsync(User);
            ViewBag.userId = user.EmployeeId;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}