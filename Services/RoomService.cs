using HotelBookingAPI.Data.Model;
using HotelBookingAPI.Data;
using HotelBookingAPI.Interfaces;

namespace HotelBookingAPI.Services
{
    public class RoomService : IRoomService
    {
        private readonly ApplicationDbContext _context;
        public RoomService(ApplicationDbContext context) { _context = context; }

        public List<Room> GetAllRooms() => _context.Rooms.ToList();
        public Room GetRoomById(int id) => _context.Rooms.Find(id);
        public List<Room> GetAvailableRooms() => _context.Rooms.Where(r => r.IsAvailable).ToList();
    }
}
