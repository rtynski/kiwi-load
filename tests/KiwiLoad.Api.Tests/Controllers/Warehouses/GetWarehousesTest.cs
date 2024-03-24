using FluentAssertions;
using KiwiLoad.Api.Controllers.Warehouses.Models;
using KiwiLoad.Application.Security;
using KiwiLoad.Infrastructure.Databases;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using System.Net;

namespace KiwiLoad.Api.Tests.Controller.Warehouses;
public class GetWarehousesTest
{
    private const string BaseUrl = "/api/warehouses/v1";
    private readonly TestServer server;
    private readonly HttpClient client;

    public GetWarehousesTest()
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
        // Init in scoped
        using (var scope = server.Services.CreateScope())
        {
            // Set token
            var mc = scope.ServiceProvider.GetRequiredService<IMemoryCache>();
            mc.Set(Mt.Token, Mt.Username);

            // Init db for test
            var db = scope.ServiceProvider.GetRequiredService<KiwiDbContext>();
            db.Database.EnsureDeleted();
            db.SaveChanges();
        }
    }

    [Fact]
    public async Task V1_NoAuth_Should_ReturnNoAuth()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Get, BaseUrl);

        // Act
        var response = await client.SendAsync(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task V1_Should_ReturnCollectionOfWarehouses()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Get, BaseUrl);

        // Act
        client.DefaultRequestHeaders.Add("Authorization", Mt.Token);
        var response = await client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();

        var stringResponse = await response.Content.ReadAsStringAsync();
        var warehouses = JsonConvert.DeserializeObject<WarehouseRes[]>(stringResponse);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        warehouses.Should().NotBeNull();
        warehouses!.Length.Should().Be(0);
    }
}
