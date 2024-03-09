using KiwiLoad.Api.Controllers.Auth.Login.V1.Models;
using KiwiLoad.Core.Areas.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KiwiLoad.Appi.Controllers;

public partial class AuthController
{
    [HttpPost("v1/login")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginRes>> LoginV1(
        [FromBody]
        LoginReq req,
        [FromServices]
        IAuthService authService
    )
    {
        logger.LogInformation("{HttpMethod} {ActionName}", "POST", nameof(LoginV1));
        var res = await authService.Authenticate(req.Username, req.Password);
        if (res is null)
        {
            return Unauthorized();
        }
        return Ok(new LoginRes(res));
    }
}