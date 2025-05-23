
using Chronos.Core.Entities;

namespace Chronos.Core.RepositoryContracts;

    public interface IOrganizationsRepository
    {
    Task<Organization?> AddOrganization(Organization organization);
    Task<Organization?> UpdateOrganization(Organization organization);
    Task<bool> DeleteOrganization(Guid? organizationId);
    }
