using VideoRentalOnlineStore.Models.Entities;

namespace VideoRentalOnlineStore.Models.ViewModels
{
    public class RentalDetailsVM
    {
        public string MovieTitle { get; set; }
        public DateTime RentedOn { get; set; }
        public DateTime ReturnedOn { get; set; }

    }
}
