using UserManagementAPI.Entities;

namespace UserManagementAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
