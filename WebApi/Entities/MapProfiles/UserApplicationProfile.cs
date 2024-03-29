﻿using AutoMapper;
using Entities.DataTransferObjects.UserApplication;
using Entities.Models;
using Generics.Extensions;
using Generics.Models;

namespace Entities.MapProfiles;

public class UserApplicationProfile : Profile
{
    public UserApplicationProfile()
    {
        CreateMap<UserApplication, UserApplicationRegisterDto>()
            .ForMember(dest => dest.ModifiedAt,
                opt => opt.MapFrom(src => src.ModifiedAt == null || src.ModifiedAt.Value.IsDefault() ? "-" : src.ModifiedAt.Value.ToString()))
            .ReverseMap();

        CreateMap<UserApplication, UserApplicationUpdateDto>()
            .ReverseMap();

        CreateMap<UserApplication, UserApplicationDto>()
            .ForMember(dest => dest.ModifiedAt,
                opt => opt.MapFrom(src => src.ModifiedAt == null || src.ModifiedAt.Value.IsDefault() ? "-" : src.ModifiedAt.Value.ToString()))
            .ForMember(dest => dest.PaidUntil,
                opt => opt.MapFrom(src => src.PaidUntil == null || src.PaidUntil.Value.IsDefault() ? "-" : src.PaidUntil.Value.ToString()))
            .ReverseMap();

        CreateMap<Pagination<UserApplication>, Pagination<UserApplicationDto>>()
            .ReverseMap();

        CreateMap<UserApplication, UserApplicationLoginDto>()
            .ReverseMap();
    }
}