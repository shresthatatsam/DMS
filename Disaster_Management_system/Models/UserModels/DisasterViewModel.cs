namespace Disaster_Management_system.Models.UserModels
{
    public class DisasterViewModel
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Severity { get; set; }
        public string Date_Occured { get; set; }

        // Foreign keys
        public Guid VictimId { get; set; }

        // Navigation properties
        public VictimViewModel Victim { get; set; }
    }
}
