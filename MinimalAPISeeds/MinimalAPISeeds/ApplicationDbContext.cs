using Microsoft.EntityFrameworkCore;
using MinimalAPISeeds.Entidades;

namespace MinimalAPISeeds
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Season> Seasons { get; set; } = null!;
        public DbSet<Crop> Crops { get; set; } = null!;
        public DbSet<PlantingMethod> PlantingMethods { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación muchos a muchos entre Crops y Seasons
            modelBuilder.Entity<Crop>()
                .HasMany(c => c.Seasons)
                .WithMany(s => s.Crops)
                .UsingEntity(j => j.ToTable("CropSeasons"));

            // Relación muchos a muchos entre Crops y PlantingMethods
            modelBuilder.Entity<Crop>()
                .HasMany(c => c.PlantingMethods)
                .WithMany(pm => pm.Crops)
                .UsingEntity(j => j.ToTable("CropPlantingMethods"));
        }



    }
}
