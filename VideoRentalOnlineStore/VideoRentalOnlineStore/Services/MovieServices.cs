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

        public RentedMovieVM RentMovie(int id)
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
                ReturnedOn = DateTime.Now.AddDays(7),
            };
            _context.Rentals.Add(rental);

            entity.Quantity--;
            if (entity.Quantity <= 0)
            {
                
                entity.IsAvailable = false;
            }
           
            _context.SaveChanges();

            var rentalV = new RentedMovieVM()
            {
             
                MovieTitle = entity.Title,
                RentedOn = rental.RentedOn,
                ReturnedOn = rental.ReturnedOn,
            };

            return rentalV;
        }


        public List<RentedMovieVM> RentedMoviesForUser(int userId)
        {
       
            List<Rental> userRentals = _context.Rentals.Where(r => r.UserId == userId).ToList();


            List<RentedMovieVM>  userRentedMovies = new List<RentedMovieVM>();

            foreach (var rental in userRentals)
            {
                var movie = _context.Movies.Where(m => m.Id == rental.MovieId).FirstOrDefault();

                var rentedMovie = new RentedMovieVM()
                {
                    MovieTitle = movie.Title,
                    RentedOn = rental.RentedOn,
                    ReturnedOn = rental.ReturnedOn,
                    MovieId = movie.Id, 
                };

                userRentedMovies.Add(rentedMovie);

            }

            return userRentedMovies;
        }


        public void ReturnMovie(int id)
        {


            var item = _context.Rentals.Where(r => r.MovieId == id).FirstOrDefault();
            

            if (item != null)
            {
                
                _context.Rentals.Remove(item);
                _context.SaveChanges(); 
            }
            var movie = _context.Movies.Where(movie => movie.Id == id).FirstOrDefault();

            movie.Quantity++;

           
        }

    }
}
