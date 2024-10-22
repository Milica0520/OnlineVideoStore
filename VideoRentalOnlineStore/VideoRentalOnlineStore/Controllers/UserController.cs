using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using VideoRentalOnlineStore.Models.ViewModels;
using VideoRentalOnlineStore.Services;

namespace VideoRentalOnlineStore.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {

        private UserServices _userServices;

        public UserController(UserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("login")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("login")]
  
        public IActionResult LogIn(UserLogInVM userLogInVM)
        {
            var result = _userServices.LogInUser(userLogInVM);


            if (result == null)
            {

                return RedirectToAction("Index", "Home");
            }

            HttpContext.Session.SetString("user", JsonSerializer.Serialize(result));

            return RedirectToAction("myRentals", "movie");

        }

        public IActionResult LogOut() 
        {

            HttpContext.Session.Clear();

            return RedirectToAction("Home", "Index");
        }
    }
}
