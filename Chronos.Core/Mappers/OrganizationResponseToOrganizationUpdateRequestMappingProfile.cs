using AutoMapper;
using Chronos.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Core.Mappers
{
    public class OrganizationResponseToOrganizationUpdateRequestMappingProfile : Profile
    {
        public OrganizationResponseToOrganizationUpdateRequestMappingProfile()
        {
            CreateMap<OrganizationResponse, OrganizationUpdateRequest>();
        }
    }
}
