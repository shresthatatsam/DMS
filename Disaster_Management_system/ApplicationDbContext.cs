using Microsoft.EntityFrameworkCore;
using Disaster_Management_system.Models.UserModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Disaster_Management_system.Models.AdminModels;
namespace Disaster_Management
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<LocationViewModel> Locations { get; set; }
        public DbSet<VictimViewModel> Victims { get; set; }
        public DbSet<PhotosViewModel> Photos { get; set; }
        public DbSet<DisasterViewModel> Disasters { get; set; }
        public DbSet<DisasterCategoryViewModel> DisasterCategory { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LocationViewModel>(entity =>
            {
                entity.ToTable("user_location");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Province).IsRequired();
                entity.Property(e => e.District).IsRequired();
                entity.Property(e => e.Municipality).IsRequired();
                entity.Property(e => e.Ward).IsRequired();
                entity.Property(e => e.Tole).IsRequired();
                
                entity.HasOne(p => p.Victim)
                      .WithMany(v => v.Locations)
                      .HasForeignKey(p => p.VictimId);
            });

            modelBuilder.Entity<VictimViewModel>(entity =>
            {
                entity.ToTable("victims");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Age).IsRequired();
                entity.Property(e => e.Gender).IsRequired();
                entity.Property(e => e.ContactNumber).IsRequired();
                entity.Property(e => e.Status).IsRequired();
                entity.Property(e => e.Password).IsRequired();
            });

            modelBuilder.Entity<DisasterViewModel>(entity =>
            {
                entity.ToTable("disasters");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Category).IsRequired();
                entity.Property(e => e.Severity).IsRequired();
                entity.Property(e => e.Date_Occured).IsRequired();
                entity.HasOne(p => p.Victim)
                    .WithMany(v => v.Disasters)
                    .HasForeignKey(p => p.VictimId);
            });

            modelBuilder.Entity<PhotosViewModel>(entity =>
            {
                entity.ToTable("photos");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.Url).IsRequired();
                entity.HasOne(p => p.Victim)
                      .WithMany(v => v.Photos)
                      .HasForeignKey(p => p.VictimId);
            });

                 modelBuilder.Entity<DisasterCategoryViewModel>(entity =>
            {
                entity.ToTable("disasterCategory");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Severity).IsRequired();
                entity.Property(e => e.CreatedDate).IsRequired();
            
            });
        }
    }
}
