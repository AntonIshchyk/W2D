using AutoMapper;
using Backend.Models;

namespace Backend.Contracts.Auth;

public class AuthMappingProfile : Profile
{
    public AuthMappingProfile()
    {
        CreateMap<User, LoginResponse>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ProfileSetupComplete, opt => opt.MapFrom(src => src.ProfileSetupComplete))
            .ForMember(dest => dest.IsAdmin, opt => opt.MapFrom(src => src.IsAdmin))
            .ForMember(dest => dest.Token, opt => opt.Ignore());
    }
}
