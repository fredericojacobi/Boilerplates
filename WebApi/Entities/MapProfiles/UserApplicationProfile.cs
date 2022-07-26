using AutoMapper;
using Entities.DataTransferObjects.UserApplication;
using Entities.Models;

namespace Entities.MapProfiles;

public class UserApplicationProfile : Profile
{
    public UserApplicationProfile()
    {
        CreateMap<UserApplication, UserApplicationRegisterDto>().ReverseMap();
        
    }
}