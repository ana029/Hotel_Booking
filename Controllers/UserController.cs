using HotelBookingAPI.Data.DTO.User;
using HotelBookingAPI.Data;
using HotelBookingAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    //[ServiceFilter(typeof(AdminRoleFilter))]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut]
        public async Task<ServiceResponse<string>> UpdateAsync(UserUpdateDTO dto)
        {
            return await _userService.UpdateAsync(dto);
        }

        [HttpPost]
        public async Task<ServiceResponse<string>> CreateAsync(UserCreateDTO dto)
        {
            return await _userService.CreateAsync(dto);
        }

        [HttpGet]
        public async Task<ServiceResponse<List<UserDTO>>> GetAllAsync(int page, int pageSize)
        {
            
            return await _userService.GetAllAsync(page, pageSize);
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<UserDTO>> GetByIdAsync(int id)
        {
            return await _userService.GetAsync(id);
        }

        [HttpDelete]
        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            return await _userService.DeleteAsync(id);
        }
    }
}
