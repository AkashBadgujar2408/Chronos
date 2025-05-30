
using Chronos.Core.Entities;

namespace Chronos.Core.RepositoryContracts;

    public interface IOrganizationsRepository
    {
    Task<Organization?> AddOrganizationAsync(Organization organization);
    Task<Organization?> UpdateOrganizationAsync(Organization organization);
    Task<bool> DeleteOrganizationAsync(Guid? organizationId);
    Task<OrgAdminMap?> CreateOrgAdminMapAsync(OrgAdminMap orgAdminMap);
    }
