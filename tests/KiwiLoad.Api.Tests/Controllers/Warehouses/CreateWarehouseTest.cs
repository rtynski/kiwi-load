using FluentAssertions;
using KiwiLoad.Api.Controllers.Warehouses.Models;
using KiwiLoad.Application.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace KiwiLoad.Api.Tests.Controller.Warehouses;
public class CreateWarehouseTest
{
    private const string BaseUrl = "/api/warehouses/v1";
    private readonly TestServer server;
    private readonly HttpClient client;

    public CreateWarehouseTest()
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
        }
    }

    [Fact]
    public async Task V1_Should_ReturnWarehouseCreated()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl);

        // Act
        client.DefaultRequestHeaders.Add("Authorization", Mt.Token);
        var warehouse = new WarehouseReq {
            Name = "Test"
        };
        request.Content = new StringContent(JsonConvert.SerializeObject(warehouse), Encoding.UTF8, Mt.Json);
        var response = await client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();

        var stringResponse = await response.Content.ReadAsStringAsync();
        var warehouses = JsonConvert.DeserializeObject<WarehouseRes>(stringResponse);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        warehouses.Should().NotBeNull();
        warehouses!.Id.Should().Be(1);
    }
}
