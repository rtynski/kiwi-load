using KiwiLoad.Application.Security;
using KiwiLoad.Application.Security.Providers;
using KiwiLoad.Application.Services.Auth;
using KiwiLoad.Application.Services.Users;
using KiwiLoad.Application.Services.Warehouses;
using KiwiLoad.Core.Areas.Auth;
using KiwiLoad.Core.Areas.Users;
using KiwiLoad.Core.Areas.Warehouses;
using Microsoft.Extensions.DependencyInjection;

namespace KiwiLoad.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Providers
        services.AddSingleton<ITokenGeneratorProvider, TokenGeneratorProvider>();
        services.AddSingleton<IPasswordHashGeneratorProvider, PasswordHashGeneratorProvider>();

        // Transient
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IUsersService, UsersService>();
        services.AddTransient<IWarehousesService, WarehousesService>();

        return services;
    }
}
