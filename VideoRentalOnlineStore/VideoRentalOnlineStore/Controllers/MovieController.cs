using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using VideoRentalOnlineStore.Database;
using VideoRentalOnlineStore.Models.Entities;
using VideoRentalOnlineStore.Models.ViewModels;
using VideoRentalOnlineStore.Services;

namespace VideoRentalOnlineStore.Controllers
{

    [Route("movie")]
    public class MovieController : Controller
    {

        private  MovieServices _movieService;

        public MovieController(MovieServices movieServices)
        {
           
            _movieService = movieServices;
        }

        [HttpGet("allMovies")]
        public IActionResult AllMovies()
        {
            var allMovies = _movieService.GetAllMovies();

            return View(allMovies);
        }

        [HttpGet("details/{id}")]

        public IActionResult MovieDetails(int id)
        {
            var movie = _movieService.GetMovieById(id);
            return View(movie);
        }

        [HttpPost("rent")]
        public IActionResult RentAMovie(int id)
        {
            var userId = JsonSerializer.Deserialize<UserVM>(HttpContext.Session.GetString("user")).Id;
            var rental = _movieService.RentMovie(id, userId);

            return View(rental);

        }


        [HttpGet("myRentals")]
        public  IActionResult MyRentedMovies() {

            var userId = JsonSerializer.Deserialize<UserVM>(HttpContext.Session.GetString("user")).Id;
            if (userId == 0)
            {
                throw new ArgumentException("You need to log in to rent a movie");
            }
            var userRentedMovies = _movieService.RentedMoviesForUser(userId);
            return View(userRentedMovies);
        }

        [HttpPost("returnMovie")]
        public IActionResult ReturnAMovie(int id)
        {

            _movieService.ReturnMovie(id);

            return RedirectToAction("MyRentedMovies", "Movie" );
        }


    }
}
