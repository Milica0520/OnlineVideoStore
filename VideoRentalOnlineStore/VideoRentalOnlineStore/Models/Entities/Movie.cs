using System.Reflection.Metadata.Ecma335;
using VideoRentalOnlineStore.Models.Enums;

namespace VideoRentalOnlineStore.Models.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public Language Language { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Length { get; set; }
        public int AgeRestriction { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }
    }
}
