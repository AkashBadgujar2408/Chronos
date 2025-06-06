
using ApplicationCore.DTOs;
using Chronos.Core.DTOs;

namespace Chronos.Core.ServiceContracts;

public interface IOrganizationsService
{
    Task<OperationResult<OrganizationResponse?>> CreateOrganizationAsync(OrganizationCreateRequest? organizationCreateRequest);
    Task<OperationResult<OrganizationResponse?>> UpdateOrganizationAsync(OrganizationUpdateRequest? organizationUpdateRequest);

    Task<OrganizationResponse?> GetUserOrganizationAsync(Guid? userId);
}
