using AutoMapper;
using HotelBookingAPI.Data.DTO.Role;
using HotelBookingAPI.Data.Model;
using HotelBookingAPI.Data;
using HotelBookingAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Services
{
    public class RoleService : IRoleService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RoleService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<RoleDTO>>> GetAllAsync()
        {
            var response = new ServiceResponse<List<RoleDTO>>();


            var roles = await _context.roles.ToListAsync();

            response.Data = roles.Select(x => _mapper.Map<RoleDTO>(x)).ToList();

            return response;
        }

        public Task<ServiceResponse<RoleDTO>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<string>> CreateAsync(RoleCreateDTO dto)
        {
            var mapped = _mapper.Map<Role>(dto);
            await _context.roles.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new ServiceResponse<string>() { Data = "Role added successfully" };
        }

        public Task<ServiceResponse<string>> UpdateAsync(RoleUpdateDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
