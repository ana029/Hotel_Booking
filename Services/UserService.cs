using AutoMapper;
using HotelBookingAPI.Data.DTO.User;
using HotelBookingAPI.Data.Model;
using HotelBookingAPI.Data;
using System.Security.Cryptography;
using System.Text;
using System;
using HotelBookingAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<string>> CreateAsync(UserCreateDTO dto)
        {
            try
            {
                var response = new ServiceResponse<string>();

                if (await UserExists(dto.UserName))
                {
                    response.Success = false;
                    response.Message = "User already exists";
                    return response;
                }

                CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

                var user = new User()
                {
                    UserName = dto.UserName,
                    Status = dto.Status,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };

                var roles = await _context.roles.Where(x => dto.RoleIds.Contains(x.Id)).ToListAsync();

                user.Roles = roles;

                await _context.users.AddAsync(user);
                await _context.SaveChangesAsync();

                response.Data = "User created successfully";
                return response;
            }
            catch (Exception ex)
            {
                return new ServiceResponse<string>() { Success = false, Message = ex.GetFullMessage() };
            }
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            try
            {
                var user = await _context.users.FirstOrDefaultAsync(x => x.Id == id);

                if (user == null)
                    return new ServiceResponse<bool>() { Success = false, Message = "User not found" };

                user.Status = Enams.Status.Deleted;

                _context.users.Update(user);
                await _context.SaveChangesAsync();

                return new ServiceResponse<bool>() { Message = "User deleted successfully" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>() { Success = false, Message = ex.GetFullMessage() };
            }
        }

        public async Task<ServiceResponse<List<UserDTO>>> GetAllAsync(int page, int pageSize)
        {
            try
            {
                var query = _context.users.AsQueryable();

                var paginatedUsers = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

                return new ServiceResponse<List<UserDTO>>() { Data = paginatedUsers.Select(x => _mapper.Map<UserDTO>(x)).ToList() };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<UserDTO>>() { Success = false, Message = ex.GetFullMessage() };
            }


        }

        public async Task<ServiceResponse<UserDTO>> GetAsync(int id)
        {
            try
            {
                var user = await _context.users.Include(x => x.Roles).FirstOrDefaultAsync(x => x.Id == id);

                if (user == null)
                    return new ServiceResponse<UserDTO>() { Success = false, Message = "User not found" };

                return new ServiceResponse<UserDTO>() { Data = _mapper.Map<UserDTO>(user) };

            }
            catch (Exception ex)
            {
                return new ServiceResponse<UserDTO>() { Success = false, Message = ex.GetFullMessage() };
            }
        }

        public async Task<ServiceResponse<string>> UpdateAsync(UserUpdateDTO dto)
        {
            try
            {
                var user = await _context.users.Include(x => x.Roles).FirstOrDefaultAsync(x => x.UserName.ToLower() == dto.UserName.ToLower());

                if (user == null)
                    return new ServiceResponse<string> { Success = false, Message = "User not found" };

                var rolesToAssign = await _context.roles.Where(x => dto.RoleIds.Contains(x.Id)).ToListAsync();

                user.Roles = rolesToAssign;
                user.Status = dto.Status;

                _context.users.Update(user);
                await _context.SaveChangesAsync();

                return new ServiceResponse<string>() { Data = "User updates successfully" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<string> { Success = false, Message = ex.GetFullMessage() };
            }
        }


        #region
        private async Task<bool> UserExists(string userName)
        {
            if (await _context.users.AnyAsync(x => x.UserName.ToLower() == userName.ToLower()))
                return true;
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        #endregion
    }
}
