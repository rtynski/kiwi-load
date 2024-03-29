using FluentAssertions;
using KiwiLoad.Application.Security;
using KiwiLoad.Infrastructure.Databases;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Net;
using System.Text;

namespace KiwiLoad.Api.Tests.Controller.Auth;
public class LogoutTest
{
    private const string BaseUrl = "/api/auth/v1/logout";
    private readonly TestServer server;
    private readonly HttpClient client;

    public LogoutTest()
    {
        var testServer = new WebHostBuilder()
            .UseEnvironment("Development")
            .UseStartup<Startup>();
        // Replace ITokenGeneratorProvider
        testServer.ConfigureTestServices(services =>
        {
            services.Remove(services.First(d => d.ServiceType == typeof(ITokenGeneratorProvider)));
            var tokenProviderMock = new Mock<ITokenGeneratorProvider>();
            tokenProviderMock.Setup(x => x.GenerateToken(It.IsAny<int>())).Returns(Mt.Token);
            services.AddSingleton(tokenProviderMock.Object);
        });
        server = new TestServer(testServer);
        client = server.CreateClient();
        // init in scoped
        using (var scope = server.Services.CreateScope())
        {
            var mc = scope.ServiceProvider.GetRequiredService<IMemoryCache>();
            mc.Set(Mt.Token, Mt.Username);

            var db = scope.ServiceProvider.GetRequiredService<IDbContext>();
            db.Database.EnsureDeleted();
            db.SaveChangesAsync().Wait();
        }
    }

    [Fact]
    public async Task V1_Should_NoAuthorize()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl);

        // Act
        request.Content = new StringContent(string.Empty);
        var response = await client.SendAsync(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task V1_Should_Logout()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl);

        // Act
        client.DefaultRequestHeaders.Add("Authorization", Mt.Token);
        request.Content = new StringContent("{}", Encoding.UTF8, Mt.Json);
        var response = await client.SendAsync(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
