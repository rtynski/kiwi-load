using KiwiLoad.Application;
using KiwiLoad.Core;
using KiwiLoad.Core.Authentication;
using KiwiLoad.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using KiwiLoad.Infrastructure.Errors;

namespace KiwiLoad.Api;

public class Startup
{
    private const string TokenScheme = nameof(TokenScheme);
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddAuthentication(TokenScheme)
            .AddScheme<AuthenticationSchemeOptions, TokenAuthenticationHandler>(TokenScheme, options => { });

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
        }

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
}
