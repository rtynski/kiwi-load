using KiwiLoad.Core.Areas.Auth;
using KiwiLoad.Core.Areas.Users;
using KiwiLoad.Core.Areas.Warehouses;
using KiwiLoad.Infrastructure.Databases;
using KiwiLoad.Infrastructure.Repositories.Auth;
using KiwiLoad.Infrastructure.Repositories.Users;
using KiwiLoad.Infrastructure.Repositories.Warehouses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KiwiLoad.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        _ = services.AddDbContext<KiwiDbContext>((options) =>
        {
            options.UseInMemoryDatabase("KiwiLoad");
        }, ServiceLifetime.Transient);

        services.AddTransient<IDbContext, KiwiDbContext>();
        services.AddInfrastructureBase();
        return services;
    }
}
