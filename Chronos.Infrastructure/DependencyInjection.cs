using Chronos.Core.RepositoryContracts;
using Chronos.Infrastructure.Context;
using Chronos.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chronos.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(
            options =>
            options.UseSqlServer(configuration.GetConnectionString("ChronosDBConnection"))
        );
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IOrganizationsRepository, OrganizationsRepository>();

        return services;
    }
}