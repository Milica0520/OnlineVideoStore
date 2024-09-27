using Microsoft.AspNetCore.Http.HttpResults;
using VideoRentalOnlineStore.Database;
using VideoRentalOnlineStore.Models.Entities;
using VideoRentalOnlineStore.Models.ViewModels;

namespace VideoRentalOnlineStore.Services
{
    public class MovieServices
    {
        public MovieServices() { }

        private ApplicationDbContext _context;

        public MovieServices(ApplicationDbContext context)
        {
            _context = context;
        }



        public List<MovieVM> GetAllMovies()
        {
            List<MovieVM> moviesToView = _context.Movies.Select(m => new MovieVM()
            {
                Id = m.Id,
                Title = m.Title,
                Genre = m.Genre,
                IsAvailable = m.IsAvailable,

            }).ToList();

            return moviesToView;
        }
        public MovieDetailsVM GetMovieById(int id)
        {

            var entity = _context.Movies.Where(m => m.Id == id).FirstOrDefault();

            if (entity == null)
            {
                throw new Exception("Movie not found");
            }
            var movie = new MovieDetailsVM()
            {
                Id = entity.Id,
                Title = entity.Title,
                Length = entity.Length,
                Genre = entity.Genre,
                Language = entity.Language,
                AgeRestriction = entity.AgeRestriction,
                Quantity = entity.Quantity,
                IsAvailable = entity.IsAvailable,   
            };

            return movie;

        }

        public RentalDetailsVM RentMovie(int id)
        {
            var entity = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (entity == null)
                throw new Exception("Movie not found");
            if (entity.Quantity <= 0)
                throw new Exception("Movie not available for rent.");

            int userId = 1;
            var rental = new Rental()
            {
                MovieId = entity.Id,
                UserId = userId,
                RentedOn = DateTime.Now,
                ReturnedOn = DateTime.Now.AddDays(14),
            };
            _context.Rentals.Add(rental);

            entity.Quantity--;
            if (entity.Quantity <= 0)
            {
                entity.Quantity = 0;
                entity.IsAvailable = false;
            }
            _context.Movies.Update(entity);
            _context.SaveChanges();

            var rentalV = new RentalDetailsVM()
            {
                MovieTitle = entity.Title,
                RentedOn = rental.RentedOn,
                ReturnedOn = rental.ReturnedOn,
            };
            return rentalV;
        }
    }
}
