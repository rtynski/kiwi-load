using KiwiLoad.Api.Controllers.Auth.Logout.V1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KiwiLoad.Appi.Controllers;

public partial class AuthController
{
    [HttpPost("v1/logout")]
    [Authorize]
    public async Task<ActionResult<LogoutRes>> LogoutV1()
    {
        await Task.Yield();
        logger.LogInformation("{HttpMethod} {ActionName}", "POST", nameof(LogoutV1));
        return Ok(new LogoutRes("token"));
    }
}