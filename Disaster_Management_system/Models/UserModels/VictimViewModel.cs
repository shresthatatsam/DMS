namespace Disaster_Management_system.Models.UserModels
{
    public class VictimViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public bool Status { get; set; }
        public ICollection<PhotosViewModel> Photos { get; set; }
        public ICollection<LocationViewModel> Locations { get; set; }
        public ICollection<DisasterViewModel> Disasters { get; set; }
    }
}
