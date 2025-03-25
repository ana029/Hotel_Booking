using HotelBookingAPI.Data.Model;

namespace HotelBookingAPI.Interfaces
{
    public interface IHotelService
    {
        List<Hotel> GetAllHotels();
        Hotel GetHotelById(int id);
        List<string> GetCities();
    }

}
