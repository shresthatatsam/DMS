namespace Disaster_Management_system.Models.UserModels
{
    public class PhotosViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
     

        // Foreign keys
        public Guid VictimId { get; set; }

        // Navigation properties
        public VictimViewModel Victim { get; set; }
    }
}
