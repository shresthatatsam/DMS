using Disaster_Management_system.Data.Interface;
using Disaster_Management_system.Models;
using Microsoft.AspNetCore.Mvc;

namespace Disaster_Management_system.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authService;

        public AccountController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.LoginAsync(model.Username, model.Password);
                if (result.Succeeded)
                {
                    // Redirect to a success page or the home page
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Display error message
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View(model);
        }
    }
}
