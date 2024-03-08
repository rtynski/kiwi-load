namespace KiwiLoad.Api.Controllers.Auth.Login.V1.Models;

public class LoginReq
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
