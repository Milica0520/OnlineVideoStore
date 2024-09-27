using Microsoft.AspNetCore.Mvc;
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
            var rental = _movieService.RentMovie(id);

            return View(rental);

        }


    }
}
