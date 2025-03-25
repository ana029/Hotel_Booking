using HotelBookingAPI.Data.Model;

namespace HotelBookingAPI.Interfaces
{
    public interface IRoomService
    {
        List<Room> GetAllRooms();
        Room GetRoomById(int id);
        List<Room> GetAvailableRooms();
    }
}
