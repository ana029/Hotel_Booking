using HotelBookingAPI.Data.DTO;
using HotelBookingAPI.Data;
using HotelBookingAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<ServiceResponse<int>> Register(UserRegisterDTO userRegisterDTO)
        {
            return await _authService.Register(userRegisterDTO);
        }

        [HttpPost("Login")]
        public async Task<ServiceResponse<string>> Login(UserLoginDTO userLoginDTO)
        {
            return await _authService.Login(userLoginDTO);
        }

        [HttpGet("CheckAdmin")]
        [Authorize(Roles = "Admin")]
        public async Task<ServiceResponse<string>> CheckAdmin()
        {
            return new ServiceResponse<string>() { Data = "Access granted" };
        }

        [HttpGet("CheckUser")]
        [Authorize(Roles = "User")]
        public async Task<ServiceResponse<string>> CheckUser()
        {
            return new ServiceResponse<string>() { Data = "Access granted" };
        }
    }
}
