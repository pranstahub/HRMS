using HRMS.Entity.Models;
using HRMS.Entity.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public NewsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            var news = new List<News>();
            news = await _context.News.Include(e=> e.empDetail).ToListAsync();
            return View(news);
        }

        public IActionResult AddNews()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNews(News n)
        {
            var user = await _userManager.GetUserAsync(User);
            var empId = user.EmployeeId;
            n.empId = (int)empId;
            _context.News.Add(n);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "News");
        }
    }
}
