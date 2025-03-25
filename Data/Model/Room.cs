using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Data.Model
{
    public class Room
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string RoomType { get; set; }

        [Precision(18, 2)] // 
        public decimal PricePerNight { get; set; }

        public bool IsAvailable { get; set; }
    }
}
