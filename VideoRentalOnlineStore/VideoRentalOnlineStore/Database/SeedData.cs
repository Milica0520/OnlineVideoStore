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
                    UserId = 1,
                    RentedOn = DateTime.Now,
                    ReturnedOn = DateTime.Now.AddDays(7)
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "Ana Marković",
                    Age = 28,
                    CardNumber = "1234-5678-9012-3456",
                    CreatedOn = new DateTime(2023, 5, 12),
                    IsSubscriptionExpired = false,
                    SubscriptionType = SubscriptionType.Monthly,
                },
                new User
                {
                    Id = 2,
                    FullName = "Ivan Petrović",
                    Age = 35,
                    CardNumber = "9876-5432-1098-7654",
                    CreatedOn = new DateTime(2022, 8, 24),
                    IsSubscriptionExpired = true,
                    SubscriptionType = SubscriptionType.Yearly,
                },
                new User
                {
                    Id = 3,
                    FullName = "Maja Nikolić",
                    Age = 22,
                    CardNumber = "4567-8901-2345-6789",
                    CreatedOn = new DateTime(2024, 1, 15),
                    IsSubscriptionExpired = false,
                    SubscriptionType = SubscriptionType.Monthly
                }
          );
        }
    }
}

