using FluentAssertions;
using KiwiLoad.Api.Controllers.Warehouses.GetWarehouses.V1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net;

namespace KiwiLoad.Api.Tests;

public class WarehousesControllerTests
{
    private readonly TestServer _server;
    private readonly HttpClient _client;

    public WarehousesControllerTests()
    {
        // Arrange
        var testServer = new WebHostBuilder()
            .UseEnvironment("Development")
            .UseStartup<Startup>();
        _server = new TestServer(testServer);
        _client = _server.CreateClient();
    }

    [Fact]
    public async Task GetWarehousesV1NoAuth_Should_ReturnNoAuth()
    {
        // Arrange
        var request = "/api/warehouses/v1";

        // Act
        var response = await _client.GetAsync(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task GetWarehousesV1_Should_ReturnCollectionOfWarehouses()
    {
        // Arrange
        var request = "/api/warehouses/v1";

        // Act
        // add barer token
        _client.DefaultRequestHeaders.Add("Authorization", "test_token");
        var response = await _client.GetAsync(request);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        var stringResponse = await response.Content.ReadAsStringAsync();
        var warehouses = JsonConvert.DeserializeObject<WarehouseRes[]>(stringResponse);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        warehouses.Should().NotBeNull();
        warehouses!.Length.Should().Be(5);
    }
}
