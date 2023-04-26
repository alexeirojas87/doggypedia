using DogBreedApp.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DogBreedApp.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Breed> Breeds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>()
                .HasOne(d => d.Father)
                .WithOne()
                .HasForeignKey<Dog>(d => d.FatherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Dog>()
                .HasOne(d => d.Mother)
                .WithOne()
                .HasForeignKey<Dog>(d => d.MotherId)
                .OnDelete(DeleteBehavior.Restrict);

            // ... (Cualquier otra configuración de modelo que puedas tener)
        }
    }
}
