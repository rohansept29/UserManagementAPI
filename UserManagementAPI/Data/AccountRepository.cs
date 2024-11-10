using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserManagementAPI.DTOs;
using UserManagementAPI.Entities;
using UserManagementAPI.Interfaces;

namespace UserManagementAPI.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        public AccountRepository(DataContext context, IMapper mapper, ITokenService tokenService)
        {
            _context = context;
            _mapper = mapper;
            _tokenService = tokenService;
        }
        public async Task AddUser(RegisterDto registerDto)
        {
            // Hash the password
            var passwordHash = Helper.HashPassword(registerDto.Password);

            var user = new User
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = passwordHash
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<string> UserLogin(LoginDto loginDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null || !Helper.VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            return _tokenService.CreateToken(user);
        }

    }
}
