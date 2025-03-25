using HotelBookingAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService) { _roomService = roomService; }

        [HttpGet("GetAll")]
        public IActionResult GetAllRooms() => Ok(_roomService.GetAllRooms());

        [HttpGet("GetRoom/{id}")]
        public IActionResult GetRoom(int id) => Ok(_roomService.GetRoomById(id));

        [HttpGet("GetAvailableRooms")]
        public IActionResult GetAvailableRooms() => Ok(_roomService.GetAvailableRooms());
    }
}
