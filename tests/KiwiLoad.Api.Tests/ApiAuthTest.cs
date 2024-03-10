using FluentAssertions;
using KiwiLoad.Api.Controllers.Auth.Login.V1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace KiwiLoad.Api.Tests;
public class ApiAuthTest
{
    private readonly TestServer _server;
    private readonly HttpClient _client;

    public ApiAuthTest()
    {
        // Arrange
        var testServer = new WebHostBuilder()
            .UseEnvironment("Development")
            .UseStartup<Startup>();
        _server = new TestServer(testServer);
        _client = _server.CreateClient();
    }

    [Fact]
    public async Task GetLoginNoUsername_Should_ReturnUnauthorized()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Post, "/api/auth/v1/login");

        // Arrange
        var login = new LoginReq()
        {
            Username = string.Empty,
            Password = "test"
        };
        request.Content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
        var response = await _client.SendAsync(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task GetLoginNoPassword_Should_ReturnUnauthorized()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Post, "/api/auth/v1/login");

        // Arrange
        var login = new LoginReq()
        {
            Username = "Test",
            Password = string.Empty
        };
        request.Content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
        var response = await _client.SendAsync(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
}
