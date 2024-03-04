using KiwiLoad.Application;
using KiwiLoad.Core;
using KiwiLoad.Core.Authentication;
using KiwiLoad.Infrastructure;
using Microsoft.AspNetCore.Authentication;

namespace KiwiLoad.Api;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthentication("TokenScheme")
                .AddScheme<AuthenticationSchemeOptions, TokenAuthenticationHandler>("TokenScheme", options => { });


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
