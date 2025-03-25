using HotelBookingAPI.Enams;

namespace HotelBookingAPI.Data.DTO.User
{
    public class UserCreateDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<int> RoleIds { get; set; }
        public Status Status { get; set; }
    }
}
