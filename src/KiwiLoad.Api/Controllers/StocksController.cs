using Microsoft.AspNetCore.Mvc;

namespace KiwiLoad.Api.Controllers;

[ApiController]
[Route("api/stocks")]
public partial class StocksController : ControllerBase
{
    private readonly ILogger<StocksController> logger;
    public StocksController(ILogger<StocksController> logger)
    {
        this.logger=logger;
    }
}
