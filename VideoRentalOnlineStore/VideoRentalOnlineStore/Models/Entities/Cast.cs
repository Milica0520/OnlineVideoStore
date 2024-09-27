using VideoRentalOnlineStore.Models.Enums;

namespace VideoRentalOnlineStore.Models.Entities
{
    public class Cast
    {
        public int Id { get; set; }
        public string MovieId { get; set; }
        public string Name { get; set; }
        public Part Part { get; set; } 
    }
}
