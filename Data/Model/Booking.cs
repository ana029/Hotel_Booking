using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Data.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public int RoomID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        [Precision(18, 2)] //
        public decimal TotalPrice { get; set; }

        public bool IsConfirmed { get; set; }
        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
        public string CustomerPhone { get; set; }
    }
}
