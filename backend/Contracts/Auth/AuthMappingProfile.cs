using AutoMapper;
using Backend.Models;

namespace Backend.Contracts.Auth;

public class AuthMappingProfile : Profile
{
    public AuthMappingProfile()
    {
        // User -> LoginResponse
        CreateMap<User, LoginResponse>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Token, opt => opt.Ignore()); // Set manually in service
    }
}
