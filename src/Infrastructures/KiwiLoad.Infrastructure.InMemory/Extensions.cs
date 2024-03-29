using KiwiLoad.Infrastructure.Databases;
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
