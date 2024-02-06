using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectAspNet.Models;

namespace ProjectAspNet.Controllers
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

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            await Register("eden", "Eden9123@");
            await Register("kfir", "Kfir1998@");
            await Register("celine", "Celine!153");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username!, model.Password!, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Admin", "Animal");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Admin", "Animal");
        }
        public async Task<IActionResult> Register(string username, string password)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = username,
            };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return RedirectToAction("Login");
        }
    }
}
