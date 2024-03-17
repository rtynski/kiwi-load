using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

namespace KiwiLoad.Core.Authentication;
public class TokenAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private const string Token = "BAt4IElJoNDnvinqH6gMBhBO9Y8YLLBk0N4SZkijQEz9VBqVfuXuUSzFDDClD3Ya";

    public TokenAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock) :
        base(options, logger, encoder, clock)
    {
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        await Task.Yield();
        var token = Request.Headers["Authorization"];
        token = token.ToString().Replace("Bearer ", "");

        if (token == Token)
        {
            var claims = new[]
            {
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, "test"),
            };

            var identity = new System.Security.Claims.ClaimsIdentity(claims, Scheme.Name);
            var principal = new System.Security.Claims.ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
        else
        {
            return AuthenticateResult.Fail("Unauthorized");
        }
    }
}
