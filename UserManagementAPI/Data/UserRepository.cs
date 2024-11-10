using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Text;
using UserManagementAPI.DTOs;
using UserManagementAPI.Entities;
using UserManagementAPI.Interfaces;

namespace UserManagementAPI.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserDto> GetUserProfile(string email)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                // to do
                throw new Exception("User not found");
            }
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task UpdateUserProfile(UserDto userDto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userDto.Email);
            if (user == null) { throw new Exception("User Not Found"); }
            if (userDto.OldPassword != null)
            {
                var oldPasswordHash = Helper.HashPassword(userDto.OldPassword);
                if (oldPasswordHash != user.PasswordHash)
                {
                    throw new Exception("Incorrect Password");
                }
                // Hash the password
                var passwordHash = Helper.HashPassword(userDto.NewPassword);
                user.PasswordHash = passwordHash;
            }
            if (!string.IsNullOrWhiteSpace(userDto.Username))
                user.UserName = userDto.Username;
            await _context.SaveChangesAsync();
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserProfilePatch(string email, JsonPatchDocument<UserDto> patchDocument)
        {
            User existingUser = await _context.Users.FirstAsync(u => u.Email == email);

            if (existingUser != null)
            {
                var userToPatch = _mapper.Map<UserDto>(existingUser);

                patchDocument.ApplyTo(userToPatch);

                existingUser.UserName = userToPatch.Username;

                _context.Entry(existingUser).State = EntityState.Modified;
               await _context.SaveChangesAsync();
            }
        }
    }
}
