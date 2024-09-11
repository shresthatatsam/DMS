using Disaster_Management;
using Disaster_Management_system.Models.UserModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Disaster_Management_system.Controllers.UserController
{
    public class ImageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImageController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public class PhotoUploadViewModel
        {
            public string Description { get; set; }
            public DateTime Date { get; set; }
            public string VictimId { get; set; }
            public List<IFormFile> Photos { get; set; }
        }

        [HttpPost]
        public IActionResult Create([FromForm] PhotoUploadViewModel model)
        {
            var userIdString = HttpContext.Session.GetString("VictimId");

            if (!Guid.TryParse(userIdString, out var userId))
            {
                userId = Guid.Empty;
            }

            // Process each file in the Photos collection
            foreach (var photo in model.Photos)
            {
                if (photo != null && photo.Length > 0)
                {
                    // Optionally, process the file (e.g., save to disk or cloud storage)
                    using (var memoryStream = new MemoryStream())
                    {
                       photo.CopyToAsync(memoryStream);
                        var photoData = new PhotosViewModel
                        {
                            Description = model.Description,
                            Date = model.Date,
                            Url = Convert.ToBase64String(memoryStream.ToArray()),
                            VictimId = userId
                        };

                        _context.Photos.Add(photoData);
                        _context.SaveChangesAsync();
                    }
                }
            }

            return Json(new { success = true });
        }



       
    }

}
