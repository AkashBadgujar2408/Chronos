
using AutoMapper;
using Chronos.Core.DTOs;
using Chronos.Core.Entities;

namespace Chronos.Core.Mappers;

public class OrganizationToOrganizationResponseMappingProfile : Profile
{
    public OrganizationToOrganizationResponseMappingProfile()
    {
        CreateMap<Organization, OrganizationResponse>();
    }
}