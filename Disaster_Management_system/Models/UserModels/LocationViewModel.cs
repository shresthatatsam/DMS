namespace Disaster_Management_system.Models.UserModels
{
    public class LocationViewModel
    {
        public Guid Id { get; set; }
        public string Tole { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Municipality { get; set; }
        public string Ward { get; set; }

        // Foreign keys
        public Guid VictimId { get; set; }

        // Navigation properties
        public VictimViewModel Victim { get; set; }
    }
}
