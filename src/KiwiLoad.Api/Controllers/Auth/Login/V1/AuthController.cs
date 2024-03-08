using KiwiLoad.Api.Controllers.Auth.Login.V1.Models;
using Microsoft.AspNetCore.Mvc;

namespace KiwiLoad.Appi.Controllers;

public partial class AuthController
{
    [HttpPost("login")]
    public async Task<ActionResult<LoginRes>> Login([FromBody] LoginReq req)
    {
        await Task.Yield();
        return Ok(new LoginRes("token"));
    }
}