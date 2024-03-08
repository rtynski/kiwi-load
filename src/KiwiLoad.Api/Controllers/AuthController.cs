using Microsoft.AspNetCore.Mvc;

namespace KiwiLoad.Appi.Controllers;

[ApiController]
[Route("api/auth")]
public partial class AuthController(ILogger<AuthController> logger) : ControllerBase
{
}