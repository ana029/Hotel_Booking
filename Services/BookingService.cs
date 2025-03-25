using HotelBookingAPI.Data;
using HotelBookingAPI.Data.Model;
using HotelBookingAPI.Interfaces;

namespace HotelBookingAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly ApplicationDbContext _context;
        public BookingService(ApplicationDbContext context) { _context = context; }

        public List<Booking> GetAllBookings() => _context.Bookings.ToList();

        public void AddBooking(Booking booking)
        {
            
            var room = _context.Rooms.FirstOrDefault(r => r.Id == booking.RoomID);

            if (room == null)
            {
                throw new Exception("Room not found.");
            }

            if (!room.IsAvailable)
            {
                throw new Exception("Room is not available for booking.");
            }

            bool isRoomBooked = _context.Bookings.Any(b =>
                b.RoomID == booking.RoomID &&
                ((booking.CheckInDate >= b.CheckInDate && booking.CheckInDate < b.CheckOutDate) ||
                 (booking.CheckOutDate > b.CheckInDate && booking.CheckOutDate <= b.CheckOutDate) ||
                 (booking.CheckInDate <= b.CheckInDate && booking.CheckOutDate >= b.CheckOutDate))
            );

            if (isRoomBooked)
            {
                throw new Exception("The room is already booked for the selected dates.");
            }

            int numberOfDays = (booking.CheckOutDate - booking.CheckInDate).Days;

            if (numberOfDays <= 0)
            {
                throw new Exception("Check-out date must be after check-in date.");
            }

            booking.TotalPrice = numberOfDays * room.PricePerNight;

            _context.Bookings.Add(booking);

            room.IsAvailable = false;
            _context.SaveChanges();
        }


        public void DeleteBooking(int bookingId)
        {
            var booking = _context.Bookings.Find(bookingId);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
        }
    }

}
