
using Chronos.Core.Mappers;
using Chronos.Core.ServiceContracts;
using Chronos.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Chronos.Core;
public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ApplicationUserToAuthenticationResponseMappingProfile).Assembly);
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IOrganizationsService, OrganizationsService>();
        services.AddScoped<JwtService>();

        return services;
    }
}
