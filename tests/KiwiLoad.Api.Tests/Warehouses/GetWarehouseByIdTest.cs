using FluentAssertions;
using KiwiLoad.Api.Controllers.Warehouses.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net;

namespace KiwiLoad.Api.Tests.Warehouses;
public class GetWarehouseByIdTest
{
    private const string BaseUrl = "/api/warehouses/v1";
    private readonly TestServer server;
    private readonly HttpClient client;

    public GetWarehouseByIdTest()
    {
        var testServer = new WebHostBuilder()
            .UseEnvironment("Development")
            .UseStartup<Startup>();
        server = new TestServer(testServer);
        client = server.CreateClient();
    }
    [Fact]
    public async Task V1ById_Should_ReturnWarehouse()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/warehouses/v1/1");

        // Act
        client.DefaultRequestHeaders.Add("Authorization", "test_token");
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
    public async Task V1ById_Should_ReturnNotFound()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/warehouses/v1/11");

        // Act
        client.DefaultRequestHeaders.Add("Authorization", "test_token");
        var response = await client.SendAsync(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task V1ById_Should_ReturnBadRequest()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/warehouses/v1/0");

        // Act
        client.DefaultRequestHeaders.Add("Authorization", "test_token");
        var response = await client.SendAsync(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
