using AuthAPI.Data.DTO;
using AuthAPI.Models;
using AutoMapper;

namespace AuthAPI.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDTO, User>();
    }
}
