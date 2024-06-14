using HRMS.Entity.Models;
using HRMS.Entity.ViewModels;
using HRMS.Services.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Controllers
{
    [Authorize(Roles = "Admin")]

    public class EmployeeController : Controller
    {
        private readonly iOrganisationRepository _orgRepository;
        private readonly iEmployeeRepository _repository;
        private readonly IWebHostEnvironment _env;

        public EmployeeController(iOrganisationRepository orgRepository, iEmployeeRepository repository, IWebHostEnvironment env)
        {
            _orgRepository = orgRepository;
            _repository = repository;
            _env = env;
        }
        public IActionResult Index()
        {
            var emp = new List<EmployeeDetail>();
            return View(emp);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.positions = await _orgRepository.GetPositions();
            ViewBag.departments = await _orgRepository.GetDepartments();
            ViewBag.locations = await _orgRepository.GetLocations();
            ViewBag.emp = await _repository.GetAllEmployees();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string firstName, string lastName, string midName,
           int positionId, int deptId, int locationId, DateTime birthDate, int age, string sex, string address,
           int supervisorId/*, IFormFile filepath*/)
        {
            EmployeeDetail emp = new EmployeeDetail();
            emp.firstName = firstName;
            emp.lastName = lastName;
            emp.midName = midName;
            emp.positionId = positionId;
            emp.deptId = deptId;
            emp.locationId = locationId;
            emp.birthDate = birthDate;
            emp.age = age;
            emp.sex = sex;
            emp.address = address;
            emp.employedDate = DateTime.Now;
            emp.supervisorId = supervisorId;
            //emp.filepath = filepath;

            //string fullPath = string.Empty;
            //if (emp.filepath != null)
            //{
            //    var imagePath = Path.Combine(_env.WebRootPath, "Images");
            //    string filename = emp.firstName + emp.filepath.FileName;
            //    fullPath = Path.Combine(imagePath, filename);
            //    if (!System.IO.File.Exists(fullPath))
            //    {
            //        emp.filepath.CopyTo(new FileStream(fullPath, FileMode.Create));
            //    }
            //    emp.image = filename;
            //}

            await _repository.AddEmployee(emp);

            return Ok(emp.empId);
        }



        //public async Task<IActionResult> Edit(int id)
        //{
        //    var customer = await _repository.GetCustomerById(id);
        //    var category = await _repository.GetCategory();
        //    ViewBag.category = category;
        //    return View(customer);
        //}

        //[HttpPost]
        //[Authorize(Policy = "EditPolicy")]

        //public async Task<IActionResult> Edit(Customer cus)
        //{
        //    string fullPath = string.Empty;

        //    if (cus.filepath != null)
        //    {
        //        var imagePath = Path.Combine(_env.WebRootPath, "Images");
        //        string filename = cus.firstName + cus.filepath.FileName;
        //        fullPath = Path.Combine(imagePath, filename);
        //        if (!System.IO.File.Exists(fullPath))
        //        {
        //            cus.filepath.CopyTo(new FileStream(fullPath, FileMode.Create));
        //        }
        //        cus.image = filename;
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        await _repository.UpdateCustomer(cus);
        //    }
        //    return RedirectToAction("Index");
        //}

        //[Authorize(Policy = "DeletePolicy")]

        //public async Task<IActionResult> Delete(int id)
        //{
        //    var customer = await _repository.GetCustomerById(id);
        //    return View(customer);
        //}

        //[HttpPost]
        //[ActionName("Delete")]
        //[Authorize(Policy = "DeletePolicy")]
        //public async Task<IActionResult> ConfrimDelete(int id)
        //{
        //    //var customer = _repository.GetCustomerById(id);
        //    await _repository.DeleteCustomerById(id);
        //    return RedirectToAction("Index");
        //}

        //public async Task<IActionResult> Details(int id)
        //{
        //    var customer = await _repository.GetCustomerById(id);
        //    return View(customer);
        //}

        public async Task<JsonResult> getJsonEmployee()
        {
            var emp = await _repository.GetDetailedEmployees();
            return Json(new { data = emp });
        }

        public async Task<IActionResult> Details(int id)
        {
            var emp = await _repository.GetDetailedEmployeeById(id);
            return View(emp);
        }
    }
}
