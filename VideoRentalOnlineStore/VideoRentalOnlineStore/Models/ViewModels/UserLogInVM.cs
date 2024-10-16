using System.ComponentModel.DataAnnotations;

namespace VideoRentalOnlineStore.Models.ViewModels
{
    public class UserLogInVM
    {

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string CardNumber { get; set; }

    }
}
