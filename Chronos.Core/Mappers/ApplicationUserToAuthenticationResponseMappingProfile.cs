
using AutoMapper;
using Chronos.Core.DTOs;
using Chronos.Core.Entities;

namespace Chronos.Core.Mappers;

public class ApplicationUserToAuthenticationResponseMappingProfile : Profile
{
    public ApplicationUserToAuthenticationResponseMappingProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(authResp => authResp.Id, opt => opt.MapFrom(user => user.Id))
            .ForMember(authResp => authResp.UserName, opt => opt.MapFrom(user => user.UserName))
            .ForMember(authResp => authResp.FullName, opt => opt.MapFrom(user => user.FullName))
            .ForMember(authResp => authResp.PhoneNumber, opt => opt.MapFrom(opt => opt.PhoneNumber))
            .ForMember(authResp => authResp.Email, opt => opt.MapFrom(opt => opt.Email))
            .ForMember(authResp => authResp.TeamId, opt => opt.MapFrom(opt => opt.TeamId))
            .ForMember(authResp => authResp.IsActive, opt => opt.MapFrom(opt => opt.IsActive));
    }
}
