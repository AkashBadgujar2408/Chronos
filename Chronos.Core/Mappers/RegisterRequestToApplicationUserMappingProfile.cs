
using AutoMapper;
using Chronos.Core.DTOs;
using Chronos.Core.Entities;

namespace Chronos.Core.Mappers;

public class RegisterRequestToApplicationUserMappingProfile : Profile
{
    public RegisterRequestToApplicationUserMappingProfile()
    {
        CreateMap<RegisterRequest, ApplicationUser>()
            .ForMember(appUser => appUser.Id, opt => opt.Ignore())
            .ForMember(appUser => appUser.UserName, opt => opt.MapFrom(user => user.UserName))
            .ForMember(appUser => appUser.FullName, opt => opt.MapFrom(user => user.FullName))
            .ForMember(appUser => appUser.PasswordHash, opt => opt.MapFrom(user => user.Password))
            .ForMember(appUser => appUser.PhoneNumber, opt => opt.MapFrom(user => user.PhoneNumber))
            .ForMember(appUser => appUser.Email, opt => opt.MapFrom(user => user.Email))
            .ForMember(appUser => appUser.TeamId, opt => opt.Ignore());
    }
}
