using Career_Search_Project.Areas.Admin.Models;
using Career_Search_Project.Areas.Admin.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Career_Search_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public AccountController(SignInManager<User> signInManager,
        RoleManager<IdentityRole> roleManager,
        UserManager<User> userManager)
        {
            _signInManager = signInManager;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AccountLoginViewModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid)
                return View(model);
            ////var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                if (returnUrl != null)
                    return LocalRedirect(returnUrl); // the localredirect is to avoid 0RedirectVulnearability Attack
                else
                    return RedirectToAction("Index", "Dashboard");

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login details");
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult Register()
        {

            var model = new AccountRegisterViewModel();
            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> RegisterAsync(AccountRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = new User { FullName = model.FullName, Email = model.Email, Tel = model.Tel, UserName = model.Email };

                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    await userManager.AddToRoleAsync(user, model.Role);

                    TempData["StatusMessage"] = "New account created successfully";
                    return RedirectToAction("Register");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    model.UserRoles = GetRolesDropdown();
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }



        [NonAction]
        public ICollection<SelectListItem> GetRolesDropdown()
        {
            return roleManager.Roles.Select(r => new SelectListItem { Text = r.Name, Value = r.Name }).ToList();
        }

        public IActionResult Accessdenied()
        {
            return View();
        }
    }


}