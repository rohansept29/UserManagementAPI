using UserManagementAPI.DTOs;

namespace UserManagementAPI.Interfaces
{
    public interface IAccountRepository
    {
        Task AddUser(RegisterDto registerDto);
        Task<string> UserLogin(LoginDto loginDto);
    }
}
