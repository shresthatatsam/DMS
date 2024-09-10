using Microsoft.AspNetCore.Mvc;

namespace Disaster_Management_system.Controllers.UserController
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
