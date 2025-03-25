using HotelBookingAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelController(IHotelService hotelService) { _hotelService = hotelService; }

        [HttpGet("GetAll")]
        public IActionResult GetAllHotels() => Ok(_hotelService.GetAllHotels());

        [HttpGet("GetHotel/{id}")]
        public IActionResult GetHotel(int id) => Ok(_hotelService.GetHotelById(id));

        [HttpGet("GetCities")]
        public IActionResult GetCities() => Ok(_hotelService.GetCities());
    }
}
