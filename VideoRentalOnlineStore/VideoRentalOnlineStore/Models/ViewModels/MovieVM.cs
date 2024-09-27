using VideoRentalOnlineStore.Models.Enums;

namespace VideoRentalOnlineStore.Models.ViewModels
{
    public class MovieVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public bool IsAvailable { get; set; }
    
    }
}
