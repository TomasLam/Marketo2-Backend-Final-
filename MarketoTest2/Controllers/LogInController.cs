using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MarketoTest2.Models;
using System.Threading.Tasks;

public class LogInController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;

    public LogInController(SignInManager<IdentityUser> signInManager)
    {
         _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult LogIn()
    {
        return View();
    }



    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LogIn(LogInViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                 return RedirectToAction("Index", "Home");

            }

            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Index()
    {
        return View();
    }
}
