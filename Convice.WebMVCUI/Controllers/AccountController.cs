using System;
using System.Threading.Tasks;
using Convice.Entities.IdentityEntities;
using Convice.WebMVCUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Convice.WebMVCUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<CustomIdentityUser> _userManager;
        private SignInManager<CustomIdentityUser> _signInManager;
        private RoleManager<CustomIdentityRole> _roleManager;

        public AccountController(UserManager<CustomIdentityUser> userManager, SignInManager<CustomIdentityUser> signInManager, RoleManager<CustomIdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public string Index()
        {
            return "hello";
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = new CustomIdentityUser { UserName = model.UserName, Email = model.Email,FirstName = model.FirstName,LastName = model.LastName};
                var result = await _userManager.CreateAsync(user, model.Password);
              
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    await _userManager.AddToRoleAsync(user, "Admin");
                    return RedirectToAction("List", "Content");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("List", "Content");
                }
                
            }
            ModelState.AddModelError(string.Empty, "Kullanýcý Bulunamadý.");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public string Den()
        {
          var user = _userManager.GetUserAsync(HttpContext.User).Result;
            return user.FirstName;
        }
    }
}