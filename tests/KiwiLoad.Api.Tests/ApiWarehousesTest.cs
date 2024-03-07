using FluentAssertions;
using KiwiLoad.Api.Controllers.Warehouses.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Text;

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


    [Fact]
    public async Task PostWarehousesV1_Should_ReturnWarehouseCreated()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Post, "/api/warehouses/v1");

        // Act
        // add barer token
        _client.DefaultRequestHeaders.Add("Authorization", "test_token");
        // Arrange
        var warehouse = new WarehouseReq { /* set properties here */ };
        request.Content = new StringContent(JsonConvert.SerializeObject(warehouse), Encoding.UTF8, "application/json");
        var response = await _client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        var stringResponse = await response.Content.ReadAsStringAsync();
        var warehouses = JsonConvert.DeserializeObject<WarehouseRes>(stringResponse);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        warehouses.Should().NotBeNull();
        warehouses!.Id.Should().Be(6);
    }

    [Fact]
    public async Task GetWarehousesV1ById_Should_ReturnWarehouse()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/warehouses/v1/1");

        // Act
        // add barer token
        _client.DefaultRequestHeaders.Add("Authorization", "test_token");
        // Arrange
        var response = await _client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        var stringResponse = await response.Content.ReadAsStringAsync();
        var warehouses = JsonConvert.DeserializeObject<WarehouseRes>(stringResponse);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        warehouses.Should().NotBeNull();
        warehouses!.Id.Should().Be(1);
    }
    [Fact]
    public async Task GetWarehousesV1ById_Should_ReturnNotFound()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/warehouses/v1/11");

        // Act
        // add barer token
        _client.DefaultRequestHeaders.Add("Authorization", "test_token");
        // Arrange
        var response = await _client.SendAsync(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetWarehousesV1ById_Should_ReturnBadRequest()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/warehouses/v1/0");

        // Act
        // add barer token
        _client.DefaultRequestHeaders.Add("Authorization", "test_token");
        // Arrange
        var response = await _client.SendAsync(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
