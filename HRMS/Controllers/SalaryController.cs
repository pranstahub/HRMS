using HRMS.Entity.Models;
using HRMS.Entity.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using NuGet.Protocol.Core.Types;

namespace HRMS.Controllers
{
    [Authorize]
    public class SalaryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private readonly IToastNotification _toast;

        public SalaryController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            IToastNotification toast)
        {
            _context = context;
            _userManager = userManager;
            _toast = toast;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var empId = user.EmployeeId;
            var sal = _context.EmployeeSalaries.FirstOrDefault(e => e.empId == empId);
            return View(sal);
        }


        [HttpPost]
        public async Task<IActionResult> Create(float annualIncome, float taxable, float pfCuts, int empId)
        {
            EmployeeSalary sal = new EmployeeSalary();
            sal.empId = empId;
            sal.taxable = taxable;
            sal.annualIncome = annualIncome;
            sal.pfCuts = pfCuts;

            if (ModelState.IsValid)
            {
                await _context.EmployeeSalaries.AddAsync(sal);
                await _context.SaveChangesAsync();
                _toast.AddSuccessToastMessage("Employee Registered!");

            }
            return NoContent();
        }

        //public async Task<IActionResult> EditPosition(int id)
        //{
        //    var pos = await _repository.GetPositionById(id);
        //    return View(pos);
        //}
        //[HttpPost]
        //public async Task<IActionResult> EditPosition(Position pos)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _repository.UpdatePosition(pos);
        //    }
        //    return RedirectToAction("Index");
        //}

        //public async Task<IActionResult> DeletePosition(int id)
        //{
        //    var pos = await _repository.GetPositionById(id);
        //    return View(pos);
        //}
        //[HttpPost]
        //[ActionName("DeletePosition")]
        //public async Task<IActionResult> ConfrimDeletePosition(int id)
        //{
        //    await _repository.DeletePosition(id);
        //    return RedirectToAction("Index");
        //}
    }
}
