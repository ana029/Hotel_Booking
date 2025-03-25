using HotelBookingAPI.Data.Model;
using HotelBookingAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService) { _bookingService = bookingService; }

        [HttpGet]
        public IActionResult GetAllBookings() => Ok(_bookingService.GetAllBookings());

        [HttpPost]
        public IActionResult AddBooking([FromBody] Booking booking)
        {
            _bookingService.AddBooking(booking);
            return Ok();
        }

        [HttpDelete("{bookingId}")]
        public IActionResult DeleteBooking(int bookingId)
        {
            _bookingService.DeleteBooking(bookingId);
            return Ok();
        }
    }
}
