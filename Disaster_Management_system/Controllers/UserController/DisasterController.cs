using Disaster_Management;
using Disaster_Management_system.Data.Interface;
using Disaster_Management_system.Models.AdminModels;
using Disaster_Management_system.Models.UserModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Management_system.Controllers.UserController
{
    public class DisasterController : Controller
    {
        public readonly IDisasterCategory _disasterCategory;
        private readonly ApplicationDbContext _context;

     
        public DisasterController(IDisasterCategory disasterCategory, ApplicationDbContext context) 
        {
            _disasterCategory = disasterCategory;
            _context = context;
        }

        public IActionResult Index()
        {
            //var disasterList = _disasterCategory.getAllDisasters();
            //ViewBag.DisasterList = disasterList;
            return View();
            //ViewBag.disasterList = _disasterCategory.getAllDisasters();
            //return View();
        }

        [HttpGet]
        public IActionResult GetDisasterDropdownOptions()
        {
            var disasterList = _disasterCategory.getAllDisasters();

            // Convert to view model if necessary
            var viewModelList = disasterList.Select(d => new DisasterCategoryViewModel
            {
                Name = d.Name,
                Id = d.Id,
                Severity = d.Severity
            }).ToList();

            // Return the partial view with the list as the model
            return PartialView("_DisasterDropdownPartial", viewModelList);
        }

        [HttpGet]
        public IActionResult getDisasterCategoryByName(Guid id)
        {
           var data= _disasterCategory.getDisastersByName(id);
            return Json(data);
        }


        [HttpPost]
        public async Task<IActionResult> Create(DisasterViewModel model)
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
            var disaster = new DisasterViewModel
            {
                Id = Guid.NewGuid(),
                Category = model.Category,
                Severity = model.Severity,
                Date_Occured = DateTime.UtcNow.ToString("yyyy-MM-dd"),
                VictimId = userId
            };

            _context.Disasters.Add(disaster);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Image");
        }


    }
}
