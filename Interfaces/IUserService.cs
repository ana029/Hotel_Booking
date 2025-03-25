using HotelBookingAPI.Data.DTO.User;
using HotelBookingAPI.Data;

namespace HotelBookingAPI.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<string>> UpdateAsync(UserUpdateDTO dto);
        Task<ServiceResponse<string>> CreateAsync(UserCreateDTO dto);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
        Task<ServiceResponse<UserDTO>> GetAsync(int id);
        Task<ServiceResponse<List<UserDTO>>> GetAllAsync(int page, int pageSize);

    }
}
