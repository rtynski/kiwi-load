using KiwiLoad.Application.Services.Warehouses;
using KiwiLoad.Core.Areas.Warehouses;
using Microsoft.Extensions.DependencyInjection;

namespace KiwiLoad.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IWarehousesService, WarehousesService>();
        return services;
    }
}
