using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection.Metadata.Ecma335;
using VideoRentalOnlineStore.Database;
using VideoRentalOnlineStore.Models.Entities;
using VideoRentalOnlineStore.Models.ViewModels;

namespace VideoRentalOnlineStore.Services
{
    public class UserServices
    {

        public UserServices() { }

        private ApplicationDbContext _context;


        public UserServices(ApplicationDbContext context) {
        
        _context = context;
        }
       public UserLogInVM LogInUser(UserLogInVM userLogInVM)
        {





            return new UserLogInVM();


        }


    }
}
