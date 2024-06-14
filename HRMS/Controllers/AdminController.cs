using HRMS.Entity.Security;
using HRMS.Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.Security.Claims;

namespace HRMS.Controllers
{
        [Authorize(Roles = "Admin,Supervisor")]

    public class AdminController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        private readonly IToastNotification _toast;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IToastNotification toast)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _toast = toast;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string UserName, string Password, string ConfirmPassword, int empId)
        {
            RegisterViewModel model = new RegisterViewModel();
            model.UserName = UserName;
            model.Password = Password;
            model.ConfirmPassword = ConfirmPassword;
            model.EmployeeId = empId;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.UserName,
                    EmployeeId = model.EmployeeId
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return NoContent();
                }
                else
                {
                    _toast.AddErrorToastMessage("User Registration Failed!");
                }
            }
             return NoContent();
        }

        public async Task<IActionResult> ListRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole
                {
                    Name = model.Name,
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Employee");
                }
            }
            return View();
        }

        public async Task<IActionResult> AssignRoles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            ViewBag.ID = id;
            ViewBag.username = user.UserName;

            List<ManageRoleViewModel> models = new List<ManageRoleViewModel>();

            foreach (var role in _roleManager.Roles.ToList())
            {
                ManageRoleViewModel manageRolesView = new ManageRoleViewModel()
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    IsSelected = await _userManager.IsInRoleAsync(user, role.Name)

                };
                models.Add(manageRolesView);
            }
            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRoles(List<ManageRoleViewModel> model, string UserId)
        {
            var user = await _userManager.FindByIdAsync(UserId);

            ViewBag.ID = UserId;
            ViewBag.username = user.UserName;

            bool bFlag = false;

            for (int i = 0; i < model.Count; i++)
            {
                IdentityResult result = new IdentityResult();

                if (model[i].IsSelected && !await _userManager.IsInRoleAsync(user, model[i].RoleName))
                {
                    result = await _userManager.AddToRoleAsync(user, model[i].RoleName);
                }
                else if (!model[i].IsSelected && await _userManager.IsInRoleAsync(user, model[i].RoleName))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, model[i].RoleName);
                }
                bFlag = result.Succeeded ? true : false;
            }
            if (bFlag)
            {
                return RedirectToAction("Index", "Employee");
            }
            return RedirectToAction("Index", "Employee");
        }

    }
}
