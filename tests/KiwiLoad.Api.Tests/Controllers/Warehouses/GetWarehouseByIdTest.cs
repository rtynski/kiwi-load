using FluentAssertions;
using KiwiLoad.Api.Controllers.Warehouses.Models;
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

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace KiwiLoad.Api.Tests.Controller.Warehouses;
public class GetWarehouseByIdTest
{
    private readonly TestServer server;
    private readonly HttpClient client;

    public GetWarehouseByIdTest()
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
            // Set token
            var mc = scope.ServiceProvider.GetRequiredService<IMemoryCache>();
            mc.Set(Mt.Token, Mt.Username);

            // Init db for test
            var db = scope.ServiceProvider.GetRequiredService<IDbContext>();
            db.Database.EnsureDeleted();
            db.Warehouses.Add(new Warehouse { Id = 1, Name = "Test" });
            db.SaveChangesAsync().Wait();
        }
    }

    [Fact]
    public async Task V1_ById_Should_ReturnWarehouse()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/warehouses/v1/1");

        // Act
        client.DefaultRequestHeaders.Add("Authorization", Mt.Token);
        var response = await client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();

        var stringResponse = await response.Content.ReadAsStringAsync();
        var warehouses = JsonConvert.DeserializeObject<WarehouseRes>(stringResponse);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        warehouses.Should().NotBeNull();
        warehouses!.Id.Should().Be(1);
    }

    [Fact]
    public async Task V1_ById_Should_ReturnNotFound()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/warehouses/v1/11");

        // Act
        client.DefaultRequestHeaders.Add("Authorization", Mt.Token);
        var response = await client.SendAsync(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task V1_ById_Should_ReturnBadRequest()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/warehouses/v1/0");

        // Act
        client.DefaultRequestHeaders.Add("Authorization", Mt.Token);
        var response = await client.SendAsync(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
