using Disaster_Management;
using Disaster_Management_system.Models.UserModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Management_system.Controllers.UserController
{
    public class VictimController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VictimController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VictimViewModel model)
        {
            
            var victim = new VictimViewModel
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Age = model.Age,
                Gender = model.Gender,
                ContactNumber = model.ContactNumber,
                //Password = model.Password,
                Status = true,
              
            };

            _context.Victims.Add(victim);
            await _context.SaveChangesAsync();

            HttpContext.Session.SetString("VictimId", victim.Id.ToString());

            return RedirectToAction("Index", "Location");
        }

        //[HttpGet]
        //public async Task<IActionResult> getallData()
        //{
        //    var userIdString = HttpContext.Session.GetString("VictimId");

        //    Guid userId;
        //    if (Guid.TryParse(userIdString, out userId))
        //    {
        //        ViewBag.UserId = userId;
        //    }
        //    else
        //    {
        //        ViewBag.UserId = Guid.Empty;
        //    }

        //   var data= _context.Victims.Where(x => x.Id == userId).FirstOrDefault();
        //    return Json(new
        //    {
        //        success = true,
        //        data = new
        //        {
        //            data.Id,
        //            data.Name,
        //            data.Age,
        //            data.Gender,
        //            data.ContactNumber
        //        }
        //    });

        //}


    }
}
