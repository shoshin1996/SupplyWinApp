using Microsoft.Extensions.DependencyInjection;
using SupplyWinApp.Application.Interfaces;
using SupplyWinApp.Application.Services;
using SupplyWinApp.Domain.Interfaces;
using SupplyWinApp.Infrastructure.Repositories;

namespace SupplyWinApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string usersJsonPath)
    {
        services.AddSingleton<IUserRepository>(new JsonUserRepository(usersJsonPath));
        services.AddSingleton<IAuthenticationService, AuthenticationService>();
        return services;
    }
}
