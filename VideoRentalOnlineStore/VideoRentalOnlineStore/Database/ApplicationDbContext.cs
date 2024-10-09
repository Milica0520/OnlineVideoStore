using Microsoft.EntityFrameworkCore;
using VideoRentalOnlineStore.Models.Entities;
using VideoRentalOnlineStore.Models.Enums;

namespace VideoRentalOnlineStore.Database
{
    public class ApplicationDbContext : DbContext
    {
       public DbSet<Movie> Movies { get; set; }
       public DbSet<Rental> Rentals { get; set; }

        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            base.OnModelCreating(modelBuilder);

            SeedData.Initialize(modelBuilder);
        }


    }
}
