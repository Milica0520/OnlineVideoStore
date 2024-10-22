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

       public UserVM? LogInUser(UserLogInVM userLogInVM)
        {
            
            var entity = _context.Users.Where(u => (u.FullName == userLogInVM.FirstName + " " + userLogInVM.LastName)
            && (u.CardNumber == userLogInVM.CardNumber))
                .FirstOrDefault();

           if (entity == null)
            {
               return null;
            }

            return new UserVM()
            {
                Id = entity.Id,
                FullName = entity.FullName
            };

        }


    }
}
