using HRMS.Entity.Models;
using HRMS.Services.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace HRMS.Controllers
{
    [Authorize]

    public class LeaveController : Controller
    {
        private readonly iLeaveRepository _repository;

        public LeaveController(iLeaveRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Attendance()
        {
            return View();
        }

        public async Task<IActionResult> ListLeaves()
        {
            List<Leave> leaves = new();
            leaves = await _repository.GetLeaveTypes();
            return View(leaves);
        }

        public async Task<IActionResult> ApplyLeave()
        {
            ViewBag.leaves = await _repository.GetLeaveTypes();
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> ApplyLeave(EmployeeLeave leave)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _repository.AddProduct(product);
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
