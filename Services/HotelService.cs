using HotelBookingAPI.Data.Model;
using HotelBookingAPI.Data;
using HotelBookingAPI.Interfaces;

namespace HotelBookingAPI.Services
{
    public class HotelService : IHotelService
    {
        private readonly ApplicationDbContext _context;
        public HotelService(ApplicationDbContext context) { _context = context; }

        public List<Hotel> GetAllHotels() => _context.Hotels.ToList();
        public Hotel GetHotelById(int id) => _context.Hotels.Find(id);
        public List<string> GetCities() => _context.Hotels.Select(h => h.City).Distinct().ToList();
    }

}
