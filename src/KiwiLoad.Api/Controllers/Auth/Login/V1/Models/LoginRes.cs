namespace KiwiLoad.Api.Controllers.Auth.Login.V1.Models;

public class LoginRes(string token)
{
    public string Token { get; } = token;
}
