using KiwiLoad.Api.Controllers.Auth.Logout.V1.Models;
using Microsoft.AspNetCore.Mvc;

namespace KiwiLoad.Appi.Controllers;

public partial class AuthController
{
    [HttpPost("logout")]
    public async Task<ActionResult<LogoutRes>> Logout()
    {
        await Task.Yield();
        return Ok(new LogoutRes("token"));
    }
}