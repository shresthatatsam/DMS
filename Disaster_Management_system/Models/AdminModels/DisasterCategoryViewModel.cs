namespace Disaster_Management_system.Models.AdminModels
{
    public class DisasterCategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Severity { get; set; }

        public DateTime? CreatedDate { get; set; } = default(DateTime?);

    }
}
