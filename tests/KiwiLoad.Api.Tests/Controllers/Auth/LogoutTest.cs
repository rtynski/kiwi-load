using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Text;

namespace KiwiLoad.Api.Tests.Controller.Auth;
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
    public async Task V1_Should_NoAuthorize()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl);

        // Act
        request.Content = new StringContent(string.Empty);
        var response = await client.SendAsync(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task V1_Should_Logout()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl);

        // Act
        client.DefaultRequestHeaders.Add("Authorization", Mt.Token);
        request.Content = new StringContent("{}", Encoding.UTF8, Mt.Json);
        var response = await client.SendAsync(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
