using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PL.ViewModels;  
namespace PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
        private readonly Microsoft.AspNetCore.Identity.SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM uservm)
        {
            if (ModelState.IsValid)
            {
                // save  in db
                ApplicationUser user = new ApplicationUser
                {
                    UserName = uservm.Username,
                    Address = uservm.Address
                };
                IdentityResult result = await _userManager.CreateAsync(user, uservm.Password);
                if (result.Succeeded)
                {
                    // create cookie
                    await _signInManager.SignInAsync(user, isPersistent: false);
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(" ", item.Description);
                    }
                    return View(uservm);
                }
                return RedirectToAction("login", "Account");
            }
            return View(uservm);
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login", "Account");

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginvm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByNameAsync(loginvm.Username);
                if (user != null)
                {
                   bool found = await _userManager.CheckPasswordAsync(user, loginvm.Password);
                    if (found)
                    {
                        //Create cookie
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Student");
                    }
                    else
                    {
                        ModelState.AddModelError(" ", "Invalid username or password");
                        return View(loginvm);

                    }
                }
            }
            return View(loginvm);
        }
    }
}
