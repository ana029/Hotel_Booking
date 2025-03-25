using HotelBookingAPI.Data.Model;

namespace HotelBookingAPI.Interfaces
{
    public interface IBookingService
    {
        List<Booking> GetAllBookings();
        void AddBooking(Booking booking);
        void DeleteBooking(int bookingId);
    }
}
