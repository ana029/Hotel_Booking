using AutoMapper;
using HotelBookingAPI.Data.DTO.Role;
using HotelBookingAPI.Data.DTO.User;
using HotelBookingAPI.Data.Model;

namespace HotelBookingAPI
{
    public class MappinProfile : Profile
    {
        public MappinProfile()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Role, RoleCreateDTO>().ReverseMap();
            CreateMap<Role, RoleUpdateDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
