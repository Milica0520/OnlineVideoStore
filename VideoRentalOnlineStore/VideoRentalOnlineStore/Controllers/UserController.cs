using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using VideoRentalOnlineStore.Models.ViewModels;
using VideoRentalOnlineStore.Services;

namespace VideoRentalOnlineStore.Controllers
{
    public class UserController : Controller
    {

        private UserServices _userServices;

        public UserController(UserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("logIn")]
        public IActionResult LogIn([FromBody]UserLogInVM userLogInVM)
        {
            var result = _userServices.LogInUser(userLogInVM);
            
            if (result == null) {
                
                return View();
            }
            return RedirectToAction("Index", "Home");
            
        }
    }
}
