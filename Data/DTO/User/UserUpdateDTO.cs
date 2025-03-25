using HotelBookingAPI.Enams;

namespace HotelBookingAPI.Data.DTO.User
{
    public class UserUpdateDTO
    {
        public string UserName { get; set; }
        public List<int> RoleIds { get; set; }
        public Status Status { get; set; }
    }
}
