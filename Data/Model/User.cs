using HotelBookingAPI.Enams;
using System.Data;

namespace HotelBookingAPI.Data.Model
{
    public class User : BaseClass
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshExpirationDate { get; set; }
        public List<Role> Roles { get; set; }
        public Status Status { get; set; }
    }
}
