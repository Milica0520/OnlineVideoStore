using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using VideoRentalOnlineStore.Models.ViewModels;
using VideoRentalOnlineStore.Services;

namespace VideoRentalOnlineStore.Controllers
{
    public class UserController : Controller
    {

        private UserServices _userServices;

        private UserController(UserServices userServices)
        {
            _userServices = userServices ;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(UserLogInVM userLogInVM)
        {
          var result = _userServices.LogInUser(userLogInVM);    
            return View();
        }


        
    }
}
