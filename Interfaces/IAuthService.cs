using HotelBookingAPI.Data.DTO;
using HotelBookingAPI.Data;

namespace HotelBookingAPI.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRegisterDTO registerDTO);
        Task<ServiceResponse<string>> Login(UserLoginDTO loginDTO);
    }
}
