using Disaster_Management;
using Disaster_Management_system.Models.UserModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Management_system.Controllers.UserController
{
    public class LocationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Create(LocationViewModel model)
        {
            var userIdString = HttpContext.Session.GetString("VictimId");

            Guid userId;
            if (Guid.TryParse(userIdString, out userId))
            {
                ViewBag.UserId = userId;
            }
            else
            {
                ViewBag.UserId = Guid.Empty;
            }
            var location = new LocationViewModel
            {
                Id = Guid.NewGuid(),
                Tole = model.Tole,
                Province = model.Province,
                District = model.District,
                Municipality = model.Municipality,
                Ward = model.Ward,
                VictimId = userId
            };
             
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Disaster");
        }

       
    }
}
