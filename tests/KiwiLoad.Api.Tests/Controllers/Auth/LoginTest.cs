using FluentAssertions;
using KiwiLoad.Api.Controllers.Auth.Login.V1.Models;
using KiwiLoad.Application.Security;
using KiwiLoad.Infrastructure.Databases;
using KiwiLoad.Infrastructure.Databases.Entries;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace KiwiLoad.Api.Tests.Controller.Auth;
public class LoginTest
{
    private const string BaseUrl = "/api/auth/v1/login";
    private readonly TestServer server;
    private readonly HttpClient client;

    public LoginTest()
    {
        var testServer = new WebHostBuilder()
            .UseEnvironment("Development")
            .UseStartup<Startup>();
        server = new TestServer(testServer);
        client = server.CreateClient();

        testServer.ConfigureTestServices(services =>
        {
            services.Remove(services.First(d => d.ServiceType == typeof(ITokenGeneratorProvider)));
            var tokenProviderMock = new Mock<ITokenGeneratorProvider>();
            tokenProviderMock.Setup(x => x.GenerateToken(It.IsAny<int>())).Returns(Mt.Token);
            services.AddSingleton(tokenProviderMock.Object);
        });

        // Init in scoped
        using (var scope = server.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<KiwiDbContext>();
            db.Database.EnsureDeleted();
            db.Users.Add(new User { Id = 1, Username = "admin", PasswordHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918" });
            db.SaveChanges();
        }
    }
    [Fact]
    public async Task LoginV1NoUsername_Should_ReturnUnauthorized()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl);

        // Act
        var login = new LoginReq()
        {
            Username = string.Empty,
            Password = "test"
        };
        request.Content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, Mt.Json);
        var response = await client.SendAsync(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task LoginV1NoPassword_Should_ReturnUnauthorized()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl);

        // Act
        var login = new LoginReq()
        {
            Username = "Test",
            Password = string.Empty
        };
        request.Content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, Mt.Json);
        var response = await client.SendAsync(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task V1WrongPassword_Should_Authorized()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl);

        // Act
        var login = new LoginReq()
        {
            Username = "Test",
            Password = "Test"
        };
        request.Content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, Mt.Json);
        var response = await client.SendAsync(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    // Disable temporary
    public async Task V1_Should_Authorized()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl);

        // Act
        var login = new LoginReq()
        {
            Username = "admin",
            Password = "admin"
        };
        request.Content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, Mt.Json);
        var response = await client.SendAsync(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
