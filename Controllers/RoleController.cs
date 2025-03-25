using HotelBookingAPI.Data.DTO.Role;
using HotelBookingAPI.Data;
using HotelBookingAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ServiceResponse<List<RoleDTO>>> GetAllAsync()
        {
            return await _roleService.GetAllAsync();
        }

        [HttpPost]
        public async Task<ServiceResponse<string>> CreateAsync(RoleCreateDTO dto)
        {
            return await _roleService.CreateAsync(dto);
        }
    }
}
