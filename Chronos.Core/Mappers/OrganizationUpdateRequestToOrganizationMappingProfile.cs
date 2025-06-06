using AutoMapper;
using Chronos.Core.DTOs;
using Chronos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Core.Mappers;

public class OrganizationUpdateRequestToOrganizationMappingProfile : Profile
{
    public OrganizationUpdateRequestToOrganizationMappingProfile()
    {
        CreateMap<OrganizationUpdateRequest, Organization>()
        .ForMember(org => org.CreatedBy, opt => opt.Ignore())
        .ForMember(org => org.CreatedOn, opt => opt.Ignore())
        .ForMember(org => org.UpdatedBy, opt => opt.MapFrom(req => req.UpdatedBy))
        .ForMember(org => org.UpdatedOn, opt => opt.MapFrom(_ => DateTime.Now));
    }
}
