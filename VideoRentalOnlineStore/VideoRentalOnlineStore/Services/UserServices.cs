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
            
            var entity = _context.Users.Where(u => (u.FullName == userLogInVM.FirstName + " " + userLogInVM.LastName)
            && (u.CardNumber == userLogInVM.CardNumber))
                .FirstOrDefault();

           if (entity == null)
            {
               return null;
            }

            var fullNameParts = entity.FullName.Split(' ');

            var userLogIn = new UserLogInVM
            {
                FirstName = fullNameParts[0], 
                LastName = fullNameParts[1], 
                CardNumber = entity.CardNumber
            };

            return userLogIn;

        }


    }
}
