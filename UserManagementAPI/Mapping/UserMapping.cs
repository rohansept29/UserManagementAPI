using AutoMapper;
using UserManagementAPI.DTOs;
using UserManagementAPI.Entities;

namespace UserManagementAPI.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<RegisterDto, User>();
            CreateMap<User, UserDto>().ReverseMap();
        }

    }
}
