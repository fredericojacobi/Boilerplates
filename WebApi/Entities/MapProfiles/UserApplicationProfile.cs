using AutoMapper;
using Entities.DataTransferObjects.UserApplication;
using Entities.Models;
using Generics.Models;
using Extensions;

namespace Entities.MapProfiles;

public class UserApplicationProfile : Profile
{
    public UserApplicationProfile()
    {
        CreateMap<UserApplication, UserApplicationRegisterDto>()
            .ForMember(dest => dest.ModifiedAt,
                opt => opt.MapFrom(src => src.ModifiedAt == null || src.ModifiedAt.Value.IsDefault() ? string.Empty : src.ModifiedAt.Value.ToString()))
            .ReverseMap();
        
        CreateMap<UserApplication, UserApplicationUpdateDto>().ReverseMap();
        
        CreateMap<UserApplication, UserApplicationDto>()
            .ForMember(dest => dest.ModifiedAt,
                opt => opt.MapFrom(src => src.ModifiedAt == null || src.ModifiedAt.Value.IsDefault() ? string.Empty : src.ModifiedAt.Value.ToString()))
            .ReverseMap();
        
        CreateMap<Pagination<UserApplication>, Pagination<UserApplicationDto>>().ReverseMap();
        
        CreateMap<UserApplication, UserApplicationLoginDto>().ReverseMap();
    }
}