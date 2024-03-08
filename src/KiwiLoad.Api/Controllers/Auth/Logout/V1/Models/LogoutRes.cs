namespace KiwiLoad.Api.Controllers.Auth.Logout.V1.Models;

public class LogoutRes(string message)
{
    public string Message { get; } = message;
}