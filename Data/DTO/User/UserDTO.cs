using HotelBookingAPI.Data.DTO.Role;
using HotelBookingAPI.Enams;

namespace HotelBookingAPI.Data.DTO.User
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Status Status { get; set; }
        public List<RoleDTO> Roles { get; set; }
    }
}

