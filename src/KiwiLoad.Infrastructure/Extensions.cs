using KiwiLoad.Core.Areas.Auth;
using KiwiLoad.Core.Areas.Warehouses;
using KiwiLoad.Infrastructure.Repositories.Auth;
using KiwiLoad.Infrastructure.Repositories.Warehouses;
using Microsoft.Extensions.DependencyInjection;

namespace KiwiLoad.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IAuthRepository, AuthRepository>();
        services.AddTransient<IWarehouseRepository, WarehouseRepository>();
        return services;
    }
}
