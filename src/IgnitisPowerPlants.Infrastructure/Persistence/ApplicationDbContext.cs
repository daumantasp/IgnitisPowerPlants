using IgnitisPowerPlants.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IgnitisPowerPlants.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<PowerPlant> PowerPlants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PowerPlant>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Owner).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Power).IsRequired().HasColumnType("decimal(6,1)");
                entity.Property(e => e.ValidFrom).IsRequired();
                entity.Property(e => e.ValidTo).IsRequired(false);
            });

            modelBuilder.Entity<PowerPlant>()
                .ToTable(t => t.HasCheckConstraint("CK_PowerPlants_Power", "[Power] >= 0.0 AND [Power] <= 200.0"));

            modelBuilder.Entity<PowerPlant>()
                .ToTable(t => t.HasCheckConstraint("CK_PowerPlants_Owner", "[Owner] LIKE '% %' AND [Owner] NOT LIKE '%  %' AND [Owner] NOT LIKE '%[0-9]%'"));

            modelBuilder.Entity<PowerPlant>()
                .ToTable(t => t.HasCheckConstraint("CK_PowerPlants_ValidFrom_ValidTo", "[ValidTo] IS NULL OR [ValidFrom] < [ValidTo]"));
        }
    }
}
