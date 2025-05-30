
using ApplicationCore.DTOs;
using AutoMapper;
using Chronos.Core.DTOs;
using Chronos.Core.Entities;
using Chronos.Core.Helpers;
using Chronos.Core.RepositoryContracts;
using Chronos.Core.ServiceContracts;

namespace Chronos.Core.Services;

public class OrganizationsService(IOrganizationsRepository _organizationsRepository, IMapper _mapper) : IOrganizationsService
{
    public async Task<OperationResult<OrganizationResponse?>> CreateOrganizationAsync(OrganizationCreateRequest? organizationCreateRequest)
    {
        OperationType operation = OperationType.Create;
        if (organizationCreateRequest == null)
        {
            return OperationResult.Failure<OrganizationResponse?>(operation, message: "Invalid organization creation request!");
        }
        if (!ValidationHelper.TryValidate(organizationCreateRequest, out var validationResults))
        {
            return OperationResult.Failure<OrganizationResponse?>(operation, message: validationResults.First().ErrorMessage);
        }

        Organization? organizationToAdd = _mapper.Map<Organization>(organizationCreateRequest);
        Organization? addedOrganization = await _organizationsRepository.AddOrganizationAsync(organizationToAdd);

        if (addedOrganization == null)
        {
            return OperationResult.Failure<OrganizationResponse?>(operation, message: "Organization creation failed!");
        }

        OrgAdminMap? orgAdminMap = _mapper.Map<OrgAdminMap>(addedOrganization);
        OrgAdminMap? addedOrgAdminMap =  await _organizationsRepository.CreateOrgAdminMapAsync(orgAdminMap);

        if (addedOrgAdminMap == null)
        {
            return OperationResult.Failure<OrganizationResponse?>(operation, message: "Org Admin Map creation failed!");
        }

        OrganizationResponse? organizationResponse = _mapper.Map<OrganizationResponse>(addedOrganization);

        return OperationResult.Success(organizationResponse, operation, message: "Organization successfully created.")!;
    }

    public Task<OperationResult<OrganizationResponse?>> UpdateOrganizationAsync()
    {
        throw new NotImplementedException();
    }
}
