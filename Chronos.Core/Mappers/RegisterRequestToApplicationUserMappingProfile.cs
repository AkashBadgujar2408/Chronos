
using ApplicationCore.Infrastructure;
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
            .ForMember(appUser => appUser.PhoneNumber, opt => opt.MapFrom(user => user.PhoneNumber))
            .ForMember(appUser => appUser.Email, opt => opt.MapFrom(user => user.Email))
            .ForMember(appUser => appUser.TeamId, opt => opt.Ignore())
            .ForMember(appUser => appUser.IsActive, opt => opt.MapFrom(_ => true))
            .AfterMap((user, appUser) => 
            {
                appUser.PasswordHash = CryptoService.Encrypt(user.Password!, out string algoInfo);
                appUser.AlgoInfo = algoInfo;
            });
    }
}
