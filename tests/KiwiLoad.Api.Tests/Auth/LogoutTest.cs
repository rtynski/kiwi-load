using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;

namespace KiwiLoad.Api.Tests.Auth;
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
        server = new TestServer(testServer);
        client = server.CreateClient();
    }

    

    [Fact]
    public async Task LogoutV1WithoutKey_Should_ReturnUnauthorized()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl);
        // Act
        request.Content = new StringContent(string.Empty);
        var response = await client.SendAsync(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
}
