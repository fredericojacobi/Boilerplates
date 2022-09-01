using AutoMapper;
using Entities.DataTransferObjects.UserApplication;
using Entities.Models;

namespace Entities.MapProfiles;

public class UserApplicationProfile : Profile
{
    public UserApplicationProfile()
    {
        CreateMap<UserApplication, UserApplicationRegisterDto>().ReverseMap();
        CreateMap<UserApplication, UserApplicationUpdateDto>().ReverseMap();
        CreateMap<UserApplication, UserApplicationDto>().ReverseMap();
        CreateMap<UserApplication, UserApplicationLoginDto>().ReverseMap();
        
    }
}