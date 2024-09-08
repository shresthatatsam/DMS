using Disaster_Management;
using Disaster_Management_system.Data.Interface;
using Disaster_Management_system.Models.AdminModels;
using Disaster_Management_system.Models.UserModels;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Management_system.Data
{
    public class DisasterCategory : IDisasterCategory
    {
        public DisasterCategoryViewModel Model{ get; set; }
        public readonly ApplicationDbContext _context;
        public DisasterCategory(ApplicationDbContext context)
        {

            Model = new DisasterCategoryViewModel();
            _context = context;
        }
        public IEnumerable<DisasterCategoryViewModel> getAllDisasters()
        {
            var disasters = _context.DisasterCategory.Select(x => new DisasterCategoryViewModel
            {Id=x.Id,
                Name = x.Name,
                CreatedDate = x.CreatedDate,
                Severity = x.Severity
            }).ToList();
            return disasters;
        }

        public IEnumerable<DisasterCategoryViewModel> getDisastersByName(Guid id)
        {
            var disasters = _context.DisasterCategory.Where(x=>x.Id == id).Select(x => new DisasterCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreatedDate = x.CreatedDate,
                Severity = x.Severity
            });
            return disasters;
        }
    }
   
}
