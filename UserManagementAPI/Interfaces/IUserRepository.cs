using Microsoft.AspNetCore.JsonPatch;
using UserManagementAPI.DTOs;
using UserManagementAPI.Entities;

namespace UserManagementAPI.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> GetUserProfile(string email);
        Task UpdateUserProfile(UserDto userDto);

        Task UpdateUserProfilePatch(string email, JsonPatchDocument<UserDto> patchDocument);
    }
}
