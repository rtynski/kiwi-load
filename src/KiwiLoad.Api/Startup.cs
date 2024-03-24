using KiwiLoad.Application;
using KiwiLoad.Core;
using KiwiLoad.Core.Areas.Users;
using KiwiLoad.Core.Authentication;
using KiwiLoad.Infrastructure;
using KiwiLoad.Infrastructure.Errors;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Caching.Memory;

namespace KiwiLoad.Api;

public class Startup
{
    private class SeedData { }
    private const string TokenScheme = nameof(TokenScheme);
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddAuthentication(TokenScheme)
            .AddScheme<AuthenticationSchemeOptions, TokenAuthenticationHandler>(TokenScheme, options => { });

        services.AddSingleton<IMemoryCache, MemoryCache>();

        services.AddErrorHandler();

        services.AddControllers();

        services.AddApplication();
        services.AddInfrastructure();
        services.AddCore();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            Initialize(app.ApplicationServices);
        }
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "KiwiLoad API V1");
        });

        app.UseErrorHandler();

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var authService = services.GetRequiredService<IUsersService>();
                authService.AddUser(new Core.Areas.Users.DTO.AddUserDto("admin", "admin@example.com", "admin"));
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<SeedData>>();
                logger.LogError(ex, "Error while seeding data.");
            }
        }
    }
}
