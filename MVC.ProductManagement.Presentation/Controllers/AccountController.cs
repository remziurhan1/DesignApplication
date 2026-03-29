using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.ProductManagement.Presentation.Models.AccountVMs;

namespace MVC.ProductManagement.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                await Console.Out.WriteLineAsync("Login işlemi başarısız");
                return View(model);
            }

            var checkPassword = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (!checkPassword.Succeeded)
            {
                await Console.Out.WriteLineAsync("Login işlemi başarısız");
                return View(model);
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            if (userRoles == null || !userRoles.Any())
            {
                await Console.Out.WriteLineAsync("Login işlemi başarısız");
                return View(model);
            }

            if (userRoles.Contains("Admin"))
            {
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }

            if (userRoles.Contains("Sales"))
            {
                return RedirectToAction("Index", "Home", new { Area = "Sales" });
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
