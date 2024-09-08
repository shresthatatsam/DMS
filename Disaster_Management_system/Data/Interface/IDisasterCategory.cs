using Disaster_Management_system.Models.AdminModels;

namespace Disaster_Management_system.Data.Interface
{
    public interface IDisasterCategory
    {
        public DisasterCategoryViewModel Model{ get; set; }
        IEnumerable<DisasterCategoryViewModel> getAllDisasters();
        IEnumerable<DisasterCategoryViewModel> getDisastersByName(Guid id);
    }
}
