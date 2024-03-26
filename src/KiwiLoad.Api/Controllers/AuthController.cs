using Microsoft.AspNetCore.Mvc;

namespace KiwiLoad.Appi.Controllers;

[ApiController]
[Route("api/auth")]
public partial class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> logger;
    public AuthController(ILogger<AuthController> logger)
    {
        this.logger=logger;
    }
}