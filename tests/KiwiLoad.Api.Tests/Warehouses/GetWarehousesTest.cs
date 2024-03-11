using FluentAssertions;
using KiwiLoad.Api.Controllers.Warehouses.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net;

namespace KiwiLoad.Api.Tests.Warehouses;
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
        server = new TestServer(testServer);
        client = server.CreateClient();
    }

    [Fact]
    public async Task V1NoAuth_Should_ReturnNoAuth()
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
        client.DefaultRequestHeaders.Add("Authorization", "test_token");
        var response = await client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();

        var stringResponse = await response.Content.ReadAsStringAsync();
        var warehouses = JsonConvert.DeserializeObject<WarehouseRes[]>(stringResponse);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        warehouses.Should().NotBeNull();
        warehouses!.Length.Should().Be(5);
    }
}
