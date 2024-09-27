using Microsoft.EntityFrameworkCore;
using VideoRentalOnlineStore.Models.Entities;
using VideoRentalOnlineStore.Models.Enums;

namespace VideoRentalOnlineStore.Database
{
    public static class SeedData
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Inception",
                    Genre = Genre.SciFi,
                    Language = Language.English,
                    IsAvailable = true,
                    ReleaseDate = new DateTime(2010, 7, 16),
                    Length = new TimeSpan(2, 28, 0),
                    AgeRestriction = 13,
                    Quantity = 100
                },
                new Movie
                {
                    Id = 2,
                    Title = "Parasite",
                    Genre = Genre.Drama,
                    Language = Language.Korean,
                    IsAvailable = true,
                    ReleaseDate = new DateTime(2019, 5, 30),
                    Length = new TimeSpan(2, 12, 0),
                    AgeRestriction = 15,
                    Quantity = 100
                },
                new Movie
                {
                    Id = 3,
                    Title = "The Dark Knight",
                    Genre = Genre.Action,
                    Language = Language.English,
                    IsAvailable = false,
                    ReleaseDate = new DateTime(2008, 7, 18),
                    Length = new TimeSpan(2, 32, 0),
                    AgeRestriction = 13,
                    Quantity = 100
                }
            );

            modelBuilder.Entity<Rental>().HasData(
                new Rental
                {
                    Id = 1,
                    MovieId = 1,
                    UserId  = 1,
                    RentedOn = DateTime.Now,
                    ReturnedOn= DateTime.Now.AddDays(7)
                }
            );
        }
    }
}

