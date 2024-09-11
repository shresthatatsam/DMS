using Microsoft.AspNetCore.Mvc;

namespace Disaster_Management_system.Controllers.UserController
{
    public class ImageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        //[HttpPost]
        //public IActionResult Create([FromBody] PhotoUploadViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Process each Base64 encoded image
        //        if (model.PhotosBase64 != null && model.PhotosBase64.Any())
        //        {
        //            foreach (var base64 in model.PhotosBase64)
        //            {
        //                var base64Data = base64.Split(',')[1];
        //                var fileName = Guid.NewGuid() + ".png"; // Generate a unique file name
        //                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

        //                // Convert Base64 string to byte array
        //                byte[] imageBytes = Convert.FromBase64String(base64Data);

        //                // Save the image file
        //                System.IO.File.WriteAllBytes(filePath, imageBytes);

        //                // Prepare the JSON data
        //                var photoData = new
        //                {
        //                    Description = model.Description,
        //                    Date = model.Date,
        //                    Url = $"/images/{fileName}",
        //                    VictimId = model.VictimId
        //                };

        //                var jsonData = JsonConvert.SerializeObject(photoData);

        //                // Save JSON data to a file (for example, in wwwroot/json or any other location)
        //                var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/json/photoData.json");

        //                System.IO.File.AppendAllText(jsonFilePath, jsonData + Environment.NewLine);
        //            }
        //        }

        //        return Json(new { success = true });
        //    }

        //    return Json(new { success = false });
        //}
    }

}
